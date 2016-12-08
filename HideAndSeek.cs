using ExitGames.Client.Photon;
using Photon;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UnityEngine;

public class HideAndSeek : Photon.MonoBehaviour
{
    public static bool justenabled = false;
    public static int step = 0;
    public static bool restart = false;
    public static bool restarted = false;
    public static bool startgame = false;
    public static int seekerid;
    public static float begincount = Time.time;
    GameObject charging = new GameObject();
    string askseekerid = "1";

    public void OnGUI()
    {
        if (startgame)
        {
            if (Time.time - begincount < 10)
            {
                GUILayout.BeginVertical();
                GUILayout.Space(Screen.height / 3);
                GUILayout.BeginHorizontal();
                GUILayout.Space(Screen.width / 3);
                GUILayout.Label("<size=" + Convert.ToString(Screen.width / 25) + ">Hide 'N Seek Starting In</size>", new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Space(Screen.width / 3);
                GUILayout.Label("<size=" + Convert.ToString(Screen.width / 15) + ">" + Convert.ToString(10 - (Time.time - begincount)) + "</size>", new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }
            else if (Time.time - begincount < 40)
            {
                if (PhotonNetwork.player.ID == seekerid)
                {
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FengGameManagerMKII.candytextures[0]);
                }
                GUILayout.BeginVertical();
                GUILayout.Space(Screen.height / 3.5f);
                GUILayout.BeginHorizontal();
                GUILayout.Space(Screen.width / 4);
                if (PhotonNetwork.player.ID != seekerid)
                {
                    GUILayout.Label("<size=" + Convert.ToString(Screen.width / 25) + ">Hide From Player With ID " + Convert.ToString(seekerid) + "</size>", new GUILayoutOption[0]);
                }
                else
                {
                    GUILayout.Label("<size=" + Convert.ToString(Screen.width / 25) + "><color=black>You Are The Seeker! Start In</color></size>", new GUILayoutOption[0]);
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Space(Screen.width / 2.3f);
                if (PhotonNetwork.player.ID != seekerid)
                {
                    GUILayout.Label("<size=" + Convert.ToString(Screen.width / 13) + ">" + Convert.ToString(Convert.ToInt32(40 - (Time.time - begincount))) + "</size>", new GUILayoutOption[0]);
                }
                else
                {
                    GUILayout.Label("<size=" + Convert.ToString(Screen.width / 13) + "><color=black>" + Convert.ToString(Convert.ToInt32(40 - (Time.time - begincount))) + "</color></size>", new GUILayoutOption[0]);
                }
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
                if (Time.time - begincount > 39.9f)
                {
                    if (PhotonNetwork.player.ID == seekerid)
                    {
                        charging = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        charging.transform.parent = IN_GAME_MAIN_CAMERA.main_object.transform;
                        charging.transform.position = IN_GAME_MAIN_CAMERA.main_object.transform.position + new Vector3(0f, .7f, 0f);
                        charging.collider.enabled = false;
                        charging.transform.localScale = new Vector3(10, 10, 10);
                        charging.renderer.material.shader = Shader.Find("Transparent/VertexLit");
                        charging.renderer.material.mainTexture = FengGameManagerMKII.candytextures[20];
                    }
                }
            }
        }
        if (justenabled)
        {
            GUILayout.BeginVertical();
            GUILayout.Space(Screen.height / 3);
            GUILayout.BeginHorizontal();
            GUILayout.Space(Screen.width / 3);
            if (step == 1)
            {
                GUILayout.Label("<size=" + Convert.ToString(Screen.width / 25) + ">Restart The Game?</size>", new GUILayoutOption[0]);
            }/*
            if (step == 0)
            {
                GUILayout.Label("<size=" + Convert.ToString(Screen.width / 25) + ">Enter Seeker's ID</size>", new GUILayoutOption[0]);
            }*/
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Space(Screen.width / 3);
            if (step == 1)
            {
                if (GUILayout.Button("<size=" + Convert.ToString(Screen.width / 25) + ">Yes</size>", new GUILayoutOption[0]))
                {
                    //step++;
                    justenabled = false;
                    restart = true;
                    InRoomChat.MultiplayerManager.GetComponent<FengGameManagerMKII>().restartGame(false);
                }
                if (GUILayout.Button("<size=" + Convert.ToString(Screen.width / 25) + ">No</size>", new GUILayoutOption[0]))
                {
                    //step++;
                    justenabled = false;
                    restart = false;
                    GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().photonView.RPC("StartHide", PhotonTargets.All, new object[] { seekerid });
                }
            }/*
            else if (step == 0)
            {
                askseekerid = GUILayout.TextArea(askseekerid, new GUILayoutOption[0]);
                if (GUILayout.Button("<size=" + Convert.ToString(Screen.width / 25) + ">Enter</size>", new GUILayoutOption[0]))
                {
                    bool can = int.TryParse(askseekerid, out seekerid);
                    if (can)
                    {
                        if (FengGameManagerMKII.cmusers.ContainsKey(seekerid))
                        {
                            if (FengGameManagerMKII.cmusers[seekerid] != null)
                            {
                                if (PhotonNetwork.isMasterClient)
                                {
                                    step++;
                                }
                                else
                                {
                                    justenabled = false;
                                    restart = false;
                                    GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().photonView.RPC("StartHide", PhotonTargets.All, new object[] { seekerid });
                                }
                            }
                            else
                            {
                                askseekerid = "CandyMod user must be spawned";
                            }
                        }
                        else
                        {
                            askseekerid = "CandyMod user not found";
                        }
                    }
                    else
                    {
                        askseekerid = "ID must be an integer, ex. 135";
                    }
                }
            }*/
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
    }

    public void Update()
    {
        if (restart)
        {
            if (restarted)
            {
                restarted = false;
                restart = false;
                GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().photonView.RPC("StartHide", PhotonTargets.All, new object[] { seekerid });
            }
        }
        if (startgame)
        {
            if (PhotonNetwork.player.ID == seekerid)
            {
                if (Time.time - begincount > 10)
                {
                    charging.transform.position = IN_GAME_MAIN_CAMERA.main_object.transform.position + new Vector3(0f, .7f, 0f);
                    charging.transform.Rotate(Vector3.up * 5);
                }
            }
        }
    }
}