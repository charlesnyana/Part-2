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
    float minDegree = 0f;
    float maxDegree = 90f;
    float currentDegree;
    public float rSpeed = 30f;
    bool rHorizontally = false;
    bool rVertically = false;

    Rigidbody2D rb;

    bool isVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isVertical = true;
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
        // rotates shield horizontally
        if (rHorizontally && !rVertically)
        {
            currentDegree += rSpeed*Time.deltaTime;
            rb.rotation = currentDegree;
            if (currentDegree >= maxDegree)
            {
                rHorizontally=false;
                transform.localEulerAngles = new Vector3(0, 0, 90); //locks it onto 90 degrees
                Debug.Log("horizontal rotating finished.");
            }
        }
        //rotates shield vertically
        if (!rHorizontally && rVertically)
        {
            currentDegree -= rSpeed * Time.deltaTime;
            rb.rotation = currentDegree;
            if (currentDegree <= minDegree)
            {
                rVertically = false;
                transform.localEulerAngles = new Vector3(0, 0, 0); //locks it back to vertical block
                Debug.Log("vertical rotating finished.");
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // checks if shield is vertical
            if (isVertical && !rVertically && !rHorizontally)
            {
                rHorizontally = true;
                Debug.Log("Rotating initiated to horizontal position.");
                isVertical = !isVertical;
            }
            if (!isVertical && !rVertically && !rHorizontally)
            {
                rVertically = true;
                Debug.Log("Rotating initiated to vertical position.");
                isVertical = !isVertical;
            }
        }
    }
}
