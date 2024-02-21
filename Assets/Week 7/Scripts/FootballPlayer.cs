using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer sr;
    public Color selectedColor;
    public Color unselectedColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    public void Selected(bool isSelected)
    {
        if (isSelected) {
            sr.color = selectedColor;
        } else
        {
            sr.color = unselectedColor;
        }
        
    }
}
