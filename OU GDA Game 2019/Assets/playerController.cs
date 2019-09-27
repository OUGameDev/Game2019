using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    public Camera cam;

    float yaw;
    float pitch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * 8;
        transform.eulerAngles = new Vector3(0, yaw, 0);

        Vector3 velocity = new Vector3(0, 0, 0);
        velocity.x = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;
        velocity.z = Input.GetAxis("Vertical") * 10 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        transform.Translate(velocity);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collision");
    }

    void OnTriggerExit(Collider col)
    {

    }
}
