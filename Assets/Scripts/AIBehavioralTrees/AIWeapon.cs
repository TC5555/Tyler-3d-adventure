using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class AIWeapon : MonoBehaviour
{
    public int shootMulti;

    public float verticleSpread;
    public float horizontalSpread;
    public Vector3 direction;
    public bool fire;
    public int ammoMaximum;
    protected int ammoCount;
    public float reloadTime;
    public float roundsPerMinute;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (fire)
            {
                if (ammoCount == 0)
                {
                    yield return new WaitForSeconds(reloadTime);
                    Reload();
                }
                else
                {
                    ammoCount--;
                    Debug.Log(ammoCount);
                    Launch();

                    yield return new WaitForSeconds(1 / (roundsPerMinute / 60));

                }
            }

            yield return new WaitForEndOfFrame();
        }

    }

    void Reload()
    {
        Debug.Log("EnemyReload");
        ammoCount = ammoMaximum;
    }


    public abstract void Launch();
}
