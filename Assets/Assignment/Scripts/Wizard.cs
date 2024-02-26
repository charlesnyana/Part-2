using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    Animator animator;
    public Slider healthBar;
    Rigidbody2D rb;
    
    public static float health;
    public float maxHealth = 10f;
    public static bool dead;

    Vector2 movement;

    public GameObject gameOverUI;
    
    float shrinkTimer;
    public AnimationCurve shrink;
    Vector3 baseScale;
    Vector3 basePos;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dead = false;

        health = maxHealth;
        baseScale = transform.localScale;
        basePos = transform.localPosition;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * 2 * Time.deltaTime);
        
        if (dead)
        {
            shrinkTimer = 6f * Time.deltaTime;
            float interpolate = shrink.Evaluate(shrinkTimer);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolate);
        } else
        {
            transform.localScale = baseScale;
        }
    }

    void Update()
    {
        if (!dead) movement.x = Input.GetAxis("Horizontal");
        if (movement.x > 0)
        {
            animator.SetTrigger("Start Run");
            animator.SetFloat("Run", -1);
        } if (movement.x < 0)
        {
            {
                animator.SetTrigger("Start Run");
                animator.SetFloat("Run", 1);
            }
        }

        if (dead)
        {
            animator.SetTrigger("Death");
            gameOverUI.SetActive(true);
        } else
        {
            gameOverUI.SetActive(false);
        }
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        healthBar.value -= amount;

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

    public void resetGame()
    {
        dead = false;
        health = maxHealth;
        healthBar.value = health;
    }
}
