using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour {

    public Minigame canvas;
    private MinigameTrigger trigger;
    //private Collider2D collider;
    private KeyCode hackKey = KeyCode.S;
    private bool incollider = false;

    [SerializeField]
    private PlatformMovement platform;

    // Use this for initialization
    void Start () {
        //canvas = GameObject.Find("arrows").GetComponent<Minigame>();
        trigger = gameObject.GetComponent<MinigameTrigger>();
        //collider = GameObject.Find("Player").GetComponent<Collider2D>();
    }

    void Update ()
    {
        if (incollider == true)
        {
            if (Input.GetKeyDown(hackKey))
            {
                //trigger.enabled = false;
                //gameObject.SetActive(false);
                //Destroy(trigger);
                canvas.ShowCanvas();
                //Debug.Log("Key pressed");
            }
            if (canvas.CheckMinigameFinished() == true)
            {
                trigger.enabled = false;
		        platform.makeActive();
                Destroy(gameObject);
		
            }
        }
        
        //OnTriggerStay2D(collider);
        /*if (canvas.CheckCanvas() == true)
        {
            player.enabled = false;
            player.StopMovement();
        }
        else
        {
            player.enabled = true;
        }*/
    }

    void OnTriggerStay2D(Collider2D PlayerCheck)
    {
        if (PlayerCheck.name == "Player")
        {
            //Debug.Log("Player entered");
            //Debug.Log(PlayerCheck.name);
            incollider = true;
        }
    }

    void OnTriggerExit2D(Collider2D PlayerCheck)
    {
        if (PlayerCheck.name == "Player")
        {
            incollider = false;
        }
    }

    /*void OnTriggerExit2D(Collider2D PlayerCheck)
    {
        Debug.Log("Player entered");
        Debug.Log(PlayerCheck.name);

        if (PlayerCheck.name == "Player")
        {
            canvas.HideCanvas();
            player.enabled = true;
        }
    }*/
}
