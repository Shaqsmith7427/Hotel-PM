using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(WanderingGhost_FieldOfViewController))]
public class WanderingGhost_FieldOfViewController_Editor : Editor
{
    //Draws handles on the scene
    private void OnSceneGUI()
    {
        //Creates a WanderingGhost_FieldOfViewController obj and assigns the target to it
        WanderingGhost_FieldOfViewController agentFOW = (WanderingGhost_FieldOfViewController)target;

        //ViewRadius Setup -- Creates the circle around the agent
        //Sets Handles to be white
        Handles.color = Color.white;
        //Draws an arc around the the obj in the center, fow
        Handles.DrawWireArc(agentFOW.transform.position, Vector3.up, Vector3.forward, 360, agentFOW.getViewRadius());

        //ViewAngles Setup -- Creates two angles that serve as the FieldOfView for the agent
        //Creates two Vector3s to retrieve points for making two lines
        Vector3 ViewAngleA = agentFOW.DirectionFromAngle(-agentFOW.getViewAngle() / 2, false);
        Vector3 ViewAngleB = agentFOW.DirectionFromAngle(agentFOW.getViewAngle() / 2, false);
        //Draws two lines using the two Vectors that were just created -- This creates the field of view
        Handles.DrawLine(agentFOW.transform.position, agentFOW.transform.position + ViewAngleA * agentFOW.getViewRadius());
        Handles.DrawLine(agentFOW.transform.position, agentFOW.transform.position + ViewAngleB * agentFOW.getViewRadius());

        //Draws a line pointing towards the target if it is within the agent's field of view
        Handles.color = Color.red; //Sets color to red to help differentiate it from the field of view lines
        //Draws a line towards every visible target (should only be 1 bc there's only 1 player...)
        foreach (Transform visibleTarget in agentFOW.visibleTargets)
            Handles.DrawLine(agentFOW.transform.position, visibleTarget.position);
    }

}
