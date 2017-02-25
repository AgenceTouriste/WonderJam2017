using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public void Start()
    {
        GetComponent<SpriteRenderer>().material.color = Color.green;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().material.color = Color.red;
        Debug.Log("Red");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().material.color = Color.green;
        Debug.Log("Green");
    }

}
