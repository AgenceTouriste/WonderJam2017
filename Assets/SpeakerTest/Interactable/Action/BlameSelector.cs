using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BlameSelector : MonoBehaviour
{
    public Blame blame;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask mask = LayerMask.NameToLayer("Enemies");
            if (Physics.Raycast(ray, out hit))
            {
                GameObject tmp = hit.collider.gameObject;
                if(tmp.GetComponent<StatePatternEnemy>().currentState is PatrolState)
                {
                    blame.SendMessage("OnBizutFound", tmp);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
