using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections;

public class PauseGUI : UnityEngine.MonoBehaviour
{
    public Rect GUIRect = new Rect((Screen.width * (1 - .77f)) / 2, (Screen.height * (1 - .8f)) / 2, Screen.width / 1.3f, Screen.height / 1.3f);
    public static bool toggle;
    public static int Step;
    public static string mainguiwww = "http://i.imgur.com/roL88CV.png";
    public static Texture2D mainguitex;
    public static bool maincolor;
    public static float mainR = 1f;
    public static float mainG = 1f;
    public static float mainB = 1f;
    public static string mainguiwww2 = "";
    public static bool mainrainbow;
    public static int mainstep;
    public static float mainspeed = 0.01f;
    Vector2 scrollview;
    Vector2 scrollview2;
    public static Vector2 vSliderValue;
    public static int loadnumber;

    private IEnumerator loadskins()
    {
        WWW mainload = new WWW(mainguiwww);
        yield return mainload;
        mainguitex = mainload.texture;
        PlayerPrefs.SetString("PauseSkins", mainguiwww);
    }


    public void MainBody(int id)
    {
        GUI.backgroundColor = new Color(1f, 1f, 1f, 255f);
        if (maincolor || mainrainbow)
        {
            GUI.backgroundColor = new Color(mainR, mainG, mainB, 255f);
        }
        GUILayout.BeginVertical();
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Skins", new GUILayoutOption[0]))
        {
            Step = 0;
        }
        else if (GUILayout.Button("KeyBinds", new GUILayoutOption[0]))
        {
            Step = 1;
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.BeginHorizontal();
        if (Step == 0)
        {
            Rect rec = new Rect(Screen.width / 60, Screen.height / 25, Screen.width / 15, Screen.height / 20);
                //scrollview = GUI.BeginScrollView(new Rect(Screen.width / 100, Screen.width / 150, Screen.width / 3, Screen.height / 1.1f), scrollview, new Rect(0, 0, Screen.width / 2, Screen.height / 2));
                //GUILayout.BeginVertical();
                GUIStyle a = new GUIStyle();
                a.fixedWidth = Screen.width / 20;
                a.stretchWidth = false;
                a.clipping = TextClipping.Clip;
                a.normal.background = FengGameManagerMKII.candytextures[7];
                a.normal.background = Texture2D.whiteTexture;
                string[] parts = new string[] { "Right Blade", "Left Blade", "Cape", "Eye", "Face", "Skin", "Glass", "Hair", "Costume" };
                for (int z = 0; z < 9; z++)
                {
                    rec = new Rect(Screen.width / 30, rec.yMax + Screen.height / 60, Screen.width / 17, Screen.height / 23);
                    GUI.Label(rec, parts[z]);
                    rec = new Rect(rec.xMax, rec.yMin, rec.width, rec.height);
                    InRoomChat.linkss[z] = GUI.TextField(rec, InRoomChat.linkss[z] + " ", a).Replace(" ", "");
                    rec = new Rect(rec.xMax, rec.yMin, rec.width, rec.height);
                    InRoomChat.linksss[z] = GUI.TextField(rec, InRoomChat.linksss[z] + " ", a).Replace(" ", "");
                    rec = new Rect(rec.xMax, rec.yMin, rec.width, rec.height);
                    InRoomChat.linkssss[z] = GUI.TextField(rec, InRoomChat.linkssss[z] + " ", a).Replace(" ", "");
                    rec = new Rect(rec.xMax, rec.yMin, rec.width, rec.height);
                    InRoomChat.linksssss[z] = GUI.TextField(rec, InRoomChat.linksssss[z] + " ", a).Replace(" ", "");
                }
                rec = new Rect(Screen.width / 30, rec.yMax + Screen.height / 60, Screen.width / 25, Screen.height / 20);
                string tosave = "";
                string tosave2 = "";
                string tosave3 = "";
                string tosave4 = "";
                if (GUI.Button(rec, "Load 1"))
                {
                    loadnumber = 0;
                    GameObject.Find("Chatroom").GetComponent<InRoomChat>().SetLinksLoad(1);
                }
                rec = new Rect(rec.xMax + Screen.width / 40, rec.yMin, Screen.width / 25, rec.height);
                if (GUI.Button(rec, "Load 2"))
                {
                    loadnumber = 1;
                    GameObject.Find("Chatroom").GetComponent<InRoomChat>().SetLinksLoad(2);
                }
                rec = new Rect(rec.xMax + Screen.width / 40, rec.yMin, Screen.width / 25, rec.height);
                if (GUI.Button(rec, "Load 3"))
                {
                    loadnumber = 2;
                    GameObject.Find("Chatroom").GetComponent<InRoomChat>().SetLinksLoad(3);
                }
                rec = new Rect(rec.xMax + Screen.width / 40, rec.yMin, Screen.width / 15, rec.height);
                if (GUI.Button(rec, "Save"))
                {
                    tosave = "";
                    if (loadnumber == 0)
                    {
                        for (int z = 0; z < 9; z++)
                        {
                            tosave = tosave + InRoomChat.linkss[z] + "~";
                            tosave2 = tosave2 + InRoomChat.linksss[z] + "~";
                            tosave3 = tosave3 + InRoomChat.linkssss[z] + "~";
                            tosave4 = tosave4 + InRoomChat.linksssss[z] + "~";
                        }
                        PlayerPrefs.SetString("skinsframe1", tosave);
                        PlayerPrefs.SetString("skinsframe2", tosave2);
                        PlayerPrefs.SetString("skinsframe3", tosave3);
                        PlayerPrefs.SetString("skinsframe4", tosave4);
                    }
                    else if (loadnumber == 1)
                    {
                        for (int z = 0; z < 9; z++)
                        {
                            tosave = tosave + InRoomChat.linkss[z] + "~";
                            tosave2 = tosave2 + InRoomChat.linksss[z] + "~";
                            tosave3 = tosave3 + InRoomChat.linkssss[z] + "~";
                            tosave4 = tosave4 + InRoomChat.linksssss[z] + "~";
                        }
                        PlayerPrefs.SetString("2skinsframe1", tosave);
                        PlayerPrefs.SetString("2skinsframe2", tosave2);
                        PlayerPrefs.SetString("2skinsframe3", tosave3);
                        PlayerPrefs.SetString("2skinsframe4", tosave4);
                    }
                    else if (loadnumber == 2)
                    {
                        for (int z = 0; z < 9; z++)
                        {
                            tosave = tosave + InRoomChat.linkss[z] + "~";
                            tosave2 = tosave2 + InRoomChat.linksss[z] + "~";
                            tosave3 = tosave3 + InRoomChat.linkssss[z] + "~";
                            tosave4 = tosave4 + InRoomChat.linksssss[z] + "~";
                        }
                        PlayerPrefs.SetString("3skinsframe1", tosave);
                        PlayerPrefs.SetString("3skinsframe2", tosave2);
                        PlayerPrefs.SetString("3skinsframe3", tosave3);
                        PlayerPrefs.SetString("3skinsframe4", tosave4);
                    }
                    InRoomChat.addLINE("<color=yellow>-saved</color>");
                }
        }
        else if (Step == 1)
        {
            if (GUILayout.Button("<size=" + Screen.width / 40 + ">Sorry, Stay Tuned For More CandyMod Updates :D</size>", new GUILayoutOption[0]))
            {
                Step = 0;
            }
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Continue", new GUILayoutOption[0]))
        {
            IN_GAME_MAIN_CAMERA.isPausing = false;
        }
        if (GUILayout.Button("Quit", new GUILayoutOption[0]))
        {
            PhotonNetwork.Disconnect();
            Screen.lockCursor = false;
            Screen.showCursor = true;
            IN_GAME_MAIN_CAMERA.gametype = GAMETYPE.STOP;
            FengGameManagerMKII.gameStart = false;
            GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().menuOn = false;
            FengGameManagerMKII.showconfig = true;
            UnityEngine.Object.Destroy(GameObject.Find("MultiplayerManager"));
            FengGameManagerMKII.showconfig = true;
            FengGameManagerMKII.checkedcandy = true;
            FengGameManagerMKII.candied = true;
            FengGameManagerMKII.menu = true;
            FengGameManagerMKII.gotcandytextures = 19;
            Application.LoadLevel("menu");
        }
        GUILayout.EndHorizontal();
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }

    public void CandyModUsersOnly(string rpc, string targets, object[] obj)
    {
        if (targets == "All")
        {
            foreach (int id in FengGameManagerMKII.modUsers)
            {
                FengGameManagerMKII.MKII.photonView.RPC(rpc, PhotonPlayer.Find(id), obj);
            }
        }
        if (targets == "Others")
        {
            foreach (int id in FengGameManagerMKII.modUsers)
            {
                if (id != PhotonNetwork.player.ID)
                {
                    FengGameManagerMKII.MKII.photonView.RPC(rpc, PhotonPlayer.Find(id), obj);
                }
            }
        }
    }

    public void Start()
    {
        if (PlayerPrefs.HasKey("PauseSkins"))
        {
            string skins = PlayerPrefs.GetString("PauseSkins");
            mainguiwww = skins;
        }
    }

    public void OnGUI()
    {
        if (IN_GAME_MAIN_CAMERA.isPausing)
        {
            GUI.backgroundColor = new Color(1f, 1f, 1f, 255f);
            if (maincolor || mainrainbow)
            {
                GUI.backgroundColor = new Color(mainR, mainG, mainB, 255f);
            }
            GUIRect = GUI.Window(69, GUIRect, this.MainBody, "" + DateTime.Now);
        }
    }
}