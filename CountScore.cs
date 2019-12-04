using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountScore : MonoBehaviour {

    private float gameScore;
    public Text scoreText;
    private int enemyScore, bossScore;
    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(GameObject.Find("Camera"));
        gameScore = 0;
        UpdateScoreText();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int enemyScore)
    {
        gameScore += enemyScore;
        
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + gameScore;
    }

    void ResetScore()
    {
        gameScore = 0;
        UpdateScoreText();
    }
}
