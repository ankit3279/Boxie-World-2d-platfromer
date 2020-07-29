using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolBoss : MonoBehaviour
{

    public float speed;
    public float distance;

    private bool isMovingRight = true;

    public Transform groundDetection;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        RaycastHit2D groungInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groungInfo.collider == false)
        {
            if (isMovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
                isMovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 90);
                isMovingRight = true;
            }
        }
    }
}
