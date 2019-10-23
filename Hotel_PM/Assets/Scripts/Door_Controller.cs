using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    #region Variables
    bool isDoorOpen;
    float rotationSpeed = 25f;

    [SerializeField] GameObject door;
    #endregion

    #region Unity Methods
    private void Start()
    {
        isDoorOpen = false; //All doors are closed by default
    }
    #endregion

    #region Custom Methods
    /// <summary>
    /// When the a door is clicked it will rotate +or- 90 degrees. Depending on if 
    /// it's currently open or closed. Requires a Door_Controller to be passed in so it can access the transform
    /// of the door and rotate with respect to its current status (open or closed)
    /// </summary>
    public void MoveDoor(Door_Controller door)
    {
        if(isDoorOpen)
        {
            door.transform.Rotate(0f, 90f, 0f);
            isDoorOpen = false;
        }
        else
        {
            door.transform.Rotate(0f, -90f, 0f);
            isDoorOpen = true;
        }
    }
    #endregion
}
