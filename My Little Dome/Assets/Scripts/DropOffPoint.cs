using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffPoint : MonoBehaviour
{
    [SerializeField] private bool waterTank = true;

    [SerializeField] private bool farm;
    [SerializeField] private bool animals;
    [SerializeField] private bool forest;

    [SerializeField] private GameObject waterLevel;
    [SerializeField] private GameObject foodLevel;

    [SerializeField] private float durationTimer;
    [SerializeField] private float currentTime;

    [HideInInspector] public bool consumeAvailable;

    // Start is called before the first frame update
    void Start()
    {
        if (waterTank)
        {
            waterLevel.SetActive(true);
        }
        else
        {
            foodLevel.SetActive(true);
        }

        consumeAvailable = true;
        currentTime = durationTimer;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Timer(currentTime);

        if (currentTime <= 0)
        {
            if (waterTank)
            {
                waterLevel.SetActive(false);
            }
            else
            {
                foodLevel.SetActive(false);
            }

            currentTime = 0;
            consumeAvailable = false;
        }
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (waterTank)
            {
                WaterDropOff();
            }
            else
            {
                FoodDropOff();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            UIManager.Instance.DisableCanvas();
        }
    }

    private void WaterDropOff()
    {
        if (PlayerMovement.Instance.isHoldingBucket)
        {
            if (farm)
            {
                UIManager.Instance.DropWater(1);
            }
            else if (animals)
            {
                UIManager.Instance.DropWater(2);
            }
            else if (forest)
            {
                UIManager.Instance.DropWater(3);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                waterLevel.SetActive(true);
                consumeAvailable = true;
                currentTime = durationTimer;
                PlayerMovement.Instance.EmptyHanded();
                UIManager.Instance.DisableCanvas();
            }
        }
    }

    private void FoodDropOff()
    {
        if (PlayerMovement.Instance.isHoldingFood)
        {
            UIManager.Instance.DropFoodAnimals();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                foodLevel.SetActive(true);
                consumeAvailable = true;
                currentTime = durationTimer;
                PlayerMovement.Instance.EmptyHanded();
                UIManager.Instance.DisableCanvas();
            }
        }
    }
}
