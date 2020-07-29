using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float distance;

    private bool isMovingRight = true;

    public Transform groundDetection;

    public LayerMask whatIsTransGround;

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groungInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        RaycastHit2D groungInfo2 = Physics2D.Raycast(groundDetection.position, Vector2.down, distance,whatIsTransGround);

        if (groungInfo2.collider != null)
        {
            if (isMovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isMovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isMovingRight = true;
            }
            
        }
        else
        {


            if (groungInfo.collider == false)
            {
                if (isMovingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    isMovingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    isMovingRight = true;
                }
            }
        }
    }
}
