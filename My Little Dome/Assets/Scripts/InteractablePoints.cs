using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePoints : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected virtual void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            InteractableInputs();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            UIManager.Instance.DisableCanvas();
        }
    }

    protected virtual void InteractableInputs()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InteractableMoveOne();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            InteractableMoveTwo();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            InteractableMoveThree();
        }
    }

    protected virtual void InteractableMoveOne()
    {
        //Move 1
    }

    protected virtual void InteractableMoveTwo()
    {
        //Move 2
    }

    protected virtual void InteractableMoveThree()
    {
        //Move 3
    }
}
