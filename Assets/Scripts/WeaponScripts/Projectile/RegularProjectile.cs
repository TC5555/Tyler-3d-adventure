using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularProjectile : Projectile
{
    void OnTriggerEnter(Collider other)
    {
        PlayerScript p = other.GetComponent<PlayerScript>();
        if (p != null)
        {
            p.ChangeHealth(damageAmount);
        }
        else
        {
            EnemyScript e = other.GetComponent<EnemyScript>();
            if (e != null)
            {
                e.ChangeHealth(damageAmount);
            }
        }

        Destroy(gameObject);
    }
}
