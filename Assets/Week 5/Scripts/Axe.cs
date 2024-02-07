using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{

    float currentTime;
    public float uptime = 5f;
    public float speed = 5f;

    Rigidbody2D rb;
    Collider2D col;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        currentTime = 0;
    }

    private void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        movement = -(Vector2)transform.right;

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime >= uptime)
        {
            Destroy(gameObject);
            Debug.Log("axe deleted in " +  currentTime + " seconds");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("takeDamage", 5, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
