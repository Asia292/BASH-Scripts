using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighting : MonoBehaviour
{

    [SerializeField]
    private float health;
    [SerializeField]
    private float damage;

    //Controls
    private KeyCode punchKey = KeyCode.Z;
    private KeyCode kickKey = KeyCode.X;
    private KeyCode blockKey = KeyCode.C;

    //PlayerFighting.controller FSM
    private bool isBlocking;
    private bool isPunching;
    private bool isKicking;
    private bool isHit;
    private int playerattack;

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        health = 200;
    }

    // Update is called once per frame
    void Update()
    {
        //set FSM values
        animator.SetBool("isBlocking", isBlocking);
        animator.SetBool("isPunching", isPunching);
        animator.SetBool("isKicking", isKicking);
        animator.SetBool("isHit", isHit);
        //get inputs
        if (Input.GetKeyDown(punchKey))
        {
            //do punch stuff
            Debug.Log("Punch");
            playerattack = 1;
        }
        else if (Input.GetKeyDown(kickKey))
        {
            //do kick stuff
            Debug.Log("Kick");
            playerattack = 2;
        }
        else if (Input.GetKey(blockKey))
        {
            //do block stuff;
            Debug.Log("Block");
            isBlocking = true;
            playerattack = 3;
        }
        else
        {
            playerattack = 0;
        }
        if (playerattack == 0) resetBools();
    }

    void FixedUpdate()
    {
        //set FSM values
        animator.SetBool("isBlocking", isBlocking);
        animator.SetBool("isPunching", isPunching);
        animator.SetBool("isKicking", isKicking);
        animator.SetBool("isHit", isHit);
    }

    void resetBools()
    {
        isBlocking = false;
        isPunching = false;
        isKicking = false;
        isHit = false;
    }

    bool blocking()
    {
        return isBlocking;
    }

    public void takeDamage(float value)
    {
        isHit = true;
        if (!isBlocking)
        {
            health -= value;
            Debug.Log("Take Damage");
            Debug.Log(health);
        }
    }

    public int playerAttackCheck()
    {
        return playerattack;
    }

    public float getHealth()
    {
        return health;
    }

    public void addHealth(float value)
    {
        health += value;
        if (health > 200) health = 200;
    }
}
