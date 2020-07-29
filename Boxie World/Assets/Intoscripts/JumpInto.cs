using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInto : MonoBehaviour
{
    public GameObject jumpIntroUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jumpIntroUI.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        jumpIntroUI.SetActive(false);
    }
}
