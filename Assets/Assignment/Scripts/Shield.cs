using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;

public class Shield : MonoBehaviour
{
    Vector2 movement;
    Vector2 destination;
    public float speed = 1f;
    float currentDegree = 0;
    float maxDegree = 90f;
    public float rSpeed = 1f;

    Rigidbody2D rb;

    bool isHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isHorizontal = true;
    }

    private void FixedUpdate()
    {
        // movement logic on left click
        movement = destination - (Vector2)transform.position; // A2 Item #4a

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

        // shield rotate logic
        
        {
            // rotates 90 degrees
            if (isHorizontal)
            {
                rb.rotation = currentDegree;
            } else
            {
                rb.rotation = maxDegree;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // gets coords for destination of shield on left click.
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(destination);
        }

        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            isHorizontal = !isHorizontal;
            Debug.Log("Is shield horizontal? " + isHorizontal);
        }
    }
}
