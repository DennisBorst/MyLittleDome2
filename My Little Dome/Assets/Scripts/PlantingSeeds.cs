using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSeeds : MonoBehaviour
{
    [SerializeField] private Transform[] allChildren;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < allChildren.Length; i++)
        {
            float distanceToPlant = Vector3.Distance(allChildren[i].transform.position, player.transform.position);
        }
    }
}
