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

    public GameObject gameOverBtn;
    float shrinkTimer;
    public AnimationCurve shrink;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dead = false;

        health = maxHealth;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * 2 * Time.deltaTime);
        
        if (dead)
        {
            shrinkTimer = 0.1f * Time.deltaTime;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
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
            gameOverBtn.SetActive(true);
        } else
        {
            gameOverBtn.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            dead = false;
            health = maxHealth;
            healthBar.value = health;
            animator.SetTrigger("Death");
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
            Debug.Log("DEAD TRUE.");

        }
        else
        {
            dead = false;
            animator.SetTrigger("TakeDamage");
        }
    }
}
