﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private DropOffPoint waterDropOff;

    [SerializeField] public bool fullyGrown;

    [SerializeField] private GameObject stump;
    [SerializeField] private GameObject fullyGrownTree;

    [SerializeField] private float growTime;
    [SerializeField] private float currentGrowTime;

    private void Start()
    {
        if (fullyGrown)
        {
            stump.SetActive(false);
            fullyGrownTree.SetActive(true);
        }
        else
        {
            stump.SetActive(true);
            fullyGrownTree.SetActive(false);
        }

        currentGrowTime = growTime;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (fullyGrown)
            {
                UIManager.Instance.ChopTree();

                if (Input.GetKeyDown(KeyCode.Q) && !PlayerMovement.Instance.isHoldingWood)
                {
                    ChopTree();
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

    private void Update()
    {
        if (waterDropOff.consumeAvailable)
        {
            if (!fullyGrown)
            {
                currentGrowTime = Timer(currentGrowTime);

                if (currentGrowTime <= 0)
                {
                    fullyGrown = true;
                    currentGrowTime = growTime;

                    stump.SetActive(false);
                    fullyGrownTree.SetActive(true);
                }
            }
        }
    }

    private void ChopTree()
    {
        PlayerMovement.Instance.IncreaseWoodNumber();

        fullyGrown = false;

        stump.SetActive(true);
        fullyGrownTree.SetActive(false);
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }
}
