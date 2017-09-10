using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControlScript : MonoBehaviour {

    public ParticleSystem.MainModule particles;

    public float StandartParticleSize;

	// Use this for initialization
	void Start () {
        particles = gameObject.GetComponent<ParticleSystem>().main;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(WorldScript.World.player.isJumping())
        {
            particles.startSizeMultiplier = 0;
        }
        else
        {
            particles.startSizeMultiplier = StandartParticleSize;
        }


	}
}
