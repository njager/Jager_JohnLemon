﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    //public variables
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public GameObject player;
    public Observer observer;

    //member variables
    int m_CurrentWaypointIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the ghost has reached destination then changes waypoint
        if (observer.playerSpotted == false)
        {
            Patrol();
        }
        else if (!observer.playerSpotted == false) 
        {
            Chase();
        }
    }
    //sets the ghost to move between waypoints
    void Patrol()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
    //sets teh ghost to chase the player
    void Chase()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
}
