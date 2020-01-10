using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isHoldingBucket;
    public bool isHoldingWood;
    public bool isHoldingFood;
    public bool isHoldingKnife;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Transform playerObject;

    private CharacterController characterController;

    [Header("Holding Objects")]
    [SerializeField] private GameObject bucket;
    [SerializeField] private GameObject wood;
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject knife;

    [Header("Farm Related")]
    [SerializeField] private int amountOfPlantsToFarm;
    [SerializeField] private int currentAmountOfPlants;

    [Header("Forest Related")]
    [SerializeField] private int amountOfTreeToChop;
    [SerializeField] private int currentAmountOfWood;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        characterController = GetComponent<CharacterController>();
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

        Vector3 move = transform.right * x + transform.forward * z;

        if(x > 0.5f && z < 0.5f && z > -0.5f) //going to the right
        {
            playerObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (x < -0.5f && z < 0.5f && z > -0.5f) //going to the left
        {
            playerObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (x < 0.5f && x > -0.5f && z > 0.5f) //going to the up
        {
            playerObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (x < 0.5f && x > -0.5f && z < -0.5f) //going to the down
        {
            playerObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (x > 0.5f && z > 0.5f) //going right and up
        {
            playerObject.transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else if (x < -0.5f && z < -0.5f) //going left and down
        {
            playerObject.transform.rotation = Quaternion.Euler(0, -135, 0);
        }
        else if (x < -0.5f && z > 0.5f) //going left and up
        {
            playerObject.transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        else if (x > 0.5f && z < -0.5f) //going right and down
        {
            playerObject.transform.rotation = Quaternion.Euler(0, 135, 0);
        }

        characterController.Move(move * movementSpeed * Time.deltaTime);
    }

    public void EmptyHanded()
    {
        bucket.SetActive(false);
        wood.SetActive(false);
        food.SetActive(false);
        knife.SetActive(false);

        isHoldingBucket = false;
        isHoldingWood = false;
        isHoldingFood = false;
        isHoldingKnife = false;
    }

    public void ToolEquiped()
    {
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
        else if (isHoldingKnife)
        {
            knife.SetActive(true);
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
