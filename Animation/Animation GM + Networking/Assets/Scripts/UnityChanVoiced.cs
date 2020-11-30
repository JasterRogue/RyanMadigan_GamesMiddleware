using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class UnityChanVoiced : MonoBehaviour
{
    // Speech Recogniser Code
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    Animator unityChanAnimatorVoice;

    float speedVoice = 0.0f;
    private float turningSpeedVoice = 100.0f;
    private float accelerationVoice = 0.006f;

    GameObject unityChan;
    Transform headVoice;
    public GameObject crownVoice;
    private bool voicedForward;
    private bool voicedBack;
    private bool voicedWave;

    void Start()
    {
        actions.Add("up", forward);
        actions.Add("back", back);
        actions.Add("left", left);
        actions.Add("right", right);
        actions.Add("wave", wave);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += recognisedSpeech;


        keywordRecognizer.Start();

        unityChanAnimatorVoice = GetComponent<Animator>();

        Transform[] allBones = gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform bone in allBones)
            if (bone.name == "Character1_Head")
            {
                headVoice = bone;
            }

        //print(head);

        GameObject newCrown = (GameObject)Instantiate(crownVoice, headVoice);
    }

    // Update is called once per frame
    void Update()
    {


            Camera.main.transform.position = transform.position + new Vector3(0, 1, -3);
            unityChanAnimatorVoice.SetFloat("Speed", speedVoice);

            speedVoice = Mathf.Clamp(speedVoice, 0, 1);

            if (Input.GetKey(KeyCode.UpArrow) || voicedForward)
            {
            speedVoice += accelerationVoice;
                moveForwardVoice(speedVoice);
            }

            else
            {
                unityChanAnimatorVoice.SetBool("isRunning", false);
                unityChanAnimatorVoice.SetBool("isIdle", true);

                speedVoice -= accelerationVoice;
            }


            if (Input.GetKey(KeyCode.DownArrow) || voicedBack)
            {
                unityChanAnimatorVoice.SetBool("isRunningBackwards", true);
                unityChanAnimatorVoice.SetBool("isIdle", false);
                unityChanAnimatorVoice.SetBool("isRunning", false);
                moveBackVoice(speedVoice);
            }

            else
            {
                unityChanAnimatorVoice.SetBool("isRunningBackwards", false);
                unityChanAnimatorVoice.SetBool("isIdle", true);
            }

            if (Input.GetKey(KeyCode.Z) || voicedWave)
            {
                unityChanAnimatorVoice.SetBool("isWaving", true);
            }

            else
            {
                unityChanAnimatorVoice.SetBool("isWaving", false);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                turnLeftVoice(turningSpeedVoice);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                turnRightVoice(turningSpeedVoice);
            }

    }//end of update()

    private void moveForwardVoice(float speed)
    {
        transform.position += (speed + 4) * transform.forward * Time.deltaTime;
    }

    private void moveBackVoice(float speed)
    {
        transform.position -= (speed + 4) * transform.forward * Time.deltaTime;
    }

    private void turnLeftVoice(float turningSpeed)
    {
        transform.Rotate(Vector3.down, turningSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the character right
    /// </summary>
    private void turnRightVoice(float turningSpeed)
    {
        transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
    }

    //Voice recognition methods
    private void forward()
    {
        voicedForward = true;

        Invoke("resetVoiceBools", 2f);
    }

    private void back()
    {
        voicedBack = true;

        Invoke("resetVoiceBools", 1.5f);
    }

    private void left()
    {
        int i = 0;

        while (i < 50)
        {
            turnLeftVoice(turningSpeedVoice);
            i++;
        }

    }

    private void right()
    {
        int i = 0;

        while (i < 50)
        {
            turnRightVoice(turningSpeedVoice);
            i++;
        }

    }

    private void wave()
    {
        voicedWave = true;

        Invoke("resetVoiceBools", 3f);


    }

    private void recognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void resetVoiceBools()
    {
        voicedForward = false;
        voicedBack = false;
        voicedWave = false;
    }





}
