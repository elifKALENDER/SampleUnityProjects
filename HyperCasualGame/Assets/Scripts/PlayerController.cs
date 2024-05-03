using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 100f;
    CurrentDirection cr;
    public bool isPlayerDead;
    private gameSceneSwitcher gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.right;
        isPlayerDead = false;
        gameManager=FindObjectOfType<gameSceneSwitcher>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayerDead) {
            RaycastDetector();

            if (Input.GetKeyDown("space")) //Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began)---> Can use this code for mobile game but we create the game for PC
            {
                ChangeDirection();
                PlayerStop();
            }
        }
        else
        {
            return ;
        }
        
    }

    private enum CurrentDirection
    {
        right,
        left
    }
    private void ChangeDirection() 
    {
        MovePlayer();
        if(cr==CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }
        else if(cr==CurrentDirection.left)
        {
            cr = CurrentDirection.right;
        }
    }

    private void MovePlayer() 
    {
        if(cr==CurrentDirection.right)
        {
            rb.AddForce((Vector3.forward).normalized*speed*Time.deltaTime,ForceMode.VelocityChange);
        }
        else if (cr==CurrentDirection.left) 
        {
            rb.AddForce((Vector3.right).normalized*speed*Time.deltaTime,ForceMode.VelocityChange);
        }
    }
    private void PlayerStop() 
    {
        rb.velocity=Vector3.zero;
    }

    private void RaycastDetector() 
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit) ) 
        {
            MovePlayer();
        }
        else 
        {
            PlayerStop();
            isPlayerDead = true;
            this.gameObject.SetActive(false);
            gameManager.LevelEnd();
        }


    }
}
