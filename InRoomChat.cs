using ExitGames.Client.Photon;
using Photon;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using Xft;
using RedSkies;

public class InRoomChat : Photon.MonoBehaviour
{
    private GUIStyle ayastyle;
    private GUIStyle urlStyle;
    private bool AlignBottom = true;
    public static readonly string ChatRPC = "Chat";
    public static Rect GuiRect = new Rect(0f, 100f, 300f, 470f);
    public static Rect GuiRect2 = new Rect(30f, 575f, 300f, 25f);
    private string inputLine = string.Empty;
    public bool IsVisible = true;
    public static List<string> messages = new List<string>();
    private Vector2 scrollPos = Vector2.zero;
    public static GameObject stickpl = new GameObject();
    public AudioClip musc = null;
    bool played = false;
    public static bool isloading = false;
    float cliplength = 0;
    float cliptime = Time.time;
    public bool isplaying = false;
    public AudioSource audioSource;
    float volume = 1;
    public static bool receievemusic = true;
    string lastplayed = "";
    public static bool group;
    bool clicked = false;
    string clickedmessage = String.Empty;
    public static bool candyshower = true;
    public static GameObject MultiplayerManager;
    public static string[] linkss = new string[9];
    public static string[] linksss = new string[9];
    public static string[] linkssss = new string[9];
    public static string[] linksssss = new string[9];
    public static List<string> playlist = new List<string>();
    public static int playlistplaying;
    public static bool isquidditch = false;
    public static bool joined;/*
    public static bool receieved = false;
    float receievetime = Time.time;*/
    public static float titanSizes;
    public static float titanSizes2;

    public static InRoomChat Chat;
    internal static int duelKills;
    internal static int duelTime;
    internal static int duelTimeOriginal;
    private static int titanSize;
    private static int titanSize2;
    internal bool requestpending;
    internal static bool grouping;
    internal static InRoomGroup currentgroup;
    internal static List<InRoomGroup> Groups;
    private Dictionary<int, string[]> grouprequests = new Dictionary<int, string[]>();
    private Dictionary<int, PhotonPlayer> request = new Dictionary<int, PhotonPlayer>();
    internal static string chatcolor = "FFFF00";
    WebRequest requestweb = WebRequest.Create("http://pastebin.com/edit.php?i=a7DFucrP");
    static String ftpurl = "ftp://krabynetwork.v-info.info/"; // e.g. ftp://serverip/foldername/foldername
    static String ftpusername = "username"; // e.g. username
    static String ftppassword = "pass"; // e.g. password
    public static float number = 1;
    float hehecount = Time.time;
    int inthehe = 0;

    public void UploadFileToFtp()
    {
        //Create a file to upload to ftp
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpurl + "Features.txt");
        request.Method = WebRequestMethods.Ftp.UploadFile;

        // This example assumes the FTP site uses anonymous logon.
        request.Credentials = new NetworkCredential(ftpusername, ftppassword);

        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        Byte[] bytes = encoding.GetBytes(" ");

        //and now plug that into your example
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();

        FtpWebResponse response = (FtpWebResponse)request.GetResponse();

        this.AddLine("Upload File Complete, status {0}" + response.StatusDescription);

        response.Close();
    }

    public void Awake()
    {
        FengGameManagerMKII.GuiText = FengGameManagerMKII.GuiText + "t";
        InRoomChat.grouping = false;
        InRoomChat.Groups = new List<InRoomGroup>();
        InRoomChat.GuiRect = new Rect(0f, 170f, 300f, 400f);
        InRoomChat.GuiRect2 = new Rect(30f, 575f, 300f, 25f);
        InRoomChat.messages = new List<string>();
        InRoomChat.messages = new List<string>();
        InRoomChat.duelTime = 0;
        InRoomChat.duelKills = 0;
        InRoomChat.duelTimeOriginal = 0;
        InRoomChat.titanSize = 0;
        InRoomChat.titanSize2 = 0;
        audioSource = GameObject.Find("MainCamera").AddComponent<AudioSource>();
        MultiplayerManager = GameObject.Find("MultiplayerManager");
    }

    public static void Notify(string newLine)
    {
        if (InRoomChat.grouping)
        {
            InRoomGroup inRoomGroup = InRoomChat.currentgroup;
            string[] strArrays = new string[] { "<color=", InRoomChat.chatcolor, ">", newLine, "</color>" };
            inRoomGroup.Chat(string.Concat(strArrays));
            return;
        }
        List<string> strs = InRoomChat.messages;
        string[] strArrays1 = new string[] { "<color=", InRoomChat.chatcolor, ">", newLine, "</color>" };
        strs.Add(string.Concat(strArrays1));
    }

    public static InRoomGroup FindGroupWithPlayer(PhotonPlayer player)
    {
        return InRoomChat.Groups.FirstOrDefault<InRoomGroup>((InRoomGroup room) =>
        {
            if (!(room != null) || room.participants == null)
            {
                return false;
            }
            return room.participants.Contains(player);
        });
    }

    internal static bool EndDuel(string duel)
    {
        string str = duel;
        string str1 = str;
        if (str != null)
        {
            switch (str1)
            {
                case "speedkill":
                case "speed":
                    {
                        InRoomChat.duelKills = 0;
                        FengGameManagerMKII.settings[0] = false;
                        break;
                    }
                case "damage":
                case "dmg":
                    {
                        InRoomChat.duelTime = 0;
                        InRoomChat.duelTimeOriginal = 0;
                        FengGameManagerMKII.settings[72] = false;
                        break;
                    }
                case "total":
                case "totaldmg":
                case "totaldamage":
                    {
                        FengGameManagerMKII.settings[73] = 0;
                        break;
                    }
            }
        }
        if (IN_GAME_MAIN_CAMERA.MULTIPLAYER && FengGameManagerMKII.PView != null)
        {
            FengGameManagerMKII.PView.RPC("modeDUEL", PhotonTargets.All, false, 0);
        }
        return false;
    }

    public static void Finished(string message)
    {
        message = string.Concat("<color=yellow>", message, "</color>");
        if (!InRoomChat.grouping || !(InRoomChat.currentgroup != null))
        {
            InRoomChat.addLINE(message, null, false, true);
            return;
        }
        InRoomGroup inRoomGroup = InRoomChat.currentgroup;
        string[] strArrays = new string[] { "<color=", InRoomChat.chatcolor, ">", message, "</color>" };
        inRoomGroup.Chat(string.Concat(strArrays));
    }

    public static void Error(string message)
    {
        message = string.Concat("<color=orange>error:</color><b>", message, "</b>");
        if (!InRoomChat.grouping || !(InRoomChat.currentgroup != null))
        {
            InRoomChat.addLINE(message, null, false, true);
            return;
        }
        InRoomGroup inRoomGroup = InRoomChat.currentgroup;
        string[] strArrays = new string[] { "<color=", InRoomChat.chatcolor, ">", message, "</color>" };
        inRoomGroup.Chat(string.Concat(strArrays));
    }

    public static void addLINE(string newLine, PhotonPlayer player = null, bool inGroup = false, bool hasSender = true)
    {
        if (!hasSender)
        {
            if (InRoomChat.grouping)
            {
                InRoomGroup inRoomGroup = InRoomChat.currentgroup;
                string[] strArrays = new string[] { "<color=", InRoomChat.chatcolor, ">", newLine, "</color>" };
                inRoomGroup.Chat(string.Concat(strArrays));
                return;
            }
            List<string> strs = InRoomChat.messages;
            string[] strArrays1 = new string[] { "<color=", InRoomChat.chatcolor, ">", newLine, "</color>" };
            strs.Add(string.Concat(strArrays1));
            return;
        }
        if (player != null && !player.isLocal && InRoomChat.Groups.Count > 0 && !player.RS && !player.redskies)
        {
            InRoomGroup inRoomGroup1 = InRoomChat.FindGroupWithPlayer(player);
            if (inRoomGroup1 != null)
            {
                string[] strArrays2 = new string[] { "<color=", InRoomChat.chatcolor, ">", newLine, "</color>" };
                inRoomGroup1.Chat(string.Concat(strArrays2));
            }
        }
        List<string> strs1 = InRoomChat.messages;
        string[] strArrays3 = new string[] { "<color=", InRoomChat.chatcolor, ">", newLine, "</color>" };
        strs1.Add(string.Concat(strArrays3));
    }

    public static void addLINE(string newLine)
    {
        messages.Add(newLine);
    }

    public void AddLine(string newLine)
    {
        messages.Add(newLine);
    }

    public void OnGUI()
    {/*
        if (!receieved)
        {
            if (Time.time - this.receievetime > .2f)
            {
                receieved = true;
                FengGameManagerMKII.isCandyMasterClient = true;
                addLINE("I'm masterclient");
            }
        }*/
        if (this.IsVisible && (PhotonNetwork.connectionStateDetailed == PeerStates.Joined))
        {
            if ((Event.current.type == EventType.KeyDown) && ((Event.current.keyCode == KeyCode.KeypadEnter) || (Event.current.keyCode == KeyCode.Return)))
            {
                if (!string.IsNullOrEmpty(this.inputLine))
                {
                    if (this.inputLine == "\t")
                    {
                        this.inputLine = string.Empty;
                        GUI.FocusControl(string.Empty);
                        return;
                    }
                    if (this.inputLine.StartsWith("/help 1"))
                    {
                        addLINE("<color=#ffcc00>/restart</color>");
                        addLINE("<color=#ffcc00>/play + url</color>");
                        addLINE("<color=#ffcc00>/stop</color>");
                        addLINE("<color=#ffcc00>/free</color>");
                        addLINE("<color=#ffcc00>/revive</color>");
                        addLINE("<color=#ffcc00>/on</color>");
                        addLINE("<color=#ffcc00>/off</color>");
                        addLINE("<color=#ffcc00>/revive</color>");
                        addLINE("<color=#ffcc00>/pm-id-msg</color>");
                        addLINE("<color=#ffcc00>/kick</color>");
                    }
                    if (this.inputLine.StartsWith("/help 2"))
                    {
                        addLINE("<color=#ffcc00>/bounce</color>");
                        addLINE("<color=#ffcc00>/time</color>");
                        addLINE("<color=#ffcc00>/day, dawn, night</color>");
                        addLINE("<color=#ffcc00>/wave</color>");
                        addLINE("<color=#ffcc00>/group on/off</color>");
                    }
                    if (this.inputLine.StartsWith("/group"))
                    {
                        if (this.inputLine.Substring(7) == "off")
                        {
                            group = false;
                            addLINE("<color=#FFFF00>-+=Group Chat Off=+-</color>");
                        }
                        if (this.inputLine.Substring(7) == "on")
                        {
                            group = true;
                            addLINE("<color=#FFFF00>-+=Group Chat On=+-</color>");
                        }
                    }
                    if (this.inputLine.StartsWith("/wave"))
                    {
                        object[] objArray8 = new object[] { "<color=#A8FF24>The Wave Is Now Set To " + Convert.ToInt32(this.inputLine.Remove(0, 6)) + "</color>", string.Empty };
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray8);
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().wave = Convert.ToInt32(this.inputLine.Remove(0, 6));
                    }
                    if (this.inputLine.StartsWith("/time"))
                    {
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().addTime(Convert.ToSingle(this.inputLine.Substring(6)));
                    }
                    if (FengGameManagerMKII.isCandyMasterClient)
                    {
                        if (this.inputLine.StartsWith("/day"))
                        {
                            MultiplayerManager.GetComponent<FengGameManagerMKII>().CandyModUsersOnly("ChangeTimeMode", "All", new object[] { 0 });
                        }
                        if (this.inputLine.StartsWith("/dawn"))
                        {
                            MultiplayerManager.GetComponent<FengGameManagerMKII>().CandyModUsersOnly("ChangeTimeMode", "All", new object[] { 1 });
                        }
                        if (this.inputLine.StartsWith("/night"))
                        {
                            MultiplayerManager.GetComponent<FengGameManagerMKII>().CandyModUsersOnly("ChangeTimeMode", "All", new object[] { 2 });
                        }
                    }
                    if (this.inputLine.StartsWith("/max"))
                    {
                        PhotonNetwork.room.maxPlayers = int.Parse(this.inputLine.Remove(0, 5));
                        object[] objArray10 = new object[] { "<b><color=#00ffff>Max Players Are Now Set To " + this.inputLine.Remove(0, 5) + "</color></b>", string.Empty };
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray10);
                    }
                    if (this.inputLine.StartsWith("/hide"))
                    {
                        if (PhotonNetwork.isMasterClient)
                        {
                            HideAndSeek.justenabled = true;
                        }
                    }
                    if (this.inputLine.StartsWith("/skin"))
                    {
                        FengGameManagerMKII.MKII.CandyModUsersOnly("SkinRPC", "All", new object[] { PhotonNetwork.player.ID, InRoomChat.linkss });
                    }
                    if (this.inputLine.StartsWith("/anim"))
                    {
                        FengGameManagerMKII.MKII.CandyModUsersOnly("AnimateSkinRPC", "All", new object[] { PhotonNetwork.player.ID, InRoomChat.linkss, InRoomChat.linksss, InRoomChat.linkssss, InRoomChat.linksssss });
                    }
                    if ((this.inputLine == "/restart") && PhotonNetwork.isMasterClient)
                    {
                        this.inputLine = string.Empty;
                        GUI.FocusControl(string.Empty);
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().restartGame(false);
                        return;
                    }
                    if (this.inputLine.StartsWith("/num "))
                    {
                        number = Convert.ToSingle(inputLine.Remove(0, 5));
                    }
                    if (this.inputLine.StartsWith("/musicon"))
                    {
                        if (!PhotonNetwork.isMasterClient)
                        {
                            CandyModUsersOnly("RequestMusic", "All", new object[] { PhotonNetwork.player.ID });
                            //base.photonView.RPC("RequestMusic", PhotonTargets.All, new object[] { PhotonNetwork.player.ID });
                            receievemusic = true;
                        }
                    }
                    if (this.inputLine.StartsWith("/play"))
                    {
                        if (!isplaying && !isloading)
                        {
                            string newinput = this.inputLine.Remove(0, 6);
                            double volume1 = .5;
                            if (!newinput.StartsWith("ht"))
                            {
                                volume1 = Convert.ToDouble(newinput.Remove(newinput.IndexOf(" ")));
                                newinput = newinput.Remove(0, newinput.IndexOf(" ") + 1);
                            }
                            volume = (float)volume1;
                            string url = newinput;
                            CandyModUsersOnly("SendMusic", "All", new object[] { url });
                            //base.photonView.RPC("SendMusic", PhotonTargets.All, new object[] { url });
                        }
                    }
                    if (this.inputLine.StartsWith("/stop") && PhotonNetwork.isMasterClient)
                    {
                        CandyModUsersOnly("StopMusic", "All", new object[] { });
                        //base.photonView.RPC("StopMusic", PhotonTargets.All, new object[] { });
                    }
                    if (!this.inputLine.StartsWith("/"))
                    {
                        //object[] objArray20 = new object[] { this.inputLine, PlayerPrefs.HasKey("ChatName") ? RCextensions.hexColor(PlayerPrefs.GetString("ChatName")) : IN_GAME_MAIN_CAMERA.chatname };
                        //CandyModUsersOnly("Chat", "All", objArray20);
                        //base.photonView.RPC("Chat", PhotonTargets.All, objArray20);
                    }
                    if (this.inputLine.StartsWith("/agar"))
                    {
                        foreach (GameObject obj1 in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
                        {
                            if (obj1.name.Contains("TREE") || obj1.name.Contains("aot_supply"))
                            {
                                UnityEngine.Object.Destroy(obj1);
                            }
                        }
                        IN_GAME_MAIN_CAMERA.cameraMode = CAMERA_TYPE.TOP;
                        Screen.lockCursor = false;
                    }
                    if (this.inputLine.StartsWith("/login"))
                    {
                        
                    }
                    if (this.inputLine.StartsWith("/shower"))
                    {
                        if (!PlayerPrefs.HasKey("Shower"))
                        {
                            PlayerPrefs.SetString("Shower", "false");
                            candyshower = PlayerPrefs.GetString("Shower") == "true" ? true : false;
                        }
                        else
                        {
                            PlayerPrefs.SetString("Shower", PlayerPrefs.GetString("Shower") == "true" ? "false" : "true");
                            candyshower = PlayerPrefs.GetString("Shower") == "true" ? true : false;
                        }
                    }
                    if (this.inputLine.StartsWith("/free"))
                    {
                        //IN_GAME_MAIN_CAMERA.stuck = false;
                    }
                    if (this.inputLine.StartsWith("/revive"))
                    {
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("respawnHeroInNewRound", PhotonTargets.All, new object[] { });
                    }
                    if (this.inputLine.StartsWith("/off"))
                    {
                        if (!PhotonNetwork.isMasterClient)
                        {
                            if (isplaying)
                                audioSource.Stop();
                            receievemusic = false;
                            isplaying = false;
                            isloading = false;
                            musc = null;
                        }
                    }/*
                    if (this.inputLine.ToLower().StartsWith("/pm "))
                    {
                        int id = Convert.ToInt32(this.inputLine.Substring(4, this.inputLine.IndexOf("(") - 4));
                        string message = this.inputLine.Remove(0, this.inputLine.IndexOf("(") + 1);
                        if (message.EndsWith(")"))
                        {
                            message = message.Remove(message.Length - 1);
                        }
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonPlayer.Find(id), new object[] { "<b><color=#FFCC00>[PM From]</color></b>" + "lel-chan" + ":" + message, "" });
                        addLINE("<b><color=#FFCC00>[PM To ID </color><color=red>" + Convert.ToString(id) + "</color><color=#FFCC00>]</color></b>:" + message);
                    }*/
                    if (this.inputLine.StartsWith("/pm"))
                    {
                        string[] strArray3 = this.inputLine.Split(new char[] { '-' });
                        PhotonPlayer player8 = PhotonPlayer.Find(Convert.ToInt32(strArray3[1]));
                        //MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", player8, new object[] { strArray3[2], "<b><color=#000000>[</color></b><b><color=#ff0000>PM</color></b><b><color=#000000>]</color></b><b><color=#00ffff>From(" + PhotonNetwork.player.ID + ")</color>" + (PlayerPrefs.HasKey("ChatName") ? RCextensions.hexColor(PlayerPrefs.GetString("ChatName")) :  IN_GAME_MAIN_CAMERA.chatname) + "</b>" });
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonNetwork.player, new object[] { strArray3[2], "<b><color=#000000>[</color></b><b><color=#ff0000>PM</color></b><b><color=#000000>]</color></b><b><color=#00ffff>To(" + player8.ID + ")</color></b>" });
                    }
                    if (this.inputLine.StartsWith("/findmod"))
                    {
                        foreach (int int1 in FengGameManagerMKII.cmusers.Keys)
                        {
                            addLINE("" + int1);
                        }
                    }
                    else if (this.inputLine.StartsWith("/osetspawn"))
                    {
                        TITAN.spawnrate = false;
                        object[] objArray8 = new object[] { "<color=#ffcc00>Spawn Rate Is Now Normal</color>", string.Empty };
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray8);
                    }
                    else if (this.inputLine.StartsWith("/setspawn"))
                    {
                        string[] strArray = this.inputLine.Split(new char[] { ' ' });
                        int spawn1 = Convert.ToInt32(strArray[1]);
                        int spawn2 = Convert.ToInt32(strArray[2]);
                        int spawn3 = Convert.ToInt32(strArray[3]);
                        int spawn4 = Convert.ToInt32(strArray[4]);
                        int spawn5 = Convert.ToInt32(strArray[5]);
                        if (spawn1 + spawn2 + spawn3 + spawn4 + spawn5 == 100)
                        {
                            TITAN.spawn1 = spawn1;
                            TITAN.spawn2 = spawn2;
                            TITAN.spawn3 = spawn3;
                            TITAN.spawn4 = spawn4;
                            TITAN.spawn5 = spawn5;
                            TITAN.spawnrate = true;
                            object[] objArray8 = new object[] { "<color=#ffcc00>Spawn Rate Is Now Set To: " + spawn1 + ", " + spawn2 + ", " + spawn3 + ", " + spawn4 + ", " + spawn5 + "</color>", string.Empty };
                            MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray8);
                        }
                        else
                        {
                            addLINE("<color=#ffcc00>Did Not Add Up To 100</color>");
                        }
                    }
                    else if (this.inputLine.StartsWith("/setdamage"))
                    {
                        string[] strArray = this.inputLine.Split(new char[] { ' ' });
                        int dmg = Convert.ToInt32(strArray[1]);
                        TITAN.damage = dmg;
                        FengGameManagerMKII.damage = true;
                        if (Convert.ToInt32(strArray[1]) < 11)
                        {
                            FengGameManagerMKII.damage = false;
                            object[] objArray9 = new object[] { "<color=#ffcc00>Damage Is Now Normal</color>", string.Empty };
                            MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray9);
                        }
                        else
                        {
                            object[] objArray8 = new object[] { "<color=#ffcc00>Damage Is Now Set To: " + dmg + " </color>", string.Empty };
                            MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray8);
                        }
                    }
                    else if (this.inputLine.StartsWith("/osetdamage"))
                    {
                        TITAN.damage = 10;
                        FengGameManagerMKII.damage = false;
                        object[] objArray8 = new object[] { "<color=#ffcc00>Damage Is Now Normal</color>", string.Empty };
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray8);
                    }
                    else if (this.inputLine.StartsWith("/setsize"))
                    {
                        string[] strArray = this.inputLine.Split(new char[] { ' ' });
                        TITAN.size1 = Convert.ToSingle(strArray[1]);
                        TITAN.size2 = Convert.ToSingle(strArray[2]);
                        FengGameManagerMKII.size = true;
                        object[] objArray8 = new object[] { "<color=#ffcc00>Size Is Now: " + TITAN.size1 + ", " + TITAN.size2 + "</color>", string.Empty };
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray8);
                    }
                    else if (this.inputLine.StartsWith("/osetsize"))
                    {
                        TITAN.size1 = 0.5f;
                        TITAN.size2 = 3.5f;
                        FengGameManagerMKII.size = false;
                        object[] objArray8 = new object[] { "<color=#ffcc00>Size Is Now Normal</color>", string.Empty };
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray8);
                    }
                    
                    if (this.inputLine.StartsWith("/kick"))
                    {
                        if (PhotonNetwork.player.isMasterClient)
                        {
                            PhotonNetwork.CloseConnection(PhotonPlayer.Find(Convert.ToInt32(this.inputLine.Remove(0, 5))));
                            PhotonNetwork.DestroyPlayerObjects(PhotonPlayer.Find(Convert.ToInt32(this.inputLine.Remove(0, 5))));
                        }
                    }/*
                    if (this.inputLine.StartsWith("/quidditch"))
                    {
                        if (PhotonNetwork.isMasterClient && GameObject.Find("QBall") == null)
                        {
                            base.photonView.RPC("SetupQuidditch", PhotonTargets.All, new object[] { });
                        }
                    }
                    if (this.inputLine.StartsWith("/qball force_factor "))
                    {
                        if (PhotonNetwork.isMasterClient)
                        {
                            float value = float.Parse(inputLine.Remove(0, 19));
                            base.photonView.RPC("SetQuidditchValue", PhotonTargets.All, new object[] { "force_factor", value });
                        }
                    }
                    if (this.inputLine.StartsWith("/qball gravity_factor "))
                    {
                        if (PhotonNetwork.isMasterClient)
                        {
                            float value = float.Parse(inputLine.Remove(0, 21));
                            base.photonView.RPC("SetQuidditchValue", PhotonTargets.All, new object[] { "gravity_factor", value });
                        }
                    }
                    if (this.inputLine.StartsWith("/qball max_dist "))
                    {
                        if (PhotonNetwork.isMasterClient)
                        {
                            float value = float.Parse(inputLine.Remove(0, 15));
                            base.photonView.RPC("SetQuidditchValue", PhotonTargets.All, new object[] { "max_dist", value });
                        }
                    }
                    if (this.inputLine.StartsWith("/qball ggravity_factor "))
                    {
                        if (PhotonNetwork.isMasterClient)
                        {
                            float value = float.Parse(inputLine.Remove(0, 22));
                            base.photonView.RPC("SetQuidditchValue", PhotonTargets.All, new object[] { "ggravity_factor", value });
                        }
                    }
                    if (this.inputLine.StartsWith("/snitch speed "))
                    {
                        if (PhotonNetwork.isMasterClient)
                        {
                            float value = float.Parse(inputLine.Remove(0, 13));
                            base.photonView.RPC("SetQuidditchValue", PhotonTargets.All, new object[] { "speed", value });
                        }
                    }
                    if (this.inputLine.StartsWith("/snitch dir_time "))
                    {
                        if (PhotonNetwork.isMasterClient)
                        {
                            float value = float.Parse(inputLine.Remove(0, 16));
                            base.photonView.RPC("SetQuidditchValue", PhotonTargets.All, new object[] { "dir_time", value });
                        }
                    }*/
                    if (this.inputLine.StartsWith("/bounce ") && FengGameManagerMKII.isCandyMasterClient)
                    {
                        float bounce1 = 0f;
                        if (Convert.ToInt32(this.inputLine.Remove(0, 8)) != 0)
                        {
                            bounce1 = 1f;
                        }
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().CandyModUsersOnly("Bounce", "All", new object[] { bounce1 });
                        this.inputLine = string.Empty;
                        GUI.FocusControl(string.Empty);
                        return;
                    }
                    if (this.inputLine.StartsWith("/what "))
                    {
                        GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().photonView.RPC("loadskinA", PhotonTargets.All, new object[] { });
                        addLINE(Convert.ToString("done"));
                    }
                    if (!this.inputLine.StartsWith("/") && !group)
                    {
                        object[] objArray20 = new object[] { this.inputLine, PlayerPrefs.HasKey("ChatName") ? RCextensions.hexColor(PlayerPrefs.GetString("ChatName")) : IN_GAME_MAIN_CAMERA.chatname };
                        MultiplayerManager.GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, objArray20);
                    }
                    if (!this.inputLine.StartsWith("/") && group)
                    {
                        object[] objArray20 = new object[] { this.inputLine, (PlayerPrefs.HasKey("ChatName") ? RCextensions.hexColor(PlayerPrefs.GetString("ChatName")) : IN_GAME_MAIN_CAMERA.chatname) };
                        CandyModUsersOnly("Chat1", "All", objArray20);
                    }
                    this.inputLine = string.Empty;
                    GUI.FocusControl(string.Empty);
                    return;
                }
                this.inputLine = "\t";
                GUI.FocusControl("ChatInput");
            }
            GUI.SetNextControlName(string.Empty);
            GUILayout.BeginArea(GuiRect);
            GUILayout.FlexibleSpace();
            string text = string.Empty;
            string text2 = string.Empty;
            int whichmessage = messages.Count;
            bool condition = false;
            if (messages.Count < 10)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages[i].Contains("</color><color=#3f91g1></color>"))
                    {
                        condition = true;
                        whichmessage = i;
                        GUI.SetNextControlName("ChatInput");
                        if (GUILayout.Button("<size=" + Screen.height / 55 + ">" + messages[whichmessage] + "</size>"))
                        {
                            string[] strArray1 = messages[whichmessage].Split(new char[0]);
                            foreach (string str in strArray1)
                            {
                                if (str.Contains("</color><color=#3f91g1></color>"))
                                {
                                    clickedmessage = str;
                                    clicked = true;
                                }
                            }
                        }
                    }
                    else
                        text = text + messages[i] + "\n";
                }
            }
            else
            {
                condition = false;
                for (int j = messages.Count - 10; j < messages.Count; j++)
                {
                    if (messages[j].Contains("</color><color=#3f91g1></color>"))
                    {
                        whichmessage = j;
                        condition = true;
                        if (GUILayout.Button("<size=" + Screen.height / 55 + ">" + messages[whichmessage] + "</size>"))
                        {
                            GUI.SetNextControlName("ChatInput");
                            string[] strArray1 = messages[whichmessage].Split(new char[0]);
                            foreach (string str in strArray1)
                            {
                                if (str.Contains("</color><color=#3f91g1></color>"))
                                {
                                    clickedmessage = str;
                                    clicked = true;
                                }
                            }
                        }
                    }
                    else
                        text = text + messages[j] + "\n";
                }
            }
            if (clicked)
            {
                Rect guirect = new Rect(GuiRect.xMin, Screen.height / 3f, GuiRect.width, Screen.height / 40);
                if (GUI.Button(guirect, "Copy"))
                {
                    if (clickedmessage.Remove(0, clickedmessage.IndexOf("blue>") + 5).Replace("</color><color=#3f91g1></color>", "").EndsWith(".wav"))
                    {
                        this.inputLine = "/play " + clickedmessage.Remove(0, clickedmessage.IndexOf("blue>") + 5).Replace("</color><color=#3f91g1></color>", "");
                    }
                    else this.inputLine = clickedmessage.Remove(0, clickedmessage.IndexOf("blue>") + 5).Replace("</color><color=#3f91g1></color>", "");
                    clicked = false;
                }
                guirect = new Rect(guirect.xMin, guirect.yMax, guirect.width, guirect.height);
                if (GUI.Button(guirect, "Open"))
                {
                    Application.OpenURL(clickedmessage.Remove(0, clickedmessage.IndexOf("blue>") + 5).Replace("</color><color=#3f91g1></color>", ""));
                    clicked = false;
                }
                if (GUI.Button(new Rect(guirect.xMin, guirect.yMax, guirect.width, guirect.height), "Close"))
                {
                    clicked = false;
                }
            }
            GUILayout.Label(text, new GUILayoutOption[0]);
            GUILayout.EndArea();
            GUILayout.BeginArea(GuiRect2);
            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
            GUI.SetNextControlName("ChatInput");
            this.inputLine = GUILayout.TextField(this.inputLine, new GUILayoutOption[0]);
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
    }

    public void setPosition()
    {
        if (this.AlignBottom)
        {
            GuiRect = new Rect(0f, (float)(Screen.height - 500), 300f, 470f);
            GuiRect2 = new Rect(30f, (float)((Screen.height - 300) + 0x113), 300f, 25f);
        }
    }
    [RPC]
    private void Chat1(string content, string sender, PhotonMessageInfo info)
    {
        if (FengGameManagerMKII.cmusers.ContainsKey(info.sender.ID))
        {
            string[] strArray1 = content.Split(new char[0]);
            foreach (string str in strArray1)
            {
                if (str.StartsWith("www.") || str.StartsWith("https://") || str.StartsWith("http://"))
                {
                    content = content.Replace(str, "<color=blue>" + str + "</color><color=#3f91g1></color>");
                }
            }
            if (sender != string.Empty)
            {
                content = sender + ":" + content;
            }
            string[] strArray5 = DateTime.Now.ToShortTimeString().Split(new char[0]);
            content = "<color=black>[C] </color>" + "<color=black>||</color>" + info.sender.ID + "<color=black>|</color>" + strArray5[0] + "<color=black>|| </color>" + content;
            InRoomChat.addLINE(content);
        }
    }
    [RPC]
    private void net3DMGSMOKE(PhotonMessageInfo info)
    {
        if (!FengGameManagerMKII.modUsers.Contains(info.sender.ID))
        {
            FengGameManagerMKII.modUsers.Add(info.sender.ID);
            if (FengGameManagerMKII.isCandyMasterClient)
            {

            }
            base.photonView.RPC("net3DMGSMOKE", PhotonTargets.All, new object[] { });
        }
    }

    [RPC]
    public void ModDetect1(PhotonMessageInfo info)
    {
        if (!FengGameManagerMKII.modUsers1.Contains(info.sender.ID))
        {
            FengGameManagerMKII.modUsers1.Add(info.sender.ID);
        }
    }
    [RPC]
    public void ModDetect3(PhotonMessageInfo info)
    {
        if (!FengGameManagerMKII.modUsers1.Contains(info.sender.ID))
        {
            FengGameManagerMKII.modUsers1.Add(info.sender.ID);
        }
    }

    public void CandyModUsersOnly(string rpc, string targets, object[] obj)
    {
        if (targets == "All")
        {
            foreach (int id in FengGameManagerMKII.cmusers.Keys)
            {
                base.photonView.RPC(rpc, PhotonPlayer.Find(id), obj);
            }
        }
        if (targets == "Others")
        {
            foreach (int id in FengGameManagerMKII.cmusers.Keys)
            {
                if (id != PhotonNetwork.player.ID)
                {
                    base.photonView.RPC(rpc, PhotonPlayer.Find(id), obj);
                }
            }
        }
    }

    [RPC]
    public void SendMusic(string url, PhotonMessageInfo info)
    {
        if (FengGameManagerMKII.cmusers.ContainsKey(info.sender.ID) && FengGameManagerMKII.candyMasterClient == info.sender.ID && !MainGUI.local || PhotonNetwork.player == info.sender && MainGUI.local)
        {
            if (!isplaying && !isloading && receievemusic)
            {
                base.StartCoroutine(PlayMusic(url));
                played = false;
                lastplayed = url;
            }
        }
    }

    [RPC]
    public void StopMusic(PhotonMessageInfo info)
    {
        if (FengGameManagerMKII.cmusers.ContainsKey(info.sender.ID) && FengGameManagerMKII.candyMasterClient == info.sender.ID && !MainGUI.local || PhotonNetwork.player == info.sender && MainGUI.local)
        {
            audioSource.Stop();
            isplaying = false;
            isloading = false;
            musc = null;
        }
    }

    [RPC]
    public void RequestMusic(int id, PhotonMessageInfo info)
    {
        if (PhotonNetwork.isMasterClient && isplaying && FengGameManagerMKII.cmusers.ContainsKey(info.sender.ID))
        {
            if (FengGameManagerMKII.cmusers.ContainsKey(id))
            {
                base.photonView.RPC("SendMusic", PhotonPlayer.Find(id), new object[] { lastplayed });
            }
        }
    }

    [RPC]
    public void playsoundRPC(PhotonMessageInfo info)
    {
        FengGameManagerMKII.restOfModUsers[info.sender.ID] = 3;
    }

    public System.Collections.IEnumerator PlayMusic(string url)
    {
        WWW ww = new WWW(url);
        yield return ww.audioClip;
        musc = ww.audioClip;
    }

    public void SetLinksLoad(int number)
    {
        if (number == 1)
        {
            String toarray1 = PlayerPrefs.GetString("skinsframe1");
            String toarray2 = PlayerPrefs.GetString("skinsframe2");
            String toarray3 = PlayerPrefs.GetString("skinsframe3");
            String toarray4 = PlayerPrefs.GetString("skinsframe4");
            for (int z = 0; z < linkss.Length; z++)
            {
                if (z != 0)
                    toarray1 = toarray1.Remove(0, toarray1.IndexOf("~") + 1);
                linkss[z] = toarray1.Substring(0, toarray1.IndexOf("~"));
                if (z != 0)
                    toarray2 = toarray2.Remove(0, toarray2.IndexOf("~") + 1);
                linksss[z] = toarray2.Substring(0, toarray2.IndexOf("~"));
                if (z != 0)
                    toarray3 = toarray3.Remove(0, toarray3.IndexOf("~") + 1);
                linkssss[z] = toarray3.Substring(0, toarray3.IndexOf("~"));
                if (z != 0)
                    toarray4 = toarray4.Remove(0, toarray4.IndexOf("~") + 1);
                linksssss[z] = toarray4.Substring(0, toarray4.IndexOf("~"));
            }
        }
        if (number == 2)
        {
            String toarray1 = PlayerPrefs.GetString("2skinsframe1");
            String toarray2 = PlayerPrefs.GetString("2skinsframe2");
            String toarray3 = PlayerPrefs.GetString("2skinsframe3");
            String toarray4 = PlayerPrefs.GetString("2skinsframe4");
            for (int z = 0; z < linkss.Length; z++)
            {
                if (z != 0)
                    toarray1 = toarray1.Remove(0, toarray1.IndexOf("~") + 1);
                linkss[z] = toarray1.Substring(0, toarray1.IndexOf("~"));
                if (z != 0)
                    toarray2 = toarray2.Remove(0, toarray2.IndexOf("~") + 1);
                linksss[z] = toarray2.Substring(0, toarray2.IndexOf("~"));
                if (z != 0)
                    toarray3 = toarray3.Remove(0, toarray3.IndexOf("~") + 1);
                linkssss[z] = toarray3.Substring(0, toarray3.IndexOf("~"));
                if (z != 0)
                    toarray4 = toarray4.Remove(0, toarray4.IndexOf("~") + 1);
                linksssss[z] = toarray4.Substring(0, toarray4.IndexOf("~"));
            }
        }
        if (number == 3)
        {
            String toarray1 = PlayerPrefs.GetString("3skinsframe1");
            String toarray2 = PlayerPrefs.GetString("3skinsframe2");
            String toarray3 = PlayerPrefs.GetString("3skinsframe3");
            String toarray4 = PlayerPrefs.GetString("3skinsframe4");
            for (int z = 0; z < linkss.Length; z++)
            {
                if (z != 0)
                    toarray1 = toarray1.Remove(0, toarray1.IndexOf("~") + 1);
                linkss[z] = toarray1.Substring(0, toarray1.IndexOf("~"));
                if (z != 0)
                    toarray2 = toarray2.Remove(0, toarray2.IndexOf("~") + 1);
                linksss[z] = toarray2.Substring(0, toarray2.IndexOf("~"));
                if (z != 0)
                    toarray3 = toarray3.Remove(0, toarray3.IndexOf("~") + 1);
                linkssss[z] = toarray3.Substring(0, toarray3.IndexOf("~"));
                if (z != 0)
                    toarray4 = toarray4.Remove(0, toarray4.IndexOf("~") + 1);
                linksssss[z] = toarray4.Substring(0, toarray4.IndexOf("~"));
            }
        }
    }

    public void Start()
    {
        if (!joined)
        {
            //you can also put join msgs here if you want
            joined = true;
        }
        InRoomChat.Chat = this;
        // Set the Method property of the request to POST.
        requestweb.Method = "POST";
        // Create POST data and convert it to a byte array.
        string postData = "This is a test that posts this string to a Web server.";
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        // Set the ContentType property of the WebRequest.
        //requestweb.ContentType = "application/x-www-form-urlencoded";
        // Set the ContentLength property of the WebRequest.
        requestweb.ContentLength = byteArray.Length;
        // Get the request stream.
        if (PlayerPrefs.HasKey("skinsframe1"))
        {
            String toarray1 = PlayerPrefs.GetString("skinsframe1");
            String toarray2 = PlayerPrefs.GetString("skinsframe2");
            String toarray3 = PlayerPrefs.GetString("skinsframe3");
            String toarray4 = PlayerPrefs.GetString("skinsframe4");
            for (int z = 0; z < linkss.Length; z++)
            {
                if (z != 0)
                    toarray1 = toarray1.Remove(0, toarray1.IndexOf("~") + 1);
                linkss[z] = linkss[z] + toarray1.Substring(0, toarray1.IndexOf("~"));
                if (z != 0)
                    toarray2 = toarray2.Remove(0, toarray2.IndexOf("~") + 1);
                linksss[z] = linksss[z] + toarray2.Substring(0, toarray2.IndexOf("~"));
                if (z != 0)
                    toarray3 = toarray3.Remove(0, toarray3.IndexOf("~") + 1);
                linkssss[z] = linkssss[z] + toarray3.Substring(0, toarray3.IndexOf("~"));
                if (z != 0)
                    toarray4 = toarray4.Remove(0, toarray4.IndexOf("~") + 1);
                linksssss[z] = linksssss[z] + toarray4.Substring(0, toarray4.IndexOf("~"));
            }
        }
        else
        {
            PlayerPrefs.SetString("skinsframe1", "");
            PlayerPrefs.SetString("skinsframe2", "");
            PlayerPrefs.SetString("skinsframe3", "");
            PlayerPrefs.SetString("skinsframe4", "");
        }
        if (!PlayerPrefs.HasKey("2skinsframe1"))
        {
            PlayerPrefs.SetString("2skinsframe1", "");
            PlayerPrefs.SetString("2skinsframe2", "");
            PlayerPrefs.SetString("2skinsframe3", "");
            PlayerPrefs.SetString("2skinsframe4", "");
        }
        if (!PlayerPrefs.HasKey("3skinsframe1"))
        {
            PlayerPrefs.SetString("3skinsframe1", "");
            PlayerPrefs.SetString("3skinsframe2", "");
            PlayerPrefs.SetString("3skinsframe3", "");
            PlayerPrefs.SetString("3skinsframe4", "");
        }
        if (PlayerPrefs.HasKey("Fly"))
        {
            IN_GAME_MAIN_CAMERA.fly = PlayerPrefs.GetString("Fly") == "true" ? true : false;
        }
        if (PlayerPrefs.HasKey("Shower"))
        {
            candyshower = PlayerPrefs.GetString("Shower") == "true" ? true : false;
        }
        String nametoadd = String.Empty;
        if (PlayerPrefs.GetString("Name") != String.Empty)
        {
            nametoadd = PlayerPrefs.GetString("Name");
        }
        ExitGames.Client.Photon.Hashtable hashtable2 = new ExitGames.Client.Photon.Hashtable();
        hashtable2.Add(PhotonPlayerProperty.name, nametoadd != String.Empty ? nametoadd : "CandyMod");
        ExitGames.Client.Photon.Hashtable propertiesToSet = hashtable2;
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);

        base.photonView.RPC("net3DMGSMOKE", PhotonTargets.All, new object[] { });
        this.setPosition();
        this.setPosition();
        GUIStyle gUIStyle = new GUIStyle();
        //gUIStyle.margin = (((int)FengGameManagerMKII.settings[75] <= 0 ? new RectOffset(0, 0, 2147483647, 0) : new RectOffset(0, 0, 2, 0)));
        gUIStyle.wordWrap = (true);
        gUIStyle.clipping =((TextClipping)1);
        this.ayastyle = gUIStyle;
        GUIStyle gUIStyle1 = new GUIStyle();
        //gUIStyle1.margin = (((int)FengGameManagerMKII.settings[75] <= 0 ? new RectOffset(0, 0, 2147483647, 0) : new RectOffset(0, 0, 2, 0)));
        GUIStyleState gUIStyleState = new GUIStyleState();
        gUIStyleState.background = (Texture2D.blackTexture);
        gUIStyleState.textColor = (Color.white);
        gUIStyle1.hover = (gUIStyleState);
        GUIStyleState gUIStyleState1 = new GUIStyleState();
        gUIStyleState1.background = (Texture2D.blackTexture);
        gUIStyleState1.textColor = (Color.white);
        gUIStyle1.onHover = (gUIStyleState1);
        gUIStyle1.wordWrap = (true);
        gUIStyle1.clipping =((TextClipping)1);
        //this.urlStyle = gUIStyle1;
        //FengGameManagerMKII.MKII.StartNameAnim((string)FengGameManagerMKII.settings[84] != "None");
    }

    [RPC]
    public void SetupQuidditch(PhotonMessageInfo info)
    {
        foreach (GameObject obj1 in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            //move supply tank to center
            if (obj1.name.Contains("aot_supply"))
            {
                obj1.transform.position = new Vector3(0, 0, 0);
            }
            //destroy all undesired objects
            if (obj1.tag.Contains("titan") || (obj1.name.Contains("Cube") && !obj1.name.Contains("01") && !obj1.name.Contains("02") && !obj1.name.Contains("06") && !obj1.name.Contains("07")))
            {
                GameObject.Destroy(obj1);
            }
        }
        //add column1
        GameObject column1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //move into position & scale
        column1.transform.localScale = new Vector3(7, 50, 7);
        column1.transform.position = new Vector3(10, 25, 0);
        //set layer to 9 so players can hook on
        column1.layer = LayerMask.NameToLayer("Ground");

        //add column2
        GameObject column2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //move into position & scale
        column2.transform.localScale = new Vector3(7, 50, 7);
        column2.transform.position = new Vector3(0, 25, 500);
        //set layer to 9 so players can hook on
        column2.layer = LayerMask.NameToLayer("Ground");

        //add column3
        GameObject column3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //move into position & scale
        column3.transform.localScale = new Vector3(7, 50, 7);
        column3.transform.position = new Vector3(0, 25, -500);
        //set layer to 9 so players can hook on
        column3.layer = LayerMask.NameToLayer("Ground");

        //add ring2
        GameObject ring2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ring2.renderer.material.color = Color.red;
        //move into position & scale
        ring2.transform.localScale = new Vector3(12, 12, 12);
        ring2.transform.position = new Vector3(0, 56f, 500);
        //add component to check if ball is in
        ring2.collider.isTrigger = true;
        ring2.AddComponent<QuidditchRing>();

        //add ring3
        GameObject ring3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ring3.renderer.material.color = Color.red;
        //move into position & scale
        ring3.transform.localScale = new Vector3(12, 12, 12);
        ring3.transform.position = new Vector3(0, 56f, -500);
        //add component to check if ball is in
        ring3.collider.isTrigger = true;
        ring3.AddComponent<QuidditchRing>();

        //add qball
        GameObject qball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        qball.renderer.material.color = Color.red;
        //move into position & scale
        qball.transform.localScale = new Vector3(4, 4, 4);
        qball.transform.position = new Vector3(10, 52f, 0);
        //set layer to 9 so players can hook on
        qball.layer = LayerMask.NameToLayer("Ground");
        qball.AddComponent<Rigidbody>();
        qball.AddComponent<QuidditchBall>();
        qball.name = "QBall";
        qball.rigidbody.useGravity = false;

        //add snitch
        GameObject snitch = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        snitch.renderer.material.color = Color.red;
        //move into position & scale
        snitch.transform.localScale = new Vector3(1, 1, 1);
        snitch.transform.position = new Vector3(0, 56f, -520);
        //set layer to 9 so players can hook on
        snitch.layer = LayerMask.NameToLayer("Ground");
        snitch.AddComponent<Rigidbody>();
        snitch.AddComponent<Snitch>();
        snitch.name = "Snitch";
        snitch.rigidbody.useGravity = false;
    }

    [RPC]
    public void SetQuidditchValue(string variable, float value, PhotonMessageInfo info)
    {
        GameObject qball = GameObject.Find("QBall");
        if (qball != null)
        {
            if (variable == "force_factor")
            {
                qball.GetComponent<QuidditchBall>().force_factor = value;
                AddLine("force_factor changed to: " + value);
            }
            else if (variable == "gravity_factor")
            {
                qball.GetComponent<QuidditchBall>().gravity_factor = value;
                AddLine("gravity_factor changed to: " + value);
            }
            else if (variable == "max_dist")
            {
                qball.GetComponent<QuidditchBall>().max_dist = value;
                AddLine("max_dist changed to: " + value);
            }
            else if (variable == "ggravity_factor")
            {
                qball.GetComponent<QuidditchBall>().grappled_gravity_factor = value;
                AddLine("grappled_gravity_factor changed to: " + value);
            }
            else if (variable == "speed")
            {
                GameObject snitch = GameObject.Find("Snitch");
                if (snitch != null)
                {
                    snitch.GetComponent<Snitch>().speed = value;
                    AddLine("speed changed to: " + value);
                }
            }
            else if (variable == "dir_time")
            {
                GameObject snitch = GameObject.Find("Snitch");
                if (snitch != null)
                {
                    snitch.GetComponent<Snitch>().dir_time = value;
                    AddLine("dir_time changed to: " + value);
                }
            }
        }
    }

    private System.Collections.IEnumerator nextSong(float time, int counter)
    {
        yield return new WaitForSeconds(time);
        if (counter == MainGUI.playcountkeeping)
        {
            if (playlist.Count > 0)
            {
                CandyModUsersOnly("StopMusic", "All", new object[] { });
                if (playlistplaying < playlist.Count)
                {
                    playlistplaying++;
                }
                else
                {
                    playlistplaying = 1;
                }
                foreach (string str in playlist)
                {
                    if (str.Split(new char[0])[0] == "" + playlistplaying && str.Split(new char[0])[2] == "(Removed)")
                    {
                        if (playlistplaying < playlist.Count)
                        {
                            playlistplaying++;
                        }
                        else
                        {
                            playlistplaying = 1;
                        }
                    }
                }
                CandyModUsersOnly("SendMusic", "All", new object[] { playlist[playlistplaying - 1].Remove(0, 2).Replace(" ", "") });
            }
        }
    }

    public void Update()
    {/*
        string[] stuff = { " ┏(-_-)┛ ", " ┏(-_-)┓ ", " ┗(-_-﻿)┓ ", " ┏(-_-)┓ " };
        if (Time.time - hehecount > .1f)
        {
            hehecount = Time.time;
            FengGameManagerMKII.GuiText = stuff[inthehe];
            for (int z = 0; z < 10; z++)
            {
                GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, new object[] { " ", "" });
            }
            GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().photonView.RPC("Chat", PhotonTargets.All, new object[] { stuff[inthehe], "" });
            inthehe++;
            if (inthehe > 3)
            {
                inthehe = 0;
            }
        }*/
        if (musc != null && played == false)
        {
            if (musc.isReadyToPlay)
            {
                audioSource.clip = musc;
                audioSource.volume = volume;
                audioSource.Play();
                MainGUI.playcountkeeping++;
                base.StartCoroutine(this.nextSong(audioSource.clip.length, MainGUI.playcountkeeping));
                cliplength = audioSource.clip.length;
                cliptime = Time.time;
                played = true;
                musc = null;
                isloading = false;
                isplaying = true;
            }
            else
            {
                isloading = true;
            }
        }
        if (isplaying)
        {
            if (Time.time - cliptime > cliplength)
            {
                isplaying = false;
            }
        }
    }
}

