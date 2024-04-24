using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 velocity;

    public Animator animator;

    void Start()
    {
        inventory = new Inventory(5);
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector2.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        if (velocity != Vector2.zero)
        {
            UpdateMovement();

            animator.SetBool("Walking", true);
            animator.SetFloat("Horizontal", velocity.x);
            animator.SetFloat("Vertical", velocity.y);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void UpdateMovement()
    {
        rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
    }
}