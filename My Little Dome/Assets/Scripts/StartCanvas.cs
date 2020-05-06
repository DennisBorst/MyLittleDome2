using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanvas : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        gameManager.enabled = false;

        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;

        gameManager.enabled = true;
    }
}