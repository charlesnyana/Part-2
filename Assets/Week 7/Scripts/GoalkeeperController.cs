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
    float distance;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        pivotPoint = rb.transform.position;
        Debug.Log(pivotPoint);

    }

    void FixedUpdate()
    {
        // gets active selected player's position and stores it.
        if (Controller.SelectedPlayer != null)
        {
            activePlayer = Controller.SelectedPlayer.transform.position;

            halfPoint = (activePlayer + pivotPoint)/2;

            if (rb.position != halfPoint)
            {
                rb.MovePosition(halfPoint);
            }
            

        }

    }
}
