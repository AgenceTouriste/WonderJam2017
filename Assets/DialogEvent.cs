using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvent : MonoBehaviour {

    private bool played = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!played) {
            if (collider.gameObject.CompareTag("Player"))
            {
                GetComponentInChildren<AudioSource>().Play();
                played = true;
            }

        }
        
    }

}
