using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class LocalBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        spawnLocalBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    void spawnLocalBall()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ball"), new Vector3(0,2,0), Quaternion.identity);
    }
}
