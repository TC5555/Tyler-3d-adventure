using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnWeapon : AIWeapon
{
    public GameObject projectilePrefab;
    // Update is called once per frame
    public override void Launch()
    {
        for (int i = shootMulti; i > 0; i--)
        {

            Vector3 shootAngle = transform.forward;

            shootAngle += new Vector3(Random.Range(-horizontalSpread * Mathf.PI / 360f, horizontalSpread * Mathf.PI / 360f), Random.Range(-verticleSpread * Mathf.PI / 360f, verticleSpread * Mathf.PI / 360f), 0);


            GameObject projectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(shootAngle));
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch(shootAngle, transform.position);

        }
    }
}
