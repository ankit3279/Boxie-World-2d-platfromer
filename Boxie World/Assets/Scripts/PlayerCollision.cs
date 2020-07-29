using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerC movement;

    private void Start()
    {
        movement = GetComponent<PlayerC>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spik")
        {
            movement.enabled = false;
            FindObjectOfType<GameController>().GameEnded();
        }
    }
}
