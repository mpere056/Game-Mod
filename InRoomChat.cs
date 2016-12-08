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

    public void OnGUI()
    {
        if (this.IsVisible && (PhotonNetwork.connectionStateDetailed == PeerStates.Joined))
        {
            if ((Event.current.type == EventType.KeyDown) && ((Event.current.keyCode == KeyCode.KeypadEnter) || (Event.current.keyCode == KeyCode.Return)))
            {
                if (!string.IsNullOrEmpty(this.inputLine))
                {
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
                    }
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
                }
            }
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
    {
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

