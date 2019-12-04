using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLock : MonoBehaviour
{
    public GameObject player;
    private BoxCollider2D collider;

    void Start()
    {
        player = GameObject.Find("Player");
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
    }

    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (player.transform.position.x > this.gameObject.transform.position.x)
        {
            collider.enabled = true;
        }
    }

}
