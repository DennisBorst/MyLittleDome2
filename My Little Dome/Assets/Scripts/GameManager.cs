using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float mustSurviveTime;
    private float currentSurviveTime;

    void Awake()
    {
        currentSurviveTime = mustSurviveTime;
    }

    void Update()
    {
        currentSurviveTime = Timer(currentSurviveTime);

        if(currentSurviveTime <= 0)
        {
            WonGame();
        }
    }

    public void WonGame()
    {
        Debug.Log("You won");
        //Game has won
    }

    public void GameOver()
    {
        Debug.Log("You lose");
        //Lost the game
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }
}
