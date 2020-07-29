using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatfrom : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 initialPosition;
    private bool platfromMovingBcak;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (platfromMovingBcak)
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, 20f * Time.deltaTime);
        }
        if (transform.position.y == initialPosition.y)
        {
            platfromMovingBcak = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("DropPlatfrom",1f);
           // Destroy(gameObject, 3f);
        }
    }

    void DropPlatfrom()
    {
        rb2d.isKinematic = false;
        Invoke("GetPlatfromBack", 2f);
    }
    void GetPlatfromBack()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.isKinematic = true;
        platfromMovingBcak = true;

    }
}
