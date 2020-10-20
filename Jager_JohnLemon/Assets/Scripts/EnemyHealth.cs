using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //variables
    public int health = 3;
    public int enemyCount;

    //function that when called removes health
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
            enemyCount -= 1;
        }
    }

}
