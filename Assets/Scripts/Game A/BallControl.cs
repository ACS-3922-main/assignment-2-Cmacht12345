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
        float rand = Random.Range(0, 2);
        if (rand < 1) {
            _rb.AddForce(new Vector2(20, -15));
        }
        else {
            _rb.AddForce(new Vector2(-20, -15));
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
