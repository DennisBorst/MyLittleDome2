using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButcherPlace : MonoBehaviour
{
    [SerializeField] private Animals animal;

    private float isPressingTime = 0.5f;
    private float currentIsPressingTime;

    private bool isPressing = false;

    private void Start()
    {
        currentIsPressingTime = isPressingTime;
    }

    private void Update()
    {
        if (isPressing)
        {
            currentIsPressingTime = Timer(currentIsPressingTime);

            if (currentIsPressingTime <= 0)
            {
                isPressing = false;
                currentIsPressingTime = isPressingTime;
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (animal.animalsAlive > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !isPressing)
            {
                isPressing = true;
                animal.KillAnimal();
                Health.Instance.currentFood = Health.Instance.foodCapacity;
            }
        }
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }
}
