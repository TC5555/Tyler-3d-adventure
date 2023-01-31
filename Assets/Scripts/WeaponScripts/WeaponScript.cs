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
        gameObject.SetActive(false);
    }

    IEnumerator Update()
    {

        if (!Mathf.Approximately(Input.GetAxis("reload"), 0.0f))
        {
            Reload();
        }
        else if (Mathf.Approximately(fire, 0.0f))
        {
            if(ammoCount == 0)
            {
                Reload();
            }
            else { 
            ammoCount--;
                Debug.Log(ammoCount);
                Launch();

            yield return new WaitForSeconds(roundsPerMinute/60);
                
            }
            }

    }

    IEnumerator Reload()
    {
        Debug.Log("Reload");
        ammoCount = ammoMaximum;
        yield return new WaitForSeconds(reloadTime);
    }


    public abstract void Launch();
}
