﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (Random.Range(0, 1) >= 0.5f)
        {
            rigidbody2d.AddForce(new Vector2(80, 10));
        }
        else
        {
            rigidbody2d.AddForce(new Vector2(-80, -10));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }
    }
}