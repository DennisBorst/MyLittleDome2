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

    private void Awake()
    {
        currentSurviveTime = mustSurviveTime;
        currentDayTime = mustSurviveTime / 7;

        instance = this;

        winScreen.SetActive(false);
        endScreen.SetActive(false);
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
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

    public void LoadScene(int sceneLevel)
    {
        SceneManager.LoadScene(sceneLevel);
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

        if(healthType == 1)
        {
            endText.text = "You have died of thirst, which means you haven't drank enough water.";
        }
        else if (healthType == 2)
        {
            endText.text = "You have died of hunger, which means you haven't consumed enough food.";
        }
        else if (healthType == 3)
        {
            endText.text = "You froze to death, which means you haven't kept yourself warm enough.";
        }
    }

    public void GameOverAir(int airType)
    {
        //Lost the game
        Time.timeScale = 0;
        endScreen.SetActive(true);
        Debug.Log("Game Over : Air");

        if (airType == 1)
        {
            endText.text = "The ecosystem is out of balance, which means the oxygen level was either too high or too low.";
        }
        else if (airType == 2)
        {
            endText.text = "The ecosystem is out of balance, which means the CO2 level was either too high or too low.";
        }
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
