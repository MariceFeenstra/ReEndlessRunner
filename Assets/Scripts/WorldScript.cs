using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour {

    public static WorldScript World;
    public PlayerControlScript player;
    public ControllScript Controll;

    private float curvedWorldChangeDirection;
    

	// Use this for initialization
	void Start () {
        World = this;

        SkillList.Init();
        Controll.ControllInit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void checkDirection()
    {
        //if(Mathf.Abs())
    }





}
