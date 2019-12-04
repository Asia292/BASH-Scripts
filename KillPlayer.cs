using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    [SerializeField]
    private PlayerFighting player;
    private float currentHealth;

    void Update()
    {
        if (currentHealth < 1)
        {
            Debug.Log("Player is dead");
            SceneManager.LoadScene("Bad_GameOver");
        }
    }
    
    void FixedUpdate()
    {
        currentHealth = player.getHealth();
    }
}
