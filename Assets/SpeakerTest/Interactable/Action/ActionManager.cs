using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private Action selectedAction;
    // Use this for initialization
    void Start()
    {
        selectedAction = null;
    }

    public void ChooseAction(Action input)
    {
        selectedAction = input;
    }

    public void ResetAction()
    {
        selectedAction = null;
    }

    public void ExecuteAction()
    {
        //Do shit about selectedAction then go back to inactive
        if (selectedAction != null)
        {

        }
        ResetAction();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
