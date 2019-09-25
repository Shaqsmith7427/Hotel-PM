using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingGhost_FieldOfViewController : MonoBehaviour
{
    #region Variables
    [SerializeField] private float viewRadius;
    [Range(0,360)] //Restricts viewAngle to only have values of 0-360
    [SerializeField] private float viewAngle;

    [Range(0, 100)]
    [SerializeField] private float speed;

    //Used for ID'ing the target (ie the player) and obstacles
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    //Displays Current visisble targets
    public List<Transform> visibleTargets = new List<Transform>();

    //Reference to the WanderController script -- used to enable & disable it
    [SerializeField] private WanderingGhost_WanderController navMeshAgentWanderController;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f); //delay = .2f
    }

    #endregion

    #region Custom Methods
    //Takes an angle in and returns the direction from the angle
    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        //If the angle isnt a global angle, then it makes it a global angle.. idk what a global angle is..
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y; //Helps keep the angle relative to the character (I think...)
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0f, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    //Finds all the targets witin the agent's field of view
    public void FindVisibleTargets()
    {
        visibleTargets.Clear(); //Helps avoid duplicates within the list of visibleTargets
        //Gets an array of all targets
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        //Scans the array
        for(int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            //Finds the direction to target
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            //Checks if target is within our view angle
            if(Vector3.Angle(transform.forward, directionToTarget) < viewAngle/2)
            {
                //See if there's an obstacle
                //Calc distance to target
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                //If there's no collision with the raycast (ie no obstacles)
                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    //Adds target to the visibleTargets transform
                    visibleTargets.Add(target);

                }
            }

            //Creates an array of visible targets using the list 
            Transform[] visibleTargetsArray = visibleTargets.ToArray();
            //If there's an enemy in sight (list length > 0) the agent attacks
            if(visibleTargetsArray.Length > 0)
            {
                //If a target is found the agent switches out of 'wander' and swtiches to 'attack'
                //Disables WanderControl script
                GetComponent<WanderingGhost_WanderController>().enabled = false;
                //Sets the position of the the target in visibleTarges, ie moves towards the visible target-- 'attacks' the target
                NavMeshAgent navAgent = navMeshAgentWanderController.getNavMeshAgent();
                navAgent.speed = speed;
                navAgent.SetDestination(visibleTargets[i].position);
            }
            else
            {
                //Enables WanderController script bc there's no targets insight to 'attack'
                GetComponent<WanderingGhost_WanderController>().enabled = true;
            }
        }

    }
    #endregion

    #region Coroutines
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            FindVisibleTargets();
        }
    }
    #endregion

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
