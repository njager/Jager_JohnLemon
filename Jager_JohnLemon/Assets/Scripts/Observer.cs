using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // public variables
    public Transform player;
    public GameEnding gameEnding;
    public WaypointPatrol waypointPatrol;
    public bool playerSpotted;

    // member variables
    bool m_IsPlayerInRange;

    private void Start()
    {
        playerSpotted = false;
    }
    
    //detects if the player has entered range
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    //detects if the player has exited range
    private void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
    
    //called every frame; checks line of sight by raycasting
    private void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            
            Ray ray = new Ray(transform.position, direction); //creates ray at the position of the parent object
            RaycastHit raycastHit; //defines a raycast hit variable
            if(Physics.Raycast(ray, out raycastHit)) //detects if the ray has hit anything
            {
                if(raycastHit.collider.transform == player) //if the raycast hit a collider and that collider is the player, then set bool
                {
                    playerSpotted = true;
                }
            }
        }
    }
}
