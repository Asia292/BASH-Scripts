using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour {

    public GameObject canvas;
    private SpriteRenderer padlock;
    private PlayerMovement player;
    private bool minigamecheck;
    private string answer;
    private string playerInput;
    private SpriteRenderer[] images = new SpriteRenderer[8];

    private bool answerShown;
    private bool holdImages;

    // Use this for initialization
    void Start () {
        canvas = gameObject;
        padlock = GameObject.Find("HackingMinigame").GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        canvas.SetActive(false);
        //canvas.interactable = false;
        images[0] = gameObject.transform.Find("arrowUpBlank").GetComponent<SpriteRenderer>();
        images[1] = gameObject.transform.Find("arrowDownBlank").GetComponent<SpriteRenderer>();
        images[2] = gameObject.transform.Find("arrowRightBlank").GetComponent<SpriteRenderer>();
        images[3] = gameObject.transform.Find("arrowLeftBlank").GetComponent<SpriteRenderer>();
        images[4] = gameObject.transform.Find("arrowUpFill").GetComponent<SpriteRenderer>();
        images[5] = gameObject.transform.Find("arrowDownFill").GetComponent<SpriteRenderer>();
        images[6] = gameObject.transform.Find("arrowRightFill").GetComponent<SpriteRenderer>();
        images[7] = gameObject.transform.Find("arrowLeftFill").GetComponent<SpriteRenderer>();
        for (int x = 0; x < 8; x++)
        {
            images[x].enabled = false;
        }
        answer = "dummy";
        playerInput = "";
        answerShown = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (answerShown)
        {
            if (answer.Length == playerInput.Length)
            {
                if (playerInput == answer)
                {
                    minigamecheck = true;
                    HideCanvas();
                    Debug.Log("Answer Correct");
                    padlock.enabled = false;
                }
                else
                {
                    minigamecheck = false;
                    HideCanvas();
                    Debug.Log("Answer Incorrect");
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    playerInput += "0";
                    StartCoroutine(inputchecker(4));
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    playerInput += "1";
                    StartCoroutine(inputchecker(5));
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    playerInput += "2";
                    StartCoroutine(inputchecker(6));
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    playerInput += "3";
                    StartCoroutine(inputchecker(7));
                }
            }
            //Debug.Log(playerInput);
        }
    }

    void createAnswer()
    {
        answer = "";
        int answerLength;
        answerLength = Random.Range(3, 7);

        int current;
        for (int x = 0; x < answerLength; x++)
        {
            current = Random.Range(0, 4);
            answer += current.ToString();
        }
        Debug.Log(answer);
    }

    public void ShowCanvas()
    {
        canvas.SetActive(true);
        //canvas.interactable = true;
        player.enabled = false;
        player.StopMovement();
        createAnswer();
        StartCoroutine(displayAnswer());
        answerShown = true;
    }

    public void HideCanvas()
    {
        for (int x = 0; x < 8; x++)
        {
            images[x].enabled = false;
        }
        answer = "dummy";
        playerInput = "";
        answerShown = false;
        canvas.SetActive(false);
        //canvas.interactable = false;
        player.enabled = true;
    }

    /*void OnTriggerEnter2D(Collider2D collider)
    {
        createAnswer();
        
        for (int x = 0; x < 8; x++)
        {
            images[x].enabled = true;
        }
        
        displayAnswer();
    }*/

    IEnumerator displayAnswer()
    {
        int index = 0;
        for (int x = 0; x < answer.Length; x++)
        {
            if (answer[x] == '0') index = 0;
            if (answer[x] == '1') index = 1;
            if (answer[x] == '2') index = 2;
            if (answer[x] == '3') index = 3;
            images[index].enabled = true;
            yield return new WaitForSeconds(0.5f);
            images[index].enabled = false;
            yield return new WaitForSeconds(0.25f);
        }
    }
    IEnumerator inputchecker(int input)
    {
        images[input].enabled = true;
        yield return new WaitForSeconds(0.5f);
        images[input].enabled = false;
    }

    /*public bool CheckCanvas()
    {
        if (canvas.alpha == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }*/
    public bool CheckMinigameFinished()
    {
        return minigamecheck;
    }
}
