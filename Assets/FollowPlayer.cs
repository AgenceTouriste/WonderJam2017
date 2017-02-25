using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public bool followPlayer = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (followPlayer == true)
        {
            cameraFollowPlayer();
        }
	}

    public void setFollowPlayer(bool val)
    {
        followPlayer = val;
    }

    private void cameraFollowPlayer ()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        transform.position = newPos;
    }
}
