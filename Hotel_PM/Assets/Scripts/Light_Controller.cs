using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] Light light;

    private bool isLightOn;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        isLightOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        handleLight();
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
    #endregion
}
