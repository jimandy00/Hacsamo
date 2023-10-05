using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using System.Linq;
using System.IO.IsolatedStorage;

public class BillBoard : MonoBehaviourPun
{
    //Camera[] cameras = Camera.allCameras;
    //Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        //print(Camera.allCameras.Length);
        //for (int i = 0; i < cameras.Length; i++)
        //{
        //    if (cameras[i].CompareTag("PersoanlCamera"))
        //    {
        //        cam = cameras[i];
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //transform.forward = Camera.main.transform.forward;
        //transform.forward = cam.transform.forward;
        transform.forward = Camera.allCameras[1].transform.forward;

    }
}
