using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections;

public class MainGUI : UnityEngine.MonoBehaviour
{
    public Rect GUIRect = new Rect(0f, 0f, Convert.ToSingle(Screen.width / 2.75), Convert.ToSingle(Screen.height / 1.5));
    public Rect BanRect = new Rect(0f, 0f, Convert.ToSingle(Screen.width / 2.75), Convert.ToSingle(Screen.height / 1.5));
    public Rect PlayerRect = new Rect(0f, 0f, Convert.ToSingle(Screen.width / 2.75), Convert.ToSingle(Screen.height / 1.5));
    public Rect SkinRect = new Rect(0f, 0f, Convert.ToSingle(Screen.width / 2.75), Convert.ToSingle(Screen.height / 1.5));
    public static bool toggle;
    public static int Step;/*
    public static int roommax;
    public static bool roomvis = true;
    public static bool roomjoin = true;*/
    public static bool flight;
    public static bool banList;
    public static float kdr;
    public static float dr;
    public PhotonPlayer playerInfo;
    public static bool playerListGUI;
    public static string filter = "";
    public static Vector2 vSliderValue;
    public static bool skins;
    public static string playlist;
    public static bool Add;
    public static string AddSong = String.Empty;
    public static bool copy;
    public static bool remover;
    public static List<string> extraList = new List<string>();
    public static bool local;
    public static string mainguiwww = "http://i.imgur.com/roL88CV.png";
    public static string banguiwww = "http://i.imgur.com/roL88CV.png";
    public static string skinguiwww = "http://i.imgur.com/roL88CV.png";
    public static string playerwww = "http://i.imgur.com/roL88CV.png";
    public static Texture2D mainguitex;
    public static Texture2D banguitex;
    public static Texture2D skinguitex;
    public static Texture2D playertex;
    public static bool mainvis = true;
    public static bool banvis = true;
    public static bool skinvis = true;
    public static bool playervis = true;
    public static bool mainskin = true;
    public static bool banskin = true;
    public static bool skinskin = true;
    public static bool playerskin = true;
    public static bool maincolor;
    public static bool bancolor;
    public static bool skincolor;
    public static bool playercolor;
    public static float mainR = 1f;
    public static float mainG = 1f;
    public static float mainB = 1f;
    public static float banR = 1f;
    public static float banG = 1f;
    public static float banB = 1f;
    public static float skinR = 1f;
    public static float skinG = 1f;
    public static float skinB = 1f;
    public static float playerR = 1f;
    public static float playerG = 1f;
    public static float playerB = 1f;
    public static string mainguiwww2 = "";
    public static string banguiwww2 = "";
    public static string skinguiwww2 = "";
    public static string playerwww2 = "";
    public static bool mainrainbow;
    public static bool banrainbow;
    public static bool skinrainbow;
    public static bool playerrainbow;
    public static int mainstep;
    public static int banstep;
    public static int skinstep;
    public static int playerstep;
    public static float mainspeed = 0.01f;
    public static float banspeed = 0.01f;
    public static float skinspeed = 0.01f;
    public static float playerspeed = 0.01f;
    public static float timelimit = Time.time;
    public static float timeamt = 60f;
    public static float logtimeamt = 60f;
    public static bool timing;
    public static bool THistory;
    Vector2 scrollview;
    Vector2 scrollview2;
    public static int loadnumber;
    public static float kdr2;
    public static float dr2;
    public static float logdeaths;
    public static float logkills;
    public static float logdmg;
    public static float logmax;
    public static float tkills;
    public static float tdeaths;
    public static float tdmg;
    public static float tkills2;
    public static bool catchupbool;
    public static float tdeaths2;
    public static bool bounceme = true;
    public bool bounceserver = false;
    public bool sendbounce = false;
    public static bool shadow;
    public static bool prefShadows;
    public static float quality;
    public static float distance;
    public static int playcountkeeping = int.MaxValue * -1;

    private IEnumerator loadskins()
    {
        WWW mainload = new WWW(mainguiwww);
        yield return mainload;
        mainguitex = mainload.texture;
        WWW banload = new WWW(banguiwww);
        yield return banload;
        banguitex = banload.texture;
        WWW skinload = new WWW(skinguiwww);
        yield return skinload;
        skinguitex = skinload.texture;
        WWW playerload = new WWW(playerwww);
        yield return playerload;
        playertex = playerload.texture;
        PlayerPrefs.SetString("Skins", mainguiwww + " " + banguiwww + " " + skinguiwww + " " + playerwww);
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
        if (GUILayout.Button("Personal", new GUILayoutOption[0]))
        {
            Step = 0;
        }
        if (GUILayout.Button("Music", new GUILayoutOption[0]))
        {
            Step = 3;
            History = false;
        }
        if (GUILayout.Button("Player", new GUILayoutOption[0]))
        {
            Step = 1;
        }
        if (GUILayout.Button("Server", new GUILayoutOption[0]))
        {
            Step = 2;
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Settings", new GUILayoutOption[0]))
        {
            Step = 4;
        }/*
        if (GUILayout.Button("Skins", new GUILayoutOption[0]))
        {
            Step = 5;
        }*/
        if (GUILayout.Button("Timer", new GUILayoutOption[0]))
        {
            Step = 6;
        }
        if (GUILayout.Button("Hide-n-Seek", new GUILayoutOption[0]))
        {
            Step = 7;
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        if (PhotonNetwork.inRoom || IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
        {
            if (Step == 0)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Name: " + RCextensions.hexColor((string)PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]), new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", new GUILayoutOption[0]))
                {
                    ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable()
					            {
						            { PhotonPlayerProperty.name, PlayerPrefs.GetString("Name") }
					            };
                    ExitGames.Client.Photon.Hashtable hashtable1 = hashtable;
                    PhotonNetwork.player.SetCustomProperties(hashtable1);
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("Guild: " + RCextensions.hexColor((string)PhotonNetwork.player.customProperties[PhotonPlayerProperty.guildName]), new GUILayoutOption[0]);
                if (GUILayout.Button("Reset", new GUILayoutOption[0]))
                {
                    ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable()
					            {
						            { PhotonPlayerProperty.guildName, PlayerPrefs.GetString("GuildName") }
					            };
                    ExitGames.Client.Photon.Hashtable hashtable1 = hashtable;
                    PhotonNetwork.player.SetCustomProperties(hashtable1);
                }
                GUILayout.EndHorizontal();
                GUILayout.Label("ChatName: " + PlayerPrefs.GetString("ChatName"), new GUILayoutOption[0]);
                if (Convert.ToInt32(PhotonNetwork.player.customProperties[PhotonPlayerProperty.isTitan]) == 1 && !Convert.ToBoolean(PhotonNetwork.player.customProperties[PhotonPlayerProperty.dead]))
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("<b><color=#00FFFF>ACL: " + PhotonNetwork.player.customProperties[PhotonPlayerProperty.statACL] + "</color></b>");
                    GUILayout.Label("<b><color=#000000>BLA: " + PhotonNetwork.player.customProperties[PhotonPlayerProperty.statBLA] + "</color></b>");
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("<b><color=#FFFFFF>GAS: " + PhotonNetwork.player.customProperties[PhotonPlayerProperty.statGAS] + "</color></b>");
                    GUILayout.Label("<b><color=#FFFF00>SPD: " + PhotonNetwork.player.customProperties[PhotonPlayerProperty.statSPD] + "</color></b>");
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("<b><color=#FF0000>SKILL: " + PhotonNetwork.player.customProperties[PhotonPlayerProperty.statSKILL] + "</color></b>");
                    GUILayout.Label("<b><color=#FFFFFFF>Total: " + (((((int)PhotonNetwork.player.customProperties[PhotonPlayerProperty.statACL]) + ((int)PhotonNetwork.player.customProperties[PhotonPlayerProperty.statBLA])) + ((int)PhotonNetwork.player.customProperties[PhotonPlayerProperty.statGAS])) + ((int)PhotonNetwork.player.customProperties[PhotonPlayerProperty.statSPD])) + "/455 </color></b>");
                    GUILayout.EndHorizontal();
                }
                float kills = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.kills]);
                float deaths = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.deaths]);
                if (deaths == 0)
                {
                    deaths = 1;
                }
                if (kills > 0)
                {
                    kdr = kills / deaths;
                }
                if (kills == 0)
                {
                    kdr = 0;
                }
                float dmg = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.total_dmg]);
                float kills2 = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.kills]);
                if (dmg == 0 || kills == 0)
                {
                    dr = 0;
                }
                if (dmg > 0 && kills > 0)
                {
                    dr = dmg / kills2;
                }
                GUILayout.BeginHorizontal();
                GUILayout.Label("<color=#FF0000>KDR:</color> " + kdr, new GUILayoutOption[0]);
                GUILayout.Label("<color=#000000>DR:</color> " + dr, new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.Label("<color=#FFFFFF>Damage: </color>" + Mathf.Max(10, (int)IN_GAME_MAIN_CAMERA.main_object.rigidbody.velocity.magnitude * 10f), new GUILayoutOption[0]);
                if (GUILayout.Button("Clear Stats", new GUILayoutOption[0]))
                {
                    ExitGames.Client.Photon.Hashtable propertiesToSet = new ExitGames.Client.Photon.Hashtable();
                    propertiesToSet.Add(PhotonPlayerProperty.kills, 0);
                    propertiesToSet.Add(PhotonPlayerProperty.deaths, 0);
                    propertiesToSet.Add(PhotonPlayerProperty.max_dmg, 0);
                    propertiesToSet.Add(PhotonPlayerProperty.total_dmg, 0);
                    PhotonNetwork.player.SetCustomProperties(propertiesToSet);
                }
                if (GUILayout.Button("GUI Skins", new GUILayoutOption[0]))
                {
                    skins = !skins;
                }
            }
            if (Step == 1)
            {
                GUILayout.BeginVertical();
                filter = GUILayout.TextField(filter, new GUILayoutOption[0]);
                /*if (PhotonNetwork.playerList.Length > 13)
                {
                    vSliderValue = GUI.BeginScrollView(new Rect(-8, 70, 330, 300), vSliderValue, new Rect(0, 0, 0, 30 * PhotonNetwork.playerList.Length));
                }*/
                foreach (PhotonPlayer player1 in PhotonNetwork.playerList)
                {
                    if (player1.customProperties[PhotonPlayerProperty.dead] != null)
                    {
                        string str = (string)player1.customProperties[PhotonPlayerProperty.name];
                        if (str.ToUpper().Contains(filter.ToUpper()) || filter.Contains("" + player1.ID))
                        {
                            if (str.Length < 300)
                            {
                                str = RCextensions.hexColor(str);
                                if (GUILayout.Button(str, new GUILayoutOption[0]))
                                {
                                    playerListGUI = true;
                                    playerInfo = player1;
                                }
                            }
                            else
                            {
                                if (GUILayout.Button(player1.ID + " Long Name.", new GUILayoutOption[0]))
                                {
                                    playerListGUI = true;
                                    playerInfo = player1;
                                }
                            }
                        }
                    }
                }
                GUILayout.EndVertical();
            }
            if (Step == 2)
            {
                if (!PhotonNetwork.isMasterClient)
                {
                    GUILayout.BeginVertical();
                    GUILayout.Label("Room name: " + RCextensions.hexColor((string)PhotonNetwork.room.name.Split(new char[] { '`' })[0]), new GUILayoutOption[0]);
                    GUILayout.Label("Gamemode: " + IN_GAME_MAIN_CAMERA.gamemode.ToString(), new GUILayoutOption[0]);
                    char[] separator = new char[] { "`"[0] };
                    string[] strArray = PhotonNetwork.room.name.Split(separator);
                    if (strArray[5] != string.Empty)
                    {
                        GUILayout.Label("Password: " + new SimpleAES().Decrypt(strArray[5]), new GUILayoutOption[0]);
                    }
                    GUILayout.Label("Players: " + PhotonNetwork.room.playerCount + "/" + PhotonNetwork.room.maxPlayers, new GUILayoutOption[0]);
                    if (PhotonNetwork.room.visible)
                    {
                        GUILayout.Label("Room Visibility: <color=#32CD32>Enabled</color>", new GUILayoutOption[0]);
                    }
                    else
                    {
                        GUILayout.Label("Room Visibility: <color=#FF0000>Disabled</color>", new GUILayoutOption[0]);
                    }
                    if (PhotonNetwork.room.open)
                    {
                        GUILayout.Label("Room Joinability: <color=#32CD32>Enabled</color>", new GUILayoutOption[0]);
                    }
                    else
                    {
                        GUILayout.Label("Room Joinability: <color=#FF0000>Disabled</color>", new GUILayoutOption[0]);
                    }
                    if (FengGameManagerMKII.flight)
                    {
                        GUILayout.Label("Flight: <color=#32CD32>Enabled</color>", new GUILayoutOption[0]);
                    }
                    else
                    {
                        GUILayout.Label("Flight: <color=#FF0000>Disabled</color>", new GUILayoutOption[0]);
                    }
                    if (FengGameManagerMKII.isCandyMasterClient)
                    {
                        bounceserver = GUILayout.Toggle(bounceserver, "Bounce", new GUILayoutOption[0]);
                        if (!sendbounce)
                        {

                            if (bounceserver)
                            {
                                sendbounce = true;
                                FengGameManagerMKII.MKII.CandyModUsersOnly("Bounce", "All", new object[] { 100f });
                            }
                        }
                        else if (!bounceserver)
                        {
                            sendbounce = false;
                            FengGameManagerMKII.MKII.CandyModUsersOnly("Bounce", "All", new object[] { 0f });
                        }
                    }
                    GUILayout.EndVertical();
                }
                else
                {
                    GUILayout.BeginVertical();
                    GUILayout.Label("Room name: " + RCextensions.hexColor((string)PhotonNetwork.room.name.Split(new char[] { '`' })[0]), new GUILayoutOption[0]);
                    GUILayout.Label("Gamemode: " + IN_GAME_MAIN_CAMERA.gamemode.ToString(), new GUILayoutOption[0]);
                    char[] separator = new char[] { "`"[0] };
                    string[] strArray = PhotonNetwork.room.name.Split(separator);
                    if (strArray[5] != string.Empty)
                    {
                        GUILayout.Label("Password: " + new SimpleAES().Decrypt(strArray[5]), new GUILayoutOption[0]);
                    }
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Players: " + PhotonNetwork.room.playerCount + "/", new GUILayoutOption[0]);
                    PhotonNetwork.room.maxPlayers = int.Parse(GUILayout.TextField(PhotonNetwork.room.maxPlayers + "", new GUILayoutOption[0]));
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Titan Size: ", new GUILayoutOption[0]);
                    TITAN.size1 = float.Parse(GUILayout.TextField(TITAN.size1 + "", new GUILayoutOption[0]));
                    GUILayout.Label("   /", new GUILayoutOption[0]);
                    TITAN.size2 = float.Parse(GUILayout.TextField(TITAN.size2 + "", new GUILayoutOption[0]));
                    if (GUILayout.Button("Set", new GUILayoutOption[0]))
                    {
                        FengGameManagerMKII.size = true;
                        object[] objArray8 = new object[] { "<color=#ffcc00>Size Is Now: " + TITAN.size1 + ", " + TITAN.size2 + "</color>", string.Empty };
                        FengGameManagerMKII.MKII.photonView.RPC("Chat", PhotonTargets.All, objArray8);
                    }
                    if (GUILayout.Button("Reset", new GUILayoutOption[0]))
                    {
                        TITAN.size1 = 0.7f;
                        TITAN.size2 = 3f;
                        FengGameManagerMKII.size = false;
                        object[] objArray8 = new object[] { "<color=#ffcc00>Size Is Now Normal</color>", string.Empty };
                        FengGameManagerMKII.MKII.photonView.RPC("Chat", PhotonTargets.All, objArray8);
                    }
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Titan Spawn: ", new GUILayoutOption[0]);
                    TITAN.spawn1 = int.Parse(GUILayout.TextField(TITAN.spawn1 + "", new GUILayoutOption[0]));
                    TITAN.spawn2 = int.Parse(GUILayout.TextField(TITAN.spawn2 + "", new GUILayoutOption[0]));
                    TITAN.spawn3 = int.Parse(GUILayout.TextField(TITAN.spawn3 + "", new GUILayoutOption[0]));
                    TITAN.spawn4 = int.Parse(GUILayout.TextField(TITAN.spawn4 + "", new GUILayoutOption[0]));
                    TITAN.spawn5 = int.Parse(GUILayout.TextField(TITAN.spawn5 + "", new GUILayoutOption[0]));
                    if (GUILayout.Button("Set", new GUILayoutOption[0]))
                    {
                        if (TITAN.spawn1 + TITAN.spawn2 + TITAN.spawn3 + TITAN.spawn4 + TITAN.spawn5 == 100)
                        {
                            TITAN.spawnrate = true;
                            object[] objArray8 = new object[] { "<color=#ffcc00>Spawn Rate Is Now Set To: " + TITAN.spawn1 + ", " + TITAN.spawn2 + ", " + TITAN.spawn3 + ", " + TITAN.spawn4 + ", " + TITAN.spawn5 + "</color>", string.Empty };
                            FengGameManagerMKII.MKII.photonView.RPC("Chat", PhotonTargets.All, objArray8);
                        }
                        else
                        {
                            InRoomChat.addLINE("<color=#ffcc00>Did Not Add Up To 100</color>");
                        }
                    }
                    if (GUILayout.Button("Reset", new GUILayoutOption[0]))
                    {
                        TITAN.spawnrate = false;
                    }
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Titan Damage: ", new GUILayoutOption[0]);
                    TITAN.damage = int.Parse(GUILayout.TextField(TITAN.damage + "", new GUILayoutOption[0]));
                    if (GUILayout.Button("Set", new GUILayoutOption[0]))
                    {
                        if (TITAN.damage < 11)
                        {
                            FengGameManagerMKII.damage = false;
                            object[] objArray9 = new object[] { "<color=#ffcc00>Damage Is Now Normal</color>", string.Empty };
                            FengGameManagerMKII.MKII.photonView.RPC("Chat", PhotonTargets.All, objArray9);
                        }
                        else
                        {
                            FengGameManagerMKII.damage = true;
                            object[] objArray8 = new object[] { "<color=#ffcc00>Damage Is Now Set To: " + TITAN.damage + " </color>", string.Empty };
                            FengGameManagerMKII.MKII.photonView.RPC("Chat", PhotonTargets.All, objArray8);
                        }
                    }
                    GUILayout.EndHorizontal();
                    PhotonNetwork.room.visible = GUILayout.Toggle(PhotonNetwork.room.visible, "Room Visibility", new GUILayoutOption[0]);
                    PhotonNetwork.room.open = GUILayout.Toggle(PhotonNetwork.room.open, "Room Joinability", new GUILayoutOption[0]);
                    FengGameManagerMKII.flight = GUILayout.Toggle(FengGameManagerMKII.flight, "Flight", new GUILayoutOption[0]);
                    bounceserver = GUILayout.Toggle(bounceserver, "Bounce", new GUILayoutOption[0]);
                    if (!sendbounce)
                    {

                        if (bounceserver)
                        {
                            sendbounce = true;
                            FengGameManagerMKII.MKII.CandyModUsersOnly("Bounce", "All", new object[] { 100f });
                        }
                    }
                    else if (!bounceserver)
                    {
                        sendbounce = false;
                        FengGameManagerMKII.MKII.CandyModUsersOnly("Bounce", "All", new object[] { 0f });
                    }
                    if (GUILayout.Button("Revive All", new GUILayoutOption[0]))
                    {
                        FengGameManagerMKII.MKII.photonView.RPC("respawnHeroInNewRound", PhotonTargets.All, new object[0]);
                    }
                    if (GUILayout.Button("Ban List", new GUILayoutOption[0]))
                    {
                        banList = !banList;
                    }
                    GUILayout.EndVertical();
                }
            }
            if (Step == 3 && !History)//Music Area
            {
                GUILayout.BeginVertical();
                if (InRoomChat.playlist.Count != 0 && !remover)
                {
                    playlist = "";
                    foreach (string str in InRoomChat.playlist)
                    {
                        if (str.Split(new char[0])[2] != "(Removed)" && !copy)
                        {
                            string str2 = str.Split(new char[0])[1];
                            if (playlist == "")
                            {
                                if (str.Split(new char[0])[0] == "" + InRoomChat.playlistplaying)
                                {
                                    playlist = "Playing=>" + str2;
                                }
                                else
                                {
                                    playlist = "" + str2;
                                }
                            }
                            else
                            {
                                if (str.Split(new char[0])[0] == "" + InRoomChat.playlistplaying)
                                {
                                    playlist = playlist + '\n' + "Playing=>" + str2;
                                }
                                else
                                {
                                    playlist = playlist + '\n' + str2;
                                }
                            }
                        }
                        if (copy)
                        {
                            string str2 = str.Split(new char[0])[1] + " " + str.Split(new char[0])[2];
                            if (playlist == "")
                            {
                                if (str.Split(new char[0])[0] == "" + InRoomChat.playlistplaying)
                                {
                                    playlist = "Playing=>" + str2;
                                }
                                else
                                {
                                    playlist = "" + str2;
                                }
                            }
                            else
                            {
                                if (str.Split(new char[0])[0] == "" + InRoomChat.playlistplaying)
                                {
                                    playlist = playlist + '\n' + "Playing=>" + str2;
                                }
                                else
                                {
                                    playlist = playlist + '\n' + str2;
                                }
                            }
                        }
                    }
                }
                if (InRoomChat.playlist.Count == 0)
                {
                    playlist = "Empty...";
                }
                if (remover)
                {
                    foreach (string str in InRoomChat.playlist)
                    {
                        if (GUILayout.Button(str, new GUILayoutOption[0]))
                        {
                            extraList = new List<string>();
                            foreach (string str2 in InRoomChat.playlist)
                            {
                                if (str == str2 && !str.EndsWith("(Removed)"))
                                {
                                    extraList.Add(str + "(Removed)");
                                }
                                else if (str == str2 && str.EndsWith("(Removed)"))
                                {
                                    extraList.Add(str.Split(new char[0])[0] + " " + str.Split(new char[0])[1] + " ");
                                }
                                else if (str != str2)
                                {
                                    extraList.Add(str2);
                                }
                            }
                            InRoomChat.playlist = extraList;
                            if (!local)
                            {
                                CandyModUsersOnly("Remove", "Others", new object[] { str });
                            }
                        }
                    }
                }
                if (!copy && !remover)
                {
                    GUILayout.Label(playlist, new GUILayoutOption[0]);
                }
                if (copy)
                {
                    GUILayout.TextArea(playlist, new GUILayoutOption[0]);
                }
                GUILayout.BeginHorizontal();
                if (copy = GUILayout.Toggle(copy, "Copy", new GUILayoutOption[0]))
                {
                    remover = false;
                }
                local = GUILayout.Toggle(local, "Local", new GUILayoutOption[0]);
                if (PhotonNetwork.player.ID == FengGameManagerMKII.candyMasterClient || local)
                {
                    if (remover = GUILayout.Toggle(remover, "Remove", new GUILayoutOption[0]))
                    {
                        copy = false;
                    }
                }
                GUILayout.EndHorizontal();
                if (PhotonNetwork.player.ID == FengGameManagerMKII.candyMasterClient || local)
                {
                    if (GUILayout.Button("Add", new GUILayoutOption[0]))
                    {
                        Add = !Add;
                        if (AddSong != String.Empty)
                        {
                            extraList = new List<string>();
                            foreach (string str in InRoomChat.playlist)
                            {
                                if (str.Split(new char[0])[1] != AddSong)
                                {
                                    extraList.Add(str);
                                }
                            }
                            if (extraList != InRoomChat.playlist)
                            {
                                int int1 = InRoomChat.playlist.Count + 1;
                                InRoomChat.playlist.Add(int1 + " " + AddSong + " ");
                                if (!local)
                                {
                                    CandyModUsersOnly("AddS", "Others", new object[] { AddSong });
                                }
                            }
                            AddSong = String.Empty;
                        }
                        if (InRoomChat.playlist.Count == 1)
                        {
                            InRoomChat.playlistplaying = 1;
                            GameObject.Find("Chatroom").GetComponent<InRoomChat>().CandyModUsersOnly("SendMusic", "All", new object[] { InRoomChat.playlist[InRoomChat.playlistplaying - 1].Remove(0, 2).Replace(" ", "") });
                            CandyModUsersOnly("SongInt", "Others", new object[] { InRoomChat.playlistplaying });
                        }
                    }
                    if (Add)
                    {
                        AddSong = GUILayout.TextField(AddSong, new GUILayoutOption[0]);
                    }
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button("Previous", new GUILayoutOption[0]))
                    {
                        if (InRoomChat.playlist.Count > 0)
                        {
                            GameObject.Find("Chatroom").GetComponent<InRoomChat>().CandyModUsersOnly("StopMusic", "All", new object[] { });
                            if (InRoomChat.playlistplaying > 1)
                            {
                                InRoomChat.playlistplaying--;
                            }
                            else
                            {
                                InRoomChat.playlistplaying = InRoomChat.playlist.Count;
                            }
                            foreach (string str in InRoomChat.playlist)
                            {
                                if (str.Split(new char[0])[0] == "" + InRoomChat.playlistplaying && str.Split(new char[0])[2] == "(Removed)")
                                {
                                    if (InRoomChat.playlistplaying > 1)
                                    {
                                        InRoomChat.playlistplaying--;
                                    }
                                    else
                                    {
                                        InRoomChat.playlistplaying = InRoomChat.playlist.Count;
                                    }
                                }
                            }
                            GameObject.Find("Chatroom").GetComponent<InRoomChat>().CandyModUsersOnly("SendMusic", "All", new object[] { InRoomChat.playlist[InRoomChat.playlistplaying - 1].Remove(0, 2).Replace(" ", "") });
                            CandyModUsersOnly("SongInt", "Others", new object[] { InRoomChat.playlistplaying });
                        }
                    }
                    if (GUILayout.Button("Next", new GUILayoutOption[0]))
                    {
                        if (InRoomChat.playlist.Count > 0)
                        {
                            GameObject.Find("Chatroom").GetComponent<InRoomChat>().CandyModUsersOnly("StopMusic", "All", new object[] { });
                            if (InRoomChat.playlistplaying < InRoomChat.playlist.Count)
                            {
                                InRoomChat.playlistplaying++;
                            }
                            else
                            {
                                InRoomChat.playlistplaying = 1;
                            }
                            foreach (string str in InRoomChat.playlist)
                            {
                                if (str.Split(new char[0])[0] == "" + InRoomChat.playlistplaying && str.Split(new char[0])[2] == "(Removed)")
                                {
                                    if (InRoomChat.playlistplaying < InRoomChat.playlist.Count)
                                    {
                                        InRoomChat.playlistplaying++;
                                    }
                                    else
                                    {
                                        InRoomChat.playlistplaying = 1;
                                    }
                                }
                            }
                            GameObject.Find("Chatroom").GetComponent<InRoomChat>().CandyModUsersOnly("SendMusic", "All", new object[] { InRoomChat.playlist[InRoomChat.playlistplaying - 1].Remove(0, 2).Replace(" ", "") });
                        }
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.BeginHorizontal();
                if (PhotonNetwork.player.ID == FengGameManagerMKII.candyMasterClient || local)
                {
                    if (GUILayout.Button("Play", new GUILayoutOption[0]))
                    {
                        if (InRoomChat.playlistplaying == 0)
                        {
                            InRoomChat.playlistplaying = 1;
                        }
                        else
                        {
                            GameObject.Find("Chatroom").GetComponent<InRoomChat>().CandyModUsersOnly("SendMusic", "All", new object[] { InRoomChat.playlist[InRoomChat.playlistplaying - 1].Remove(0, 2).Replace(" ", "") });
                            CandyModUsersOnly("SongInt", "Others", new object[] { InRoomChat.playlistplaying });
                        }
                    }
                    if (GUILayout.Button("Stop", new GUILayoutOption[0]))
                    {
                        GameObject.Find("Chatroom").GetComponent<InRoomChat>().CandyModUsersOnly("StopMusic", "All", new object[] { });
                    }
                }
                if (GUILayout.Button("Off", new GUILayoutOption[0]))
                {
                    if (!PhotonNetwork.isMasterClient)
                    {
                        if (GameObject.Find("Chatroom").GetComponent<InRoomChat>().isplaying)
                            GameObject.Find("Chatroom").GetComponent<InRoomChat>().audioSource.Stop();
                        InRoomChat.receievemusic = false;
                        GameObject.Find("Chatroom").GetComponent<InRoomChat>().isplaying = false;
                        InRoomChat.isloading = false;
                        GameObject.Find("Chatroom").GetComponent<InRoomChat>().musc = null;
                    }
                }
                if (GUILayout.Button("On", new GUILayoutOption[0]))
                {
                    if (!PhotonNetwork.isMasterClient)
                    {
                        GameObject.Find("Chatroom").GetComponent<InRoomChat>().CandyModUsersOnly("RequestMusic", "All", new object[] { PhotonNetwork.player.ID });
                        InRoomChat.receievemusic = true;
                    }
                }
                GUILayout.EndHorizontal();
                if (PhotonNetwork.isMasterClient || local)
                {
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button("Clear", new GUILayoutOption[0]))
                    {
                        InRoomChat.playlist.Clear();
                        InRoomChat.playlistplaying = 0;
                        if (!local)
                        {
                            CandyModUsersOnly("Clear", "Others", new object[] { });
                        }
                    }
                    if (GUILayout.Button("History", new GUILayoutOption[0]))
                    {
                        History = !History;
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();
            }
            if (Step == 3 && History)
            {
                GUILayout.BeginVertical();
                GUILayout.Label("<size=25>Coming Soon</size>", new GUILayoutOption[0]);
                if (HCopy)
                {
                }
                if (HAdd)
                {
                }
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Add/Copy", new GUILayoutOption[0]))
                {
                    HCopy = !HCopy;
                    HAdd = !HAdd;
                }
                if (GUILayout.Button("Replace All", new GUILayoutOption[0]))
                {
                    //CandyModUsersOnly("Clear", "All", new object[] { });
                }
                GUILayout.EndHorizontal();
                if (GUILayout.Button("Back", new GUILayoutOption[0]))
                {
                    History = false;
                }
                GUILayout.EndVertical();
            }
            if (Step == 4)//Settings Area
            {
                GUILayout.BeginVertical();
                damage = GUILayout.Toggle(damage, "Damage Meter", new GUILayoutOption[0]);
                speed = GUILayout.Toggle(speed, "Speedometer", new GUILayoutOption[0]);
                FPS = GUILayout.Toggle(FPS, "FPS Meter", new GUILayoutOption[0]);
                GUILayout.BeginHorizontal();
                GUILayout.Label("FPS Limiter: ", new GUILayoutOption[0]);
                Application.targetFrameRate = int.Parse(GUILayout.TextField(Application.targetFrameRate + "", new GUILayoutOption[0]));
                GUILayout.EndHorizontal();
                //IN_GAME_MAIN_CAMERA.fly = GUILayout.Toggle(IN_GAME_MAIN_CAMERA.fly, "Flight", new GUILayoutOption[0]);
                InRoomChat.candyshower = GUILayout.Toggle(InRoomChat.candyshower, "Candy Shower", new GUILayoutOption[0]);
                FengGameManagerMKII.showcandies = GUILayout.Toggle(FengGameManagerMKII.showcandies, "Show CandyMod Users", new GUILayoutOption[0]);
                FengGameManagerMKII.showchat = GUILayout.Toggle(FengGameManagerMKII.showchat, "Chat Over Head", new GUILayoutOption[0]);
                bounceme = GUILayout.Toggle(bounceme, "Bounce", new GUILayoutOption[0]);
                if (!bounceme)
                {
                    PhysicMaterial material = new PhysicMaterial("bouncy")
                    {
                        bounciness = 0f,//0.45f
                        bounceCombine = PhysicMaterialCombine.Maximum
                    };
                    IN_GAME_MAIN_CAMERA.main_object.collider.material = material;
                }
                //GUILayout.Label("(Quality Settings)", new GUILayoutOption[0]);
                shadow = GUILayout.Toggle(shadow, "Shadows", new GUILayoutOption[0]);
                trailLength = GUILayout.Toggle(trailLength, "Trail Length", new GUILayoutOption[0]);
                //RenderSettings.fog = GUILayout.Toggle(RenderSettings.fog, "Fog", new GUILayoutOption[0]);
                bladeTrails = GUILayout.Toggle(bladeTrails, "HD Blade Trails", new GUILayoutOption[0]);
                FengGameManagerMKII.rainbowasdf = GUILayout.Toggle(FengGameManagerMKII.rainbowasdf, "Rainbow Trails (Beta)", new GUILayoutOption[0]);
                GUILayout.Label("Render Distance & Quality: ", new GUILayoutOption[0]);
                //GUILayout.Label("Render Distance: ", new GUILayoutOption[0]);
                distance = GUILayout.HorizontalSlider(distance, 1, 40000, new GUILayoutOption[0]);
                if (distance <= 30)
                    distance = 30.1f;
                //GUILayout.Label("Quality: ", new GUILayoutOption[0]);
                quality = GUILayout.HorizontalSlider(quality, 10, 0, new GUILayoutOption[0]);
                GUILayout.EndVertical();
            }/*
            if (Step == 5)//Skins Area
            {
                Rect rec = new Rect(Screen.width / 60, Screen.height / 25, Screen.width / 15, Screen.height / 20);
                scrollview = GUI.BeginScrollView(new Rect(Screen.width / 100, Screen.width / 150, Screen.width / 3, Screen.height / 1.1f), scrollview, new Rect(0, 0, Screen.width / 2, Screen.height / 2));
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
                    InRoomChat.addLINE("<color=yellow>-saved-</color>");
                }
                //GUILayout.EndVertical();
                GUI.EndScrollView();
            }*/
            if (Step == 6 && !THistory)//Timer
            {
                GUILayout.BeginVertical();
                if (timeamt - (Time.time - timelimit) >= 0 && timing)
                {
                    GUILayout.Label("Time: " + (timeamt - (Time.time - timelimit)), new GUILayoutOption[0]);
                    tkills = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.kills]) - logkills;
                    tdeaths = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.deaths]) - logdeaths;
                    tdeaths2 = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.deaths]) - logdeaths;
                    if (tdeaths == 0)
                    {
                        tdeaths = 1;
                    }
                    if (tkills > 0)
                    {
                        kdr2 = tkills / tdeaths;
                    }
                    if (tkills == 0)
                    {
                        kdr2 = 0;
                    }
                    tdmg = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.total_dmg]);
                    tkills2 = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.kills]);
                    if (tdmg == 0 || tkills == 0)
                    {
                        dr2 = 0;
                    }
                    if (tdmg > 0 && tkills > 0)
                    {
                        dr2 = tdmg / tkills2;
                    }
                }
                else
                {
                    timing = false;
                    GUILayout.Label("Time Ended...", new GUILayoutOption[0]);
                }
                GUILayout.BeginHorizontal();
                GUILayout.Label("Time: ", new GUILayoutOption[0]);
                if (!timing || timeamt - (Time.time - timelimit) <= 0)
                {
                    timeamt = int.Parse(GUILayout.TextField(timeamt + "", new GUILayoutOption[0]));
                    if (timeamt.ToString().Length >= 7)
                    {
                        timeamt = Convert.ToInt32(timeamt.ToString().Remove(0, 1));
                    }
                }
                else
                {
                    GUILayout.Label("" + timeamt, new GUILayoutOption[0]);
                }
                GUILayout.EndHorizontal();
                GUILayout.Label("<color=#FFFFFF><Note That These Are The Final Scores></color>", new GUILayoutOption[0]);
                GUILayout.BeginHorizontal();
                GUILayout.Label("<color=#FF0000>Kills:</color> " + tkills, new GUILayoutOption[0]);
                GUILayout.Label("<color=#000000>Deaths:</color> " + tdeaths2, new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("<color=#FF0000>KDR:</color> " + kdr2, new GUILayoutOption[0]);
                GUILayout.Label("<color=#000000>DR:</color> " + dr2, new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                float asdf = logtimeamt / 60f;
                GUILayout.Label("<color=#FF0000>KPM:</color> " + tkills / asdf, new GUILayoutOption[0]);
                GUILayout.Label("<color=#000000>DPM:</color> " + dr2 / asdf, new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Label("<color=#FF0000>KPS:</color> " + tkills / logtimeamt, new GUILayoutOption[0]);
                GUILayout.Label("<color=#000000>DPS:</color> " + dr2 / logtimeamt, new GUILayoutOption[0]);
                GUILayout.EndHorizontal();
                if (!timing || timeamt - (Time.time - timelimit) <= 0)
                {
                    if (GUILayout.Button("Start", new GUILayoutOption[0]))
                    {
                        timelimit = Time.time;
                        logkills = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.kills]);
                        logdeaths = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.deaths]);
                        logdmg = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.total_dmg]);
                        logmax = Convert.ToSingle(PhotonNetwork.player.customProperties[PhotonPlayerProperty.max_dmg]);
                        logtimeamt = timeamt;
                        timing = true;
                    }
                }
                else
                {
                    if (GUILayout.Button("Stop", new GUILayoutOption[0]))
                    {
                        timing = false;
                    }
                }
                GUILayout.EndVertical();
            }
            if (Step == 6 && THistory)
            {
                scrollview2 = GUI.BeginScrollView(new Rect(Screen.width / 40, 0f, Screen.width / 3, Screen.height / 1.1f), scrollview2, new Rect(0, 0, Screen.width / 2, Screen.height / 2));
                GUILayout.BeginVertical();
                if (GUILayout.Button("Clear", new GUILayoutOption[0]))
                {
                    PlayerPrefs.SetString("TimerH", "");
                }
                if (GUILayout.Button("Back", new GUILayoutOption[0]))
                {
                    PlayerPrefs.SetString("TimerH", "");
                }
                GUILayout.EndVertical();
                GUI.EndScrollView();
            }
            if (Step == 7)
            {
                GUILayout.BeginVertical();
                GUILayout.BeginHorizontal();
                GUILayout.Label("Seeker", new GUILayoutOption[0]);
                seeker = int.Parse(GUILayout.TextField(seeker + "", new GUILayoutOption[0]));
                GUILayout.EndHorizontal();
                if (GUILayout.Button("Start!", new GUILayoutOption[0]))
                {
                    if (FengGameManagerMKII.cmusers.ContainsKey(seeker))
                    {
                        if (FengGameManagerMKII.cmusers[seeker] != null)
                        {
                            if (PhotonNetwork.isMasterClient)
                            {
                                HideAndSeek.step = 1;
                                HideAndSeek.justenabled = true;
                                HideAndSeek.seekerid = seeker;
                                //FengGameManagerMKII.GuiText = Convert.ToString(FengGameManagerMKII.candyMasterClient);
                                /*
                                bool cango = false;
                                GameObject[] pls = GameObject.FindGameObjectsWithTag("Player");
                                for (int z = 0; z < pls.Length; z++)
                                {
                                    if (pls[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID == seeker)
                                    {
                                        cango = true;
                                        break;
                                    }
                                }
                                if (FengGameManagerMKII.modUsers.Contains(seeker) && cango)
                                {
                                    FengGameManagerMKII.MKII.restartGame(false);
                                    FengGameManagerMKII.MKII.CandyModUsersOnly("Seeker", "All", new object[] { seeker });
                                }
                                else
                                {
                                    InRoomChat.addLINE("<color=yellow>-There is no alive CandyMod user with that id-</color>");
                                }*/
                            }
                            else
                            {
                                HideAndSeek.justenabled = false;
                                HideAndSeek.restart = false;
                                GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().photonView.RPC("StartHide", PhotonTargets.All, new object[] { seeker });
                                //InRoomChat.addLINE("<color=yellow>-You Must Be Candymasterclient-</color>");
                            }
                        }
                    }
                }
                if (GUILayout.Button("Stop", new GUILayoutOption[0]))
                {
                    if (FengGameManagerMKII.isCandyMasterClient)
                    {
                        FengGameManagerMKII.MKII.CandyModUsersOnly("Stophns", "All", new object[] { });
                        FengGameManagerMKII.MKII.restartGame(false);
                    }
                    else
                    {
                        InRoomChat.addLINE("<color=yellow>-You Must Be Candymasterclient-</color>");
                    }
                }
                GUILayout.EndVertical();
            }
        }
        else
        {
            GUILayout.Label("<size=25>Please Join A Server...</size>", new GUILayoutOption[0]);
        }
        GUILayout.EndVertical();
        if ((!Input.GetKey(KeyCode.Mouse0) || !Input.GetKey(KeyCode.Mouse1)) && !Input.GetKey(KeyCode.C) && (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.WOW || IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.ORIGINAL))
        {
            GUI.DragWindow();
        }
    }
    int seeker = 0;
    public static bool History;
    public static bool HCopy;
    public static bool HAdd;
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
    public void BanGUI(int id)
    {
        GUI.backgroundColor = new Color(1f, 1f, 1f, 255f);
        if (bancolor || banrainbow)
        {
            GUI.backgroundColor = new Color(banR, banG, banB, 255f);
        }
        GUILayout.BeginVertical();
        foreach (string str in FengGameManagerMKII.banlist)
        {
            if (str != String.Empty && str != null)
            {
                GUILayout.BeginVertical();
                if (GUILayout.Button(str, new GUILayoutOption[0]))
                {
                    //put your own list with remove
                }
                GUILayout.EndVertical();
            }
        }
        if (GUILayout.Button("Clear", new GUILayoutOption[0]))
        {
            playcountkeeping++;
            //put your own clear
        }
        GUILayout.EndVertical();
        if ((!Input.GetKey(KeyCode.Mouse0) || !Input.GetKey(KeyCode.Mouse1)) && !Input.GetKey(KeyCode.C) && (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.WOW || IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.ORIGINAL))
        {
            GUI.DragWindow();
        }
    }

    public void SkinGUI(int id)
    {
        GUI.backgroundColor = new Color(1f, 1f, 1f, 255f);
        if (skincolor || skinrainbow)
        {
            GUI.backgroundColor = new Color(skinR, skinG, skinB, 255f);
        }
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Main Skin", new GUILayoutOption[0]);
        mainskin = GUILayout.Toggle(mainskin, "Texture", new GUILayoutOption[0]);
        maincolor = GUILayout.Toggle(maincolor, "Color", new GUILayoutOption[0]);
        mainrainbow = GUILayout.Toggle(mainrainbow, "Rainbow", new GUILayoutOption[0]);
        mainvis = GUILayout.Toggle(mainvis, "Visible", new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        if (mainskin)
        {
            mainguiwww = GUILayout.TextField(mainguiwww, new GUILayoutOption[0]);
        }
        if (maincolor)
        {
            mainR = GUILayout.HorizontalSlider(mainR, 0f, 1f, new GUILayoutOption[0]);
            mainG = GUILayout.HorizontalSlider(mainG, 0f, 1f, new GUILayoutOption[0]);
            mainB = GUILayout.HorizontalSlider(mainB, 0f, 1f, new GUILayoutOption[0]);
        }
        if (mainrainbow)
        {
            mainspeed = GUILayout.HorizontalSlider(mainspeed, 0.001f, 0.15f, new GUILayoutOption[0]);
        }
        GUILayout.BeginHorizontal();
        GUILayout.Label("Ban Skin", new GUILayoutOption[0]);
        banskin = GUILayout.Toggle(banskin, "Texture", new GUILayoutOption[0]);
        bancolor = GUILayout.Toggle(bancolor, "Color", new GUILayoutOption[0]);
        banrainbow = GUILayout.Toggle(banrainbow, "Rainbow", new GUILayoutOption[0]);
        banvis = GUILayout.Toggle(banvis, "Visible", new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        if (banskin)
        {
            banguiwww = GUILayout.TextField(banguiwww, new GUILayoutOption[0]);
        }
        if (bancolor)
        {
            banR = GUILayout.HorizontalSlider(banR, 0f, 1f, new GUILayoutOption[0]);
            banG = GUILayout.HorizontalSlider(banG, 0f, 1f, new GUILayoutOption[0]);
            banB = GUILayout.HorizontalSlider(banB, 0f, 1f, new GUILayoutOption[0]);
        }
        if (banrainbow)
        {
            banspeed = GUILayout.HorizontalSlider(banspeed, 0.001f, 0.15f, new GUILayoutOption[0]);
        }
        GUILayout.BeginHorizontal();
        GUILayout.Label("This Skin", new GUILayoutOption[0]);
        skinskin = GUILayout.Toggle(skinskin, "Texture", new GUILayoutOption[0]);
        skincolor = GUILayout.Toggle(skincolor, "Color", new GUILayoutOption[0]);
        skinrainbow = GUILayout.Toggle(skinrainbow, "Rainbow", new GUILayoutOption[0]);
        skinvis = GUILayout.Toggle(skinvis, "Visible", new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        if (skinskin)
        {
            skinguiwww = GUILayout.TextField(skinguiwww, new GUILayoutOption[0]);
        }
        if (skincolor)
        {
            skinR = GUILayout.HorizontalSlider(skinR, 0f, 1f, new GUILayoutOption[0]);
            skinG = GUILayout.HorizontalSlider(skinG, 0f, 1f, new GUILayoutOption[0]);
            skinB = GUILayout.HorizontalSlider(skinB, 0f, 1f, new GUILayoutOption[0]);
        }
        if (skinrainbow)
        {
            skinspeed = GUILayout.HorizontalSlider(skinspeed, 0.001f, 0.15f, new GUILayoutOption[0]);
        }
        GUILayout.BeginHorizontal();
        GUILayout.Label("Player Info Skin", new GUILayoutOption[0]);
        playerskin = GUILayout.Toggle(playerskin, "Texture", new GUILayoutOption[0]);
        playercolor = GUILayout.Toggle(playercolor, "Color", new GUILayoutOption[0]);
        playerrainbow = GUILayout.Toggle(playerrainbow, "Rainbow", new GUILayoutOption[0]);
        playervis = GUILayout.Toggle(playervis, "Visible", new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        if (playerskin)
        {
            playerwww = GUILayout.TextField(playerwww, new GUILayoutOption[0]);
        }
        if (playercolor)
        {
            playerR = GUILayout.HorizontalSlider(playerR, 0f, 1f, new GUILayoutOption[0]);
            playerG = GUILayout.HorizontalSlider(playerG, 0f, 1f, new GUILayoutOption[0]);
            playerB = GUILayout.HorizontalSlider(playerB, 0f, 1f, new GUILayoutOption[0]);
        }
        if (playerrainbow)
        {
            playerspeed = GUILayout.HorizontalSlider(playerspeed, 0.001f, 0.15f, new GUILayoutOption[0]);
        }
        //if(GUILayout.Button("Load", new GUILayoutOption[0]))
        if (playerwww2 != playerwww || mainguiwww != mainguiwww2 || banguiwww != banguiwww2 || skinguiwww != skinguiwww2)
        {
            playerwww2 = playerwww;
            mainguiwww2 = mainguiwww;
            banguiwww2 = banguiwww;
            skinguiwww2 = skinguiwww;
            base.StartCoroutine(this.loadskins());
        }
        GUILayout.EndVertical();
        if ((!Input.GetKey(KeyCode.Mouse0) || !Input.GetKey(KeyCode.Mouse1)) && !Input.GetKey(KeyCode.C) && (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.WOW || IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.ORIGINAL))
        {
            GUI.DragWindow();
        }
    }

    public void PlayerGUI(int id)
    {
        GUI.backgroundColor = new Color(1f, 1f, 1f, 255f);
        if (playercolor || playerrainbow)
        {
            GUI.backgroundColor = new Color(playerR, playerG, playerB, 255f);
        }
        GUILayout.BeginVertical();
        GUILayout.Label("ID: " + playerInfo.ID, new GUILayoutOption[0]);
        string name = RCextensions.hexColor((string)playerInfo.customProperties[PhotonPlayerProperty.name]);
        string guild = RCextensions.hexColor((string)playerInfo.customProperties[PhotonPlayerProperty.guildName]);
        GUILayout.Label("Name: " + name, new GUILayoutOption[0]);
        GUILayout.Label("Guild: " + guild, new GUILayoutOption[0]);
        if (Convert.ToInt32(playerInfo.customProperties[PhotonPlayerProperty.isTitan]) == 1 && !Convert.ToBoolean(playerInfo.customProperties[PhotonPlayerProperty.dead]))
        {
            int num3 = ((((int)playerInfo.customProperties[PhotonPlayerProperty.statACL]) + ((int)playerInfo.customProperties[PhotonPlayerProperty.statBLA])) + ((int)playerInfo.customProperties[PhotonPlayerProperty.statGAS])) + ((int)playerInfo.customProperties[PhotonPlayerProperty.statSPD]);
            int num4 = (int)playerInfo.customProperties[PhotonPlayerProperty.statACL];
            int num5 = (int)playerInfo.customProperties[PhotonPlayerProperty.statBLA];
            int num6 = (int)playerInfo.customProperties[PhotonPlayerProperty.statGAS];
            int num7 = (int)playerInfo.customProperties[PhotonPlayerProperty.statSPD];
            GUILayout.BeginHorizontal();
            GUILayout.Label("<b><color=#00FFFF>ACL: " + num4 + "</color></b>");
            GUILayout.Label("<b><color=#000000>BLA: " + num5 + "</color></b>");
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("<b><color=#FFFFFF>GAS: " + num6 + "</color></b>");
            GUILayout.Label("<b><color=#FFFF00>SPD: " + num7 + "</color></b>");
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("<b><color=#FF0000>SKILL: " + playerInfo.customProperties[PhotonPlayerProperty.statSKILL] + "</color></b>");
            GUILayout.Label("<b><color=#FFFFFFF>Total: " + num3 + "/455 </color></b>");
            GUILayout.EndHorizontal();
            if (num3 > 455 || num4 > 150 || num5 > 125 || num6 > 150 || num7 > 140)
            {
                GUILayout.Label("<b><color=#FF0000>H4X0R!!!</color></b>");
            }
        }
        float kills = Convert.ToSingle(playerInfo.customProperties[PhotonPlayerProperty.kills]);
        float deaths = Convert.ToSingle(playerInfo.customProperties[PhotonPlayerProperty.deaths]);
        if (deaths == 0)
        {
            deaths = 1;
        }
        if (kills > 0)
        {
            kdr = kills / deaths;
        }
        if (kills == 0)
        {
            kdr = 0;
        }
        float dmg = Convert.ToSingle(playerInfo.customProperties[PhotonPlayerProperty.total_dmg]);
        float kills2 = Convert.ToSingle(playerInfo.customProperties[PhotonPlayerProperty.kills]);
        if (dmg == 0 || kills == 0)
        {
            dr = 0;
        }
        if (dmg > 0 && kills > 0)
        {
            dr = dmg / kills2;
        }
        GUILayout.BeginHorizontal();
        GUILayout.Label("<color=#FF0000>KDR:</color> " + kdr, new GUILayoutOption[0]);
        GUILayout.Label("<color=#000000>DR:</color> " + dr, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        foreach (GameObject obj1 in GameObject.FindGameObjectsWithTag("Player"))
        {
            if ((obj1.GetComponent<SmoothSyncMovement>().photonView.owner.ID == playerInfo.ID) && (obj1.GetComponent<HERO>() != null))
            {
                GUILayout.Label("<color=#FFFFFF>Damage: </color>" + Mathf.Max(10, (int)obj1.rigidbody.velocity.magnitude * 10f), new GUILayoutOption[0]);
            }
        }
        if (PhotonNetwork.isMasterClient)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Revive", new GUILayoutOption[0]))
            {
                FengGameManagerMKII.MKII.photonView.RPC("respawnHeroInNewRound", playerInfo, new object[0]);
            }
            if (GUILayout.Button("Destroy", new GUILayoutOption[0]))
            {
                PhotonNetwork.DestroyPlayerObjects(playerInfo);
                PhotonNetwork.networkingPeer.DestroyPlayerObjects(playerInfo.ID, false);
                foreach (GameObject obj6 in GameObject.FindGameObjectsWithTag("Player"))
                {
                    obj6.GetComponent<HERO>().photonView.RPC("blowAway", playerInfo, new object[] { new Vector3(2E+09f, 2E+09f, 2E+09f) });
                }
                if (Convert.ToInt32(playerInfo.customProperties[PhotonPlayerProperty.isTitan]) == 1)
                {
                    foreach (GameObject obj14 in GameObject.FindGameObjectsWithTag("Player"))
                    {
                        if ((obj14.GetComponent<SmoothSyncMovement>().photonView.owner.ID == playerInfo.ID) && (obj14.GetComponent<HERO>() != null))
                        {
                            obj14.GetComponent<HERO>().markDie();
                            PhotonView networkView = obj14.GetComponent<HERO>().photonView;
                            object[] objArray3 = new object[] { -1, "[000000]Master Client[-]" };
                            networkView.RPC("netDie2", PhotonTargets.All, objArray3);
                        }
                    }
                }
                if (Convert.ToInt32(playerInfo.customProperties[PhotonPlayerProperty.isTitan]) == 2)
                {
                    foreach (GameObject obj15 in GameObject.FindGameObjectsWithTag("titan"))
                    {
                        if ((obj15.GetComponent<SmoothSyncMovement>().photonView.owner.ID == playerInfo.ID) && (obj15.GetComponent<TITAN>() != null))
                        {
                            obj15.GetComponent<TITAN>().photonView.RPC("netDie", PhotonTargets.All, new object[0]);
                        }
                    }
                }
            }
            if (GUILayout.Button("Kill", new GUILayoutOption[0]))
            {
                if (Convert.ToInt32(playerInfo.customProperties[PhotonPlayerProperty.isTitan]) == 1)
                {
                    foreach (GameObject obj14 in GameObject.FindGameObjectsWithTag("Player"))
                    {
                        if ((obj14.GetComponent<SmoothSyncMovement>().photonView.owner.ID == playerInfo.ID) && (obj14.GetComponent<HERO>() != null))
                        {
                            obj14.GetComponent<HERO>().markDie();
                            PhotonView networkView = obj14.GetComponent<HERO>().photonView;
                            object[] objArray3 = new object[] { -1, "[000000]Master Client[-]" };
                            networkView.RPC("netDie2", PhotonTargets.All, objArray3);
                        }
                    }
                }
                if (Convert.ToInt32(playerInfo.customProperties[PhotonPlayerProperty.isTitan]) == 2)
                {
                    foreach (GameObject obj15 in GameObject.FindGameObjectsWithTag("titan"))
                    {
                        if ((obj15.GetComponent<SmoothSyncMovement>().photonView.owner.ID == playerInfo.ID) && (obj15.GetComponent<TITAN>() != null))
                        {
                            obj15.GetComponent<TITAN>().photonView.RPC("netDie", PhotonTargets.All, new object[0]);
                        }
                    }
                }
            }
            if (GUILayout.Button("Ban", new GUILayoutOption[0]))
            {
                string string1 = (string)playerInfo.customProperties[PhotonPlayerProperty.name];
                //put your own ban
            }
            if (GUILayout.Button("Kick", new GUILayoutOption[0]))
            {
                PhotonPlayer player4 = playerInfo;
                //put your own kick
            }
            GUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Close", new GUILayoutOption[0]))
        {
            playerListGUI = false;
        }
        GUILayout.EndVertical();
        if ((!Input.GetKey(KeyCode.Mouse0) || !Input.GetKey(KeyCode.Mouse1)) && !Input.GetKey(KeyCode.C) && (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.WOW || IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.ORIGINAL))
        {
            GUI.DragWindow();
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Skins", mainguiwww + " " + banguiwww + " " + skinguiwww + " " + playerwww);
        PlayerPrefs.SetString("MColors", mainR + " " + mainG + " " + mainB);
        PlayerPrefs.SetString("BColors", banR + " " + banG + " " + banB);
        PlayerPrefs.SetString("SColors", skinR + " " + skinG + " " + skinB);
        PlayerPrefs.SetString("PColors", playerR + " " + playerG + " " + playerB);
        PlayerPrefs.SetString("Rainbows", mainspeed + " " + banspeed + " " + skinspeed + " " + playerspeed);
        PlayerPrefs.SetString("Rainbows", mainspeed + " " + banspeed + " " + skinspeed + " " + playerspeed);
        if (mainskin)
        {
            PlayerPrefs.SetString("MEnabled", "1");
        }
        else
        {
            PlayerPrefs.SetString("MEnabled", "0");
        }
        if (maincolor)
        {
            PlayerPrefs.SetString("MEnabled", PlayerPrefs.GetString("MEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("MEnabled", PlayerPrefs.GetString("MEnabled") + " 0");
        }
        if (mainrainbow)
        {
            PlayerPrefs.SetString("MEnabled", PlayerPrefs.GetString("MEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("MEnabled", PlayerPrefs.GetString("MEnabled") + " 0");
        }
        if (mainvis)
        {
            PlayerPrefs.SetString("MEnabled", PlayerPrefs.GetString("MEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("MEnabled", PlayerPrefs.GetString("MEnabled") + " 0");
        }
        if (banskin)
        {
            PlayerPrefs.SetString("BEnabled", "1");
        }
        else
        {
            PlayerPrefs.SetString("BEnabled", "0");
        }
        if (bancolor)
        {
            PlayerPrefs.SetString("BEnabled", PlayerPrefs.GetString("BEnabled") + "1");
        }
        else
        {
            PlayerPrefs.SetString("BEnabled", PlayerPrefs.GetString("BEnabled") + " 0");
        }
        if (banrainbow)
        {
            PlayerPrefs.SetString("BEnabled", PlayerPrefs.GetString("BEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("BEnabled", PlayerPrefs.GetString("BEnabled") + " 0");
        }
        if (banvis)
        {
            PlayerPrefs.SetString("BEnabled", PlayerPrefs.GetString("BEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("BEnabled", PlayerPrefs.GetString("BEnabled") + " 0");
        }
        if (skinskin)
        {
            PlayerPrefs.SetString("SEnabled", "1");
        }
        else
        {
            PlayerPrefs.SetString("SEnabled", "0");
        }
        if (skincolor)
        {
            PlayerPrefs.SetString("SEnabled", PlayerPrefs.GetString("SEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("SEnabled", PlayerPrefs.GetString("SEnabled") + " 0");
        }
        if (skinrainbow)
        {
            PlayerPrefs.SetString("SEnabled", PlayerPrefs.GetString("SEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("SEnabled", PlayerPrefs.GetString("SEnabled") + " 0");
        }
        if (skinvis)
        {
            PlayerPrefs.SetString("SEnabled", PlayerPrefs.GetString("SEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("SEnabled", PlayerPrefs.GetString("SEnabled") + " 0");
        }
        if (playerskin)
        {
            PlayerPrefs.SetString("PEnabled", "1");
        }
        else
        {
            PlayerPrefs.SetString("PEnabled", "0");
        }
        if (playercolor)
        {
            PlayerPrefs.SetString("PEnabled", PlayerPrefs.GetString("PEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("PEnabled", PlayerPrefs.GetString("PEnabled") + " 0");
        }
        if (playerrainbow)
        {
            PlayerPrefs.SetString("PEnabled", PlayerPrefs.GetString("PEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("PEnabled", PlayerPrefs.GetString("PEnabled") + " 0");
        }
        if (playervis)
        {
            PlayerPrefs.SetString("PEnabled", PlayerPrefs.GetString("PEnabled") + " 1");
        }
        else
        {
            PlayerPrefs.SetString("PEnabled", PlayerPrefs.GetString("PEnabled") + " 0");
        }
    }

    public void Start()
    {
        base.StartCoroutine(this.size());
        flight = FengGameManagerMKII.flight;
        if (PlayerPrefs.GetString("tLength") == "true")
        {
            trailLength = true;
        }
        if (PlayerPrefs.GetString("Trails") == "true")
        {
            FengGameManagerMKII.rainbowasdf = true;
        }
        if (PlayerPrefs.GetString("Fly") == "true")
        {
            prefFlight = true;
        }
        if (PlayerPrefs.GetString("Fly") == "false")
        {
            prefFlight = false;
        }
        if (PlayerPrefs.GetString("Shower") == "true")
        {
            prefShower = true;
        }
        if (PlayerPrefs.GetString("Shower") == "false")
        {
            prefShower = false;
        }
        if (PlayerPrefs.GetString("FPS") == "true")
        {
            prefFPS = true;
        }
        if (PlayerPrefs.GetString("FPS") == "false")
        {
            prefFPS = false;
        }
        if (PlayerPrefs.GetString("Damage") == "true")
        {
            prefDamage = true;
        }
        if (PlayerPrefs.GetString("Damage") == "false")
        {
            prefDamage = false;
        }
        if (PlayerPrefs.GetString("Speed") == "true")
        {
            prefSpeed = true;
        }
        if (PlayerPrefs.GetString("Speed") == "false")
        {
            prefSpeed = false;
        }
        if (PlayerPrefs.GetString("Blades") == "true")
        {
            bladeTrails = true;
        }
        if (PlayerPrefs.GetString("Shadows") == "false")
        {
            shadow = true;
        }
        if (PlayerPrefs.HasKey("Distance"))
        {
            if (PlayerPrefs.GetFloat("Distance") > 30f)
                distance = PlayerPrefs.GetFloat("Distance");
            else
                distance = 30.2f;
        }
        else
        {
            distance = 10000f;
        }
        if (PlayerPrefs.HasKey("Quality"))
        {
            quality = PlayerPrefs.GetInt("Quality");
        }
        if (PlayerPrefs.HasKey("Skins"))
        {
            string[] skins = PlayerPrefs.GetString("Skins").Split(new char[0]);
            mainguiwww = skins[0];
            banguiwww = skins[1];
            skinguiwww = skins[2];
            playerwww = skins[3];
        }
        if (PlayerPrefs.HasKey("MColors"))
        {
            string[] colors = PlayerPrefs.GetString("MColors").Split(new char[0]);
            mainR = Convert.ToSingle(colors[0]);
            mainG = Convert.ToSingle(colors[1]);
            mainB = Convert.ToSingle(colors[2]);
        }
        if (PlayerPrefs.HasKey("BColors"))
        {
            string[] colors = PlayerPrefs.GetString("BColors").Split(new char[0]);
            banR = Convert.ToSingle(colors[0]);
            banG = Convert.ToSingle(colors[1]);
            banB = Convert.ToSingle(colors[2]);
        }
        if (PlayerPrefs.HasKey("SColors"))
        {
            string[] colors = PlayerPrefs.GetString("SColors").Split(new char[0]);
            skinR = Convert.ToSingle(colors[0]);
            skinG = Convert.ToSingle(colors[1]);
            skinB = Convert.ToSingle(colors[2]);
        }
        if (PlayerPrefs.HasKey("PColors"))
        {
            string[] colors = PlayerPrefs.GetString("PColors").Split(new char[0]);
            playerR = Convert.ToSingle(colors[0]);
            playerG = Convert.ToSingle(colors[1]);
            playerB = Convert.ToSingle(colors[2]);
        }
        if (PlayerPrefs.HasKey("Rainbows"))
        {
            string[] rainbows = PlayerPrefs.GetString("Rainbows").Split(new char[0]);
            mainspeed = Convert.ToSingle(rainbows[0]);
            banspeed = Convert.ToSingle(rainbows[1]);
            skinspeed = Convert.ToSingle(rainbows[2]);
            playerspeed = Convert.ToSingle(rainbows[3]);
        }
        if (PlayerPrefs.HasKey("MEnabled"))
        {
            string[] enable = PlayerPrefs.GetString("MEnabled").Split(new char[0]);
            if (enable[0] == "0")
            {
                mainskin = false;
            }
            if (enable[1] == "1")
            {
                maincolor = true;
            }
            if (enable[2] == "1")
            {
                mainrainbow = true;
            }
            if (enable[3] == "0")
            {
                mainvis = false;
            }
        }
        if (PlayerPrefs.HasKey("BEnabled"))
        {
            string[] enable = PlayerPrefs.GetString("BEnabled").Split(new char[0]);
            if (enable[0] == "0")
            {
                banskin = false;
            }
            if (enable[1] == "1")
            {
                bancolor = true;
            }
            if (enable[2] == "1")
            {
                banrainbow = true;
            }
            if (enable[3] == "0")
            {
                banvis = false;
            }
        }
        if (PlayerPrefs.HasKey("SEnabled"))
        {
            string[] enable = PlayerPrefs.GetString("SEnabled").Split(new char[0]);
            if (enable[0] == "0")
            {
                skinskin = false;
            }
            if (enable[1] == "1")
            {
                skincolor = true;
            }
            if (enable[2] == "1")
            {
                skinrainbow = true;
            }
            if (enable[3] == "0")
            {
                skinvis = false;
            }
        }
        if (PlayerPrefs.HasKey("PEnabled"))
        {
            string[] enable = PlayerPrefs.GetString("PEnabled").Split(new char[0]);
            if (enable[0] == "0")
            {
                playerskin = false;
            }
            if (enable[1] == "1")
            {
                playercolor = true;
            }
            if (enable[2] == "1")
            {
                playerrainbow = true;
            }
            if (enable[3] == "0")
            {
                playervis = false;
            }
        }
        Application.targetFrameRate = PlayerPrefs.GetInt("TargetFPS");
        prefFrames = Application.targetFrameRate;
        FPS = prefFPS;
        damage = prefDamage;
        speed = prefSpeed;
        base.StartCoroutine(this.loadskins());
    }
    public static bool prefFlight;
    public static bool prefShower;
    public static bool FPS;
    public static bool prefFPS;
    public static int prefFrames;
    public static bool damage;
    public static bool speed;
    public static bool prefDamage;
    public static bool prefSpeed;
    public static bool prefTrails;
    public IEnumerator size()
    {
        yield return new WaitForSeconds(0.1f);
        GUIRect.size = new Vector2(Convert.ToSingle(Screen.width / 2.9), Convert.ToSingle(Screen.height / 1.5));
        BanRect.size = new Vector2(Convert.ToSingle(Screen.width / 2.9), Convert.ToSingle(Screen.height / 1.5));
        PlayerRect.size = new Vector2(Convert.ToSingle(Screen.width / 2.9), Convert.ToSingle(Screen.height / 1.5));
        SkinRect.size = new Vector2(Convert.ToSingle(Screen.width / 2.9), Convert.ToSingle(Screen.height / 1.5));
    }
    
    public static bool bladeTrails;
    public static bool prefBlades;
    public static bool tLength;
    public static bool trailLength;
    public void Update()
    {
        if (trailLength != tLength)
        {
            if (!trailLength)
            {
                PlayerPrefs.SetString("tLength", "false");
            }
            else
            {
                PlayerPrefs.SetString("tLength", "true");
            }
            tLength = trailLength;
        }
        if (FengGameManagerMKII.rainbowasdf != prefTrails)
        {
            prefTrails = FengGameManagerMKII.rainbowasdf;
            if (FengGameManagerMKII.rainbowasdf)
            {
                PlayerPrefs.SetString("Trails", "true");
            }
            else
            {
                PlayerPrefs.SetString("Trails", "false");
            }
        }
        if (local != catchupbool)
        {
            if (!local)
            {
                FengGameManagerMKII.MKII.photonView.RPC("ReqList", PhotonPlayer.Find(FengGameManagerMKII.candyMasterClient), new object[] { });
            }
            local = catchupbool;
        }
        if (GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().isInputDown[InputCode.fullscreen])
        {
            base.StartCoroutine(this.size());
        }
        if (bladeTrails != prefBlades)
        {
            if (!bladeTrails)
            {
                PlayerPrefs.SetString("Blades", "false");
            }
            else
            {
                PlayerPrefs.SetString("Blades", "true");
            }
            prefBlades = bladeTrails;
        }
        if (UnityEngine.Camera.mainCamera.farClipPlane != distance)
        {
            UnityEngine.Camera.mainCamera.farClipPlane = distance;
            PlayerPrefs.SetFloat("Distance", distance);
        }
        if (quality != QualitySettings.masterTextureLimit)
        {
            QualitySettings.masterTextureLimit = Convert.ToInt32(quality);
            PlayerPrefs.SetInt("Quality", Convert.ToInt32(quality));
        }
        if (shadow != prefShadows)
        {
            if (!shadow)
            {
                PlayerPrefs.SetString("Shadows", "true");
            }
            else
            {
                PlayerPrefs.SetString("Shadows", "false");
            }
            prefShadows = shadow;
            if (shadow)
            {
                QualitySettings.shadowDistance = 0f;
                QualitySettings.shadowProjection = 0f;
                QualitySettings.shadowCascades = 1;
            }
            if (!shadow)
            {
                //I haven't added putting shadows back yet
            }
        }
        if (mainrainbow)
        {
            if (maincolor)
            {
                maincolor = false;
            }
            if (mainR >= 0.1f && mainG >= 0.1f && mainB >= 0.1f)
            {
                mainR = 0f;
                mainG = 0f;
                mainB = 0f;
            }
            if (mainstep == 0)
            {
                if (mainR >= 0.999f)
                {
                    mainstep++;
                }
                else
                {
                    mainR = mainR + mainspeed;
                }
            }
            if (mainstep == 1)
            {
                if (mainG >= 0.999f)
                {
                    mainstep++;
                }
                else
                {
                    mainG = mainG + mainspeed;
                }
            }
            if (mainstep == 2)
            {
                if (mainR <= 0.001f)
                {
                    mainstep++;
                }
                else
                {
                    mainR = mainR - mainspeed;
                }
            }
            if (mainstep == 3)
            {
                if (mainB >= 0.999f)
                {
                    mainstep++;
                }
                else
                {
                    mainB = mainB + mainspeed;
                }
            }
            if (mainstep == 4)
            {
                if (mainG <= 0.001f)
                {
                    mainstep++;
                }
                else
                {
                    mainG = mainG - mainspeed;
                }
            }
            if (mainstep == 5)
            {
                if (mainR >= 0.999f)
                {
                    mainstep++;
                }
                else
                {
                    mainR = mainR + mainspeed;
                }
            }
            if (mainstep == 6)
            {
                if (mainB <= 0.001f)
                {
                    mainstep = 1;
                }
                else
                {
                    mainB = mainB - mainspeed;
                }
            }
        }
        if (banrainbow)
        {
            if (bancolor)
            {
                bancolor = false;
            }
            if (banR >= 0.1f && banG >= 0.1f && banB >= 0.1f)
            {
                banR = 0f;
                banG = 0f;
                banB = 0f;
            }
            if (banstep == 0)
            {
                if (banR >= 0.999f)
                {
                    banstep++;
                }
                else
                {
                    banR = banR + banspeed;
                }
            }
            if (banstep == 1)
            {
                if (banG >= 0.999f)
                {
                    banstep++;
                }
                else
                {
                    banG = banG + banspeed;
                }
            }
            if (banstep == 2)
            {
                if (banR <= 0.001f)
                {
                    banstep++;
                }
                else
                {
                    banR = banR - banspeed;
                }
            }
            if (banstep == 3)
            {
                if (banB >= 0.999f)
                {
                    banstep++;
                }
                else
                {
                    banB = banB + banspeed;
                }
            }
            if (banstep == 4)
            {
                if (banG <= 0.001f)
                {
                    banstep++;
                }
                else
                {
                    banG = banG - banspeed;
                }
            }
            if (banstep == 5)
            {
                if (banR >= 0.999f)
                {
                    banstep++;
                }
                else
                {
                    banR = banR + banspeed;
                }
            }
            if (banstep == 6)
            {
                if (banB <= 0.001f)
                {
                    banstep = 1;
                }
                else
                {
                    banB = banB - banspeed;
                }
            }
        }
        if (skinrainbow)
        {
            if (skincolor)
            {
                skincolor = false;
            }
            if (skinR >= 0.1f && skinG >= 0.1f && skinB >= 0.1f)
            {
                skinR = 0f;
                skinG = 0f;
                skinB = 0f;
            }
            if (skinstep == 0)
            {
                if (skinR >= 0.999f)
                {
                    skinstep++;
                }
                else
                {
                    skinR = skinR + skinspeed;
                }
            }
            if (skinstep == 1)
            {
                if (skinG >= 0.999f)
                {
                    skinstep++;
                }
                else
                {
                    skinG = skinG + skinspeed;
                }
            }
            if (skinstep == 2)
            {
                if (skinR <= 0.001f)
                {
                    skinstep++;
                }
                else
                {
                    skinR = skinR - skinspeed;
                }
            }
            if (skinstep == 3)
            {
                if (skinB >= 0.999f)
                {
                    skinstep++;
                }
                else
                {
                    skinB = skinB + skinspeed;
                }
            }
            if (skinstep == 4)
            {
                if (skinG <= 0.001f)
                {
                    skinstep++;
                }
                else
                {
                    skinG = skinG - skinspeed;
                }
            }
            if (skinstep == 5)
            {
                if (skinR >= 0.999f)
                {
                    skinstep++;
                }
                else
                {
                    skinR = skinR + skinspeed;
                }
            }
            if (skinstep == 6)
            {
                if (skinB <= 0.001f)
                {
                    skinstep = 1;
                }
                else
                {
                    skinB = skinB - skinspeed;
                }
            }
        }
        if (playerrainbow)
        {
            if (playercolor)
            {
                playercolor = false;
            }
            if (playerR >= 0.1f && playerG >= 0.1f && playerB >= 0.1f)
            {
                playerR = 0f;
                playerG = 0f;
                playerB = 0f;
            }
            if (playerstep == 0)
            {
                if (playerR >= 0.999f)
                {
                    playerstep++;
                }
                else
                {
                    playerR = playerR + playerspeed;
                }
            }
            if (playerstep == 1)
            {
                if (playerG >= 0.999f)
                {
                    playerstep++;
                }
                else
                {
                    playerG = playerG + playerspeed;
                }
            }
            if (playerstep == 2)
            {
                if (playerR <= 0.001f)
                {
                    playerstep++;
                }
                else
                {
                    playerR = playerR - playerspeed;
                }
            }
            if (playerstep == 3)
            {
                if (playerB >= 0.999f)
                {
                    playerstep++;
                }
                else
                {
                    playerB = playerB + playerspeed;
                }
            }
            if (playerstep == 4)
            {
                if (playerG <= 0.001f)
                {
                    playerstep++;
                }
                else
                {
                    playerG = playerG - playerspeed;
                }
            }
            if (playerstep == 5)
            {
                if (playerR >= 0.999f)
                {
                    playerstep++;
                }
                else
                {
                    playerR = playerR + playerspeed;
                }
            }
            if (playerstep == 6)
            {
                if (playerB <= 0.001f)
                {
                    playerstep = 1;
                }
                else
                {
                    playerB = playerB - playerspeed;
                }
            }
        }
        if (FPS)
        {
            GameObject obj2 = GameObject.Find("LabelInfoTopRight");
            if (obj2 != null)
            {
                float fpsmeter2 = 1f / Time.deltaTime;
                int fpsmeter = (int)fpsmeter2;
                UILabel component = obj2.GetComponent<UILabel>();
                if (!component.text.Contains("FPS:"))
                {
                    component.text = component.text + "\n[000000]FPS: [-]";
                    if (fpsmeter > 150)
                    {
                        component.text = component.text + "[0000FF]" + fpsmeter + "[-]";
                    }
                    else if (fpsmeter > 60)
                    {
                        component.text = component.text + "[00FF00]" + fpsmeter + "[-]";
                    }
                    else if (fpsmeter > 25)
                    {
                        component.text = component.text + "[FFFF00]" + fpsmeter + "[-]";
                    }
                    else
                    {
                        component.text = component.text + "[FF0000]" + fpsmeter + "[-]";
                    }
                }
            }
        }
        if (Application.targetFrameRate != prefFrames)
        {
            prefFrames = Application.targetFrameRate;
            PlayerPrefs.SetInt("TargetFPS", Application.targetFrameRate);
        }
        if (damage != prefDamage)
        {
            prefDamage = damage;
            if (damage)
            {
                PlayerPrefs.SetString("Damage", "true");
            }
            else
            {
                PlayerPrefs.SetString("Damage", "false");
            }
        }
        if (speed != prefSpeed)
        {
            prefSpeed = speed;
            if (speed)
            {
                PlayerPrefs.SetString("Speed", "true");
            }
            else
            {
                PlayerPrefs.SetString("Speed", "false");
            }
        }
        if (FPS != prefFPS)
        {
            prefFPS = FPS;
            if (FPS)
            {
                PlayerPrefs.SetString("FPS", "true");
            }
            else
            {
                PlayerPrefs.SetString("FPS", "false");
            }
        }/*
        if (IN_GAME_MAIN_CAMERA.fly != prefFlight)
        {
            prefFlight = IN_GAME_MAIN_CAMERA.fly;
            if (IN_GAME_MAIN_CAMERA.fly)
            {
                PlayerPrefs.SetString("Fly", "true");
            }
            else
            {
                PlayerPrefs.SetString("Fly", "false");
            }
        }*/
        if (InRoomChat.candyshower != prefShower)
        {
            prefShower = InRoomChat.candyshower;
            if (InRoomChat.candyshower)
            {
                PlayerPrefs.SetString("Shower", "true");
            }
            else
            {
                PlayerPrefs.SetString("Shower", "false");
            }
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            toggle = !toggle;
        }
        if (PhotonNetwork.inRoom)
        {
            if (PhotonNetwork.isMasterClient && FengGameManagerMKII.flight != flight)
            {
                flight = FengGameManagerMKII.flight;
                FengGameManagerMKII.MKII.CandyModUsersOnly("flightToggle", "All", new object[] { FengGameManagerMKII.flight });
            }
        }
    }
    public void OnGUI()
    {
        if (toggle)
        {
            GUI.backgroundColor = new Color(1f, 1f, 1f, 255f);
            if (maincolor || mainrainbow)
            {
                GUI.backgroundColor = new Color(mainR, mainG, mainB, 255f);
            }
            if (mainvis)
            {
                GUIRect = GUI.Window(69, GUIRect, this.MainBody, "" + DateTime.Now);
            }
            else
            {
                GUIRect = GUI.Window(69, GUIRect, this.MainBody, "" + DateTime.Now, "");
            }
            if (mainskin)
            {
                GUI.DrawTexture(GUIRect, mainguitex);
            }
        }
        if (banList && PhotonNetwork.isMasterClient)
        {
            GUI.backgroundColor = new Color(1f, 1f, 1f, 255f);
            if (bancolor || banrainbow)
            {
                GUI.backgroundColor = new Color(banR, banG, banB, 255f);
            }
            if (banvis)
            {
                BanRect = GUI.Window(70, BanRect, this.BanGUI, "Ban List");
            }
            else
            {
                BanRect = GUI.Window(70, BanRect, this.BanGUI, "Ban List", "");
            }
            if (banskin)
            {
                GUI.DrawTexture(BanRect, banguitex);
            }
        }
        if (playerListGUI && PhotonNetwork.inRoom)
        {
            GUI.backgroundColor = new Color(1f, 1f, 1f, 255f);
            if (playercolor || playerrainbow)
            {
                GUI.backgroundColor = new Color(playerR, playerG, playerB, 255f);
            }
            if (playervis)
            {
                PlayerRect = GUI.Window(71, PlayerRect, this.PlayerGUI, "Player Info");
            }
            else
            {
                PlayerRect = GUI.Window(71, PlayerRect, this.PlayerGUI, "Player Info", "");
            }
            if (playerskin)
            {
                GUI.DrawTexture(PlayerRect, playertex);
            }
        }
        if (skins)
        {
            GUI.backgroundColor = new Color(1f, 1f, 1f, 255f);
            if (skincolor || skinrainbow)
            {
                GUI.backgroundColor = new Color(skinR, skinG, skinB, 255f);
            }
            if (skinvis)
            {
                SkinRect = GUI.Window(72, SkinRect, this.SkinGUI, "Skins");
            }
            else
            {
                SkinRect = GUI.Window(72, SkinRect, this.SkinGUI, "Skins", "");
            }
            if (skinskin)
            {
                GUI.DrawTexture(SkinRect, skinguitex);
            }
        }
    }
}