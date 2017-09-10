using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    private Text scoreText;

    // Use this for initialization
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreToString();
    }



    string ScoreToString()
    {
        string str = "Score: ";
        str += WorldScript.World.player.GetComponent<PlayerStatScript>().GetScore().ToString();

        return str;
    }

}
