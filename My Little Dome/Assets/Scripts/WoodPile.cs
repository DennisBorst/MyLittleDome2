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
                UIManager.Instance.PlaceWood(true);

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    House.Instance.UpdateWood(1, true);
                    PlayerMovement.Instance.EmptyHanded();
                    UIManager.Instance.DisableCanvas();
                }
            }
            else
            {
                UIManager.Instance.PlaceWood(false);
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
}
