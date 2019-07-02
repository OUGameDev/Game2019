using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider col;

    public float jumpStrength = 5;
    public float moveSpeed = 5;
    float bonusMoveSpeed = 0;
    Vector3 velocity;

    List<GameObject> inventory = new List<GameObject>();

    enum playerState { grounded, climbing, airborne, hanging };
    playerState state = playerState.grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        velocity = Vector3.zero;

        switch (state)
        {
            case playerState.grounded:
                rb.useGravity = true;
                velocity = Vector3.right * Input.GetAxis("Horizontal") * (moveSpeed + bonusMoveSpeed);

                if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
                {
                    rb.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
                    state = playerState.airborne;
                }

                break;
            case playerState.climbing:
                rb.useGravity = false;

                velocity = Vector3.up * Input.GetAxis("Vertical") * moveSpeed;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
                    state = playerState.airborne;
                }

                break;
            case playerState.airborne:
                rb.useGravity = true;

                velocity = Vector3.right * Input.GetAxis("Horizontal") * moveSpeed;

                if (Input.GetKeyDown(KeyCode.Space) && !isGrounded())
                {
                    if (Physics.Raycast(transform.position, Vector3.right, 0.1f) || Physics.Raycast(transform.position, Vector3.left, 0.1f))
                    {
                        rb.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
                    }
                }

                if (isGrounded()) state = playerState.grounded;

                break;
            case playerState.hanging:
                rb.useGravity = false;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
                    state = playerState.airborne;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    state = playerState.airborne;
                }

                break;
        };
        rb.AddForce(velocity, ForceMode.Force);
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.name == "Ladder")
        {
            rb.velocity = Vector3.zero;
            state = playerState.climbing;
        }
        else if ((hit.gameObject.name == "Ledge") && (hit.transform.position.y - transform.position.y > 0.15))
        {
            rb.velocity = Vector3.zero;
            transform.position = hit.transform.position - (Vector3.down * 0.5f);
            state = playerState.hanging;
        }
        else if (hit.gameObject.name == "Key")
        {
            //inventory.add(hit);
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.name == "PowerUp")
        {
            Debug.Log("POWERUP");

            PowerUp p = hit.gameObject.GetComponent<PowerUpObject>().GetPowerUp();

            AddEffect(p);
            StartCoroutine(RemoveEffect(p));
            Destroy(hit.gameObject);
        }
    }

    void AddEffect(PowerUp p)
    {
        bonusMoveSpeed += p.bonusMoveSpeed;
        Debug.Log(bonusMoveSpeed);
    }

    IEnumerator RemoveEffect(PowerUp p)
    {
        yield return new WaitForSeconds(p.duration);

        bonusMoveSpeed -= p.bonusMoveSpeed;
        Debug.Log(bonusMoveSpeed);
    }

    bool UseItem(string key)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].name == key)
            {
                inventory.Remove(inventory[i]);
                return true;
            }
        }
        return false;
    }


}
