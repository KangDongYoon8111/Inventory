using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public int money = 0;

    public GameObject fieldItemPrefab;
    public Vector3[] pos;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();

    private void Start()
    {
        money = 10000;

        for(int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}
