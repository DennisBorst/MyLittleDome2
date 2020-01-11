using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int waterCapacity;
    [SerializeField] public int foodCapacity;
    [SerializeField] public int heatCapacity;
    [Space]
    [SerializeField] public float currentWater;
    [SerializeField] public float currentFood;
    [SerializeField] public float currentHeat;
    [Space]
    [SerializeField] private float popUpStageOne;
    [SerializeField] private float popUpStageTwo;
    [SerializeField] private float popUpStageThree;

    // Start is called before the first frame update
    void Start()
    {
        currentWater = waterCapacity;
        currentFood = foodCapacity;
        currentHeat = heatCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        Water();
        Food();
        Heat();

        if (currentWater <= 0 || currentFood <= 0 || currentHeat <= 0)
        {
            //Game Over
            Debug.Log("Game Over");
        }
    }

    private void Water()
    {
        currentWater = Timer(currentWater);

        if(currentWater > popUpStageOne)
        {
            UIManager.Instance.DisablePlayerCanvas(1);
        }

        if (currentWater <= popUpStageThree)
        {
            UIManager.Instance.Health(1, 3);
        }
        else if (currentWater <= popUpStageTwo)
        {
            UIManager.Instance.Health(1, 2);
        }
        else if (currentWater <= popUpStageOne)
        {
            UIManager.Instance.Health(1, 1);
        }
    }

    private void Food()
    {
        currentFood = Timer(currentFood);

        if (currentFood > popUpStageOne)
        {
            UIManager.Instance.DisablePlayerCanvas(2);
        }

        if (currentFood <= popUpStageThree)
        {
            UIManager.Instance.Health(2, 3);
        }
        else if (currentFood <= popUpStageTwo)
        {
            UIManager.Instance.Health(2, 2);
        }
        else if (currentFood <= popUpStageOne)
        {
            UIManager.Instance.Health(2, 1);
        }
    }

    private void Heat()
    {
        currentHeat = Timer(currentHeat);

        if (currentHeat > popUpStageOne)
        {
            UIManager.Instance.DisablePlayerCanvas(3);
        }

        if (currentHeat <= popUpStageThree)
        {
            UIManager.Instance.Health(3, 3);
        }
        else if (currentHeat <= popUpStageTwo)
        {
            UIManager.Instance.Health(3, 2);
        }
        else if (currentHeat <= popUpStageOne)
        {
            UIManager.Instance.Health(3, 1);
        }
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }

    #region Singleton
    private static Health instance;

    private void Awake()
    {
        instance = this;
    }

    public static Health Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Health();
            }

            return instance;
        }
    }

    #endregion
}
