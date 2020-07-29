using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameController>().CompleteLevel();
        Player.SetActive(false);
    }
}
