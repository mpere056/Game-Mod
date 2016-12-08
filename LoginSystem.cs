using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using Photon;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UnityEngine;

public class LoginSystem : UnityEngine.MonoBehaviour
{
    private int[,] RCCandy = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
    public static Rect GUIRect = new Rect(0f, 0f, Convert.ToSingle(Screen.width / 2.75), Convert.ToSingle(Screen.height / 1.5));
    public static Rect ResponseRect = new Rect(Screen.width / 20, Screen.height / 20, Convert.ToSingle(Screen.width / 5), Convert.ToSingle(Screen.height / 6));
    public static Rect RequestsRect = new Rect(0f, 0f, Convert.ToSingle(Screen.width / 2.75), Convert.ToSingle(Screen.height / 1.5));
    public static Rect FriendsRect = new Rect(0f, 0f, Convert.ToSingle(Screen.width / 2.75), Convert.ToSingle(Screen.height / 1.5));
    public static bool showresponse = false;
    public static string responsefromserver;
    public static bool loggedin = false;
    public static string username;
    public static string userpassword;
    public static int friendsnumber;
    public static int requestsnumber = 0;
    public static string friends;
    public static string requests;
    public static List<string> eachfriend = new List<string>();
    public static List<string> eachrequest = new List<string>();
    public static bool showfriends = false;
    public static bool showrequests = false;
    public static List<bool> onlinelist = new List<bool>();
    string usernamebox = String.Empty;
    string passwordbox = String.Empty;
    string addfriendbox = String.Empty;
    string removefriendbox = String.Empty;
    public static bool showlogin = false;
    int selected = 0;
    bool isselected = false;

    public static void Register(string name, string password)
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=register&username=" + name + "&password=" + password;
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = name;
        formData["password"] = password;

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
        responsefromserver = Encoding.UTF8.GetString(responseBytes);
        responsefromserver = responsefromserver.Remove(responsefromserver.IndexOf("<!"));
        showresponse = true;
        webClient.Dispose();
    }

    public void LogOut()
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=setonline&username=" + username + "&password=" + userpassword + "&online=" + "0";
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = username;
        formData["password"] = userpassword;
        formData["online"] = "0";

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
        responsefromserver = Encoding.UTF8.GetString(responseBytes);
        responsefromserver = responsefromserver.Remove(responsefromserver.IndexOf("<!"));
        loggedin = false;
        showfriends = false;
        showrequests = false;
        showresponse = false;
        username = String.Empty;
        userpassword = String.Empty;
        RequestsRect = new Rect(0f, 0f, Convert.ToSingle(Screen.width / 2.75), Convert.ToSingle(Screen.height / 1.5));
        FriendsRect = new Rect(0f, 0f, Convert.ToSingle(Screen.width / 2.75), Convert.ToSingle(Screen.height / 1.5));
        webClient.Dispose();
    }

    public static void Login(string name, string password)
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=setonline&username=" + name + "&password=" + password + "&online=" + "1";
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = name;
        formData["password"] = password;
        formData["online"] = "1";

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
        responsefromserver = Encoding.UTF8.GetString(responseBytes);
        responsefromserver = responsefromserver.Remove(responsefromserver.IndexOf("<!"));
        if (responsefromserver.Replace("\n", "").StartsWith("success"))
        {
            responsefromserver = "Logged In";
            //PhotonNetwork.playerName = name;
            loggedin = true;
            username = name;
            userpassword = password;
            ListRequests(0);
            //ListFriends();
            FriendsRect.xMin = GUIRect.xMin;
            FriendsRect.yMax = GUIRect.yMax;
        }
        //showresponse = true;
        webClient.Dispose();
    }

    public void OnApplicationQuit()
    {
        LogOut();
    }

    public static void ListRequests(int number)
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=viewrequests&username=" + username + "&password=" + userpassword;
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = username;
        formData["password"] = userpassword;

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);

        requests = Encoding.UTF8.GetString(responseBytes);
        requests = requests.Remove(requests.IndexOf("<!"));
        requests.Replace("<br>", "@");
        string[] temp = requests.Replace("<br>", "@").Split('@');
        eachrequest = new List<string>();
        for (int z = 0; z < temp.Length - 1; z++)
        {
            eachrequest.Add(temp[z]);
        }
        if (number != 0)
        {
            showrequests = true;
        }
        if (eachrequest.Count > 0)
        {
            requestsnumber = eachrequest.Count;
        }
        else
        {
            requestsnumber = 0;
        }
        webClient.Dispose();
    }

    public void ListFriends()
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=listfriends&username=" + username + "&password=" + userpassword;
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = username;
        formData["password"] = userpassword;

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
        friends = Encoding.UTF8.GetString(responseBytes);
        friends = friends.Remove(friends.IndexOf("<!"));
        friends = friends.Replace("<br>", "@");
        string[] temp = friends.Split('@');
        eachfriend = new List<string>();
        onlinelist = new List<bool>();
        for (int z = 0; z < temp.Length - 1; z++)
        {
            eachfriend.Add(temp[z]);
        }
        base.StartCoroutine(RefreshFriends());
        showfriends = true;
        webClient.Dispose();
    }

    public IEnumerator RefreshFriends()
    {
        for (int z = 0; z < eachfriend.Count; z++)
        {
            bool t = IsOnline(eachfriend[z]);
            yield return t;
            onlinelist.Add(t);
        }
    }

    public static bool IsOnline(string fname)
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=isonline&username=" + username + "&password=" + userpassword + "&username2=" + fname;
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = username;
        formData["password"] = userpassword;

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
        string aresponse = Encoding.UTF8.GetString(responseBytes);
        aresponse = aresponse.Remove(aresponse.IndexOf("<!"));
        if (aresponse.StartsWith("1"))
        {
            webClient.Dispose();
            return true;
        }
        else
        {
            webClient.Dispose();
            return false;
        }
    }

    public void AddFriend(string fname)
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=request&username=" + username + "&password=" + userpassword + "&username2=" + fname;
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = username;
        formData["password"] = userpassword;
        formData["fusername"] = fname;

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
        responsefromserver = Encoding.UTF8.GetString(responseBytes);
        responsefromserver = responsefromserver.Remove(responsefromserver.IndexOf("<!"));
        if (responsefromserver.StartsWith("success"))
        {
            responsefromserver = "success";
        }
        showresponse = true;
        webClient.Dispose();
    }

    public void AcceptFriendRequest(string fname)
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=acceptfriend&username=" + username + "&password=" + userpassword + "&username2=" + fname;
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = username;
        formData["password"] = userpassword;
        formData["fusername"] = fname;

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
        responsefromserver = Encoding.UTF8.GetString(responseBytes);
        responsefromserver = responsefromserver.Remove(responsefromserver.IndexOf("<!"));
        showresponse = true;
        webClient.Dispose();
    }

    public void DeclineFriendRequest(string fname)
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=declinefriend&username=" + username + "&password=" + userpassword + "&username2=" + fname;
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = username;
        formData["password"] = userpassword;
        formData["fusername"] = fname;

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
        responsefromserver = Encoding.UTF8.GetString(responseBytes);
        showresponse = true;
        webClient.Dispose();
    }

    public void RemoveFriend(string fname)
    {
        string URL = "http://lelchan.comoj.com/doaction.php?action=removefriend&username=" + username + "&password=" + userpassword + "&username2=" + fname;
        WebClient webClient = new WebClient();

        NameValueCollection formData = new NameValueCollection();
        formData["username"] = username;
        formData["password"] = userpassword;
        formData["fusername"] = fname;

        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
        responsefromserver = Encoding.UTF8.GetString(responseBytes);
        if (responsefromserver.StartsWith("success"))
        {
            responsefromserver = "success";
        }
        showresponse = true;
        webClient.Dispose();
    }

    public void ResponseBody(int id)
    {
        if (GUI.Button(new Rect(0, 0, ResponseRect.width, ResponseRect.height), responsefromserver))
        {
            showresponse = false;
        }
        if ((!Input.GetKey(KeyCode.Mouse0) || !Input.GetKey(KeyCode.Mouse1)) && !Input.GetKey(KeyCode.C) && (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.WOW || IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.ORIGINAL))
        {
            GUI.DragWindow();
        }
    }

    public void Requests(int id)
    {
        GUILayout.BeginVertical();
        for (int z = 0; z < eachrequest.Count; z++)
        {
            if (GUILayout.Button(eachrequest[z], new GUILayoutOption[0]))
            {
                selected = z;
                isselected = true;
            }
            if (isselected && selected == z)
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Accept", new GUILayoutOption[0]))
                {
                    AcceptFriendRequest(eachrequest[z]);
                    ListRequests(0);
                    isselected = false;
                }
                if (GUILayout.Button("Decline", new GUILayoutOption[0]))
                {
                    DeclineFriendRequest(eachrequest[z]);
                    ListRequests(0);
                    isselected = false;
                }
                GUILayout.EndHorizontal();
            }
        }
        if (GUILayout.Button("Close", new GUILayoutOption[0]))
        {
            showrequests = false;
        }
        if ((!Input.GetKey(KeyCode.Mouse0) || !Input.GetKey(KeyCode.Mouse1)) && !Input.GetKey(KeyCode.C) && (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.WOW || IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.ORIGINAL))
        {
            GUI.DragWindow();
        }
        GUILayout.EndVertical();
    }

    public void Friends(int id)
    {
        GUILayout.BeginVertical();
        for (int z = 0; z < eachfriend.Count; z++)
        {
            if (GUILayout.Button(eachfriend[z] + (onlinelist[z] == true ? " Online" : " Offline"), new GUILayoutOption[0]))
            {

            }
        }
        if (GUILayout.Button("Close", new GUILayoutOption[0]))
        {
            showfriends = false;
        }
        if ((!Input.GetKey(KeyCode.Mouse0) || !Input.GetKey(KeyCode.Mouse1)) && !Input.GetKey(KeyCode.C) && (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.WOW || IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.ORIGINAL))
        {
            GUI.DragWindow();
        }
        GUILayout.EndVertical();
    }

    public void MainBody(int id)
    {
        //GUILayout.BeginVertical();
        if (showresponse)
        {

        }
        else
        {
            GUIStyle a = new GUIStyle();
            a.fixedWidth = Screen.width / 10;
            a.stretchWidth = false;
            a.clipping = TextClipping.Clip;
            a.normal.background = Texture2D.whiteTexture;
            a.hover.background = FengGameManagerMKII.candytextures[8];
            GUILayout.BeginVertical();
            if (!loggedin)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Username: ", new GUILayoutOption[0]);
                usernamebox = GUILayout.TextField(usernamebox, a, new GUILayoutOption[0]);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Password: ", new GUILayoutOption[0]);
                passwordbox = GUILayout.TextField(passwordbox, a, new GUILayoutOption[0]);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Register", new GUILayoutOption[0]))
                {
                    Register(usernamebox, passwordbox);
                }

                if (GUILayout.Button("Login", new GUILayoutOption[0]))
                {
                    Login(usernamebox, passwordbox);
                }
                GUILayout.EndHorizontal();
            }
            else
            {
                if (requestsnumber > 0)
                {
                    if (GUILayout.Button("Requests (" + requestsnumber + ")", new GUILayoutOption[0]))
                    {
                        ListRequests(1);
                    }
                }

                GUILayout.BeginHorizontal();
                addfriendbox = GUILayout.TextField(addfriendbox, a, new GUILayoutOption[0]);
                if (GUILayout.Button("Add Friend", new GUILayoutOption[0]))
                {
                    AddFriend(addfriendbox);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                removefriendbox = GUILayout.TextField(removefriendbox, a, new GUILayoutOption[0]);
                if (GUILayout.Button("Remove Friend", new GUILayoutOption[0]))
                {
                    RemoveFriend(removefriendbox);
                }
                GUILayout.EndHorizontal();

                if (GUILayout.Button("Friends", new GUILayoutOption[0]))
                {
                    ListFriends();
                }
                if (GUILayout.Button("Log out", new GUILayoutOption[0]))
                {
                    LogOut();
                }
            }
            GUILayout.EndVertical();
        }
        if ((!Input.GetKey(KeyCode.Mouse0) || !Input.GetKey(KeyCode.Mouse1)) && !Input.GetKey(KeyCode.C) && (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.WOW || IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.ORIGINAL))
        {
            GUI.DragWindow();
        }
    }

    public void OnGUI()
    {
        if (showlogin)
        {
            GUIRect = GUI.Window(69, GUIRect, this.MainBody, "" + DateTime.Now);
            if (showresponse && responsefromserver.Length > 2)
            {
                ResponseRect = GUI.Window(420, new Rect(GUIRect.xMin + (GUIRect.xMax - GUIRect.xMin) / 5, GUIRect.yMin + (GUIRect.yMax - GUIRect.yMin) / 5, ResponseRect.width, ResponseRect.height), this.ResponseBody, "" + DateTime.Now);
                GUI.BringWindowToBack(69);
                GUI.BringWindowToFront(420);
            }
            if (showrequests)
            {
                RequestsRect = GUI.Window(1337, RequestsRect, this.Requests, "" + "Requests");
                //GUI.BringWindowToBack(69);
                GUI.BringWindowToFront(1337);
            }
            if (showfriends)
            {
                FriendsRect = GUI.Window(300, FriendsRect, this.Friends, "" + "Friends List");
            }
        }
    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            showlogin = !showlogin;
        }
    }

    public void Start()
    {
    }
}