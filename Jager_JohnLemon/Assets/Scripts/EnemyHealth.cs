using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //variables
    public int health = 1;
    public PlayerMovement playerMovement;

    //function that when called removes health
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
            playerMovement.ReduceCounterText();
        }
    }

}
