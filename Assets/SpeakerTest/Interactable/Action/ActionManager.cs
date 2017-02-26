using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private Action selectedAction;
    public Speaker truc;
    private bool waitForBizut;
    // Use this for initialization
    void Start()
    {
        selectedAction = null;
        waitForBizut = false;
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
        if (!(selectedAction is Blame))
        {
            Execute4Real();
        }
        else
        {
            if (!waitForBizut)
            {
                BroadcastMessage("ActivateBlameSelector");
                waitForBizut = true;
            }
        }   
    }

    private void Execute4Real()
    {
        if (selectedAction != null)
        {
            selectedAction.Execute(truc.affectableAgents);
        }
        ResetAction();
        gameObject.SetActive(false);
    }

    public void SpecialBlameExecutor()
    {
        waitForBizut = false;
        Execute4Real();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
