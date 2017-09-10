using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public float Score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.name =="Player")
        {
            WorldScript.World.player.GetComponent<PlayerStatScript>().PickupCoin(Score);

            ObjectPool.returnItem(gameObject);
        }
    }

    public void Init(Vector3 position)
    {
        transform.position = position;
    }
}
