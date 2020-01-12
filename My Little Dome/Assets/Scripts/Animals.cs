using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public int animalsAlive;
    [SerializeField] private GameObject[] animals;

    [SerializeField] private DropOffPoint dropOffWater;
    [SerializeField] private DropOffPoint dropOfFood;

    [SerializeField] private float timeToCheckAnimal;
    [SerializeField] private float currentTimeToCheck;
    [Space]
    [SerializeField] private float happyTimeAnimal;
    [SerializeField] private float currentHappyAnimalTime;

    private float currentWater;
    private float currentFood;

    private float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentTimeToCheck = timeToCheckAnimal;
        currentHappyAnimalTime = happyTimeAnimal;

        currentWater = currentTimeToCheck;
        currentFood = currentTimeToCheck;

        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < animalsAlive; i++)
        {
            animals[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Starving();
    }

    private void Starving()
    {
        if (dropOfFood.consumeAvailable && dropOffWater.consumeAvailable)
        {
            currentHappyAnimalTime = Timer(currentHappyAnimalTime);
            currentTimeToCheck = timeToCheckAnimal;
            UIManager.Instance.AnimalDiedOrBorn();

            if (currentHappyAnimalTime <= 0)
            {
                if (animals.Length > animalsAlive)
                {
                    animalsAlive++;
                    AnimalsAlive(true);
                    currentHappyAnimalTime = happyTimeAnimal;

                    UIManager.Instance.AnimalDiedOrBorn();
                }
            }
        }
        else
        {
            if (dropOfFood.consumeAvailable || dropOffWater.consumeAvailable)
            {
                speed = 0.5f;
            }
            else
            {
                speed = 1;
            }

            if (!dropOfFood.consumeAvailable && !dropOffWater.consumeAvailable)
            {
                UIManager.Instance.AnimalFood(animalsAlive, true);
                UIManager.Instance.AnimalWater(animalsAlive, true);

                Food();
                Water();
            }
            else if (!dropOfFood.consumeAvailable)
            {
                UIManager.Instance.AnimalFood(animalsAlive, true);
                UIManager.Instance.AnimalWater(animalsAlive, false);

                Food();
                //UIManager.Instance.DisableAnimalCanvas(1);
            }
            else if (!dropOffWater.consumeAvailable)
            {
                UIManager.Instance.AnimalFood(animalsAlive, false);
                UIManager.Instance.AnimalWater(animalsAlive, true);

                Water();
                //UIManager.Instance.DisableAnimalCanvas(2);
            }
            else
            {
                //UIManager.Instance.DisableAnimalCanvas(1);
                //UIManager.Instance.DisableAnimalCanvas(2);
            }

            currentTimeToCheck = Timer(currentTimeToCheck);

            if (currentTimeToCheck <= 0)
            {
                animalsAlive--;
                AnimalsAlive(false);
                currentTimeToCheck = timeToCheckAnimal;

                UIManager.Instance.AnimalDiedOrBorn();
            }
        }
    }

    private void AnimalsAlive(bool alive)
    {
        if (alive)
        {
            animals[animalsAlive - 1].gameObject.SetActive(true);
        }
        else
        {
            animals[animalsAlive].gameObject.SetActive(false);
        }
    }

    public void KillAnimal()
    {
        animalsAlive--;
        AnimalsAlive(false);
        currentTimeToCheck = timeToCheckAnimal;

        UIManager.Instance.AnimalDiedOrBorn();
    }

    private void Water()
    {
        currentFood = Timer(currentFood);

        if (currentTimeToCheck <= (timeToCheckAnimal / 3) * 1)
        {
            UIManager.Instance.HealthAnimal(animalsAlive, 3);
        }
        else if (currentTimeToCheck <= (timeToCheckAnimal / 3) * 2)
        {
            UIManager.Instance.HealthAnimal(animalsAlive, 2);
        }
        else
        {
            UIManager.Instance.HealthAnimal(animalsAlive, 1);
        }
    }

    private void Food()
    {
        currentFood = Timer(currentFood);

        if (currentTimeToCheck <= (timeToCheckAnimal / 3) * 1)
        {
            UIManager.Instance.HealthAnimal(animalsAlive, 3);
        }
        else if (currentTimeToCheck <= (timeToCheckAnimal / 3) * 2)
        {
            UIManager.Instance.HealthAnimal(animalsAlive, 2);
        }
        else
        {
            UIManager.Instance.HealthAnimal(animalsAlive, 1);
        }
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime * speed;
        return timer;
    }
}
