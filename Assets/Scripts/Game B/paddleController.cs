using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleController : MonoBehaviour
{
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    private float _speed = 8;
    private float _boundary = 5f;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // moves the paddle up or down when key pressed
        Vector2 vel = _rb.velocity;
        if (Input.GetKey(_moveLeft))
        {
            vel.x = -_speed;
        }
        else if (Input.GetKey(_moveRight))
        {
            vel.x = _speed;
        }
        else
        {
            vel.x = 0;
        }
        _rb.velocity = vel;

        // limits movement at boundaries
        Vector3 pos = transform.position;
        if (pos.x > _boundary)
        {
            pos.x = _boundary;
        }
        else if (pos.x < -_boundary)
        {
            pos.x = -_boundary;
        }
        transform.position = pos;
    }
}
