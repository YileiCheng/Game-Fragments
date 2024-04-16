using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        /*velocity = Vector2.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
        Debug.Log(velocity);*/
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(directionX * 2f, directionY * 2f);
    }

    /*void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
    }*/
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("here");
        if (collision.gameObject.CompareTag("Fragment"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
