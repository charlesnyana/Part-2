using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D col;
    SpriteRenderer sr;

    Vector2 movement;
    public float speed = 3f;

    Vector2 playerLoc;
    float rSpawnIndex;
    float spawnX;
    float spawnY;
    Vector2 spawnLoc;

    int attuneMissile;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col =GetComponent<CircleCollider2D>();
        sr = col.GetComponent<SpriteRenderer>();

        // spawn cases either 1-3
        rSpawnIndex = Random.Range(1, 4);
        //spawn somewhere along the 6 y-axis
        spawnX = Random.Range(-11, 11);
        spawnY = Random.Range(-3, 7);

        if (rSpawnIndex == 1)
        {
            //spawns on top of game screen
            spawnLoc = new Vector2(spawnX, 6);
            transform.position = spawnLoc;
            //Debug.Log("missile spawned at: case 1");
        }
        if (rSpawnIndex == 2)
        {
            //spawns out left of game screen
            spawnLoc = new Vector2(-10, spawnY);
            transform.position = spawnLoc;
            //Debug.Log("missile spawned at: case 2");
        }

        if (rSpawnIndex == 3)
        {
            //spawns out right of game screen
            spawnLoc = new Vector2(10, spawnY);
            transform.position = spawnLoc;
            //Debug.Log("missile spawned at: case 3");
        }
        

        attuneMissile = Random.Range(0, 3); //selects the attunement
        if (attuneMissile == 0) sr.color = Color.blue; // blue
        if (attuneMissile == 1) sr.color = Color.red; // red
        if (attuneMissile == 2) sr.color = Color.yellow; // yellow
       }

    private void FixedUpdate()
    {
        // missile homes towards player.
        movement = playerLoc - (Vector2)transform.position;
        if (movement.magnitude < 0.1) // might remove this part once destroy logic is placed.
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        playerLoc = GameController.playerLoc; //finds player location and updates it.

        if (Wizard.dead && gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Shield") && attuneMissile == GameController.attuneIndex)
        {
            Destroy(gameObject);
            // insert points system here
        }

        if (collider.gameObject.layer == LayerMask.NameToLayer("Player")) // if missile hits player
        {
            collider.SendMessage("takeDamage", 1, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);

        }
        }
    }


