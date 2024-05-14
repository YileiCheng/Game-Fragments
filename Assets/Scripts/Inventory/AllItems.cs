using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItems : MonoBehaviour
{
    public static AllItems Instance { get; private set; }

    public List<Item> allItems = new List<Item>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadItems();
    }
    private void LoadItems()
    {
        //Debug.Log("Loaded all items");
        Item[] items = Resources.LoadAll<Item>("Items");
        allItems.AddRange(items);
        //foreach (Item item in allItems)
        //{
        //    Debug.Log(item.type);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // Example: press E to get icecream
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject playerGameObject = GameObject.Find("Player");
            if (playerGameObject != null)
            {
                Player player = playerGameObject.GetComponent<Player>();
                player.inventory.AddfromType(CollectableType.Icecream);
            }
        }

    }
}
