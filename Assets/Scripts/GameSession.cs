using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1.1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplayEnabled;

    //State Variables
    [SerializeField] int currentScore;
    

    private void Awake()
    {
        int countGameStatus = FindObjectsOfType<GameSession>().Length;
        if(countGameStatus > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
     
        }

        
    }
    private void Start()
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
        currentScore = currentScore + pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoplayEnabled;
    }
}
