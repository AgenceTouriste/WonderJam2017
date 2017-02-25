using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {

    private bool isClicked = false;

	// Use this for initialization
	void Start () {
        isClicked = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown() {
        isClicked = !isClicked;
        if (isClicked) {
            Debug.Log("Clicked and opening menu");
        }
        else {
            Debug.Log("Closing Menu");
        };
        transform.GetChild(0).gameObject.SetActive(isClicked);
        
    }
    
}


