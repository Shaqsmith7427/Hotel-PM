using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRotator_Controller : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 25f;

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f, rotationSpeed * Time.deltaTime) ;

    }
}
