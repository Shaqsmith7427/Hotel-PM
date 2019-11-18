using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] GameObject key;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateKey();
    }
    #endregion

    #region Custom Methods
    void RotateKey()
    {
        key.transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);
    }
    #endregion
}
