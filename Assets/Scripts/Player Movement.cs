using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 velocity;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {

        SaveSystem.LoadPlayer(this);
        //if (data != null) // Make sure data is not null
        //{
        //    if (inventory != null && data.inventory != null) // Check both inventories are not null
        //    {
        //        inventory = data.inventory;
        //    }
        //    else
        //    {
        //        Debug.LogError("Inventory data is null.");
        //    }

        //    // Check if the position data is not null and has the correct length
        //    if (data.position != null && data.position.Length == 3)
        //    {
        //        Vector3 position;
        //        position.x = data.position[0];
        //        position.y = data.position[1];
        //        position.z = data.position[2];
        //        transform.position = position;
        //    }
        //    else
        //    {
        //        Debug.LogError("Position data is null or incorrect.");
        //    }
        //}
        //else
        //{
        //    Debug.LogError("Player data is null.");
        //}

        //PlayerData data = SaveSystem.LoadPlayer();

        //inventory = data.inventory;
        //Vector3 position;
        //position.x = data.position[0];
        //position.y = data.position[1];
        //position.z = data.position[2];
        //transform.position = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(5);
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
