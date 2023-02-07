using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : WeaponScript
{

    public override void Launch()
    {
        for (int i = shootMulti; i > 0; i--)
        {

            Vector3 shootAngle = transform.forward;

            shootAngle += new Vector3(Random.Range(-horizontalSpread * Mathf.PI / 360f, horizontalSpread * Mathf.PI / 360f), Random.Range(-verticleSpread * Mathf.PI / 360f, verticleSpread * Mathf.PI / 360f),0);

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