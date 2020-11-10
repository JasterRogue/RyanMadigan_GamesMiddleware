using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{
    void Start()
    {
        CreatePlayer(); 
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "unitychan"), Vector3.zero, Quaternion.identity);
    }
}
