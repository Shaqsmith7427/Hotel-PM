using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    private float speed;
    private float rotationSpeed;
    private float translation;
    private float v_translation;
    private float h_translation;
    private float rotation;
    private float mouse_y_axis;
    private float mouse_x_axis;

    [SerializeField] Camera player_camera;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        rotationSpeed = 25f;
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
        //Moves Forward and back along z axis                           //Up/Down
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed);
        //Rotates Left and right along x Axis                               //Left/Right
        transform.Rotate(0f, Input.GetAxis("Horizontal")* rotationSpeed * Time.deltaTime, 0f);
    }

    /// <summary>
    /// Rotates camera in a Vertical manner -- Horizantal is controlled in HandleInput function
    /// Uses the mouse's Y-Axis to rotate the camera with respect to the player's X-Axis
    /// Uses -y_axis to avoid the camera rotation being inverted
    /// </summary>
    void RotateCamera()
    {
        /*
        //Rotates Up & Down -- Rotates camera (Flashlight won't follow camera)
         mouse_y_axis= Input.GetAxis("Mouse Y");
         transform.Rotate(-mouse_y_axis, 0f, 0f);
         Mathf.Clamp(transform.eulerAngles.y, -45, 0);

        //Rotates Left & Right -- Rotates player
        mouse_x_axis = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouse_x_axis, 0f);
        Mathf.Clamp(transform.eulerAngles.x, -15, 15);
        */

        mouse_y_axis = -Input.GetAxis("Mouse Y") * (2 * rotationSpeed) * Time.deltaTime;
        //mouse_x_axis = Input.GetAxis("Mouse X") * (2 * rotationSpeed) * Time.deltaTime;

        //Mathf.Clamp(mouse_y_axis, -30, 30);
        //Mathf.Clamp(mouse_x_axis, -30, 30);

        Mathf.Clamp(mouse_y_axis, -15f, 15f);

        //player_camera.transform.Rotate(mouse_y_axis, mouse_x_axis, 0f);
        player_camera.transform.Rotate(mouse_y_axis, 0f, 0f);
    }
    #endregion
}
