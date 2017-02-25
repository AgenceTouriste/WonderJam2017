using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public CircleCollider2D clickableArea;

    public Sprite inactive;
    public Sprite active;
    SpriteRenderer spriteRenderer;

    //ToDo Change type
    private HashSet<GameObject> affectableAgents;

    public virtual void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
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
        spriteRenderer.sprite = active;
        foreach (var agent in affectableAgents)
        {
            //ToDo change their color
        }

    }

    public virtual void OnClickEnd()
    {
        spriteRenderer.sprite = inactive;
        foreach (var agent in affectableAgents)
        {
            //ToDo revert their color to normal
        }
    }
}
