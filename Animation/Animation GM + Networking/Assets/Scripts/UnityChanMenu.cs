using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnityChanMenu : MonoBehaviour
{
    // Start is called before the first frame update

    Animator unityChanMenuAnimator;

    float speedMenu = 0.0f;
    private float accelerationMenu = 0.006f;

    GameObject unityChanMenu;
    Transform headMenu;
    public GameObject crownMenu;

    void Start()
    {
        unityChanMenuAnimator = GetComponent<Animator>();
        unityChanMenu = GameObject.Find("unitychan");
        Transform[] allBones = unityChanMenu.GetComponentsInChildren<Transform>();

        foreach (Transform bone in allBones)
            if (bone.name == "Character1_Head")
            {
                headMenu = bone;
            }

        print(headMenu);

        GameObject newCrown = (GameObject)Instantiate(crownMenu, headMenu);
    }

    // Update is called once per frame
    void Update()
    {


      
            unityChanMenuAnimator.SetFloat("Speed", speedMenu);

            speedMenu = Mathf.Clamp(speedMenu, 0, 1);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                speedMenu += accelerationMenu;
            }

            else
            {
                unityChanMenuAnimator.SetBool("isRunning", false);
                unityChanMenuAnimator.SetBool("isIdle", true);

                speedMenu -= accelerationMenu;
            }


            if (Input.GetKey(KeyCode.DownArrow))
            {
            unityChanMenuAnimator.SetBool("isRunningBackwards", true);
            unityChanMenuAnimator.SetBool("isIdle", false);
            unityChanMenuAnimator.SetBool("isRunning", false);
            }

            else
            {
            unityChanMenuAnimator.SetBool("isRunningBackwards", false);
            unityChanMenuAnimator.SetBool("isIdle", true);
            }

            if (Input.GetKey(KeyCode.Z))
            {
            unityChanMenuAnimator.SetBool("isWaving", true);
            }

            else
            {
            unityChanMenuAnimator.SetBool("isWaving", false);
            }


    }//end of update()

    
}
