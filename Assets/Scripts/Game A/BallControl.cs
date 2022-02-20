using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallControl : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void GoBall() {
        float rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                _rb.AddForce(new Vector2(Random.Range(10, 20), Random.Range(10, 20)));
                break;
            case 1:
                _rb.AddForce(new Vector2(-(Random.Range(10, 20)), Random.Range(10, 20)));
                break;
            case 2:
                _rb.AddForce(new Vector2(Random.Range(10, 20), -(Random.Range(10, 20))));
                break;
            case 3:
                _rb.AddForce(new Vector2(-(Random.Range(10, 20)), -(Random.Range(10, 20))));
                break;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        if (col.gameObject.tag == "Player") 
        {
            float ballPos = transform.position.y;
            float paddlePos = col.transform.position.y;
            float difference = ballPos - paddlePos;
            if (difference >= 0.20 || difference <= -0.20)
            {
                if (ballPos > paddlePos)
                {
                    _rb.AddForce(new Vector2(3, 20));
                }
                else if (ballPos < paddlePos)
                {
                    _rb.AddForce(new Vector2(3, -20));
                }
            }
        }
    }
    public void ResetBall() {
        _rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
    }

    public void Restart() {
        ResetBall();
        Invoke("GoBall", 1);
    }
}
