using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurn : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private Vector3 currentAngle;

    [SerializeField] private Transform[] canvasTurns;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(0, 90, 0);
            //transform.rotation = Quaternion.Lerp(Quaternion.AngleAxis(this.transform.rotation.y, Vector3.up), Quaternion.AngleAxis(this.transform.rotation.y - 90, Vector3.up), rotateSpeed);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(0, -90, 0);

            //transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.AngleAxis(this.transform.rotation.y + 90, Vector3.up), rotateSpeed);
        }
    }
}
