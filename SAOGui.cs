using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections;

public class SAOGui : UnityEngine.MonoBehaviour
{
    int whichselected = 0;

    public void OnGUI()
    {
        List<GameObject> testlist = new List<GameObject>();
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] titans = GameObject.FindGameObjectsWithTag("titan");
        for (int z = 0; z < titans.Length; z++)
        {
            testlist.Add(titans[z]);
        }
        for (int z = 0; z < gameObjectArray.Length; z++)
        {
            testlist.Add(gameObjectArray[z]);
        }
        if (FengGameManagerMKII.selected != null)
        {
            for (int i = 0; i < testlist.Count; i++)
            {
                Vector3? nullable = new Vector3?(GameObject.Find("MainCamera").GetComponent<Camera>().WorldToScreenPoint(testlist[i].transform.position));
                if (nullable.HasValue)
                {
                    Vector3 value = nullable.Value;
                    if (value.z > 0f)
                    {
                        Vector2 gUIPoint = GUIUtility.ScreenToGUIPoint(value);
                        gUIPoint.y = (float)Screen.height - (gUIPoint.y + 1f);/*
                    if (Convert.ToInt32(testlist[i].GetComponent<SmoothSyncMovement>().photonView.owner.customProperties[PhotonPlayerProperty.max_dmg]) > 5000 || Convert.ToInt32(testlist[i].GetComponent<SmoothSyncMovement>().photonView.owner.customProperties[PhotonPlayerProperty.statACL]) + Convert.ToInt32(testlist[i].GetComponent<SmoothSyncMovement>().photonView.owner.customProperties[PhotonPlayerProperty.statBLA]) + Convert.ToInt32(testlist[i].GetComponent<SmoothSyncMovement>().photonView.owner.customProperties[PhotonPlayerProperty.statGAS]) + Convert.ToInt32(testlist[i].GetComponent<SmoothSyncMovement>().photonView.owner.customProperties[PhotonPlayerProperty.statSPD]) > 600)
                    {
                        GUI.Label(new Rect(gUIPoint.x, gUIPoint.y, 200f, 20f), string.Concat("[", Convert.ToString(testlist[i].GetComponent<SmoothSyncMovement>().photonView.ownerId), "] <color=#FF0000>(MODDER)</color>"));
                    }
                    else
                    {
                        GUI.Label(new Rect(gUIPoint.x, gUIPoint.y, 200f, 20f), string.Concat("[", Convert.ToString(testlist[i].GetComponent<SmoothSyncMovement>().photonView.ownerId), "]"));
                    }*/
                        if (FengGameManagerMKII.selected != null && testlist[i] == FengGameManagerMKII.selected)
                        {
                            Rect t = new Rect(gUIPoint.x + 35 + 2f, gUIPoint.y + 7 - 60, 20, 20);
                            if (t.Contains(Event.current.mousePosition))
                            {
                                whichselected = 0;
                            }
                            t = new Rect(gUIPoint.x + 36 + 2f, gUIPoint.y + 23 - 60, 20, 20);
                            if (t.Contains(Event.current.mousePosition))
                            {
                                whichselected = 1;
                            }
                            t = new Rect(gUIPoint.x + 36 + 2f, gUIPoint.y + 43 - 60, 20, 20);
                            if (t.Contains(Event.current.mousePosition))
                            {
                                whichselected = 2;
                            }
                            t = new Rect(gUIPoint.x + 36 + 2f, gUIPoint.y + 61 - 60, 20, 20);
                            if (t.Contains(Event.current.mousePosition))
                            {
                                whichselected = 3;
                            }
                            t = new Rect(gUIPoint.x + 36 + 2f, gUIPoint.y + 82 - 60, 20, 20);
                            if (t.Contains(Event.current.mousePosition))
                            {

                            }
                            if (testlist[i].GetComponent<HERO>())
                            {
                                GUI.Label(new Rect(gUIPoint.x - 5, gUIPoint.y - 150 + Mathf.Cos(Convert.ToSingle(((2 * Mathf.PI * 2) / 1) * Time.time)) * 3, 30, 50f), FengGameManagerMKII.selectedtexture);
                                GUI.Label(new Rect(gUIPoint.x - 30, gUIPoint.y - 60, 80, 80), FengGameManagerMKII.selectedtexture2);
                                GUI.Label(new Rect(gUIPoint.x + 40, gUIPoint.y - 60, 100, 100), FengGameManagerMKII.selectedtexture3[whichselected]);
                            }
                            else
                            {
                                GUI.Label(new Rect(gUIPoint.x - 5, gUIPoint.y - 175 * testlist[i].transform.localScale.y / .85f + Mathf.Cos(Convert.ToSingle(((2 * Mathf.PI * 2) / 1) * Time.time)) * 3, 30, 50f), FengGameManagerMKII.selectedtexture);
                                GUI.Label(new Rect(gUIPoint.x - 80, gUIPoint.y - 85 * testlist[i].transform.localScale.y / .85f, 100 * testlist[i].transform.localScale.y / .85f, 100 * testlist[i].transform.localScale.y / .85f), FengGameManagerMKII.selectedtexture2);
                                GUI.Label(new Rect(gUIPoint.x + 80, gUIPoint.y - 100 * testlist[i].transform.localScale.y / .85f, 150 * testlist[i].transform.localScale.y / .85f, 100 * testlist[i].transform.localScale.y / .85f), FengGameManagerMKII.selectedtexture3[whichselected]);
                            }
                            Rect[] buttons = new Rect[3];
                        }
                    }
                }
            }
        }
    }
}