using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnModel : MonoBehaviour
{
    private Animator animator;
    GameObject bone;
    // Start is called before the first frame update
    void Start()
    {
        bone = transform.Find("bone").gameObject;
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    public void updateHead(Vector3 target)
    {
        Debug.Log("turned");

        bone.transform.position = transform.Find("neck").position;
        bone.transform.LookAt(target);
        animator.SetBoneLocalRotation(HumanBodyBones.Neck, bone.transform.rotation);
    }
}
