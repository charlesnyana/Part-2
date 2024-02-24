using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 movement;
    public float speed = 3f;

    Vector2 playerLoc;
    float rSpawnIndex;
    float spawnX;
    float spawnY;
    Vector2 spawnLoc;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // spawn cases either 1-3
        rSpawnIndex = Random.Range(1, 3);
        //spawn somewhere along the 6 y-axis
        spawnX = Random.Range(-10, 10);
        spawnY = Random.Range(-2, 6);

        if (rSpawnIndex == 1)
        {
            //spawns on top of game screen
            spawnLoc = new Vector2(spawnX, 6);
            transform.position = spawnLoc;
            Debug.Log("missile spawned at: case 1");
        }
        if (rSpawnIndex == 2)
        {
            //spawns out left of game screen
            spawnLoc = new Vector2(-10, spawnY);
            transform.position = spawnLoc;
            Debug.Log("missile spawned at: case 2");
        }

        if (rSpawnIndex == 3)
        {
            //spawns out right of game screen
            spawnLoc = new Vector2(10, spawnY);
            transform.position = spawnLoc;
            Debug.Log("missile spawned at: case 3");
        }



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
    }
}
