using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    Rigidbody rb;
    public float speed = 10;
    public float jumpSpeed = 5;
    float yaw;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Cursor.visible = false; //Press ESC to make visible
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        yaw += Input.GetAxis("Mouse X") * 5;
        transform.eulerAngles = new Vector3(0, yaw, 0);

        Vector3 velocity = new Vector3(0,0,0);
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        velocity.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (velocity.magnitude > 0)
        {
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
            this.rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        }

        if (rb.velocity.y < 1)
        {
            this.rb.AddForce(new Vector3(0, -15, 0));
        }

        this.transform.Translate(velocity);
    }
    bool isGrounded()
    {
        //Shoot a ray down from center of player to see if we are touching the ground
        //Length of ray is height from center of player to bottom of player (0.5 in this case) + 0.1 to reach the ground
        return Physics.Raycast(this.transform.position, Vector3.down, 1.1f);
    }
}
