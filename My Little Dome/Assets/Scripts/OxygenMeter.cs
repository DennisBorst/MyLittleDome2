using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenMeter : MonoBehaviour
{
    [SerializeField] private Tree[] trees;
    [SerializeField] private int amountOfTreesGrown;

    // Start is called before the first frame update
    void Start()
    {
        amountOfTreesGrown = 0;

        for (int i = 0; i < trees.Length; i++)
        {
            if (trees[i].fullyGrown)
            {
                amountOfTreesGrown++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        amountOfTreesGrown = 0;

        for (int i = 0; i < trees.Length; i++)
        {
            if (trees[i].fullyGrown)
            {
                amountOfTreesGrown++;
            }
        }
        
        if()

        Debug.Log(amountOfTreesGrown);
    }
}
