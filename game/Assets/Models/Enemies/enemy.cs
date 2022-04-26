using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthMan : MonoBehaviour
{
    public Animator anim;
    private bool rightStep;


    void Start()
    {
        anim.Play("Idle");
    }

    void HitByRay()
    {
        if (rightStep)
        {
            anim.Play("Hit 1");
        }
        else
        {
            anim.Play("Hit 2");
        }
    }


    public void LeftStep()
    {
        rightStep = false;
    }

    public void RightStep()
    {
        rightStep = true;
    }
}
