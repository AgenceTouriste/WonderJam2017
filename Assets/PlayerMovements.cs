using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //Inspector Variables
    public float speed = 6.0F;
    public float slowdown;
    public float maxSpeed = 20.0F;
    public Rigidbody rb;
    private bool hasSlowdown = true;

    void Start()
    {
    }

    void FixedUpdate()
    {
        MoveForward();
    }

    public void MoveForward()
    {
        Vector3 force = Vector3.zero;
        if (Input.GetAxis("Vertical") > 0)
        {
            force += Vector3.forward * speed;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            force += Vector3.back * speed;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            force += Vector3.right * speed;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            force += Vector3.left * speed;
        }
        if(force.magnitude==0)
        {
            rb.velocity = Vector3.zero;
        }
        force = Vector3.ClampMagnitude(force,speed);
        rb.AddForce(force);

    }

}