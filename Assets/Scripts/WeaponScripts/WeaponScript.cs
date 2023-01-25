using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponScript : MonoBehaviour
{
    Vector3 direction;
    bool canShoot;
    float timer;
    public float shootTime;
    public int shootMulti;

    public float verticleSpread;
    public float horizontalSpread;

    public float fire;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {

        if (!canShoot)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                canShoot = true;
            }
        }
        else if (fire > .1)
        {
            canShoot = false;
            timer = shootTime;

            Launch();

        }
    }

    public abstract void Launch();
}
