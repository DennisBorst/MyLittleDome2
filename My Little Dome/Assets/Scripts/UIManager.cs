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
    [SerializeField] private GameObject goInsideHouse;

    [Header("Farm")]
    [SerializeField] private GameObject dropWaterFarm;
    [SerializeField] private GameObject placeSeedFarm;
    [SerializeField] private GameObject harvestFoodFarm;

    [Header("Animals")]
    [SerializeField] private GameObject dropWaterAnimals;
    [SerializeField] private GameObject dropFoodAnimals;
    [SerializeField] private GameObject eatAnimals;

    [SerializeField] private GameObject[] animalFood;
    [SerializeField] private GameObject[] animalWater;

    [Header("Forest")]
    [SerializeField] private GameObject dropWaterForest;
    [SerializeField] private GameObject chopTreeForest;

    private void Awake()
    {
        instance = this;

        DisableCanvas();
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
    public void PlaceWood()
    {
        placeWoodHouse.SetActive(true);
    }

    public void GoInside()
    {
        goInsideHouse.SetActive(true);
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
    #endregion

    #region Forest
    public void ChopTree()
    {
        chopTreeForest.SetActive(true);
    }
    #endregion

    public void DisableCanvas()
    {
        //waterplace
        waterCanvas.SetActive(false);

        //House
        placeWoodHouse.SetActive(false);
        goInsideHouse.SetActive(false);

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
