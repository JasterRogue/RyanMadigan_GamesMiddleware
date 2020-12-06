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
        Rigidbody ballRB = GetComponent<Rigidbody>();
        ballRB.velocity =  ballRB.velocity * 40;
        Destroy(this, 10f);
    }

}
