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

    [SerializeField] Camera player_camera;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        rotationSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        RotateCamera();
    }

    #endregion

    #region Custom Methods
    /// <summary>
    /// Handles Input for user movement/interaction
    /// Translates the player's position with respect to their Vertical-Axiss
    /// Rotates the horizantal axis of the player
    /// </summary>
    void HandleInput()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0f, 0f, translation);
        transform.Rotate(0f, rotation, 0f);

        
    }

    /// <summary>
    /// Rotates camera in a Vertical manner -- Horizantal is controlled in HandleInput function
    /// Uses the mouse's Y-Axis to rotate the camera with respect to the player's X-Axis
    /// Uses -y_axis to avoid the camera rotation being inverted
    /// </summary>
    void RotateCamera()
    {
        float y_axis = Input.GetAxis("Mouse Y");
        player_camera.transform.Rotate(-y_axis, 0f, 0f);
    }

   
    #endregion
}
