using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Collider2D ballCol;
    Rigidbody2D rb;
    public GameObject kickSpot;

    public static bool resetBall;

    void Start()
    {
        ballCol = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (resetBall)
        {
            rb.position = kickSpot.transform.position;
            rb.velocity = Vector2.zero;
            resetBall = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Goal"))
        {
            // increments score by 1
            Controller.score++;
            Debug.Log("goal! Points: " + Controller.score);
            resetBall = true;
        }
    }
}
