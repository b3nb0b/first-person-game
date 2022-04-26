using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator anim;
    // Update is called once per frame
    void Start()
    {
        anim.Play("Idle");
    }

    void HitByRay()
    {
        anim.Play("Hit");
    }
}
