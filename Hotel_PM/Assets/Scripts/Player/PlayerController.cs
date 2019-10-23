using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public Flashlight flash;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();
    }
    #endregion
 
    #region Custom Methods
    /// <summary>
    /// This function is called in Update. 
    /// Used for left mouse button interaction with game objects. Creates a raycast using the mouse position.
    /// Then uses compareTag() to determine what the obj is. 
    /// 
    /// If its a door...
    /// If the mouse position is on the door the collider, the door will open or close depending on it's current status. 
    /// The transform (of the door that's being clicked on) being referenced was drag and dropped in the GUI as the reference -- Obtained in line 53 via GetComponent
    /// 
    /// If its a battery..
    /// It increases the light intensity of the flashlight & makes the battery obj inactive
    /// </summary>
    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                Debug.Log("Click!");
                
                if(hit.collider.CompareTag("Door"))
                {
                    Door_Controller door = hit.transform.GetComponent<Door_Controller>();
                    if (door)
                    {
                        Debug.Log("Door Click..");
                        door.MoveDoor(door);
                    }
                }

                if (hit.collider.CompareTag("Battery"))
                {
                    Debug.Log("Battery Click..");
                    hit.collider.gameObject.SetActive(false);
                    flash.flashlight.intensity += 10;
                }
            }
        }
    }
    #endregion
}
