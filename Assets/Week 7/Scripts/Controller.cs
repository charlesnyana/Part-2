using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using TMPro;

public class Controller : MonoBehaviour
{
    float charge;
    Vector2 direction;
    public float maxCharge = 1;
    public Slider chargeSlider;

    public static float score = 0;
    public TextMeshProUGUI scoreboard;

    public static FootballPlayer SelectedPlayer { get; private set; }

    public static void SetSelectedPlayer(FootballPlayer player)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }
        player.Selected(true);
        SelectedPlayer = player;
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = charge;
        }
    }
    private void Update()
    {
        if (Ball.resetBall)
        {
            scoreboard.text = ("SCORE: " + score.ToString());
        }

        if (SelectedPlayer == null) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            Mathf.Clamp(charge, 0, maxCharge);
            direction = Vector2.zero;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            chargeSlider.value = charge;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - SelectedPlayer.transform.position).normalized * charge;
        }
    }
}
