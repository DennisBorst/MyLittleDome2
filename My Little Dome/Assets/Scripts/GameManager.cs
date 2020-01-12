using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float mustSurviveTime;

    [Header("Won Game")]
    [SerializeField] private GameObject winScreen;

    [Header("Game Over")]
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI endText;

    private float currentSurviveTime;
    private float currentDayTime;
    private int dayCount = 1;

    void Awake()
    {
        Time.timeScale = 1f;

        currentSurviveTime = mustSurviveTime;
        currentDayTime = mustSurviveTime / 7;

        instance = this;

        winScreen.SetActive(false);
        endScreen.SetActive(false);
    }

    void Update()
    {

        if (currentSurviveTime <= 0)
        {
            WonGame();
            return;
        }

        TimeManagement();
    }

    public void TimeManagement()
    {
        currentSurviveTime = Timer(currentSurviveTime);
        currentDayTime = Timer(currentDayTime);

        if (currentDayTime <= 0)
        {
            currentDayTime = mustSurviveTime / 7;
            dayCount++;
            UIManager.Instance.IncreaseDayCount(dayCount);
        }
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void WonGame()
    {
        //Game has won
        Time.timeScale = 0;
        winScreen.SetActive(true);
        Debug.Log("You won");
    }

    public void GameOverHealth(int healthType)
    {
        //Lost the game
        Time.timeScale = 0;
        endScreen.SetActive(true);
        Debug.Log("Game Over : Health");
    }

    public void GameOverAir(int airType)
    {
        //Lost the game
        Time.timeScale = 0;
        endScreen.SetActive(true);
        Debug.Log("Game Over : Air");
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }

    #region Singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    #endregion
}
