using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private PlayerFighting player;
    private float maxHealth;
    private float width;
    private float currentHealth;

    private float sliderMax;
    private Transform greenBar;

    private float startXPos;
    private float finalXPos;
    private float difference;

    // Use this for initialization
    void Start () {
        maxHealth = player.getHealth();
        greenBar = transform.Find("greenBar");
        width = greenBar.GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log(width);
        startXPos = greenBar.position.x;
        finalXPos = startXPos - (width/2);
        Debug.Log(startXPos);
        Debug.Log(finalXPos);
        /*maxHealth = player.getHealth();
        greenBar = transform.Find("greenBar");

        startXPos = greenBar.position.x;
        float width = greenBar.GetComponent<SpriteRenderer>().bounds.size.x;
        finalXPos = startXPos - width / 2;
        //finalXPos = startXPos / 2f;
        //if (startXPos < 0) finalXPos = startXPos * 2;

        difference = startXPos - finalXPos;
        //Debug.Log(startXPos);
        //Debug.Log(finalXPos);*/

    }

    // Update is called once per frame
    void Update () {
        startXPos = transform.Find("redBar").position.x;
        finalXPos = startXPos - (width / 2);
        float newBarLength = currentHealth / maxHealth;
        float difference = (startXPos - finalXPos) * (1 - newBarLength);
        greenBar.localScale = new Vector3(newBarLength, greenBar.localScale.y, greenBar.localScale.z);
        if (currentHealth <= 0)
        {
            greenBar.position = new Vector3(finalXPos, greenBar.position.y, greenBar.position.z);
        }
        else
        {
            greenBar.position = new Vector3(startXPos - difference, greenBar.position.y, greenBar.position.z);
        }

        /*float newBarLength = (currentHealth / maxHealth);
        greenBar.localScale = new Vector3(newBarLength, greenBar.localScale.y, greenBar.localScale.z);
        greenBar.position = new Vector3(startXPos - difference * newBarLength, greenBar.position.y, greenBar.position.z);
        Debug.Log(greenBar.position.x);*/
    }

    void FixedUpdate()
    {
        currentHealth = player.getHealth();
    }
}
