using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("here");
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.inventory.AddfromCollection(this);
            Destroy(this.gameObject);
        }

        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
