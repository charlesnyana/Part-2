using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    float speed;

    public Collider2D runway;
    bool canLand = false;

    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rb;
    public AnimationCurve landing;
    float landingTimer;

    SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;

    public int score;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        speed = Random.Range(minSpeed, maxSpeed);

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0,sprites.Count)];

        score = 0;
    }

    private void FixedUpdate()
    {
       currentPosition = new Vector2(transform.position.x, transform.position.y); 
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        speed = Random.Range(1, maxSpeed);

        if (canLand)
        {
            landingTimer += 0.01f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
                score++;
                Debug.Log(score);
            } else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
            }
        }

        if(points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Planes"))
        {
            spriteRenderer.color = Color.red;

            if (Vector3.Distance(currentPosition, collision.transform.position) < 0.6)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Runway"))
        {
            canLand = true;
        } else
        {
            canLand = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(currentPosition, lastPosition) > newPointThreshold)
        {
            points.Add(currentPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
            lastPosition = currentPosition;
        }
    }
}
