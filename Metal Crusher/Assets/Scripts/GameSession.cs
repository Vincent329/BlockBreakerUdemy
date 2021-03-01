using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // config parameters
    [SerializeField] [Range(0.1f, 10f)] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText; 

    // State Variables
    [SerializeField] int currentScore = 0;

    // storing in a variable the number of 
    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length; // looking at how many objects of type Game Status there are
        if (gameStatusCount > 1) // if there's already one that exists, unless this is the first one that exists
        {
            gameObject.SetActive(false); // this makes sure that nothing else happens as this thing is getting destroy
            Destroy(gameObject); // There can only be one game status, this will destroy the current GS if there's already one that exists
        } else
        {
            DontDestroyOnLoad(gameObject); // if there's only one, don't destroy this one when the level loads in the future
        }
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
