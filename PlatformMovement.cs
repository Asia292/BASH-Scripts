using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    [SerializeField]
    public GameObject start;
    public GameObject end;
    public float speed;
    private float actualTime;
    private float moveTime;
    private float movement;
    private bool reverse = false;

    private bool moving;
    private Vector3 velocity;
    

    private bool isActive;

    // Use this for initialization
    void Start()
    {

        isActive = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {

            moveTime = (Vector2.Distance(start.transform.position, end.transform.position) * speed);
            if (transform.position == end.transform.position)
            {
                if (reverse == false)
                {
                    actualTime = Time.time;
                }
                reverse = true;
                //actualTime = Time.time;
                //moveTime = (Vector2.Distance(start.transform.position, end.transform.position) * speed);
            }
            else if (transform.position == start.transform.position)
            {
                if (reverse == true)
                {
                    actualTime = Time.time;
                }
                reverse = false;
            }

            if (reverse == false)
            {
                movement = speed * (Time.time - actualTime);
                transform.position = Vector3.Lerp(start.transform.position, end.transform.position, movement);
            }
            else if (reverse == true)
            {
                movement = speed * (Time.time - actualTime);
                transform.position = Vector3.Lerp(end.transform.position, start.transform.position, movement);
            }

            if (moving)
            {
                transform.position += (velocity * Time.deltaTime);
            }
        }//end if
    }//end FU

    /* void OnCollisionEnter2D(Collider2D boi)
     {
         if(boi.name == "Player")
         {
             boi.transform.position = transform.position + offset;
         }

     }*/
     
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals ("Player"))
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
    public void makeActive()
    {
        isActive = true;
    }
}