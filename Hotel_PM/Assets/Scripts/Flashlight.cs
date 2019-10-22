using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public Light flashlight;
    public bool on;
    //public float timer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        flashlight.enabled = false;
        on = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (on == true)
            {
                on = false;
                flashlight.enabled = false;
            }
            else //(on == false)
            {
                on = true;
                flashlight.enabled = true;
            }
 
        }

           if (on == true)
            {
               // flashlight.enabled = true;
                if (flashlight.intensity > 0)
                {
                    flashlight.intensity -= .01f * Time.deltaTime;
                }
                else
                {
                     flashlight.intensity = 0;
                     on = false;
                     flashlight.enabled = false;
            }
           }        

    }
}
       




