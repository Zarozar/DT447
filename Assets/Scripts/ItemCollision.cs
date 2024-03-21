using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    public enum ItemType { Feather, Drink, Fake};

    [SerializeField]
    private ItemType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (type == ItemType.Feather)
            {
                FindObjectOfType<GameManager>().GetComponent<GameManager>().IncrementFeatherCount();
            }
            if (type == ItemType.Drink)
            {
                FindObjectOfType<GameManager>().GetComponent<GameManager>().IncrementDrinksCount();
            }
            if (type == ItemType.Fake)
            {
                FindObjectOfType<GameManager>().GetComponent<GameManager>().IncrementFakesCount();
            }

            Destroy(gameObject);
        }
    }

}
