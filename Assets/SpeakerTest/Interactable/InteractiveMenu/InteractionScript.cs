using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{

    public float InteractivityRange = 1000;
    public float DeadzoneRange = 100;
    public float dist;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            Action[] Buttons = this.GetComponentsInChildren<Action>();

            float distanceToCenter = Vector3.Distance(Vector3.ProjectOnPlane(Vector3.up,Camera.main.ScreenToWorldPoint(Input.mousePosition)), Vector3.ProjectOnPlane(Vector3.up,transform.position));
            dist = distanceToCenter;    
            if (distanceToCenter > InteractivityRange)
            {
                CloseMenu();
            }
            else if (distanceToCenter > DeadzoneRange)
            {
                float old_distance = InteractivityRange;
                int i = 0;
                int j = 0;
                while (i < Buttons.Length)
                {
                    float distance = Vector3.Distance(Vector3.ProjectOnPlane(Vector3.up, Camera.main.ScreenToWorldPoint(Input.mousePosition)), Vector3.ProjectOnPlane(Vector3.up, Buttons[i].gameObject.transform.position));
                    if (distance < old_distance)
                    {
                        old_distance = distance;
                        j = i;
                    };
                    i++;
                }
                for (int k = 0; k < Buttons.Length; k++)
                {
                    if (k == j)
                    {
                        Buttons[k].gameObject.GetComponent<Image>().color = Color.green;
                    }
                    else
                    {
                        Buttons[k].gameObject.GetComponent<Image>().color = Color.white;
                    }
                }

            }
            else
            {
                for (int k = 0; k < Buttons.Length; k++)
                {
                    Buttons[k].gameObject.GetComponent<Image>().color = Color.white;
                }
            }
        }
    }


    /// <summary>
    /// Close the menu and reset the buttons with default colors
    /// </summary>
    void CloseMenu()
    {
        Action[] Buttons = this.GetComponentsInChildren<Action>();
        for (int k = 0; k < Buttons.Length; k++)
        {
            Buttons[k].gameObject.GetComponent<Image>().color = Color.white;
        }
        transform.GetChild(0).gameObject.SetActive(false);
    }

    /// <summary>
    /// Open the actions menu when holding the left click button on the object
    /// </summary>
    void OnMouseDown()
    {
        //Debug.Log("mousedown");
        transform.GetChild(0).gameObject.SetActive(true);
    }


    /// <summary>
    /// Close the actions menu when letting go of the left click button
    /// </summary>
    void OnMouseUp()
    {
        CloseMenu();
    }
    

}


