using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //Inspector Variables
    public float speed = 6.0F;
    public float maxSpeed = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public Rigidbody rb;


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
        force = Vector3.ClampMagnitude(force, speed);
        rb.AddForce(force);
    }

}