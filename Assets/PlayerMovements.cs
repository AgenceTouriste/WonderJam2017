using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //Inspector Variables
    public float speed = 6.0F;
    public float rotSpeed;
    public float slowdown;
    public float maxSpeed = 20.0F;
    private Rigidbody rb;
    private bool hasSlowdown = true;
    private Vector3 toward;

    void Start()
    {
        toward = transform.forward;
    }

    void FixedUpdate()
    {
        Move();
        //MoveForward();
        //Align();
    }

    //private void Align()
    //{
    //    Vector3 force = Vector3.zero;
    //    float delta = Vector3.Angle(transform.forward,toward);
    //    //Vector3.ClampMagnitude(delta, rotSpeed);
    //    delta = Mathf.Min(delta, rotSpeed);
    //    rb.AddTorque(delta * Vector3.up);
    //}

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
        if (force.magnitude == 0)
        {
            rb.velocity = Vector3.zero;
        }
        force = Vector3.ClampMagnitude(force, speed);
        rb.AddRelativeForce(force);
        if (force.magnitude != 0)
            toward = force.normalized;
        //rb.Ad(transform.up,Vector3.Angle(transform.forward,force));
    }

    public void Move()
    {
        GetComponent<Animator>().SetBool("isMoving", false);
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("isMoving", true);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(movement),
                Time.fixedDeltaTime * rotSpeed
            );
        }
        
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    GetComponent<Animator>().SetBool("isRunning", true);
        //}
        //else
        //{
        //    GetComponent<Animator>().SetBool("isRunning", false);
        //}
    }

}