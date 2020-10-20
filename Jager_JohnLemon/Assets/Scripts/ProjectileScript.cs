using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject projectile;


    private void Start()
    {
        Destroy(gameObject, 5f);
        
    }
    //detects bullet collision and deals damage to enemies
    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                EnemyHealth ehealth = other.gameObject.GetComponent<EnemyHealth>();

                if (ehealth != null)
                {
                    ehealth.TakeDamage(1);

                }
                Destroy(gameObject);
            }
            
        }
        
    }
}
