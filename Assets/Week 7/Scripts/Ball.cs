using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Collider2D ballCol;

    // Start is called before the first frame update
    void Start()
    {
        ballCol = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer ("Goal"))
        {
            Debug.Log("goal!");

            goalMade();
        }
    }

    public static void goalMade()
    {

    }
}
