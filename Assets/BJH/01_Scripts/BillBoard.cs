using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using System.Linq;
using System.IO.IsolatedStorage;

public class BillBoard : MonoBehaviourPun
{
    public Camera cam;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.forward = cam.transform.forward;

    }
}
