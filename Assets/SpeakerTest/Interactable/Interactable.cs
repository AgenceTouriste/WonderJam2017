using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject ui;

    MeshFilter meshFilter;

    //ToDo Change type
    public HashSet<StatePatternEnemy> affectableAgents;

    public virtual void Start()
    {
        affectableAgents = new HashSet<StatePatternEnemy>();
        meshFilter = this.GetComponent<MeshFilter>();
    }

    void Update()
    {
        this.transform.parent.LookAt(Camera.main.transform);
        ui.transform.eulerAngles = new Vector3(90,180,180);
    }

    protected void RegisterAgent(StatePatternEnemy agent)
    {
        Debug.Log("Hi agent", agent);
        affectableAgents.Add(agent);
    }

    protected void UnregisterAgent(StatePatternEnemy agent)
    {
        Debug.Log("Bye agent", agent);
        affectableAgents.Remove(agent);
    }

    public virtual void OnClickStart()
    {
        foreach (var agent in affectableAgents)
        {
            //ToDo change their color
        }

    }

    public virtual void OnClickEnd()
    {

        foreach (var agent in affectableAgents)
        {
            //ToDo revert their color to normal
        }
    }
}
