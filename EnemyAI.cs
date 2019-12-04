using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //For the players location
    private Transform playerLocation;
    public CountScore score;
    private Vector3 direction;
    //For the FSM in EnemyAI.controller
    private Animator animator;
    [SerializeField]
    private float distFromPlayer;
    [SerializeField]
    private bool playerInRange;
    //private bool idle;
    //Variables about the enemy itself
    [SerializeField]
    private float health;
    [SerializeField]
    private float walkSpeed = 5f;
    [SerializeField]
    private float damage = 8f;
    private bool isWaiting;
    //private Transform target;
    //private Rigidbody2D rb2d;
    private PlayerFighting player;
    private bool playerclose;
    private float enemyScale;


    // Use this for initialization
    void Start()
    {
        updateDistFromPlayer();
        player = GameObject.Find("Player").GetComponent<PlayerFighting>();
        score = GameObject.Find("ScoreUI").GetComponent<CountScore>();
        animator = gameObject.GetComponent<Animator>();
        playerLocation = GameObject.Find("Player").transform;
        //rb2d = GetComponent<Rigidbody2D>();
        if (gameObject.name == "Boss")
        {
            health = 1000f;
            enemyScale = 0.1f;
            damage = 20f;
        }
        else
        {
            health = 100f;
            enemyScale = 0.07f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateDistFromPlayer();
        //If Player in Range (Range of detection basically)
        if (playerInRange)
        {
            if (distFromPlayer < 1)
            {
                if (!isWaiting)
                {
                    fight();
                    StartCoroutine(wait(2f));
                }
                if (player.playerAttackCheck() == 1)
                {
                    takeDamage(8);
                }
                else if (player.playerAttackCheck() == 2)
                {
                    takeDamage(10);
                }
               
            }
            else
            {
                playerclose = false;
                followPlayer();
            }
        }
    }

    void FixedUpdate()
    {
        animator.SetFloat("distToPlayer", distFromPlayer);
        animator.SetBool("playerInRange", playerInRange);
        updateDistFromPlayer();
        //checkPlayerInRange();
        
    }

    void followPlayer()
    {
        /*if (!isWaiting)
        {
            while (distFromPlayer > 1 && playerInRange)
            {
                direction = playerLocation.position - transform.position;
                if (direction.x < 0 && transform.localScale.x > 0) //Move Left and Look Left
                {
                    //target = playerLocation;
                    //var step = walkSpeed * Time.deltaTime;
                    //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x - walkSpeed, transform.position.y, transform.position.z);
                    //transform.Translate(-walkSpeed, 0, 0);
                    //rb2d.velocity = new Vector2(-walkSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else if (direction.x < 0 && transform.localScale.x < 0)//Move left, Already looking left
                {
                    //target = playerLocation;
                    //var step = walkSpeed * Time.deltaTime;
                    //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                    transform.position = new Vector3(transform.position.x - walkSpeed, transform.position.y, transform.position.z);
                    //transform.Translate(-walkSpeed, 0, 0);
                    //rb2d.velocity = new Vector2(-walkSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                if (direction.x > 0 && transform.localScale.x < 0)//Move Right and Look Right 
                {
                    //target = playerLocation;
                    //var step = walkSpeed * Time.deltaTime;
                    //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x + walkSpeed, transform.position.y, transform.position.z);
                    //transform.Translate(walkSpeed, 0, 0);
                    //rb2d.velocity = new Vector2(walkSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else if (direction.x > 0 && transform.localScale.x > 0)//Move Right, Already looking right
                {
                    //target = playerLocation;
                    //var step = walkSpeed * Time.deltaTime;
                    //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                    transform.position = new Vector3(transform.position.x + walkSpeed, transform.position.y, transform.position.z);
                    //transform.Translate(walkSpeed, 0, 0);
                    //rb2d.velocity = new Vector2(walkSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }//end if
                updateDistFromPlayer();
                //checkPlayerInRange();
            }//end while
        }*/
        //transform.LookAt(player);
        if (Vector3.Distance(transform.position, playerLocation.position) >= 1)
        {
            direction = playerLocation.position - transform.position;
            transform.position += direction * walkSpeed * Time.deltaTime;
            if (direction.x < 1) transform.localScale = new Vector3(-enemyScale, enemyScale, 1);
            else transform.localScale = new Vector3(enemyScale, enemyScale, 1);
        }

    }//end function

    void fight()
    {
        player.takeDamage(damage);
        //takeDamage(8);
       
        Debug.Log("Enemy Health" + health);
    }

    /*void setIdle(bool value) {
        idle = value;
    }*/

    void updateDistFromPlayer()
    {
        playerLocation = GameObject.Find("Player").transform;
        distFromPlayer = playerLocation.position.x - transform.position.x;
        if (distFromPlayer < 0)
        {
            distFromPlayer *= -1;
        }
    }
    void takeDamage(float value)
    {
        health -= value;
        if (gameObject.name == "Boss" && health - value < 1)
        {
            score.AddScore(100);
            SceneManager.LoadScene("Good_GameOver");
            Destroy(gameObject);
        }
        else if (health - value < 1)
        {
            score.AddScore(50);
            Destroy(gameObject);
            
        }
        else
        {
            health -= value;
        }
    }

    /*void checkPlayerInRange()
    {
        if(distFromPlayer < 10)
        {
            playerInRange = true;
        }
        else { playerInRange = false; }
    }*/
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            playerInRange = false;
        }
    }

    IEnumerator wait(float seconds)
    {
        isWaiting = true;
        yield return new WaitForSeconds(seconds);
        isWaiting = false;
    }

    public float getHealth()
    {
        return health;
    }
}