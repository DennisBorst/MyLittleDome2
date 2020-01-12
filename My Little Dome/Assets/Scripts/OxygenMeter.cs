using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenMeter : MonoBehaviour
{
    [SerializeField] private Tree[] trees;
    [SerializeField] private int amountOfTreesGrown;
    [Space]
    [SerializeField] private int minTrees;
    [SerializeField] private int maxTrees;
    [Space]
    [SerializeField] private int maxGameOverZone;
    [Space]
    [SerializeField] private float currentOxygenLevel;

    [Header("Slider")]
    [SerializeField] private Slider oxygenSlider;

    private float timerSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        amountOfTreesGrown = 0;
        timerSpeed = 0;

        oxygenSlider.maxValue = maxGameOverZone;
        currentOxygenLevel = maxGameOverZone/2;

        for (int i = 0; i < trees.Length; i++)
        {
            if (trees[i].fullyGrown)
            {
                amountOfTreesGrown++;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(currentOxygenLevel <= 0 || currentOxygenLevel >= maxGameOverZone)
        {
            GameManager.Instance.GameOverAir(1);
            return;
        }

        oxygenSlider.value = currentOxygenLevel;
        CheckTrees();
    }

    private void CheckTrees()
    {
        amountOfTreesGrown = 0;

        for (int i = 0; i < trees.Length; i++)
        {
            if (trees[i].fullyGrown)
            {
                amountOfTreesGrown++;
            }
        }

        if (amountOfTreesGrown == minTrees - 1 || amountOfTreesGrown == maxTrees + 1)
        {
            if (amountOfTreesGrown < minTrees)
            {
                currentOxygenLevel = Timer(currentOxygenLevel, 1);
            }
            else
            {
                currentOxygenLevel = Timer(currentOxygenLevel, -1);
            }
        }
        else if (amountOfTreesGrown == minTrees - 2 || amountOfTreesGrown == maxTrees + 2)
        {
            if (amountOfTreesGrown < minTrees)
            {
                currentOxygenLevel = Timer(currentOxygenLevel, 2);
            }
            else
            {
                currentOxygenLevel = Timer(currentOxygenLevel, -2);
            }
        }
        else if (amountOfTreesGrown <= minTrees - 3 || amountOfTreesGrown >= maxTrees + 3)
        {
            if (amountOfTreesGrown < minTrees)
            {
                currentOxygenLevel = Timer(currentOxygenLevel, 3);
            }
            else
            {
                currentOxygenLevel = Timer(currentOxygenLevel, -3);
            }
        }
    }

    private float Timer(float timer, int timerSpeed)
    {
        timer -= Time.deltaTime * timerSpeed;
        return timer;
    }
}
