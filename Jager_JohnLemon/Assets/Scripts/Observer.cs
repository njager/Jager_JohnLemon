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
            
            //creates + defines ray, sends out ray that detects and returns hit
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    playerSpotted = true;
                    print("Spotted!");
                }
                else
                {
                    print("hit this object: " + raycastHit.collider.gameObject.name);
                }
            }
        }
    }
}
