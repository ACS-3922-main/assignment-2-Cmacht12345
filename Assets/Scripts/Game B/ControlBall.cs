using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBall : MonoBehaviour
{
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 0.5f);
    }

    void GoBall()
    {
        _rb.AddForce(new Vector3(5, 40));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float ballPos = transform.position.x;
            float paddlePos = col.transform.position.x;
            float difference = ballPos - paddlePos;
            if (difference >= 0.20 || difference <= -0.20)
            {
                if (ballPos > paddlePos)
                {
                    _rb.AddForce(new Vector2(20, 10));
                }
                else if (ballPos < paddlePos)
                {
                    _rb.AddForce(new Vector2(-20, 10));
                }
            }
        }
        if(col.gameObject.tag == "Rectangle") 
        {
            Destroy(col.gameObject);
            GameObject.Find("Canvas").GetComponent<ManageUI>().Hit();

        }
    }
    public void ResetBall() 
    {
        _rb.velocity = Vector2.zero;
        Vector3 pos = new Vector3(0.0f, -3.7f, 0.0f);
        transform.position = pos;

        GameObject p = GameObject.Find("Player");
        pos = new Vector3(0.0f, -4.0f, 0.0f);
        p.transform.position = pos;

    }

    public void Restart()
    {
        ResetBall();
        GoBall();
    }
}
