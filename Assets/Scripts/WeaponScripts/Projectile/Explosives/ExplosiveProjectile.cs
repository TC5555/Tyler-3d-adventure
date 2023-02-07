using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExplosiveProjectile : Projectile
{
    public float contactDamage;
    public float radius;
    public float Knockback;
    public float vertKnockback;
    public ParticleSystem ExplosionEffects;
    public float falloff;
    protected bool exploded = false;


    private void Update()
    {
        if (!Mathf.Approximately(Input.GetAxis("Aim"), 0.0f))
        {
            if (!exploded && GameObject.FindGameObjectsWithTag("PlayerProjectile").Length == 1) 
            {
                StartCoroutine(Explode());
            }
        }
    }


    protected IEnumerator Explode()
    {
        exploded = true;
        Collider[] explosion = Physics.OverlapSphere(rigidbody.position, radius);

        foreach (Collider hit in explosion)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.gameObject.GetComponent<EnemyScript>().ChangeHealth(damageAmount * (falloff + (1f-falloff) * (radius - (hit.ClosestPoint(rigidbody.position) - rigidbody.position).magnitude) / radius));
                //blast damage calculation is blastdamage - MaxFallout * (radius - distance)/radius.
                //4 meters away from a 5 meter explosion is 4/5ths damage. 
                Debug.Log((falloff + (1f - falloff) * (radius - (hit.ClosestPoint(rigidbody.position) - rigidbody.position).magnitude) / radius));

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
