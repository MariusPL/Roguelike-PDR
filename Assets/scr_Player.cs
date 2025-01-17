﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour
{
    public float movSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animcontrol;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");    
        movement.y = Input.GetAxis("Vertical");

        animcontrol.SetFloat("Horizontal", movement.x);
        animcontrol.SetFloat("Vertical", movement.y);
        animcontrol.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movSpeed * Time.fixedDeltaTime);
    }

}
