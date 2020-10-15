using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject projectile;

    private void Start()
    {
        //Destroy(GameObject projectile, float 3.0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        /*if(!other.isTrigger)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                EnemyHealth eHealth = other.game
            }
                Destroy(gameObject);
        }
         */   
    }
}
