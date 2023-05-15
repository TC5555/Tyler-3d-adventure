using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PawnModel : MonoBehaviour
{
    public Vector3 target;
    private Animator animator;
    GameObject bone;
    // Start is called before the first frame update
    void Start()
    {
        bone = transform.Find("bone").gameObject;
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void OnAnimatorIK()
    {
        if (target != null)
        {
            /* Debug.Log("turned");
             Debug.Log(animator.GetBoneTransform(HumanBodyBones.Neck));
             bone.transform.position = animator.GetBoneTransform(HumanBodyBones.Neck).position;
             bone.transform.LookAt(target);
             animator.SetBoneLocalRotation(HumanBodyBones.Neck, bone.transform.rotation);*/
            animator.SetLookAtWeight(1);
            animator.SetLookAtPosition(target);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
            animator.SetIKPosition(AvatarIKGoal.RightHand, new Vector3(target.x,target.y + 1.1f,target.z));
           
        }
    }
}
