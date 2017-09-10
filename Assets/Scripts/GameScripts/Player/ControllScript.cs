using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllScript : MonoBehaviour {


    PlayerControlScript player;

    Vector2 TouchInputBeginPos;



    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        #region PC Input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            InputLeft();
        if(Input.GetKeyDown(KeyCode.RightArrow))
            InputRight();
        if(Input.GetKeyDown(KeyCode.UpArrow))
            InputJump();
        if(Input.GetKeyDown(KeyCode.DownArrow))
            InputCrouch();

        #endregion

        #region Touch Input

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                TouchInputBeginPos = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                Vector2 deltaTouchMovement = touch.position - TouchInputBeginPos;

                if(Mathf.Abs(deltaTouchMovement.x) > Mathf.Abs(deltaTouchMovement.y))
                {
                    if(deltaTouchMovement.x > 0)
                    {
                        InputRight();
                    }
                    else
                    {
                        InputLeft();
                    }


                }
                else
                {
                    if(deltaTouchMovement.y > 0)
                    {
                        InputJump();
                    }
                    else
                    {
                        InputCrouch();
                    }

                }

            }

        }
        
        #endregion


    }

    private void InputLeft()
    {
        player.HorizontalMove(Vector3.left);
    }

    private void InputRight()
    {
        player.HorizontalMove(Vector3.right);
    }

    private void InputJump()
    {
        player.Jump();
    }

    private void InputCrouch()
    {
        Debug.Log("Crouch");
    }



    public void ControllInit()
    {
        player = WorldScript.World.player;
    }




}
