using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected Rigidbody rigidbody;
    public float damageAmount;   
    public float force;  
    public int distance;
    Vector2 origin;


    void Awake()
    {

        rigidbody = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction, Vector3 origin)
    {
        this.origin = origin;
   
        rigidbody.AddForce(direction * force);
    }

    void Update()
    {

        if (transform.position.x > origin.x + distance || transform.position.x < origin.x - distance || transform.position.y > origin.y + distance || transform.position.y < origin.y - distance)
        {

         //   Destroy(gameObject);
        }
    }
}

