using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class UnityChanController : MonoBehaviour
{
    // Speech Recogniser Code
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    Animator unityChanAnimator;

    float speed = 0.0f;
    private float turningSpeed = 100.0f;
    private float acceleration = 0.006f;

    GameObject unityChan;
    Transform head;
    public GameObject crown;
    PhotonView pv;

    void Start()
    {
        //Speech Recognition code
        actions.Add("forward", forward);
        actions.Add("back", back);
        actions.Add("left", left);
        actions.Add("right", right);
        actions.Add("wave", wave);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += recognisedSpeech;
        keywordRecognizer.Start();

        pv = PhotonView.Get(this);
        unityChanAnimator = GetComponent<Animator>();
        
        Transform[] allBones = gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform bone in allBones)
            if (bone.name == "Character1_Head")
            {
                head = bone;
            }

        //print(head);

        GameObject newCrown = (GameObject)Instantiate(crown, head);
    }

    // Update is called once per frame
    void Update()
    {
        
         if (pv.IsMine)
            {

                Camera.main.transform.position = transform.position + new Vector3(0, 1, -3);
                unityChanAnimator.SetFloat("Speed", speed);

                speed = Mathf.Clamp(speed, 0, 1);

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    speed += acceleration;
                    moveForward(speed);
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
                    moveBack(speed);
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

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    turnLeft(turningSpeed);
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    turnRight(turningSpeed);
                }

            }
        
    }//end of update()

    private void moveForward(float speed)
    {
        transform.position += (speed + 4) * transform.forward * Time.deltaTime;
    }

    private void moveBack(float speed)
    {
        transform.position -= (speed + 4) * transform.forward * Time.deltaTime;
    }

    private void turnLeft(float turningSpeed)
    {
        transform.Rotate(Vector3.down, turningSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the character right
    /// </summary>
    private void turnRight(float turningSpeed)
    {
        transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
    }

    //Voice recognition methods
    private void forward()
    {
        moveForward(speed);
    }

    private void back()
    {
        moveBack(speed);
    }

    private void left()
    {
        int i = 0;

        while(i < 6)
        {
            turnLeft(turningSpeed);
        }
        
    }

    private void right()
    {
        turnRight(turningSpeed);
    }

    private void wave()
    {
        unityChanAnimator.SetBool("isWaving", true);
    }

    private void recognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
}
