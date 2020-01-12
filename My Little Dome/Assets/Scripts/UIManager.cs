using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Day Cycle")]
    [SerializeField] private TextMeshProUGUI dayTime;

    [Header("WaterPoint")]
    [SerializeField] private GameObject waterCanvas;

    [Header("Player")]
    [SerializeField] private GameObject[] healthTypeUI;
    [SerializeField] private Image[] colorHealthType;

    [Header("House")]
    [SerializeField] private GameObject placeWoodHouse;
    [SerializeField] private GameObject noPlaceWoodHouse;
    [SerializeField] private GameObject goInsideHouse;
    [SerializeField] private GameObject noGoInsideHouse;

    [Header("Farm")]
    [SerializeField] private GameObject dropWaterFarm;
    [SerializeField] private GameObject placeSeedFarm;
    [SerializeField] private GameObject harvestFoodFarm;
    [SerializeField] private GameObject maisStatsFarm;
    [SerializeField] private TextMeshProUGUI maisStats;

    [Header("Animals")]
    [SerializeField] private GameObject dropWaterAnimals;
    [SerializeField] private GameObject dropFoodAnimals;
    [SerializeField] private GameObject eatAnimals;

    [SerializeField] private Image[] colorWaterAnimal;
    [SerializeField] private Image[] colorFoodAnimal;

    [SerializeField] private GameObject[] animalFood;
    [SerializeField] private GameObject[] animalWater;

    [Header("Forest")]
    [SerializeField] private GameObject dropWaterForest;
    [SerializeField] private GameObject chopTreeForest;

    [SerializeField] private GameObject woodStatsFarm;
    [SerializeField] private TextMeshProUGUI woodStats;

    private void Awake()
    {
        instance = this;

        DisableCanvas();
        DisableStats();
    }

    #region DayTime
    public void IncreaseDayCount(int dayCount)
    {
        dayTime.text = "Day: " + dayCount;
    }
    #endregion

    #region Player
    public void Health(int healthType, int phase)
    {
        healthTypeUI[healthType - 1].SetActive(true);

        if (phase == 1)
        {
            colorHealthType[healthType - 1].color = new Color32(255, 255, 0, 150);
        }
        else if(phase == 2)
        {
            colorHealthType[healthType - 1].color = new Color32(255, 140, 0, 150);
        }
        else if (phase == 3)
        {
            colorHealthType[healthType - 1].color = new Color32(255, 0, 0, 150);
        }
    }
    #endregion

    #region House
    public void PlaceWood(bool active)
    {
        if (active)
        {
            placeWoodHouse.SetActive(true);
        }
        else
        {
            noPlaceWoodHouse.SetActive(true);
        }
    }

    public void GoInside(bool active)
    {
        if (active)
        {
            goInsideHouse.SetActive(true);
        }
        else
        {
            noGoInsideHouse.SetActive(true);
        }
    }
    #endregion

    #region WaterPoint
    public void WaterPoint()
    {
        waterCanvas.SetActive(true);
    }

    public void DropWater(int waterPlace)
    {
        if(waterPlace == 1)
        {
            dropWaterFarm.SetActive(true);
        }
        else if (waterPlace == 2)
        {
            dropWaterAnimals.SetActive(true);
        }
        else if (waterPlace == 3)
        {
            dropWaterForest.SetActive(true);
        }
    }
    #endregion

    #region Farm
    public void PlaceSeed()
    {
        placeSeedFarm.SetActive(true);
    }

    public void HarvestPlant()
    {
        harvestFoodFarm.SetActive(true);
    }

    public void StatsDisplayFarm()
    {
        maisStatsFarm.SetActive(true);
    }

    public void UpdateStatsFarm(int maisCount)
    {
        maisStats.text = maisCount + " / 5";
    }
    #endregion

    #region Animals
    public void DropFoodAnimals()
    {
        dropFoodAnimals.SetActive(true);
    }

    public void AnimalFood(int currentAnimal, bool correct)
    {
        if (correct)
        {
            animalFood[currentAnimal - 1].SetActive(true);
        }
        else
        {
            animalFood[currentAnimal - 1].SetActive(false);
        }
    }

    public void AnimalWater(int currentAnimal, bool correct)
    {
        if (correct)
        {
            animalWater[currentAnimal - 1].SetActive(true);
        }
        else
        {
            animalWater[currentAnimal - 1].SetActive(false);
        }
    }

    public void AnimalDiedOrBorn()
    {
        for (int i = 0; i < animalFood.Length; i++)
        {
            animalFood[i].SetActive(false);
        }

        for (int i = 0; i < animalFood.Length; i++)
        {
            animalWater[i].SetActive(false);
        }
    }

    public void EatAnimal()
    {
        eatAnimals.SetActive(true);
    }

    public void HealthAnimal(int animalAlive, int phase)
    {
        if (phase == 1)
        {
            colorWaterAnimal[animalAlive - 1].color = new Color32(255, 255, 0, 150);
            colorFoodAnimal[animalAlive - 1].color = new Color32(255, 255, 0, 150);
        }
        else if (phase == 2)
        {
            colorWaterAnimal[animalAlive - 1].color = new Color32(255, 140, 0, 150);
            colorFoodAnimal[animalAlive - 1].color = new Color32(255, 140, 0, 150);

        }
        else if (phase == 3)
        {
            colorWaterAnimal[animalAlive - 1].color = new Color32(255, 0, 0, 150);
            colorFoodAnimal[animalAlive - 1].color = new Color32(255, 0, 0, 150);
        }
    }
    #endregion

    #region Forest
    public void ChopTree()
    {
        chopTreeForest.SetActive(true);
    }

    public void DisplayStatsWood()
    {
        woodStatsFarm.SetActive(true);
    }


    public void UpdateStatsForest(int woodCount)
    {
        woodStats.text = woodCount + " / 5";
    }
    #endregion

    public void DisableCanvas()
    {
        //waterplace
        waterCanvas.SetActive(false);

        //House
        placeWoodHouse.SetActive(false);
        goInsideHouse.SetActive(false);

        noPlaceWoodHouse.SetActive(false);
        noGoInsideHouse.SetActive(false);

        //farm
        dropWaterFarm.SetActive(false);
        placeSeedFarm.SetActive(false);
        harvestFoodFarm.SetActive(false);

        //animals
        dropWaterAnimals.SetActive(false);
        dropFoodAnimals.SetActive(false);
        eatAnimals.SetActive(false);

        //forest
        dropWaterForest.SetActive(false);
        chopTreeForest.SetActive(false);
    }

    public void DisablePlayerCanvas(int healthType)
    {
        healthTypeUI[healthType - 1].SetActive(false);
    }

    public void DisableStats()
    {
        maisStatsFarm.SetActive(false);
        woodStatsFarm.SetActive(false);
    }

    /*
    public void DisableAnimalCanvas(int animal, bool water)
    {
        if (water)
        {
            color[healthType - 1].SetActive(false);
        }
    }
    */

    #region Singleton
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }
    #endregion
}
