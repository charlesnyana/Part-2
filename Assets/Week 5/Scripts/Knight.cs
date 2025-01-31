using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Knight : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3f;
    Animator animator;
    Collider2D col;
    bool clickOnSelf = false;
    public float HP;
    public float maxHP = 5;
    bool isDead;
    public HPBar HPBar;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();

        HP = maxHP;
        isDead = false;
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0) && !clickOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnMouseDown()
    {
        if (isDead) return;

        clickOnSelf = true;
        gameObject.SendMessage("takeDamage", 1);
    }
    private void OnMouseUp()
    {
        clickOnSelf = false;
    }

    public void takeDamage(float damage)
    {
        HP -= damage;
        HP = Mathf.Clamp(HP, 0, maxHP);

        if (HP <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        } else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }
    }
}
