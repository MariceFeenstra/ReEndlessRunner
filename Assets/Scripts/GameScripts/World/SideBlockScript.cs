using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBlockScript : MonoBehaviour {

    public Vector3 RebounceDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "Player")
        {
            WorldScript.World.player.GetComponent<PlayerControlScript>().HorizontalMove(RebounceDirection);
        }
    }



}
