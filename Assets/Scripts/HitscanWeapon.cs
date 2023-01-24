using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : WeaponScript
{




    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Launch()
    {
        for (int i = shootMulti; i > 0; i--)
        {

            Vector3 shootAngle = transform.forward;

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 80f, LayerMask.GetMask("Enemy"));

            if (hit.collider)
            {
                Debug.Log("hit");
                hit.collider.GetComponent<EnemyScript>().ChangeHealth(-1);
            }

        }
    }
}