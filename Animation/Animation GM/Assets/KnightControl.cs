using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightControl : MonoBehaviour
{
    Animator knightAnimator;

    // Start is called before the first frame update
    void Start()
    {
        knightAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            knightAnimator.SetBool("isRunning", true);
            knightAnimator.SetBool("isIdle", false);
            knightAnimator.SetBool("isRunningBackwards", false);
        }

        else
        {
            knightAnimator.SetBool("isRunning", false);
            knightAnimator.SetBool("isIdle", true);
            knightAnimator.SetBool("isJumping", false);
        }


        if(Input.GetKey(KeyCode.S))
        {
            knightAnimator.SetBool("isRunningBackwards", true);
            knightAnimator.SetBool("isIdle", false);
            knightAnimator.SetBool("isRunning", false);
        }

        else
        {
            knightAnimator.SetBool("isRunningBackwards", false);
            knightAnimator.SetBool("isIdle", true);
            knightAnimator.SetBool("isJumping", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            knightAnimator.SetBool("isJumping", true);

        }
    }
}
