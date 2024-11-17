using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject _destroyerObject;
void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if this GameObject is the player
        if (gameObject.CompareTag("Player"))
        {
            // Check if the collided object is the specific destroyer object
            if (collision.gameObject == _destroyerObject)
            {
                // Destroy this GameObject (the player)
                Destroy(gameObject);
            }
        }       
    }
}
