using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.LowLevel;

public class GameController : MonoBehaviour
{
    public Image attuneUI;
    public List <Sprite> attuneGem = new List<Sprite>(); // 0 is blue, 1 is red, 2 is yellow.
    public List <Color> attuneColor = new List<Color>(); // 0 is blue, 1 is red, 2 is yellow.
    public static int attuneIndex;


    public GameObject shield;
    SpriteRenderer shieldSR;

    public GameObject player;
    public static Vector2 playerLoc { get; private set; }

    public GameObject missile;

    public float minInterval = 2f;
    public float maxInterval = 7f;
    float interval;
    float currentTime;


    private void Start()
    {
        attuneIndex = 0;
        shieldSR = shield.GetComponent<SpriteRenderer>();

        float randomInterval = Random.Range(minInterval, maxInterval+1);
        interval = randomInterval * Time.deltaTime;

        
    }

    private void FixedUpdate()
    {
        currentTime += Time.deltaTime * 1;
               
    }

    private void Update()
    {
        // Attunement system trigger. Will cycle between attunement types on spacebar.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attuneIndex = (attuneIndex + 1) % 3; // caps at 3
            Debug.Log("Attunment index: " +attuneIndex);
            attune(attuneIndex);
        }
        findPlayer(player);
        
        if(currentTime - 1 >= interval)
        {
            missileSpawner();
            currentTime = 0; // reset timer
        }
    }

    public static void findPlayer(GameObject player)
    {
        playerLoc = player.transform.position;
    }

    void attune(int attunetype)
    {
        attuneUI.sprite = attuneGem[attunetype]; // 0 is blue, 1 is red, 2 is yellow.
        shieldSR.color = attuneColor[attunetype];
    }

    void missileSpawner()
    {
        Instantiate(missile);
    }

}
