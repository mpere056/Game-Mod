using ExitGames.Client.Photon;
using Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine;
using Xft;

public class Flashing : Photon.MonoBehaviour
{
    public float timing = Time.time;
    public GameObject main_object = null;

    public void LateUpdate()
    {
        if (main_object != null)
            PhotonNetwork.Instantiate("redCross", main_object.transform.position, main_object.transform.rotation, 0);
        if (Time.time - timing > .5f)
        {
            if (main_object != null)
            {
                PhotonNetwork.Instantiate("redCross", main_object.transform.position, main_object.transform.rotation, 0);
                PhotonNetwork.Instantiate("redCross", main_object.transform.position, main_object.transform.rotation, 0);
                PhotonNetwork.Instantiate("redCross", main_object.transform.position, main_object.transform.rotation, 0);
                PhotonNetwork.Instantiate("redCross", main_object.transform.position, main_object.transform.rotation, 0);
                PhotonNetwork.Instantiate("redCross", main_object.transform.position, main_object.transform.rotation, 0);
            }
            timing = Time.time;
        }
    }

    public void Get(GameObject a)
    {
        main_object = a;
    }
}
