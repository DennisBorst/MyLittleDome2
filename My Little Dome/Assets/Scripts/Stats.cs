using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private bool farmStats;

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if (farmStats)
            {
                UIManager.Instance.StatsDisplayFarm();
            }
            else
            {
                UIManager.Instance.DisplayStatsWood();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            UIManager.Instance.DisableStats();
        }
    }
}
