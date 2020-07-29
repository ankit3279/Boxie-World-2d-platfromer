using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject welcomeUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        welcomeUI.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        welcomeUI.SetActive(false);
    }
}
