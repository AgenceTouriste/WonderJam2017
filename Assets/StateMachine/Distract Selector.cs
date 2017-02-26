using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GetComponent<DistractSelector>().isActiveAndEnabled)
        {
            GetComponent<DistractSelector>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.CompareTag("Interactive"))
                {

                }
            }
            GetComponent<DistractSelector>().enabled = false;
        }
    }
}
