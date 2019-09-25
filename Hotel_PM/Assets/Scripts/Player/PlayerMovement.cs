using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    private float speed;
    private float rotationSpeed;
    private float translation;
    private float rotation;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        rotationSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    #endregion

    #region Custom Methods
    void HandleInput()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0f, 0f, translation);
        transform.Rotate(0f, rotation, 0f);
    }
    #endregion
}
