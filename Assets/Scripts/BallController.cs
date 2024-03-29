﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 100;

    private Rigidbody2D rigidbody2d;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        Invoke(nameof(GoBall), 2);
    }

    private void Update()
    {
        // bump up the velocity
        var xVel = rigidbody2d.velocity.x;
        if (Mathf.Abs(xVel) < 18 && !Mathf.Approximately(xVel, 0))
        {
            // actually did not get there, but...
            xVel = (xVel > 0) ? 20 : -20;
        }
        rigidbody2d.velocity = new Vector2(xVel, rigidbody2d.velocity.y);
    }

    private void GoBall()
    {
        if (Random.Range(0, 2) >= 0.5f)
        {
            rigidbody2d.AddForce(new Vector2(ballSpeed, 10));
        }
        else
        {
            rigidbody2d.AddForce(new Vector2(-ballSpeed, -10));
        }
    }

    public void ResetBall()
    {
        rigidbody2d.velocity = new Vector2();
        transform.position = new Vector3();
        Invoke(nameof(GoBall), 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            var colRigBody = collision.collider.GetComponent<Rigidbody2D>();
            if (colRigBody != null)
            {
                var velocityY = rigidbody2d.velocity.y / 2 + colRigBody.velocity.y / 3;
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, velocityY);

                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.Play();
            }
        }
    }
}
