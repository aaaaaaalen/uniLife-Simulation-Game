using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using System;

public class Bird : MonoBehaviour
{
    private const float JUMP_AMOUNT = 80f;
    private Rigidbody2D rigidbody_2D;
    public event EventHandler OnDied;
    public event EventHandler OnStartedPlaying;

    private static Bird Instance;
    private State state;

    private enum State { 
        WaitingToStart,
        Playing,
        Dead
    }

    private void Awake()
    {
        Instance = this;
        rigidbody_2D = GetComponent<Rigidbody2D>();
        state = State.WaitingToStart;
    }

    public static Bird GetInstance()
    {
        return Instance;
    }

    private void Update()
    {
        switch (state) {
            default:
            case State.WaitingToStart:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    state = State.Playing;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                    if (OnStartedPlaying != null) OnStartedPlaying(this, EventArgs.Empty);
                }
                break;
            case State.Playing:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Jump();
                }
                break;
            case State.Dead:
                break;
        }


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rigidbody_2D.velocity = Vector2.up * JUMP_AMOUNT;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        if (OnDied != null) OnDied(this, EventArgs.Empty);
    }
}
