using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 activePlayer;
    Vector2 pivotPoint;
    Vector2 halfPoint;
    public float speed = 1f;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        pivotPoint = rb.transform.position;
        Debug.Log(pivotPoint);

    }

    void FixedUpdate()
    {
        // gets active selected player's position and stores it.
        if (Controller.SelectedPlayer == null)
        {
            transform.position = pivotPoint;
        } else
        {
            activePlayer = Controller.SelectedPlayer.transform.position;

            halfPoint = (activePlayer + pivotPoint) / 2;

            transform.position = Vector2.MoveTowards(transform.position, halfPoint, speed * Time.deltaTime);

        }

    }
}
