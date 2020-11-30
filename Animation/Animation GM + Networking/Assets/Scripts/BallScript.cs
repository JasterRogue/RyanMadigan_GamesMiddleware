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
       
    }

    public void shootBall(Vector3 pos, Vector3 direction)
    {
        GameObject ball = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ball"), pos, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(direction * 10);
    }

}
