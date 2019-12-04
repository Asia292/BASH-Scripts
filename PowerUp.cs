using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    private PlayerFighting player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerFighting>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player") {
            player.addHealth(24);
            //Debug.Log("Healthy Boi");
            Destroy(gameObject);
        }

    }
}
