




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections;

public class serverList2 : UnityEngine.MonoBehaviour
{
    public static string joinability1 = "";
    public static Texture2D backgroundTex;
    public static Texture2D blackBox;
    public static int filterint = 0;
    float timer = Time.time;

    public void Start()
    {
        base.StartCoroutine(this.loadBackground());
    }
    public IEnumerator loadBackground()
    {
        blackBox = FengGameManagerMKII.candytextures[18];
        backgroundTex = FengGameManagerMKII.candytextures[19];
        WWW background = new WWW("http://i.imgur.com/OFzVOkO.png");
        yield return background;
        backgroundTex = background.texture;
        WWW black = new WWW("http://i.imgur.com/91ZJ7I6.png");
        yield return black;
        backgroundTex = FengGameManagerMKII.candytextures[19];
        blackBox = FengGameManagerMKII.candytextures[18];
    }
    public void OnJoinedRoom()
    {
        FengGameManagerMKII.serverConnected = false;
    }
    public void serverList(int ID)
    {
        GUILayout.BeginVertical();
        GUILayout.Space(1);
        GUILayout.BeginHorizontal();
        a.normal.background = blackBox;
        a.alignment = TextAnchor.MiddleCenter;
        a.hover.textColor = Color.black;
        GUIStyle b = new GUIStyle();
        b.normal.background = blackBox;
        b.alignment = TextAnchor.MiddleCenter;
        b.hover.textColor = Color.black;
        b.hover.background = Texture2D.whiteTexture;
        GUILayout.Space(Screen.width / 125);
        if (GUILayout.Button("Back", b, GUILayout.Height(Screen.height/15)))
        {
            NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiStart, true);
            NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiROOM, false);
            PhotonNetwork.Disconnect();
            FengGameManagerMKII.serverConnected = false;
        }/*
        if (GUILayout.Button("Server", new GUILayoutOption[0]))
        {
            Server = !Server;
        }*/
        GUILayout.Space(1);
        if (UIMainReferences.version != "01042015")
        {
            if (GUILayout.Button("Normal Server", b, GUILayout.Height(Screen.height/15)))
            {
                PhotonNetwork.Disconnect();
                UIMainReferences.version = "01042015";
                PhotonNetwork.ConnectToMaster("app-us.exitgamescloud.com", 0x13bf, FengGameManagerMKII.applicationId, UIMainReferences.version);
            }
        }
        else
        {
            if (GUILayout.Button("Candy Server", b, GUILayout.Height(Screen.height/15)))
            {
                PhotonNetwork.Disconnect();
                UIMainReferences.version = "alz41ZVE9eYgWWdn6eAcaXASpstDrshAjegSSjChW9VTQcKPoHGROQ31GaKQ=";
                PhotonNetwork.ConnectToMaster("app-us.exitgamescloud.com", 0x13bf, FengGameManagerMKII.applicationId, UIMainReferences.version);
            }
        }
        GUILayout.Space(1);
        if (GUILayout.Button("Create Room", b, GUILayout.Height(Screen.height/15)))
        {
            Create = !Create;
        }
        a.normal.background = Texture2D.blackTexture;
        if (Time.time - timer > .15f)
        {
            a.hover.background = (UnityEngine.Random.Range(0, 4) < 1 ? Texture2D.whiteTexture : UnityEngine.Random.Range(0, 4) < 1 ? FengGameManagerMKII.candytextures[14] : UnityEngine.Random.Range(0, 4) < 2 ? FengGameManagerMKII.candytextures[15] : UnityEngine.Random.Range(0, 4) < 2 ? FengGameManagerMKII.candytextures[16] : FengGameManagerMKII.candytextures[17]);
            timer = Time.time;
        }
        GUILayout.Label("", GUILayout.Width(Screen.width / 150));
        a.normal.background = blackBox;
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (filterRoom.Count == 0)
        {
            vSliderValue = GUI.BeginScrollView(new Rect(Convert.ToSingle(serverRect.x / 7), Convert.ToSingle(serverRect.y / 1.5), Convert.ToSingle(Screen.width / 1.2), Convert.ToSingle(Screen.height / 1.35)), vSliderValue, new Rect(0, 0, 0, 20 * PhotonNetwork.GetRoomList().Length + 4));
        }
        else
        {
            vSliderValue = GUI.BeginScrollView(new Rect(Convert.ToSingle(serverRect.x / 7), Convert.ToSingle(serverRect.y / 1.5), Convert.ToSingle(Screen.width / 1.2), Convert.ToSingle(Screen.height / 1.35)), vSliderValue, new Rect(0, 0, 0, 20 * filterRoom.Count + 4));
        }
        filter = GUILayout.TextField(filter, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        enabledFilters2 = "";
        foreach (string str in enabledFilters)
        {
            if (enabledFilters2 == "")
            {
                enabledFilters2 = str;
            }
            else
            {
                enabledFilters2 = enabledFilters2 + ", " + str;
            }
        }
        if (filterRoom.Count != 0)
        {
            GUILayout.Label("Rooms: " + filterRoom.Count + "/" + PhotonNetwork.GetRoomList().Length + "  Players Online: " + PhotonNetwork.countOfPlayers, new GUILayoutOption[0]);
        }
        if (filterRoom.Count == 0)
        {
            GUILayout.Label("Rooms: " + PhotonNetwork.GetRoomList().Length + "/" + PhotonNetwork.GetRoomList().Length + "  Players Online: " + PhotonNetwork.countOfPlayers, new GUILayoutOption[0]);
        }
        GUILayout.BeginHorizontal();
        joinability = GUILayout.Toggle(joinability, "Joinability", new GUILayoutOption[0]);
        passwords = GUILayout.Toggle(passwords, "No Passwords", new GUILayoutOption[0]);
        roomFull = GUILayout.Toggle(roomFull, "Hide Full Rooms", new GUILayoutOption[0]);
        if (filterAlph = GUILayout.Toggle(filterAlph, "Alphabetical", new GUILayoutOption[0]))
        {
            if (filterint != 2)
            {
                filterint = 2;
                filterNum = false;
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        filterN = GUILayout.Toggle(filterN, "Normal", new GUILayoutOption[0]);
        filterH = GUILayout.Toggle(filterH, "Hard", new GUILayoutOption[0]);
        filterA = GUILayout.Toggle(filterA, "Abnormal", new GUILayoutOption[0]);
        if (filterNum = GUILayout.Toggle(filterNum, "Numerical", new GUILayoutOption[0]))
        {
            if (filterint != 1)
            {
                filterint = 1;
                filterAlph = false;
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Label("Enabled Filters: " + enabledFilters2, new GUILayoutOption[0]);
        if (PhotonNetwork.GetRoomList().Length != 0)
        {
            if (filterRoom.Count == 0 && !filterNum && !filterAlph)
            {
                foreach (RoomInfo roomName in PhotonNetwork.GetRoomList())
                {
                    char[] separator = new char[] { "`"[0] };
                    string[] strArray = roomName.name.Split(separator);
                    if (!roomName.open)
                    {
                        joinability1 = "<color=#FF0000>Unjoinable</color>";
                    }
                    else
                    {
                        joinability1 = "<color=#32CD32>Joinable</color>";
                    }
                    if (strArray[5] != "")
                    {
                        roomPassword = "<color=#000000>[PWD]</color>  ";
                    }
                    else
                    {
                        roomPassword = "";
                    }
                    string roomStuff = roomPassword + RCextensions.hexColor(strArray[0]) + " <color=black>║</color> " + strArray[1] + " <color=black>║</color> " + strArray[2] + " <color=black>║</color> " + strArray[4] + " <color=black>║</color> " + roomName.playerCount + "/" + roomName.maxPlayers + " <color=black>║</color> " + joinability1;
                    if (GUILayout.Button(roomStuff, a, new GUILayoutOption[0]))
                    {
                        if (strArray[5] != "")
                        {
                            PWDRoom = roomName.name;
                            passwordScr = true;
                        }
                        else
                        {
                            PhotonNetwork.JoinRoom(roomName.name);
                        }
                    }
                }
            }
            else
            {
                foreach (RoomInfo roomName in filterRoom)
                {
                    char[] separator = new char[] { "`"[0] };
                    string[] strArray = roomName.name.Split(separator);
                    if (!roomName.open)
                    {
                        joinability1 = "<color=#FF0000>Unjoinable</color>";
                    }
                    else
                    {
                        joinability1 = "<color=#32CD32>Joinable</color>";
                    }
                    if (strArray[5] != "")
                    {
                        roomPassword = "<color=#000000>[PWD]</color>  ";
                    }
                    else
                    {
                        roomPassword = "";
                    }
                    string roomStuff = roomPassword + RCextensions.hexColor(strArray[0]) + " <color=black>║</color> " + strArray[1] + " <color=black>║</color> " + strArray[2] + " <color=black>║</color> " + strArray[4] + " <color=black>║</color> " + roomName.playerCount + "/" + roomName.maxPlayers + " <color=black>║</color> " + joinability1;
                    if (GUILayout.Button(roomStuff, a, new GUILayoutOption[0]))
                    {
                        if (strArray[5] != "")
                        {
                            PWDRoom = roomName.name;
                            passwordScr = true;
                        }
                        else
                        {
                            PhotonNetwork.JoinRoom(roomName.name);
                        }
                    }
                }
            }
        }
        GUI.EndScrollView();
        GUILayout.EndVertical();
        //GUI.DragWindow();
    }
    public void serverChange(int ID)
    {
        GUILayout.BeginVertical();
        version = GUILayout.TextField(version, new GUILayoutOption[0]);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Reset", new GUILayoutOption[0]))
        {
            PhotonNetwork.Disconnect();
            UIMainReferences.version = "01042015";
            GameObject.Find("VERSION").GetComponent<UILabel>().text = "01042015";
            PhotonNetwork.ConnectToMaster("app-us.exitgamescloud.com", 0x13bf, FengGameManagerMKII.applicationId, UIMainReferences.version);
        }
        if (GUILayout.Button("Enter", new GUILayoutOption[0]))
        {
            PhotonNetwork.Disconnect();
            UIMainReferences.version = version;
            GameObject.Find("VERSION").GetComponent<UILabel>().text = version;
            PhotonNetwork.ConnectToMaster("app-us.exitgamescloud.com", 0x13bf, FengGameManagerMKII.applicationId, UIMainReferences.version);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
    Vector2 vSliderValue;
    private static string version = "01042015";
    private static string version2 = string.Empty;
    public static Rect serverRect2 = new Rect((Screen.width - 530), (float)(Screen.height - 375), 280, 60);
    public static bool Create;
    public void OnGUI()
    {
        if (FengGameManagerMKII.serverConnected)
        {
            NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiROOM, false);
            GUIStyle a = new GUIStyle();
            a.normal.background = backgroundTex;
            /*if (Server)
            {
                serverRect2 = GUI.Window(102, serverRect2, this.serverChange, "<color=#000000>Server</color>");
            }*/
            if (Create)
            {
                serverRect = GUI.Window(103, serverRect, this.createRoom, "", a);
            }
            if (!Create && !passwordScr)
            {
                serverRect = GUI.Window(101, serverRect, this.serverList, "", a);
            }
            if (passwordScr)
            {
                serverRect = GUI.Window(104, serverRect, this.passwordScreen, "", a);
            }
        }
    }
    public void passwordScreen(int ID)
    {
        GUILayout.BeginVertical();
        char[] separator = new char[] { "`"[0] };
        string[] strArray = PWDRoom.Split(separator);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name: ", new GUILayoutOption[0]);
        GUILayout.Label(RCextensions.hexColor(strArray[0]), new GUILayoutOption[0]);//name
        GUILayout.Label("Map: ", new GUILayoutOption[0]);
        GUILayout.Label(strArray[1], new GUILayoutOption[0]);//map
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Difficulty: ", new GUILayoutOption[0]);
        GUILayout.Label(strArray[2], new GUILayoutOption[0]);//difficulty
        GUILayout.Label("Time: ", new GUILayoutOption[0]);
        GUILayout.Label(strArray[4], new GUILayoutOption[0]);//day
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Password:", new GUILayoutOption[0]);
        pwd = GUILayout.TextField(pwd, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Back", new GUILayoutOption[0]))
        {
            passwordScr = false;
            pwd = "";
        }
        if (Event.current.keyCode == KeyCode.Return)
        {
            if (pwd == new SimpleAES().Decrypt(strArray[5]))
            {
                PhotonNetwork.JoinRoom(PWDRoom);
            }
            passwordScr = false;
            pwd = "";
        }
        if (GUILayout.Button("Join", new GUILayoutOption[0]))
        {
            PhotonNetwork.JoinRoom(PWDRoom);
            if (pwd == new SimpleAES().Decrypt(strArray[5]))
            {
                PhotonNetwork.JoinRoom(PWDRoom);
            }
            passwordScr = false;
            pwd = "";
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }
    public static string PWDRoom;
    public static string pwd = "";
    public static bool passwordScr;
    public static string roomName = "Candy Mod";
    public static int roomMax = 0;
    public static int roomTime = 10;
    public static string roomDifficulty = "normal";
    public static string roomDay = "day";
    public static string roomPass = "";
    public static string roomMap = "The City";
    public static bool normal = true;
    public static bool hard;
    public static bool abnormal;
    public static bool Day = true;
    public static bool Dawn;
    public static bool Night;
    public static int difficultyint = 0;
    public static int dayint = 0;
    //Vector2 vSliderValue3;

    GUIStyle a = new GUIStyle();
    public void createRoom(int ID)
    {
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Room Name: ", new GUILayoutOption[0]);
        roomName = GUILayout.TextField(roomName, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Time: ", new GUILayoutOption[0]);
        roomTime = int.Parse(GUILayout.TextField(roomTime + "", new GUILayoutOption[0]));
        GUILayout.Label("Max Players: ", new GUILayoutOption[0]);
        roomMax = int.Parse(GUILayout.TextField(roomMax + "", new GUILayoutOption[0]));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        if (normal = GUILayout.Toggle(normal, "Normal", new GUILayoutOption[0]))
        {
            if (difficultyint != 0)
            {
                difficultyint = 0;
                hard = false;
                abnormal = false;
            }
        }
        if (hard = GUILayout.Toggle(hard, "Hard", new GUILayoutOption[0]))
        {
            if (difficultyint != 1)
            {
                difficultyint = 1;
                normal = false;
                abnormal = false;
            }
        }
        if (abnormal = GUILayout.Toggle(abnormal, "Abnormal", new GUILayoutOption[0]))
        {
            if (difficultyint != 2)
            {
                difficultyint = 2;
                hard = false;
                normal = false;
            }
        }
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        if (Day = GUILayout.Toggle(Day, "Day", new GUILayoutOption[0]))
        {
            if (dayint != 0)
            {
                dayint = 0;
                Dawn = false;
                Night = false;
            }
        }
        if (Dawn = GUILayout.Toggle(Dawn, "Dawn", new GUILayoutOption[0]))
        {
            if (dayint != 1)
            {
                dayint = 1;
                Night = false;
                Day = false;
            }
        }
        if (Night = GUILayout.Toggle(Night, "Night", new GUILayoutOption[0]))
        {
            if (dayint != 2)
            {
                dayint = 2;
                Dawn = false;
                Day = false;
            }
        }
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Password:", new GUILayoutOption[0]);
        roomPass = GUILayout.TextField(roomPass, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Map: " + roomMap, new GUILayoutOption[0]);
        GUIStyle s = new GUIStyle();
        s.alignment = TextAnchor.MiddleCenter;
        s.normal.background = Texture2D.blackTexture;
        s.border.Add(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 5));
        GUI.backgroundColor = Color.white;
        GUI.color = Color.white;
        GUI.depth = 10;
        GUI.contentColor = Color.white;
        GUILayout.BeginVertical();
        a.alignment = TextAnchor.MiddleCenter;
        a.normal.textColor = Color.black;
        a.normal.background = blackBox;
        if (Time.time - timer > .15f)
        {
            a.hover.background = (UnityEngine.Random.Range(0, 4) < 1 ? Texture2D.whiteTexture : UnityEngine.Random.Range(0, 4) < 2 ? FengGameManagerMKII.candytextures[14] : UnityEngine.Random.Range(0, 4) < 2 ? FengGameManagerMKII.candytextures[15] : UnityEngine.Random.Range(0, 4) < 2 ? FengGameManagerMKII.candytextures[16] : FengGameManagerMKII.candytextures[17]);
            timer = Time.time;
        }
        if (GUILayout.Button("The City I", a, GUILayout.Height(Screen.height/27)))
        {
            roomMap = "The City I";
            /*
            if (LevelInfo.levels == null || LevelInfo.levels.Length == 0)
            {
                LevelInfo.initData();
            }
            else
            {
                GUILayout.BeginVertical();
                foreach (LevelInfo info in LevelInfo.levels)
                {
                    if (!info.name.Contains("[S]") && !info.name.Contains("Cage"))
                    {
                        if (GUILayout.Button(info.name, new GUILayoutOption[0]))
                        {
                            roomMap = info.name;
                        }
                    }
                }
                GUILayout.EndVertical();
            }*/
        }
        if (GUILayout.Button("The City II", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "The City II";
        }
        if (GUILayout.Button("The City III", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "The City III";
        }
        if (GUILayout.Button("The Forest", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "The Forest";
        }
        if (GUILayout.Button("The Forest II", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "The Forest II";
        }
        if (GUILayout.Button("The Forest III", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "The Forest III";
        }
        if (GUILayout.Button("The Forest IV", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "The Forest IV";
        }
        if (GUILayout.Button("CandyMod Balls PVP", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "CandyMod Balls PVP";
        }
        if (GUILayout.Button("Colossal Titan II", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "Colossal Titan II";
        }
        if (GUILayout.Button("Annie II", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "Annie II";
        }
        if (GUILayout.Button("Trost II", a, GUILayout.Height(Screen.height / 27)))
        {
            roomMap = "Trost II";
        }
        GUILayout.EndVertical();
        /*vSliderValue3 = GUI.BeginScrollView(new Rect(Convert.ToSingle(serverRect.x / 7), Convert.ToSingle(serverRect.y / 6), Convert.ToSingle(Screen.width / 6), Convert.ToSingle(Screen.height / 5)), vSliderValue3, new Rect(0, 4 * LevelInfo.levels.Length, 0, 0));
        foreach (LevelInfo level in LevelInfo.levels)
        {
            if (GUILayout.Button(level.name, new GUILayoutOption[0]))
            {
                roomMap = level.name;
            }
        }
        GUI.EndScrollView();*/
        //Either add a scrollview inside of the gui, or make a seperate gui pop up with a list
        //or have different buttons, or a drop down menu
        GUILayout.EndVertical();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Back", GUILayout.Height(Screen.height / 8)))
        {
            Create = false;
        }
        if (GUILayout.Button("Create", GUILayout.Height(Screen.height / 8)))
        {
            if (roomPass.Length > 0)
            {
                roomPass = new SimpleAES().Encrypt(roomPass);
            }
            if (roomMax > 255)
            {
                roomMax = 255;
            }
            if (roomTime > 680036488)
            {
                roomTime = 680036488;
            }
            roomDifficulty = !hard ? (!abnormal ? "normal" : "abnormal") : "hard";
            roomDay = !Dawn ? (!Night ? "day" : "night") : "dawn";
            PhotonNetwork.CreateRoom(string.Concat(new object[] { roomName, "`", roomMap, "`", roomDifficulty, "`", roomTime, "`", roomDay, "`", roomPass, "`", UnityEngine.Random.Range(0, 0xc350) }), true, true, roomMax);
            Create = false;
            roomPass = new SimpleAES().Decrypt(roomPass);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        if (!Day && !Dawn && !Night)
        {
            if (dayint == 1)
            {
                Dawn = true;
            }
            if (dayint == 2)
            {
                Night = true;
            }
            if (dayint == 3)
            {
                Day = true;
            }
        }
        if (!normal && !hard && !abnormal)
        {
            if (difficultyint == 1)
            {
                hard = true;
            }
            if (difficultyint == 2)
            {
                abnormal = true;
            }
            if (difficultyint == 3)
            {
                normal = true;
            }
        }
    }

    public static bool passwords = false;
    public static bool roomFull = false;
    public static bool joinability = false;
    private string filter = string.Empty;
    public static List<RoomInfo> filterRoom;
    public static List<string> enabledFilters;
    public static string enabledFilters2;
    public static bool Server;
    public static string roomPassword = "";
    public static bool filterN;
    public static bool filterH;
    public static bool filterA;
    public static bool filterAlph;
    public static bool filterNum;

    public static Rect serverRect = new Rect(Convert.ToSingle(Screen.width / 7), Convert.ToSingle(Screen.height / 10), Convert.ToSingle(Screen.width / 1.1), Convert.ToSingle(Screen.height / 1.3));
    public void Update()
    {
        if (serverRect.height != Convert.ToSingle(Screen.height / 1.2) || serverRect.width != Convert.ToSingle(Screen.width / 1.18))
        {
            serverRect = new Rect(Convert.ToSingle(Screen.width / 14), Convert.ToSingle(Screen.height / 10), Convert.ToSingle(Screen.width / 1.18), Convert.ToSingle(Screen.height / 1.2));
        }
        enabledFilters = new List<string>();
        if (passwords)
        {
            enabledFilters.Add("No Passwords");
        }
        if (joinability)
        {
            enabledFilters.Add("Joinability");
        }
        if (roomFull)
        {
            enabledFilters.Add("RoomFull");
        }
        if (filterN)
        {
            enabledFilters.Add("Normal");
        }
        if (filterH)
        {
            enabledFilters.Add("Hard");
        }
        if (filterA)
        {
            enabledFilters.Add("Abnormal");
        }
        if (filterAlph)
        {
            enabledFilters.Add("Alphabetical");
        }
        if (filterNum)
        {
            enabledFilters.Add("Numerical");
        }
        //also add alphabetical order, map order, map, and player count order both ways. Also a custom password screen so they can't join protected lobbies
        filterRoom = new List<RoomInfo>();
        if (filter != string.Empty || filterN || filterA || filterH || passwords || joinability || roomFull || filterNum || filterAlph)
        {
            foreach (RoomInfo info in PhotonNetwork.GetRoomList())
            {
                char[] separator = new char[] { "`"[0] };
                string[] strArray = info.name.Split(separator);
                if (info.name.ToUpper().Contains(this.filter.ToUpper()))
                {
                    if (roomFull && info.playerCount < info.maxPlayers)
                    {
                        if (joinability && info.open)
                        {
                            if (!passwords)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                            else if (strArray[5] == string.Empty)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                        }
                        else if (!joinability)
                        {
                            if (!passwords)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                            else if (strArray[5] == string.Empty)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                        }
                    }
                    else if (!roomFull)
                    {
                        if (joinability && info.open)
                        {
                            if (!passwords)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                            else if (strArray[5] == string.Empty)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                        }
                        else if (!joinability)
                        {
                            if (!passwords)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                            else if (strArray[5] == string.Empty)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                        }
                    }
                }
                else if (this.filter == "")
                {
                    if (roomFull && info.playerCount < info.maxPlayers)
                    {
                        if (joinability && info.open)
                        {
                            if (!passwords)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                            else if (strArray[5] == string.Empty)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                        }
                        else if (!joinability)
                        {
                            if (!passwords)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                            else if (strArray[5] == string.Empty)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                        }
                    }
                    else if (!roomFull)
                    {
                        if (joinability && info.open)
                        {
                            if (!passwords)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                            else if (strArray[5] == string.Empty)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                        }
                        else if (!joinability)
                        {
                            if (!passwords)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                            else if (strArray[5] == string.Empty)
                            {
                                if (filterN && strArray[2] == "normal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterH && strArray[2] == "hard")
                                {
                                    filterRoom.Add(info);
                                }
                                if (filterA && strArray[2] == "abnormal")
                                {
                                    filterRoom.Add(info);
                                }
                                if (!filterN && !filterH && !filterA)
                                {
                                    filterRoom.Add(info);
                                }
                            }
                        }
                    }
                }
            }
        }
        if (filterAlph)
        {
            filterRoom = filterRoom.OrderBy(w => w.name).ToList();
        }
        if (filterNum)
        {
            filterRoom = filterRoom.OrderBy(w => w.playerCount).ToList();
        }
        //filterRoom.Sort(); works better with strings.
    }
}


