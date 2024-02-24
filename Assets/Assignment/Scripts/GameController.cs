using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Image attuneUI;
    public List <Sprite> attuneGem = new List<Sprite>(); // 0 is blue, 1 is red, 2 is yellow.
    public List <Color> attuneColor = new List<Color>(); // 0 is blue, 1 is red, 2 is yellow.
    int attuneIndex;


    public GameObject shield;
    SpriteRenderer shieldSR;

    private void Start()
    {
        attuneIndex = 0;
        shieldSR = shield.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Attunement system trigger. Will cycle between attunement types on spacebar.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            attuneIndex = (attuneIndex + 1) % 3; // caps at 3
            Debug.Log("Attunment index: " +attuneIndex);
            attune(attuneIndex);
        }
    }

    public void takeDmg()
    {

    }

    void attune(int attunetype)
    {
        attuneUI.sprite = attuneGem[attunetype]; // 0 is blue, 1 is red, 2 is yellow.
        shieldSR.color = attuneColor[attunetype];
    }

}
