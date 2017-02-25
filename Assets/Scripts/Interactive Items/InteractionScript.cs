using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{


    public float InteractivityRange = 1000;
    public float DeadzoneRange = 100;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            Button[] Buttons = this.GetComponentsInChildren<Button>();

            float distanceToCenter = Vector2.Distance((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), (Vector2)transform.position);

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
                    float distance = Vector2.Distance((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), (Vector2)Buttons[i].gameObject.GetComponent<Transform>().position);
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
        Button[] Buttons = this.GetComponentsInChildren<Button>();
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


