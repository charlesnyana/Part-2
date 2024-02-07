using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;

    public void takeDamage(float damage)
    {
        slider.value -= damage;
    }
}
