using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularExplosiveProjectile : ExplosiveProjectile
{
    

    public void OnCollisionEnter(Collision other)
    {

        PlayerScript p = other.collider.GetComponent<PlayerScript>();
        if (p != null)
        {
            p.ChangeHealth(contactDamage);

        }
        else
        {
            EnemyScript e = other.collider.GetComponent<EnemyScript>();
            if (e != null)
            {
                e.ChangeHealth(contactDamage);
            }
        }

        StartCoroutine(Explode());
    }
}
