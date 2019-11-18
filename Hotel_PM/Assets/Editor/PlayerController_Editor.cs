using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerController))]
public class PlayerController_Editor : Editor
{
    [SerializeField] private PlayerController player;

    [SerializeField] private float viewRadius;
    [Range(0, 360)] //Restricts viewAngle to only have values of 0-360
    [SerializeField] private float viewAngle;

    //Draws handles on the scene
    private void onSceneGUI()
    {
        //ViewRadius Setup -- Creates the circle around the agent
        //Sets Handles to be white
        Handles.color = Color.white;
        //Draws an arc around the the obj in the center, fow
        ///Handles.DrawWireArc(player.transform.position, Vector3.up, Vector3.forward, 360, player.getViewRadius());
    }

    #region Getters
    //viewRadius
    public float getViewRadius()
    {
        return this.viewRadius;
    }
    //viewAngle
    public float getViewAngle()
    {
        return this.viewAngle;
    }
    #endregion
}
