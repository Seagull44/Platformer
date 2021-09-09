using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System.Collections;
using UnityEditor;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    public Joystick Joystick;
    private float moveInput;
    float verticalMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Joystick.Vertical;
        moveInput = Joystick.Horizontal;
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        if (verticalMove>= .5f)
        {
            rb.velocity = Vector2.up * 15;
        }
    }
}
