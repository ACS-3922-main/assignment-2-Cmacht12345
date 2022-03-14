using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    [SerializeField] private KeyCode _moveUp = KeyCode.A;
    [SerializeField] private KeyCode _moveDown = KeyCode.D;
    private float _speed = 8;
    private float _boundary = 2.25f;
    Rigidbody2D _rb;
    [SerializeField] private GameObject _ball;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _ball = GameObject.Find("Ball");
    }

    void Update() {
        Vector3 ballPos = _ball.transform.position;
        float newPos = ballPos.y;
        if (ballPos == Vector3.zero)
        {
            Vector3 paddle = transform.position;
            paddle.y = 0;
            transform.position = paddle;
        }
        // moves the paddle up or down when key pressed
        Vector2 vel = _rb.velocity;
        if (Input.GetKey(_moveUp)) {
            vel.y = _speed;
        }
        else if (Input.GetKey(_moveDown)) {
            vel.y = -_speed;
        }
        else {
            vel.y = 0;
        }
        _rb.velocity = vel;

        // limits movement at boundaries
        Vector3 pos = transform.position;
        if (pos.y > _boundary) {
            pos.y = _boundary;
        }
        else if (pos.y < -_boundary) {
            pos.y = -_boundary;
        }
        transform.position = pos;
        
    }

}
