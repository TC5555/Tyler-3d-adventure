using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    public float contactDamage;
    public float radius;
    public float Knockback;
    public float vertKnockback;
    public ParticleSystem ExplosionEffects;

    IEnumerator OnCollisionEnter(Collision other)
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

        Collider[] explosion = Physics.OverlapSphere(rigidbody.position, radius);

        foreach (Collider hit in explosion)
        {
            if (hit.CompareTag("Enemy"))
            {
                Debug.Log("boom");
                hit.gameObject.GetComponent<EnemyScript>().ChangeHealth(damageAmount);
                hit.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Knockback, rigidbody.position, radius, vertKnockback);
            }
            else if (hit.CompareTag("Player"))
            {
                hit.gameObject.GetComponent<PlayerScript>().ChangeHealth(damageAmount * .6f);
                hit.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Knockback * .6f, transform.position, radius, vertKnockback * .6f);

            }
        }

        rigidbody.Sleep();

        gameObject.GetComponent<Renderer>().enabled = false;
        ExplosionEffects.Play();


        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}