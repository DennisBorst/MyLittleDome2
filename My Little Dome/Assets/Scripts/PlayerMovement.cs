﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraMiddlePoint;

    public bool isHoldingBucket;
    public bool isHoldingWood;
    public bool isHoldingFood;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Transform playerObject;

    private CharacterController characterController;

    [Header("Holding Objects")]
    [SerializeField] private GameObject bucket;
    [SerializeField] private GameObject wood;
    [SerializeField] private GameObject food;

    [Header("Farm Related")]
    [SerializeField] private int amountOfPlantsToFarm;
    [SerializeField] private int currentAmountOfPlants;

    [Header("Forest Related")]
    [SerializeField] private int amountOfTreeToChop;
    [SerializeField] private int currentAmountOfWood;

    private bool equipedTool = false;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        characterController = GetComponent<CharacterController>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x > 0.3f || x < -0.3f || z > 0.3f || z < -0.3f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        Vector3 move = transform.right * x + transform.forward * z;

        if(x > 0.5f && z < 0.5f && z > -0.5f) //going to the right
        {
            playerObject.transform.rotation = Quaternion.Euler(0, cameraMiddlePoint.transform.position.y + 120, 0);
        }
        else if (x < -0.5f && z < 0.5f && z > -0.5f) //going to the left
        {
            playerObject.transform.rotation = Quaternion.Euler(0, cameraMiddlePoint.transform.position.y - 60, 0);
        }
        else if (x < 0.5f && x > -0.5f && z > 0.5f) //going to the up
        {
            playerObject.transform.rotation = Quaternion.Euler(0, cameraMiddlePoint.transform.position.y + 30, 0);
        }
        else if (x < 0.5f && x > -0.5f && z < -0.5f) //going to the down
        {
            playerObject.transform.rotation = Quaternion.Euler(0, cameraMiddlePoint.transform.position.y - 150, 0);
        }
        else if (x > 0.5f && z > 0.5f) //going right and up
        {
            playerObject.transform.rotation = Quaternion.Euler(0, cameraMiddlePoint.transform.position.y + 75, 0);
        }
        else if (x < -0.5f && z < -0.5f) //going left and down
        {
            playerObject.transform.rotation = Quaternion.Euler(0, cameraMiddlePoint.transform.position.y - 105, 0);
        }
        else if (x < -0.5f && z > 0.5f) //going left and up
        {
            playerObject.transform.rotation = Quaternion.Euler(0, cameraMiddlePoint.transform.position.y - 15, 0);
        }
        else if (x > 0.5f && z < -0.5f) //going right and down
        {
            playerObject.transform.rotation = Quaternion.Euler(0, cameraMiddlePoint.transform.position.y + 165, 0);
        }

        characterController.Move(move * movementSpeed * Time.deltaTime);
    }

    public void EmptyHanded()
    {
        equipedTool = false;

        bucket.SetActive(false);
        wood.SetActive(false);
        food.SetActive(false);

        isHoldingBucket = false;
        isHoldingWood = false;
        isHoldingFood = false;
    }

    public void ToolEquiped()
    {
        equipedTool = true;

        if (isHoldingBucket)
        {
            bucket.SetActive(true);
        }
        else if (isHoldingWood)
        {
            wood.SetActive(true);
        }
        else if (isHoldingFood)
        {
            food.SetActive(true);
        }
    }

    public void IncreasePlantNumber()
    {
        currentAmountOfPlants++;

        if(currentAmountOfPlants >= amountOfPlantsToFarm)
        {
            currentAmountOfPlants = 0;

            EmptyHanded();
            isHoldingFood = true;
            ToolEquiped();
        }

        UIManager.Instance.UpdateStatsFarm(currentAmountOfPlants);
    }

    public void IncreaseWoodNumber()
    {
        currentAmountOfWood++;

        if (currentAmountOfWood >= amountOfTreeToChop)
        {
            currentAmountOfWood = 0;

            EmptyHanded();
            isHoldingWood = true;
            ToolEquiped();
        }

        UIManager.Instance.UpdateStatsForest(currentAmountOfWood);
    }

    #region Singleton
    private static PlayerMovement instance;

    public static PlayerMovement Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new PlayerMovement();
            }
            return instance;
        }
    }
    #endregion
}
