using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private DropOffPoint waterDropOff;

    [SerializeField] private GameObject seeds;
    [SerializeField] private GameObject grown;
    [SerializeField] private GameObject fullyGrown;

    private bool planted;
    private bool nextStage;
    private bool finished;

    [SerializeField] private float secondStageTimer;
    [SerializeField] private float thirdStageTimer;
    [SerializeField] private float currentNextStageTime;

    // Start is called before the first frame update
    void Start()
    {
        ResetPlant();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!planted)
            {
                UIManager.Instance.PlaceSeed();

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    ResetPlant();
                    PlantSeed();

                    UIManager.Instance.DisableCanvas();
                }

            }
            if (finished)
            {
                UIManager.Instance.HarvestPlant();

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //Get some food 
                    Debug.Log("You harvest a plant");
                    PlayerMovement.Instance.IncreasePlantNumber();
                    ResetPlant();

                    UIManager.Instance.DisableCanvas();
                }
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

    // Update is called once per frame
    void Update()
    {
        if (!planted)
        {
            return;
        }

        if (finished)
        {
            return;
        }

        GrowPlant();
    }

    private void PlantSeed()
    {
        planted = true;
        seeds.SetActive(true);
    }

    private void GrowPlant()
    {

        if (waterDropOff.consumeAvailable && !nextStage)
        {
            currentNextStageTime = Timer(currentNextStageTime);

            if (currentNextStageTime <= 0)
            {
                seeds.SetActive(false);
                grown.SetActive(true);

                currentNextStageTime = thirdStageTimer;
                nextStage = true;
            }
        }

        if (waterDropOff.consumeAvailable && nextStage)
        {
            currentNextStageTime = Timer(currentNextStageTime);

            if (currentNextStageTime <= 0)
            {
                grown.SetActive(false);
                fullyGrown.SetActive(true);

                nextStage = false;
                finished = true;
            }
        }
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }

    private void ResetPlant()
    {
        planted = false;
        nextStage = false;
        finished = false;

        seeds.SetActive(false);
        grown.SetActive(false);
        fullyGrown.SetActive(false);

        currentNextStageTime = secondStageTimer;
    }
}
