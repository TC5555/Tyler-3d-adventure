using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rigidbody;
    public int damageAmount;   
    public float force;  
    public int distance;
    bool active = false;
    Vector2 origin;


    void Awake()
    {

        rigidbody = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction, Vector3 origin)
    {
        this.origin = origin;
        active = true;
   
        rigidbody.AddForce(direction * force);
    }

    void Update()
    {

        if (!active)
        {
            return;
        }

        if (transform.position.x > origin.x + distance || transform.position.x < origin.x - distance || transform.position.y > origin.y + distance || transform.position.y < origin.y - distance)
        {

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collision2D other)
    {

        if (!active)
        {
            return;
        }
        PlayerScript p = other.collider.GetComponent<PlayerScript>();
        if (p != null)
        {
            p.ChangeHealth(damageAmount);

            Destroy(gameObject);
        }

        EnemyScript e = other.collider.GetComponent<EnemyScript>();
        if (e != null)
        {
            e.ChangeHealth(damageAmount);

            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}

