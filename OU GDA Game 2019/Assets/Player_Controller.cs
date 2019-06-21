using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public CharacterController controller;

    public float gravity = -1;
    public float jumpStrength = 5;
    public float moveSpeed = 5;

    float vertical_velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3();

        if (!controller.isGrounded)
        {
            vertical_velocity += gravity;
        }
        else
        {
            vertical_velocity = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector3(1f, 0, 0) * moveSpeed;
        }     
        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector3(-1f, 0, 0) * moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vertical_velocity = jumpStrength;
        }

        velocity.y = vertical_velocity;
        controller.Move(velocity * Time.deltaTime);

    }
}
