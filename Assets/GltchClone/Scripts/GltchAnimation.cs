using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GltchAnimation : MonoBehaviour
{

    Animator gltchAnim;

    void Start()
    {
        gltchAnim = GetComponent<Animator>();
    }


    public void BlinkStart()
    {
        gltchAnim.SetBool("isWalking", true);
    }

    public void BlinkStop()
    {
        gltchAnim.SetBool("isWalking", false);
    }
}
