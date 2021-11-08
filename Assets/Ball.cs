using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 2;
    private Vector2 direction;
    private float ballRadius;
    private int a = 20;
    private static Vector2 bottomLeft;
    private static Vector2 topRight;

    void Start()
    {
        direction = new Vector2(1,1).normalized;
        ballRadius = transform.localScale.x / 2;
        
        //2nd coding point: it's just magic
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        // 1st coding point: make ball moveable
        transform.Translate(direction * speed * Time.deltaTime);
        
        // 2nd coding point: make ball bounce at top and bottom
        if (transform.position.y < bottomLeft.y + ballRadius && direction.y < 0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.y > topRight.y - ballRadius && direction.y > 0)
        {
            direction.y = -direction.y;
        }
    }

    // Vector2 initializeDirection()
    // {
    //     Vector3 a = new Vector2(Random.Range(0.5f,1),Random.Range(-1.0f,1));
    //     return a.normalized;
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        direction.x = -direction.x;
    }
}
