using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public CharacterController controller;

    public float gravity = -1;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.isGrounded)
        {
            velocity += new Vector3(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector3(1f, 0, 0);
        }     
        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector3(-1f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity += Vector3.up;
        }

        controller.Move(velocity);

    }
}
