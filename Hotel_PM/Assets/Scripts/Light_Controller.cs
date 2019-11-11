using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] Light light;

    [SerializeField] private float rotationSpeed;
    private bool isLightOn;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        //Lights are off by default (not including lights in the hallway)
        isLightOn = false;

        //Sets fan-blade rotation to a random value within the range
        rotationSpeed = Random.Range(45f, 180f);
    }

    // Update is called once per frame
    void Update()
    {
        handleLight();
        RotateFanBlades();
    }
    #endregion

    #region Custom Methods
    void handleLight()
    {
        if (isLightOn)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }

    public void setLight()
    {
        isLightOn = !isLightOn;
    }

    void RotateFanBlades()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
    #endregion
}
