using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    PhotonView pv;
    

    void Start()
    {
        pv = PhotonView.Get(this);

       if(PhotonNetwork.IsMasterClient)
        {
            spawnBall(); 
        }
       
    }

    [PunRPC]
    void spawnBall()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ball"), new Vector3(5, 5, 5), Quaternion.identity);
    }

}
