using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightControl : MonoBehaviour
{
    Animator knightAnimator;

    // Start is called before the first frame update

    float speed = 0.0f;
    private float acceleration = 0.006f;

    void Start()
    {
        knightAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        knightAnimator.SetFloat("Blend", speed);

        //print("Speed: " + speed);
        speed = Mathf.Clamp(speed, 0, 1);

        if (Input.GetKey(KeyCode.W))
        {
            speed += acceleration;
        }

        else
        {
            knightAnimator.SetBool("isRunning", false);
            knightAnimator.SetBool("isIdle", true);

            speed -= acceleration;
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
        }

        if(Input.GetKey(KeyCode.Space))
        {
            knightAnimator.SetBool("isWaving", true);
        }

        else
        {
            knightAnimator.SetBool("isWaving", false);
        }


    }
}
