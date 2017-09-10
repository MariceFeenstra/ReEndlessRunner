using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Vector3 RelCameraPosition;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FollowPlayerPosition();
        LookAtPlayer();

	}


    private void FollowPlayerPosition()
    {
        transform.position = (Vector3.forward * WorldScript.World.player.PlayerTransform.position.z) + RelCameraPosition;
    }

    private void LookAtPlayer()
    {
        Vector3 targetDir = WorldScript.World.player.PlayerTransform.position;
        transform.LookAt(targetDir);
    }



}
