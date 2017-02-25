using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public SphereCollider clickableArea;
    
    MeshFilter meshFilter;

    //ToDo Change type
    private HashSet<GameObject> affectableAgents;

    public virtual void Start()
    {
        meshFilter = this.GetComponent<MeshFilter>();
    }

    void FixedUpdate()
    {

    }

    protected void RegisterAgent(GameObject agent)
    {
        affectableAgents.Add(agent);
    }

    protected void UnregisterAgent(GameObject agent)
    {
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
