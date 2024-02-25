using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    Animator animator;
    public Slider healthBar;
    
    public static float health;
    public float maxHealth = 10f;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Debug.Log("dies.");
            animator.SetTrigger("Death");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            dead = false;
            health = maxHealth;
        }
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        healthBar.value = health;

        Debug.Log("took damage. health: " + health);

        if (health <= 0)
        {
            dead = true;

        }
        else
        {
            dead = false;
            animator.SetTrigger("TakeDamage");
        }
    }
}
