using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] float rotationSpeed = 50f;
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
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    #endregion
}
