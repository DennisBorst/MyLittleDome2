using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPile : MonoBehaviour
{
    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if (PlayerMovement.Instance.isHoldingWood)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    House.Instance.UpdateWood(1, true);
                    PlayerMovement.Instance.EmptyHanded();
                }
            }
        }
    }
}
