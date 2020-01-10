using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirection : MonoBehaviour
{
    [SerializeField] private Transform[] canvasTurn;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < canvasTurn.Length; i++)
            {
                canvasTurn[i].transform.rotation = Quaternion.Euler(canvasTurn[i].transform.rotation.eulerAngles.x, canvasTurn[i].transform.rotation.eulerAngles.y + 90f, canvasTurn[i].transform.rotation.eulerAngles.z);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < canvasTurn.Length; i++)
            {
                canvasTurn[i].transform.rotation = Quaternion.Euler(canvasTurn[i].transform.rotation.eulerAngles.x, canvasTurn[i].transform.rotation.eulerAngles.y - 90f, canvasTurn[i].transform.rotation.eulerAngles.z);
            }
        }
    }
}
