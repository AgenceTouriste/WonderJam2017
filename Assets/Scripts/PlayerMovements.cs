using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //Inspector Variables
    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        Movement();
    }

    public void Movement()
    {

        if (Input.GetKey(KeyCode.Z))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.Q))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }


    }

}