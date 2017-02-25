using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //Inspector Variables
    public float speed = 6.0F;
    public float maxSpeed = 20.0F;
    private Vector3 moveDirection = Vector3.zero;


    void Start()
    {
    }

    void FixedUpdate()
    {
        MoveForward();

    }

    public void MoveForward()
    {

        if (Input.GetKey("up"))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(0, speed * Time.fixedDeltaTime, 0);
        }
        if (Input.GetKey("down"))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(0, -speed * Time.fixedDeltaTime, 0);
        }
        if (Input.GetKey("right"))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
        }
        if (Input.GetKey("left"))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(-speed * Time.fixedDeltaTime, 0, 0);
        }
        

    }

}