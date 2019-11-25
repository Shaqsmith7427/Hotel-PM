using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HuntingGhost_WanderController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] public NavMeshAgent navMeshAgent;
    [SerializeField] private NavMeshHit navHit;
    [SerializeField] private Transform playerTrans;

    [SerializeField]  private float range;
    [SerializeField]  private float speed;

    //Stores Vector3 that is from SetRandomLocation 
    [SerializeField] private Vector3 finalDestination;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        SetRandomLocation();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAgent();
    }
    #endregion

    #region Custom Methods
    void MoveAgent()
    {
        // Choose the next destination point when the agent gets close to the current one
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f) //radiusOfSatisfaction = 0.5f;
        {
            Debug.Log("Ghost: Destination has been reached.. setting a new one");
            //Set new position
            SetRandomLocation();
        }
    }

    void SetRandomLocation()
    {
        //Sets random location
        Vector3 randomPoint = transform.position + (Random.insideUnitSphere * range);
        //Gets point within the NavMesh
        NavMesh.SamplePosition(randomPoint, out navHit, range, 1);
        //The position that is 'returned' 
        finalDestination = navHit.position;
        //Sets the location that agent will now travel to
        navMeshAgent.speed = speed;
        navMeshAgent.SetDestination(finalDestination);
    }

    public NavMeshAgent getNavMeshAgent()
    {
        return navMeshAgent;
    }
    #endregion
}
