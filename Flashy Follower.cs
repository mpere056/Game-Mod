using ExitGames.Client.Photon;
using Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class Flashy_Follower : Photon.MonoBehaviour
{
    GameObject main_object;
    float updateevery = Time.time;

    public void GetObject(GameObject a)
    {
        main_object = a;
    }

    public void Update()
    {
        if (Time.time - updateevery > .02f)
        {
            RaycastHit hit;

            if (Physics.Raycast(main_object.transform.position + new Vector3(0f, .05f, 0f), -Vector3.up, out hit))
                base.transform.position = new Vector3(main_object.transform.position.x, hit.point.y, main_object.transform.position.z);
            else
                base.transform.position = main_object.transform.position + new Vector3(0f, .05f, 0f);
            updateevery = Time.time;
            var quatHit = Quaternion.FromToRotation(Vector3.up, hit.normal);
            var quatForward = Quaternion.FromToRotation(Vector3.forward, main_object.transform.forward);
            var quatC = quatHit * quatForward;
            transform.rotation = quatC;
        }
    }
}