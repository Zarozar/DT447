using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().GetComponent<GameManager>().IncrementFeatherCount();
            Destroy(gameObject);
        }
    }

}
