﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPoint : InteractablePoints
{
    protected override void OnTriggerStay(Collider collider)
    {
        base.OnTriggerStay(collider);
        UIManager.Instance.WaterPoint();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            UIManager.Instance.DisableCanvas();
        }
    }

    protected override void InteractableInputs()
    {
        base.InteractableInputs();
    }

    protected override void InteractableMoveOne()
    {
        base.InteractableMoveOne();
        PlayerMovement.Instance.EmptyHanded();
        PlayerMovement.Instance.isHoldingBucket = true;
        PlayerMovement.Instance.ToolEquiped();
    }

    protected override void InteractableMoveTwo()
    {
        base.InteractableMoveOne();

        Health.Instance.currentWater = Health.Instance.waterCapacity;
    }
}
