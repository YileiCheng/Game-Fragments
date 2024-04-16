using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    // Start is called before the first frame update
    public CollectableType type;
    public Sprite icon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("here");
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
