using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex;

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        //When you successfully join a room
        Debug.Log("Joined room");
        StartGame();
    }

    private void StartGame()
    {
        //load into multiplayer scene
        if(PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Starting Game");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }
    }

}
