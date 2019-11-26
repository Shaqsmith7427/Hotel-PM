using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBar : MonoBehaviour
{
    private Transform bar;
    public Light flashlight;


    private void Start()
    {
        Transform bar = transform.Find("Bar");
        bar.localScale = new Vector3(flashlight.intensity, 1f);

    }

   
}
