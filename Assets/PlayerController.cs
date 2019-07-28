using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;

    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocityY = 0;
        if (Input.GetKey(moveUp))
        {
            velocityY = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            velocityY = -speed;
        }
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, velocityY);
    }
}
