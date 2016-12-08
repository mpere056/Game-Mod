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
using RedSkies;

public class FengGameManagerMKII : Photon.MonoBehaviour
{
    public static bool serverConnected;
    public static readonly string applicationId = "f1f6195c-df4a-40f9-bae5-4744c32901ef";
    private ArrayList chatContent;
    public GameObject checkpoint;
    private float currentSpeed;
    public int difficulty;
    public static bool gameStart;
    private ArrayList kicklist;
    public static FengGameManagerMKII inputs;
    public static string[] banlist = new string[100];
    public static FengGameManagerMKII instance;

    public float TimeQua = Time.time;
    public float Time2 = Time.time;
    public float Time3 = Time.time;

    public string[] songurls = new string[50];
    public string[] songs = new string[50];
    public AudioClip[] songsounds = new AudioClip[50];
    public int numbersongs = 0;

    public static bool menu = false;
    public static GameObject lan = null;
    public static GameObject options = null;
    public static GameObject single = null;
    public static GameObject credits = null;

    //WWW candywww = new WWW("http://www.psdgraphics.com/file/rainbow-colors-design.jpg");
    //WWW candywww = new WWW("http://imagehost4.online-image-editor.com/oie_upload/images/6215110H11RaM1z3y/transparent.png");
    WWW candyshowerwww = new WWW("http://www.psdgraphics.com/file/rainbow-colors-design.jpg");
    WWW candywww = new WWW("http://i.imgur.com/PsPDg7O.png");
    WWW candywww2 = new WWW("http://i.imgur.com/sfVz9Xj.png");
    //WWW candywww3 = new WWW("http://i.imgur.com/sfVz9Xj.png");
    WWW Candies = new WWW("https://www.dropbox.com/s/cfodsid3w5fextb/version%28candy%20mod%29.txt?dl=1");
    WWW errortexturewww = new WWW("http://imagehost4.online-image-editor.com/oie_upload/images/6215110H11RaM1z3y/transparent.png");
    WWW candymod = new WWW("http://i.imgur.com/zQnD4qs.png");
    WWW selectedWWW = new WWW("http://i.imgur.com/1hJQI5M.png");
    WWW selectedWWW2 = new WWW("http://i.imgur.com/3SoO2Zk.png");
    WWW[] selectedWWW3 = { new WWW("http://i.imgur.com/CXC0fwC.png"), new WWW("http://i.imgur.com/FvqsNIK.png"), new WWW("http://i.imgur.com/OOQ3QXa.png"), new WWW("http://i.imgur.com/lA3RyxU.png") };
    public WWW[] candyWWW = new WWW[21];

    public static GameObject selected = null;

    public static Texture2D candymodtexture = null;
    public static Texture2D picture2texture = null;
    public static Texture2D picture3texture = null;
    public static Texture2D picture31texture = null;
    public static Texture2D picture32texture = null;
    public static Texture2D picture33texture = null;
    public static Texture2D picture1texture = null;
    public static Texture2D playerguiskinstexture = null;
    public static Texture2D candyshowertexture = null;
    public static Texture2D candytexture = null;
    public static Texture2D candytexture2 = null;
    public static Texture2D candytexture3 = null;
    public static Texture2D forumtexture = null;
    public static Texture2D forumlinktexture = null;
    public static Texture2D redtexture = null;
    public static Texture2D greentexture = null;
    public static Texture2D bluetexture = null;
    public static Texture2D yellowtexture = null;
    public static Texture2D errortexture = null;
    public static Texture selectedtexture = new Texture();    
    public static Texture selectedtexture2 = new Texture();
    public static Texture[] selectedtexture3 = new Texture[4];
    public static Texture2D[] candytextures = new Texture2D[21];

    bool gotpicture33texture = false;
    bool gotpicture32texture = false;
    bool gotpicture31texture = false;
    bool gotpicture3texture = false;
    bool gotpicture2texture = false;
    bool gotpicture1texture = false;
    bool gotcandymod = false;
    bool gotplayerguiskins = false;
    bool gotcandyshowertexture = false;
    bool gottexture = false;
    bool gottexture2 = false;
    //bool gottexture3 = false;
    bool gotforumtexture = false;
    bool gotforumlinktexture = false;
    bool goterrortexture = false;
    bool gotred = false;
    bool gotgreen = false;
    bool gotblue = false;
    bool gotyellow = false;
    bool[] gotselected3 = new bool[4];
    bool gotselected2 = false;
    bool gotselected = false;
    bool waitcandy = false;
    public static int gotcandytextures = 0;

    bool iscandy = false;
    GameObject candy = new GameObject();
    public static bool candied = false;
    public static bool candypowers = false;
    public static float candytime = Time.time;
    public static float candytime2 = Time.time;
    public static bool flight = false;
    public static float hidetimer = Time.time;
    public bool amseeker = false;
    public static bool actualseeker = false;
    public static bool playhns = false;
    Vector3 stay = new Vector3();
    bool tpd = false;
    public static Dictionary<int, bool> caught = new Dictionary<int, bool>();

    GameObject[] candies = new GameObject[10000];
    int countcandies = 0;
    //WWW planewww = new WWW("http://i.imgur.com/30EZwWB.png");
    WWW wingswww = new WWW("http://i.imgur.com/kbMN1jg.png");
    //public static Texture2D planetex;
    public static Texture2D wingstex;
    //bool gotplane = false;
    bool gotwings = false;
    public static float dancecd = Time.time;

    public static List<int> modUsers = new List<int>();
    public static List<int> modUsers1 = new List<int>();//link
    public static List<int> modUsers2 = new List<int>();//rc
    public static List<int> modUsers3 = new List<int>();//brs
    public static ExitGames.Client.Photon.Hashtable restOfModUsers = new ExitGames.Client.Photon.Hashtable();//kage 1 skyzr 2 LSM 3 Diety 4 Jikan 5
    public static string mod;
    bool isloadingupdate = false;
    float coretimer = 0f;
    public static int fps2 = 0;
    float fpscd = Time.time;
    public static bool showcandies = true;
    public static bool showchat = true;

    public static int candyMasterClient = 1;
    public static bool isCandyMasterClient = false;

    public static bool showconfig = true;
    String nameinput = "Name";
    String guildinput = "GuildName";
    String chatnameinput = "ChatName";
    Light newli;
    Dictionary<int, GameObject[]> flashies = new Dictionary<int, GameObject[]>();

    public static bool broadcasting;
    public float chatmessagecd = Time.time;
    public bool sendchatmessage = false;
    public Dictionary<int, string> chatmessage = new Dictionary<int, string>();
    public Dictionary<int, float> chatmessagetime = new Dictionary<int, float>();
    public Dictionary<int, bool> chatmessagesend = new Dictionary<int, bool>();
    float waittime = 0;

    public WWW importmat = new WWW("http://www.netvlies.nl/wp-content/uploads/2012/07/wolk_600px_jpg_quality_50_progressive_11kb.jpg");
    public string urll = "http://www.blueseptember.org.au/userData/collateral/Blue-square.jpg";
    public Texture[] atexture = new Texture[28];
    public Texture[,] antexture = new Texture[4, 28];
    public Dictionary<int, Texture[,]> playerskins = new Dictionary<int, Texture[,]>();
    public static Dictionary<int, bool> animate = new Dictionary<int, bool>();
    public static Dictionary<int, bool> first = new Dictionary<int, bool>();
    public float animateskintimer = Time.time;
    public int animateskinpos = 0;
    public float animateeyestimer = Time.time;
    public int animateeyespos = 0;

    PhotonView basephotonView;
    internal static F3GUI f3GUI;
    public static bool damage;
    public static bool size;
    public static bool canspawn = true;
    public float canspawntime = Time.time;
    public static bool imhosting = false;
    public static string[] mymap = new string[5000];
    public static int times = 0;
    //bool loadingmap = false;

    AudioClip song123;
    AudioSource audioSource;
    public static bool musicLoop;
    public static bool checkedcandy = false;
    float countstop = Time.time;
    float countretry = 0;
    public bool setup = false;

    public static Dictionary<int, GameObject> cmusers = new Dictionary<int,GameObject>();
    public static string GuiText = "";
    public static bool loadedtextures = false;

    private void Awake()
    {
        FengGameManagerMKII.GUICtrl = new GameObject("MainGUI");
        F3GUI f3GUI = FengGameManagerMKII.GUICtrl.AddComponent<F3GUI>();
        FengGameManagerMKII.f3GUI = f3GUI;
    }




    [RPC]
    public void SendMusic(int z, string url)
    {
        base.StartCoroutine(LoadMusic(z, url));
    }

    public System.Collections.IEnumerator LoadMusic(int z, string url)
    {
        WWW www = new WWW(url);
        yield return www.audioClip;
        yield return www.audioClip.isReadyToPlay;
        AudioSource.PlayClipAtPoint(www.audioClip, Camera.main.transform.position);
        IN_GAME_MAIN_CAMERA.main_object.transform.position += new Vector3(0f, 10f, 0f);
    }
    
    public void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width - Screen.width * 6.8f / 10, Screen.height / 3f, Screen.width / 2, Screen.height / 2), "<size=" + Convert.ToString(Screen.width / 75) + "><color=black>t" + GuiText + "</color></size>");
        if (checkedcandy && candied && PhotonNetwork.insideLobby)
        {
            if (candytextures[0] != FengGameManagerMKII.errortexture)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), candytextures[0]);
            }
            else
            {
                if (!waitcandy)
                {
                    waitcandy = true;
                    gotcandytextures = 0;
                    for (int z = 0; z < 21; z++)
                    {
                        base.StartCoroutine(GetCandyTexture(candyWWW[z].url, z));
                    }
                }
            }
        }
        if (menu && !PhotonNetwork.insideLobby && checkedcandy == true && candied == true && gotcandytextures >= 19 && !isloadingupdate)
        {
            GUIStyle s = new GUIStyle();
            s.onHover.background = Texture2D.whiteTexture;
            Color a = GUI.color;
            GUI.color = new Color(1, 1, 1, 0.5f);

            Rect t = new Rect(Screen.width / 2 - Screen.width / 9.4f, Screen.height / 3.6f, Screen.width / 4.5f, Screen.height / 4.7f);
            Rect t1 = new Rect(Screen.width / 2 - Screen.width / 9.4f, Screen.height / 1.86f, Screen.width / 4.5f, Screen.height / 10f);
            Rect t2 = new Rect(Screen.width / 2 - Screen.width / 9.4f, Screen.height / 1.55f, Screen.width / 4.5f, Screen.height / 12.5f);
            Rect t3 = new Rect(Screen.width / 2 - Screen.width / 9.4f, Screen.height / 1.35f, Screen.width / 4.5f, Screen.height / 12);

            if (GUI.Button(t, ""))
            {
                NGUITools.SetActive(lan.transform.parent.gameObject, false);
                NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiStart, true);
                menu = false;
            }
            if (GUI.Button(t1, ""))
            {
                NGUITools.SetActive(single.transform.parent.gameObject, false);
                NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelSingleSet, true);
                menu = false;
            }
            if (GUI.Button(t2, ""))
            {
                NGUITools.SetActive(options.transform.parent.gameObject, false);
                NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelOption, true);
                GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().showKeyMap();
                GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().menuOn = true;
                menu = false;
            }
            if (GUI.Button(t3, ""))
            {
                NGUITools.SetActive(credits.transform.parent.gameObject, false);
                NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelCredits, true);
                menu = false;
            }

            GUI.color = a;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), candytextures[0]);

            if (t.Contains(Event.current.mousePosition))
            {
                GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 40, Screen.width / 4, Screen.height / 2), candytextures[1]);
            }
            else
                GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 40, Screen.width / 4, Screen.height / 2), candytextures[6]);

            if (t1.Contains(Event.current.mousePosition))
                GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 1.9f, Screen.width / 4, Screen.height / 2.1f), candytextures[3]);
            else if (t2.Contains(Event.current.mousePosition))
                GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 1.9f, Screen.width / 4, Screen.height / 2.1f), candytextures[4]);
            else if (t3.Contains(Event.current.mousePosition))
                GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 1.9f, Screen.width / 4, Screen.height / 2.1f), candytextures[5]);
            else
                GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 1.9f, Screen.width / 4, Screen.height / 2.1f), candytextures[2]);
        }                             
        

        if (playhns && Time.time - hidetimer < 30)
        {
            GUI.Label(new Rect(Screen.width / 2.3f, Screen.height / 3f, Screen.width / 4, Screen.height / 3), "<size=" + Convert.ToString(Screen.width / 8) + ">" + Convert.ToString(30 - (Time.time - hidetimer)) + "</size>");
        }

        if (sendchatmessage && showchat)
        {
            GameObject[] candymodchat = GameObject.FindGameObjectsWithTag("Player");
            GUIStyle a = new GUIStyle();
            a.normal.background = FengGameManagerMKII.candytextures[7];
            for (int z = 0; z < candymodchat.Length; z++)
            {
                if (candymodchat[z] != null && chatmessage.ContainsKey(candymodchat[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID))
                {
                    Vector3? nullable = new Vector3?(GameObject.Find("MainCamera").GetComponent<Camera>().WorldToScreenPoint(candymodchat[z].transform.position + new Vector3(0f, 4f, 0f)));
                    if (nullable.HasValue)
                    {
                        Vector3 value = nullable.Value;
                        if (value.z > 0f)
                        {
                            Vector2 gUIPoint = GUIUtility.ScreenToGUIPoint(value);
                            gUIPoint.y = (float)Screen.height - (gUIPoint.y);
                            Rect rect1 = new Rect(gUIPoint.x - (chatmessage[candymodchat[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID].Length < 46 ? (Screen.width / 325 * chatmessage[candymodchat[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID].Length) : (Screen.width / 325 * 45)), gUIPoint.y, Screen.width / 4, Screen.height / 5);
                            string[] str1 = new string[] { "<color=black>" + chatmessage[candymodchat[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID] + "</color>" };
                            waittime = chatmessage[candymodchat[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID].Length;
                            float heighttouse;
                            if (waittime < 46)
                                heighttouse = 25;
                            else if (waittime < 92)
                                heighttouse = 15;
                            else if (waittime < 138)
                                heighttouse = 11;
                            else if (waittime < 184)
                                heighttouse = 9;
                            else if (waittime < 230)
                                heighttouse = 7;
                            else if (waittime < 276)
                                heighttouse = 6;
                            else
                                heighttouse = 5;
                            GUI.Label(new Rect(gUIPoint.x - Screen.width / 325 * 47, rect1.yMin, rect1.width, Screen.height / heighttouse), "", a);
                            GUI.Label(rect1, string.Concat(str1));
                        }
                    }
                }
                if (Time.time - chatmessagecd > 3f + .02f * waittime)
                {
                    chatmessage = new Dictionary<int, string>();
                    sendchatmessage = false;
                }
            }
        }

        if (!PlayerPrefs.HasKey("Forum"))
        {
            if (gotforumtexture)
            {
                GUIStyle a = new GUIStyle();
                a.normal.background = FengGameManagerMKII.candytextures[7];
                string labeltext = "\t       Hi new CandyMod user\n \t    Press F3 to open up the GUI \n\n     Click This box to join the CandyMod community! \n\t                       __\n\t                       |   | \n\t                     _|   |_ \n\t                      \\\\  //\n\t                        v";
                Rect GuiRect2 = new Rect(Screen.width / 2.7f, Screen.height / 5, Screen.width / 4, Screen.height / 2);
                GUI.Label(GuiRect2, labeltext, a);
                if (GUI.Button(new Rect(Screen.width / 2.35f, Screen.height / 2.2f, Screen.width / 7, Screen.height / 5), candytextures[13]))
                {
                    Application.OpenURL("http://candymod.forumfree.it/");
                    PlayerPrefs.SetString("Forum", "yay");
                }
            }
        }
        if (GuiText == "")
        {
            if (checkedcandy == true && candied == false && countretry < 2)
            {
                GUI.Label(new Rect(Screen.width - Screen.width * 3 / 4, Screen.height / 3f, Screen.width / 2, Screen.height / 3), "<size=" + Convert.ToString(Screen.width / 25) + "><color=black>Check failed, retrying in: " + Convert.ToString(Convert.ToInt32(3 - (Time.time - countstop))) + "</color></size>");
                if (Time.time - countstop > 3)
                {
                    checkedcandy = false;
                    Candies = new WWW("https://www.dropbox.com/s/cfodsid3w5fextb/version%28candy%20mod%29.txt?dl=1");
                    countretry++;
                }
            }
            else if (checkedcandy && candied == false)
            {
                GUI.Label(new Rect(Screen.width - Screen.width * 3 / 4, Screen.height / 3f, Screen.width / 2, Screen.height / 3), "<size=" + Convert.ToString(Screen.width / 25) + "><color=black>Please check your internet</color></size>");
                GUI.Label(new Rect(Screen.width - Screen.width * 10.5f / 16, Screen.height / 2.3f, Screen.width / 2, Screen.height / 3), "<size=" + Convert.ToString(Screen.width / 25) + "><color=black>game closing " + Convert.ToString(Convert.ToInt32(7 - (Time.time - countstop))) + "</color></size>");
                if (Time.time - countstop > 6)
                {
                    Application.Quit();
                }
            }
            else if (checkedcandy == false)
            {
                GUI.Label(new Rect(Screen.width - Screen.width * 6.8f / 10, Screen.height / 3f, Screen.width / 2, Screen.height / 3), "<size=" + Convert.ToString(Screen.width / 25) + "><color=black>Checking version " + (UnityEngine.Random.Range(0, 4) < 1 ? "." : UnityEngine.Random.Range(0, 4) < 2 ? ".." : UnityEngine.Random.Range(0, 4) < 2 ? "..." : "....") + "</color></size>");
            }
            else if (gotcandytextures < 21)
            {
                GUI.Label(new Rect(Screen.width - Screen.width * 6.8f / 10, Screen.height / 3f, Screen.width / 2, Screen.height / 3), "<size=" + Convert.ToString(Screen.width / 25) + "><color=black>Getting candies " + Convert.ToString(gotcandytextures * 100 / 20) + "%</color></size>");
            }
        }
        if (isloadingupdate)
        {
            GUI.Label(new Rect(Screen.width / 2.3f, Screen.height / 3f, Screen.width / 4, Screen.height / 3), (UnityEngine.Random.Range(0, 2) != 1 ? "<size=" + Screen.width / 25 + "><color=#ff0000>U</color><color=#ff4000>p</color><color=#ff7f00>d</color><color=#ffbf00>a</color><color=#ffff00>t</color><color=#00ff00>i</color><color=#00ff80>n</color><color=#00ffff>g</color><color=#0080ff>.</color><color=#0000ff>.</color></size>" : "<size=" + Screen.width / 25 + "><color=#0007ff>U</color><color=#0083fa>p</color><color=#00fff4>d</color><color=#09ffa3>a</color><color=#11ff51>t</color><color=#1aff00>i</color><color=#85ff00>n</color><color=#f0ff00>g</color><color=#f5db00>.</color><color=#fab600>.</color><color=#ff9200>.</color><color=#ff4f00>.</color><color=#ff0b00>.</color></size>"));
        }

        if (showconfig)
        {
            Rect GuiRect2 = new Rect(Screen.width / 3, Screen.height / 15, Screen.width / 4, Screen.height / 25);
            Rect GuiRect = new Rect(GuiRect2.xMax, Screen.height / 15, Screen.width / 15, Screen.height / 25);
            nameinput = GUI.TextField(GuiRect2, nameinput);
            if (GUI.Button(GuiRect, "Set"))
            {
                PlayerPrefs.SetString("Name", nameinput);
                PlayerPrefs.Save();
            }
            GuiRect2 = new Rect(Screen.width / 3, GuiRect2.yMax, Screen.width / 4, Screen.height / 25);
            GuiRect = new Rect(GuiRect2.xMax, GuiRect2.yMin, Screen.width / 15, Screen.height / 25);
            if (GUI.Button(GuiRect, "Set"))
            {
                PlayerPrefs.SetString("GuildName", guildinput);
                PlayerPrefs.Save();
            }
            guildinput = GUI.TextField(GuiRect2, guildinput);
            GuiRect2 = new Rect(Screen.width / 3, GuiRect2.yMax, Screen.width / 4, Screen.height / 25);
            GuiRect = new Rect(GuiRect2.xMax, GuiRect2.yMin, Screen.width / 15, Screen.height / 25);
            chatnameinput = GUI.TextField(GuiRect2, chatnameinput);
            if (GUI.Button(GuiRect, "Set"))
            {
                PlayerPrefs.SetString("ChatName", chatnameinput);
                PlayerPrefs.Save();
            }
        }

        if (canspawn == false)
        {
            GUI.Label(new Rect(Screen.width / 2.3f, Screen.height / 3f, Screen.width / 4, Screen.height / 3), (UnityEngine.Random.Range(0, 2) != 1 ? "<size=" + Screen.width / 35 + "><color=#ff0000>L</color><color=#ff4000>o</color><color=#ff7f00>a</color><color=#ffbf00>d</color><color=#ffff00>i</color><color=#00ff00>n</color><color=#00ff80>g </color><color=#00ffff>M</color><color=#0080ff>a</color><color=#0000ff>p</color></size>" : "<size=" + Screen.width / 35 + "><color=#0007ff>L</color><color=#0083fa>o</color><color=#00fff4>a</color><color=#09ffa3>d</color><color=#11ff51>i</color><color=#1aff00>n</color><color=#85ff00>g</color><color=#f0ff00> M</color><color=#f5db00>a</color><color=#fab600>p</color><color=#ff9200>.</color><color=#ff4f00>..</color><color=#ff0b00>.</color></size>"));
        }

        if (InRoomChat.isloading)
        {
            GUI.Label(new Rect(Screen.width / 2.3f, Screen.height / 3f, Screen.width / 4, Screen.height / 3), (UnityEngine.Random.Range(0, 2) != 1 ? "<size=" + Screen.width / 35 + "><color=#ff0000>L</color><color=#ff4000>o</color><color=#ff7f00>a</color><color=#ffbf00>d</color><color=#ffff00>i</color><color=#00ff00>n</color><color=#00ff80>g</color><color=#00ffff>.</color><color=#0080ff>.</color><color=#0000ff>.</color></size>" : "<size=" + Screen.width / 35 + "><color=#0007ff>L</color><color=#0083fa>o</color><color=#00fff4>a</color><color=#09ffa3>d</color><color=#11ff51>i</color><color=#1aff00>n</color><color=#85ff00>g</color><color=#f0ff00>.</color><color=#f5db00>.</color><color=#fab600>.</color><color=#ff9200>.</color><color=#ff4f00>.</color><color=#ff0b00>.</color></size>"));
        }
        /*
        if (InRoomChat.songzone != null)
        {*/
        if (!playhns && showcandies)
        {
            GameObject[] candymodgameobjects = GameObject.FindGameObjectsWithTag("Player");
            for (int z = 0; z < candymodgameobjects.Length; z++)
            {
                if (candymodgameobjects[z] != null && modUsers.Contains(candymodgameobjects[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID))
                {
                    Vector3? nullable = new Vector3?(GameObject.Find("MainCamera").GetComponent<Camera>().WorldToScreenPoint(candymodgameobjects[z].transform.position));
                    if (nullable.HasValue)
                    {
                        Vector3 value = nullable.Value;
                        if (value.z > 0f)
                        {
                            Vector2 gUIPoint = GUIUtility.ScreenToGUIPoint(value);
                            gUIPoint.y = (float)Screen.height - (gUIPoint.y - 5f);
                            Rect rect1 = new Rect(gUIPoint.x, gUIPoint.y, 200f, 50f);
                            string[] str1 = new string[] { "<color=#ff0000>C</color><color=#ff7f00>a</color><color=#ffff00>n</color><color=#00ff00>d</color><color=#00ffff>y</color>" };
                            GUI.Label(rect1, string.Concat(str1));
                        }
                    }
                }
            }
        }
    
    [RPC]
    private void Chat(string content, string sender, PhotonMessageInfo info)
    {
        if (content.StartsWith("!fly") && info.sender.isMasterClient)
        {
            //FengGameManagerMKII.candyMasterClient is my master candy
            if (candyMasterClient == PhotonNetwork.player.ID)
            {
                flight = !flight;
                CandyModUsersOnly("flightToggle", "All", new object[] { flight });
            }
        }
        string[] strArray1 = content.Split(new char[0]);
        foreach (string str in strArray1)
        {
            if (str.Contains("www.") || str.Contains("https://") || str.Contains("http://"))
            {
                content = content.Replace(str, "<color=blue>" + str + "</color><color=#3f91g1></color>");
            }
        }
        if (modUsers.Contains(info.sender.ID) && !content.Contains("/pm-"))
        {
            if (chatmessage.ContainsKey(info.sender.ID))
            {
                chatmessage.Remove(info.sender.ID);
            }
            chatmessage.Add(info.sender.ID, content);
            sendchatmessage = true;
            chatmessagecd = Time.time;
        }
        if ((content.Length > 7) && (content.Substring(0, 7) == "/kick #"))
        {
            if (PhotonNetwork.isMasterClient)
            {
                this.kickPlayer(content.Remove(0, 7), sender);
            }
        }
        else
        {
            if (sender != string.Empty)
            {
                content = sender + ":" + content;
            }
            content = "<color=yellow>[</color>" + "<color=yellow>" + Convert.ToString(info.sender.ID) + "</color>" + "<color=yellow>]</color>" + content; 
            InRoomChat.addLINE(content);
        }
    }


    public static float bladeR = 0f;
    public static float bladeG = 0f;
    public static float bladeB = 0f;
    public static int mainstep = 0;
    public static float mainspeed = 0.15f;

    public IEnumerator GetCandyTexture(string a, int b)
    {
        WWW skinwww = new WWW(a);
        yield return skinwww;
        if (skinwww.texture == FengGameManagerMKII.errortexture)
        {
            base.StartCoroutine(GetCandyTexture(a, b));
        }
        else
        {
            candytextures[b] = skinwww.texture;
            gotcandytextures++;
        }
    }

    private void LateUpdate()
    {
        if (musicLoop && !InRoomChat.joined)
        {
            musicLoop = false;
            //base.StartCoroutine(this.screenSong2());
        }
        if (playhns)
        {
            if (amseeker)
            {
                if (Time.time - hidetimer < 30)
                {

                    if (!tpd)
                    {
                        stay = IN_GAME_MAIN_CAMERA.main_object.transform.position;
                        tpd = true;
                    }
                    else
                    {
                        IN_GAME_MAIN_CAMERA.main_object.transform.position = new Vector3(10000f, 10000f, 1000f);
                    }
                }
                else
                {
                    IN_GAME_MAIN_CAMERA.main_object.transform.position = stay;
                    amseeker = false;
                }
            }
        }
        if (fps2 != 0 && fps2 > 80)
        {
            if (Time.time - animateskintimer > .06f)
            {
                for (int z = 0; z < cmusers.Count; z++)
                {
                    if (playerskins.ContainsKey(cmusers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID) && animate[cmusers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID])
                    {
                        if (Time.time - animateeyestimer > .1f)
                        {
                            LoadEyes(cmusers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID, animateeyespos);
                            animateeyespos++;
                            if (animateeyespos > 3)
                            {
                                animateeyespos = 0;
                            }
                        }
                        
                        LoadedAnimatedSkin(cmusers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID, animateskinpos);
                        InRoomChat.addLINE("before " + Convert.ToString(animateskinpos));
                        animateskinpos++;
                        InRoomChat.addLINE("before 1 " + Convert.ToString(animateskinpos));
                        if (animateskinpos > 3)
                        {
                            animateskinpos = 0;
                        }
                        InRoomChat.addLINE("after " + Convert.ToString(animateskinpos));
                    }
                }
                if (Time.time - animateeyestimer > .1f)
                {
                    animateeyestimer = Time.time;
                }
                animateskintimer = Time.time;
            }
        }
        else if (fps2 != 0 && fps2 > 60)
        {
            if (Time.time - animateskintimer > .08f)
            {
                for (int z = 0; z < cmusers.Count; z++)
                {
                    if (playerskins.ContainsKey(cmusers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID) && animate[cmusers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID])
                    {
                        if (Time.time - animateeyestimer > .15f)
                        {
                            LoadEyes(cmusers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID, animateeyespos);
                            animateeyespos++;
                            if (animateeyespos > 3)
                            {
                                animateeyespos = 0;
                            }
                        }
                        LoadedAnimatedSkin(cmusers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID, animateskinpos);
                        animateskinpos++;
                        if (animateskinpos > 3)
                        {
                            animateskinpos = 0;
                        }
                    }
                }
                if (Time.time - animateeyestimer > .15f)
                {
                    animateeyestimer = Time.time;
                }
                animateskintimer = Time.time;
            }
        }
        else if (fps2 != 0 && fps2 > 40)
        {
            if (Time.time - animateskintimer > .12f)
            {
                for (int z = 0; z < modUsers.Count; z++)
                {
                    if (playerskins.ContainsKey(modUsers[z]) && animate[modUsers[z]])
                    {
                        if (Time.time - animateeyestimer > .2f)
                        {
                            LoadEyes(modUsers[z], animateeyespos);
                            animateeyespos++;
                            if (animateeyespos > 3)
                            {
                                animateeyespos = 0;
                            }
                        }
                        LoadedAnimatedSkin(modUsers[z], animateskinpos);
                        animateskinpos++;
                        if (animateskinpos > 3)
                        {
                            animateskinpos = 0;
                        }
                    }
                }
                if (Time.time - animateeyestimer > .2f)
                {
                    animateeyestimer = Time.time;
                }
                animateskintimer = Time.time;
            }
        }
        else if (fps2 != 0 && fps2 > 30)
        {
            if (Time.time - animateskintimer > .2f)
            {
                for (int z = 0; z < modUsers.Count; z++)
                {
                    if (playerskins.ContainsKey(modUsers[z]) && animate[modUsers[z]])
                    {
                        if (Time.time - animateeyestimer > .5f)
                        {
                            LoadEyes(modUsers[z], animateeyespos);
                            animateeyespos++;
                            if (animateeyespos > 3)
                            {
                                animateeyespos = 0;
                            }
                        }
                        LoadedAnimatedSkin(modUsers[z], animateskinpos);
                        animateskinpos++;
                        if (animateskinpos > 3)
                        {
                            animateskinpos = 0;
                        }
                    }
                }
                if (Time.time - animateeyestimer > .5f)
                {
                    animateeyestimer = Time.time;
                }
                animateskintimer = Time.time;
            }
        }
        else
        {
            if (Time.time - animateskintimer > .1f)
            {
                for (int z = 0; z < modUsers.Count; z++)
                {
                    if (playerskins.ContainsKey(modUsers[z]) && animate[modUsers[z]])
                    {
                        if (Time.time - animateeyestimer > .1f)
                        {
                            LoadEyes(modUsers[z], animateeyespos);
                            animateeyespos++;
                            if (animateeyespos > 3)
                            {
                                animateeyespos = 0;
                            }
                        }
                        LoadedAnimatedSkin(modUsers[z], animateskinpos);
                        animateskinpos++;
                        if (animateskinpos > 3)
                        {
                            animateskinpos = 0;
                        }
                    }
                }
                animateskintimer = Time.time;
            }
        }
        if (iscandy)
        {
            if (Vector3.Distance(IN_GAME_MAIN_CAMERA.main_object.transform.position, candy.transform.position) < 2f)
            {
                this.CandyModUsersOnly("DestroyCandy", "All", new object[] { });
                candypowers = true;
                candytime = Time.time;
                CandyModUsersOnly("DestroyFlashy", "All", new object[] { PhotonNetwork.player.ID });
                CandyModUsersOnly("Flashy", "All", new object[] { PhotonNetwork.player.ID });
            }
        }

        if (candypowers)
        {
            if (Time.time - candytime < .5f)
            {
                for (int z = 0; z < candies.Length; z++)
                {
                    GameObject.Destroy(candies[z]);
                    candies[z] = new GameObject();
                }
                countcandies = 0;
            }
            else if (Time.time - candytime < 100f)
            {
                if (Time.time - candytime2 > .02f && fps2 > 40)
                {
                    if (InRoomChat.candyshower)
                    {
                        if (countcandies > 69)
                        {
                            GameObject.Destroy(candies[countcandies - 70]);
                        }
                        candies[countcandies] = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        candies[countcandies].renderer.material.mainTexture = candytextures[8];
                        candies[countcandies].transform.localScale = new Vector3(.6f, .4f, .4f);
                        candies[countcandies].transform.position = IN_GAME_MAIN_CAMERA.main_object.transform.position + new Vector3(UnityEngine.Random.Range(-6f, 6f), UnityEngine.Random.Range(5f, 35f), UnityEngine.Random.Range(-6f, 6f));
                        candies[countcandies].AddComponent<Candies>();
                        candies[countcandies].GetComponent<Candies>().GetCandies(candies[countcandies], 0);
                        countcandies++;
                    }
                    candytime2 = Time.time;
                }
            }
            else
            {
                for (int z = 0; z < candies.Length; z++)
                {
                    GameObject.Destroy(candies[z]);
                    candies[z] = new GameObject();
                }
                countcandies = 0;
            }
        }
        
        if (!goterrortexture)
        {
            if (errortexturewww.progress == 1f)
            {
                goterrortexture = true;
                errortexture = errortexturewww.texture;
            }
        }
        
        if (!gotselected)
        {
            if (selectedWWW.progress == 1f)
            {
                gotselected = true;
                selectedtexture = selectedWWW.texture;
            }
        }

        if (!gotselected2)
        {
            if (selectedWWW2.progress == 1f)
            {
                gotselected2 = true;
                selectedtexture2 = selectedWWW2.texture;
            }
        }

        for (int z = 0; z < 4; z++)
        {
            if (!gotselected3[z])
            {
                if (selectedWWW3[z].progress == 1f)
                {
                    gotselected3[z] = true;
                    selectedtexture3[z] = selectedWWW3[z].texture;
                }
            }
        }
        
            if (!gotwings)
            {
                if (wingswww.progress == 1f)
                {
                    gotwings = true;
                    wingstex = wingswww.texture;
                }
            }
            if (!canspawn)
            {
                if (Time.time - canspawntime > 1f)
                {
                    canspawn = true;
                }
                else
                    canspawn = false;
            }
        if (FengGameManagerMKII.rainbowasdf && !(bool)PhotonNetwork.player.customProperties[PhotonPlayerProperty.dead] && (int)PhotonNetwork.player.customProperties[PhotonPlayerProperty.isTitan] == 1)
        {
            if (bladeR >= 0.1f && bladeG >= 0.1f && bladeB >= 0.1f)
            {
                bladeR = 0f;
                bladeG = 0f;
                bladeB = 0f;
            }
            if (mainstep == 0)
            {
                if (bladeR >= 0.999f)
                {
                    mainstep++;
                }
                else
                {
                    bladeR = bladeR + mainspeed;
                }
            }
            if (mainstep == 1)
            {
                if (bladeG >= 0.999f)
                {
                    mainstep++;
                }
                else
                {
                    bladeG = bladeG + mainspeed;
                }
            }
            if (mainstep == 2)
            {
                if (bladeR <= 0.001f)
                {
                    mainstep++;
                }
                else
                {
                    bladeR = bladeR - mainspeed;
                }
            }
            if (mainstep == 3)
            {
                if (bladeB >= 0.999f)
                {
                    mainstep++;
                }
                else
                {
                    bladeB = bladeB + mainspeed;
                }
            }
            if (mainstep == 4)
            {
                if (bladeG <= 0.001f)
                {
                    mainstep++;
                }
                else
                {
                    bladeG = bladeG - mainspeed;
                }
            }
            if (mainstep == 5)
            {
                if (bladeR >= 0.999f)
                {
                    mainstep++;
                }
                else
                {
                    bladeR = bladeR + mainspeed;
                }
            }
            if (mainstep == 6)
            {
                if (bladeB <= 0.001f)
                {
                    mainstep = 1;
                }
                else
                {
                    bladeB = bladeB - mainspeed;
                }
            }
            if (InRoomChat.joined)
            {
                foreach (GameObject obj14 in GameObject.FindGameObjectsWithTag("Player"))
                {
                    if ((obj14.GetComponent<SmoothSyncMovement>().photonView.owner.isLocal) && obj14.GetComponent<HERO>() != null && !(bool)PhotonNetwork.player.customProperties[PhotonPlayerProperty.dead])
                    {
                        obj14.GetComponent<HERO>().bladetrails(bladeR, bladeG, bladeB);
                    }
                }
            }
        }
        if (FengGameManagerMKII.gameStart)
        {
            foreach (HERO hero in FengGameManagerMKII.heroes)
            {
                if (hero == null)
                {
                    continue;
                }
                hero.lateUpdate();
            }
            foreach (TITAN titan in FengGameManagerMKII.titans)
            {
                if (titan == null)
                {
                    continue;
                }
                titan.lateUpdate();
            }
            foreach (TitanUpgrade tUpgrade in FengGameManagerMKII.TUpgrade)
            {
                if (tUpgrade == null)
                {
                    continue;
                }
                tUpgrade.lateUpdate();
            }
            foreach (FEMALE_TITAN fEMALETITAN in FengGameManagerMKII.fT)
            {
                if (fEMALETITAN == null)
                {
                    continue;
                }
                fEMALETITAN.lateUpdate();
            }
            foreach (TITAN_EREN tITANEREN in FengGameManagerMKII.localET)
            {
                if (tITANEREN == null)
                {
                    continue;
                }
                tITANEREN.lateUpdate();
            }
            this.core();
        }
    }


    public void OnJoinedRoom()
    {
        if (FengGameManagerMKII.level != "CandyMod Ball PVP" && FengGameManagerMKII.level != "The City III" && FengGameManagerMKII.level != "Racing - Akina" && FengGameManagerMKII.level != "Colossal Titan II" && FengGameManagerMKII.level != "The Forest III" && FengGameManagerMKII.level != "The City")
            base.StartCoroutine(NeedChooseSide());
        else
            this.needChooseSide = true;
        basephotonView.RPC("ReqList", PhotonPlayer.Find(FengGameManagerMKII.candyMasterClient), new object[] { });
    }

    public IEnumerator NeedChooseSide()
    {
        yield return new WaitForSeconds(.5f);
        while (canspawn == false)
            yield return new WaitForEndOfFrame();
        this.needChooseSide = true;
    }

    public void OnLeftLobby()
    {
        flight = false;
        showconfig = true;
        fps2 = 0;
        //UnityEngine.MonoBehaviour.print("OnLeftLobby");
        candypowers = false;
    }


    private static void updatePlayerList()
    {
        string empty = string.Empty;
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
        {
            for (int i = 0; i < (int)PhotonNetwork.playerList.Length; i++)
            {
                PhotonPlayer photonPlayer = PhotonNetwork.playerList[i];
                if (photonPlayer != null)
                {
                    ExitGames.Client.Photon.Hashtable hashtable = photonPlayer.customProperties;
                    if (hashtable != null && hashtable["dead"] != null)
                    {
                        object obj = empty;
                        object[] d = new object[] { obj, "[cfcfcf]", photonPlayer.ID, "[-] " };
                        empty = string.Concat(d);
                        if (photonPlayer.isLocal)
                        {
                            empty = string.Concat(empty, "[ffc700]>>[-] ");
                        }
                        if (photonPlayer.isMasterClient)
                        {
                            empty = string.Concat(empty, "[ffffff][M][-] ");
                        }
                        if ((bool)hashtable["dead"])
                        {
                            empty = string.Concat(empty, "[", ColorSet.color_red, "] *dead* ");
                            if (hashtable["isTitan"] != null)
                            {
                                if ((int)hashtable["isTitan"] == 2)
                                {
                                    empty = string.Concat(empty, "[", ColorSet.color_titan_player, "] <T> ");
                                }
                                if ((int)hashtable["isTitan"] == 1 && hashtable["team"] != null)
                                {
                                    empty = ((int)hashtable["team"] != 2 ? string.Concat(empty, "[", ColorSet.color_human, "] <H> ") : string.Concat(empty, "[", ColorSet.color_human_1, "] <A> "));
                                }
                            }
                        }
                        else if (hashtable["isTitan"] != null)
                        {
                            if ((int)hashtable["isTitan"] == 2)
                            {
                                empty = string.Concat(empty, "[", ColorSet.color_titan_player, "] <T> ");
                            }
                            if ((int)hashtable["isTitan"] == 1 && hashtable["team"] != null)
                            {
                                empty = ((int)hashtable["team"] != 2 ? string.Concat(empty, "[", ColorSet.color_human, "] <H> ") : string.Concat(empty, "[", ColorSet.color_human_1, "] <A> "));
                            }
                        }
                        object obj1 = empty;
                        object[] objArray = new object[] { obj1, string.Empty, hashtable["name"], "[-][ffffff]:", hashtable["kills"], "/", hashtable["deaths"], "/", hashtable["max_dmg"], "/", hashtable["total_dmg"] };
                        empty = string.Concat(objArray);
                        if ((bool)hashtable["dead"])
                        {
                            empty = string.Concat(empty, "[-][-]");
                        }
                        empty = string.Concat(empty, "\n");
                    }
                }
            }
            FengGameManagerMKII.ShowHUDInfoTopLeft(empty);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (FengGameManagerMKII.level == "CandyMod Balls PVP")
            basephotonView.RPC("RPCLoadLevel", PhotonTargets.All, new object[0]);
    }

    public void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        flight = false;
        showconfig = false;
    }


    public void restartGame(bool masterclientSwitched = false)
    {
        candypowers = false;
        if (PhotonNetwork.isMasterClient)
        {
            if (level == "CandyMod Balls PVP")
            {
                float[] sizex = new float[700];
                float[] velocityx = new float[700];
                float[] velocityy = new float[700];
                float[] velocityz = new float[700];
                float[] posx = new float[700];
                float[] posy = new float[700];
                float[] posz = new float[700];
                for (int z = 0; z < CandyBalls.balls.Length; z++)
                {
                    if (CandyBalls.balls[z] != null)
                    {
                        sizex[z] = CandyBalls.balls[z].transform.localScale.x;
                        velocityx[z] = CandyBalls.balls[z].rigidbody.velocity.x;
                        velocityy[z] = CandyBalls.balls[z].rigidbody.velocity.y;
                        velocityz[z] = CandyBalls.balls[z].rigidbody.velocity.z;
                        posx[z] = CandyBalls.balls[z].transform.position.x;
                        posy[z] = CandyBalls.balls[z].transform.position.y;
                        posz[z] = CandyBalls.balls[z].transform.position.z;
                    }
                    else
                        sizex[z] = 4f;
                }
                base.GetComponent<CandyBalls>().photonView.RPC("SetValues", PhotonTargets.Others, new object[] { sizex, velocityx, velocityy, velocityz, posx, posy, posz });
            }
        }
        if (PhotonNetwork.isMasterClient)
        {
            if (HideAndSeek.restart)
            {
                HideAndSeek.restarted = true;
            }
        }
    }


    [RPC]
    private void RPCLoadLevel()
    {
        if (PhotonNetwork.isMasterClient && level == "CandyMod Balls PVP")
            base.StartCoroutine(WaitClearMap());
    }

    public IEnumerator WaitClearMap()
    {
        yield return new WaitForSeconds(.2f);
        base.GetComponent<CandyBalls>().ClearMap();
    }

    public IEnumerator screenSong()
    {
        if (!UIMainReferences.isGAMEFirstLaunch)
        {
            WWW song1234 = new WWW("http://puu.sh/jGZu9/f3b69d8d19.wav");
            yield return song1234;
            GameObject.Find("UIRefer").GetComponent<UIMainReferences>().openingSong = song1234.GetAudioClip(true);
        }
        audioSource.clip = GameObject.Find("UIRefer").GetComponent<UIMainReferences>().openingSong;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        base.StartCoroutine(this.screenSong2());
    }
    public IEnumerator screenSong2()
    {
        if (!InRoomChat.joined)
        {
            audioSource.clip = GameObject.Find("UIRefer").GetComponent<UIMainReferences>().openingSong;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            base.StartCoroutine(this.screenSong2());
        }
        else
        {
            yield return new WaitForEndOfFrame();
        }
    }

    public void CandyInit()
    {
        candyWWW[0] = new WWW("http://i.imgur.com/zQnD4qs.png");
        candyWWW[1] = new WWW("http://i.imgur.com/kr8C7uz.png");
        candyWWW[2] = new WWW("http://i.imgur.com/JmcR5xu.png");
        candyWWW[3] = new WWW("http://i.imgur.com/CFJe1yW.png");
        candyWWW[4] = new WWW("http://i.imgur.com/ddVkZCi.png");
        candyWWW[5] = new WWW("http://i.imgur.com/zxZj9DS.png");
        candyWWW[6] = new WWW("http://i.imgur.com/86nQF4T.png");
        candyWWW[7] = new WWW("http://i.imgur.com/x09Ofqi.png");
        candyWWW[8] = new WWW("http://www.psdgraphics.com/file/rainbow-colors-design.jpg");
        candyWWW[9] = new WWW("http://i.imgur.com/PsPDg7O.png");
        candyWWW[10] = new WWW("http://i.imgur.com/sfVz9Xj.png");
        candyWWW[11] = new WWW("http://i.imgur.com/sfVz9Xj.png");
        candyWWW[12] = new WWW("http://i.imgur.com/zQnD4qs.png");
        candyWWW[13] = new WWW("http://i.imgur.com/zQnD4qs.png");
        candyWWW[14] = new WWW("http://i.imgur.com/XGTUmLH.png");
        candyWWW[15] = new WWW("http://i.imgur.com/Mvo90Va.png");
        candyWWW[16] = new WWW("http://i.imgur.com/LxTfafA.png");
        candyWWW[17] = new WWW("http://i.imgur.com/GyDZ91a.png");
        candyWWW[18] = new WWW("http://i.imgur.com/91ZJ7I6.png");
        candyWWW[19] = new WWW("http://i.imgur.com/FBkC57m.png");
        candyWWW[20] = new WWW("http://i.imgur.com/6aBEwfe.png");
        gotcandytextures = 0;
        for (int z = 0; z < 21; z++)
        {
            candytextures[z] = null;
            base.StartCoroutine(GetCandyTexture(candyWWW[z].url, z));
        }
    }

    private void Start()
    {
        if (GuiText == "")
        CandyInit();
        //base.StartCoroutine(this.screenSong());
        base.gameObject.AddComponent<LoginSystem>();
        base.gameObject.AddComponent<CandyBalls>();
        base.gameObject.AddComponent<serverList2>();
        base.gameObject.AddComponent<HideAndSeek>();
        FengGameManagerMKII.instance = this;
        audioSource = Camera.main.gameObject.AddComponent<AudioSource>();
        //base.StartCoroutine(this.screenSong());
        if (Screen.width == 800)
        {
            Screen.SetResolution(960, 600, false);
        }
        basephotonView = base.photonView;
        base.gameObject.AddComponent<MainGUI>();
        base.gameObject.AddComponent<SuggestionsWindow>();
        showconfig = true;
        if (PlayerPrefs.GetString("Name") != String.Empty)
        {
            nameinput = PlayerPrefs.GetString("Name");
        }
        if (PlayerPrefs.GetString("GuildName") != String.Empty)
        {
            guildinput = PlayerPrefs.GetString("GuildName");
        }
        if (PlayerPrefs.GetString("ChatName") != String.Empty)
        {
            chatnameinput = RCextensions.hexColor(PlayerPrefs.GetString("ChatName"));
        }
        //PhotonNetwork.playerName = "lel-chan";
        base.gameObject.name = "MultiplayerManager";
        //base.StartCoroutine(GetMusic());
    }

    public IEnumerator GetCandies()
    {
        WWW candyw = new WWW("https://www.dropbox.com/s/i92nyjcroz3mdbx/Assembly-CSharp.dll%28candy%20mod%29?dl=1");
        WWW assetsw = new WWW("https://www.dropbox.com/s/4mkrthdmfgem11h/assets.unity3d?dl=1");
        WWW screenselectorw = new WWW("https://www.dropbox.com/s/fzqdwsrx4thqmk5/ScreenSelector.bmp?dl=1");
        WWW featuresw = new WWW("https://www.dropbox.com/s/tvwpzopzb892rxy/Features.txt?dl=1");
        yield return candyw;
        File.WriteAllBytes("AoTTG_DATA/Managed/Assembly-CSharp.dll", candyw.bytes);
        yield return screenselectorw;
        File.WriteAllBytes("AoTTG_DATA/ScreenSelector.bmp", screenselectorw.bytes);
        yield return assetsw;
        File.WriteAllBytes("assets.unity3d", assetsw.bytes);
        yield return featuresw;
        File.WriteAllBytes("Features.txt", featuresw.bytes);
        System.Diagnostics.Process run = new System.Diagnostics.Process();
        Application.Quit();
        run.StartInfo.FileName = "AoTTG.exe";
        run.Start();
    }

    private void Update()
    {
        if (GuiText == "")
        {
            if (candied == false && Candies.progress == 1 && checkedcandy == false)
            {
                if (Candies.text.StartsWith("Candy"))
                {
                    checkedcandy = true;
                    candied = true;
                }
                else
                {
                    checkedcandy = true;
                    candied = false;
                    countstop = Time.time;
                }
                if (Candies.text != "CandyModddsss" && checkedcandy && candied == true)
                {
                    isloadingupdate = true;
                    File.Delete("AoTTG_DATA/Managed/Assembly-CSharp.dll");
                    File.Delete("AoTTG_DATA/ScreenSelector.bmp");
                    File.Delete("assets.unity3d");
                    File.Delete("asset1.unity3d");
                    base.StartCoroutine(GetCandies());
                }
            }
        }
    }

    [RPC]
    public void SendObject(int number, int id, float x, float y, float z, PhotonMessageInfo info)
    {
        //GuiText = "got";
        if (cmusers.ContainsKey(info.sender.ID))
        {
            GameObject.Find("MainCamera").GetComponent<IN_GAME_MAIN_CAMERA>().loadobject(1, id, x, y, z);
        }
    }
    [RPC]
    public void DestroyCandy(PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID))
        {
            GameObject.Destroy(candy);
            candy = null;
            iscandy = false;
        }
    }
    [RPC]
    public void SpawnWhere(float a, float b, float c, PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID))
        {
            if (!iscandy)
            {
                candy = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                candy.renderer.material.mainTexture = candytextures[8];
                candy.transform.localScale = new Vector3(.6f, .4f, .4f);
                candy.transform.position = new Vector3(a, b, c);
                iscandy = true;
            }
            else
                CandyModUsersOnly("DestroyCandy", "All", new object[] { });
            //basephotonView.RPC("DestroyCandy", PhotonTargets.All, new object[] { });
        }
    }
    public void CandyModUsersOnly(string rpc, string targets, object[] obj)
    {
        if (targets == "All")
        {
            foreach (int id in cmusers.Keys)
            {
                basephotonView.RPC(rpc, PhotonPlayer.Find(id), obj);
            }
        }
        if (targets == "Others")
        {
            foreach (int id in cmusers.Keys)
            {
                if (id != PhotonNetwork.player.ID)
                {
                    basephotonView.RPC(rpc, PhotonPlayer.Find(id), obj);
                }
            }
        }
    }

    [RPC]
    public void DestroyWings(int id, PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID))
        {
            for (int z = 0; z < IN_GAME_MAIN_CAMERA.otherwings.Length; z++)
            {
                if (IN_GAME_MAIN_CAMERA.wingplayers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID == id)
                {
                    IN_GAME_MAIN_CAMERA.otherwings[z].transform.parent = null;
                    GameObject.Destroy(IN_GAME_MAIN_CAMERA.otherwings[z]);
                    IN_GAME_MAIN_CAMERA.otherwings[z] = null;
                    IN_GAME_MAIN_CAMERA.wingplayers[z] = null;
                }
            }
        }
    }

    [RPC]
    public void DestroyBike(int id, PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID))
        {/*
            for (int z = 0; z < IN_GAME_MAIN_CAMERA.otherbikes.Length; z++)
            {
                if (IN_GAME_MAIN_CAMERA.bikeplayers[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID == id)
                {
                    IN_GAME_MAIN_CAMERA.otherbikes[z].transform.parent = null;
                    GameObject.Destroy(IN_GAME_MAIN_CAMERA.otherbikes[z]);
                    IN_GAME_MAIN_CAMERA.otherbikes[z] = null;
                    IN_GAME_MAIN_CAMERA.bikeplayers[z] = null;
                }
            }*/
        }
    }

    [RPC]
    public void Bounce(float number, PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID))
        {
            if (MainGUI.bounceme)
            {
                PhysicMaterial material = new PhysicMaterial("bouncy")
                {
                    bounciness = number,//0.45f
                    bounceCombine = PhysicMaterialCombine.Maximum
                };
                IN_GAME_MAIN_CAMERA.main_object.collider.material = material;
            }
            if (number == 0)
            {
                InRoomChat.addLINE("<color=yellow>-Bouncy Mode Has Been Disabled-</color>");
            }
            else
                InRoomChat.addLINE("<color=yellow>-Bouncy Mode Has Been Enabled-</color>");
        }
    }

    [RPC]
    public void Flashy(int number, PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID))
        {
            GameObject[] main_objects = GameObject.FindGameObjectsWithTag("Player");
            GameObject main_object = null;
            for (int z = 0; z < main_objects.Length; z++)
            {
                if (main_objects[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID == number)
                {
                    main_object = main_objects[z];
                    break;
                }
            }
            GameObject lightobject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            lightobject.renderer.material.shader = Shader.Find("Transparent/VertexLit");
            lightobject.renderer.material.mainTexture = FengGameManagerMKII.candytextures[9];
            lightobject.collider.enabled = false;
            lightobject.renderer.material.color = Color.red;
            lightobject.transform.localScale = new Vector3(2.8f, 0f, 2.8f);
            IN_GAME_MAIN_CAMERA.lighttest = lightobject.AddComponent<Light>();
            IN_GAME_MAIN_CAMERA.lighttest.transform.parent = lightobject.transform;
            IN_GAME_MAIN_CAMERA.lighttest.transform.position = lightobject.transform.position;
            lightobject.AddComponent<Flashy_Follower>();
            lightobject.GetComponent<Flashy_Follower>().GetObject(main_object);
            //lightobject.transform.parent = IN_GAME_MAIN_CAMERA.main_object.transform;
            //lightobject.transform.position = IN_GAME_MAIN_CAMERA.main_object.transform.position + new Vector3(0f, .05f, 0f);
            IN_GAME_MAIN_CAMERA.lighttest.intensity = float.MaxValue;
            IN_GAME_MAIN_CAMERA.lighttest.range = 15f;
            IN_GAME_MAIN_CAMERA.lighttest.color = Color.red;

            newli = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<Light>();
            newli.renderer.material.shader = Shader.Find("VertexLit");
            newli.renderer.material.mainTexture = FengGameManagerMKII.candytextures[10];
            newli.renderer.material.color = Color.red;
            newli.collider.enabled = false;
            //newli.transform.parent = IN_GAME_MAIN_CAMERA.main_object.transform;
            newli.transform.localScale = new Vector3(1.5f, 0f, 1.5f);
            newli.gameObject.AddComponent<Flashy_Follower>();
            newli.gameObject.GetComponent<Flashy_Follower>().GetObject(main_object);
            flashies.Add(number, new GameObject[] { lightobject, newli.gameObject });
            //newli.transform.position = IN_GAME_MAIN_CAMERA.main_object.transform.position + new Vector3(0f, .05f, 0f);
            newli.intensity = float.MaxValue;
            newli.range = 5f;
            newli.color = Color.red;
        }
    }

    [RPC]
    public void DestroyFlashy(int id, PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID))
        {
            if (flashies.ContainsKey(id))
            {
                GameObject[] todestroy = flashies[id];
                GameObject.Destroy(todestroy[0]);
                GameObject.Destroy(todestroy[1]);
                flashies.Remove(id);
            }
        }
    }
    /*
    [RPC]
    public void Broadcast(string content, float Length, PhotonMessageInfo info)
    {
        if (!broadcasting)
        {
            base.StartCoroutine(this.broadcastmsg(Length));
            broadcasting = true;
            if (modUsers.Contains(info.sender.ID) || info.sender == PhotonNetwork.player)
            {
                GameObject obj2 = GameObject.Find("LabelInfoCenter");
                if (obj2 != null)
                {
                    obj2.GetComponent<UILabel>().text = content;
                }
            }
        }
    }*/
    /*
    public IEnumerator broadcastmsg(float Length)
    {
        yield return new WaitForSeconds(Length);
        broadcasting = false;
        ShowHUDInfoCenter(string.Empty);
    }*/

    public IEnumerator LoadSkin(WWW[] sw, int id)
    {
        InRoomChat.addLINE("<color=#FFF000>-Importing Skins From </color><color=black>(</color><color=red>" + Convert.ToString(id) + "</color><color=black>)</color><color=#FFF000>-</color>");
        for (int z = 0; z < sw.Length; z++)
        {
            if (z == 11 || z == 12 || z == 20)
                atexture[z] = new Texture2D(4, 4, TextureFormat.DXT1, true);
                yield return sw[z];
                //InRoomChat.addLINE("<color=#FFF000>Going Through: </color>" + Convert.ToString(z));
                atexture[z] = sw[z].texture;
        }
        //atexture = sw.texture;
        if (!animate.ContainsKey(id))
        {
            animate.Add(id, false);
        }
        else
        {
            animate.Remove(id);
            animate.Add(id, false);
        }
        LoadedSkin(id);
        sw = null;
    }

    public IEnumerator LoadAnimatedSkin(WWW[,] sw, int id)
    {
        InRoomChat.addLINE("<color=#FFF000>-Importing Animated Skins From </color><color=black>(</color><color=red>" + Convert.ToString(id) + "</color><color=black>)</color><color=#FFF000>-.</color>");
        for (int zed = 0; zed < 4; zed++)
        {
            for (int z = 0; z < 28; z++)
            {
                if (z == 11 || z == 12 || z == 20)
                    antexture[zed, z] = new Texture2D(4, 4, TextureFormat.DXT1, true);
                yield return sw[zed, z];
                //InRoomChat.addLINE("<color=#FFF000>Going Through: </color>" + Convert.ToString(z));
                antexture[zed, z] = sw[zed, z].texture;
            }
        }/*
        atexture[0] = new Texture2D(4, 4, TextureFormat.DXT1, true);
        atexture[0] = sw[0, 11].texture;
        atexture[1] = new Texture2D(4, 4, TextureFormat.DXT1, true);
        atexture[1] = sw[0, 12].texture;
        atexture[2] = new Texture2D(4, 4, TextureFormat.DXT1, true);
        atexture[2] = sw[0, 20].texture;*/
        //LoadEyes(id);
        //atexture = sw.texture;
        if (!this.playerskins.ContainsKey(id))
        {
            this.playerskins.Add(id, antexture);
        }
        else
        {
            this.playerskins.Remove(id);
            this.playerskins.Add(id, antexture);
        }
        if (!animate.ContainsKey(id))
        {
            animate.Add(id, true);
        }
        else
        {
            animate.Remove(id);
            animate.Add(id, true);
        }
        sw = null;
    }
    
    public void LoadEyes(int id, int number)
    {
        GameObject[] pls = GameObject.FindGameObjectsWithTag("Player");
        GameObject pla = null;
        for (int z = 0; z < pls.Length; z++)
        {
            if (pls[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID == id)
            {
                pla = pls[z];
                break;
            }
        }
        if (pla != null)
        {
            GameObject[] pra = { pla.GetComponent<HERO_SETUP>().part_eye, pla.GetComponent<HERO_SETUP>().part_face, pla.GetComponent<HERO_SETUP>().part_glass };
            for (int zed = 0; zed < pra.Length; zed++)
            {
                if (pra[zed] != null)
                {
                    if (antexture[number, zed] != null && antexture[number, zed].texelSize != errortexture.texelSize)
                    {
                        if (first[id] == true)
                        {
                            pra[zed].renderer.material.mainTextureScale = (Vector2)(pra[zed].renderer.material.mainTextureScale * 8f);
                            pra[zed].renderer.material.mainTextureOffset = new Vector2(0f, 0f);
                        }
                        if (zed == 0)
                        {
                            pra[zed].renderer.material.mainTexture = antexture[number, 11];
                        }
                        else if (zed == 1)
                        {
                            pra[zed].renderer.material.mainTexture = antexture[number, 12];
                        }
                        else if (zed == 2)
                        {
                            pra[zed].renderer.material.mainTexture = antexture[number, 20];
                        }
                    }
                }
            }
            if (first[id] == true)
            {
                first.Remove(id);
                first.Add(id, false);
            }
        }
    }

    public void LoadedSkin(int id)
    {
        GameObject[] pls = GameObject.FindGameObjectsWithTag("Player");
        GameObject pla = null;
        for (int z = 0; z < pls.Length; z++)
        {
            if (pls[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID == id)
            {
                pla = pls[z];
                break;
            }
        }
        if (pla != null)
        {
            GameObject[] pra = { pla.GetComponent<HERO_SETUP>().part_blade_r, pla.GetComponent<HERO_SETUP>().part_3dmg_gas_r, pla.GetComponent<HERO_SETUP>().part_blade_l, pla.GetComponent<HERO_SETUP>().part_3dmg_belt, pla.GetComponent<HERO_SETUP>().part_3dmg, pla.GetComponent<HERO_SETUP>().part_3dmg_gas_l, pla.GetComponent<HERO_SETUP>().part_cape, pla.GetComponent<HERO_SETUP>().part_brand_1, pla.GetComponent<HERO_SETUP>().part_brand_2, pla.GetComponent<HERO_SETUP>().part_brand_3, pla.GetComponent<HERO_SETUP>().part_brand_4, pla.GetComponent<HERO_SETUP>().part_eye, pla.GetComponent<HERO_SETUP>().part_face, pla.GetComponent<HERO_SETUP>().part_head, pla.GetComponent<HERO_SETUP>().part_hand_l, pla.GetComponent<HERO_SETUP>().part_hand_r, pla.GetComponent<HERO_SETUP>().part_chest, pla.GetComponent<HERO_SETUP>().part_chest_1, pla.GetComponent<HERO_SETUP>().part_chest_2, pla.GetComponent<HERO_SETUP>().part_chest_3, pla.GetComponent<HERO_SETUP>().part_glass, pla.GetComponent<HERO_SETUP>().part_hair, pla.GetComponent<HERO_SETUP>().part_hair_1, pla.GetComponent<HERO_SETUP>().part_hair_2, pla.GetComponent<HERO_SETUP>().part_upper_body, pla.GetComponent<HERO_SETUP>().part_leg, pla.GetComponent<HERO_SETUP>().part_arm_l, pla.GetComponent<HERO_SETUP>().part_arm_r };
            for (int zed = 0; zed < pra.Length; zed++)
            {
                if (pra[zed] != null)
                {
                    if (atexture[zed] != null && atexture[zed].texelSize != errortexture.texelSize)
                    {
                        if (zed == 11 || zed == 12 || zed == 20)
                        {
                            if (first[id] == true)
                            {
                                pra[zed].renderer.material.mainTextureScale = (Vector2)(pra[zed].renderer.material.mainTextureScale * 8f);
                                pra[zed].renderer.material.mainTextureOffset = new Vector2(0f, 0f);
                            }
                        }
                        pra[zed].renderer.material.mainTexture = atexture[zed];
                    }
                }
            }
        }
        if (first[id] == true)
        {
            first.Remove(id);
            first.Add(id, false);
        }
        for (int z = 0; z < atexture.Length; z++)
        {
            atexture[z] = new Texture();
        }
    }

    public void LoadedAnimatedSkin(int id, int number)
    {
        GameObject[] pls = GameObject.FindGameObjectsWithTag("Player");
        GameObject pla = null;
        for (int z = 0; z < pls.Length; z++)
        {
            if (pls[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID == id)
            {
                pla = pls[z];
                break;
            }
        }
        if (pla != null)
        {
            GameObject[] pra = { pla.GetComponent<HERO_SETUP>().part_blade_r, pla.GetComponent<HERO_SETUP>().part_3dmg_gas_r, pla.GetComponent<HERO_SETUP>().part_blade_l, pla.GetComponent<HERO_SETUP>().part_3dmg_belt, pla.GetComponent<HERO_SETUP>().part_3dmg, pla.GetComponent<HERO_SETUP>().part_3dmg_gas_l, pla.GetComponent<HERO_SETUP>().part_cape, pla.GetComponent<HERO_SETUP>().part_brand_1, pla.GetComponent<HERO_SETUP>().part_brand_2, pla.GetComponent<HERO_SETUP>().part_brand_3, pla.GetComponent<HERO_SETUP>().part_brand_4, pla.GetComponent<HERO_SETUP>().part_eye, pla.GetComponent<HERO_SETUP>().part_face, pla.GetComponent<HERO_SETUP>().part_head, pla.GetComponent<HERO_SETUP>().part_hand_l, pla.GetComponent<HERO_SETUP>().part_hand_r, pla.GetComponent<HERO_SETUP>().part_chest, pla.GetComponent<HERO_SETUP>().part_chest_1, pla.GetComponent<HERO_SETUP>().part_chest_2, pla.GetComponent<HERO_SETUP>().part_chest_3, pla.GetComponent<HERO_SETUP>().part_glass, pla.GetComponent<HERO_SETUP>().part_hair, pla.GetComponent<HERO_SETUP>().part_hair_1, pla.GetComponent<HERO_SETUP>().part_hair_2, pla.GetComponent<HERO_SETUP>().part_upper_body, pla.GetComponent<HERO_SETUP>().part_leg, pla.GetComponent<HERO_SETUP>().part_arm_l, pla.GetComponent<HERO_SETUP>().part_arm_r };
            for (int zed = 0; zed < pra.Length; zed++)
            {
                if (pra[zed] != null)
                {
                    if (antexture[number, zed] != null && antexture[number, zed].texelSize != errortexture.texelSize)
                    {
                        if (zed != 11 && zed != 12 && zed != 20)
                        {
                            pra[zed].renderer.material.mainTexture = antexture[number, zed];
                        }
                    }
                }
            }
        }
    }

    [RPC]
    public void SkinRPC(int id, string[] s)
    {
        string a = "," + s[7] + "," + s[3] + "," + s[6] + "," + s[5] + "," + s[4] + "," + s[8] + "," + s[2] + "," + s[1] + "," + s[0] + ",,";
        IN_GAME_MAIN_CAMERA.main_object.GetComponent<HERO>().photonView.RPC("loadskinRPC", PhotonTargets.All, new object[] { 0, a });
        /*
        WWW[] ns = new WWW[28];
        string lastusable = "";
        for (int z = 0; z < 28; z++)
        {
            ns[z] = null;
            //                                      0                                           1                                           2                                       3                                       4                                        5                                   6                                        7                                       8                                                 9                                       10                                                   11                                      12                                            13                                                14                                   15                                              16                                        17                                          18                                           19                                               20                                          21                                            22                                         23                                                24                                           25                                   26                                                  27
            //pla.GetComponent<HERO_SETUP>().part_blade_r, pla.GetComponent<HERO_SETUP>().part_3dmg_gas_r, pla.GetComponent<HERO_SETUP>().part_blade_l, pla.GetComponent<HERO_SETUP>().part_3dmg_belt, pla.GetComponent<HERO_SETUP>().part_3dmg, pla.GetComponent<HERO_SETUP>().part_3dmg_gas_l, pla.GetComponent<HERO_SETUP>().part_cape, pla.GetComponent<HERO_SETUP>().part_brand_1, pla.GetComponent<HERO_SETUP>().part_brand_2, pla.GetComponent<HERO_SETUP>().part_brand_3, pla.GetComponent<HERO_SETUP>().part_brand_4, pla.GetComponent<HERO_SETUP>().part_eye, pla.GetComponent<HERO_SETUP>().part_face, pla.GetComponent<HERO_SETUP>().part_head, pla.GetComponent<HERO_SETUP>().part_hand_l, pla.GetComponent<HERO_SETUP>().part_hand_r, pla.GetComponent<HERO_SETUP>().part_chest, pla.GetComponent<HERO_SETUP>().part_chest_1, pla.GetComponent<HERO_SETUP>().part_chest_2, pla.GetComponent<HERO_SETUP>().part_chest_3, pla.GetComponent<HERO_SETUP>().part_glass, pla.GetComponent<HERO_SETUP>().part_hair, pla.GetComponent<HERO_SETUP>().part_hair_1, pla.GetComponent<HERO_SETUP>().part_hair_2, pla.GetComponent<HERO_SETUP>().part_upper_body, pla.GetComponent<HERO_SETUP>().part_leg, pla.GetComponent<HERO_SETUP>().part_arm_l, pla.GetComponent<HERO_SETUP>().part_arm_r
            //blade_r, blade_l, cape, eye, skin, glass, hair, costume
            if (z < 2)
            {
                ns[z] = new WWW(s[0]);
                lastusable = s[0];
            }
            else if (z < 6)
            {
                ns[z] = new WWW(s[1]);
            }
            else if (z < 11)
            {
                ns[z] = new WWW(s[2]);
            }
            else if (z == 11)
            {
                ns[z] = new WWW(s[3]);
            }
            else if (z == 12)
            {
                ns[z] = new WWW(s[4]);
            }
            else if (z < 20)
            {
                ns[z] = new WWW(s[5]);
            }
            else if (z == 20)
            {
                ns[z] = new WWW(s[6]);
            }
            else if (z < 24)
            {
                ns[z] = new WWW(s[7]);
            }
            else
            {
                ns[z] = new WWW(s[8]);
            }
        }
        StartCoroutine(LoadSkin(ns, id));*/
    }

    [RPC]
    public void AnimateSkinRPC(int id, string[] alinkss, string[] alinksss, string[] alinkssss, string[] alinksssss)
    {
        string[,] s = new string[4, 9];
        for (int z = 0; z < 9; z++)
        {
            s[0, z] = alinkss[z];
        }
        for (int z = 0; z < 9; z++)
        {
            s[1, z] = alinksss[z];
        }
        for (int z = 0; z < 9; z++)
        {
            s[2, z] = alinkssss[z];
        }
        for (int z = 0; z < 9; z++)
        {
            s[3, z] = alinksssss[z];
        }
        WWW[,] ns = new WWW[4, 28];
        string lastusable = "";
        for (int zed = 0; zed < 4; zed++)
        {
            for (int z = 0; z < 28; z++)
            {
                ns[zed, z] = null;
                if (z < 2)
                {
                    ns[zed, z] = new WWW(s[zed, 0]);
                    lastusable = s[zed, 0];
                }
                else if (z < 6)
                {
                    ns[zed, z] = new WWW(s[zed, 1]);
                }
                else if (z < 11)
                {
                    ns[zed, z] = new WWW(s[zed, 2]);
                }
                else if (z == 11)
                {
                    ns[zed, z] = new WWW(s[zed, 3]);
                }
                else if (z == 12)
                {
                    ns[zed, z] = new WWW(s[zed, 4]);
                }
                else if (z < 20)
                {
                    ns[zed, z] = new WWW(s[zed, 5]);
                }
                else if (z == 20)
                {
                    ns[zed, z] = new WWW(s[zed, 6]);
                }
                else if (z < 24)
                {
                    ns[zed, z] = new WWW(s[zed, 7]);
                }
                else
                {
                    ns[zed, z] = new WWW(s[zed, 8]);
                }
            }
        }
        StartCoroutine(LoadAnimatedSkin(ns, id));
    }

    [RPC]
    public void flightToggle(bool flight2, PhotonMessageInfo info)
    {
        //FengGameManagerMKII.candyMasterClient is my mastercandy because idk the one that you use
        if (modUsers.Contains(info.sender.ID) && candyMasterClient == info.sender.ID)
        {
            flight = flight2;
            if (flight)
            {
                InRoomChat.addLINE("<color=yellow>-The MasterClient Has Allowed Flying-</color>");
            }
            if (!flight)
            {
                InRoomChat.addLINE("<color=yellow>-The MasterClient Won't Let You Fly-</color>");
            }
        }
    }

    [RPC]
    public void Seeker(int number)
    {
        hidetimer = Time.time;
        if (PhotonNetwork.player.ID == number)
        {
            amseeker = true;
            actualseeker = true;
        }
        playhns = true;
        //IN_GAME_MAIN_CAMERA.seekerid = number;
    }

    [RPC]
    public void Found(int id, int number)
    {/*
        InRoomChat.addLINE("<color=yellow>-Player with ID </color><color=black>(</color><color=red>" + Convert.ToString(id) + "</color><color=black>)</color><color=yellow> has been found-</color>");
        if (PhotonNetwork.player.ID == id)
        {
            IN_GAME_MAIN_CAMERA.seekerid = number;
            IN_GAME_MAIN_CAMERA.followseeker = true;
        }
        if (!caught.ContainsKey(id))
        {
            caught.Remove(id);
        }
        caught.Add(id, true);
        GameObject[] pls = GameObject.FindGameObjectsWithTag("Player");
        for (int z = 0; z < pls.Length; z++)
        {
            if (modUsers.Contains(pls[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID))
            {
                if (caught[pls[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID] == false)
                {
                    CandyModUsersOnly("Stophns", "All", new object[] { });
                    break;
                }
            }
        }*/
    }

    [RPC]
    public void Stophns()
    {
        playhns = false;
        amseeker = false;
        actualseeker = false;
        caught.Clear();
        if (isCandyMasterClient)
        {
            FengGameManagerMKII.MKII.restartGame(false);
        }
    }

    [RPC]
    public void Remove(string str, PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID) && info.sender.ID == FengGameManagerMKII.candyMasterClient && !MainGUI.local || PhotonNetwork.player == info.sender && MainGUI.local)
        {
            MainGUI.extraList = new List<string>();
            foreach (string str2 in InRoomChat.playlist)
            {
                if (str == str2 && !str.EndsWith("(Removed)"))
                {
                    MainGUI.extraList.Add(str + "(Removed)");
                }
                else if (str == str2 && str.EndsWith("(Removed)"))
                {
                    MainGUI.extraList.Add(str.Split(new char[0])[0] + " " + str.Split(new char[0])[1] + " ");
                }
                else if (str != str2)
                {
                    MainGUI.extraList.Add(str2);
                }
            }
            InRoomChat.playlist = MainGUI.extraList;
        }
    }

    [RPC]
    public void AddS(string str, PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID) && info.sender.ID == FengGameManagerMKII.candyMasterClient && !MainGUI.local || PhotonNetwork.player == info.sender && MainGUI.local)
        {
            int int1 = InRoomChat.playlist.Count + 1;
            InRoomChat.playlist.Add(int1 + " " + str + " ");
        }
    }

    [RPC]
    public void Clear(PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID) && info.sender.ID == FengGameManagerMKII.candyMasterClient && !MainGUI.local || PhotonNetwork.player == info.sender && MainGUI.local)
        {
            InRoomChat.playlist.Clear();
            InRoomChat.playlistplaying = 0;
        }
    }

    [RPC]
    public void ReqList(PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID) && PhotonNetwork.player.ID == FengGameManagerMKII.candyMasterClient)
        {
            basephotonView.RPC("Clear", info.sender, new object[] { });
            foreach (string str in InRoomChat.playlist)
            {
                basephotonView.RPC("AddS", info.sender, new object[] { str });
            }
        }
    }

    [RPC]
    public void SongInt(int int1, PhotonMessageInfo info)
    {
        if (cmusers.ContainsKey(info.sender.ID) && info.sender.ID == FengGameManagerMKII.candyMasterClient)
        {
            InRoomChat.playlistplaying = int1;
        }
    }

    [RPC]
    public void ChangeTimeMode(int number)
    {
        if (number == 0)
        {
            RenderSettings.ambientLight = FengColor.dayAmbientLight;
            IN_GAME_MAIN_CAMERA.dayLight = DayLight.Day;
            GameObject.Find("mainLight").GetComponent<Light>().color = FengColor.dayLight;
        }
        else if (number == 1)
        {
            RenderSettings.ambientLight = FengColor.dawnAmbientLight;
            IN_GAME_MAIN_CAMERA.dayLight = DayLight.Dawn;
            GameObject.Find("mainLight").GetComponent<Light>().color = FengColor.dawnLight;
        }
        else
        {
            IN_GAME_MAIN_CAMERA.dayLight = DayLight.Night;
            RenderSettings.ambientLight = FengColor.nightAmbientLight;
            GameObject.Find("mainLight").GetComponent<Light>().color = FengColor.nightLight;
        }
    }

    [RPC]
    public void SpawnPlayerAtRPC(PhotonMessageInfo a)
    {/*
        if (cmusers.Count == 1)
        {
            candyMasterClient = PhotonNetwork.player.ID;
            isCandyMasterClient = true;
        }*/
        cmusers.Add(a.sender.ID, null);/*
        if (a.sender.ID != PhotonNetwork.player.ID)
        {
            if (isCandyMasterClient)
            {
                CandyModUsersOnly("ListOfUsers", "Others", new object[] { cmusers.Keys, cmusers.Values });
            }
        }*/
    }

    [RPC]
    public void ListOfUsers(int[] a, GameObject[] b, PhotonMessageInfo c)
    {
        cmusers = new Dictionary<int, GameObject>();
        for (int z = 0; z < a.Length; z++)
        {
            cmusers.Add(a[z], b[z]);
        }
    }

    [RPC]
    public void StartHide(int seeker, PhotonMessageInfo a)
    {
        //FengGameManagerMKII.GuiText = GuiText + "1";
        HideAndSeek.startgame = true;
        HideAndSeek.seekerid = seeker;
        HideAndSeek.begincount = Time.time;
        HideAndSeek.step = 0;
    }
}


