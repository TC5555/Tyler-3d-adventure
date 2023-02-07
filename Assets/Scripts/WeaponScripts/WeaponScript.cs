using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponScript : MonoBehaviour
{
    public int shootMulti;

    public float verticleSpread;
    public float horizontalSpread;

    public float fire;
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
            if (!Mathf.Approximately(Input.GetAxis("Reload"), 0.0f) && ammoCount != ammoMaximum)
            {
                yield return new WaitForSeconds(reloadTime);
                Reload();
            }
            else if (!Mathf.Approximately(fire, 0.0f))
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

                    yield return new WaitForSeconds(1/(roundsPerMinute / 60));

                }
            }

            yield return new WaitForEndOfFrame();
        }

    }

    void Reload()
    {
        Debug.Log("Reload");
        ammoCount = ammoMaximum;
    }


    public abstract void Launch();
}
