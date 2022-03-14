using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpponentControl : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    private Rigidbody2D _rb;
    private float _speed = 3.0f;
    private float _boundary = 2.25f;
    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.Find("Ball");
        _rb = GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("its working");
        Vector3 ballPos = _ball.transform.position;
        float newPos = ballPos.y;
        // Resets paddle position when ball position is reset
        if (ballPos == Vector3.zero)
        {
            Vector3 paddle = transform.position;
            paddle.y = 0;
            transform.position = paddle;
        }
        // Checks if the ball is moving up or down and moves the paddle either direction
        Vector2 vel = _rb.velocity;
        Vector3 checkY = transform.position;
        float difference = checkY.y - newPos;
        //Implemented a dead zone
        if (difference > 0.25f || difference < -0.25f)
        {
            if(checkY.y < newPos) 
            {
                vel.y= _speed;
            }
            else 
            {
                vel.y = -_speed;
            }
            _rb.velocity = vel;
            _rb.velocity = vel;
        }
        else 
        {
            vel.y = 0;
            _rb.velocity = vel;
        }
            // Checks the boundary for the paddle
        Vector3 pos = transform.position;
        if (pos.y > _boundary)
        {
            pos.y = _boundary;
        }
        else if (pos.y < -_boundary)
        {
            pos.y = -_boundary;
        }
        transform.position = pos;
        //Saving the old position
        
    }
}
