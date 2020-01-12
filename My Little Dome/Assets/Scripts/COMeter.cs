using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COMeter : MonoBehaviour
{
    [SerializeField] private Animals sheeps;
    [Space]
    [SerializeField] private int minSheeps;
    [SerializeField] private int maxSheeps;
    [Space]
    [SerializeField] private int maxGameOverZone;
    [Space]
    [SerializeField] private float currentCO2Level;

    [Header("Slider")]
    [SerializeField] private Slider co2Slider;

    private float timerSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        timerSpeed = 0;

        co2Slider.maxValue = maxGameOverZone;
        currentCO2Level = maxGameOverZone / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentCO2Level <= 0 || currentCO2Level >= maxGameOverZone)
        {
            GameManager.Instance.GameOverAir(2);
            return;
        }

        co2Slider.value = currentCO2Level;
        CheckSheeps();
    }

    private void CheckSheeps()
    {
        if (sheeps.animalsAlive == minSheeps - 1 || sheeps.animalsAlive == maxSheeps + 1)
        {
            if (sheeps.animalsAlive < minSheeps)
            {
                currentCO2Level = Timer(currentCO2Level, 1);
            }
            else
            {
                currentCO2Level = Timer(currentCO2Level, -1);
            }
        }
        else if (sheeps.animalsAlive <= minSheeps - 2 || sheeps.animalsAlive >= maxSheeps + 2)
        {
            if (sheeps.animalsAlive < minSheeps)
            {
                currentCO2Level = Timer(currentCO2Level, 2);
            }
            else
            {
                currentCO2Level = Timer(currentCO2Level, -2);
            }
        }
    }

    private float Timer(float timer, int timerSpeed)
    {
        timer -= Time.deltaTime * timerSpeed;
        return timer;
    }
}