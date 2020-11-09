using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    // Start is called before the first frame update

    Animator unityChanAnimator;

    float speed = 0.0f;
    private float acceleration = 0.006f;

    GameObject unityChan;
    Transform head;
    public GameObject crown;

    void Start()
    {
        unityChanAnimator = GetComponent<Animator>();
        unityChan = GameObject.Find("unitychan");
        Transform[] allBones = unityChan.GetComponentsInChildren<Transform>();

        foreach (Transform bone in allBones)
            if (bone.name == "Character1_Head")
            {
                head = bone;
            }

        print(head);

        GameObject newCrown = (GameObject)Instantiate(crown, head);
    }

    // Update is called once per frame
    void Update()
    {
        unityChanAnimator.SetFloat("Speed", speed);

        speed = Mathf.Clamp(speed, 0, 1);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += acceleration;
        }

        else
        {
            unityChanAnimator.SetBool("isRunning", false);
            unityChanAnimator.SetBool("isIdle", true);

            speed -= acceleration;
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            unityChanAnimator.SetBool("isRunningBackwards", true);
            unityChanAnimator.SetBool("isIdle", false);
            unityChanAnimator.SetBool("isRunning", false);
        }

        else
        {
            unityChanAnimator.SetBool("isRunningBackwards", false);
            unityChanAnimator.SetBool("isIdle", true);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            unityChanAnimator.SetBool("isWaving", true);
        }

        else
        {
            unityChanAnimator.SetBool("isWaving", false);
        }
    }
}
