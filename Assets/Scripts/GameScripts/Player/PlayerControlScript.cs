using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{

    public GameObject PlayerObject;
    public Transform PlayerTransform;

    private Vector3 TargetPosition;

    public float StartSpeed;
    private float currentSpeed;

    private bool jumping;
    private float jumpStartHeight;
    private float jumpStartTime;

    private bool speedBoosted;
    private float boost;
    private float boostDuration;
    private float boostStartTime;


    // Use this for initialization
    void Start()
    {
        PlayerObject = gameObject;
        PlayerTransform = transform;

        jumping = false;
        TargetPosition = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        SmoothMove();
        HandleJumpMotion();


    }

    public void HorizontalMove(Vector3 direction)
    {

        TargetPosition += 2 * direction;
    }

    public void Jump()
    {
        if (!jumping)
        {
            jumping = true;
            jumpStartHeight = transform.position.y;
            jumpStartTime = Time.time;
        }
    }

    private void HandleJumpMotion()
    {
        if (jumping)
        {
            float yPos = jumpStartHeight + ((10.0f - (9.81f * (Time.time - jumpStartTime))) * (Time.time - jumpStartTime));
            TargetPosition = new Vector3(TargetPosition.x, yPos, TargetPosition.z);
            if (TargetPosition.y < transform.position.y && transform.position.y < jumpStartHeight + 0.2f)
            {
                TargetPosition = new Vector3(TargetPosition.x, jumpStartHeight, TargetPosition.z);
                transform.position = new Vector3(transform.position.x, jumpStartHeight, transform.position.z);
                jumping = false;
            }
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }

    private void SmoothMove()
    {
        Vector3 movement = Vector3.forward;
        if (transform.position.x > TargetPosition.x + 0.05f)
        {
            movement += Vector3.left;
        }
        else if (transform.position.x < TargetPosition.x - 0.05f)
        {
            movement += Vector3.right;
        }
        if (transform.position.y > TargetPosition.y + 0.05f)
        {
            movement += Vector3.down;
        }
        else if (transform.position.y < TargetPosition.y - 0.05f)
        {
            movement += Vector3.up;
        }

        checkBoost();
        transform.Translate(movement * currentSpeed * Time.deltaTime);
    }

    private void checkBoost()
    {
        if (speedBoosted)
        {
            if (currentSpeed < boost)
            {
               currentSpeed += (boost) * Time.deltaTime;
            }
            else if(currentSpeed > boost)
            {
                currentSpeed = boost;
            }

            if (Time.time - boostStartTime > boostDuration)
            {
                speedBoosted = false;
                Debug.Log("Speedboost over.");
            }
        }
        else
        {
            currentSpeed = StartSpeed;
        }
    }


    public bool isJumping()
    {
        return jumping;
    }

    public void SpeedBoost(float Boost, float Duration)
    {
        boostStartTime = Time.time;
        boost = Boost * StartSpeed;
        boostDuration = Duration;
        speedBoosted = true;
    }




}
