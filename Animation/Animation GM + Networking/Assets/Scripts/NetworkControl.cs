using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkControl : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //Connect to master server
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server!");
    }
}
