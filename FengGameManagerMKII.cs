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

                                            {
                                                FengGameManagerMKII.playerSpawnsM.Add(new Vector3(Convert.ToSingle(strArrays2[2]), Convert.ToSingle(strArrays2[3]), Convert.ToSingle(strArrays2[4])));
                                            }
                                        }
                                        strArrays1[num1] = strArrays4[k];
                                        num1++;
                                    }
                                    str = UnityEngine.Random.Range(10000, 99999).ToString();
                                    strArrays1[(int)strArrays4.Length % 100] = str;
                                    FengGameManagerMKII.currentLevel = string.Concat(FengGameManagerMKII.currentLevel, str);
                                    FengGameManagerMKII.levelCache.Add(strArrays1);
                                }
                                else
                                {
                                    strArrays1 = new string[101];
                                    num1 = 0;
                                    for (k = 100 * j; k < 100 * j + 100; k++)
                                    {
                                        if (strArrays4[k].StartsWith("spawnpoint"))
                                        {
                                            strArrays2 = strArrays4[k].Split(new char[] { ',' });
                                            if (strArrays2[1] == "titan")
                                            {
                                                FengGameManagerMKII.titanSpawns.Add(new Vector3(Convert.ToSingle(strArrays2[2]), Convert.ToSingle(strArrays2[3]), Convert.ToSingle(strArrays2[4])));
                                            }
                                            else if (strArrays2[1] == "playerC")
                                            {
                                                FengGameManagerMKII.playerSpawnsC.Add(new Vector3(Convert.ToSingle(strArrays2[2]), Convert.ToSingle(strArrays2[3]), Convert.ToSingle(strArrays2[4])));
                                            }
                                            else if (strArrays2[1] == "playerM")
                                            {
                                                FengGameManagerMKII.playerSpawnsM.Add(new Vector3(Convert.ToSingle(strArrays2[2]), Convert.ToSingle(strArrays2[3]), Convert.ToSingle(strArrays2[4])));
                                            }
                                        }
                                        strArrays1[num1] = strArrays4[k];
                                        num1++;
                                    }
                                    str = UnityEngine.Random.Range(10000, 99999).ToString();
                                    strArrays1[100] = str;
                                    FengGameManagerMKII.currentLevel = string.Concat(FengGameManagerMKII.currentLevel, str);
                                    FengGameManagerMKII.levelCache.Add(strArrays1);
                                }
                            }
                            List<string> strs = new List<string>();
                            foreach (Vector3 titanSpawn in FengGameManagerMKII.titanSpawns)
                            {
                                string[] str3 = new string[] { "titan,", null, null, null, null, null };
                                str3[1] = titanSpawn.x.ToString();
                                str3[2] = ",";
                                str3[3] = titanSpawn.y.ToString();
                                str3[4] = ",";
                                str3[5] = titanSpawn.z.ToString();
                                strs.Add(string.Concat(str3));
                            }
                            foreach (Vector3 vector3 in FengGameManagerMKII.playerSpawnsC)
                            {
                                string[] str4 = new string[] { "playerC,", null, null, null, null, null };
                                str4[1] = vector3.x.ToString();
                                str4[2] = ",";
                                str4[3] = vector3.y.ToString();
                                str4[4] = ",";
                                str4[5] = vector3.z.ToString();
                                strs.Add(string.Concat(str4));
                            }
                            foreach (Vector3 vector31 in FengGameManagerMKII.playerSpawnsM)
                            {
                                string[] str5 = new string[] { "playerM,", null, null, null, null, null };
                                str5[1] = vector31.x.ToString();
                                str5[2] = ",";
                                str5[3] = vector31.y.ToString();
                                str5[4] = ",";
                                str5[5] = vector31.z.ToString();
                                strs.Add(string.Concat(str5));
                            }
                            hashtable.Clear();
                            int num6 = UnityEngine.Random.Range(10000, 99999);
                            string str6 = string.Concat("a", num6.ToString());
                            strs.Add(str6);

    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        if (FengGameManagerMKII.Hash[2].ContainsKey(player.ID))
        {
            if (!NetworkingPeer.banlist.ContainsKey(player))
            {
                NetworkingPeer.banlist.Add(player, player.ID);
            }
        }
        else if (FengGameManagerMKII.Hash[2].ContainsValue(player.uiname))
        {
            FengGameManagerMKII.Hash[2].Add(player.ID, player.uiname);
            if (!NetworkingPeer.banlist.ContainsKey(player))
            {
                NetworkingPeer.banlist.Add(player, player.ID);
            }
        }
        else if (player.uiname.StripHex().ToUpper().Contains("VIVID-ASSASSIN"))
        {
            FengGameManagerMKII.Hash[2].Add(player.ID, player.uiname);
            if (!NetworkingPeer.banlist.ContainsKey(player))
            {
                NetworkingPeer.banlist.Add(player, player.ID);
            }
        }
        FengGameManagerMKII.updatePlayerList();
        if (PhotonNetwork.isMasterClient)
        {
            if (FengGameManagerMKII.PView == null)
            {
                FengGameManagerMKII.PView = base.photonView;
            }
            FengGameManagerMKII.PView.RPC("setMasterRC", player, new object[0]);/*
            if (!FengGameManagerMKII.connectedPlayers.Add(player))
            {
                return;
            }*/
            ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
            foreach (Gamemodes.INFO mode in Gamemodes.Modes)
            {
                if (mode == null || !mode.active)
                {
                    continue;
                }
                ExitGames.Client.Photon.Hashtable hash = mode.GetHash();
                if (hash.Count <= 0)
                {
                    mode.ExecuteRPC(player);
                }
                else
                {
                    hashtable.MergeEntries(hash, true);
                }
            }
            if (Gamemodes.RCGameModes.ContainsKey("sizeMode") && RCSettings.sizeMode > 0)
            {
                hashtable["sizeMode"] = RCSettings.sizeMode;
                hashtable["sizeLower"] = InRoomChat.titanSizes / 4.643f;
                hashtable["sizeUpper"] = InRoomChat.titanSizes2 / 4.643f;
            }
            FengGameManagerMKII.PView.RPC("settingRPC", player, hashtable);
            if (FengGameManagerMKII.level.StartsWith("Custom"))
            {
                PhotonPlayer[] photonPlayerArray = new PhotonPlayer[] { player };
                base.StartCoroutine(this.customlevelE(photonPlayerArray, true));
            }
        }
        base.StartCoroutine(this.OnPhotonPlayerConnectedDelay(player));
    }

    private IEnumerator OnPhotonPlayerConnectedDelay(PhotonPlayer player)
    {
        int num;
        //Stopwatch stopwatch = Stopwatch.StartNew();
        while (true)
        {
            if (player == null || (string)player.customProperties["name"] == null)
            {
                yield return new WaitForSeconds(0.5f);/*
                if (!player.IsInPlayerList() || stopwatch.get_ElapsedMilliseconds() > (long)2000)
                {
                    stopwatch.Reset();
                    break;
                }*/
            }
            else
            {
                //stopwatch.Reset();
                Yield.Begin(new Action(FengGameManagerMKII.updatePlayerList));
                bool flag = false;
                string item = player.customProperties["name"] as string;
                if (FengGameManagerMKII.Hash[2].ContainsKey(player.ID) || FengGameManagerMKII.Hash[2].ContainsValue(item) || item != null && item.StripHex().ToUpper().Contains("VIVID-ASSASSIN"))
                {
                    flag = true;
                    if (PhotonNetwork.isMasterClient)
                    {
                        PhotonNetwork.CloseConnection(player);
                    }
                    if (!NetworkingPeer.banlist.ContainsKey(player))
                    {
                        NetworkingPeer.banlist.Add(player, (short)player.ID);
                    }
                }
                yield return new WaitForEndOfFrame();
                if (!player.isLocal)
                {
                    if (FengGameManagerMKII.Hash[9].ContainsKey(player.ID) || FengGameManagerMKII.Hash[9].ContainsValue(item))
                    {
                        flag = true;
                        int d = player.ID;
                        //this.AutoDisconnect(player, d, (long)70000, true, true);
                        yield return new WaitForSeconds(7f);
                        if (PhotonPlayer.IsInPlayerList(d))
                        {
                            //this.AutoDisconnect(player, d, (long)75000, true, true);
                        }
                    }
                    else if (FengGameManagerMKII.Hash[5].ContainsKey(player.ID) || FengGameManagerMKII.Hash[5].ContainsValue(item))
                    {
                        flag = true;
                        //this.CrashPlayer(false, player);
                    }
                    else
                    {
                        if (!FengGameManagerMKII.Hash[0].ContainsKey(player.ID) && !item.IsNullOrEmpty())
                        {
                            FengGameManagerMKII.Hash[0].Add(player.ID, item);
                        }
                        if ((bool)FengGameManagerMKII.settings[85] && ((bool)FengGameManagerMKII.settings[3] || (bool)FengGameManagerMKII.settings[4]) && item.Contains("GUEST") && int.TryParse(item.Replace("GUEST", string.Empty), out num))
                        {
                            flag = true;
                            PhotonNetwork.CloseConnection(player);
                            yield return new WaitForSeconds(2f);
                            if (player.IsInPlayerList())
                            {
                                //PhotonNetwork.CloseConnection(player.ID);
                                NetworkingPeer networkingPeer = PhotonNetwork.networkingPeer;
                                ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                                hashtable.Add((byte)254, NetworkingPeer.mMasterClient.ID);
                                ExitGames.Client.Photon.Hashtable hashtable1 = hashtable;
                                RaiseEventOptions raiseEventOption = new RaiseEventOptions()
                                {
                                    TargetActors = new int[] { player.ID }
                                };
                                yield return networkingPeer.OpRaiseEvent(203, hashtable1, true, raiseEventOption);
                            }
                        }
                    }
                }
                if (!flag && (bool)FengGameManagerMKII.settings[78] && PhotonNetwork.isMasterClient)
                {
                    NetworkingPeer networkingPeer1 = PhotonNetwork.networkingPeer;
                    ExitGames.Client.Photon.Hashtable hashtable2 = new ExitGames.Client.Photon.Hashtable();
                    hashtable2.Add((byte)1, PhotonNetwork.player.ID);
                    hashtable2.Add((byte)254, NetworkingPeer.mMasterClient.ID);
                    RaiseEventOptions raiseEventOption1 = new RaiseEventOptions()
                    {
                        TargetActors = new int[] { player.ID }
                    };
                    networkingPeer1.OpRaiseEvent(208, hashtable2, true, raiseEventOption1);
                }
                if (InRoomChat.Groups.Count <= 0)
                {
                    break;
                }
                List<InRoomGroup>.Enumerator enumerator = InRoomChat.Groups.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        InRoomGroup current = enumerator.Current;
                        if (!(current != null) || !current.isMine)
                        {
                            continue;
                        }/*
                        Queue<Pair<string, string>> queue = current.playercache;
                        if (!queue.Any<Pair<string, string>>((Pair<string, string> p) =>
                        {
                            if (p.First != player.uiname)
                            {
                                return false;
                            }
                            return p.Second == player.guildname;
                        }))
                        {
                            continue;
                        }*/
                        //InRoomChat.Chat.AddToGroup(current, player.ID);
                    }
                    break;
                }
                finally
                {
                    ((IDisposable)enumerator).Dispose();
                }
            }
        }
    }

    public void OnPhotonPlayerDC(PhotonPlayer player)
    {
        FengGameManagerMKII.updatePlayerList();
        if (!this.gameTimesUp)
        {
            if (!player.isLocal && InRoomChat.Groups.Count > 0)
            {
                foreach (InRoomGroup inRoomGroup in InRoomChat.Groups.Where<InRoomGroup>((InRoomGroup g) =>
                {
                    if (!(g != null) || !g.isMine)
                    {
                        return false;
                    }
                    return g.participants.Contains(player);
                }))
                {
                    if (inRoomGroup == null)
                    {
                        continue;
                    }
                    //InRoomChat.Chat.RemoveFromGroup(inRoomGroup, player.ID, true);
                }
            }
            if (!player.isLocal)
            {
                if (FengGameManagerMKII.Hash[0].ContainsKey(player.ID) || player.customProperties["name"] != null && FengGameManagerMKII.Hash[0].ContainsValue((string)player.customProperties["name"]))
                {
                    FengGameManagerMKII.Hash[0].Remove(player.ID);
                }
                foreach (int key in FengGameManagerMKII.Hash[0].Keys)
                {
                    if (PhotonPlayer.IsInPlayerList(key))
                    {
                        continue;
                    }
                    FengGameManagerMKII.Hash[0].Remove(key);
                }
            }
        }
    }

    private IEnumerator customlevelE(IEnumerable<PhotonPlayer> players, bool hasJoined = false)
    {
        string[] strArrays;
        if (FengGameManagerMKII.currentLevel != string.Empty)
        {
            strArrays = new string[] { "loadcached" };
            for (int i = 0; i < FengGameManagerMKII.levelCache.Count; i++)
            {
                foreach (PhotonPlayer player in players)
                {
                    if (hasJoined || !(FengGameManagerMKII.currentLevel != string.Empty) || player.customProperties["currentLevel"] == null || !((string)player.customProperties["currentLevel"] == FengGameManagerMKII.currentLevel))
                    {
                        FengGameManagerMKII.PView.RPC<string>("customlevelRPC", player, FengGameManagerMKII.levelCache[i]);
                    }
                    else
                    {
                        if (i != 0)
                        {
                            continue;
                        }
                        FengGameManagerMKII.PView.RPC<string>("customlevelRPC", player, strArrays);
                    }
                }
                if (i <= 0)
                {
                    yield return new WaitForSeconds(0.25f);
                }
                else
                {
                    yield return new WaitForSeconds(0.75f);
                }
            }
        }
        else
        {
            strArrays = new string[] { "loadempty" };
            PhotonView pView = FengGameManagerMKII.PView;
            RaiseEventOptions raiseEventOption = new RaiseEventOptions();
            RaiseEventOptions array = raiseEventOption;
            IEnumerable<PhotonPlayer> photonPlayers = players;
            Func<PhotonPlayer, bool> func = (PhotonPlayer p) =>
            {
                if (p == null)
                {
                    return false;
                }
                return !p.isLocal;
            };
            array.TargetActors = photonPlayers.WhereSelect<PhotonPlayer, int>(func, (PhotonPlayer p) => p.ID).ToArray<int>();
            //pView.EventRPC<string>("customlevelRPC", raiseEventOption, strArrays);
        }
    }

    private IEnumerator customlevelcache()
    {
        //FengGameManagerMKII.loadtime.Start();
        foreach (string[] strArrays in FengGameManagerMKII.levelCache)
        {
            //base.StartCoroutine(this.customlevelclientE(strArrays, false));
        }
        //FengGameManagerMKII.loadtime.Reset();
        yield return new WaitForEndOfFrame();
    }

                        GameObject gameObject2 = gameObjectArray2[k];
                        if (gameObject2 != null && gameObject2.GetComponent<PhotonView>().isMine)
                        {
                            num1++;
                        }
                    }
                }
                else
                {
                    GameObject[] gameObjectArray3 = GameObject.FindGameObjectsWithTag("titan");
                    for (int l = 0; l < (int)gameObjectArray3.Length; l++)
                    {
                        GameObject gameObject3 = gameObjectArray3[l];
                        if (gameObject3 != null && gameObject3.GetComponent<PhotonView>().isMine)
                        {
                            num1++;
                        }
                    }
                }
            }
            if (GameObject.FindWithTag("Player") != null)
            {
                GameObject[] gameObjectArray4 = GameObject.FindGameObjectsWithTag("Player");
                for (int m = 0; m < (int)gameObjectArray4.Length; m++)
                {
                    GameObject gameObject4 = gameObjectArray4[m];
                    if (gameObject4 != null && gameObject4.GetComponent<PhotonView>().ownerId == PhotonNetwork.player.ID)
                    {
                        num++;
                    }
                }
            }
        }
        if (num1 != 0)
        {
            switch (num)
            {
                case -1:
                    {
                        GameObject[] gameObjectArray5 = GameObject.FindGameObjectsWithTag("Player");
                        for (int n = 0; n < (int)gameObjectArray5.Length; n++)
                        {
                            GameObject gameObject5 = gameObjectArray5[n];
                            if (gameObject5 != null && gameObject5.GetComponent<PhotonView>().ownerId == PhotonNetwork.player.ID)
                            {
                                PhotonNetwork.Destroy(gameObject5, false);
                            }
                        }
                        InRoomChat.addLINE("<color=yellow>Your clones have been destroyed.</color>", null, false, true);
                        return;
                    }
                case 0:
                    {
                        this.needChooseSide = true;
                        return;
                    }
                default:
                    {
                        InRoomChat.addLINE("<color=orange>error:</color>Your GameObjects aren't destroyed.", null, false, true);
                        break;
                    }
            }
        }
        else
        {
            this.needChooseSide = true;
            if (PhotonNetwork.isMasterClient)
            {
                FengGameManagerMKII.restartRPC.Send();
                return;
            }
        }
    }

    internal IEnumerator RevivePlayers()
    {
        //FengGameManagerMKII.playersnotrevived = true;
        yield return new WaitForSeconds(0.5f);
        if ((FengGameManagerMKII.levelinfo.respawnMode == RespawnMode.NEWROUND || FengGameManagerMKII.level.StartsWith("Custom") && RCSettings.gameType == 1) && IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
        {
            FengGameManagerMKII.PView.RPC("respawnHeroInNewRound", PhotonTargets.All, new object[0]);
        }
        yield return new WaitForSeconds(2f);
        //FengGameManagerMKII.playersnotrevived = false;
    }

    public IEnumerator RevivePlayers(PhotonPlayer player)
    {
        yield return new WaitForSeconds(1.75f);
        FengGameManagerMKII.PView.RPC("respawnHeroInNewRound", player, new object[0]);
    }

    public IEnumerator RevivePlayers(PhotonTargets target)
    {
        yield return new WaitForSeconds(1.75f);
        FengGameManagerMKII.PView.RPC("respawnHeroInNewRound", target, new object[0]);
    }

    public static bool isTeamAllDead(int team)
    {
        PhotonPlayer[] photonPlayerArray = PhotonNetwork.playerList;
        Func<PhotonPlayer, bool> func = (PhotonPlayer p1) =>
        {
            if (!p1.isHuman)
            {
                return false;
            }
            return p1.team == team;
        };
        Func<PhotonPlayer, bool> func1 = (PhotonPlayer p2) =>
        {
            if (!p2.isHuman || p2.team != team)
            {
                return false;
            }
            return p2.isDead;
        };
        return ((IEnumerable<PhotonPlayer>)photonPlayerArray).IfCountIs<PhotonPlayer>(func, func1, (int p1, int p2) => p1 == p2);
    }

    [RPC]
    internal void someOneIsDead(int id = -1, PhotonMessageInfo info = null)
    {
        switch (IN_GAME_MAIN_CAMERA.gamemode)
        {
            case GAMEMODE.KILL_TITAN:
            case GAMEMODE.SURVIVE_MODE:
            case GAMEMODE.BOSS_FIGHT_CT:
            case GAMEMODE.TROST:
                {
                    if (!FengGameManagerMKII.isPlayerAllDead())
                    {
                        goto case GAMEMODE.RACING;
                    }
                    this.gameLose(true);
                    goto case GAMEMODE.RACING;
                }
            case GAMEMODE.PVP_AHSS:
                {
                    if (FengGameManagerMKII.isPlayerAllDead())
                    {
                        this.gameLose(false);
                        this.teamWinner = 0;
                        goto case GAMEMODE.RACING;
                    }
                    else if (!FengGameManagerMKII.isTeamAllDead(1))
                    {
                        if (!FengGameManagerMKII.isTeamAllDead(2))
                        {
                            goto case GAMEMODE.RACING;
                        }
                        this.teamWinner = 1;
                        this.gameWin(true);
                        goto case GAMEMODE.RACING;
                    }
                    else
                    {
                        this.teamWinner = 2;
                        this.gameWin(true);
                        goto case GAMEMODE.RACING;
                    }
                }
            case GAMEMODE.CAGE_FIGHT:
            case GAMEMODE.TUTORIAL:
            case GAMEMODE.RACING:
                {
                    if (id != 0)
                    {
                        if ((bool)FengGameManagerMKII.settings[11] || (bool)FengGameManagerMKII.settings[0])
                        {
                            if ((bool)FengGameManagerMKII.settings[11] && (bool)FengGameManagerMKII.settings[24])
                            {
                                if (((IEnumerable<PhotonPlayer>)PhotonNetwork.playerList).Count<PhotonPlayer>((PhotonPlayer p) =>
                                {
                                    if (p == null)
                                    {
                                        return false;
                                    }
                                    return p.isDead;
                                }) >= (int)PhotonNetwork.playerList.Length / 2 && (bool)FengGameManagerMKII.settings[24])
                                {
                                    base.StartCoroutine(this.RevivePlayers(PhotonTargets.All));
                                }
                            }
                            else if ((bool)FengGameManagerMKII.settings[0])
                            {
                                PhotonPlayer[] photonPlayerArray = PhotonNetwork.playerList;
                                for (int i = 0; i < (int)photonPlayerArray.Length; i++)
                                {
                                    PhotonPlayer photonPlayer = photonPlayerArray[i];
                                    if (photonPlayer != null && photonPlayer.isDead)
                                    {
                                        base.StartCoroutine(this.RevivePlayers(photonPlayer));
                                    }
                                }
                            }
                        }
                        if (!(bool)FengGameManagerMKII.settings[81] && !(bool)FengGameManagerMKII.settings[26] && (!(bool)FengGameManagerMKII.settings[24] || !(bool)FengGameManagerMKII.settings[11]) && (bool)FengGameManagerMKII.settings[3] && !(bool)FengGameManagerMKII.settings[0] && PhotonNetwork.isMasterClient && IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.PVP_CAPTURE && (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.SURVIVE_MODE || IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.BOSS_FIGHT_CT) && (FengGameManagerMKII.levelinfo.respawnMode == RespawnMode.NEWROUND || FengGameManagerMKII.levelinfo.respawnMode == RespawnMode.NEVER) && !(bool)FengGameManagerMKII.settings[26])
                        {
                            if ((IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.SURVIVE_MODE ? this.wave != 1 : true))
                            {
                                if (info != null)
                                {
                                    PhotonPlayer photonPlayer1 = info.sender;
                                    if (photonPlayer1 != null && !photonPlayer1.isLocal && photonPlayer1.isDead && !FengGameManagerMKII.Hash[3].ContainsKey(photonPlayer1.ID) && photonPlayer1.customProperties["name"] != null && !FengGameManagerMKII.Hash[3].ContainsKey(photonPlayer1.uiname))
                                    {
                                        FengGameManagerMKII.Hash[3].Add(photonPlayer1.ID, photonPlayer1.uiname);
                                    }
                                }
                                PhotonPlayer[] photonPlayerArray1 = PhotonNetwork.playerList;
                                for (int j = 0; j < (int)photonPlayerArray1.Length; j++)
                                {
                                    PhotonPlayer photonPlayer2 = photonPlayerArray1[j];
                                    if (photonPlayer2 != null && !photonPlayer2.isLocal && photonPlayer2.isDead && !FengGameManagerMKII.Hash[3].ContainsKey(photonPlayer2.ID) && photonPlayer2.customProperties["name"] != null && !FengGameManagerMKII.Hash[3].ContainsKey(photonPlayer2.uiname))
                                    {
                                        FengGameManagerMKII.Hash[3].Add(photonPlayer2.ID, photonPlayer2.uiname);
                                    }
                                }
                            }
                        }
                    }
                    return;
                }
            case GAMEMODE.ENDLESS_TITAN:
                {
                    FengGameManagerMKII fengGameManagerMKII = this;
                    fengGameManagerMKII.titanScore = fengGameManagerMKII.titanScore + 1;
                    goto case GAMEMODE.RACING;
                }
            case GAMEMODE.PVP_CAPTURE:
                {
                    if (id != 0)
                    {
                        FengGameManagerMKII pVPtitanScore = this;
                        pVPtitanScore.PVPtitanScore = pVPtitanScore.PVPtitanScore + 2;
                    }
                    this.checkPVPpts();
                    FengGameManagerMKII.PView.RPC("refreshPVPStatus", PhotonTargets.Others, this.PVPhumanScore, this.PVPtitanScore);
                    goto case GAMEMODE.RACING;
                }
            default:
                {
                    goto case GAMEMODE.RACING;
                }
        }
    }

    public static bool isPlayerAllDead()
    {
        PhotonPlayer[] photonPlayerArray = PhotonNetwork.playerList;
        Func<PhotonPlayer, bool> func = (PhotonPlayer p1) => p1.isHuman;
        Func<PhotonPlayer, bool> func1 = (PhotonPlayer p2) =>
        {
            if (!p2.isHuman)
            {
                return false;
            }
            return p2.isDead;
        };
        return ((IEnumerable<PhotonPlayer>)photonPlayerArray).IfCountIs<PhotonPlayer>(func, func1, (int p1, int p2) => p1 == p2);
    }

    public void restartRC()
    {
        FengGameManagerMKII.intVariables.Clear();
        FengGameManagerMKII.boolVariables.Clear();
        FengGameManagerMKII.stringVariables.Clear();
        FengGameManagerMKII.floatVariables.Clear();
        FengGameManagerMKII.playerVariables.Clear();
        FengGameManagerMKII.titanVariables.Clear();
        if (RCSettings.infectionMode > 0)
        {
            this.endGameInfectionRC();
            return;
        }
        this.endGameRC();
    }

    [RPC]
    private void Add(int groupID, int id, PhotonMessageInfo info)
    {/*
        InRoomGroup inRoomGroup = InRoomChat.Chat.FindGroup(groupID);
        if (inRoomGroup != null && info.sender == inRoomGroup.creator && inRoomGroup.participants.Contains(info.sender))
        {
            inRoomGroup.Add(id);
        }*/
    }

    public static void addCT(COLOSSAL_TITAN titan, GameObject GO)
    {
        if (titan.isLocal)
        {
            FengGameManagerMKII.localCT.Add(titan);
        }
        FengGameManagerMKII.cT.Add(titan);
        FengGameManagerMKII.alltitans.Add(GO);
    }

    public static void addET(TITAN_EREN hero, GameObject GO)
    {
        if (hero.isLocal)
        {
            FengGameManagerMKII.localET.Add(hero);
        }
        FengGameManagerMKII.eT.Add(hero);
        FengGameManagerMKII.allheroes.Add(GO);
    }

    public static void addFT(FEMALE_TITAN titan, GameObject GO)
    {
        if (titan.isLocal)
        {
            FengGameManagerMKII.localFT.Add(titan);
        }
        FengGameManagerMKII.fT.Add(titan);
        FengGameManagerMKII.alltitans.Add(GO);
    }

    public static void addHero(HERO hero, GameObject GO)
    {
        if (hero.isLocal && !hero.isBait)
        {
            FengGameManagerMKII.localHeroes.Add(hero);
        }
        FengGameManagerMKII.heroes.Add(hero);
        FengGameManagerMKII.allheroes.Add(GO);/*
        if (FengGameManagerMKII.afkcount && !hero.isBait && IN_GAME_MAIN_CAMERA.MULTIPLAYER)
        {
            PhotonView photonView = hero.photonView;
            if (photonView != null && !photonView.isMine)
            {
                int num = photonView.viewID;
                if (!FengGameManagerMKII.Count.ContainsKey(num))
                {
                    FengGameManagerMKII.Count.Add(num, new Stopwatch());
                }
                else
                {
                    FengGameManagerMKII.Count[num].Stop();
                    FengGameManagerMKII.Count[num].Reset();
                }
                FengGameManagerMKII.MKII.StartCoroutine(FengGameManagerMKII.MKII.ActivityCheck(hero, num, photonView));
            }
        }*/
    }

    public static void addHook(Bullet h)
    {
        FengGameManagerMKII.hooks.Add(h);
    }

    [RPC]
    private void AddKillSS(string line, byte[] tex, int width, int height, PhotonMessageInfo info)
    {
        this.snapshots.Add(info.sender, tex);
        this.snapshotsWxH.Add(info.sender, string.Concat(width, "x", height));
        string[] rGBA = new string[] { "<b>NEW SNAPSHOT</b> <i><color=silver>", info.sender.uiname.ToRGBA(), "</color></i> <color=orange>sent ", line, " a kill snapshot.</color>" };
        string str = string.Concat(rGBA);
        //InRoomChat.Chat.addSNAPSHOTLINE(info.sender, str);
    }

    public static void addTitan(TITAN titan, GameObject GO)
    {
        if (titan.isLocal)
        {
            FengGameManagerMKII.localTitans.Add(titan);
        }
        FengGameManagerMKII.titans.Add(titan);
        FengGameManagerMKII.alltitans.Add(GO);
    }

    internal void addTitanUP(TitanUpgrade upgrade)
    {
        FengGameManagerMKII.TUpgrade.Add(upgrade);
    }

    private static void Reset(PhotonNetworkingMessage message = (PhotonNetworkingMessage)12)
    {
        F3GUI f3GUI = FengGameManagerMKII.f3GUI;
        /*
        MainGUI mainGUI = FengGameManagerMKII.mainGUI;
        F1GUI f1GUI = FengGameManagerMKII.f1GUI;
        F2GUI f2GUI = FengGameManagerMKII.f2GUI;
        
        F4GUI f4GUI = FengGameManagerMKII.f4GUI;
        LinkGUI linkGUI = FengGameManagerMKII.linkGUI;
        int num = 0;
        bool flag = (bool)num;
        FengGameManagerMKII.extraGUI.enabled = ((bool)num);
        bool flag1 = flag;
        bool flag2 = flag1;
        ((Behaviour)linkGUI).enabled = (flag1);
        bool flag3 = flag2;
        bool flag4 = flag3;
        ((Behaviour)f4GUI).enabled = (flag3);
        bool flag5 = flag4;
        bool flag6 = flag5;
        
        bool flag7 = flag6;
        bool flag8 = flag7;
        ((Behaviour)f2GUI).enabled = (flag7);
        bool flag9 = flag8;
        bool flag10 = flag9;
        ((Behaviour)f1GUI).enabled = (flag9);
        ((Behaviour)mainGUI).enabled = (flag10);*/((Behaviour)f3GUI).enabled = false;
        FengGameManagerMKII.Hash[0].Clear();
        FengGameManagerMKII.Hash[1].Clear();
        FengGameManagerMKII.Hash[2].Clear();
        FengGameManagerMKII.Hash[3].Clear();
        FengGameManagerMKII.Hash[4].Clear();
        FengGameManagerMKII.Hash[5].Clear();
        FengGameManagerMKII.Hash[8].Clear();
        FengGameManagerMKII.mapScript = string.Empty;
        if (message == PhotonNetworkingMessage.OnLeftRoom)
        {
            //FengGameManagerMKII.contents = string.Empty;
            RCSettings.ahssReload = 0;
            RCSettings.aRate = 0f;
            RCSettings.banEren = 0;
            RCSettings.bombMode = 0;
            RCSettings.cRate = 0f;
            RCSettings.damageMode = 0;
            RCSettings.deadlyCannons = 0;
            RCSettings.disableRock = 0;
            RCSettings.endlessMode = 0;
            RCSettings.explodeMode = 0;
            RCSettings.friendlyMode = 0;
            RCSettings.gameType = 0;
            RCSettings.globalDisableMinimap = 0;
            RCSettings.healthLower = 0;
            RCSettings.healthMode = 0;
            RCSettings.healthUpper = 0;
            RCSettings.horseMode = 0;
            RCSettings.infectionMode = 0;
            RCSettings.jRate = 0f;
            RCSettings.maxWave = 20;
            RCSettings.moreTitans = 0;
            RCSettings.motd = string.Empty;
            RCSettings.nRate = 0f;
            RCSettings.pointMode = 0;
            RCSettings.pRate = 0f;
            RCSettings.punkWaves = 0;
            RCSettings.pvpMode = 0;
            RCSettings.racingStatic = 0;
            RCSettings.sizeLower = 0f;
            RCSettings.sizeMode = 0;
            RCSettings.sizeUpper = 0f;
            RCSettings.spawnMode = 0;
            RCSettings.teamMode = 0;
            RCSettings.titanCap = 0;
            RCSettings.waveModeNum = 0;
            RCSettings.waveModeOn = 0;
            Gamemodes.RCGameModes.Clear();
            for (int i = 0; i < 50; i++)
            {
                FengGameManagerMKII.settingsGame[i] = 0;
            }
        }
        InRoomChat.titanSizes = 0f;
        InRoomChat.titanSizes2 = 0f;
        int[] numArray = new int[50];
        for (int j = 0; j < 50; j++)
        {
            numArray[j] = 0;
        }
        FengGameManagerMKII.settingsGame = numArray;
        FengGameManagerMKII.settings[0] = false;
        FengGameManagerMKII.settings[1] = false;
        FengGameManagerMKII.settings[2] = false;
        FengGameManagerMKII.settings[6] = false;
        FengGameManagerMKII.settings[7] = false;
        FengGameManagerMKII.settings[8] = false;
        FengGameManagerMKII.settings[9] = false;
        FengGameManagerMKII.settings[10] = false;
        FengGameManagerMKII.settings[11] = false;
        FengGameManagerMKII.settings[12] = false;
        FengGameManagerMKII.settings[13] = (bool)FengGameManagerMKII.settings[13];
        FengGameManagerMKII.settings[15] = 20;
        FengGameManagerMKII.settings[16] = false;
        FengGameManagerMKII.settings[17] = false;
        FengGameManagerMKII.settings[18] = false;
        FengGameManagerMKII.settings[19] = 0;
        FengGameManagerMKII.settings[20] = 7;
        FengGameManagerMKII.settings[21] = false;
        FengGameManagerMKII.settings[22] = false;
        FengGameManagerMKII.settings[23] = false;
        FengGameManagerMKII.settings[24] = true;
        FengGameManagerMKII.settings[26] = false;
        FengGameManagerMKII.settings[27] = -1;
        FengGameManagerMKII.settings[28] = false;
        FengGameManagerMKII.settings[29] = 1f;
        FengGameManagerMKII.settings[31] = false;
        FengGameManagerMKII.settings[34] = false;
        FengGameManagerMKII.settings[35] = false;
        FengGameManagerMKII.settings[40] = false;
        FengGameManagerMKII.settings[50] = false;
        FengGameManagerMKII.settings[54] = false;
        FengGameManagerMKII.settings[56] = false;
        FengGameManagerMKII.settings[58] = 0;
        if (message == PhotonNetworkingMessage.OnLeftRoom)
        {
            FengGameManagerMKII.settings[77] = string.Empty;
        }
        FengGameManagerMKII.settings[79] = false;
        FengGameManagerMKII.settings[81] = false;
        FengGameManagerMKII.settings[82] = false;
        FengGameManagerMKII.settings[85] = false;
        FengGameManagerMKII.settings[87] = 0;
        FengGameManagerMKII.settings[101] = (string)FengGameManagerMKII.settings[101];
        FengGameManagerMKII.settings[107] = false;
        FengGameManagerMKII.settings[108] = false;
        FengGameManagerMKII.settings[109] = false;
        FengGameManagerMKII.settings[110] = false;
        FengGameManagerMKII.settings[111] = false;
        FengGameManagerMKII.settings[112] = false;
        if (message == PhotonNetworkingMessage.OnLeftRoom)
        {
            FengGameManagerMKII.settings[88] = string.Empty;
            if (InRoomChat.Groups.Count > 0)
            {
                Stack<InRoomGroup> stack = new Stack<InRoomGroup>(InRoomChat.Groups);
                while (stack.Count > 0)
                {
                    InRoomGroup inRoomGroup = stack.Pop();
                    if (inRoomGroup == null)
                    {
                        continue;
                    }
                    //InRoomChat.Chat.LocallyLeaveGroup(inRoomGroup.ID);
                }
                InRoomChat.grouping = false;
            }
            PhotonNetwork.isAntiCheat = false;
        }
        //InRoomChat.Groups.Clear();
        FengGameManagerMKII.loadconfig();
    }

    private static void ResetBoxCollider()
    {
        string str = FengGameManagerMKII.levelinfo.mapName;
        string str1 = str;
        if (str != null)
        {
            switch (str1)
            {
                case "track - akina":
                    {
                        FengGameManagerMKII.LevelBounds.center = (new Vector3(897f, 26.6f, 1971.4f));
                        FengGameManagerMKII.LevelBounds.size = (new Vector3(3303.1f, 255.1f, 4363.8f));
                        return;
                    }
                case "CaveFight":
                    {
                        FengGameManagerMKII.LevelBounds.center = (new Vector3(7.9f, 20.2f, 2.5f));
                        FengGameManagerMKII.LevelBounds.size = (new Vector3(118.3f, 161.4f, 290.3f));
                        return;
                    }
                case "The Forest":
                    {
                        FengGameManagerMKII.LevelBounds.center = (new Vector3(0.3f, 551.3f, 0.8f));
                        FengGameManagerMKII.LevelBounds.size = (new Vector3(1399.8f, 1404.3f, 1401f));
                        return;
                    }
                case "The City I":
                    {
                        FengGameManagerMKII.LevelBounds.center = (new Vector3(23.3f, 700f, 14.3f));
                        FengGameManagerMKII.LevelBounds.size = (new Vector3(1543f, 1800f, 1594.4f));
                        return;
                    }
                case "HouseFight":
                    {
                        FengGameManagerMKII.LevelBounds.center = (new Vector3(0f, 17.9f, 8.4f));
                        FengGameManagerMKII.LevelBounds.size = (new Vector3(67.2f, 185.9f, 143.6f));
                        return;
                    }
                case "Colossal Titan":
                    {
                        FengGameManagerMKII.LevelBounds.center = (new Vector3(-23.65f, 619.1f, 180.9f));
                        FengGameManagerMKII.LevelBounds.size = (new Vector3(2040f, 1540f, 1872f));
                        return;
                    }
                case "OutSide":
                    {
                        FengGameManagerMKII.LevelBounds.center = (new Vector3(2489.6f, 619.5f, 2869.1f));
                        FengGameManagerMKII.LevelBounds.size = (new Vector3(7205.3f, 1540.9f, 5838.1f));
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
        }
    }

    private void ResetKillInfo()
    {
        FengGameManagerMKII.waitforkillinfo = false;
    }

    private void resetSettings(bool isLeave)
    {
        FengGameManagerMKII.uiname = LoginFengKAI.player.name;
        ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
        hashtable.Add("RCteam", 0);
        ExitGames.Client.Photon.Hashtable hashtable1 = hashtable;
        if (isLeave)
        {
            //FengGameManagerMKII.contents = string.Empty;
            FengGameManagerMKII.mapScript = string.Empty;
            FengGameManagerMKII.currentLevel = string.Empty;
            hashtable1.Add("currentLevel", string.Empty);
            FengGameManagerMKII.currentScriptLogic = string.Empty;
            FengGameManagerMKII.levelCache.Clear();
            FengGameManagerMKII.titanSpawnersCopy.Clear();
            FengGameManagerMKII.playerSpawnsC.Clear();
            FengGameManagerMKII.playerSpawnsM.Clear();
            FengGameManagerMKII.titanSpawners.Clear();
            FengGameManagerMKII.titanSpawns.Clear();
            //FengGameManagerMKII.customPhoton.Clear();
            //FengGameManagerMKII.contents = string.Empty;
            RCSettings.ahssReload = 0;
            RCSettings.aRate = 0f;
            RCSettings.banEren = 0;
            RCSettings.bombMode = 0;
            RCSettings.cRate = 0f;
            RCSettings.damageMode = 0;
            RCSettings.deadlyCannons = 0;
            RCSettings.disableRock = 0;
            RCSettings.endlessMode = 0;
            RCSettings.explodeMode = 0;
            RCSettings.friendlyMode = 0;
            RCSettings.gameType = 0;
            RCSettings.globalDisableMinimap = 0;
            RCSettings.healthLower = 0;
            RCSettings.healthMode = 0;
            RCSettings.healthUpper = 0;
            RCSettings.horseMode = 0;
            RCSettings.infectionMode = 0;
            RCSettings.jRate = 0f;
            RCSettings.maxWave = 20;
            RCSettings.moreTitans = 0;
            RCSettings.motd = string.Empty;
            RCSettings.nRate = 0f;
            RCSettings.pointMode = 0;
            RCSettings.pRate = 0f;
            RCSettings.punkWaves = 0;
            RCSettings.pvpMode = 0;
            RCSettings.racingStatic = 0;
            RCSettings.spawnMode = 0;
            RCSettings.teamMode = 0;
            RCSettings.titanCap = 0;
            RCSettings.waveModeNum = 0;
            RCSettings.waveModeOn = 0;
            Gamemodes.RCGameModes.Clear();
            for (int i = 0; i < 50; i++)
            {
                FengGameManagerMKII.settingsGame[i] = 0;
            }
            while (FengGameManagerMKII.customObjects.Count > 0)
            {
                GameObject gameObject = FengGameManagerMKII.customObjects.Dequeue();
                if (gameObject == null)
                {
                    continue;
                }
                UnityEngine.Object.Destroy(gameObject);
            }
        }
        PhotonNetwork.player.SetCustomProperties(hashtable1);
        for (int j = 0; j < 50; j++)
        {
            FengGameManagerMKII.settingsGame[j] = 0;
        }
        FengGameManagerMKII.settingsGame[20] = 1;
        FengGameManagerMKII.oldScript = string.Empty;
        FengGameManagerMKII.heroHash.Clear();
    }

    private static void resetSkyTexture(int level = 1)
    {
        if (level != 1000 && !FengGameManagerMKII.skyname.IsNullOrEmpty() && (PhotonNetwork.connectionStateDetailed == PeerStates.Joined || IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE))
        {
            return;
        }
        if (Camera.main == null)
        {
            return;
        }
        if (IN_GAME_MAIN_CAMERA.skybox == null)
        {
            IN_GAME_MAIN_CAMERA.skybox = Camera.main.GetComponent<Skybox>();
            if (IN_GAME_MAIN_CAMERA.skybox == null)
            {
                return;
            }
        }
        if (level != 0 && (PhotonNetwork.networkingPeer == null || !PhotonNetwork.networkingPeer.State.ToString().Contains("Disconnect")))
        {
            switch (IN_GAME_MAIN_CAMERA.dayLight)
            {
                case DayLight.Day:
                    {
                        IN_GAME_MAIN_CAMERA.skybox.material = (new Material(FengGameManagerMKII.skinCache[4]["DAY"]));
                        return;
                    }
                case DayLight.Dawn:
                    {
                        IN_GAME_MAIN_CAMERA.skybox.material = (new Material(FengGameManagerMKII.skinCache[4]["DAWN"]));
                        return;
                    }
                case DayLight.Night:
                case DayLight.NightVision:
                case DayLight.Limbo:
                case DayLight.Sketch:
                    {
                        IN_GAME_MAIN_CAMERA.skybox.material = (new Material(FengGameManagerMKII.skinCache[4]["NIGHT"]));
                        break;
                    }
    internal static void loadconfig()
    {
        int i;
        string[] empty = new string[100];
        for (i = 0; i < 100; i++)
        {
            empty[i] = string.Empty;
        }
        empty[0] = PlayerPrefs.GetString("human", "1");
        empty[1] = PlayerPrefs.GetString("titan", "1");
        empty[2] = PlayerPrefs.GetString("level", "1");
        empty[3] = PlayerPrefs.GetString("horse", string.Empty);
        empty[4] = PlayerPrefs.GetString("hair", string.Empty);
        empty[5] = PlayerPrefs.GetString("eye", string.Empty);
        empty[6] = PlayerPrefs.GetString("glass", string.Empty);
        empty[7] = PlayerPrefs.GetString("face", string.Empty);
        empty[8] = PlayerPrefs.GetString("skin", string.Empty);
        empty[9] = PlayerPrefs.GetString("costume", string.Empty);
        empty[10] = PlayerPrefs.GetString("logo", string.Empty);
        empty[11] = PlayerPrefs.GetString("bladel", string.Empty);
        empty[12] = PlayerPrefs.GetString("blader", string.Empty);
        empty[13] = PlayerPrefs.GetString("gas", string.Empty);
        empty[14] = PlayerPrefs.GetString("haircolor", "0");
        empty[15] = PlayerPrefs.GetString("gasenable", "0");
        empty[16] = PlayerPrefs.GetString("titanHead1", "http://i.imgur.com/vCqCfXH.png");
        empty[17] = PlayerPrefs.GetString("titanHead2", "http://i.imgur.com/vCqCfXH.png");
        empty[18] = PlayerPrefs.GetString("titanHead3", "http://i.imgur.com/FYTJrP4.png");
        empty[19] = PlayerPrefs.GetString("titanHead4", "http://i.imgur.com/FYTJrP4.png");
        empty[20] = PlayerPrefs.GetString("titanHead5", string.Empty);
        empty[21] = PlayerPrefs.GetString("titanHead6", string.Empty);
        empty[22] = PlayerPrefs.GetString("titanHead7", string.Empty);
        empty[23] = PlayerPrefs.GetString("titanHead8", string.Empty);
        empty[24] = PlayerPrefs.GetString("titanBody1", "http://i.imgur.com/NaQkcAl.png");
        empty[25] = PlayerPrefs.GetString("titanBody2", "http://i.imgur.com/NaQkcAl.png");
        empty[26] = PlayerPrefs.GetString("titanBody3", "http://i.imgur.com/v7CBTCM.png");
        empty[27] = PlayerPrefs.GetString("titanBody4", "http://i.imgur.com/v7CBTCM.png");
        empty[28] = PlayerPrefs.GetString("titanBody5", string.Empty);
        empty[29] = PlayerPrefs.GetString("titanBody6", string.Empty);
        empty[30] = PlayerPrefs.GetString("titanBody7", string.Empty);
        empty[31] = PlayerPrefs.GetString("titanBody8", string.Empty);
        empty[32] = PlayerPrefs.GetString("titanR", "0");
        empty[33] = PlayerPrefs.GetString("tree1", "http://i.imgur.com/UkjOfy2.png");
        empty[34] = PlayerPrefs.GetString("tree2", "http://i.imgur.com/UkjOfy2.png");
        empty[35] = PlayerPrefs.GetString("tree3", "http://i.imgur.com/H5Q8ZS6.png");
        empty[36] = PlayerPrefs.GetString("tree4", "http://i.imgur.com/H5Q8ZS6.png");
        empty[37] = PlayerPrefs.GetString("tree5", "http://i.imgur.com/UkjOfy2.png");
        empty[38] = PlayerPrefs.GetString("tree6", "http://i.imgur.com/UkjOfy2.png");
        empty[39] = PlayerPrefs.GetString("tree7", "http://i.imgur.com/H5Q8ZS6.png");
        empty[40] = PlayerPrefs.GetString("tree8", "http://i.imgur.com/H5Q8ZS6.png");
        empty[41] = PlayerPrefs.GetString("leaf1", "http://i.imgur.com/lSFZqz2.png");
        empty[42] = PlayerPrefs.GetString("leaf2", "http://i.imgur.com/lSFZqz2.png");
        empty[43] = PlayerPrefs.GetString("leaf3", "http://i.imgur.com/38zHTCW.png");
        empty[44] = PlayerPrefs.GetString("leaf4", "http://i.imgur.com/38zHTCW.png");
        empty[45] = PlayerPrefs.GetString("leaf5", "http://i.imgur.com/lSFZqz2.png");
        empty[46] = PlayerPrefs.GetString("leaf6", "http://i.imgur.com/lSFZqz2.png");
        empty[47] = PlayerPrefs.GetString("leaf7", "http://i.imgur.com/38zHTCW.png");
        empty[48] = PlayerPrefs.GetString("leaf8", "http://i.imgur.com/38zHTCW.png");
        empty[49] = PlayerPrefs.GetString("forestG", "http://i.imgur.com/ReUbCu0.jpg");
        empty[50] = PlayerPrefs.GetString("forestR", "0");
        empty[51] = PlayerPrefs.GetString("house1", "http://i.imgur.com/wuy77R8.png");
        empty[52] = PlayerPrefs.GetString("house2", "http://i.imgur.com/wuy77R8.png");
        empty[53] = PlayerPrefs.GetString("house3", "http://i.imgur.com/wuy77R8.png");
        empty[54] = PlayerPrefs.GetString("house4", "http://i.imgur.com/wuy77R8.png");
        empty[55] = PlayerPrefs.GetString("house5", "http://i.imgur.com/wuy77R8.png");
        empty[56] = PlayerPrefs.GetString("house6", "http://i.imgur.com/wuy77R8.png");
        empty[57] = PlayerPrefs.GetString("house7", "http://i.imgur.com/wuy77R8.png");
        empty[58] = PlayerPrefs.GetString("house8", "http://i.imgur.com/wuy77R8.png");
        empty[59] = PlayerPrefs.GetString("cityG", "http://i.imgur.com/Mr9ZXip.png");
        empty[60] = PlayerPrefs.GetString("cityW", "http://i.imgur.com/Tm7XfQP.png");
        empty[61] = PlayerPrefs.GetString("cityH", "http://i.imgur.com/Q3YXkNM.png");
        empty[62] = PlayerPrefs.GetString("skinQ", "0");
        empty[63] = PlayerPrefs.GetString("skinQL", "0");
        empty[64] = "0";
        empty[65] = PlayerPrefs.GetString("eren", string.Empty);
        empty[66] = PlayerPrefs.GetString("annie", string.Empty);
        empty[67] = PlayerPrefs.GetString("colossal", string.Empty);
        empty[87] = PlayerPrefs.GetString("humanset1", "1");
        empty[88] = PlayerPrefs.GetString("humanset2", "0");
        empty[89] = PlayerPrefs.GetString("airspecial", "none");
        empty[90] = PlayerPrefs.GetString("groundspecial", "none");
        empty[91] = "0";
        empty[92] = "0";
        int num = PlayerPrefs.GetInt("gameTypeRS", 1);
        empty[93] = num.ToString();
        empty[94] = PlayerPrefs.GetString("tthrowrock", "V");
        empty[95] = PlayerPrefs.GetString("tmeteor", "B");
        empty[96] = PlayerPrefs.GetString("tlaugh", "G");
        object[] str = new object[300];
        for (i = 0; i < 187; i++)
        {
            if (i != 68 && i != 78 && i != 73 && i != 74 && i != 75 && i != 185 && i != 186 && i != 76 && i != 84)
            {
                str[i] = string.Empty;
            }
        }
        str[0] = PlayerPrefs.GetString("human", "1");
        str[1] = PlayerPrefs.GetString("titan", "1");
        str[2] = PlayerPrefs.GetString("level", "1");
        str[3] = PlayerPrefs.GetString("horse", string.Empty);
        str[4] = PlayerPrefs.GetString("hair", string.Empty);
        str[5] = PlayerPrefs.GetString("eye", string.Empty);
        str[6] = PlayerPrefs.GetString("glass", string.Empty);
        str[7] = PlayerPrefs.GetString("face", string.Empty);
        str[8] = PlayerPrefs.GetString("skin", string.Empty);
        str[9] = PlayerPrefs.GetString("costume", string.Empty);
        str[10] = PlayerPrefs.GetString("logo", string.Empty);
        str[11] = PlayerPrefs.GetString("bladel", string.Empty);
        str[12] = PlayerPrefs.GetString("blader", string.Empty);
        str[13] = PlayerPrefs.GetString("gas", string.Empty);
        str[14] = PlayerPrefs.GetString("hoodie", string.Empty);
        str[15] = PlayerPrefs.GetString("gasenable", "0");
        str[16] = PlayerPrefs.GetString("titantype1", "-1");
        str[17] = PlayerPrefs.GetString("titantype2", "-1");
        str[18] = PlayerPrefs.GetString("titantype3", "-1");
        str[19] = PlayerPrefs.GetString("titantype4", "-1");
        str[20] = PlayerPrefs.GetString("titantype5", "-1");
        str[21] = PlayerPrefs.GetString("titanhair1", string.Empty);
        str[22] = PlayerPrefs.GetString("titanhair2", string.Empty);
        str[23] = PlayerPrefs.GetString("titanhair3", string.Empty);
        str[24] = PlayerPrefs.GetString("titanhair4", string.Empty);
        str[25] = PlayerPrefs.GetString("titanhair5", string.Empty);
        str[26] = PlayerPrefs.GetString("titaneye1", string.Empty);
        str[27] = PlayerPrefs.GetString("titaneye2", string.Empty);
        str[28] = PlayerPrefs.GetString("titaneye3", string.Empty);
        str[29] = PlayerPrefs.GetString("titaneye4", string.Empty);
        str[30] = PlayerPrefs.GetString("titaneye5", string.Empty);
        str[31] = PlayerPrefs.GetString("titangui", "0");
        str[32] = PlayerPrefs.GetString("titanR", "0");
        str[33] = PlayerPrefs.GetString("tree1");
        str[34] = PlayerPrefs.GetString("tree2");
        str[35] = PlayerPrefs.GetString("tree3");
        str[36] = PlayerPrefs.GetString("tree4");
        str[37] = PlayerPrefs.GetString("tree5");
        str[38] = PlayerPrefs.GetString("tree6");
        str[39] = PlayerPrefs.GetString("tree7");
        str[40] = PlayerPrefs.GetString("tree8");
        str[41] = PlayerPrefs.GetString("leaf1");
        str[42] = PlayerPrefs.GetString("leaf2");
        str[43] = PlayerPrefs.GetString("leaf3");
        str[44] = PlayerPrefs.GetString("leaf4");
        str[45] = PlayerPrefs.GetString("leaf5");
        str[46] = PlayerPrefs.GetString("leaf6");
        str[47] = PlayerPrefs.GetString("leaf7");
        str[48] = PlayerPrefs.GetString("leaf8");
        str[49] = PlayerPrefs.GetString("forestG");
        str[50] = PlayerPrefs.GetString("forestR");
        str[51] = PlayerPrefs.GetString("house1");
        str[52] = PlayerPrefs.GetString("house2");
        str[53] = PlayerPrefs.GetString("house3");
        str[54] = PlayerPrefs.GetString("house4");
        str[55] = PlayerPrefs.GetString("house5");
        str[56] = PlayerPrefs.GetString("house6");
        str[57] = PlayerPrefs.GetString("house7");
        str[58] = PlayerPrefs.GetString("house8");
        str[59] = PlayerPrefs.GetString("cityG");
        str[60] = PlayerPrefs.GetString("cityW");
        str[61] = PlayerPrefs.GetString("cityH");
        str[62] = PlayerPrefs.GetString("skinQ");
        str[63] = PlayerPrefs.GetString("skinQL");
        str[64] = 0;
        str[65] = PlayerPrefs.GetString("eren", string.Empty);
        str[66] = PlayerPrefs.GetString("annie", string.Empty);
        str[67] = PlayerPrefs.GetString("colossal", string.Empty);
        str[68] = 0;
        str[69] = "default";
        str[70] = "1";
        str[71] = "1";
        str[72] = "1";
        str[73] = 1f;
        str[74] = 1f;
        str[75] = 1f;
        str[76] = 0;
        str[77] = string.Empty;
        str[78] = 0;
        str[79] = "1";
        str[80] = "1";
        str[81] = "0";
        str[82] = PlayerPrefs.GetString("cnumber", "1");
        str[126] = PlayerPrefs.GetString("lslow", "LeftShift");
        str[127] = PlayerPrefs.GetString("lrforward", "R");
        str[128] = PlayerPrefs.GetString("lrback", "F");
        str[129] = PlayerPrefs.GetString("lrleft", "Q");
        str[130] = PlayerPrefs.GetString("lrright", "E");
        str[131] = PlayerPrefs.GetString("lrccw", "Z");
        str[132] = PlayerPrefs.GetString("lrcw", "C");
        str[133] = PlayerPrefs.GetString("humangui", "0");
        str[134] = PlayerPrefs.GetString("horse2", string.Empty);
        str[135] = PlayerPrefs.GetString("hair2", string.Empty);
        str[136] = PlayerPrefs.GetString("eye2", string.Empty);
        str[137] = PlayerPrefs.GetString("glass2", string.Empty);
        str[138] = PlayerPrefs.GetString("face2", string.Empty);
        str[139] = PlayerPrefs.GetString("skin2", string.Empty);
        str[140] = PlayerPrefs.GetString("costume2", string.Empty);
        str[141] = PlayerPrefs.GetString("logo2", string.Empty);
        str[142] = PlayerPrefs.GetString("bladel2", string.Empty);
        str[143] = PlayerPrefs.GetString("blader2", string.Empty);
        str[144] = PlayerPrefs.GetString("gas2", string.Empty);
        str[145] = PlayerPrefs.GetString("hoodie2", string.Empty);
        str[146] = PlayerPrefs.GetString("trail2", string.Empty);
        str[147] = PlayerPrefs.GetString("horse3", string.Empty);
        str[148] = PlayerPrefs.GetString("hair3", string.Empty);
        str[149] = PlayerPrefs.GetString("eye3", string.Empty);
        str[150] = PlayerPrefs.GetString("glass3", string.Empty);
        str[151] = PlayerPrefs.GetString("face3", string.Empty);
        str[152] = PlayerPrefs.GetString("skin3", string.Empty);
        str[153] = PlayerPrefs.GetString("costume3", string.Empty);
        str[154] = PlayerPrefs.GetString("logo3", string.Empty);
        str[155] = PlayerPrefs.GetString("bladel3", string.Empty);
        str[156] = PlayerPrefs.GetString("blader3", string.Empty);
        str[157] = PlayerPrefs.GetString("gas3", string.Empty);
        str[158] = PlayerPrefs.GetString("hoodie3", string.Empty);
        str[159] = PlayerPrefs.GetString("trail3", string.Empty);
        FengGameManagerMKII.currentScript = PlayerPrefs.GetString("script", string.Empty);
        str[161] = PlayerPrefs.GetString("lfast", ((KeyCode)306).ToString());
        str[162] = PlayerPrefs.GetString("customGround", string.Empty);
        str[163] = PlayerPrefs.GetString("forestskyfront", string.Empty);
        str[164] = PlayerPrefs.GetString("forestskyback", string.Empty);
        str[165] = PlayerPrefs.GetString("forestskyleft", string.Empty);
        str[166] = PlayerPrefs.GetString("forestskyright", string.Empty);
        str[167] = PlayerPrefs.GetString("forestskyup", string.Empty);
        str[168] = PlayerPrefs.GetString("forestskydown", string.Empty);
        str[169] = PlayerPrefs.GetString("cityskyfront", string.Empty);
        str[170] = PlayerPrefs.GetString("cityskyback", string.Empty);
        str[171] = PlayerPrefs.GetString("cityskyleft", string.Empty);
        str[172] = PlayerPrefs.GetString("cityskyright", string.Empty);
        str[173] = PlayerPrefs.GetString("cityskyup", string.Empty);
        str[174] = PlayerPrefs.GetString("cityskydown", string.Empty);
        str[175] = PlayerPrefs.GetString("customskyfront", string.Empty);
        str[176] = PlayerPrefs.GetString("customskyback", string.Empty);
        str[177] = PlayerPrefs.GetString("customskyleft", string.Empty);
        str[178] = PlayerPrefs.GetString("customskyright", string.Empty);
        str[179] = PlayerPrefs.GetString("customskyup", string.Empty);
        str[180] = PlayerPrefs.GetString("customskydown", string.Empty);
        str[181] = PlayerPrefs.GetString("dashenable", string.Empty);
        str[182] = PlayerPrefs.GetString("dashkey", "RightControl");
        str[183] = PlayerPrefs.GetString("vsync", "0");
        str[184] = PlayerPrefs.GetString("fpscap", "0");
        str[185] = 0;
        str[186] = 0;
        str[187] = 0;
        str[188] = 0;
        str[189] = PlayerPrefs.GetInt("speedometer", 0);
        str[190] = 0;
        str[191] = string.Empty;
        str[192] = PlayerPrefs.GetInt("bombMode", 0);
        str[193] = PlayerPrefs.GetInt("teamMode", 0);
        str[194] = PlayerPrefs.GetInt("rockThrow", 0);
        str[195] = PlayerPrefs.GetInt("explodeModeOn", 0);
        str[196] = PlayerPrefs.GetString("explodeModeNum", "30");
        str[197] = PlayerPrefs.GetInt("healthMode", 0);
        str[198] = PlayerPrefs.GetString("healthLower", "100");
        str[199] = PlayerPrefs.GetString("healthUpper", "200");
        str[200] = PlayerPrefs.GetInt("infectionModeOn", 0);
        str[201] = PlayerPrefs.GetString("infectionModeNum", "1");
        str[202] = PlayerPrefs.GetInt("banEren", 0);
        str[203] = PlayerPrefs.GetInt("moreTitanOn", 0);
        str[204] = PlayerPrefs.GetString("moreTitanNum", "1");
        str[205] = PlayerPrefs.GetInt("damageModeOn", 0);
        str[206] = PlayerPrefs.GetString("damageModeNum", "1000");
        str[207] = PlayerPrefs.GetInt("sizeMode", 0);
        str[208] = PlayerPrefs.GetString("sizeLower", "1.0");
        str[209] = PlayerPrefs.GetString("sizeUpper", "3.0");
        str[210] = PlayerPrefs.GetInt("spawnModeOn", 0);
        str[211] = PlayerPrefs.GetString("nRate", "20.0");
        str[212] = PlayerPrefs.GetString("aRate", "20.0");
        str[213] = PlayerPrefs.GetString("jRate", "20.0");
        str[214] = PlayerPrefs.GetString("cRate", "20.0");
        str[215] = PlayerPrefs.GetString("pRate", "20.0");
        str[216] = PlayerPrefs.GetInt("horseMode", 0);
        str[217] = PlayerPrefs.GetInt("waveModeOn", 0);
        str[218] = PlayerPrefs.GetString("waveModeNum", "1");
        str[219] = PlayerPrefs.GetInt("friendlyMode", 0);
        str[220] = PlayerPrefs.GetInt("pvpMode", 0);
        str[221] = PlayerPrefs.GetInt("maxWaveOn", 0);
        str[222] = PlayerPrefs.GetString("maxWaveNum", "20");
        str[223] = PlayerPrefs.GetInt("endlessModeOn", 0);
        str[224] = PlayerPrefs.GetString("endlessModeNum", "10");
        str[225] = PlayerPrefs.GetString("motd", string.Empty);
        str[226] = PlayerPrefs.GetInt("pointModeOn", 0);
        str[227] = PlayerPrefs.GetString("pointModeNum", "50");
        str[228] = PlayerPrefs.GetInt("ahssReload", 0);
        str[229] = PlayerPrefs.GetInt("punkWaves", 0);
        str[230] = 0;
        str[231] = PlayerPrefs.GetInt("mapOn", 0);
        str[232] = PlayerPrefs.GetString("mapMaximize", "Tab");
        str[233] = PlayerPrefs.GetString("mapToggle", "M");
        str[234] = PlayerPrefs.GetString("mapReset", "K");
        str[235] = PlayerPrefs.GetInt("globalDisableMinimap", 0);
        str[236] = PlayerPrefs.GetString("chatRebind", "None");
        str[237] = PlayerPrefs.GetString("hforward", "W");
        str[238] = PlayerPrefs.GetString("hback", "S");
        str[239] = PlayerPrefs.GetString("hleft", "A");
        str[240] = PlayerPrefs.GetString("hright", "D");
        str[241] = PlayerPrefs.GetString("hwalk", "LeftShift");
        str[242] = PlayerPrefs.GetString("hjump", "Q");
        str[243] = PlayerPrefs.GetString("hmount", "LeftControl");
        str[244] = PlayerPrefs.GetInt("chatfeed", 0);
        str[245] = 0;
        str[246] = PlayerPrefs.GetFloat("bombR", 1f);
        str[247] = PlayerPrefs.GetFloat("bombG", 1f);
        str[248] = PlayerPrefs.GetFloat("bombB", 1f);
        str[249] = PlayerPrefs.GetFloat("bombA", 1f);
        str[250] = PlayerPrefs.GetInt("bombRadius", 5);
        str[251] = PlayerPrefs.GetInt("bombRange", 5);
        str[252] = PlayerPrefs.GetInt("bombSpeed", 5);
        str[253] = PlayerPrefs.GetInt("bombCD", 5);
        str[254] = PlayerPrefs.GetString("cannonUp", "W");
        str[255] = PlayerPrefs.GetString("cannonDown", "S");
        str[256] = PlayerPrefs.GetString("cannonLeft", "A");
        str[257] = PlayerPrefs.GetString("cannonRight", "D");
        str[258] = PlayerPrefs.GetString("cannonFire", "Q");
        str[259] = PlayerPrefs.GetString("cannonMount", "G");
        str[260] = PlayerPrefs.GetString("cannonSlow", "LeftShift");
        str[261] = PlayerPrefs.GetInt("deadlyCannon", 0);
        FengGameManagerMKII.editormoves = new KeyCode[18];
        for (i = 0; i < 16; i++)
        {
            FengGameManagerMKII.editormoves[i] = (KeyCode)Enum.Parse(typeof(KeyCode), (string)str[117 + i]);
        }
        FengGameManagerMKII.inputRC = new InputManagerRC();
        FengGameManagerMKII.inputRC.setInputHuman(InputCodeRC.reelin, (string)str[98]);
        FengGameManagerMKII.inputRC.setInputHuman(InputCodeRC.reelout, (string)str[99]);
        FengGameManagerMKII.inputRC.setInputHuman(InputCodeRC.dash, (string)str[182]);
        FengGameManagerMKII.inputRC.setInputHuman(InputCodeRC.mapMaximize, (string)str[232]);
        FengGameManagerMKII.inputRC.setInputHuman(InputCodeRC.mapToggle, (string)str[233]);
        FengGameManagerMKII.inputRC.setInputHuman(InputCodeRC.mapReset, (string)str[234]);
        if (!Enum.IsDefined(typeof(KeyCode), (string)str[232]))
        {
            str[232] = "None";
        }
        if (!Enum.IsDefined(typeof(KeyCode), (string)str[233]))
        {
            str[233] = "None";
        }
        if (!Enum.IsDefined(typeof(KeyCode), (string)str[234]))
        {
            str[234] = "None";
        }
        for (i = 0; i < 15; i++)
        {
            FengGameManagerMKII.inputRC.setInputTitan(i, (string)str[101 + i]);
        }
        FengGameManagerMKII.inputRC.setInputTitan(15, empty[94]);
        FengGameManagerMKII.inputRC.setInputTitan(16, empty[95]);
        FengGameManagerMKII.inputRC.setInputTitan(17, empty[96]);
        for (i = 0; i < 7; i++)
        {
            FengGameManagerMKII.inputRC.setInputCannon(i, (string)str[254 + i]);
        }
        for (i = 0; i < 16; i++)
        {
            FengGameManagerMKII.inputRC.setInputLevel(i, (string)str[117 + i]);
        }
        FengGameManagerMKII.inputRC.setInputLevel(InputCodeRC.levelFast, (string)str[161]);
        int num1 = PlayerPrefs.GetInt("texQuality", 100);
        QualitySettings.masterTextureLimit = ((num1 == 100 ? QualitySettings.masterTextureLimit : num1));
        FengGameManagerMKII.editormoves[16] = (KeyCode)Enum.Parse(typeof(KeyCode), (string)str[161]);
        FengGameManagerMKII.settings[25] = PlayerPrefs.GetString("redCross", "False") == "True";
        FengGameManagerMKII.settings[32] = (int)PlayerPrefs.GetFloat("dmgscreenshot", 0f);
        FengGameManagerMKII.settings[33] = PlayerPrefs.GetString("deathscreenshot", "False") == "True";
        FengGameManagerMKII.settings[39] = PlayerPrefs.GetString("fog", "False") == "True";
        FengGameManagerMKII.settings[43] = PlayerPrefs.GetString("bodylean", "True") == "True";
        FengGameManagerMKII.settings[44] = PlayerPrefs.GetString("autoaimGuns", "False") == "True";
        FengGameManagerMKII.settings[45] = PlayerPrefs.GetString("weaponTrail", "True") == "True";
        FengGameManagerMKII.settings[48] = PlayerPrefs.GetString("oldtrail", "False") == "True";
        FengGameManagerMKII.settings[62] = PlayerPrefs.GetString("HDSnapShots", "False") == "True";
        FengGameManagerMKII.settings[75] = PlayerPrefs.GetInt("ShowHUD", 4);
        FengGameManagerMKII.settings[83] = PlayerPrefs.GetString("FPScamera", "False") == "True";
        FengGameManagerMKII.settings[84] = PlayerPrefs.GetString("AnimatedName", "None");
        FengGameManagerMKII.settings[114] = PlayerPrefs.GetString("mapTogglePref", "False") == "True";
        FengGameManagerMKII.settings[115] = PlayerPrefs.GetString("RSSpeedMeter", "False") == "True";/*
        if (Minimap.instance)
        {
            Minimap.instance.SetEnabled((bool)FengGameManagerMKII.settings[114]);
        }*/
        AudioListener.volume = (Convert.ToSingle(PlayerPrefs.GetString("vol", "1")));
        FengGameManagerMKII.settings[95] = PlayerPrefs.GetString("Faded", "None");
        FengGameManagerMKII.settings[96] = PlayerPrefs.GetString("Linear", "None");
        FengGameManagerMKII.settings[97] = PlayerPrefs.GetString("Rebound", "None");
        FengGameManagerMKII.settingsSkin = empty;
        FengGameManagerMKII.settingsRC = str;
        FengGameManagerMKII.EncodeAnimation((string)FengGameManagerMKII.settings[95]);
        FengGameManagerMKII.EncodeAnimation((string)FengGameManagerMKII.settings[96]);
        FengGameManagerMKII.EncodeAnimation((string)FengGameManagerMKII.settings[97]);
    }

    internal static void RespawnAfterSeconds(float seconds)
    {
        FengGameManagerMKII.MKII.StartCoroutine(FengGameManagerMKII.RespawnAfterSecondsE(seconds));
    }

    private static IEnumerator RespawnAfterSecondsE(float seconds)
    {
        FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("Respawning in...", seconds));
        for (float i = 1f; i <= seconds; i = i + 1f)
        {
            yield return new WaitForSeconds(1f);
            FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("Respawning in...", seconds - i));
        }
        FengGameManagerMKII.MKII.respawnHeroInNewRound();
    }

    private IEnumerator respawnE(float seconds)
    {
        while (PhotonNetwork.isMasterClient && FengGameManagerMKII.settingsGame[24] > 0)
        {
            yield return new WaitForSeconds(seconds);
            if (this.isLosing || this.isWinning)
            {
                continue;
            }
            PhotonPlayer[] photonPlayerArray = PhotonNetwork.playerList;
            for (int i = 0; i < (int)photonPlayerArray.Length; i++)
            {
                PhotonPlayer photonPlayer = photonPlayerArray[i];
                if (photonPlayer.customProperties["RCteam"] == null && photonPlayer.isDead)
                {
                    FengGameManagerMKII.PView.RPC("respawnHeroInNewRound", photonPlayer, new object[0]);
                }
            }
        }
    }

    [RPC]
    private void respawnHeroInNewRound()
    {
        if (!this.needChooseSide && IN_GAME_MAIN_CAMERA.mainCamera.gameOver)
        {
            if (!PhotonNetwork.player.isTitan)
            {
                if (this.myLastHero.IsNullOrEmpty())
                {
                    this.myLastHero = "LEVI";
                }
                this.SpawnPlayer(this.myLastHero, this.myLastRespawnTag);
            }
            else
            {
                if (this.myLastHero.IsNullOrEmpty())
                {
                    this.myLastHero = "RANDOM";
                }
                this.SpawnNonAITitan(this.myLastHero, this.myLastRespawnTag);
            }
            IN_GAME_MAIN_CAMERA.mainCamera.gameOver = false;
            FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
        }
    }

    internal void NOTSpawnNonAITitan(string id)
    {
        this.myLastHero = id.ToUpper();
        PhotonPlayer photonPlayer = PhotonNetwork.player;
        ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
        hashtable.Add("dead", true);
        hashtable.Add("isTitan", 2);
        photonPlayer.SetCustomProperties(hashtable);
        Screen.lockCursor = ((IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS));
        Screen.showCursor = (true);
        FengGameManagerMKII.ShowHUDInfoCenter("the game has started for 60 seconds.\n please wait for next round.\n Click Right Mouse Key to Enter or Exit the Spectator Mode.");
        IN_GAME_MAIN_CAMERA.mainCamera.enabled = (true);
        IN_GAME_MAIN_CAMERA.mainCamera.setMainObject(null, true, false);
        IN_GAME_MAIN_CAMERA.mainCamera.setSpectorMode(true);
        IN_GAME_MAIN_CAMERA.mainCamera.gameOver = true;
    }

    public void cache()
    {
        FengGameManagerMKII.BoundsDisabled = false;
        FengGameManagerMKII.logicLoaded = false;
        FengGameManagerMKII.customLevelLoaded = true;
        this.isUnloading = false;
        FengGameManagerMKII.PView = base.photonView;
        GameObject gameObject = CacheGameObject.Find("LabelScore");
        FengGameManagerMKII.LabelScore = gameObject;
        UILabel component = gameObject.GetComponent<UILabel>();
        FengGameManagerMKII.LabelScoreUI = component;
        FengGameManagerMKII.LabelScoreT = ((Component)component).transform;
        FengGameManagerMKII.titanSpawners.Clear();
        if (FengGameManagerMKII.titanSpawnersCopy.Count > 0)
        {
            FengGameManagerMKII.titanSpawners = new List<TitanSpawner>(FengGameManagerMKII.titanSpawnersCopy);
        }
        FengGameManagerMKII.groundList.Clear();
        Time.timeScale = (1f);
        if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
        {
            FengGameManagerMKII.roundTime = 0f;
            if (FengGameManagerMKII.level.StartsWith("Custom"))
            {
                FengGameManagerMKII.customLevelLoaded = false;
            }
            if (PhotonNetwork.isMasterClient)
            {
                if (FengGameManagerMKII.isFirstLoad)
                {
                    this.setGameSettings(Gamemodes.RCGameModes, null);
                }
                if (RCSettings.endlessMode > 0)
                {
                    base.StartCoroutine(this.respawnE((float)RCSettings.endlessMode));
                }
            }
            if ((int)FengGameManagerMKII.settingsRC[244] == 1 && InRoomChat.Chat != null)
            {
                InRoomChat.addLINE(string.Concat("<color=#FFC000>(", FengGameManagerMKII.roundTime.ToString("F2"), ")</color> Round Start."), null, false, true);
            }
        }
        FengGameManagerMKII.isFirstLoad = false;
        FengGameManagerMKII.MKII = this;
    }


    public void NOTSpawnNonAITitanRC(string id)
    {
        this.myLastHero = id.ToUpper();
        PhotonPlayer photonPlayer = PhotonNetwork.player;
        ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
        hashtable.Add("dead", true);
        hashtable.Add("isTitan", 2);
        photonPlayer.SetCustomProperties(hashtable);
        Screen.lockCursor = ((IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS));
        Screen.showCursor = (true);
        FengGameManagerMKII.ShowHUDInfoCenter("Syncing spawn locations...");
        IN_GAME_MAIN_CAMERA.mainCamera.enabled = (true);
        IN_GAME_MAIN_CAMERA.mainCamera.setMainObject(null, true, false);
        IN_GAME_MAIN_CAMERA.mainCamera.setSpectorMode(true);
        IN_GAME_MAIN_CAMERA.mainCamera.gameOver = true;
    }

    internal void NOTSpawnPlayer(string id)
    {
        this.myLastHero = id.ToUpper();
        PhotonPlayer photonPlayer = PhotonNetwork.player;
        ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
        hashtable.Add("dead", true);
        hashtable.Add("isTitan", 1);
        photonPlayer.SetCustomProperties(hashtable);
        Screen.lockCursor = ((IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS));
        Screen.showCursor = (false);
        FengGameManagerMKII.ShowHUDInfoCenter("the game has started for 60 seconds.\n please wait for next round.\n Click Right Mouse Key to Enter or Exit the Spectator Mode.");
        IN_GAME_MAIN_CAMERA.mainCamera.enabled = (true);
        IN_GAME_MAIN_CAMERA.mainCamera.setMainObject(null, true, false);
        IN_GAME_MAIN_CAMERA.mainCamera.setSpectorMode(true);
        IN_GAME_MAIN_CAMERA.mainCamera.gameOver = true;
    }

    private void DestroyLeftOvers()
    {
        int num = 0;
        foreach (Photon.MonoBehaviour monoBehaviour in new HashSet<Photon.MonoBehaviour>(UnityEngine.Object.FindObjectsOfType<Photon.MonoBehaviour>(), new FunctionEquality<Photon.MonoBehaviour>((Photon.MonoBehaviour x, Photon.MonoBehaviour y) => x.GetInstanceID() == y.GetInstanceID(), (Photon.MonoBehaviour z) => z.GetInstanceID())))
        {
            if (!(monoBehaviour != null) || monoBehaviour.isBackground || monoBehaviour.sceneID == PhotonNetwork.sceneID || FengGameManagerMKII.customObjects.Contains(monoBehaviour.gameObject))
            {
                continue;
            }
            PhotonView photonView = (monoBehaviour is PhotonView ? monoBehaviour as PhotonView : monoBehaviour.photonView);
            if (photonView != null)
            {
                if (photonView.isSceneView)
                {
                    continue;
                }
                PhotonPlayer photonPlayer = photonView.owner;
                if (photonPlayer != null)
                {
                    Debug.Log(string.Format("Destroying...GameObject:{0} Owner:{1} OwnerName:{2}", monoBehaviour, photonPlayer, photonPlayer.uiname));
                }
            }
            PhotonNetwork.networkingPeer.DestroyLeftOver<Photon.MonoBehaviour>(monoBehaviour, true);
            num++;
        }
        if (num > 0)
        {
            if (num == 1)
            {
                object[] objArray = new object[] { num, "<color=yellow><b>", "</b></color>", "<color=silver>", "</color>" };
                InRoomChat.Notify(string.Format("{1}Destroyed {3}{0}{4} leftover gameobject from the last scene.{2}", objArray));
                return;
            }
            object[] objArray1 = new object[] { num, "<color=yellow><b>", "</b></color>", "<color=silver>", "</color>" };
            InRoomChat.Notify(string.Format("{1}Destroyed {3}{0}{4} leftover gameobjects from the last scene.{2}", objArray1));
        }
    }

    internal TITAN randomSpawnOneTitan(string place, int rate)
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag(place);
        int num = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
        while (gameObjectArray[num] == null)
        {
            num = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
        }
        Transform _transform = gameObjectArray[num].transform;
        gameObjectArray[num] = null;
        return this.spawnTitan(rate, _transform.position, _transform.rotation, false);
    }

    internal void randomSpawnTitan(string place, int rate, int num, bool punk = false)
    {
        if (num == -1)
        {
            num = 1;
        }
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag(place);
        if ((int)gameObjectArray.Length > 0)
        {
            for (int i = 0; i < num; i++)
            {
                int num1 = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
                while (gameObjectArray[num1] == null)
                {
                    num1 = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
                }
                Transform _transform = gameObjectArray[num1].transform;
                gameObjectArray[num1] = null;
                this.spawnTitan(rate, _transform.position, _transform.rotation, punk);
            }
        }
    }

    public void NOTSpawnPlayerRC(string id)
    {
        this.myLastHero = id.ToUpper();
        PhotonPlayer photonPlayer = PhotonNetwork.player;
        ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
        hashtable.Add("dead", true);
        hashtable.Add("isTitan", 1);
        photonPlayer.SetCustomProperties(hashtable);
        Screen.lockCursor = ((IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS));
        Screen.showCursor = (false);
        IN_GAME_MAIN_CAMERA.mainCamera.enabled = (true);
        IN_GAME_MAIN_CAMERA.mainCamera.setMainObject(null, true, false);
        IN_GAME_MAIN_CAMERA.mainCamera.setSpectorMode(true);
        IN_GAME_MAIN_CAMERA.mainCamera.gameOver = true;
    }

    internal void SpawnNonAITitan(string id, string tag = "titanRespawn")
    {
        TITAN component;
        if (FengGameManagerMKII.logicLoaded && FengGameManagerMKII.customLevelLoaded)
        {
            Transform _transform = GameObject.FindGameObjectsWithTag(tag).RandomPick<GameObject>().transform;
            this.myLastHero = id.ToUpper();
            if (FengGameManagerMKII.level.StartsWith("Custom") && FengGameManagerMKII.titanSpawns.Count > 0)
            {
                _transform.position = (FengGameManagerMKII.titanSpawns.RandomPick<Vector3>());
            }
            if (IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.PVP_CAPTURE)
            {
                component = PhotonNetwork.Instantiate("TITAN_VER3.1", _transform.position, _transform.rotation, 0, null).AddComponent<TitanUpgrade>().GetComponent<TITAN>();
            }
            else
            {
                _transform = this.checkpoint.transform;
                component = PhotonNetwork.Instantiate("TITAN_VER3.1", _transform.position + new Vector3((float)UnityEngine.Random.Range(-20, 20), 2f, (float)UnityEngine.Random.Range(-20, 20)), _transform.rotation, 0, null).AddComponent<TitanUpgrade>().GetComponent<TITAN>();
            }
            IN_GAME_MAIN_CAMERA.mainCamera.setMainObjectASTITAN(component.gameObject);
            component.nonAI = true;
            component.speed = 30f;
            component.GetComponent<TITAN_CONTROLLER>().enabled = (true);
            if (id == "RANDOM" && UnityEngine.Random.Range(0, 100) < 7)
            {
                component.setAbnormalType(AbnormalType.TYPE_CRAWLER, true);
            }
            IN_GAME_MAIN_CAMERA.mainCamera.enabled = (true);
            IN_GAME_MAIN_CAMERA.mouselook.disable = true;
            IN_GAME_MAIN_CAMERA.spectate.disable = true;
            IN_GAME_MAIN_CAMERA.mainCamera.gameOver = false;
            PhotonPlayer photonPlayer = PhotonNetwork.player;
            ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
            hashtable.Add("dead", false);
            hashtable.Add("isTitan", 2);
            photonPlayer.SetCustomProperties(hashtable);
            Screen.lockCursor = ((IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS));
            Screen.showCursor = (true);
            FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
        }
    }

    internal void SpawnPlayer(string id, string tag = "playerRespawn")
    {
        if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.PVP_CAPTURE)
        {
            this.SpawnPlayerAt(id, this.checkpoint);
            return;
        }
        string str = tag;
        string str1 = str;
        this.myLastRespawnTag = str;
        this.SpawnPlayerAt(id, GameObject.FindGameObjectsWithTag(str1).RandomPick<GameObject>());
    }

    internal void SpawnPlayerAt(string id, GameObject pos)
    {
        Transform _transform = pos.transform;
        this.SpawnPlayerAt(id, _transform.position, _transform.rotation);
    }

    internal void SpawnPlayerAt(string id, Vector3 position, Quaternion rotation)
    {
        bool flag;/*
        if (!FengGameManagerMKII.logicLoaded || !FengGameManagerMKII.customLevelLoaded)
        {
            this.NOTSpawnPlayerRC(id);
            return;
        }*/
        if (this.racingSpawnPointSet)
        {
            position = this.racingSpawnPoint;
        }
        else if (FengGameManagerMKII.level.StartsWith("Custom"))
        {
            int rCteam = PhotonNetwork.player.RCteam;
            if (rCteam == 0)
            {
                List<Vector3> vector3s = new List<Vector3>();
                foreach (Vector3 vector3 in FengGameManagerMKII.playerSpawnsC)
                {
                    vector3s.Add(vector3);
                }
                foreach (Vector3 vector31 in FengGameManagerMKII.playerSpawnsM)
                {
                    vector3s.Add(vector31);
                }
                if (vector3s.Count > 0)
                {
                    position = vector3s.RandomPick<Vector3>();
                }
            }
            else if (rCteam == 1)
            {
                if (FengGameManagerMKII.playerSpawnsC.Count > 0)
                {
                    position = FengGameManagerMKII.playerSpawnsC.RandomPick<Vector3>();
                }
            }
            else if (rCteam == 2 && FengGameManagerMKII.playerSpawnsM.Count > 0)
            {
                position = FengGameManagerMKII.playerSpawnsM.RandomPick<Vector3>();
            }
        }
        this.myLastHero = id.ToUpper();
        if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
        {
            HERO component = IN_GAME_MAIN_CAMERA.mainCamera.setMainObject(PhotonNetwork.Instantiate("AOTTG_HERO 1", position, rotation, 0, null), true, false).GetComponent<HERO>();
            HERO_SETUP info = component.GetComponent<HERO_SETUP>();
            id = id.ToUpper();
            if (id == "SET 1" || id == "SET 2" || id == "SET 3")
            {
                HeroCostume heroCostume = CostumeConeveter.LocalDataToHeroCostume(id);
                heroCostume.checkstat();
                CostumeConeveter.HeroCostumeToLocalData(heroCostume, id);
                info.init();
                if (heroCostume == null)
                {
                    heroCostume = HeroCostume.costumeOption[3];
                    info.myCostume = heroCostume;
                    info.myCostume.stat = HeroStat.getInfo(heroCostume.name.ToUpper());
                }
                else
                {
                    info.myCostume = heroCostume;
                    info.myCostume.stat = heroCostume.stat;
                }
                info.setCharacterComponent();
                component.setStat();
                component.setSkillHUDPosition();
            }
            else if (!id.StartsWith("AHSS-"))
            {
                string upper = id.ToUpper();
                int num = 0;
                while (num < (int)HeroCostume.costume.Length)
                {
                    if (HeroCostume.costume[num].name.ToUpper() != upper)
                    {
                        num++;
                    }
                    else
                    {
                        int num1 = HeroCostume.costume[num].id;
                        if (upper != "AHSS")
                        {
                            num1 = num1 + (CheckBoxCostume.costumeSet - 1);
                        }
                        if (HeroCostume.costume[num1].name != HeroCostume.costume[num].name)
                        {
                            num1 = HeroCostume.costume[num].id + 1;
                        }
                        info.init();
                        info.myCostume = HeroCostume.costume[num1];
                        info.myCostume.stat = HeroStat.getInfo(HeroCostume.costume[num1].name.ToUpper());
                        info.setCharacterComponent();
                        //component.setStat();
                        component.setSkillHUDPosition();
                        break;
                    }
                }
            }
            else
            {
                info.myCostume = CostumeConeveter.HeroToAHSS(id);
                info.setCharacterComponent();
                component.setStat();
                info.myCostume.setMesh();
                info.myCostume.setTexture();
                component.setSkillHUDPosition();
            }
            CostumeConeveter.HeroCostumeToPhotonData(info.myCostume, PhotonNetwork.player);
            if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.PVP_CAPTURE)
            {
                Transform mainObjectT = IN_GAME_MAIN_CAMERA.main_objectT;
                mainObjectT.position = (mainObjectT.position + new Vector3((float)UnityEngine.Random.Range(-20, 20), 2f, (float)UnityEngine.Random.Range(-20, 20)));
            }
            PhotonPlayer photonPlayer = PhotonNetwork.player;
            ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
            hashtable.Add("dead", false);
            hashtable.Add("isTitan", 1);
            photonPlayer.SetCustomProperties(hashtable);
        }
        else if (IN_GAME_MAIN_CAMERA.singleCharacter == "TITAN_EREN")
        {
            IN_GAME_MAIN_CAMERA.mainCamera.setMainObject((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("TITAN_EREN"), position, rotation), true, false);
        }
        else if (!IN_GAME_MAIN_CAMERA.singleCharacter.StartsWith("AHSS-"))
        {
            HERO hERO = IN_GAME_MAIN_CAMERA.mainCamera.setMainObject((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("AOTTG_HERO 1"), position, rotation), true, false).GetComponent<HERO>();
            HERO_SETUP hEROSETUP = hERO.GetComponent<HERO_SETUP>();
            if (IN_GAME_MAIN_CAMERA.singleCharacter == "SET 1" || IN_GAME_MAIN_CAMERA.singleCharacter == "SET 2" || IN_GAME_MAIN_CAMERA.singleCharacter == "SET 3")
            {
                HeroCostume heroCostume1 = CostumeConeveter.LocalDataToHeroCostume(IN_GAME_MAIN_CAMERA.singleCharacter);
                heroCostume1.checkstat();
                CostumeConeveter.HeroCostumeToLocalData(heroCostume1, IN_GAME_MAIN_CAMERA.singleCharacter);
                hEROSETUP.init();
                if (heroCostume1 == null)
                {
                    heroCostume1 = HeroCostume.costumeOption[3];
                    hEROSETUP.myCostume = heroCostume1;
                    hEROSETUP.myCostume.stat = HeroStat.getInfo(heroCostume1.name.ToUpper());
                }
                else
                {
                    hEROSETUP.myCostume = heroCostume1;
                    hEROSETUP.myCostume.stat = heroCostume1.stat;
                }
                hEROSETUP.setCharacterComponent();
                hERO.setStat();
                hERO.setSkillHUDPosition();
            }
            else
            {
                string str = IN_GAME_MAIN_CAMERA.singleCharacter.ToUpper();
                int num2 = 0;
                while (num2 < (int)HeroCostume.costume.Length)
                {
                    if (HeroCostume.costume[num2].name.ToUpper() != str)
                    {
                        num2++;
                    }
                    else
                    {
                        int num3 = HeroCostume.costume[num2].id + CheckBoxCostume.costumeSet - 1;
                        if (HeroCostume.costume[num3].name != HeroCostume.costume[num2].name)
                        {
                            num3 = HeroCostume.costume[num2].id + 1;
                        }
                        hEROSETUP.init();
                        hEROSETUP.myCostume = HeroCostume.costume[num3];
                        hEROSETUP.myCostume.stat = HeroStat.getInfo(HeroCostume.costume[num3].name.ToUpper());
                        hEROSETUP.setCharacterComponent();
                        hERO.setStat();
                        hERO.setSkillHUDPosition();
                        this.isLosing = false;
                        IN_GAME_MAIN_CAMERA.mainCamera.setHUDposition();
                        IN_GAME_MAIN_CAMERA.mainCamera.enabled = (true);
                        IN_GAME_MAIN_CAMERA.mouselook.disable = true;
                        IN_GAME_MAIN_CAMERA.spectate.disable = true;
                        IN_GAME_MAIN_CAMERA.mainCamera.gameOver = false;
                        Screen.showCursor = (false);
                        flag = (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS);
                        Screen.lockCursor = (flag);
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
                        return;
                    }
                }
            }
        }
        else
        {
            HERO component1 = IN_GAME_MAIN_CAMERA.mainCamera.setMainObject((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("AOTTG_HERO 1"), position, rotation), true, false).GetComponent<HERO>();
            HERO_SETUP aHSS = component1.GetComponent<HERO_SETUP>();
            aHSS.myCostume = CostumeConeveter.HeroToAHSS(IN_GAME_MAIN_CAMERA.singleCharacter);
            aHSS.setCharacterComponent();
            component1.setStat();
            aHSS.myCostume.setMesh();
            aHSS.myCostume.setTexture();
            component1.setSkillHUDPosition();
        }
        this.isLosing = false;
        IN_GAME_MAIN_CAMERA.mainCamera.setHUDposition();
        IN_GAME_MAIN_CAMERA.mainCamera.enabled = (true);
        IN_GAME_MAIN_CAMERA.mouselook.disable = true;
        IN_GAME_MAIN_CAMERA.spectate.disable = true;
        IN_GAME_MAIN_CAMERA.mainCamera.gameOver = false;
        Screen.showCursor = (false);
        flag = (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS);
        Screen.lockCursor = (flag);
        FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
    }

    [RPC]
    public void spawnPlayerAtRPC(float posX, float posY, float posZ, PhotonMessageInfo info)
    {
        if (info.sender.isMasterClient && FengGameManagerMKII.logicLoaded && FengGameManagerMKII.customLevelLoaded && !this.needChooseSide && IN_GAME_MAIN_CAMERA.mainCamera.gameOver)
        {
            this.SpawnPlayerAt(this.myLastHero.ToUpper(), new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }

    private void spawnPlayerCustomMap()
    {
        if (!this.needChooseSide && IN_GAME_MAIN_CAMERA.mainCamera.gameOver)
        {
            IN_GAME_MAIN_CAMERA.mainCamera.gameOver = false;
            if (!PhotonNetwork.player.isTitan)
            {
                this.SpawnPlayer(this.myLastHero, (this.myLastRespawnTag.IsNullOrEmpty() ? "playerRespawn" : this.myLastRespawnTag));
            }
            else
            {
                this.SpawnNonAITitan(this.myLastHero, "titanRespawn");
            }
            FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
        }
    }

    private void spawnRandomFT(string place, int num)
    {
        Vector3 _position;
        Quaternion _rotation;
        GameObject gameObject;
        Transform _transform;
        if (num == -1)
        {
            num = 1;
        }
        if ((int)FengGameManagerMKII.settings[87] > 0)
        {
            if (!(bool)FengGameManagerMKII.settings[11])
            {
                num = (int)FengGameManagerMKII.settings[87];
            }
            else if (this.wave == 1)
            {
                num = (int)FengGameManagerMKII.settings[87];
            }
            else if (!(bool)FengGameManagerMKII.settings[24] && FengGameManagerMKII.fT.Count < (int)FengGameManagerMKII.settings[87])
            {
                FengGameManagerMKII.settings[24] = true;
                if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
                {
                    int num1 = 7 + this.wave + (int)FengGameManagerMKII.settings[87];
                    this.sendChatContentInfo(string.Concat("<color=#A8FF24><color=white><b>Respawning turned on.</b></color> Reach ", num1.ToString(), " titans to hit next wave.</color>"));
                }
            }
        }
        GameObject[] array = (
            from spawn in GameObject.FindGameObjectsWithTag(place)
            where spawn != null
            select spawn).ToArray<GameObject>();
        if (!FengGameManagerMKII.level.StartsWith("Custom"))
        {
            if ((int)array.Length > 0)
            {
                for (int i = 0; i < num; i++)
                {
                    int num2 = UnityEngine.Random.Range(0, (int)array.Length);
                    gameObject = array[num2];
                    while (array[num2] == null)
                    {
                        num2 = UnityEngine.Random.Range(0, (int)array.Length);
                        gameObject = array[num2];
                    }
                    array[num2] = null;
                    _position = gameObject.transform.position;
                    _rotation = gameObject.transform.rotation;
                    if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
                    {
                        _transform = PhotonNetwork.Instantiate("FEMALE_TITAN", _position, _rotation, 0, null).transform;
                        Transform transform = PhotonNetwork.Instantiate("FX/Thunder", _transform.position, Quaternion.Euler(270f, 0f, 0f), 0, null).transform;
                        Transform _transform1 = PhotonNetwork.Instantiate("FX/FXtitanDie", _transform.position, Quaternion.Euler(-90f, 0f, 0f), 0, null).transform;
                        Vector3 _localScale = _transform.localScale;
                        Vector3 vector3 = _localScale;
                        _transform1.localScale = (_localScale);
                        transform.localScale = (vector3);
                    }
                    else
                    {
                        _transform = ((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("FEMALE_TITAN"), _position, _rotation)).transform;
                        Transform transform1 = ((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("FX/Thunder"), _transform.position, Quaternion.Euler(270f, 0f, 0f))).transform;
                        Transform _transform2 = ((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("FX/FXtitanDie"), _transform.position, Quaternion.Euler(-90f, 0f, 0f))).transform;
                        Vector3 _localScale1 = _transform.localScale;
                        Vector3 vector31 = _localScale1;
                        _transform2.localScale = (_localScale1);
                        transform1.localScale = (vector31);
                    }
                }
            }
            return;
        }
        for (int j = 0; j < num; j++)
        {
            _position = new Vector3(UnityEngine.Random.Range(-400f, 400f), 0f, UnityEngine.Random.Range(-400f, 400f));
            _rotation = new Quaternion(0f, 0f, 0f, 1f);
            if (FengGameManagerMKII.titanSpawns.Count <= 0)
            {
                int num3 = UnityEngine.Random.Range(0, (int)array.Length);
                gameObject = array[num3];
                while (array[num3] == null)
                {
                    num3 = UnityEngine.Random.Range(0, (int)array.Length);
                    gameObject = array[num3];
                }
                array[num3] = null;
                _position = gameObject.transform.position;
                _rotation = gameObject.transform.rotation;
            }
            else
            {
                _position = FengGameManagerMKII.titanSpawns.RandomPick<Vector3>();
            }
            if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
            {
                _transform = PhotonNetwork.Instantiate("FEMALE_TITAN", _position, _rotation, 0, null).transform;
                Transform transform2 = PhotonNetwork.Instantiate("FX/Thunder", _transform.position, Quaternion.Euler(270f, 0f, 0f), 0, null).transform;
                Transform _transform3 = PhotonNetwork.Instantiate("FX/FXtitanDie", _transform.position, Quaternion.Euler(-90f, 0f, 0f), 0, null).transform;
                Vector3 _localScale2 = _transform.localScale;
                Vector3 vector32 = _localScale2;
                _transform3.localScale = (_localScale2);
                transform2.localScale = (vector32);
            }
            else
            {
                _transform = ((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("FEMALE_TITAN"), _position, _rotation)).transform;
                Transform transform3 = ((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("FX/Thunder"), _position, Quaternion.Euler(270f, 0f, 0f))).transform;
                Transform _transform4 = ((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("FX/FXtitanDie"), _position, Quaternion.Euler(-90f, 0f, 0f))).transform;
                Vector3 _localScale3 = _transform.localScale;
                Vector3 vector33 = _localScale3;
                _transform4.localScale = (_localScale3);
                transform3.localScale = (vector33);
            }
        }
    }

    internal TITAN spawnTitan(int rate, Vector3 position, Quaternion rotation, bool punk = false)
    {
        TITAN tITAN = this.spawnTitanRaw(position, rotation);
        if (punk)
        {
            tITAN.setAbnormalType(AbnormalType.TYPE_PUNK, false);
        }
        else if (UnityEngine.Random.Range(0, 100) < rate)
        {
            if (IN_GAME_MAIN_CAMERA.difficulty == 2)
            {
                if (UnityEngine.Random.Range(0f, 1f) < 0.7f || FengGameManagerMKII.levelinfo.noCrawler || (bool)FengGameManagerMKII.settings[1])
                {
                    tITAN.setAbnormalType(AbnormalType.TYPE_JUMPER, false);
                }
                else
                {
                    tITAN.setAbnormalType(AbnormalType.TYPE_CRAWLER, false);
                }
            }
        }
        else if (IN_GAME_MAIN_CAMERA.difficulty == 2)
        {
            if (UnityEngine.Random.Range(0f, 1f) < 0.7f || FengGameManagerMKII.levelinfo.noCrawler || (bool)FengGameManagerMKII.settings[1])
            {
                tITAN.setAbnormalType(AbnormalType.TYPE_JUMPER, false);
            }
            else
            {
                tITAN.setAbnormalType(AbnormalType.TYPE_CRAWLER, false);
            }
        }
        else if (UnityEngine.Random.Range(0, 100) < rate)
        {
            if (UnityEngine.Random.Range(0f, 1f) < 0.8f || FengGameManagerMKII.levelinfo.noCrawler || (bool)FengGameManagerMKII.settings[1])
            {
                tITAN.setAbnormalType(AbnormalType.TYPE_I, false);
            }
            else
            {
                tITAN.setAbnormalType(AbnormalType.TYPE_CRAWLER, false);
            }
        }
        else if (UnityEngine.Random.Range(0f, 1f) < 0.8f || FengGameManagerMKII.levelinfo.noCrawler || (bool)FengGameManagerMKII.settings[1])
        {
            tITAN.setAbnormalType(AbnormalType.TYPE_JUMPER, false);
        }
        else
        {
            tITAN.setAbnormalType(AbnormalType.TYPE_CRAWLER, false);
        }
        Vector3 _localScale = tITAN.transform.localScale;
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
        {
            if (!(bool)FengGameManagerMKII.settings[10])
            {
                ((Transform)UnityEngine.Object.Instantiate(CacheResources.Load<Transform>("FX/FXtitanSpawn"), position, Quaternion.Euler(-90f, 0f, 0f))).localScale = (_localScale);
            }
            else
            {
                ((Transform)UnityEngine.Object.Instantiate(CacheResources.Load<Transform>("FX/Thunder"), position, Quaternion.Euler(270f, 0f, 0f))).localScale = (_localScale);
                ((Transform)UnityEngine.Object.Instantiate(CacheResources.Load<Transform>("FX/FXtitanDie"), position, Quaternion.Euler(-90f, 0f, 0f))).localScale = (_localScale);
            }
        }
        else if (!(bool)FengGameManagerMKII.settings[10])
        {
            PhotonNetwork.Instantiate<Transform>("FX/FXtitanSpawn", position, Quaternion.Euler(-90f, 0f, 0f), 0, null).localScale = (_localScale);
        }
        else
        {
            PhotonNetwork.Instantiate<Transform>("FX/Thunder", position, Quaternion.Euler(270f, 0f, 0f), 0, null).localScale = (_localScale);
            PhotonNetwork.Instantiate<Transform>("FX/FXtitanDie", position, Quaternion.Euler(-90f, 0f, 0f), 0, null).localScale = (_localScale);
        }
        return tITAN;
    }

    public void spawnTitanAction(int type, float size, int health, int number)
    {
        this.spawnTitanAtAction(type, size, health, number, UnityEngine.Random.Range(-400f, 400f), 0f, UnityEngine.Random.Range(-400f, 400f));
    }

    public void spawnTitanAtAction(int type, float size, int health, int number, float posX, float posY, float posZ)
    {
        Vector3 vector3 = new Vector3(posX, posY, posZ);
        Quaternion quaternion = new Quaternion(0f, 0f, 0f, 1f);
        if (FengGameManagerMKII.titanSpawns.Count <= 0)
        {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("titanRespawn");
            if ((int)gameObjectArray.Length > 0)
            {
                int num = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
                GameObject gameObject = gameObjectArray[num];
                while (gameObjectArray[num] == null)
                {
                    num = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
                    gameObject = gameObjectArray[num];
                }
                gameObjectArray[num] = null;
                Transform _transform = gameObject.transform;
                vector3 = _transform.position;
                quaternion = _transform.rotation;
            }
        }
        else
        {
            vector3 = FengGameManagerMKII.titanSpawns[UnityEngine.Random.Range(0, FengGameManagerMKII.titanSpawns.Count)];
        }
        for (int i = 0; i < number; i++)
        {
            TITAN tITAN = this.spawnTitanRaw(vector3, quaternion);
            TITAN tITAN1 = tITAN;
            tITAN.resetLevel(size);
            tITAN1.hasSetLevel = true;
            if (health > 0)
            {
                tITAN1.currentHealth = health;
                tITAN1.maxHealth = health;
            }
            switch (type)
            {
                case 0:
                    {
                        tITAN1.setAbnormalType(AbnormalType.NORMAL, false);
                        break;
                    }
                case 1:
                    {
                        tITAN1.setAbnormalType(AbnormalType.TYPE_I, false);
                        break;
                    }
                case 2:
                    {
                        tITAN1.setAbnormalType(AbnormalType.TYPE_JUMPER, false);
                        break;
                    }
                case 3:
                    {
                        tITAN1.setAbnormalType(AbnormalType.TYPE_CRAWLER, true);
                        break;
                    }
                case 4:
                    {
                        tITAN1.setAbnormalType(AbnormalType.TYPE_PUNK, false);
                        break;
                    }
                default:
                    {
                        goto case 2;
                    }
            }
        }
    }

    public void spawnTitanCustom(string type, int abnormal, int rate, bool punk)
    {
        int j;
        GameObject gameObject;
        Vector3 vector3;
        Quaternion quaternion;
        GameObject[] gameObjectArray;
        int num;
        if ((int)FengGameManagerMKII.settings[87] > 0 && !(bool)FengGameManagerMKII.settings[11])
        {
            rate = (int)FengGameManagerMKII.settings[87];
        }
        int num1 = rate;
        if (FengGameManagerMKII.level.StartsWith("Custom"))
        {
            num1 = 5;
            if (RCSettings.gameType == 1)
            {
                num1 = 3;
            }
            else if (RCSettings.gameType == 2 || RCSettings.gameType == 3)
            {
                num1 = 0;
            }
        }
        if (RCSettings.moreTitans > 0 || RCSettings.moreTitans == 0 && FengGameManagerMKII.level.StartsWith("Custom") && RCSettings.gameType >= 2)
        {
            num1 = RCSettings.moreTitans;
        }
        if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.SURVIVE_MODE)
        {
            if (punk)
            {
                num1 = rate;
            }
            else if (RCSettings.moreTitans == 0)
            {
                num = 1;
                if (RCSettings.waveModeOn == 1)
                {
                    num = RCSettings.waveModeNum;
                }
                num1 = num1 + (this.wave - 1) * (num - 1);
            }
            else if (RCSettings.moreTitans > 0)
            {
                num = 1;
                if (RCSettings.waveModeOn == 1)
                {
                    num = RCSettings.waveModeNum;
                }
                num1 = num1 + (this.wave - 1) * num;
            }
        }
        num1 = Math.Min(50, num1);
        if (RCSettings.spawnMode != 1)
        {
            if (!FengGameManagerMKII.level.StartsWith("Custom"))
            {
                this.randomSpawnTitan("titanRespawn", abnormal, rate, punk);
                return;
            }
            for (int i = 0; i < rate; i++)
            {
                vector3 = new Vector3(UnityEngine.Random.Range(-400f, 400f), 0f, UnityEngine.Random.Range(-400f, 400f));
                quaternion = new Quaternion(0f, 0f, 0f, 1f);
                if (FengGameManagerMKII.titanSpawns.Count <= 0)
                {
                    gameObjectArray = GameObject.FindGameObjectsWithTag("titanRespawn");
                    if ((int)gameObjectArray.Length > 0)
                    {
                        j = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
                        gameObject = gameObjectArray[j];
                        while (gameObjectArray[j] == null)
                        {
                            j = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
                            gameObject = gameObjectArray[j];
                        }
                        gameObjectArray[j] = null;
                        Transform _transform = gameObject.transform;
                        vector3 = _transform.position;
                        quaternion = _transform.rotation;
                    }
                }
                else
                {
                    vector3 = FengGameManagerMKII.titanSpawns[UnityEngine.Random.Range(0, FengGameManagerMKII.titanSpawns.Count)];
                }
                this.spawnTitan(abnormal, vector3, quaternion, punk);
            }
            return;
        }
        float single = RCSettings.nRate;
        float single1 = RCSettings.aRate;
        float single2 = RCSettings.jRate;
        float single3 = RCSettings.cRate;
        float single4 = RCSettings.pRate;
        if (punk && RCSettings.punkWaves == 1)
        {
            single = 0f;
            single1 = 0f;
            single2 = 0f;
            single3 = 0f;
            single4 = 100f;
            num1 = rate;
        }
        for (j = 0; j < num1; j++)
        {
            vector3 = new Vector3(UnityEngine.Random.Range(-400f, 400f), 0f, UnityEngine.Random.Range(-400f, 400f));
            quaternion = new Quaternion(0f, 0f, 0f, 1f);
            if (FengGameManagerMKII.titanSpawns.Count <= 0)
            {
                gameObjectArray = GameObject.FindGameObjectsWithTag("titanRespawn");
                if ((int)gameObjectArray.Length > 0)
                {
                    j = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
                    gameObject = gameObjectArray[j];
                    while (gameObjectArray[j] == null)
                    {
                        j = UnityEngine.Random.Range(0, (int)gameObjectArray.Length);
                        gameObject = gameObjectArray[j];
                    }
                    gameObjectArray[j] = null;
                    vector3 = gameObject.transform.position;
                    quaternion = gameObject.transform.rotation;
                }
            }
            else
            {
                vector3 = FengGameManagerMKII.titanSpawns[UnityEngine.Random.Range(0, FengGameManagerMKII.titanSpawns.Count)];
            }
            float single5 = UnityEngine.Random.Range(0f, 100f);
            if (single5 > single + single1 + single2 + single3 + single4)
            {
                this.spawnTitan(abnormal, vector3, quaternion, punk);
            }
            else
            {
                TITAN tITAN = this.spawnTitanRaw(vector3, quaternion);
                if (single5 < single)
                {
                    tITAN.setAbnormalType(AbnormalType.NORMAL, false);
                }
                else if (single5 >= single && single5 < single + single1)
                {
                    tITAN.setAbnormalType(AbnormalType.TYPE_I, false);
                }
                else if (single5 >= single + single1 && single5 < single + single1 + single2)
                {
                    tITAN.setAbnormalType(AbnormalType.TYPE_JUMPER, false);
                }
                else if (single5 >= single + single1 + single2 && single5 < single + single1 + single2 + single3)
                {
                    tITAN.setAbnormalType(AbnormalType.TYPE_CRAWLER, true);
                }
                else if (single5 < single + single1 + single2 + single3 || single5 >= single + single1 + single2 + single3 + single4)
                {
                    tITAN.setAbnormalType(AbnormalType.NORMAL, false);
                }
                else
                {
                    tITAN.setAbnormalType(AbnormalType.TYPE_PUNK, false);
                }
            }
        }
    }

    private TITAN spawnTitanRaw(Vector3 position, Quaternion rotation)
    {
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
        {
            return ((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("TITAN_VER3.1"), position, rotation)).AddComponent<TitanUpgrade>().GetComponent<TITAN>();
        }
        return PhotonNetwork.Instantiate("TITAN_VER3.1", position, rotation, 0, null).AddComponent<TitanUpgrade>().GetComponent<TITAN>();
    }

    [RPC]
    private void spawnTitanRPC(PhotonMessageInfo info)
    {
        if (info.sender.isMasterClient)
        {
            foreach (TITAN titan in FengGameManagerMKII.titans)
            {
                if (!titan.photonView.isMine || PhotonNetwork.isMasterClient && !titan.nonAI)
                {
                    continue;
                }
                PhotonNetwork.Destroy(titan.gameObject, false);
            }
            this.SpawnNonAITitan(this.myLastHero, "titanRespawn");
        }
    }

    internal void CheckIfCloned()
    {
        if (PhotonNetwork.connectionStateDetailed == PeerStates.Joined && !FengGameManagerMKII.restarting && !PhotonNetwork.networkingPeer.loadingLevelAndPausedNetwork)
        {
            base.Invoke("CloneCheck", 1f);
        }
    }

    private void CloneCheck()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < (int)gameObjectArray.Length; i++)
        {
            GameObject gameObject = gameObjectArray[i];
            if (!(gameObject == null) && gameObject.GetComponent<PhotonView>().ownerId == PhotonNetwork.player.ID && (IN_GAME_MAIN_CAMERA.mainCamera.gameOver || gameObject != IN_GAME_MAIN_CAMERA.main_object))
            {
                PhotonNetwork.Destroy(gameObject, false);
            }
        }
    }

    private void startFilter(bool start)
    {
        if (start)
        {
            if (!this.filtering)
            {
                this.filtering = true;
                base.StartCoroutine(this.filter());
                return;
            }
        }
        else if (this.filtering)
        {
            this.filtering = false;
            base.StopCoroutine(this.filter());
        }
    }

    public static void EncodeAnimation(string animation = null)
    {
        Match match;
        Regex regex;
        int num;
        float single;
        float single1;
        float single2;
        float single3;
        if (animation.IsNullOrEmpty())
        {
            return;
        }
        FengGameManagerMKII.GrabHexes();
        if (animation.StartsWith("Faded"))
        {
            regex = new Regex("\\[\\d+\\]spd=\\d+(\\d+|\\.\\d+)?");
            if (regex.IsMatch(animation))
            {
                MatchCollection matchCollection = regex.Matches(animation);
                FengGameManagerMKII.fadedSpeed.Clear();
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    string value = matchCollection[i].Value;
                    int num1 = value.IndexOf("[") + 1;
                    if (int.TryParse(value.Substring(num1, value.IndexOf("]") - num1).Trim(), out num))
                    {
                        string str = value.Substring(value.IndexOf("spd=") + 4).Trim();
                        if (float.TryParse(str, out single))
                        {
                            if (!FengGameManagerMKII.fadedSpeed.ContainsKey(num))
                            {
                                FengGameManagerMKII.fadedSpeed.Add(num, str);
                            }
                            else
                            {
                                FengGameManagerMKII.fadedSpeed[num] = str;
                            }
                        }
                    }
                }
                return;
            }
        }
        else if (animation.StartsWith("Linear"))
        {
            regex = new Regex("spd=\\d+(\\d+|\\.\\d+)?");
            if (regex.IsMatch(animation))
            {
                match = regex.Match(animation);
                string str1 = match.Value.Substring(match.Value.IndexOf("spd=") + 4).Trim();
                if (float.TryParse(str1, out single1))
                {
                    FengGameManagerMKII.linearSpeed = str1;
                    return;
                }
            }
        }
        else if (animation.StartsWith("Rebound"))
        {
            regex = new Regex("\\[fwd\\]spd=\\d+(\\d+|\\.\\d+)?");
            if (regex.IsMatch(animation))
            {
                match = regex.Match(animation);
                string str2 = match.Value.Substring(match.Value.IndexOf("spd=") + 4).Trim();
                if (float.TryParse(str2, out single2))
                {
                    FengGameManagerMKII.reboundSpeed["fwd"] = str2;
                }
            }
            regex = new Regex("\\[back\\]spd=\\d+(\\d+|\\.\\d+)?");
            if (regex.IsMatch(animation))
            {
                match = regex.Match(animation);
                string str3 = match.Value.Substring(match.Value.IndexOf("spd=") + 4).Trim();
                if (float.TryParse(str3, out single3))
                {
                    FengGameManagerMKII.reboundSpeed["back"] = str3;
                }
            }
        }
    }

    private void endGameInfectionRC()
    {
        int i;
        FengGameManagerMKII.imatitan.Clear();
        for (i = 0; i < (int)PhotonNetwork.playerList.Length; i++)
        {
            PhotonPlayer photonPlayer = PhotonNetwork.playerList[i];
            ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
            hashtable.Add("isTitan", 1);
            photonPlayer.SetCustomProperties(hashtable);
        }
        int length = (int)PhotonNetwork.playerList.Length;
        int num = RCSettings.infectionMode;
        for (i = 0; i < (int)PhotonNetwork.playerList.Length; i++)
        {
            PhotonPlayer photonPlayer1 = PhotonNetwork.playerList[i];
            if (length > 0 && UnityEngine.Random.Range(0f, 1f) <= (float)(num / length))
            {
                ExitGames.Client.Photon.Hashtable hashtable1 = new ExitGames.Client.Photon.Hashtable();
                hashtable1.Add("isTitan", 2);
                photonPlayer1.SetCustomProperties(hashtable1);
                FengGameManagerMKII.imatitan.Add(photonPlayer1.ID, 2);
                num--;
            }
            length--;
        }
        this.gameEndCD = 0f;
        this.restartGame(false);
    }

    private void endGameRC()
    {
        if (RCSettings.pointMode > 0)
        {
            for (int i = 0; i < (int)PhotonNetwork.playerList.Length; i++)
            {
                PhotonPlayer photonPlayer = PhotonNetwork.playerList[i];
                ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                hashtable.Add("kills", 0);
                hashtable.Add("deaths", 0);
                hashtable.Add("max_dmg", 0);
                hashtable.Add("total_dmg", 0);
                photonPlayer.SetCustomProperties(hashtable);
            }
        }
        this.gameEndCD = 0f;
        this.restartGame(false);
    }

    public void ExportRenderers()
    {
        string empty = string.Empty;
        GameObject[] gameObjectArray = UnityEngine.Object.FindObjectsOfType<GameObject>();
        for (int i = 0; i < (int)gameObjectArray.Length; i++)
        {
            Renderer[] componentsInChildren = gameObjectArray[i].GetComponentsInChildren<Renderer>();
            for (int j = 0; j < (int)componentsInChildren.Length; j++)
            {
                Renderer renderer = componentsInChildren[j];
                if (!empty.Contains(string.Concat("|", renderer.name)))
                {
                    empty = string.Concat(empty, "|", renderer.name);
                }
            }
        }
        string str = string.Concat(Application.dataPath, "/../rend.txt");
        char[] chrArray = new char[] { '|' };
        File.WriteAllLines(str, empty.Split(chrArray));
    }

    private IEnumerator filter()
    {
        while (this.filtering)
        {
            yield return new WaitForSeconds(5f);
            yield return new WaitForEndOfFrame();
            if (PhotonNetwork.isMasterClient)
            {
                if ((bool)FengGameManagerMKII.settings[11])
                {
                    if ((bool)FengGameManagerMKII.settings[16])
                    {
                        if (FengGameManagerMKII.fT.Count < 2 || FengGameManagerMKII.fT.Count > 8 + this.wave)
                        {
                            this.oneTitanDown("Titan", false);
                        }
                    }
                    else if (FengGameManagerMKII.titans.Count < 2 || FengGameManagerMKII.titans.Count > 8 + this.wave)
                    {
                        this.oneTitanDown("Titan", false);
                    }
                }
                else if ((bool)FengGameManagerMKII.settings[16])
                {
                    if (FengGameManagerMKII.fT.Count <= 0)
                    {
                        this.oneTitanDown("Titan", false);
                    }
                }
                else if (FengGameManagerMKII.titans.Count <= 0)
                {
                    this.oneTitanDown("Titan", false);
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }

    internal bool gameLose(bool humanDied = false)
    {
        if (this.isWinning || this.isLosing)
        {
            return false;
        }
        if (humanDied && FengGameManagerMKII.settingsGame[24] > 0)
        {
            return true;
        }
        this.isLosing = true;
        FengGameManagerMKII fengGameManagerMKII = this;
        fengGameManagerMKII.titanScore = fengGameManagerMKII.titanScore + 1;
        this.gameEndCD = this.gameEndTotalCDtime;
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
        {
            FengGameManagerMKII.PView.RPC("netGameLose", PhotonTargets.Others, this.titanScore);
            if ((int)FengGameManagerMKII.settingsRC[244] == 1)
            {
                InRoomChat.addLINE(string.Concat("<color=#FFC000>(", FengGameManagerMKII.roundTime.ToString("F2"), ")</color> Round ended (game lose)."), null, false, true);
            }
        }
        return true;
    }

    public static void GrabHexes()
    {
        FengGameManagerMKII.hexcodes.Clear();
        string str = LoginFengKAI.player.name;
        if (!str.IsNullOrEmpty() && FengGameManagerMKII.regexHex.IsMatch(str))
        {
            MatchCollection matchCollection = FengGameManagerMKII.regexHex.Matches(str);
            for (int i = 0; i < matchCollection.Count; i++)
            {
                if (str.HasHexAt(matchCollection[i].Index))
                {
                    FengGameManagerMKII.hexcodes.Add(matchCollection[i].Value);
                }
            }
        }
        FengGameManagerMKII.uiname = LoginFengKAI.player.name;
    }

    public void GamemodesActivation(bool isHuman)
    {
        if (isHuman)
        {
            //string str = LoginFengKAI.Get("hgamemode", "hgamemodes");
            string str = "tsetet";
            if (!str.IsNullOrEmpty())
            {
                FengGameManagerMKII.settings[101] = str;
                Gamemodes.ActivateAll(str, true);
                return;
            }
            str = (string)FengGameManagerMKII.settings[101];
            if (!str.IsNullOrEmpty())
            {
                Gamemodes.ActivateAll(str, true);
            }
            return;
        }
        //string str1 = LoginFengKAI.Get("tgamemode", "tgamemodes");
        string str1 = "tsetet1";
        if (!str1.IsNullOrEmpty())
        {
            FengGameManagerMKII.settings[102] = str1;
            Gamemodes.ActivateAll(str1, false);
            return;
        }
        str1 = (string)FengGameManagerMKII.settings[102];
        if (!str1.IsNullOrEmpty())
        {
            Gamemodes.ActivateAll(str1, false);
        }
    }

    internal bool gameWin(bool humanDied = false)
    {
        if (this.isLosing || this.isWinning)
        {
            return false;
        }
        if (humanDied && FengGameManagerMKII.settingsGame[24] > 0)
        {
            return true;
        }
        this.isWinning = true;
        FengGameManagerMKII fengGameManagerMKII = this;
        fengGameManagerMKII.humanScore = fengGameManagerMKII.humanScore + 1;
        if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.RACING)
        {
            this.gameEndCD = (RCSettings.racingStatic == 1 ? 1000f : 20f);
            if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
            {
                FengGameManagerMKII.PView.RPC("netGameWin", PhotonTargets.Others, 0);
                if ((int)FengGameManagerMKII.settingsRC[244] == 1)
                {
                    InRoomChat.addLINE(string.Concat("<color=#FFC000>(", FengGameManagerMKII.roundTime.ToString("F2"), ")</color> Round ended (game win)."), null, false, true);
                }
            }
            return true;
        }
        if (IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.PVP_AHSS)
        {
            this.gameEndCD = this.gameEndTotalCDtime;
            if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
            {
                FengGameManagerMKII.PView.RPC("netGameWin", PhotonTargets.Others, this.humanScore);
                if ((int)FengGameManagerMKII.settingsRC[244] == 1)
                {
                    InRoomChat.addLINE(string.Concat("<color=#FFC000>(", FengGameManagerMKII.roundTime.ToString("F2"), ")</color> Round ended (game win)."), null, false, true);
                }
            }
            return true;
        }
        this.gameEndCD = this.gameEndTotalCDtime;
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
        {
            FengGameManagerMKII.PView.RPC("netGameWin", PhotonTargets.Others, this.teamWinner);
            if ((int)FengGameManagerMKII.settingsRC[244] == 1)
            {
                InRoomChat.addLINE(string.Concat("<color=#FFC000>(", FengGameManagerMKII.roundTime.ToString("F2"), ")</color> Round ended (game win)."), null, false, true);
            }
        }
        this.teamScores[this.teamWinner - 1] = this.teamScores[this.teamWinner - 1] + 1;
        return true;
    }

    public static void Encapsulate(GameObject obj, Components component)
    {
        Bounds levelBounds = FengGameManagerMKII.LevelBounds;
        FengGameManagerMKII.Encapsulate(obj, obj.transform, component);
    }

    public static void Encapsulate(GameObject obj, Transform form, Components component)
    {
        Component component1;
        Bounds levelBounds = FengGameManagerMKII.LevelBounds;
        if ((component & Components.ConstantForceInParent) != Components.None && form)
        {
            FengGameManagerMKII.LevelBounds.Encapsulate(form.position);
            FengGameManagerMKII.LevelBounds.Encapsulate(form.position + form.localScale);
        }
        if ((component & Components.GUIElementInParent) != Components.None)
        {
            Collider _collider = obj.collider;
            component1 = _collider;
            if (_collider)
            {
                FengGameManagerMKII.LevelBounds.Encapsulate(((Collider)component1).bounds);
            }
        }
        if ((component & Components.AudioSourceInParent) != Components.None)
        {
            Renderer _renderer = obj.renderer;
            component1 = _renderer;
            if (_renderer)
            {
                FengGameManagerMKII.LevelBounds.Encapsulate(((Renderer)component1).bounds);
            }
        }
        if ((component & Components.GUITextInParent) != Components.None)
        {
            MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
            component1 = meshFilter;
            if (meshFilter)
            {
                Mesh _mesh = ((MeshFilter)component1).mesh;
                Mesh mesh = _mesh;
                if (_mesh != null)
                {
                    FengGameManagerMKII.LevelBounds.Encapsulate(mesh.bounds);
                }
            }
        }
        if ((component & Components.AnimationInParents) != Components.None)
        {
            Transform[] componentsInChildren = obj.GetComponentsInChildren<Transform>();
            for (int i = 0; i < (int)componentsInChildren.Length; i++)
            {
                Transform transform = componentsInChildren[i];
                if (transform != null)
                {
                    FengGameManagerMKII.LevelBounds.Encapsulate(transform.position);
                }
            }
        }
        if ((component & Components.GUIText) != Components.None)
        {
            Collider[] colliderArray = obj.GetComponentsInChildren<Collider>();
            for (int j = 0; j < (int)colliderArray.Length; j++)
            {
                Collider collider = colliderArray[j];
                if (collider != null)
                {
                    FengGameManagerMKII.LevelBounds.Encapsulate(collider.bounds);
                }
            }
        }
        if ((component & Components.Camera) != Components.None)
        {
            Renderer[] rendererArray = obj.GetComponentsInChildren<Renderer>();
            for (int k = 0; k < (int)rendererArray.Length; k++)
            {
                Renderer renderer = rendererArray[k];
                if (renderer != null)
                {
                    FengGameManagerMKII.LevelBounds.Encapsulate(renderer.bounds);
                }
            }
        }
        if ((component & Components.AnimationInParents) != Components.None)
        {
            MeshFilter[] meshFilterArray = obj.GetComponentsInChildren<MeshFilter>();
            for (int l = 0; l < (int)meshFilterArray.Length; l++)
            {
                MeshFilter meshFilter1 = meshFilterArray[l];
                if (!(meshFilter1 == null) && !(meshFilter1.mesh == null))
                {
                    FengGameManagerMKII.LevelBounds.Encapsulate(meshFilter1.mesh.bounds);
                }
            }
        }
    }

    public void unloadAssets()
    {
        if (!this.isUnloading)
        {
            this.isUnloading = true;
            base.StartCoroutine(this.unloadAssetsE(10f));
        }
    }

    public IEnumerator unloadAssetsE(float time)
    {
        yield return new WaitForSeconds(time);
        Resources.UnloadUnusedAssets();
        this.isUnloading = false;
    }

    public void unloadAssetsEditor()
    {
        if (!this.isUnloading)
        {
            this.isUnloading = true;
            base.StartCoroutine(this.unloadAssetsE(30f));
        }
    }

    internal static void removeTitan(TITAN titan, GameObject GO)
    {
        FengGameManagerMKII.titans.Remove(titan);
        if (titan.isLocal)
        {
            FengGameManagerMKII.localTitans.Remove(titan);
        }
        FengGameManagerMKII.alltitans.Remove(GO);
    }

    internal void removeTitanUP(TitanUpgrade upgrade)
    {
        FengGameManagerMKII.TUpgrade.Remove(upgrade);
    }

    private void Animate(string type, out int place)
    {
        place = 0;/*
        string str = FengGameManagerMKII.uiname;
        if (type == "Faded")
        {
            if (!this.rewind)
            {
                FengGameManagerMKII fengGameManagerMKII = this;
                fengGameManagerMKII.placeFade = fengGameManagerMKII.placeFade + 1;
                if (this.placeFade >= FengGameManagerMKII.hexcodes.Count)
                {
                    this.rewind = true;
                    FengGameManagerMKII fengGameManagerMKII1 = this;
                    fengGameManagerMKII1.placeFade = fengGameManagerMKII1.placeFade - 1;
                }
            }
            else
            {
                FengGameManagerMKII fengGameManagerMKII2 = this;
                fengGameManagerMKII2.placeFade = fengGameManagerMKII2.placeFade - 1;
                if (this.placeFade < 0)
                {
                    this.rewind = false;
                    FengGameManagerMKII fengGameManagerMKII3 = this;
                    fengGameManagerMKII3.placeFade = fengGameManagerMKII3.placeFade + 1;
                }
            }
            place = this.placeFade;
            str = str.StripHex();
            str = string.Concat(FengGameManagerMKII.hexcodes[this.placeFade], str, "[-]");
        }
        else if (type == "Rebound")
        {
            int num = 0;
            MatchCollection matchCollection = FengGameManagerMKII.regexHex.Matches(str);
            for (int i = 0; i < matchCollection.Count; i++)
            {
                if (this.rewind)
                {
                    num = (i < matchCollection.Count - 1 ? i + 1 : 0);
                }
                else
                {
                    num = (i > 0 ? i - 1 : matchCollection.Count - 1);
                }
                str = str.Remove(matchCollection.get_Item(i).get_Index(), 8);
                str = str.Insert(matchCollection.get_Item(i).get_Index(), matchCollection.get_Item(num).Value);
            }
        }
        else if (type == "Linear")
        {
            int num1 = 0;
            MatchCollection matchCollection1 = FengGameManagerMKII.regexHex.Matches(str);
            for (int j = 0; j < matchCollection1.Count; j++)
            {
                num1 = (j > 0 ? j - 1 : matchCollection1.Count - 1);
                str = str.Remove(matchCollection1.get_Item(j).get_Index(), 8);
                str = str.Insert(matchCollection1.get_Item(j).get_Index(), matchCollection1.get_Item(num1).Value);
            }
        }
        FengGameManagerMKII.uiname = str;*/
    }

    private void Awake()
    {
            UnityEngine.Object.DontDestroyOnLoad(FengGameManagerMKII.GUICtrl);
        
        FengGameManagerMKII.RSAssets = null;
        FengGameManagerMKII.LevelBounds = new Bounds(Vector3.zero, Vector3.one);
        FengGameManagerMKII.logicLoaded = false;
        FengGameManagerMKII.customLevelLoaded = false;
        FengGameManagerMKII.isFirstLoad = false;
        FengGameManagerMKII.groundList = new List<GameObject>();
        FengGameManagerMKII.updateTime = 0f;
        FengGameManagerMKII.currentLevel = string.Empty;
        FengGameManagerMKII.currentScript = string.Empty;
        FengGameManagerMKII.oldScript = string.Empty;
        FengGameManagerMKII.oldScriptLogic = string.Empty;
        FengGameManagerMKII.currentScriptLogic = string.Empty;
        FengGameManagerMKII.imatitan = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.heroHash = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.RCEvents = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.RCRegions = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.RCRegionTriggers = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.RCVariableNames = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.intVariables = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.boolVariables = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.stringVariables = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.floatVariables = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.playerVariables = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.titanVariables = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.globalVariables = new ExitGames.Client.Photon.Hashtable();
        FengGameManagerMKII.customObjects = new Queue<GameObject>();
        FengGameManagerMKII.BoundsDisabled = false;
        Dictionary<int, string> nums = new Dictionary<int, string>()
        {
            { 0, "[000000][[cfcfcf]LIST OF OBJECTS[-]][-]\nOwnerID:Name:Tag:ViewID\n" }
        };
        FengGameManagerMKII.TUpgrade = new List<TitanUpgrade>();
        FengGameManagerMKII.timeTillReplaced = 0f;
        FengGameManagerMKII.fadedSpeed = new Dictionary<int, string>();
        FengGameManagerMKII.fadedSpeedTest = new Dictionary<int, string>();
        FengGameManagerMKII.linearSpeed = "0.09";
        FengGameManagerMKII.linearSpeedTest = "0.09";
        Dictionary<string, string> strs = new Dictionary<string, string>(2)
        {
            { "fwd", "0.09" },
            { "back", "0.09" }
        };
        FengGameManagerMKII.reboundSpeed = strs;
        Dictionary<string, string> strs1 = new Dictionary<string, string>(2)
        {
            { "fwd", "0.09" },
            { "back", "0.09" }
        };
        FengGameManagerMKII.reboundSpeedTest = strs1;
        FengGameManagerMKII.animHexSelected = 0;
        FengGameManagerMKII.animSpeed = "0.09";
        FengGameManagerMKII.skyname = string.Empty;
        FengGameManagerMKII.afkcount = false;
        FengGameManagerMKII.linkHash = new ExitGames.Client.Photon.Hashtable[9];
        FengGameManagerMKII.mapScript = string.Empty;
        FengGameManagerMKII.playerSpawns = new List<Vector3>();
        FengGameManagerMKII.playerSpawnsC = new List<Vector3>();
        FengGameManagerMKII.playerSpawnsM = new List<Vector3>();
        FengGameManagerMKII.titanSpawners = new List<TitanSpawner>();
        FengGameManagerMKII.titanSpawnersCopy = new List<TitanSpawner>();
        FengGameManagerMKII.titanSpawns = new List<Vector3>();
        FengGameManagerMKII.playersRPC = new List<PhotonPlayer>();
        FengGameManagerMKII.levelCache = new List<string[]>();
        FengGameManagerMKII.hexcodes = new List<string>();
        FengGameManagerMKII.regexHex = new Regex("\\[([a-fA-F0-9]{6})\\]");
        FengGameManagerMKII.uiname = string.Empty;
        FengGameManagerMKII.alltitans = new List<GameObject>();
        FengGameManagerMKII.allheroes = new List<GameObject>();
        FengGameManagerMKII.localHeroes = new List<HERO>();
        FengGameManagerMKII.localTitans = new List<TITAN>();
        FengGameManagerMKII.localET = new List<TITAN_EREN>();
        FengGameManagerMKII.localFT = new List<FEMALE_TITAN>();
        FengGameManagerMKII.localCT = new List<COLOSSAL_TITAN>();
        FengGameManagerMKII.cT = new List<COLOSSAL_TITAN>();
        FengGameManagerMKII.eT = new List<TITAN_EREN>();
        FengGameManagerMKII.fT = new List<FEMALE_TITAN>();
        FengGameManagerMKII.gameStart = false;
        FengGameManagerMKII.heroes = new List<HERO>();
        FengGameManagerMKII.hooks = new List<Bullet>();
        FengGameManagerMKII.LAN = false;
        FengGameManagerMKII.level = string.Empty;
        FengGameManagerMKII.roundTime = 0f;
        FengGameManagerMKII.titans = new List<TITAN>();
        FengGameManagerMKII.GUICtrl = new GameObject("MainGUI");
        F3GUI f3GUI = FengGameManagerMKII.GUICtrl.AddComponent<F3GUI>();
        FengGameManagerMKII.f3GUI = f3GUI;/*
        
        MainGUI mainGUI = FengGameManagerMKII.GUICtrl.AddComponent<MainGUI>();
        FengGameManagerMKII.mainGUI = mainGUI;
        F1GUI f1GUI = FengGameManagerMKII.GUICtrl.AddComponent<F1GUI>();
        FengGameManagerMKII.f1GUI = f1GUI;
        F2GUI f2GUI = FengGameManagerMKII.GUICtrl.AddComponent<F2GUI>();
        FengGameManagerMKII.f2GUI = f2GUI;
        
        
        F4GUI f4GUI = FengGameManagerMKII.GUICtrl.AddComponent<F4GUI>();
        FengGameManagerMKII.f4GUI = f4GUI;
        LinkGUI linkGUI = FengGameManagerMKII.GUICtrl.AddComponent<LinkGUI>();
        FengGameManagerMKII.linkGUI = linkGUI;
        ExtraGUI extraGUI = FengGameManagerMKII.GUICtrl.AddComponent<ExtraGUI>();
        FengGameManagerMKII.extraGUI = extraGUI;
        ServerListGUI serverListGUI = FengGameManagerMKII.GUICtrl.AddComponent<ServerListGUI>();
        FengGameManagerMKII.serverlistGUI = serverListGUI;*/
        int num = 0;
        bool flag = false;
        bool flag1 = flag;
        bool flag2 = flag1;
        //((Behaviour)extraGUI).enabled = (flag1);
        bool flag3 = flag2;
        bool flag4 = flag3;
        //((Behaviour)linkGUI).enabled = (flag3);
        bool flag5 = flag4;
        bool flag6 = flag5;
        //((Behaviour)f4GUI).enabled = (flag5);
        bool flag7 = flag6;
        bool flag8 = flag7;
        ((Behaviour)f3GUI).enabled = (flag7);
        bool flag9 = flag8;
        bool flag10 = flag9;
        //((Behaviour)f2GUI).enabled = (flag9);
        bool flag11 = flag10;
        bool flag12 = flag11;
        //((Behaviour)f1GUI).enabled = (flag11);
        //((Behaviour)mainGUI).enabled = (flag12);
        object[] empty = new object[] { false, false, false, null, null, false, false, false, false, false, false, false, false, false, false, 20, false, false, false, 0, 7, false, false, false, true, false, false, -1, false, 0f, false, false, 0, false, false, false, 0, 0, string.Empty, false, false, 0, string.Empty, false, false, false, "3m5EbyCnLX/hq8ihVFYtcA==", "/eTk55N4SM3u7kEzRW28CmxwfG18DNkrLLIuZePpLaQMBQ4k/ZVa9YadDegZGxj1fLOc6crhy2LEVFWcfg75++bezrauVJPbFnX/ydH0wGirOpRpZjULGmZBIO9nrZs6ahfXmieVacaG9TR48JjB9A==", false, false, false, "v9/1/15", string.Empty, string.Empty, false, string.Empty, false, 0, 0, false, string.Empty, "5mu2X1f9AK1GfC+2Ghap8/kwA7aGqmou0BB3I1q/gQPq6GWKfIiHVOCfXz5LJ3IwIPSJipco9QGcL98Gwb8qjdicKl3rXgwo4V+GF6K09Fvfcp34BcSYdmWGTDWH0Nec09MfP1ES6Vd5YOL80sZJ4mMVQvjaONCnbCatYFotL/qgkZwgPPWphVZ3k4uULmO9PWXjyUsTtCAea7K/qYOJh4LdvcLBBGi2vaNg359LQ6NlsxM5hySN8EIsTvWNbCmIr3yUa8OVyzgDlnqNC03T9A==", false, false, string.Empty, string.Empty, false, string.Empty, false, string.Empty, string.Empty, string.Empty, false, 0, false, 0f, true, string.Empty, false, false, false, false, false, false, string.Empty, false, string.Empty, 0, string.Empty, string.Empty, false, false, "Faded", string.Empty, false, "None", "None", "None", false, false, null, string.Empty, string.Empty, string.Empty, false, false, false, false, false, false, false, false, false, -1, false, false, false, false };
        FengGameManagerMKII.settings = empty;
        IN_GAME_MAIN_CAMERA nGAMEMAINCAMERA = Resources.Load<IN_GAME_MAIN_CAMERA>("MainCamera_Mono");
        FengGameManagerMKII.skinCache = new Dictionary<string, Material>[] { new Dictionary<string, Material>(), new Dictionary<string, Material>(), new Dictionary<string, Material>(), new Dictionary<string, Material>(), null };
        Dictionary<string, Material>[] dictionaryArrays = FengGameManagerMKII.skinCache;
        Dictionary<string, Material> strs2 = new Dictionary<string, Material>(3)
        {
            { "DAY", nGAMEMAINCAMERA.skyBoxDAY },
            { "DAWN", nGAMEMAINCAMERA.skyBoxDAWN },
            { "NIGHT", nGAMEMAINCAMERA.skyBoxNIGHT }
        };
        dictionaryArrays[4] = strs2;
        FengGameManagerMKII.textureCache = new Dictionary<string, Texture>[] { new Dictionary<string, Texture>(), new Dictionary<string, Texture>(), new Dictionary<string, Texture>(), new Dictionary<string, Texture>() };
        FengGameManagerMKII.Hash = new ExitGames.Client.Photon.Hashtable[] { new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable() };
        FengGameManagerMKII.linkHash = new ExitGames.Client.Photon.Hashtable[] { new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable(), new ExitGames.Client.Photon.Hashtable() };
        strs2 = new Dictionary<string, Material>(3)
        {
            { "DAY", nGAMEMAINCAMERA.skyBoxDAY },
            { "DAWN", nGAMEMAINCAMERA.skyBoxDAWN },
            { "NIGHT", nGAMEMAINCAMERA.skyBoxNIGHT }
        };
        dictionaryArrays = FengGameManagerMKII.skinCache;
        dictionaryArrays[4] = strs2;
    }

    internal void Upload()
    {
        FengGameManagerMKII.settings[80] = true;
        FengGameManagerMKII.settings[69] = string.Empty;
        BTN_save_snapshot.Uploading = true;
        base.StartCoroutine(FengGameManagerMKII.UploadImage(null));
    }

    internal static void ResizeImg(Texture2D kill = null)
    {
        if (FengGameManagerMKII.MKII != null)
        {
            FengGameManagerMKII.MKII.StartCoroutine(FengGameManagerMKII.ResizeIMG(kill));
        }
    }

    private static IEnumerator ResizeIMG(Texture2D kill = null)
    {
        yield return new WaitForEndOfFrame();/*
        float _width;
        int _height;
        int i;
        byte[] numArray;
        if (kill == null)
        {
            if (LinkGUI.resizedlinkTex != null)
            {
                _width = (float)LinkGUI.resizedlinkTex.width / (float)LinkGUI.resizedlinkTex.height;
                _height = (int)((float)Screen.height * 0.75f * _width);
                for (i = (int)((float)Screen.height * 0.75f); _height >= Screen.width || i >= Screen.height; i = i - (int)((float)i * 0.05f))
                {
                    _height = _height - (int)((float)_height * 0.05f);
                }
                UnityEngine.Object.Destroy(LinkGUI.resizedlinkTex);
                while (LinkGUI.resizedlinkTex != null)
                {
                    yield return null;
                }
                byte[] pNG = LinkGUI.linkTex.EncodeToPNG();
                byte[] numArray1 = pNG;
                numArray = pNG;
                yield return numArray1;
                Texture2D texture2D = new Texture2D(_height, i, 1, (double)LinkGUI.link.Third >= 5000000);
                LinkGUI.resizedlinkTex = texture2D;
                yield return texture2D;
                if (!LinkGUI.resizedlinkTex.LoadImage(numArray))
                {
                    throw new Exception("Failed to resize image - LinkGUI.resizedlinkTex.LoadImage(data)");
                }
                TextureScale.Bilinear(LinkGUI.resizedlinkTex, _height, i);
                if ((double)LinkGUI.link.Third >= 500000)
                {
                    LinkGUI.resizedlinkTex.Compress(true);
                }
                LinkGUI.resizedlinkTex.Apply();
            }
            if (FengGameManagerMKII.resizedlinkTex != null && ((bool)FengGameManagerMKII.settings[63] && FengGameManagerMKII.linkTex != null && FengGameManagerMKII.www != null || (bool)FengGameManagerMKII.settings[79]))
            {
                _width = (float)FengGameManagerMKII.resizedlinkTex.width / (float)FengGameManagerMKII.resizedlinkTex.height;
                _height = (int)((float)Screen.height * 0.75f * _width);
                for (i = (int)((float)Screen.height * 0.75f); _height >= Screen.width || i >= Screen.height; i = i - (int)((float)i * 0.05f))
                {
                    _height = _height - (int)((float)_height * 0.05f);
                }
                UnityEngine.Object.Destroy(FengGameManagerMKII.resizedlinkTex);
                while (FengGameManagerMKII.resizedlinkTex != null)
                {
                    yield return null;
                }
                if (!(bool)FengGameManagerMKII.settings[79])
                {
                    Texture2D texture2D1 = new Texture2D(_height, i, 1, (double)FengGameManagerMKII.www.size >= 50000000);
                    FengGameManagerMKII.resizedlinkTex = texture2D1;
                    yield return texture2D1;
                    FengGameManagerMKII.www.LoadImageIntoTexture(FengGameManagerMKII.resizedlinkTex);
                }
                else
                {
                    byte[] jPG = SnapShotSaves.getCurrentIMG().EncodeToJPG();
                    byte[] numArray2 = jPG;
                    numArray = jPG;
                    yield return numArray2;
                    Texture2D texture2D2 = new Texture2D(_height, i, 1, false);
                    FengGameManagerMKII.resizedlinkTex = texture2D2;
                    yield return texture2D2;
                    if (!FengGameManagerMKII.resizedlinkTex.LoadImage(numArray))
                    {
                        throw new Exception("Failed to resize image - resizedlinkTex.LoadImage(data)");
                    }
                }
                TextureScale.Bilinear(FengGameManagerMKII.resizedlinkTex, _height, i);
                if (!(bool)FengGameManagerMKII.settings[79] && (double)FengGameManagerMKII.www.size >= 500000)
                {
                    FengGameManagerMKII.resizedlinkTex.Compress(true);
                }
                FengGameManagerMKII.resizedlinkTex.Apply();
            }
        }
        else
        {
            _width = (float)kill.width / (float)kill.height;
            _height = (int)((float)Screen.height * 0.75f * _width);
            i = (int)((float)Screen.height * 0.75f);
            while (_height >= Screen.width)
            {
                _height = _height - (int)((float)_height * 0.05f);
                i = i - (int)((float)i * 0.05f);
            }
            byte[] jPG1 = kill.EncodeToJPG();
            byte[] numArray3 = jPG1;
            numArray = jPG1;
            yield return numArray3;
            Texture2D texture2D3 = new Texture2D(kill.width, kill.height, 1, false);
            FengGameManagerMKII.linkTex = texture2D3;
            yield return texture2D3;
            Texture2D texture2D4 = new Texture2D(_height, i, 1, false);
            FengGameManagerMKII.resizedlinkTex = texture2D4;
            yield return texture2D4;
            if (!FengGameManagerMKII.linkTex.LoadImage(numArray) || !FengGameManagerMKII.resizedlinkTex.LoadImage(numArray))
            {
                throw new Exception("Failed to resize image - linkTex.LoadImage(data) && resizedlinkTex.LoadImage(data)");
            }
            TextureScale.Bilinear(FengGameManagerMKII.resizedlinkTex, _height, i);
            FengGameManagerMKII.resizedlinkTex.Apply();
        }*/
    }

    internal static IEnumerator UploadImage(Texture2D kill = null)
    {
        WWWForm wWWForm = new WWWForm();
        wWWForm.AddField("key", "433a1bf4743dd8d7845629b95b5ca1b4");
        if (kill == null)
        {
            BTN_save_snapshot.tex.OnClick();
            yield return new WaitForEndOfFrame();
            float _height = (float)Screen.height / 600f;
            Texture2D texture2D = new Texture2D((int)(_height * BTN_save_snapshot.tex.targetTexture.transform.localScale.x), (int)(_height * BTN_save_snapshot.tex.targetTexture.transform.localScale.y), (TextureFormat)3, false);
            texture2D.ReadPixels(new Rect((float)Screen.width * 0.5f - (float)texture2D.width * 0.5f, (float)Screen.height * 0.5f - (float)texture2D.height * 0.5f - _height * 0f, (float)texture2D.width, (float)texture2D.height), 0, 0);
            texture2D.Apply();
            wWWForm.AddBinaryData("image", texture2D.EncodeToPNG());
            using (WWW wWW = new WWW("http://imgur.com/api/upload.xml", wWWForm))
            {
                yield return wWW;
                if (!wWW.error.IsNullOrEmpty())
                {
                    FengGameManagerMKII.settings[69] = wWW.error;
                }
                else
                {
                    FengGameManagerMKII.settings[69] = wWW.text;
                }
                BTN_save_snapshot.tex.Reposition();
                BTN_save_snapshot.Uploading = false;
                FengGameManagerMKII.settings[80] = false;
            }
            UnityEngine.Object.Destroy(texture2D);
        }
        else
        {
            wWWForm.AddBinaryData("image", kill.EncodeToPNG());
            using (WWW wWW1 = new WWW("http://imgur.com/api/upload.xml", wWWForm))
            {
                yield return wWW1;
                if (!wWW1.error.IsNullOrEmpty())
                {
                    FengGameManagerMKII.settings[69] = wWW1.error;
                }
                else
                {
                    FengGameManagerMKII.settings[69] = wWW1.text;
                }
                FengGameManagerMKII.settings[80] = false;
            }
        }
    }

    private bool VectorClamp(Vector3 next, float scale)
    {
        float single = next.x;
        float single1 = next.y;
        float single2 = next.z;
        bool flag = false;
        scale = scale / 2f;
        string str = FengGameManagerMKII.levelinfo.mapName;
        string str1 = str;
        if (str != null)
        {
            if (str1 == "OutSide")
            {
                if (!single.InBetween(-1129.9f, 6110.1f))
                {
                    flag = true;
                    single = Mathf.Clamp(single, -1059.9f, 6040.1f);
                }
                if (!single1.InBetween(-10f * scale, 1420f))
                {
                    flag = true;
                    single1 = 0f;
                }
                if (!single2.InBetween(600f, 5815.5f))
                {
                    flag = true;
                    single2 = Mathf.Clamp(single2, 670f, 5745.5f);
                }
                if (flag)
                {
                    next = new Vector3(single, single1, single2);
                }
                return flag;
            }
            if (str1 == "The Forest")
            {
                if (!single.InBetween(-749.5f, 749.5f))
                {
                    flag = true;
                    single = Mathf.Clamp(single, -639.5f, 639.5f);
                }
                if (single1 < -10f * Mathf.Abs(scale))
                {
                    flag = true;
                    single1 = 0f;
                }
                if (!single2.InBetween(-749.5f, 749.5f))
                {
                    flag = true;
                    single2 = Mathf.Clamp(single2, -639.5f, 639.5f);
                }
                if (flag)
                {
                    next = new Vector3(single, single1, single2);
                }
                return flag;
            }
            if (str1 == "The City I")
            {
                if (!single.InBetween(-760f, 810f))
                {
                    flag = true;
                    single = Mathf.Clamp(single, -650f, 739f);
                }
                if (single1 < -10f * Mathf.Abs(scale))
                {
                    flag = true;
                    single1 = 0f;
                }
                if (!single2.InBetween(-792.1f, 828f))
                {
                    flag = true;
                    single2 = Mathf.Clamp(single2, -700f, 748f);
                }
                if (flag)
                {
                    next = new Vector3(single, single1, single2);
                }
                return flag;
            }
            if (str1 == "Colossal Titan")
            {
                if (!single.InBetween(-1057.1f, 1015.9f))
                {
                    flag = true;
                    single = Mathf.Clamp(single, -937.1f, 925.9f);
                }
                if (single1 < -10f * Mathf.Abs(scale))
                {
                    flag = true;
                    single1 = 0f;
                }
                if (!single2.InBetween(-760f, 1136.6f))
                {
                    flag = true;
                    single2 = Mathf.Clamp(single2, -698f, 1000f);
                }
                if (flag)
                {
                    next = new Vector3(single, single1, single2);
                }
                return flag;
            }
        }
        return false;
    }

    internal void ViewKillSnapshot(PhotonPlayer player)
    {
        byte[] item = this.snapshots[player];
        string[] strArrays = this.snapshotsWxH[player].Split(new char[] { 'x' });
        float single = Convert.ToSingle(strArrays[0].Replace("x", string.Empty)) / Convert.ToSingle(strArrays[1].Replace("x", string.Empty));
        int _height = (int)((float)Screen.height * 0.75f * single);
        int num = (int)((float)Screen.height * 0.75f);
        while (_height >= Screen.width)
        {
            _height = _height / 10;
            num = num / 10;
        }
        FengGameManagerMKII.linkTex = new Texture2D(Convert.ToInt32(strArrays[0].Replace("x", string.Empty)), Convert.ToInt32(strArrays[1].Replace("x", string.Empty)), (TextureFormat)1, false);
        FengGameManagerMKII.resizedlinkTex = new Texture2D(_height, num, (TextureFormat)1, false);
        FengGameManagerMKII.linkTex.LoadImage(item);
        FengGameManagerMKII.resizedlinkTex.LoadImage(item);
        TextureScale.Bilinear(FengGameManagerMKII.resizedlinkTex, _height, num);
        FengGameManagerMKII.settings[63] = true;
        int num1 = 1;
        IN_GAME_MAIN_CAMERA.isPausing = true;
        IN_GAME_MAIN_CAMERA.isTyping = true;
        FengGameManagerMKII.settings[40] = true;
    }

    public static LevelInfo levelinfo
    {
        get
        {
            if (Application.loadedLevel != 0)
            {
                return FengGameManagerMKII.current;
            }
            return new LevelInfo();
        }
        set
        {
            FengGameManagerMKII.current = value;
        }
    }


    public static bool RPC(string method, PhotonPlayer player, object var)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, player, var);
        return true;
    }

    public static bool RPC(string method, PhotonPlayer player, object var, object var2)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, player, var, var2);
        return true;
    }

    public static bool RPC(string method, PhotonPlayer player, object var, object var2, object var3)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, player, var, var2, var3);
        return true;
    }

    public static bool RPC(string method, PhotonPlayer player, object var, object var2, object var3, object var4)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, player, var, var2, var3, var4);
        return true;
    }

    public static bool RPC<T>(string method, PhotonPlayer player, T[] parameters)
    where T : class
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC<T>(method, player, parameters);
        return true;
    }

    public static bool RPC(string method, PhotonPlayer player, params object[] parameters)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, player, parameters);
        return true;
    }

    public static bool RPC(string method, PhotonTargets targets, object var)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, targets, var);
        return true;
    }

    public static bool RPC(string method, PhotonTargets targets, object var, object var2)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, targets, var, var2);
        return true;
    }

    public static bool RPC(string method, PhotonTargets targets, object var, object var2, object var3)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, targets, var, var2, var3);
        return true;
    }

    public static bool RPC(string method, PhotonTargets targets, object var, object var2, object var3, object var4)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, targets, var, var2, var3, var4);
        return true;
    }

    public static bool RPC(string method, PhotonTargets targets, params string[] parameters)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC<string>(method, targets, parameters);
        return true;
    }

    public static bool RPC(string method, PhotonTargets targets, params object[] parameters)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null)
        {
            return false;
        }
        FengGameManagerMKII.PView.RPC(method, targets, parameters);
        return true;
    }

    public static bool RPC(RPCList rpcList)
    {
        if (FengGameManagerMKII.MKII == null || FengGameManagerMKII.PView == null || rpcList == null)
        {
            return false;
        }
        if (rpcList.sendOnCreate)
        {
            return true;
        }
        rpcList.SendAll();
        return true;
    }


    private void setGameSettings(ExitGames.Client.Photon.Hashtable hash, PhotonMessageInfo info)
    {
        string empty;
        if (hash.ContainsKey("bomb"))
        {
            if (RCSettings.bombMode != (int)hash["bomb"])
            {
                RCSettings.bombMode = (int)hash["bomb"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE("<color=#FFCC00>PVP Bomb Mode enabled.</color>", null, false, true);
                }
            }
        }
        else if (RCSettings.bombMode != 0)
        {
            RCSettings.bombMode = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>PVP Bomb Mode disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("globalDisableMinimap"))
        {
            if (RCSettings.globalDisableMinimap != (int)hash["globalDisableMinimap"])
            {
                RCSettings.globalDisableMinimap = (int)hash["globalDisableMinimap"];
                InRoomChat.addLINE("<color=#FFCC00>Minimaps are not allowed.</color>", null, false, true);
            }
        }
        else if (RCSettings.globalDisableMinimap != 0)
        {
            RCSettings.globalDisableMinimap = 0;
            InRoomChat.addLINE("<color=#FFCC00>Minimaps are allowed.</color>", null, false, true);
        }
        if (hash.ContainsKey("horse"))
        {
            if (RCSettings.horseMode != (int)hash["horse"])
            {
                RCSettings.horseMode = (int)hash["horse"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE("<color=#FFCC00>Horses enabled.</color>", null, false, true);
                    if (IN_GAME_MAIN_CAMERA.mainHERO != null)
                    {
                        IN_GAME_MAIN_CAMERA.mainHERO.SpawnHorse(false);
                    }
                }
            }
        }
        else if (RCSettings.horseMode != 0)
        {
            RCSettings.horseMode = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Horses disabled.</color>", null, false, true);
                if (IN_GAME_MAIN_CAMERA.mainHERO != null)
                {
                    IN_GAME_MAIN_CAMERA.mainHERO.DestroyHorse();
                }
            }
        }
        if (hash.ContainsKey("punkWaves"))
        {
            if (RCSettings.punkWaves != (int)hash["punkWaves"])
            {
                RCSettings.punkWaves = (int)hash["punkWaves"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE("<color=#FFCC00>Punk override every 5 waves enabled.</color>", null, false, true);
                }
            }
        }
        else if (RCSettings.punkWaves != 0)
        {
            RCSettings.punkWaves = 0;
            if (!PhotonNetwork.isMasterClient)
            {
                InRoomChat.addLINE("<color=#FFCC00>Punk override every 5 waves disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("ahssReload"))
        {
            if (RCSettings.ahssReload != (int)hash["ahssReload"])
            {
                RCSettings.ahssReload = (int)hash["ahssReload"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE("<color=#FFCC00>AHSS Air-Reload disabled.</color>", null, false, true);
                }
            }
        }
        else if (RCSettings.ahssReload != 0)
        {
            RCSettings.ahssReload = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>AHSS Air-Reload allowed.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("team"))
        {
            if (RCSettings.teamMode != (int)hash["team"])
            {
                RCSettings.teamMode = (int)hash["team"];
                empty = string.Empty;
                if (RCSettings.teamMode == 1)
                {
                    empty = "no sort";
                }
                else if (RCSettings.teamMode == 2)
                {
                    empty = "locked by size";
                }
                else if (RCSettings.teamMode == 3)
                {
                    empty = "locked by skill";
                }
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>Team Mode enabled (", empty, ").</color>"), null, false, true);
                }
                if (PhotonNetwork.player.RCteam == 0)
                {
                    this.setTeam(3);
                }
            }
        }
        else if (RCSettings.teamMode != 0)
        {
            RCSettings.teamMode = 0;
            this.setTeam(0);
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Team mode disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("point"))
        {
            if (RCSettings.pointMode != (int)hash["point"])
            {
                RCSettings.pointMode = (int)hash["point"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>Point limit enabled (", RCSettings.pointMode, ").</color>"), null, false, true);
                }
            }
        }
        else if (RCSettings.pointMode != 0)
        {
            RCSettings.pointMode = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Point limit disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("rock"))
        {
            if (RCSettings.disableRock != (int)hash["rock"])
            {
                RCSettings.disableRock = (int)hash["rock"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE("<color=#FFCC00>Punk rock throwing disabled.</color>", null, false, true);
                }
            }
        }
        else if (RCSettings.disableRock != 0)
        {
            RCSettings.disableRock = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Punk rock throwing enabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("explode"))
        {
            if (RCSettings.explodeMode != (int)hash["explode"])
            {
                RCSettings.explodeMode = (int)hash["explode"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>Titan Explode Mode enabled (Radius ", RCSettings.explodeMode, ").</color>"), null, false, true);
                }
            }
        }
        else if (RCSettings.explodeMode != 0)
        {
            RCSettings.explodeMode = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Titan Explode Mode disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("healthMode") && hash.ContainsKey("healthLower") && hash.ContainsKey("healthUpper"))
        {
            if (RCSettings.healthMode != (int)hash["healthMode"] || RCSettings.healthLower != (int)hash["healthLower"] || RCSettings.healthUpper != (int)hash["healthUpper"])
            {
                RCSettings.healthMode = (int)hash["healthMode"];
                RCSettings.healthLower = (int)hash["healthLower"];
                RCSettings.healthUpper = (int)hash["healthUpper"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    empty = "Static";
                    if (RCSettings.healthMode == 2)
                    {
                        empty = "Scaled";
                    }
                    string[] str = new string[] { "<color=#FFCC00>Titan Health (", empty, ", ", null, null, null, null };
                    str[3] = RCSettings.healthLower.ToString();
                    str[4] = " to ";
                    str[5] = RCSettings.healthUpper.ToString();
                    str[6] = ") enabled.</color>";
                    InRoomChat.addLINE(string.Concat(str), null, false, true);
                }
            }
        }
        else if (RCSettings.healthMode != 0 || RCSettings.healthLower != 0 || RCSettings.healthUpper != 0)
        {
            RCSettings.healthMode = 0;
            RCSettings.healthLower = 0;
            RCSettings.healthUpper = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Titan Health disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("infection"))
        {
            if (RCSettings.infectionMode != (int)hash["infection"])
            {
                RCSettings.infectionMode = (int)hash["infection"];
                base.name = (LoginFengKAI.player.name);
                PhotonPlayer photonPlayer = PhotonNetwork.player;
                ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                hashtable.Add("RCteam", 0);
                photonPlayer.SetCustomProperties(hashtable);
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>Infection mode (", RCSettings.infectionMode, ") enabled. Make sure your first character is human.</color>"), null, false, true);
                }
            }
        }
        else if (RCSettings.infectionMode != 0)
        {
            RCSettings.infectionMode = 0;
            PhotonPlayer photonPlayer1 = PhotonNetwork.player;
            ExitGames.Client.Photon.Hashtable hashtable1 = new ExitGames.Client.Photon.Hashtable();
            hashtable1.Add("isTitan", 1);
            photonPlayer1.SetCustomProperties(hashtable1);
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Infection Mode disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("eren"))
        {
            if (RCSettings.banEren != (int)hash["eren"])
            {
                RCSettings.banEren = (int)hash["eren"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE("<color=#FFCC00>Anti-Eren enabled. Using eren transform will get you kicked.</color>", null, false, true);
                }
            }
        }
        else if (RCSettings.banEren != 0)
        {
            RCSettings.banEren = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Anti-Eren disabled. Eren transform is allowed.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("titanc"))
        {
            if (RCSettings.moreTitans != (int)hash["titanc"])
            {
                RCSettings.moreTitans = (int)hash["titanc"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>", RCSettings.moreTitans, " titans will spawn each round.</color>"), null, false, true);
                }
            }
        }
        else if (RCSettings.moreTitans != 0)
        {
            RCSettings.moreTitans = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Default titans will spawn each round.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("damage"))
        {
            if (RCSettings.damageMode != (int)hash["damage"])
            {
                RCSettings.damageMode = (int)hash["damage"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    int num = RCSettings.damageMode;
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>Nape minimum damage (", num.ToString(), ") enabled.</color>"), null, false, true);
                }
            }
        }
        else if (RCSettings.damageMode != 0)
        {
            RCSettings.damageMode = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Nape minimum damage disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("sizeMode") && hash.ContainsKey("sizeLower") && hash.ContainsKey("sizeUpper"))
        {
            if (RCSettings.sizeMode == (int)hash["sizeMode"])
            {
                if (RCSettings.sizeLower == (hash["sizeLower"] is float ? (float)hash["sizeLower"] : (float)((int)hash["sizeLower"])))
                {
                    if (RCSettings.sizeUpper == (hash["sizeUpper"] is float ? (float)hash["sizeUpper"] : (float)((int)hash["sizeUpper"])))
                    {
                        //goto Label0;
                    }
                }
            }
            RCSettings.sizeMode = (int)hash["sizeMode"];
            RCSettings.sizeLower = (hash["sizeLower"] is float ? (float)hash["sizeLower"] : (float)((int)hash["sizeLower"])) * 4.643f;
            RCSettings.sizeUpper = (hash["sizeUpper"] is float ? (float)hash["sizeUpper"] : (float)((int)hash["sizeUpper"])) * 4.643f;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                string[] strArrays = new string[] { "<color=#FFCC00>Custom titan size (", null, null, null, null };
                strArrays[1] = RCSettings.sizeLower.ToString("F2");
                strArrays[2] = ",";
                strArrays[3] = RCSettings.sizeUpper.ToString("F2");
                strArrays[4] = ") enabled.</color>";
                InRoomChat.addLINE(string.Concat(strArrays), null, false, true);
            }
        }
        else if (!PhotonNetwork.player.isTitan && (RCSettings.sizeMode != 0 || RCSettings.sizeLower != 0f || RCSettings.sizeUpper != 0f))
        {
            RCSettings.sizeMode = 0;
            RCSettings.sizeLower = 0f;
            RCSettings.sizeUpper = 0f;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Custom titan size disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("spawnMode") && hash.ContainsKey("nRate") && hash.ContainsKey("aRate") && hash.ContainsKey("jRate") && hash.ContainsKey("cRate") && hash.ContainsKey("pRate"))
        {
            if (RCSettings.spawnMode != (int)hash["spawnMode"] || RCSettings.nRate != (float)hash["nRate"] || RCSettings.aRate != (float)hash["aRate"] || RCSettings.jRate != (float)hash["jRate"] || RCSettings.cRate != (float)hash["cRate"] || RCSettings.pRate != (float)hash["pRate"])
            {
                RCSettings.spawnMode = (int)hash["spawnMode"];
                RCSettings.nRate = (float)hash["nRate"];
                RCSettings.aRate = (float)hash["aRate"];
                RCSettings.jRate = (float)hash["jRate"];
                RCSettings.cRate = (float)hash["cRate"];
                RCSettings.pRate = (float)hash["pRate"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    string[] str1 = new string[] { "<color=#FFCC00>Custom spawn rate enabled (", null, null, null, null, null, null, null, null, null, null };
                    str1[1] = RCSettings.nRate.ToString("F2");
                    str1[2] = "% Normal, ";
                    str1[3] = RCSettings.aRate.ToString("F2");
                    str1[4] = "% Abnormal, ";
                    str1[5] = RCSettings.jRate.ToString("F2");
                    str1[6] = "% Jumper, ";
                    str1[7] = RCSettings.cRate.ToString("F2");
                    str1[8] = "% Crawler, ";
                    str1[9] = RCSettings.pRate.ToString("F2");
                    str1[10] = "% Punk </color>";
                    InRoomChat.addLINE(string.Concat(str1), null, false, true);
                }
            }
        }
        else if (RCSettings.spawnMode != 0 || RCSettings.nRate != 0f || RCSettings.aRate != 0f || RCSettings.jRate != 0f || RCSettings.cRate != 0f || RCSettings.pRate != 0f)
        {
            RCSettings.spawnMode = 0;
            RCSettings.nRate = 0f;
            RCSettings.aRate = 0f;
            RCSettings.jRate = 0f;
            RCSettings.cRate = 0f;
            RCSettings.pRate = 0f;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Custom spawn rate disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("waveModeOn") && hash.ContainsKey("waveModeNum"))
        {
            if (RCSettings.waveModeOn != (int)hash["waveModeOn"] || RCSettings.waveModeNum != (int)hash["waveModeNum"])
            {
                RCSettings.waveModeOn = (int)hash["waveModeOn"];
                RCSettings.waveModeNum = (int)hash["waveModeNum"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    int num1 = RCSettings.waveModeNum;
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>Custom wave mode (", num1.ToString(), ") enabled.</color>"), null, false, true);
                }
            }
        }
        else if (RCSettings.waveModeOn != 0 || RCSettings.waveModeNum != 0)
        {
            RCSettings.waveModeOn = 0;
            RCSettings.waveModeNum = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Custom wave mode disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("friendly"))
        {
            if (RCSettings.friendlyMode != (int)hash["friendly"])
            {
                RCSettings.friendlyMode = (int)hash["friendly"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE("<color=#FFCC00>PVP is prohibited.</color>", null, false, true);
                }
            }
        }
        else if (RCSettings.friendlyMode != 0)
        {
            RCSettings.friendlyMode = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>PVP is allowed.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("pvp"))
        {
            if (RCSettings.pvpMode != (int)hash["pvp"])
            {
                RCSettings.pvpMode = (int)hash["pvp"];
                empty = string.Empty;
                if (RCSettings.pvpMode == 1)
                {
                    empty = "Team-Based";
                }
                else if (RCSettings.pvpMode == 2)
                {
                    empty = "FFA";
                }
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>Blade/AHSS PVP enabled (", empty, ").</color>"), null, false, true);
                }
            }
        }
        else if (RCSettings.pvpMode != 0)
        {
            RCSettings.pvpMode = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Blade/AHSS PVP disabled.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("maxwave"))
        {
            if (RCSettings.maxWave != (int)hash["maxwave"])
            {
                RCSettings.maxWave = (int)hash["maxwave"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    int num2 = RCSettings.maxWave;
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>Max wave is ", num2.ToString(), ".</color>"), null, false, true);
                }
            }
        }
        else if (RCSettings.maxWave != 0)
        {
            RCSettings.maxWave = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Max wave set to default.</color>", null, false, true);
            }
        }
        if (hash.ContainsKey("endless"))
        {/*
            if (RCSettings.endlessMode != (int)hash["endless"])
            {
                RCSettings.endlessMode = (int)hash["endless"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    int num3 = RCSettings.endlessMode;
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>Endless respawn enabled (", num3.ToString(), " seconds).</color>"), null, false, true);
                }
            }*/
        }/*
        else if (RCSettings.endlessMode != 0)
        {
            RCSettings.endlessMode = 0;
            if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
            {
                InRoomChat.addLINE("<color=#FFCC00>Endless respawn disabled.</color>", null, false, true);
            }
        }*/
        if (hash.ContainsKey("motd"))
        {
            if (RCSettings.motd != (string)hash["motd"])
            {
                RCSettings.motd = (string)hash["motd"];
                if (!PhotonNetwork.isMasterClient && info != null && !info.sender.RS)
                {
                    InRoomChat.addLINE(string.Concat("<color=#FFCC00>MOTD:", RCSettings.motd, "</color>"), null, false, true);
                }
            }
        }
        else if (RCSettings.motd != string.Empty)
        {
            RCSettings.motd = string.Empty;
        }
        if (hash.ContainsKey("deadlycannons"))
        {
            if (RCSettings.deadlyCannons != (int)hash["deadlycannons"])
            {
                RCSettings.deadlyCannons = (int)hash["deadlycannons"];
                InRoomChat.addLINE("<color=#FFCC00>Cannons will now kill players.</color>", null, false, true);
            }
        }
        else if (RCSettings.deadlyCannons != 0)
        {
            RCSettings.deadlyCannons = 0;
            InRoomChat.addLINE("<color=#FFCC00>Cannons will no longer kill players.</color>", null, false, true);
        }
        if (hash.ContainsKey("asoracing"))
        {
            if (RCSettings.racingStatic != (int)hash["asoracing"])
            {
                RCSettings.racingStatic = (int)hash["asoracing"];
                InRoomChat.addLINE("<color=#FFCC00>Racing will not restart on win.</color>", null, false, true);
                return;
            }
        }
        else if (RCSettings.racingStatic != 0)
        {
            RCSettings.racingStatic = 0;
            InRoomChat.addLINE("<color=#FFCC00>Racing will restart on win.</color>", null, false, true);
        }
    }

    [RPC]
    private void setMasterRC(PhotonMessageInfo info)
    {
        if (info.sender.isMasterClient)
        {
            FengGameManagerMKII.masterRC = true;
        }
    }

    private void setTeam(int setting)
    {
        switch (setting)
        {
            case 0:
                {
                    FengGameManagerMKII.uiname = LoginFengKAI.player.name;
                    PhotonPlayer photonPlayer = PhotonNetwork.player;
                    ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                    hashtable.Add("team", 0);
                    hashtable.Add("name", FengGameManagerMKII.uiname);
                    photonPlayer.SetCustomProperties(hashtable);
                    foreach (GameObject allhero in FengGameManagerMKII.allheroes)
                    {
                        if (allhero == null)
                        {
                            continue;
                        }
                        PhotonView component = allhero.GetComponent<PhotonView>();
                        if (!(component != null) || !component.isMine)
                        {
                            continue;
                        }
                        FengGameManagerMKII.PView.RPC("labelRPC", PhotonTargets.All, component.viewID);
                    }
                    return;
                }
            case 1:
                {
                    string str = LoginFengKAI.player.name.StripHex();
                    if (!str.StartsWith("[00FFFF]"))
                    {
                        str = string.Concat("[00FFFF]", str);
                    }
                    FengGameManagerMKII.uiname = str;
                    PhotonPlayer photonPlayer1 = PhotonNetwork.player;
                    ExitGames.Client.Photon.Hashtable hashtable1 = new ExitGames.Client.Photon.Hashtable();
                    hashtable1.Add("team", 1);
                    hashtable1.Add("name", FengGameManagerMKII.uiname);
                    photonPlayer1.SetCustomProperties(hashtable1);
                    foreach (GameObject gameObject in FengGameManagerMKII.allheroes)
                    {
                        if (gameObject == null)
                        {
                            continue;
                        }
                        PhotonView photonView = gameObject.GetComponent<PhotonView>();
                        if (!(photonView != null) || !photonView.isMine)
                        {
                            continue;
                        }
                        FengGameManagerMKII.PView.RPC("labelRPC", PhotonTargets.All, photonView.viewID);
                    }
                    return;
                }
            case 2:
                {
                    string str1 = LoginFengKAI.player.name.StripHex();
                    if (!str1.StartsWith("[FF00FF]"))
                    {
                        str1 = string.Concat("[FF00FF]", str1);
                    }
                    FengGameManagerMKII.uiname = str1;
                    PhotonPlayer photonPlayer2 = PhotonNetwork.player;
                    ExitGames.Client.Photon.Hashtable hashtable2 = new ExitGames.Client.Photon.Hashtable();
                    hashtable2.Add("team", 2);
                    hashtable2.Add("name", FengGameManagerMKII.uiname);
                    photonPlayer2.SetCustomProperties(hashtable2);
                    foreach (GameObject allhero1 in FengGameManagerMKII.allheroes)
                    {
                        if (allhero1 == null)
                        {
                            continue;
                        }
                        PhotonView component1 = allhero1.GetComponent<PhotonView>();
                        if (!(component1 != null) || !component1.isMine)
                        {
                            continue;
                        }
                        FengGameManagerMKII.PView.RPC("labelRPC", PhotonTargets.All, component1.viewID);
                    }
                    return;
                }
            case 3:
                {
                    int num = 0;
                    int num1 = 0;
                    int num2 = 1;
                    PhotonPlayer[] photonPlayerArray = PhotonNetwork.playerList;
                    for (int i = 0; i < (int)photonPlayerArray.Length; i++)
                    {
                        ExitGames.Client.Photon.Hashtable hashtable3 = photonPlayerArray[i].customProperties;
                        if (hashtable3["team"] != null)
                        {
                            if ((int)hashtable3["team"] == 1)
                            {
                                num++;
                            }
                            else if ((int)hashtable3["team"] == 2)
                            {
                                num1++;
                            }
                        }
                    }
                    if (num > num1)
                    {
                        num2 = 2;
                    }
                    this.setTeam(num2);
                    return;
                }
            default:
                {
                    return;
                }
        }
    }

    [RPC]
    private void setTeamRPC(int setting, PhotonMessageInfo info)
    {
        if (info.sender.isMasterClient || info.sender.isLocal)
        {
            this.setTeam(setting);
        }
    }

    [RPC]
    private void settingRPC(ExitGames.Client.Photon.Hashtable hash, PhotonMessageInfo info)
    {
        if (info.sender.isMasterClient)
        {
            this.setGameSettings(hash, info);
        }
    }

    [RPC]
    public void settingRPC(string type, int setting, PhotonMessageInfo info)
    {
        if (!info.sender.RS && (info.sender.isMasterClient || info.sender.isLocal))
        {
            if (type == "label")
            {
                PhotonView photonView = PhotonView.Find(setting);
                string str = photonView.owner.guildname;
                string str1 = photonView.owner.uiname;
                HERO component = photonView.GetComponent<HERO>();
                if (component == null)
                {
                    return;
                }
                if (str == string.Empty)
                {
                    component.myNetWorkName.GetComponent<UILabel>().text = str1;
                }
                else
                {
                    component.myNetWorkName.GetComponent<UILabel>().text = string.Concat("[FFFF00]", str, "\n[FFFFFF]", str1);
                }
            }
            string str2 = type;
            string str3 = str2;
            if (str2 != null)
            {
                switch (str3)
                {
                    case "masterRC":
                        {
                            FengGameManagerMKII.masterRC = true;
                            return;
                        }
                    case "maxwave":
                        {
                            FengGameManagerMKII.settingsGame[23] = setting;
                            return;
                        }
                    case "endless":
                        {
                            FengGameManagerMKII.settingsGame[24] = setting;
                            return;
                        }
                    case "titan":
                        {
                            foreach (TITAN titan in FengGameManagerMKII.titans)
                            {
                                if (!(titan.photonView != null) || !titan.photonView.isMine || PhotonNetwork.isMasterClient && !titan.nonAI)
                                {
                                    continue;
                                }
                                PhotonNetwork.Destroy(titan.gameObject, false);
                            }
                            if (!(this.myLastHero == null || this.myLastHero == String.Empty))
                            {
                                this.SpawnNonAITitan(this.myLastHero, "titanRespawn");
                            }
                            return;
                        }
                    case "friendly":
                        {
                            FengGameManagerMKII.settingsGame[21] = setting;
                            return;
                        }
                    case "pvp":
                        {
                            FengGameManagerMKII.settingsGame[22] = setting;
                            return;
                        }
                    case "wave":
                        {
                            FengGameManagerMKII.settingsGame[20] = setting;
                            return;
                        }
                    case "bomb":
                        {
                            FengGameManagerMKII.settingsGame[0] = setting;
                            return;
                        }
                    case "team":
                        {
                            FengGameManagerMKII.settingsGame[1] = setting;
                            if (setting == 0)
                            {
                                this.settingRPC("myteam", 0, info);
                            }
                            return;
                        }
                    case "point":
                        {
                            FengGameManagerMKII.settingsGame[2] = setting;
                            return;
                        }
                    case "rock":
                        {
                            FengGameManagerMKII.settingsGame[3] = setting;
                            return;
                        }
                    case "explode":
                        {
                            FengGameManagerMKII.settingsGame[4] = setting;
                            return;
                        }
                    case "health":
                        {
                            FengGameManagerMKII.settingsGame[5] = setting;
                            return;
                        }
                    case "infection":
                        {
                            if (setting == 1)
                            {
                                FengGameManagerMKII.settingsGame[0] = 0;
                                FengGameManagerMKII.settingsGame[1] = 0;
                                FengGameManagerMKII.settingsGame[2] = 0;
                                FengGameManagerMKII.settingsGame[22] = 0;
                                FengGameManagerMKII.uiname = LoginFengKAI.player.name;
                                PhotonPlayer photonPlayer = PhotonNetwork.player;
                                ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                                hashtable.Add("team", 0);
                                hashtable.Add("name", FengGameManagerMKII.uiname);
                                photonPlayer.SetCustomProperties(hashtable);
                            }
                            FengGameManagerMKII.settingsGame[6] = setting;
                            return;
                        }
                    case "antieren":
                        {
                            FengGameManagerMKII.settingsGame[7] = setting;
                            return;
                        }
                    case "titanc":
                        {
                            FengGameManagerMKII.settingsGame[8] = setting;
                            return;
                        }
                    case "damage":
                        {
                            FengGameManagerMKII.settingsGame[9] = setting;
                            return;
                        }
                    case "size1":
                        {
                            FengGameManagerMKII.settingsGame[10] = setting;
                            if (setting == 0)
                            {
                                FengGameManagerMKII.settingsGame[11] = setting;
                            }
                            return;
                        }
                    case "size2":
                        {
                            FengGameManagerMKII.settingsGame[11] = setting;
                            return;
                        }
                    case "nrate":
                        {
                            if (setting != 0)
                            {
                                FengGameManagerMKII.settingsGame[12] = setting;
                                return;
                            }
                            FengGameManagerMKII.settingsGame[12] = setting;
                            FengGameManagerMKII.settingsGame[13] = setting;
                            FengGameManagerMKII.settingsGame[14] = setting;
                            FengGameManagerMKII.settingsGame[15] = setting;
                            FengGameManagerMKII.settingsGame[16] = setting;
                            return;
                        }
                    case "arate":
                        {
                            FengGameManagerMKII.settingsGame[13] = setting;
                            return;
                        }
                    case "jrate":
                        {
                            FengGameManagerMKII.settingsGame[14] = setting;
                            return;
                        }
                    case "crate":
                        {
                            FengGameManagerMKII.settingsGame[15] = setting;
                            return;
                        }
                    case "prate":
                        {
                            FengGameManagerMKII.settingsGame[16] = setting;
                            return;
                        }
                    case "myteam":
                        {
                            switch (setting)
                            {
                                case 0:
                                    {
                                        FengGameManagerMKII.uiname = LoginFengKAI.player.name;
                                        PhotonPlayer photonPlayer1 = PhotonNetwork.player;
                                        ExitGames.Client.Photon.Hashtable hashtable1 = new ExitGames.Client.Photon.Hashtable();
                                        hashtable1.Add("team", 0);
                                        hashtable1.Add("name", FengGameManagerMKII.uiname);
                                        photonPlayer1.SetCustomProperties(hashtable1);
                                        foreach (HERO hero in FengGameManagerMKII.heroes)
                                        {
                                            if (hero == null)
                                            {
                                                continue;
                                            }
                                            PhotonView photonView1 = hero.photonView;
                                            PhotonView photonView2 = photonView1;
                                            if (!((UnityEngine.Object)photonView1 != null) || !photonView2.isMine)
                                            {
                                                continue;
                                            }
                                            FengGameManagerMKII.PView.RPC("settingRPC", PhotonTargets.All, "label", photonView2.viewID);
                                        }
                                        return;
                                    }
                                case 1:
                                    {
                                        string str4 = LoginFengKAI.player.name.StripHex();
                                        if (!str4.StartsWith("[00FFFF]"))
                                        {
                                            str4 = string.Concat("[00FFFF]", str4);
                                        }
                                        FengGameManagerMKII.uiname = str4;
                                        PhotonPlayer photonPlayer2 = PhotonNetwork.player;
                                        ExitGames.Client.Photon.Hashtable hashtable2 = new ExitGames.Client.Photon.Hashtable();
                                        hashtable2.Add("team", 1);
                                        hashtable2.Add("name", FengGameManagerMKII.uiname);
                                        photonPlayer2.SetCustomProperties(hashtable2);
                                        foreach (HERO hERO in FengGameManagerMKII.heroes)
                                        {
                                            if (hERO == null)
                                            {
                                                continue;
                                            }
                                            PhotonView photonView3 = hERO.photonView;
                                            PhotonView photonView4 = photonView3;
                                            if (!((UnityEngine.Object)photonView3 != null) || !photonView4.isMine)
                                            {
                                                continue;
                                            }
                                            FengGameManagerMKII.PView.RPC("settingRPC", PhotonTargets.All, "label", photonView4.viewID);
                                        }
                                        return;
                                    }
                                case 2:
                                    {
                                        string str5 = LoginFengKAI.player.name.StripHex();
                                        if (!str5.StartsWith("[FF00FF]"))
                                        {
                                            str5 = string.Concat("[FF00FF]", str5);
                                        }
                                        FengGameManagerMKII.uiname = str5;
                                        PhotonPlayer photonPlayer3 = PhotonNetwork.player;
                                        ExitGames.Client.Photon.Hashtable hashtable3 = new ExitGames.Client.Photon.Hashtable();
                                        hashtable3.Add("team", 2);
                                        hashtable3.Add("name", FengGameManagerMKII.uiname);
                                        photonPlayer3.SetCustomProperties(hashtable3);
                                        foreach (HERO hero1 in FengGameManagerMKII.heroes)
                                        {
                                            if (hero1 == null)
                                            {
                                                continue;
                                            }
                                            PhotonView photonView5 = hero1.photonView;
                                            PhotonView photonView6 = photonView5;
                                            if (!((UnityEngine.Object)photonView5 != null) || !photonView6.isMine)
                                            {
                                                continue;
                                            }
                                            FengGameManagerMKII.PView.RPC("settingRPC", PhotonTargets.All, "label", photonView6.viewID);
                                        }
                                        return;
                                    }
                                case 3:
                                    {
                                        int num = 0;
                                        int num1 = 0;
                                        int num2 = 1;
                                        PhotonPlayer[] photonPlayerArray = PhotonNetwork.playerList;
                                        for (int i = 0; i < (int)photonPlayerArray.Length; i++)
                                        {
                                            switch ((int)photonPlayerArray[i].customProperties["team"])
                                            {
                                                case 1:
                                                    {
                                                        num++;
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        num1++;
                                                        break;
                                                    }
                                            }
                                        }
                                        if (num > num1)
                                        {
                                            num2 = 2;
                                        }
                                        this.settingRPC("myteam", num2, info);
                                        break;
                                    }
                                default:
                                    {
                                        return;
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
            }
        }
    }

    [RPC]
    internal void titanGetKill(PhotonPlayer player, int Damage, string name, PhotonMessageInfo info)
    {
        if (info != null && !info.sender.choseSide)
        {
            return;
        }
        PhotonView pView = FengGameManagerMKII.PView;
        int num = Mathf.Max(10, Damage);
        Damage = num;
        pView.RPC("netShowDamage", player, num);
        FengGameManagerMKII.PView.RPC("oneTitanDown", PhotonTargets.MasterClient, name, false);
        this.sendKillInfo(false, player.uiname, true, name, Damage);
        FengGameManagerMKII.playerKillInfoUpdate(player, Damage);
    }

    public void addTime(float time)
    {
        this.timeTotalServer -= time;
    }

    [RPC]
    public void clearlevel(string[] link, int gametype, PhotonMessageInfo info)
    {
        if (gametype == 0)
        {
            IN_GAME_MAIN_CAMERA.gamemode = GAMEMODE.KILL_TITAN;
        }
        else if (gametype == 1)
        {
            IN_GAME_MAIN_CAMERA.gamemode = GAMEMODE.SURVIVE_MODE;
        }
        else if (gametype == 2)
        {
            IN_GAME_MAIN_CAMERA.gamemode = GAMEMODE.PVP_AHSS;
        }
        if (info.sender.isMasterClient && link != null)
        {
            //base.gameObject.GetComponent<CustomMaps>().Destroy();
            base.StartCoroutine(this.clearlevelE(link));
        }
    }

    private IEnumerator clearlevelE(string[] skybox)
    {
        foreach (GameObject obj1 in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj1.name.Contains("TREE") || obj1.name.Contains("aot_supply"))
            {
                UnityEngine.Object.Destroy(obj1);
            }
        }
        string key = skybox[6];
        bool mipmap = true;
        if (settings[0x3f] == "1")
        {
            mipmap = false;
        }
        if (((((skybox[0] != string.Empty) || (skybox[1] != string.Empty)) || ((skybox[2] != string.Empty) || (skybox[3] != string.Empty))) || (skybox[4] != string.Empty)) || (skybox[5] != string.Empty))
        {
            string iteratorVariable2 = string.Join(",", skybox);
            Material material = Camera.main.GetComponent<Skybox>().material;
            string url = skybox[0];
            string iteratorVariable5 = skybox[1];
            string iteratorVariable6 = skybox[2];
            string iteratorVariable7 = skybox[3];
            string iteratorVariable8 = skybox[4];
            string iteratorVariable9 = skybox[5];
            if ((url.EndsWith(".jpg") || url.EndsWith(".png")) || url.EndsWith(".jpeg"))
            {
                WWW link = new WWW(url);
                yield return link;
                Texture2D texture = RCextensions.loadimage(link, mipmap, 0x7a120);
                material.SetTexture("_FrontTex", texture);
            }
            if ((iteratorVariable5.EndsWith(".jpg") || iteratorVariable5.EndsWith(".png")) || iteratorVariable5.EndsWith(".jpeg"))
            {
                WWW iteratorVariable12 = new WWW(iteratorVariable5);
                yield return iteratorVariable12;
                Texture2D iteratorVariable13 = RCextensions.loadimage(iteratorVariable12, mipmap, 0x7a120);
                material.SetTexture("_BackTex", iteratorVariable13);
            }
            if ((iteratorVariable6.EndsWith(".jpg") || iteratorVariable6.EndsWith(".png")) || iteratorVariable6.EndsWith(".jpeg"))
            {
                WWW iteratorVariable14 = new WWW(iteratorVariable6);
                yield return iteratorVariable14;
                Texture2D iteratorVariable15 = RCextensions.loadimage(iteratorVariable14, mipmap, 0x7a120);
                material.SetTexture("_LeftTex", iteratorVariable15);
            }
            if ((iteratorVariable7.EndsWith(".jpg") || iteratorVariable7.EndsWith(".png")) || iteratorVariable7.EndsWith(".jpeg"))
            {
                WWW iteratorVariable16 = new WWW(iteratorVariable7);
                yield return iteratorVariable16;
                Texture2D iteratorVariable17 = RCextensions.loadimage(iteratorVariable16, mipmap, 0x7a120);
                material.SetTexture("_RightTex", iteratorVariable17);
            }
            if ((iteratorVariable8.EndsWith(".jpg") || iteratorVariable8.EndsWith(".png")) || iteratorVariable8.EndsWith(".jpeg"))
            {
                WWW iteratorVariable18 = new WWW(iteratorVariable8);
                yield return iteratorVariable18;
                Texture2D iteratorVariable19 = RCextensions.loadimage(iteratorVariable18, mipmap, 0x7a120);
                material.SetTexture("_UpTex", iteratorVariable19);
            }
            if ((iteratorVariable9.EndsWith(".jpg") || iteratorVariable9.EndsWith(".png")) || iteratorVariable9.EndsWith(".jpeg"))
            {
                WWW iteratorVariable20 = new WWW(iteratorVariable9);
                yield return iteratorVariable20;
                Texture2D iteratorVariable21 = RCextensions.loadimage(iteratorVariable20, mipmap, 0x7a120);
                material.SetTexture("_DownTex", iteratorVariable21);
            }
            Camera.main.GetComponent<Skybox>().material = material;
            //linkHash[1].Add(iteratorVariable2, material);
            //skyMaterial = material;
        }/*
        if ((key.EndsWith(".jpg") || key.EndsWith(".png")) || key.EndsWith(".jpeg"))
        {
            foreach (GameObject iteratorVariable22 in this.groundList)
            {
                if ((iteratorVariable22 != null) && (iteratorVariable22.renderer != null))
                {
                    foreach (Renderer iteratorVariable23 in iteratorVariable22.GetComponentsInChildren<Renderer>())
                    {
                        if (!linkHash[0].ContainsKey(key))
                        {
                            Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, mipmap);
                            WWW iteratorVariable25 = new WWW(key);
                            yield return iteratorVariable25;
                            if ((iteratorVariable25.size > 0) && (iteratorVariable25.size < 0x30d40))
                            {
                                iteratorVariable25.LoadImageIntoTexture(tex);
                            }
                            if (!linkHash[0].ContainsKey(key))
                            {
                                iteratorVariable23.material.mainTexture = tex;
                                linkHash[0].Add(key, iteratorVariable23.material);
                            }
                            else
                            {
                                iteratorVariable23.material = (Material)linkHash[0][key];
                            }
                        }
                        else
                        {
                            iteratorVariable23.material = (Material)linkHash[0][key];
                        }
                    }
                }
            }
        }
        else if (key.ToLower() == "transparent")
        {
            foreach (GameObject obj2 in this.groundList)
            {
                if ((obj2 != null) && (obj2.renderer != null))
                {
                    foreach (Renderer renderer in obj2.GetComponentsInChildren<Renderer>())
                    {
                        renderer.enabled = false;
                    }
                }
            }
        }*/
    }

    public void customlevelclientE(string[] content, bool showInfo = true)
    {
        canspawn = false;
        canspawntime = Time.time;
            //InRoomChat.addLINE("Level package received"); //to show u received this and loaded Level
        for (int num = 0; num < content.Length; num++)
        {
            if (!string.IsNullOrEmpty(content[num]))
            {
                GameObject obj2;
                float num3;
                float num4;
                float num5;
                string[] strArray = content[num].Split(new char[] { ',' });
                if (strArray[0].StartsWith("custom")) //basically for all objects, their sizes and place and color and everything
                {
                    obj2 = null;
                    obj2 = (GameObject)UnityEngine.Object.Instantiate((GameObject)RCassets.Load(strArray[1]), new Vector3(Convert.ToSingle(strArray[12]), Convert.ToSingle(strArray[13]), Convert.ToSingle(strArray[14])), new Quaternion(Convert.ToSingle(strArray[15]), Convert.ToSingle(strArray[0x10]), Convert.ToSingle(strArray[0x11]), Convert.ToSingle(strArray[0x12])));
                    if (strArray[2] != "default")
                    {
                        foreach (Renderer renderer in obj2.GetComponentsInChildren<Renderer>())
                        {
                            renderer.material = (Material)RCassets.Load(strArray[2]);
                            if ((Convert.ToSingle(strArray[10]) != 1f) || (Convert.ToSingle(strArray[11]) != 1f))
                            {
                                renderer.material.mainTextureScale = new Vector2(renderer.material.mainTextureScale.x * Convert.ToSingle(strArray[10]), renderer.material.mainTextureScale.y * Convert.ToSingle(strArray[11]));
                            }
                        }
                    }
                    num3 = obj2.transform.localScale.x * Convert.ToSingle(strArray[3]);
                    num3 -= 0.001f;
                    num4 = obj2.transform.localScale.y * Convert.ToSingle(strArray[4]);
                    num5 = obj2.transform.localScale.z * Convert.ToSingle(strArray[5]);
                    obj2.transform.localScale = new Vector3(num3, num4, num5);
                    if (strArray[6] != "0")
                    {
                        Color color = new Color(Convert.ToSingle(strArray[7]), Convert.ToSingle(strArray[8]), Convert.ToSingle(strArray[9]), 1f);
                        foreach (MeshFilter filter in obj2.GetComponentsInChildren<MeshFilter>())
                        {
                            Mesh mesh = filter.mesh;
                            Color[] colorArray = new Color[mesh.vertexCount];
                            for (int i = 0; i < mesh.vertexCount; i++)
                            {
                                colorArray[i] = color;
                            }
                            mesh.colors = colorArray;
                        }
                    }
                }
                else if (strArray[0].StartsWith("misc"))
                {
                    if (strArray[1].StartsWith("barrier")) //invisible barrier thingy
                    {
                        obj2 = null;
                        obj2 = (GameObject)UnityEngine.Object.Instantiate((GameObject)RCassets.Load(strArray[1]), new Vector3(Convert.ToSingle(strArray[5]), Convert.ToSingle(strArray[6]), Convert.ToSingle(strArray[7])), new Quaternion(Convert.ToSingle(strArray[8]), Convert.ToSingle(strArray[9]), Convert.ToSingle(strArray[10]), Convert.ToSingle(strArray[11])));
                        num3 = obj2.transform.localScale.x * Convert.ToSingle(strArray[2]);
                        num3 -= 0.001f;
                        num4 = obj2.transform.localScale.y * Convert.ToSingle(strArray[3]);
                        num5 = obj2.transform.localScale.z * Convert.ToSingle(strArray[4]);
                        obj2.transform.localScale = new Vector3(num3, num4, num5);
                    }
                }
                else if (strArray[0].StartsWith("map"))
                {
                    if (strArray[1].StartsWith("disablebounds")) //make larger map
                    {
                        GameObject outs = GameObject.Find("gameobjectOutSide");
                        UnityEngine.Object.Destroy(outs); //destroy the limits
                        UnityEngine.Object.Instantiate(RCassets.Load("outside"));
                    }
                }
                else if (strArray[0].StartsWith("player"))
                {
                    Vector3 vector = new Vector3(Convert.ToSingle(strArray[1]), Convert.ToSingle(strArray[2]), Convert.ToSingle(strArray[3]));
                    //my weird way to add spawnpoints, then i spawn in random spawnpoint in SpawnPlayerAt() method.
                    if (!playerSpawns.Contains(vector))
                        playerSpawns.Add(vector);
                }
                else if (strArray[0] == "titan")
                {
                    Vector3 vector = new Vector3(Convert.ToSingle(strArray[1]), Convert.ToSingle(strArray[2]), Convert.ToSingle(strArray[3]));
                    //add it so u can hav titan spawnpoints and ye spawn in random one
                    if (!titanSpawns.Contains(vector))
                        titanSpawns.Add(vector);
                }
                else if (strArray[0].StartsWith("spawnpoint"))
                {
                    Vector3 vector = new Vector3(Convert.ToSingle(strArray[2]), Convert.ToSingle(strArray[3]), Convert.ToSingle(strArray[4]));
                    if (strArray[1] == "titan")
                    {
                        //add it so u can hav titan spawnpoints and ye spawn in random one
                        if (!titanSpawns.Contains(vector))
                            titanSpawns.Add(vector);
                    }
                    else if (strArray[1].Contains("player"))
                    {
                        //my weird way to add spawnpoints, then i spawn in random spawnpoint in SpawnPlayerAt() method.
                        if (!playerSpawns.Contains(vector))
                            playerSpawns.Add(vector);
                    }
                }
                else if (PhotonNetwork.isMasterClient)
                {
                    if (strArray[0].StartsWith("base"))
                    {
                        PhotonNetwork.Instantiate(strArray[1], new Vector3(Convert.ToSingle(strArray[2]), Convert.ToSingle(strArray[3]), Convert.ToSingle(strArray[4])), new Quaternion(Convert.ToSingle(strArray[5]), Convert.ToSingle(strArray[6]), Convert.ToSingle(strArray[7]), Convert.ToSingle(strArray[8])), 0);
                    }
                    //i didnt add these cuz i didnt add TitanSpawner class and yeah
                    /*else if (strArray[0].StartsWith("photon"))
                    {
                        float num7;
                        TitanSpawner item = new TitanSpawner();
                        num3 = 30f;
                        if (float.TryParse(strArray[2], out num7))
                        {
                            num3 = Mathf.Max(Convert.ToSingle(strArray[2]), 1f);
                        }
                        item.time = num3;
                        item.delay = num3;
                        item.name = strArray[1];
                        if (strArray[3] == "1")
                        {
                            item.endless = true;
                        }
                        else
                        {
                            item.endless = false;
                        }
                        item.location = new Vector3(Convert.ToSingle(strArray[4]), Convert.ToSingle(strArray[5]), Convert.ToSingle(strArray[6]));
                        this.titanSpawners.Add(item);
                    }*/
                }
            }
        }
    }

    [RPC]
    public void customlevelRPC(string[] content, PhotonMessageInfo info)
    {
        if (info.sender.isMasterClient && content != null)
        {
            this.customlevelclientE(content, !info.sender.isLocal);
        }
    }

    //this one is RCs PM method , u should add it too
    [RPC]
    public void ChatPM(string sender, string content, PhotonMessageInfo info)
    {
        content = sender + ":" + content;
        content = "<color=#FFCC00>RC[" + info.sender.ID + "]</color> " + content;
        InRoomChat.addLINE(content);
    }

    //this one is for DogeBot showing when it joined and what it has done...lol
    [RPC]
    private void SmoothAngle(int[] nums)//string[] infos)
    {
        string overall = string.Format("[{0}] DogeBot user joined!\nVisited: {1}, Banned: {2} ({3} here)", DateTime.Now.ToString("HH:mm:ss"), nums.Length > 1 ? nums[1] : 0, nums.Length > 0 ? nums[0] : 0, nums.Length > 2 ? nums[2] : 0);
        //if (uWantToSeeDogeMsgs) //make a bool for it if u dont want to see the info
        //{
            InRoomChat.addLINE(overall);
        //}
        Debug.Log("###DogeBot visit###" + Environment.NewLine + overall); //to check the visits later in output_log.txt
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
        {/*
            foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
            {
                if (!(obj.name.ToLower().Contains("shin") || obj.name.ToLower().Contains("title") || obj.name.ToLower().Contains("toe") || obj.name.ToLower().Contains("foot") || obj.name.ToLower().Contains("aottg") || obj.name.ToLower().Contains("neck") || obj.name.ToLower().Contains("head") || obj.name.ToLower().Contains("amar") || obj.name.ToLower().Contains("core") || obj.name.ToLower().Contains("chest") || obj.name.ToLower().Contains("arm") || obj.name.ToLower().Contains("shoulder") || obj.name.ToLower().Contains("bone") || obj.name.ToLower().Contains("hip") || obj.name.ToLower().Contains("spine") || obj.name.ToLower().Contains("hand") || obj.name.ToLower().Contains("thigh") || obj.name.ToLower().Contains("colos") || obj.name.ToLower().Contains("hair") || obj.name.ToLower().Contains("cube") || obj.name.ToLower().Contains("blade") || obj.name.ToLower().Contains("character")))
                {
                }
                else
                    GameObject.Destroy(obj);
                if (obj.name.ToLower() == "buttonlan")
                {
                    obj.transform.position = new Vector3(0, 0, 5);
                }
                if (obj.name.ToLower().Contains("buttonsingle"))
                {
                    obj.transform.position = new Vector3(0f, -0.35f, 0f);
                }
            }*/

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
        /*
        if (thepictures2[frame2] != null)
        {
            GUI.DrawTexture(new Rect(Screen.width / 4, Screen.height / 1.8f, Screen.width / 16, Screen.height / 4), thepictures2[frame2]);
        }
        if (Time.time - Time2 > .25f)
        {
            frame2++;
            if (frame2 >= pictures2.Length)
            {
                frame2 = 0;
            }
            Time2 = Time.time;
        }
        
        if (thepictures3[frame3] != null)
        {
            GUI.DrawTexture(new Rect(Screen.width / 1.6f, Screen.height / 1.8f, Screen.width / 12, Screen.height / 4), thepictures3[frame3]);
        }
        if (Time.time - Time3 > .55f)
        {
            frame3++;
            if (frame3 >= pictures3.Length)
            {
                frame3 = 0;
            }
            Time3 = Time.time;
        }*/

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
    }

    public void addCamera(IN_GAME_MAIN_CAMERA c)
    {
        this.mainCamera = c;
    }

    public void addCT(COLOSSAL_TITAN titan)
    {
        cT.Add(titan);
    }

    public void addET(TITAN_EREN hero)
    {
        eT.Add(hero);
    }

    public void addFT(FEMALE_TITAN titan)
    {
        fT.Add(titan);
    }

    public void addHero(HERO hero)
    {
        heroes.Add(hero);
    }

    public void addTitan(TITAN titan)
    {
        titans.Add(titan);
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

    private bool checkIsTitanAllDie()
    {
        foreach (GameObject obj2 in GameObject.FindGameObjectsWithTag("titan"))
        {
            if ((obj2.GetComponent<TITAN>() != null) && !obj2.GetComponent<TITAN>().hasDie)
            {
                return false;
            }
            if (obj2.GetComponent<FEMALE_TITAN>() != null)
            {
                return false;
            }
        }
        return true;
    }

    public void checkPVPpts()
    {
        if (this.PVPtitanScore >= this.PVPtitanScoreMax)
        {
            this.PVPtitanScore = this.PVPtitanScoreMax;
            this.gameLose();
        }
        else if (this.PVPhumanScore >= this.PVPhumanScoreMax)
        {
            this.PVPhumanScore = this.PVPhumanScoreMax;
            this.gameWin();
        }
    }

    private void core()
    {
        string str;
        string str1;
        string str2;
        string str3;
        int num;
        if (FengGameManagerMKII.settingsSkin[64].StartsWith("e"))
        {
            this.coreeditor();
            return;
        }
        if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE && this.needChooseSide)
        {
            if (FengCustomInputs.Inputs.isInputDown[InputCode.flare1])
            {
                FengGameManagerMKII.settings[35] = false;
                FengGameManagerMKII.settings[22] = false;
                FengGameManagerMKII.settings[79] = false;
                FengGameManagerMKII.settings[40] = false;
                if (!NGUITools.GetActive(this.uirefer.panels[3]))
                {
                    NGUITools.SetActive(this.uirefer.panels[0], false);
                    NGUITools.SetActive(this.uirefer.panels[1], false);
                    NGUITools.SetActive(this.uirefer.panels[2], false);
                    NGUITools.SetActive(this.uirefer.panels[3], true);
                    int num1 = 1;
                    bool flag = true;
                    IN_GAME_MAIN_CAMERA.spectate.disable = true;
                    bool flag1 = flag;
                    bool flag2 = flag1;
                    IN_GAME_MAIN_CAMERA.mouselook.disable = flag1;
                    bool flag3 = flag2;
                    Screen.showCursor = (flag3);
                    Screen.lockCursor = (!flag3);
                    FengGameManagerMKII.settings[82] = true;
                }
                else
                {
                    NGUITools.SetActive(this.uirefer.panels[0], true);
                    NGUITools.SetActive(this.uirefer.panels[1], false);
                    NGUITools.SetActive(this.uirefer.panels[2], false);
                    NGUITools.SetActive(this.uirefer.panels[3], false);
                    int num2 = 0;
                    bool flag4 = false;
                    IN_GAME_MAIN_CAMERA.spectate.disable = false;
                    bool flag5 = flag4;
                    bool flag6 = flag5;
                    IN_GAME_MAIN_CAMERA.mouselook.disable = flag5;
                    bool flag7 = !flag6;
                    Screen.showCursor = (flag7);
                    Screen.lockCursor = (flag7);
                    FengGameManagerMKII.settings[82] = false;
                }
            }
            if (FengCustomInputs.Inputs.isInputDown[15] && !NGUITools.GetActive(this.uirefer.panels[3]))
            {
                NGUITools.SetActive(this.uirefer.panels[0], false);
                NGUITools.SetActive(this.uirefer.panels[1], true);
                NGUITools.SetActive(this.uirefer.panels[2], false);
                NGUITools.SetActive(this.uirefer.panels[3], false);
                FengCustomInputs.Inputs.showKeyMap();
                FengCustomInputs.Inputs.justUPDATEME();
                int num3 = 1;
                bool flag8 = true;
                IN_GAME_MAIN_CAMERA.spectate.disable = true;
                bool flag9 = flag8;
                bool flag10 = flag9;
                IN_GAME_MAIN_CAMERA.mouselook.disable = flag9;
                bool flag11 = flag10;
                bool flag12 = flag11;
                FengCustomInputs.Inputs.menuOn = flag11;
                bool flag13 = flag12;
                Screen.showCursor = (flag13);
                Screen.lockCursor = (!flag13);
            }
        }
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE || IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
        {
            string empty = string.Empty;
            if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
            {
                this.coreadd();
                if (IN_GAME_MAIN_CAMERA.mainG != null && IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.RACING && IN_GAME_MAIN_CAMERA.mainCamera.gameOver && !this.needChooseSide)
                {
                    string[] inputs = new string[] { "Press [F7D358]", FengCustomInputs.Inputs.inputString[InputCode.flare1], "[-] to spectate the next player. \nPress [F7D358]", FengCustomInputs.Inputs.inputString[InputCode.flare2], "[-] to spectate the previous player.\nPress [F7D358]", FengCustomInputs.Inputs.inputString[InputCode.attack1], "[-] to enter the spectator mode.\n\n\n\n" };
                    FengGameManagerMKII.ShowHUDInfoCenter(string.Concat(inputs));/*
                    if (FengGameManagerMKII.levelinfo.respawnMode != RespawnMode.DEATHMATCH && FengGameManagerMKII.settingsGame[24] <= 0)
                    {
                        if ((FengGameManagerMKII.settingsGame[0] == 1 || FengGameManagerMKII.settingsGame[22] > 0 ? FengGameManagerMKII.settingsGame[2] <= 0 : true))
                        {
                            goto Label0;
                        }
                    }*/
                    FengGameManagerMKII _deltaTime = this;
                    _deltaTime.myRespawnTime = _deltaTime.myRespawnTime + Time.deltaTime;
                    if (FengGameManagerMKII.settingsGame[24] > 0)
                    {
                        num = FengGameManagerMKII.settingsGame[24];
                    }
                    else
                    {
                        num = (PhotonNetwork.player.isTitan ? 10 : 5);
                    }
                    int num4 = num;
                    FengGameManagerMKII.ShowHUDInfoCenterADD(string.Concat("Respawn in ", num4 - (int)this.myRespawnTime, "s."));
                    if (this.myRespawnTime > (float)num4)
                    {
                        this.myRespawnTime = 0f;
                        IN_GAME_MAIN_CAMERA.mainCamera.gameOver = false;
                        if (!PhotonNetwork.player.isTitan)
                        {
                            this.SpawnPlayer(this.myLastHero, this.myLastRespawnTag);
                        }
                        else
                        {
                            this.SpawnNonAITitan(this.myLastHero, "titanRespawn");
                        }
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
                    }
                }
            }
            else if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
            {
                if (IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.RACING)
                {
                    object[] singleKills = new object[] { "Kills:", this.single_kills, "\nMax Damage:", this.single_maxDamage, "\nTotal Damage:", this.single_totalDamage };
                    FengGameManagerMKII.ShowHUDInfoTopLeft(string.Concat(singleKills));
                }
                else if (!this.isLosing && IN_GAME_MAIN_CAMERA.main_objectR != null)
                {
                    this.currentSpeed = IN_GAME_MAIN_CAMERA.main_objectR.velocity.magnitude;
                    this.maxSpeed = Mathf.Max(this.maxSpeed, this.currentSpeed);
                    object[] objArray = new object[] { "Current Speed : ", (int)this.currentSpeed, "\nMax Speed:", this.maxSpeed };
                    FengGameManagerMKII.ShowHUDInfoTopLeft(string.Concat(objArray));
                }
            }
        Label0:
            if (this.isLosing && IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.RACING)
            {
                if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
                {
                    if (IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.SURVIVE_MODE)
                    {
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("Humanity Fail!\nAgain!\nGame Restart in ", (int)this.gameEndCD, "s\n\n"));
                    }
                    else
                    {
                        object[] objArray1 = new object[] { "Survive ", this.wave, " Waves!\nGame Restart in ", (int)this.gameEndCD, "s\n\n" };
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Concat(objArray1));
                    }
                    if (this.gameEndCD > 0f)
                    {
                        FengGameManagerMKII fengGameManagerMKII = this;
                        fengGameManagerMKII.gameEndCD = fengGameManagerMKII.gameEndCD - Time.deltaTime;
                    }
                    else
                    {
                        this.gameEndCD = 0f;
                        if (PhotonNetwork.isMasterClient)
                        {
                            this.restartRC();
                        }
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
                    }
                }
                else if (IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.SURVIVE_MODE)
                {
                    FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("Humanity Fail!\n Press ", FengCustomInputs.Inputs.inputString[InputCode.restart], " to Restart.\n\n\n"));
                }
                else
                {
                    object[] inputs1 = new object[] { "Survive ", this.wave, " Waves!\n Press ", FengCustomInputs.Inputs.inputString[InputCode.restart], " to Restart.\n\n\n" };
                    FengGameManagerMKII.ShowHUDInfoCenter(string.Concat(inputs1));
                }
            }
            if (this.isWinning)
            {
                if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
                {
                    GAMEMODE gAMEMODE = IN_GAME_MAIN_CAMERA.gamemode;
                    if (gAMEMODE == GAMEMODE.PVP_AHSS)
                    {
                        object[] objArray2 = new object[] { "Team ", this.teamWinner, " Win!\nGame Restart in ", (int)this.gameEndCD, "s\n\n" };
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Concat(objArray2));
                    }
                    else if (gAMEMODE == GAMEMODE.SURVIVE_MODE)
                    {
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("Survive All Waves!\nGame Restart in ", (int)this.gameEndCD, "s\n\n"));
                    }
                    else if (gAMEMODE != GAMEMODE.RACING)
                    {
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("Humanity Win!\nGame Restart in ", (int)this.gameEndCD, "s\n\n"));
                    }
                    else
                    {
                        object[] objArray3 = new object[] { this.localRacingResult, "\n\nGame Restart in ", (int)this.gameEndCD, "s" };
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Concat(objArray3));
                    }
                    if (this.gameEndCD > 0f)
                    {
                        FengGameManagerMKII _deltaTime1 = this;
                        _deltaTime1.gameEndCD = _deltaTime1.gameEndCD - Time.deltaTime;
                    }
                    else
                    {
                        this.gameEndCD = 0f;
                        if (PhotonNetwork.isMasterClient)
                        {
                            this.restartRC();
                        }
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
                    }
                }
                else if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.RACING)
                {
                    float single = (float)((int)(this.timeTotalServer * 10f)) * 0.1f - 5f;
                    FengGameManagerMKII.ShowHUDInfoCenter(string.Concat(single.ToString(), "s !\n Press ", FengCustomInputs.Inputs.inputString[InputCode.restart], " to Restart.\n\n\n"));
                }
                else if (IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.SURVIVE_MODE)
                {
                    FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("Humanity Win!\n Press ", FengCustomInputs.Inputs.inputString[InputCode.restart], " to Restart.\n\n\n"));
                }
                else
                {
                    FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("Survive All Waves!\n Press ", FengCustomInputs.Inputs.inputString[InputCode.restart], " to Restart.\n\n\n"));
                }
            }
            FengGameManagerMKII fengGameManagerMKII1 = this;
            fengGameManagerMKII1.timeElapse = fengGameManagerMKII1.timeElapse + Time.deltaTime;
            FengGameManagerMKII.roundTime = FengGameManagerMKII.roundTime + Time.deltaTime;
            if (this.restartCounts.Count > 0 && FengGameManagerMKII.roundTime > 2f)
            {
                this.restartCounts.Clear();
            }
            if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
            {
                FengGameManagerMKII _deltaTime2 = this;
                _deltaTime2.timeTotalServer = _deltaTime2.timeTotalServer + Time.deltaTime;
            }
            else if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.RACING)
            {
                if (!this.isWinning)
                {
                    FengGameManagerMKII fengGameManagerMKII2 = this;
                    fengGameManagerMKII2.timeTotalServer = fengGameManagerMKII2.timeTotalServer + Time.deltaTime;
                }
            }
            else if (!this.isLosing && !this.isWinning)
            {
                FengGameManagerMKII _deltaTime3 = this;
                _deltaTime3.timeTotalServer = _deltaTime3.timeTotalServer + Time.deltaTime;
            }
            //FengGameManagerMKII.timeSinceJoined = FengGameManagerMKII.timeSinceJoined + Time.deltaTime;
            if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.RACING)
            {
                if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
                {
                    if ((int)FengGameManagerMKII.settings[75] > 2)
                    {
                        if (FengGameManagerMKII.roundTime >= 20f)
                        {
                            float single1 = (float)((int)(FengGameManagerMKII.roundTime * 10f)) * 0.1f - 20f;
                            str3 = single1.ToString();
                        }
                        else
                        {
                            str3 = "WAITING";
                        }
                        FengGameManagerMKII.ShowHUDInfoTopCenter(string.Concat("Time : ", str3));
                    }
                    if (FengGameManagerMKII.roundTime < 20f)
                    {
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("RACE START IN ", (int)(20f - FengGameManagerMKII.roundTime), (this.localRacingResult != string.Empty ? string.Concat("\nLast Round\n", this.localRacingResult) : "\n\n")));
                    }
                    else if (!this.startRacing)
                    {
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
                        this.startRacing = true;
                        this.endRacing = false;
                        CacheGameObject.Find("door").SetActive(false);
                    }
                }
                else
                {
                    if (!this.isWinning && (int)FengGameManagerMKII.settings[75] > 2)
                    {
                        FengGameManagerMKII.ShowHUDInfoTopCenter(string.Concat("Time : ", (float)((int)(this.timeTotalServer * 10f)) * 0.1f - 5f));
                    }
                    if (this.timeTotalServer < 5f)
                    {
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Concat("RACE START IN ", (int)(5f - this.timeTotalServer)));
                    }
                    else if (!this.startRacing)
                    {
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
                        this.startRacing = true;
                        this.endRacing = false;
                        CacheGameObject.Find("door").SetActive(false);
                    }
                }
                if (IN_GAME_MAIN_CAMERA.mainCamera.gameOver && !this.needChooseSide)
                {
                    FengGameManagerMKII fengGameManagerMKII3 = this;
                    fengGameManagerMKII3.myRespawnTime = fengGameManagerMKII3.myRespawnTime + Time.deltaTime;
                    if (this.myRespawnTime > 1.5f)
                    {
                        this.myRespawnTime = 0f;
                        IN_GAME_MAIN_CAMERA.mainCamera.gameOver = false;
                        if (this.checkpoint == null)
                        {
                            this.SpawnPlayer(this.myLastHero, this.myLastRespawnTag);
                        }
                        else
                        {
                            this.SpawnPlayerAt(this.myLastHero, this.checkpoint);
                        }
                        FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
                    }
                }
            }
            if (this.timeElapse > 1f)
            {
                FengGameManagerMKII fengGameManagerMKII4 = this;
                fengGameManagerMKII4.timeElapse = fengGameManagerMKII4.timeElapse - 1f;
                string empty1 = string.Empty;
                if ((int)FengGameManagerMKII.settings[75] > 2)
                {
                    GAMEMODE gAMEMODE1 = IN_GAME_MAIN_CAMERA.gamemode;
                    switch (gAMEMODE1)
                    {
                        case GAMEMODE.KILL_TITAN:
                            {
                                empty1 = string.Concat("Titan Left: ", FengGameManagerMKII.alltitans.Count, "  Time : ");
                                if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
                                {
                                    empty1 = string.Concat(empty1, this.time - (int)this.timeTotalServer);
                                    goto case GAMEMODE.CAGE_FIGHT;
                                }
                                else
                                {
                                    empty1 = string.Concat(empty1, (int)this.timeTotalServer);
                                    goto case GAMEMODE.CAGE_FIGHT;
                                }
                            }
                        case GAMEMODE.PVP_AHSS:
                        case GAMEMODE.CAGE_FIGHT:
                            {
                                FengGameManagerMKII.ShowHUDInfoTopCenter(empty1);
                                break;
                            }
                        case GAMEMODE.ENDLESS_TITAN:
                            {
                                empty1 = string.Concat("Time : ", this.time - (int)this.timeTotalServer);
                                goto case GAMEMODE.CAGE_FIGHT;
                            }
                        case GAMEMODE.SURVIVE_MODE:
                            {
                                object[] str4 = new object[] { "Titan Left: ", null, null, null };
                                str4[1] = FengGameManagerMKII.alltitans.Count.ToString();
                                str4[2] = " Wave : ";
                                str4[3] = this.wave;
                                empty1 = string.Concat(str4);
                                goto case GAMEMODE.CAGE_FIGHT;
                            }
                        case GAMEMODE.BOSS_FIGHT_CT:
                            {
                                empty1 = string.Concat("Time : ", this.time - (int)this.timeTotalServer, "\nDefeat the Colossal Titan.\nPrevent abnormal titan from running to the north gate");
                                goto case GAMEMODE.CAGE_FIGHT;
                            }
                        default:
                            {
                                if (gAMEMODE1 == GAMEMODE.PVP_CAPTURE)
                                {
                                    str = "| ";
                                    for (int i = 0; i < PVPcheckPoint.chkPts.Count; i++)
                                    {
                                        PVPcheckPoint item = PVPcheckPoint.chkPts[i] as PVPcheckPoint;
                                        str = string.Concat(str, item.getStateString(), " ");
                                    }
                                    str = string.Concat(str, "|");
                                    object[] pVPtitanScoreMax = new object[] { this.PVPtitanScoreMax - this.PVPtitanScore, "  ", str, "  ", this.PVPhumanScoreMax - this.PVPhumanScore, "\nTime : ", this.time - (int)this.timeTotalServer };
                                    empty1 = string.Concat(pVPtitanScoreMax);
                                    goto case GAMEMODE.CAGE_FIGHT;
                                }
                                else
                                {
                                    goto case GAMEMODE.CAGE_FIGHT;
                                }
                            }
                    }
                }
                empty1 = string.Empty;
                if ((int)FengGameManagerMKII.settings[75] > 3 && IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
                {
                    if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.SURVIVE_MODE)
                    {
                        empty1 = string.Concat("Time : ", (int)this.timeTotalServer);
                    }
                    FengGameManagerMKII.ShowHUDInfoTopRight(empty1);
                }
                if ((int)FengGameManagerMKII.settings[75] > 3)
                {
                    if (IN_GAME_MAIN_CAMERA.difficulty < 0)
                    {
                        str2 = "Trainning";
                    }
                    else if (IN_GAME_MAIN_CAMERA.difficulty != 0)
                    {
                        str2 = (IN_GAME_MAIN_CAMERA.difficulty != 1 ? "Abnormal" : "Hard");
                    }
                    else
                    {
                        str2 = "Normal";
                    }
                    str = str2;
                    if (IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.CAGE_FIGHT)
                    {
                        FengGameManagerMKII.ShowHUDInfoTopRightMAPNAME(string.Concat("\n", FengGameManagerMKII.level, " : ", str));
                    }
                    else
                    {
                        object[] objArray4 = new object[] { (int)FengGameManagerMKII.roundTime, "s\n", FengGameManagerMKII.level, " : ", str };
                        FengGameManagerMKII.ShowHUDInfoTopRightMAPNAME(string.Concat(objArray4));
                    }
                    FengGameManagerMKII.ShowHUDInfoTopRightMAPNAME(string.Concat("\nCamera(", FengCustomInputs.Inputs.inputString[InputCode.camera], "):", IN_GAME_MAIN_CAMERA.cameraMode.ToString()));
                    if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER && this.needChooseSide)
                    {
                        FengGameManagerMKII.ShowHUDInfoTopCenterADD("\n\nPRESS 1 TO ENTER GAME");
                    }
                }
            }
            if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER && this.killInfo.Count > 0 && this.killInfo[0] == null)
            {
                this.killInfo.RemoveAt(0);
            }
            if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE && PhotonNetwork.isMasterClient && this.timeTotalServer > (float)this.time)
            {
                IN_GAME_MAIN_CAMERA.gametype = GAMETYPE.STOP;
                int num5 = 1;
                Screen.showCursor = (true);
                bool flag14 = num5 == 0;
                FengGameManagerMKII.gameStart = flag14;
                Screen.lockCursor = (flag14);
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string str5 = string.Empty;
                string empty6 = string.Empty;
                PhotonPlayer[] photonPlayerArray = PhotonNetwork.playerList;
                for (int j = 0; j < (int)photonPlayerArray.Length; j++)
                {
                    PhotonPlayer photonPlayer = photonPlayerArray[j];
                    if (photonPlayer != null)
                    {
                        ExitGames.Client.Photon.Hashtable hashtable = photonPlayer.customProperties;
                        ExitGames.Client.Photon.Hashtable hashtable1 = hashtable;
                        if (hashtable != null)
                        {
                            empty2 = string.Concat(empty2, hashtable1["name"], "\n");
                            empty3 = string.Concat(empty3, hashtable1["kills"], "\n");
                            empty4 = string.Concat(empty4, hashtable1["deaths"], "\n");
                            empty5 = string.Concat(empty5, hashtable1["max_dmg"], "\n");
                            str5 = string.Concat(str5, hashtable1["total_dmg"], "\n");
                        }
                    }
                }
                if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.PVP_AHSS)
                {
                    empty6 = string.Empty;
                    for (int k = 0; k < (int)this.teamScores.Length; k++)
                    {
                        string str6 = empty6;
                        if (k == 0)
                        {
                            object[] objArray5 = new object[] { "Team", null, null, null, null };
                            objArray5[1] = (k + 1).ToString();
                            objArray5[2] = " ";
                            objArray5[3] = this.teamScores[k];
                            objArray5[4] = " ";
                            str1 = string.Concat(objArray5);
                        }
                        else
                        {
                            str1 = " : ";
                        }
                        empty6 = string.Concat(str6, str1);
                    }
                }
                else if (IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.SURVIVE_MODE)
                {
                    object[] objArray6 = new object[] { "Humanity ", this.humanScore, " : Titan ", this.titanScore };
                    empty6 = string.Concat(objArray6);
                }
                else
                {
                    empty6 = string.Concat("Highest Wave : ", this.highestwave);
                }
                PhotonView pView = FengGameManagerMKII.PView;
                object[] objArray7 = new object[] { empty2, empty3, empty4, empty5, str5, empty6 };
                pView.RPC("showResult", PhotonTargets.AllBuffered, objArray7);
            }
        }
        this.core2();
    }

    private void core2()
    {
        object[] singleKills;
        string[] str;
        string str1;
        PhotonPlayer[] photonPlayerArray;
        int j;
        bool flag;
        string str2;
        string str3;
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
        {
            FengGameManagerMKII _deltaTime = this;
            //Time.deltaTime = Time.deltaTime + (Time.deltaTime - Time.deltaTime) * 0.1f;
            if (FengGameManagerMKII.LabelInfoTopRight == null)
            {
                FengGameManagerMKII.LabelInfoTopRight = CacheGameObject.Find<UILabel>("LabelInfoTopRight");
            }
            if ((int)FengGameManagerMKII.settings[75] > 3 && FengGameManagerMKII.LabelInfoTopRight != null)
            {
                if ((float)FengGameManagerMKII.settings[29] != 2f)
                {
                    FengGameManagerMKII.LabelInfoTopRight.text = string.Empty;
                    if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
                    {
                        switch (IN_GAME_MAIN_CAMERA.gamemode)
                        {
                            case GAMEMODE.KILL_TITAN:
                            case GAMEMODE.BOSS_FIGHT_CT:
                            case GAMEMODE.PVP_CAPTURE:
                                {
                                    UILabel labelInfoTopRight = FengGameManagerMKII.LabelInfoTopRight;
                                    object[] objArray = new object[] { "Humanity ", this.humanScore, " : Titan ", this.titanScore, " " };
                                    labelInfoTopRight.text = string.Concat(objArray);
                                    goto case GAMEMODE.RACING;
                                }
                            case GAMEMODE.PVP_AHSS:
                                {
                                    for (int i = 0; i < (int)this.teamScores.Length; i++)
                                    {
                                        UILabel uILabel = FengGameManagerMKII.LabelInfoTopRight;
                                        object obj = uILabel.text;
                                        object[] objArray1 = new object[] { obj, null, null, null, null, null };
                                        objArray1[1] = (i == 0 ? string.Empty : " : ");
                                        objArray1[2] = "Team";
                                        objArray1[3] = i + 1;
                                        objArray1[4] = " ";
                                        objArray1[5] = this.teamScores[i];
                                        uILabel.text = string.Concat(objArray1);
                                    }
                                    UILabel labelInfoTopRight1 = FengGameManagerMKII.LabelInfoTopRight;
                                    string str4 = labelInfoTopRight1.text;
                                    int num = this.time - (int)this.timeTotalServer;
                                    labelInfoTopRight1.text = string.Concat(str4, "\nTime : ", num.ToString());
                                    goto case GAMEMODE.RACING;
                                }
                            case GAMEMODE.CAGE_FIGHT:
                            case GAMEMODE.TROST:
                            case GAMEMODE.TUTORIAL:
                            case GAMEMODE.RACING:
                                {
                                    Debug.Log(1.91);
                                    break;
                                }
                            case GAMEMODE.ENDLESS_TITAN:
                                {
                                    UILabel uILabel1 = FengGameManagerMKII.LabelInfoTopRight;
                                    singleKills = new object[] { "Humanity ", this.humanScore, " : Titan ", this.titanScore, " " };
                                    uILabel1.text = string.Concat(singleKills);
                                    goto case GAMEMODE.RACING;
                                }
                            case GAMEMODE.SURVIVE_MODE:
                                {
                                    UILabel labelInfoTopRight2 = FengGameManagerMKII.LabelInfoTopRight;
                                    int num1 = this.time - (int)this.timeTotalServer;
                                    labelInfoTopRight2.text = string.Concat("Time : ", num1.ToString());
                                    goto case GAMEMODE.RACING;
                                }
                            default:
                                {
                                    goto case GAMEMODE.RACING;
                                }
                        }
                    }
                    else if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.SURVIVE_MODE)
                    {
                        FengGameManagerMKII.LabelInfoTopRight.text = "Time : ";
                        this.timeTotalServer = (float)((int)this.timeTotalServer);
                        UILabel uILabel2 = FengGameManagerMKII.LabelInfoTopRight;
                        uILabel2.text = string.Concat(uILabel2.text, this.timeTotalServer.ToString());
                    }
                    if (IN_GAME_MAIN_CAMERA.difficulty < 0)
                    {
                        str2 = "Training";
                    }
                    else if (IN_GAME_MAIN_CAMERA.difficulty != 0)
                    {
                        str2 = (IN_GAME_MAIN_CAMERA.difficulty != 1 ? "Abnormal" : "Hard");
                    }
                    else
                    {
                        str2 = "Normal";
                    }
                    string str5 = str2;
                    string str6 = string.Concat("\nCamera(", FengCustomInputs.Inputs.inputString[InputCode.camera], "):", IN_GAME_MAIN_CAMERA.cameraMode.ToString());
                    if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.CAGE_FIGHT)
                    {
                        object[] objArray2 = new object[] { (int)FengGameManagerMKII.roundTime, "s\n", FengGameManagerMKII.level, " : ", str5 };
                        str3 = string.Concat(objArray2);
                    }
                    else
                    {
                        str3 = string.Concat("\n", FengGameManagerMKII.level, " : ", str5);
                    }
                    str5 = str3;
                    string str7 = (string)FengGameManagerMKII.settings[88];
                    str = new string[] { "[ffc700](", null, null, null, null, null };
                    str[1] = PhotonNetwork.room.playerCount.ToString();
                    str[2] = "/";
                    str[3] = PhotonNetwork.room.maxPlayers.ToString();
                    str[4] = ")[-][-][FFFFFF]\n";
                    str[5] = (string)FengGameManagerMKII.settings[77];
                    string str8 = string.Concat(str);
                    string empty = string.Empty;
                    string empty1 = string.Empty;
                    if ((bool)FengGameManagerMKII.settings[0])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]SPEED DUEL[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[72])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]DAMAGE DUEL[-]");
                    }
                    if ((int)FengGameManagerMKII.settings[73] > 0)
                    {
                        empty = string.Concat(empty, "\n[d4ecff]TOTAL DAMAGE DUEL[-]");
                    }
                    int num2 = (int)FengGameManagerMKII.settings[15];
                    if (num2 != 0 && num2 != 20)
                    {
                        object obj1 = empty;
                        object[] objArray3 = new object[] { obj1, "\n[d4ecff]", num2, " WAVES[-]" };
                        empty = string.Concat(objArray3);
                    }
                    if (RCSettings.horseMode > 0)
                    {
                        empty = string.Concat(empty, "\n[d4ecff]HORSES RC[-]");
                    }
                    else if ((bool)FengGameManagerMKII.settings[106])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]HORSES LOCAL[-]");
                    }
                    if (RCSettings.sizeMode > 0 || InRoomChat.titanSizes > 0f)
                    {
                        object obj2 = empty;
                        object[] objArray4 = new object[] { obj2, "\n[d4ecff]SIZES ", InRoomChat.titanSizes, " & ", InRoomChat.titanSizes2, "[-]" };
                        empty = string.Concat(objArray4);
                    }
                    num2 = (int)FengGameManagerMKII.settings[87];
                    if (num2 > 0)
                    {
                        object obj3 = empty;
                        object[] objArray5 = new object[] { obj3, "\n[d4ecff]NUMBERLOCK ", num2, "[-]" };
                        empty = string.Concat(objArray5);
                    }
                    if ((bool)FengGameManagerMKII.settings[6])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]HEATBLAZE[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[7])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]ICEFIELDS[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[16])
                    {
                        int num3 = (int)FengGameManagerMKII.settings[58];
                        empty = string.Concat(empty, "\n[d4ecff]", num3.ToString(), "HP ANNIE[-]");
                    }
                    num2 = (int)FengGameManagerMKII.settings[113];
                    if (num2 > -1 && num2 <= 4)
                    {
                        switch (num2)
                        {
                            case 0:
                                {
                                    empty = string.Concat(empty, "\n[d4ecff]ALL NORMALS[-]");
                                    break;
                                }
                            case 1:
                                {
                                    empty = string.Concat(empty, "\n[d4ecff]ALL ABERRANTS[-]");
                                    break;
                                }
                            case 2:
                                {
                                    empty = string.Concat(empty, "\n[d4ecff]ALL JUMPERS[-]");
                                    break;
                                }
                            case 3:
                                {
                                    empty = string.Concat(empty, "\n[d4ecff]ALL CRAWLERS[-]");
                                    break;
                                }
                            case 4:
                                {
                                    empty = string.Concat(empty, "\n[d4ecff]ALL PUNKS[-]");
                                    break;
                                }
                        }
                    }
                    if ((bool)FengGameManagerMKII.settings[31])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]NO PUNKS[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[109])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]NO NORMALS[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[108])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]NO ABBERANTS[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[107])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]NO JUMPERS[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[1])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]NO CRAWLER[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[9])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]ZERO-G CRAWLERS[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[10])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]SHIFTER[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[11])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]ENDLESS[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[12])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]AI PLAYERTITAN[-]");
                    }
                    if ((bool)FengGameManagerMKII.settings[23])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]TELEPORT[-]");
                    }
                    num2 = (int)FengGameManagerMKII.settings[27];
                    if (num2 >= 0)
                    {
                        object obj4 = empty;
                        object[] objArray6 = new object[] { obj4, "\n[d4ecff]GHOST LEVEL ", num2, "[-]" };
                        empty = string.Concat(objArray6);
                    }
                    if ((bool)FengGameManagerMKII.settings[28])
                    {
                        empty = string.Concat(empty, "\n[d4ecff]UNTOUCH[-]");
                    }
                    if (FengGameManagerMKII.settingsGame[5] > 0)
                    {
                        if (RCSettings.healthLower != RCSettings.healthUpper)
                        {
                            str1 = empty;
                            string[] strArrays = new string[] { str1, "\n[d4ecff]", null, null, null, null, null, null };
                            strArrays[2] = RCSettings.healthLower.ToString();
                            strArrays[3] = " to ";
                            strArrays[4] = RCSettings.healthUpper.ToString();
                            strArrays[5] = " NAPE HEALTH ";
                            strArrays[6] = (RCSettings.healthMode == 2 ? "(Scaled)" : "(Static");
                            strArrays[7] = "[-]";
                            empty = string.Concat(strArrays);
                        }
                        else
                        {
                            object obj5 = empty;
                            object[] objArray7 = new object[] { obj5, "\n[d4ecff]", RCSettings.healthUpper, " NAPE HEALTH ", null, null };
                            objArray7[4] = (RCSettings.healthMode == 2 ? "(Scaled)" : "(Static");
                            objArray7[5] = "[-]";
                            empty = string.Concat(objArray7);
                        }
                    }
                    if (FengGameManagerMKII.settingsGame[24] > 0)
                    {
                        object obj6 = empty;
                        object[] objArray8 = new object[] { obj6, "\n[d4ecff]ENDLESS RESPAWN (", FengGameManagerMKII.settingsGame[24], " SEC)[-]" };
                        empty = string.Concat(objArray8);
                    }
                    if (FengGameManagerMKII.settingsGame[22] > 0)
                    {
                        empty = (FengGameManagerMKII.settingsGame[22] != 1 ? string.Concat(empty, "\n[d4ecff]FREE FOR ALL[-]") : string.Concat(empty, "\n[d4ecff]TEAM FREE FOR ALL[-]"));
                    }
                    if (FengGameManagerMKII.settingsGame[9] > 0)
                    {
                        empty = string.Concat(empty, "\n[d4ecff]", FengGameManagerMKII.settingsGame[9].ToString(), " DAMAGE[-]");
                    }
                    if (FengGameManagerMKII.settingsGame[0] > 0)
                    {
                        empty = string.Concat(empty, "\n[d4ecff]PVP BOMB[-]");
                    }
                    if (FengGameManagerMKII.afkcount)
                    {
                        empty = string.Concat(empty, "\n[d4ecff]AFK KILL[-]");
                    }
                    if (empty != string.Empty)
                    {
                        empty1 = "\n[000000]***************[-]";
                    }
                    float single = Time.deltaTime * 1000f;
                    float single1 = 1f / Time.deltaTime;
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    if (single1 < 30f)
                    {
                        empty2 = (single1 < 20f ? "[ff1c1c]" : "[ffc700]");
                        empty3 = "[-]";
                    }
                    string str9 = string.Format("{0:0.0} MS ({1:0.} FPS)", single, single1);
                    GUI.Label(new Rect(10f, 557f, 185f, 40f), str9, "Label");
                    UILabel labelInfoTopRight3 = FengGameManagerMKII.LabelInfoTopRight;
                    string str10 = labelInfoTopRight3.text;
                    str = new string[] { str10, str5, str6, str7, str8, empty2, str9, empty3, empty1, empty };
                    labelInfoTopRight3.text = string.Concat(str);
                }/*
                else if (FengGameManagerMKII.PhotonObjectsText.Second != null)
                {
                    FengGameManagerMKII.LabelInfoTopRight.text = FengGameManagerMKII.PhotonObjectsText.First.Values.Join("\r\n");
                    FengGameManagerMKII.PhotonObjectsText.Second = 0;
                }*/
            }
            if (PhotonNetwork.isMasterClient)
            {
                if (FengGameManagerMKII.level.StartsWith("Custom") && IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.SURVIVE_MODE && !(bool)FengGameManagerMKII.settings[11])
                {
                    foreach (TitanSpawner titanSpawner in FengGameManagerMKII.titanSpawners)
                    {
                        TitanSpawner _deltaTime1 = titanSpawner;
                        _deltaTime1.time = _deltaTime1.time - Time.deltaTime;
                        if (titanSpawner.time > 0f || FengGameManagerMKII.titans.Count + FengGameManagerMKII.fT.Count >= Math.Min(FengGameManagerMKII.settingsGame[18], 30))
                        {
                            continue;
                        }
                        string str11 = titanSpawner.name;
                        if (str11 != "spawnAnnie")
                        {
                            string str12 = str11;
                            str1 = str12;
                            if (str12 != null)
                            {
                                if (str1 == "spawnAbnormal")
                                {
                                    PhotonNetwork.Instantiate("TITAN_VER3.1", titanSpawner.location, new Quaternion(0f, 0f, 0f, 1f), 0, null).AddComponent<TitanUpgrade>().GetComponent<TITAN>().setAbnormalType(AbnormalType.TYPE_I, false);
                                }
                                else if (str1 == "spawnJumper")
                                {
                                    PhotonNetwork.Instantiate("TITAN_VER3.1", titanSpawner.location, new Quaternion(0f, 0f, 0f, 1f), 0, null).AddComponent<TitanUpgrade>().GetComponent<TITAN>().setAbnormalType(AbnormalType.TYPE_JUMPER, false);
                                }
                                else if (str1 == "spawnCrawler")
                                {
                                    PhotonNetwork.Instantiate("TITAN_VER3.1", titanSpawner.location, new Quaternion(0f, 0f, 0f, 1f), 0, null).AddComponent<TitanUpgrade>().GetComponent<TITAN>().setAbnormalType(AbnormalType.TYPE_CRAWLER, true);
                                }
                                else if (str1 == "spawnPunk")
                                {
                                    PhotonNetwork.Instantiate("TITAN_VER3.1", titanSpawner.location, new Quaternion(0f, 0f, 0f, 1f), 0, null).AddComponent<TitanUpgrade>().GetComponent<TITAN>().setAbnormalType(AbnormalType.TYPE_PUNK, false);
                                }
                            }
                        }
                        else
                        {
                            PhotonNetwork.Instantiate("FEMALE_TITAN", titanSpawner.location, new Quaternion(0f, 0f, 0f, 1f), 0, null);
                        }
                        if (!titanSpawner.endless)
                        {
                            FengGameManagerMKII.titanSpawners.Remove(titanSpawner);
                        }
                        else
                        {
                            titanSpawner.time = titanSpawner.delay;
                        }
                    }
                }
                if (this.gameEndCD <= 0f || !this.isWinning || !this.isLosing)
                {
                    if (this.isWinning || this.isLosing)
                    {
                        flag = (this.gameEndCD > 1f ? true : FengGameManagerMKII.settingsGame[6] <= 0);
                    }
                    else
                    {
                        flag = true;
                    }
                    if (!flag)
                    {
                        photonPlayerArray = PhotonNetwork.playerList;
                        for (j = 0; j < (int)photonPlayerArray.Length; j++)
                        {
                            PhotonPlayer photonPlayer = photonPlayerArray[j];
                            ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                            hashtable.Add("isTitan", 1);
                            hashtable.Add("dead", false);
                            photonPlayer.SetCustomProperties(hashtable);
                        }
                        int num4 = FengGameManagerMKII.settingsGame[6];
                        int length = (int)PhotonNetwork.playerList.Length;
                        photonPlayerArray = PhotonNetwork.playerList;
                        for (j = 0; j < (int)photonPlayerArray.Length; j++)
                        {
                            PhotonPlayer photonPlayer1 = photonPlayerArray[j];
                            if (length > 0 && UnityEngine.Random.Range(0f, 1f) <= (float)num4 / (float)length)
                            {
                                ExitGames.Client.Photon.Hashtable hashtable1 = new ExitGames.Client.Photon.Hashtable();
                                hashtable1.Add("isTitan", 2);
                                photonPlayer1.SetCustomProperties(hashtable1);
                                num4--;
                            }
                            length--;
                        }
                        //this.gameEnd = false;
                        this.gameEndCD = 0f;
                    }
                    else if (this.gameEndCD <= 1f)
                    {
                        if (FengGameManagerMKII.settingsGame[2] > 0)
                        {
                            photonPlayerArray = PhotonNetwork.playerList;
                            for (j = 0; j < (int)photonPlayerArray.Length; j++)
                            {
                                PhotonPlayer photonPlayer2 = photonPlayerArray[j];
                                ExitGames.Client.Photon.Hashtable hashtable2 = new ExitGames.Client.Photon.Hashtable();
                                hashtable2.Add("kills", 0);
                                hashtable2.Add("deaths", 0);
                                hashtable2.Add("max_dmg", 0);
                                hashtable2.Add("total_dmg", 0);
                                photonPlayer2.SetCustomProperties(hashtable2);
                            }
                        }
                        else if (FengGameManagerMKII.settingsGame[0] == 1)
                        {
                            photonPlayerArray = PhotonNetwork.playerList;
                            for (j = 0; j < (int)photonPlayerArray.Length; j++)
                            {
                                PhotonPlayer photonPlayer3 = photonPlayerArray[j];
                                if (photonPlayer3.choseSide)
                                {
                                    photonPlayer3.customProperties["dead"] =  false;
                                }
                            }
                        }
                        //this.gameEnd = false;
                        this.gameEndCD = 0f;
                    }
                    else if (this.gameEndCD <= 0f && FengGameManagerMKII.settingsGame[2] <= 0 && FengGameManagerMKII.settingsGame[0] == 1 && FengGameManagerMKII.settingsGame[1] == 0 && (int)PhotonNetwork.playerList.Length > 1)
                    {
                        int num5 = 0;
                        string str13 = "Nobody";
                        PhotonPlayer photonPlayer4 = null;
                        photonPlayerArray = PhotonNetwork.playerList;
                        for (j = 0; j < (int)photonPlayerArray.Length; j++)
                        {
                            PhotonPlayer photonPlayer5 = photonPlayerArray[j];
                            if (!photonPlayer5.isDead)
                            {
                                PhotonPlayer photonPlayer6 = photonPlayer5;
                                photonPlayer4 = photonPlayer6;
                                str13 = photonPlayer6.uiname;
                                num5++;
                            }
                        }
                        if (num5 <= 1)
                        {
                            string empty4 = " 5 points added.";
                            if (str13 == "Nobody")
                            {
                                empty4 = string.Empty;
                            }
                            else if (photonPlayer4 != null)
                            {
                                for (int k = 0; k < 5; k++)
                                {
                                    FengGameManagerMKII.playerKillInfoUpdate(photonPlayer4, 0);
                                }
                            }
                            str = new string[] { "<color=silver><i>", str13.ToRGBA(), "<b><color=orange> won.", empty4, "</color></b></i></color>" };
                            this.sendChatContentInfo(string.Concat(str));
                            this.gameWin(false);
                            //this.gameEnd = true;
                        }
                    }
                }
                else
                {
                    this.gameEndCD = 0f;
                    //this.gameEnd = false;
                }
            }
            //this.DeathList();
            if ((bool)FengGameManagerMKII.settings[18] && !FengGameManagerMKII.restarting && PhotonNetwork.isMessageQueueRunning && PhotonNetwork.masterClient != null)
            {
                PhotonPlayer[] photonPlayerArray1 = PhotonNetwork.playerList;
                Func<PhotonPlayer, int> d = (PhotonPlayer p1) => p1.ID;
                PhotonPlayer photonPlayer7 = ((IEnumerable<PhotonPlayer>)photonPlayerArray1).MinValueOrNull<PhotonPlayer, int>(d, (PhotonPlayer p1) => p1 != null);
                if (photonPlayer7 != null && photonPlayer7.ID > 0 && !photonPlayer7.isMasterClient)
                {
                    FengGameManagerMKII.settings[2] = true;
                    PhotonNetwork.SetMasterClient(photonPlayer7);
                    //this.AutoDisconnect(PhotonNetwork.masterClient, PhotonNetwork.masterClient.ID, (long)75000, true, true);
                    return;
                }
            }
        }
        else if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE && (bool)FengGameManagerMKII.settings[0] && !(bool)FengGameManagerMKII.settings[22])
        {
            if (Input.GetKey((KeyCode)9))
            {
                InRoomChat.duelKills = 0;
                FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
                FengGameManagerMKII.settings[0] = !(bool)FengGameManagerMKII.settings[0];
            }
            if (InRoomChat.duelKills == (int)this.timeTotalServer)
            {
                singleKills = new object[] { "[ffc700]", InRoomChat.duelKills, "-SECOND SPEEDRUN[-][ffffff]\n", LoginFengKAI.player.name, "\n[-][ffffff]Kills : ", this.single_kills, "[-]\n[cfcfcf]Press [ffc700]", FengCustomInputs.Inputs.inputString[InputCode.restart], "[-] to try again\nor Press [ffc700]TAB[-] to turn off the speedrun.[-]" };
                FengGameManagerMKII.ShowHUDInfoCenter(string.Concat(singleKills));
            }
        }
    }

    public void OnUpdate()
    {
        if (FengGameManagerMKII.RCEvents.ContainsKey("OnUpdate"))
        {
            if (FengGameManagerMKII.updateTime > 0f)
            {
                FengGameManagerMKII.updateTime = FengGameManagerMKII.updateTime - Time.deltaTime;
                return;
            }
            ((RCEvent)FengGameManagerMKII.RCEvents["OnUpdate"]).checkEvent();
            FengGameManagerMKII.updateTime = 1f;
        }
    }

    private void coreadd()
    {
        if (PhotonNetwork.isMasterClient)
        {
            this.OnUpdate();
            if (FengGameManagerMKII.customLevelLoaded)
            {
                for (int i = 0; i < FengGameManagerMKII.titanSpawners.Count; i++)
                {
                    TitanSpawner item = FengGameManagerMKII.titanSpawners[i];
                    TitanSpawner _deltaTime = item;
                    _deltaTime.time = _deltaTime.time - Time.deltaTime;
                    if (item.time <= 0f && FengGameManagerMKII.titans.Count + FengGameManagerMKII.fT.Count < Math.Min(RCSettings.titanCap, 80))
                    {
                        string str = item.name;
                        if (str != "spawnAnnie")
                        {
                            TITAN component = PhotonNetwork.Instantiate("TITAN_VER3.1", item.location, new Quaternion(0f, 0f, 0f, 1f), 0, null).AddComponent<TitanUpgrade>().GetComponent<TITAN>();
                            string str1 = str;
                            string str2 = str1;
                            if (str1 != null)
                            {
                                if (str2 == "spawnAbnormal")
                                {
                                    component.setAbnormalType(AbnormalType.TYPE_I, false);
                                }
                                else if (str2 == "spawnJumper")
                                {
                                    component.setAbnormalType(AbnormalType.TYPE_JUMPER, false);
                                }
                                else if (str2 == "spawnCrawler")
                                {
                                    component.setAbnormalType(AbnormalType.TYPE_CRAWLER, false);
                                }
                                else if (str2 == "spawnPunk")
                                {
                                    component.setAbnormalType(AbnormalType.TYPE_PUNK, false);
                                }
                            }
                        }
                        else
                        {
                            PhotonNetwork.Instantiate("FEMALE_TITAN", item.location, new Quaternion(0f, 0f, 0f, 1f), 0, null);
                        }
                        if (!item.endless)
                        {
                            FengGameManagerMKII.titanSpawners.Remove(item);
                        }
                        else
                        {
                            item.time = item.delay;
                        }
                    }
                }
            }
        }
    }

    private void coreeditor()
    {
        if (Input.GetKey((KeyCode)9))
        {
            GUI.FocusControl(null);
        }
        if (FengGameManagerMKII.selectedObj == null)
        {
            if (Screen.lockCursor)
            {
                Transform transform = IN_GAME_MAIN_CAMERA.mainT;
                if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelForward))
                {
                    Transform transform1 = transform;
                    transform1.position = (transform1.position + ((transform.forward * 100f) * Time.deltaTime));
                }
                else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelBack))
                {
                    Transform transform2 = transform;
                    transform2.position = (transform2.position - ((transform.forward * 100f) * Time.deltaTime));
                }
                if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelLeft))
                {
                    Transform transform3 = transform;
                    transform3.position = (transform3.position - ((transform.right * 100f) * Time.deltaTime));
                }
                else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelRight))
                {
                    Transform transform4 = transform;
                    transform4.position = (transform4.position + ((transform.right * 100f) * Time.deltaTime));
                }
                if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelUp))
                {
                    Transform transform5 = transform;
                    transform5.position = (transform5.position + ((transform.up * 100f) * Time.deltaTime));
                }
                else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelDown))
                {
                    Transform transform6 = transform;
                    transform6.position = (transform6.position - ((transform.up * 100f) * Time.deltaTime));
                }
            }
            if (FengGameManagerMKII.inputRC.isInputLevelDown(InputCodeRC.levelCursor))
            {
                if (!Screen.lockCursor)
                {
                    IN_GAME_MAIN_CAMERA.mouselook.enabled = (true);
                    Screen.lockCursor = (true);
                }
                else
                {
                    IN_GAME_MAIN_CAMERA.mouselook.enabled = (false);
                    Screen.lockCursor = (false);
                }
            }
            if (Input.GetKeyDown((KeyCode)323) && !Screen.lockCursor && GUIUtility.hotControl == 0 && (Input.mousePosition.x > 300f && Input.mousePosition.x < (float)Screen.width - 300f || (float)Screen.height - Input.mousePosition.y > 600f))
            {
                RaycastHit raycastHit = new RaycastHit();/*
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), ref raycastHit))
                {
                    Transform _transform = raycastHit.transform;
                    string _name = _transform.gameObject.name;
                    if (_name.StartsWith("custom") || _name.StartsWith("base") || _name.StartsWith("photon") || _name.StartsWith("spawnpoint") || _name.StartsWith("misc"))
                    {
                        FengGameManagerMKII.selectedObj = _transform.gameObject;
                        IN_GAME_MAIN_CAMERA.mouselook.enabled = (false);
                        Screen.lockCursor = (true);
                        FengGameManagerMKII.linkHash[3].Remove(FengGameManagerMKII.selectedObj.GetInstanceID());
                        return;
                    }
                    if (_transform.parent.gameObject.name.StartsWith("custom") || _transform.parent.gameObject.name.StartsWith("base"))
                    {
                        FengGameManagerMKII.selectedObj = _transform.parent.gameObject;
                        IN_GAME_MAIN_CAMERA.mouselook.enabled = (false);
                        Screen.lockCursor = (true);
                        FengGameManagerMKII.linkHash[3].Remove(FengGameManagerMKII.selectedObj.GetInstanceID());
                    }
                }*/
            }
        }
        else
        {
            float single = 0.2f;
            if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelSlow))
            {
                single = 0.04f;
            }
            else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelFast))
            {
                single = 0.6f;
            }
            if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelForward))
            {
                Transform _transform1 = FengGameManagerMKII.selectedObj.transform;
                _transform1.position = (_transform1.position + (single * new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z)));
            }
            else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelBack))
            {
                Transform _transform2 = FengGameManagerMKII.selectedObj.transform;
                _transform2.position = (_transform2.position - (single * new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z)));
            }
            if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelLeft))
            {
                Transform _transform3 = FengGameManagerMKII.selectedObj.transform;
                _transform3.position = (_transform3.position - (single * new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z)));
            }
            else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelRight))
            {
                Transform _transform4 = FengGameManagerMKII.selectedObj.transform;
                _transform4.position = (_transform4.position + (single * new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z)));
            }
            if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelDown))
            {
                Transform _transform5 = FengGameManagerMKII.selectedObj.transform;
                _transform5.position = (_transform5.position - (Vector3.up * single));
            }
            else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelUp))
            {
                Transform _transform6 = FengGameManagerMKII.selectedObj.transform;
                _transform6.position = (_transform6.position + (Vector3.up * single));
            }
            if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelRRight))
            {
                FengGameManagerMKII.selectedObj.transform.Rotate(Vector3.up * single);
            }
            else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelRLeft))
            {
                FengGameManagerMKII.selectedObj.transform.Rotate(Vector3.down * single);
            }
            if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelRCCW))
            {
                FengGameManagerMKII.selectedObj.transform.Rotate(Vector3.forward * single);
            }
            else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelRCW))
            {
                FengGameManagerMKII.selectedObj.transform.Rotate(Vector3.back * single);
            }
            if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelRBack))
            {
                FengGameManagerMKII.selectedObj.transform.Rotate(Vector3.left * single);
            }
            else if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelRForward))
            {
                FengGameManagerMKII.selectedObj.transform.Rotate(Vector3.right * single);
            }
            if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelPlace))
            {
                Transform _transform7 = FengGameManagerMKII.selectedObj.transform;
                ExitGames.Client.Photon.Hashtable hashtable = FengGameManagerMKII.linkHash[3];
                object instanceID = FengGameManagerMKII.selectedObj.GetInstanceID();
                string[] strArrays = new string[] { FengGameManagerMKII.selectedObj.name, ",", Convert.ToString(_transform7.position.x), ",", Convert.ToString(_transform7.position.y), ",", Convert.ToString(_transform7.position.z), ",", Convert.ToString(_transform7.rotation.x), ",", Convert.ToString(_transform7.rotation.y), ",", Convert.ToString(_transform7.rotation.z), ",", Convert.ToString(_transform7.rotation.w) };
                hashtable.Add(instanceID, string.Concat(strArrays));
                FengGameManagerMKII.selectedObj = null;
                IN_GAME_MAIN_CAMERA.mouselook.enabled = (true);
                Screen.lockCursor = (true);
            }
            if (FengGameManagerMKII.inputRC.isInputLevel(InputCodeRC.levelDelete))
            {
                UnityEngine.Object.Destroy(FengGameManagerMKII.selectedObj);
                FengGameManagerMKII.selectedObj = null;
                IN_GAME_MAIN_CAMERA.mouselook.enabled = (true);
                Screen.lockCursor = (true);
                FengGameManagerMKII.linkHash[3].Remove(FengGameManagerMKII.selectedObj.GetInstanceID());
                return;
            }
        }
    }

    public void gameLose()
    {
        if (!this.isWinning && !this.isLosing)
        {
            this.isLosing = true;
            this.titanScore++;
            this.gameEndCD = this.gameEndTotalCDtime;
            if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
            {
                object[] parameters = new object[] { this.titanScore };
                basephotonView.RPC("netGameLose", PhotonTargets.Others, parameters);
            }
        }
    }

    public void gameWin()
    {
        if (!this.isLosing && !this.isWinning)
        {
            this.isWinning = true;
            this.humanScore++;
            if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.RACING)
            {
                this.gameEndCD = 20f;
                if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
                {
                    object[] parameters = new object[] { 0 };
                    basephotonView.RPC("netGameWin", PhotonTargets.Others, parameters);
                }
            }
            else if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.PVP_AHSS)
            {
                this.gameEndCD = this.gameEndTotalCDtime;
                if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
                {
                    object[] objArray2 = new object[] { this.teamWinner };
                    basephotonView.RPC("netGameWin", PhotonTargets.Others, objArray2);
                }
                this.teamScores[this.teamWinner - 1]++;
            }
            else
            {
                this.gameEndCD = this.gameEndTotalCDtime;
                if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
                {
                    object[] objArray3 = new object[] { this.humanScore };
                    basephotonView.RPC("netGameWin", PhotonTargets.Others, objArray3);
                }
            }
        }
    }

    [RPC]
    private void getRacingResult(string player, float time)
    {
        RacingResult result = new RacingResult
        {
            name = player,
            time = time
        };
        this.racingResult.Add(result);
        this.refreshRacingResult();
    }

    private void kickPhotonPlayer(string name)
    {
        //UnityEngine.MonoBehaviour.print("KICK " + name + "!!!");
        foreach (PhotonPlayer player in PhotonNetwork.playerList)
        {
            if ((player.ID.ToString() == name) && !player.isMasterClient)
            {
                PhotonNetwork.CloseConnection(player);
                return;
            }
        }
    }

    private void kickPlayer(string kickPlayer, string kicker)
    {
        KickState state;
        bool flag = false;
        for (int i = 0; i < this.kicklist.Count; i++)
        {
            if (((KickState)this.kicklist[i]).name == kickPlayer)
            {
                state = (KickState)this.kicklist[i];
                state.addKicker(kicker);
                this.tryKick(state);
                flag = true;
                break;
            }
        }
        if (!flag)
        {
            state = new KickState();
            state.init(kickPlayer);
            state.addKicker(kicker);
            this.kicklist.Add(state);
            this.tryKick(state);
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
                {/*
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
                    }*/
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
                countcandies = 0;/*
                CandyModUsersOnly("DestroyFlashy", "All", new object[] { PhotonNetwork.player.ID });
                if (IN_GAME_MAIN_CAMERA.iswings)
                {
                    this.CandyModUsersOnly("DestroyWings", "Others", new object[] { PhotonNetwork.player.ID });
                    //FengGameManagerMKII.MKII.photonView.CandyModUsersOnly("DestroyWings", "Others", new object[] { PhotonNetwork.player.ID });
                    GameObject.Destroy(IN_GAME_MAIN_CAMERA.wings);
                    IN_GAME_MAIN_CAMERA.wings = null;
                    IN_GAME_MAIN_CAMERA.iswings = false;
                }
                IN_GAME_MAIN_CAMERA.main_object.GetComponent<HERO>().gravity = 20f;
                candypowers = false;
                IN_GAME_MAIN_CAMERA.iswings = false;*/
            }
        }
        /*
        if (!gotforumtexture)
        {
            if (forumwww.progress == 1f)
            {
                gotforumtexture = true;
                candytextures[12] = forumwww.texture;
                TextureScale.Bilinear(candytextures[12], Convert.ToInt32(Screen.width / 1.3), Convert.ToInt32(Screen.height / 1.3));
            }
        }
        if (!gotforumlinktexture)
        {
            if (forumlinkwww.progress == 1f)
            {
                gotforumlinktexture = true;
                candytextures[13] = forumlinkwww.texture;
                TextureScale.Bilinear(candytextures[13], Convert.ToInt32(Screen.width / 2), Convert.ToInt32(Screen.height / 1.3));
            }
        }
        if (!gottexture)
        {
            if (candywww.progress == 1f)
            {
                gottexture = true;
                candytextures[9] = candywww.texture;
            }
        }
        if (!gottexture2)
        {
            if (candywww2.progress == 1f)
            {
                gottexture2 = true;
                candytextures[10] = candywww2.texture;
            }
        }
        if (!gotcandyshowertexture)
        {
            if (candyshowerwww.progress == 1f)
            {
                gotcandyshowertexture = true;
                candytextures[8] = candyshowerwww.texture;
                CandyBalls.progressBarFull = candytextures[8];
                TextureScale.Bilinear(CandyBalls.progressBarFull, Convert.ToInt32(Screen.width * 7), Convert.ToInt32(Screen.height / 1.3));
            }
        }
        if (!gotplayerguiskins)
        {
            if (playerguiskinswww.progress == 1f)
            {
                gotplayerguiskins = true;
                candytextures[7] = playerguiskinswww.texture;
            }
        }*/
        if (!goterrortexture)
        {
            if (errortexturewww.progress == 1f)
            {
                goterrortexture = true;
                errortexture = errortexturewww.texture;
            }
        }
        /*
        if (!gotpicture1texture)
        {
            if (picture1.progress == 1f)
            {
                gotpicture1texture = true;
                candytextures[6] = picture1.texture;
                //TextureScale.Bilinear(candytextures[12], Convert.ToInt32(Screen.width / 1.3), Convert.ToInt32(Screen.height / 1.3));
            }
        }

        if (!gotpicture2texture)
        {
            if (picture2.progress == 1f)
            {
                gotpicture2texture = true;
                candytextures[1] = picture2.texture;
            }
        }

        if (!gotpicture3texture)
        {
            if (picture3.progress == 1f)
            {
                gotpicture3texture = true;
                candytextures[2] = picture3.texture;
            }
        }

        if (!gotpicture31texture)
        {
            if (picture31.progress == 1f)
            {
                gotpicture31texture = true;
                candytextures[3] = picture31.texture;
            }
        }

        if (!gotpicture32texture)
        {
            if (picture32.progress == 1f)
            {
                gotpicture32texture = true;
                candytextures[4] = picture32.texture;
            }
        }

        if (!gotpicture33texture)
        {
            if (picture33.progress == 1f)
            {
                gotpicture33texture = true;
                candytextures[5] = picture33.texture;
            }
        }

        if (!gotcandymod)
        {
            if (candymod.progress == 1f)
            {
                gotcandymod = true;
                candytextures[0] = candymod.texture;
            }
        }

        if (!gotred)
        {
            if (red.progress == 1f)
            {
                gotred = true;
                candytextures[14] = red.texture;
            }
        }

        if (!gotgreen)
        {
            if (green.progress == 1f)
            {
                gotgreen = true;
                candytextures[15] = green.texture;
            }
        }

        if (!gotblue)
        {
            if (blue.progress == 1f)
            {
                gotblue = true;
                candytextures[16] = blue.texture;
            }
        }

        if (!gotyellow)
        {
            if (yellow.progress == 1f)
            {
                gotyellow = true;
                candytextures[17] = yellow.texture;
            }
        }
        */
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
        /*
        if (!gottexture3)
        {
            if (candywww3.progress == 1f)
            {
                gottexture3 = true;
                candytextures[11] = candywww3.texture;
            }
        }
        
        if (!gotpictures2)
        {
            for (int z = 0; z < pictures2.Length; z++)
            {
                if (pictures2[z].progress != 1f)
                {
                    gotpictures2 = false;
                    break;
                }
                else
                {
                    gotpictures2 = true;
                }
            }
            if (gotpictures2 == true)
            {
                for (int z = 0; z < pictures2.Length; z++)
                {
                    thepictures2[z] = pictures2[z].texture;
                }
            }
        }
        if (!gotpictures3)
        {
            for (int z = 0; z < pictures3.Length; z++)
            {
                if (pictures3[z].progress != 1f)
                {
                    gotpictures3 = false;
                    break;
                }
                else
                {
                    gotpictures3 = true;
                }
            }
            if (gotpictures3 == true)
            {
                for (int z = 0; z < pictures3.Length; z++)
                {
                    thepictures3[z] = pictures3[z].texture;
                }
            }
          }*/
        /*
            if (!gotplane)
            {
                if (planewww.progress == 1f)
                {
                    gotplane = true;
                    planetex = planewww.texture;
                }
            }*/
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

    public void multiplayerRacingFinsih()
    {
        float time = roundTime - 20f;
        if (PhotonNetwork.isMasterClient)
        {
            this.getRacingResult(LoginFengKAI.player.name, time);
        }
        else
        {
            object[] parameters = new object[] { LoginFengKAI.player.name, time };
            basephotonView.RPC("getRacingResult", PhotonTargets.MasterClient, parameters);
        }
        this.gameWin();
    }

    [RPC]
    private void netGameLose(int score)
    {
        if (level != "CandyMod Balls PVP")
        {
            this.isLosing = true;
            this.titanScore = score;
            this.gameEndCD = this.gameEndTotalCDtime;
        }
    }

    [RPC]
    private void netGameWin(int score)
    {
        if (level != "CandyMod Balls PVP")
        {
            this.humanScore = score;
            this.isWinning = true;
            if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.PVP_AHSS)
            {
                this.teamWinner = score;
                this.teamScores[this.teamWinner - 1]++;
                this.gameEndCD = this.gameEndTotalCDtime;
            }
            else if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.RACING)
            {
                this.gameEndCD = 20f;
            }
            else
            {
                this.gameEndCD = this.gameEndTotalCDtime;
            }
        }
    }

    [RPC]
    private void netRefreshRacingResult(string tmp)
    {
        this.localRacingResult = tmp;
    }

    [RPC]
    public void netShowDamage(int speed)
    {
        GameObject.Find("Stylish").GetComponent<StylishComponent>().Style(speed);
        GameObject target = GameObject.Find("LabelScore");
        if (target != null)
        {
            target.GetComponent<UILabel>().text = speed.ToString();
            target.transform.localScale = Vector3.zero;
            speed = (int)(speed * 0.1f);
            speed = Mathf.Max(40, speed);
            speed = Mathf.Min(150, speed);
            iTween.Stop(target);
            object[] args = new object[] { "x", speed, "y", speed, "z", speed, "easetype", iTween.EaseType.easeOutElastic, "time", 1f };
            iTween.ScaleTo(target, iTween.Hash(args));
            object[] objArray2 = new object[] { "x", 0, "y", 0, "z", 0, "easetype", iTween.EaseType.easeInBounce, "time", 0.5f, "delay", 2f };
            iTween.ScaleTo(target, iTween.Hash(objArray2));
        }
    }

    public void OnConnectedToMaster()
    {
        //UnityEngine.MonoBehaviour.print("OnConnectedToMaster");
    }

    public void OnConnectedToPhoton()
    {
        //UnityEngine.MonoBehaviour.print("OnConnectedToPhoton");
    }

    public void OnConnectionFail(DisconnectCause cause)
    {
        //UnityEngine.MonoBehaviour.print("OnConnectionFail : " + cause.ToString());
        Screen.lockCursor = false;
        Screen.showCursor = true;
        IN_GAME_MAIN_CAMERA.gametype = GAMETYPE.STOP;
        gameStart = false;
        NGUITools.SetActive(this.uirefer.GetComponent<UIReferArray>().panels[0], false);
        NGUITools.SetActive(this.uirefer.GetComponent<UIReferArray>().panels[1], false);
        NGUITools.SetActive(this.uirefer.GetComponent<UIReferArray>().panels[2], false);
        NGUITools.SetActive(this.uirefer.GetComponent<UIReferArray>().panels[3], false);
        NGUITools.SetActive(this.uirefer.GetComponent<UIReferArray>().panels[4], true);
        GameObject.Find("LabelDisconnectInfo").GetComponent<UILabel>().text = "OnConnectionFail : " + cause.ToString();
    }

    public void OnCreatedRoom()
    {
        this.kicklist = new ArrayList();
        this.racingResult = new ArrayList();
        this.teamScores = new int[2];
        //UnityEngine.MonoBehaviour.print("OnCreatedRoom");
    }

    public void OnCustomAuthenticationFailed()
    {
        //UnityEngine.MonoBehaviour.print("OnCustomAuthenticationFailed");
    }

    public void OnDisconnectedFromPhoton()
    {
        //UnityEngine.MonoBehaviour.print("OnDisconnectedFromPhoton");
        Screen.lockCursor = false;
        Screen.showCursor = true;
    }



    [RPC]
    public void oneTitanDown(string name1 = "", bool onPlayerLeave = false)
    {
        if ((IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE) || PhotonNetwork.isMasterClient)
        {
            if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.PVP_CAPTURE)
            {
                if (name1 != string.Empty)
                {
                    if (name1 == "Titan")
                    {
                        this.PVPhumanScore++;
                    }
                    else if (name1 == "Aberrant")
                    {
                        this.PVPhumanScore += 2;
                    }
                    else if (name1 == "Jumper")
                    {
                        this.PVPhumanScore += 3;
                    }
                    else if (name1 == "Crawler")
                    {
                        this.PVPhumanScore += 4;
                    }
                    else if (name1 == "Female Titan")
                    {
                        this.PVPhumanScore += 10;
                    }
                    else
                    {
                        this.PVPhumanScore += 3;
                    }
                }
                this.checkPVPpts();
                object[] parameters = new object[] { this.PVPhumanScore, this.PVPtitanScore };
                basephotonView.RPC("refreshPVPStatus", PhotonTargets.Others, parameters);
            }
            else if (IN_GAME_MAIN_CAMERA.gamemode != GAMEMODE.CAGE_FIGHT)
            {
                if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.KILL_TITAN)
                {
                    if (this.checkIsTitanAllDie())
                    {
                        this.gameWin();
                        GameObject.Find("MainCamera").GetComponent<IN_GAME_MAIN_CAMERA>().gameOver = true;
                    }
                }
                else if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.SURVIVE_MODE)
                {
                    if (this.checkIsTitanAllDie())
                    {
                        this.wave++;
                        if ((LevelInfo.getInfo(level).respawnMode == RespawnMode.NEWROUND) && (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER))
                        {
                            basephotonView.RPC("respawnHeroInNewRound", PhotonTargets.All, new object[0]);
                        }
                        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
                        {
                            this.sendChatContentInfo("<color=#A8FF24>Wave : " + this.wave + "</color>");
                        }
                        if (this.wave > this.highestwave)
                        {
                            this.highestwave = this.wave;
                        }
                        if (PhotonNetwork.isMasterClient)
                        {
                            this.RequireStatus();
                        }
                        if (this.wave > 20)
                        {
                            this.gameWin();
                        }
                        else
                        {
                            int rate = 90;
                            if (this.difficulty == 1)
                            {
                                rate = 70;
                            }
                            if (!LevelInfo.getInfo(level).punk)
                            {
                                this.randomSpawnTitan("titanRespawn", rate, this.wave + 2, false);
                            }
                            else if (this.wave == 5)
                            {
                                this.randomSpawnTitan("titanRespawn", rate, 1, true);
                            }
                            else if (this.wave == 10)
                            {
                                this.randomSpawnTitan("titanRespawn", rate, 2, true);
                            }
                            else if (this.wave == 15)
                            {
                                this.randomSpawnTitan("titanRespawn", rate, 3, true);
                            }
                            else if (this.wave == 20)
                            {
                                this.randomSpawnTitan("titanRespawn", rate, 4, true);
                            }
                            else
                            {
                                this.randomSpawnTitan("titanRespawn", rate, this.wave + 2, false);
                            }
                        }
                    }
                }
                else if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.ENDLESS_TITAN)
                {
                    if (!onPlayerLeave)
                    {
                        this.humanScore++;
                        int num2 = 90;
                        if (this.difficulty == 1)
                        {
                            num2 = 70;
                        }
                        this.randomSpawnTitan("titanRespawn", num2, 1, false);
                    }
                }
                else if (LevelInfo.getInfo(level).enemyNumber == -1)
                {
                }
            }
        }
    }

    public void OnFailedToConnectToPhoton()
    {
        //UnityEngine.MonoBehaviour.print("OnFailedToConnectToPhoton");
    }

    public void OnJoinedLobby()
    {
        setup = false;
        showconfig = false;
        fps2 = 0;
        //UnityEngine.MonoBehaviour.print("OnJoinedLobby");
        NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiStart, false);
        NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiROOM, true);
    }

    public void OnJoinedRoom()
    {
        flight = false;
        showconfig = false;
        fps2 = 0;
        char[] separator = new char[] { "`"[0] };
        //UnityEngine.MonoBehaviour.print("OnJoinedRoom " + PhotonNetwork.room.name + "    >>>>   " + LevelInfo.getInfo(PhotonNetwork.room.name.Split(separator)[1]).mapName);
        this.gameTimesUp = false;
        char[] chArray2 = new char[] { "`"[0] };
        string[] strArray = PhotonNetwork.room.name.Split(chArray2);
        level = strArray[1];
        if (strArray[2] == "normal")
        {
            this.difficulty = 0;
        }
        else if (strArray[2] == "hard")
        {
            this.difficulty = 1;
        }
        else if (strArray[2] == "abnormal")
        {
            this.difficulty = 2;
        }
        IN_GAME_MAIN_CAMERA.difficulty = this.difficulty;
        this.time = int.Parse(strArray[3]);
        this.time *= 60;
        if (strArray[4] == "day")
        {
            IN_GAME_MAIN_CAMERA.dayLight = DayLight.Day;
        }
        else if (strArray[4] == "dawn")
        {
            IN_GAME_MAIN_CAMERA.dayLight = DayLight.Dawn;
        }
        else if (strArray[4] == "night")
        {
            IN_GAME_MAIN_CAMERA.dayLight = DayLight.Night;
        }
        IN_GAME_MAIN_CAMERA.gamemode = LevelInfo.getInfo(level).type;
        PhotonNetwork.LoadLevel(LevelInfo.getInfo(level).mapName);
        ExitGames.Client.Photon.Hashtable hashtable2 = new ExitGames.Client.Photon.Hashtable();
        hashtable2.Add(PhotonPlayerProperty.name, LoginFengKAI.player.name);
        ExitGames.Client.Photon.Hashtable propertiesToSet = hashtable2;
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);
        hashtable2 = new ExitGames.Client.Photon.Hashtable();
        hashtable2.Add(PhotonPlayerProperty.guildName, LoginFengKAI.player.guildname);
        propertiesToSet = hashtable2;
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);
        hashtable2 = new ExitGames.Client.Photon.Hashtable();
        hashtable2.Add(PhotonPlayerProperty.kills, 0);
        propertiesToSet = hashtable2;
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);
        hashtable2 = new ExitGames.Client.Photon.Hashtable();
        hashtable2.Add(PhotonPlayerProperty.max_dmg, 0);
        propertiesToSet = hashtable2;
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);
        hashtable2 = new ExitGames.Client.Photon.Hashtable();
        hashtable2.Add(PhotonPlayerProperty.total_dmg, 0);
        propertiesToSet = hashtable2;
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);
        hashtable2 = new ExitGames.Client.Photon.Hashtable();
        hashtable2.Add(PhotonPlayerProperty.deaths, 0);
        propertiesToSet = hashtable2;
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);
        hashtable2 = new ExitGames.Client.Photon.Hashtable();
        hashtable2.Add(PhotonPlayerProperty.dead, true);
        propertiesToSet = hashtable2;
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);
        hashtable2 = new ExitGames.Client.Photon.Hashtable();
        hashtable2.Add(PhotonPlayerProperty.isTitan, 0);
        propertiesToSet = hashtable2;
        PhotonNetwork.player.SetCustomProperties(propertiesToSet);
        this.humanScore = 0;
        this.titanScore = 0;
        this.PVPtitanScore = 0;
        this.PVPhumanScore = 0;
        this.wave = 1;
        this.highestwave = 1;
        this.localRacingResult = string.Empty;
        if (FengGameManagerMKII.level != "CandyMod Ball PVP" && FengGameManagerMKII.level != "The City III" && FengGameManagerMKII.level != "Racing - Akina" && FengGameManagerMKII.level != "Colossal Titan II" && FengGameManagerMKII.level != "The Forest III" && FengGameManagerMKII.level != "The City")
            base.StartCoroutine(NeedChooseSide());
        else
            this.needChooseSide = true;
        this.chatContent = new ArrayList();
        this.killInfoGO = new ArrayList();
        InRoomChat.messages = new List<string>();
        if (!PhotonNetwork.isMasterClient)
        {
            basephotonView.RPC("RequireStatus", PhotonTargets.MasterClient, new object[0]);
        }
        basephotonView.RPC("ReqList", PhotonPlayer.Find(FengGameManagerMKII.candyMasterClient), new object[] { });
        FengGameManagerMKII.Reset(PhotonNetworkingMessage.OnJoinedRoom);
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

    public void OnLeftRoom()
    {
        setup = false;
        flight = false;
        InRoomChat.joined = false;
        fps2 = 0;
        //UnityEngine.MonoBehaviour.print("OnLeftRoom");
        playerSpawns.Clear();
        candypowers = false;
        if (Application.loadedLevel != 0)
        {
            Time.timeScale = 1f;
            if (PhotonNetwork.connected)
            {
                PhotonNetwork.Disconnect();
            }
            IN_GAME_MAIN_CAMERA.gametype = GAMETYPE.STOP;
            gameStart = false;
            Screen.lockCursor = false;
            Screen.showCursor = true;
            FengCustomInputs.inputs.menuOn = false;
            UnityEngine.Object.Destroy(GameObject.Find("MultiplayerManager"));
            showconfig = true;
            Application.LoadLevel("menu");
        }
    }

    public void CachedStatic()
    {
        BoundsDisabled = false;
        FengCustomInputs.inputs = GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>();
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
        }
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
        showconfig = false;
        CachedStatic();
        FengGameManagerMKII.restarting = true;
        if (level != 0 && Application.loadedLevelName != "characterCreation" && Application.loadedLevelName != "SnapShot")
        {
            ChangeQuality.setCurrentQuality();
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("titan");
            for (int i = 0; i < (int)gameObjectArray.Length; i++)
            {
                GameObject gameObject = gameObjectArray[i];
                PhotonView component = gameObject.GetComponent<PhotonView>();
                if (component == null || !component.owner.isMasterClient)
                {
                    UnityEngine.Object.Destroy(gameObject);
                }
            }
            this.isWinning = false;
            FengGameManagerMKII.ShowHUDInfoCenter(string.Empty);
            GameObject gameObject1 = CacheGameObject.Find("cameraDefaultPosition");
            Transform _transform = gameObject1.transform;
            ((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("MainCamera_mono"), _transform.position, _transform.rotation)).name = ("MainCamera");
            UnityEngine.Object.Destroy(gameObject1);
            UIReferArray uIReferArray = (UIReferArray)UnityEngine.Object.Instantiate(CacheResources.Load<UIReferArray>("UI_IN_GAME"));
            UIReferArray uIReferArray1 = uIReferArray;
            this.uirefer = uIReferArray;
            uIReferArray1.name = ("UI_IN_GAME");
            this.uirefer.gameObject.SetActive(true);
            NGUITools.SetActive(this.uirefer.panels[0], true);
            NGUITools.SetActive(this.uirefer.panels[1], false);
            NGUITools.SetActive(this.uirefer.panels[2], false);
            NGUITools.SetActive(this.uirefer.panels[3], false);
            FengGameManagerMKII.levelinfo = LevelInfo.getInfo(FengGameManagerMKII.level);
            Screen.lockCursor = (true);
            Screen.showCursor = (true);
            FengGameManagerMKII.skyname = string.Empty;
            this.cache();
            //this.loadskin();
            IN_GAME_MAIN_CAMERA.mainCamera.setHUDposition();
            IN_GAME_MAIN_CAMERA.mainCamera.setDayLight(IN_GAME_MAIN_CAMERA.dayLight);
            FengGameManagerMKII.gameStart = true;
            Bounds levelBounds = FengGameManagerMKII.LevelBounds;
            FengGameManagerMKII.LevelBounds.center = (Vector3.zero);
            if (FengGameManagerMKII.level != "Custom" && FengGameManagerMKII.level != "Custom (No PT)")
            {
                FengGameManagerMKII.LevelBounds.size = (Vector3.one);
            }
            if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE)
            {
                PVPcheckPoint.chkPts = new ArrayList();
                IN_GAME_MAIN_CAMERA.mainCamera.enabled = (false);
                IN_GAME_MAIN_CAMERA.shake.enabled = (false);
                IN_GAME_MAIN_CAMERA.gametype = GAMETYPE.MULTIPLAYER;
                if (FengGameManagerMKII.settingsSkin[64].StartsWith("e"))
                {
                    Screen.showCursor = (true);
                    Screen.lockCursor = (false);
                    return;
                }
                if (!(FengGameManagerMKII.levelinfo.name != "Custom") || !(FengGameManagerMKII.levelinfo.name != "Custom (No PT)"))
                {
                    FengGameManagerMKII.LevelBounds.center = (Vector3.zero);
                    FengGameManagerMKII.LevelBounds.size = (Vector3.one);
                }/*
                else
                {
                    FengGameManagerMKII.ResetBoxCollider();
                }
                */
                FengGameManagerMKII.updatePlayerList();
                //FengGameManagerMKII.TopLeftText = string.Empty;
                if (FengGameManagerMKII.levelinfo != null)
                {/*
                    if (PhotonNetwork.isMasterClient && FengGameManagerMKII.customPhoton.Count > 0 && FengGameManagerMKII.levelinfo.name == "Custom" && FengGameManagerMKII.levelinfo.name == "Custom (No PT)")
                    {
                        foreach (Action action in FengGameManagerMKII.customPhoton)
                        {
                            action();
                        }
                    }*/
                    if (FengGameManagerMKII.levelinfo.type == GAMEMODE.TROST)
                    {
                        CacheGameObject.Find("playerRespawn").SetActive(false);
                        UnityEngine.Object.Destroy(CacheGameObject.Find("playerRespawn"));
                        CacheGameObject.Find("rock").animation["lift"].speed = (0f);
                        CacheGameObject.Find("door_fine").SetActive(false);
                        CacheGameObject.Find("door_broke").SetActive(true);
                        UnityEngine.Object.Destroy(CacheGameObject.Find("ppl"));
                    }
                    else if (FengGameManagerMKII.levelinfo.type == GAMEMODE.BOSS_FIGHT_CT)
                    {
                        CacheGameObject.Find("playerRespawnTrost").SetActive(false);
                        UnityEngine.Object.Destroy(CacheGameObject.Find("playerRespawnTrost"));
                    }
                }
                if (!this.needChooseSide)
                {
                    Screen.lockCursor = ((IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS));
                    if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.PVP_CAPTURE)
                    {
                        this.checkpoint = CacheGameObject.Find((PhotonNetwork.player.isTitan ? "PVPchkPtT" : "PVPchkPtH"));
                    }
                    if (PhotonNetwork.player.isTitan)
                    {
                        if (!this.myLastHero.IsNullOrEmpty())
                        {
                            this.SpawnNonAITitan(this.myLastHero, "titanRespawn");
                        }
                    }
                    else if (!this.myLastHero.IsNullOrEmpty() && !string.IsNullOrEmpty(this.myLastRespawnTag))
                    {
                        this.SpawnPlayer(this.myLastHero, this.myLastRespawnTag);
                    }
                }
                else
                {
                    FengGameManagerMKII.ShowHUDInfoTopCenterADD("\n\nPRESS 1 TO ENTER GAME");
                }
                if (FengGameManagerMKII.levelinfo.type == GAMEMODE.BOSS_FIGHT_CT)
                {
                    UnityEngine.Object.Destroy(CacheGameObject.Find("rock"));
                }
                if (PhotonNetwork.isMasterClient)
                {
                    switch (FengGameManagerMKII.levelinfo.type)
                    {
                        case GAMEMODE.KILL_TITAN:
                        case GAMEMODE.ENDLESS_TITAN:
                        case GAMEMODE.SURVIVE_MODE:
                            {
                                if (FengGameManagerMKII.levelinfo.name.StartsWith("Annie"))
                                {
                                    Transform transform = CacheGameObject.Find("titanRespawn").transform;
                                    PhotonNetwork.Instantiate("FEMALE_TITAN", transform.position, transform.rotation, 0, null);
                                    break;
                                }
                                else if (!(bool)FengGameManagerMKII.settings[16])
                                {
                                    int num = 90;
                                    if (this.difficulty == 1)
                                    {
                                        num = 70;
                                    }
                                    if (FengGameManagerMKII.level.StartsWith("Custom") && FengGameManagerMKII.settingsSkin[93] == "1")
                                    {
                                        if ((int)FengGameManagerMKII.settings[87] <= 0)
                                        {
                                            this.spawnTitanCustom("titanRespawn", num, 3, false);
                                            break;
                                        }
                                        else
                                        {
                                            this.spawnTitanCustom("titanRespawn", num, (int)FengGameManagerMKII.settings[87], false);
                                            break;
                                        }
                                    }
                                    else if ((int)FengGameManagerMKII.settings[87] <= 0)
                                    {
                                        this.spawnTitanCustom("titanRespawn", num, FengGameManagerMKII.levelinfo.enemyNumber, false);
                                        break;
                                    }
                                    else
                                    {
                                        this.spawnTitanCustom("titanRespawn", num, (int)FengGameManagerMKII.settings[87], false);
                                        break;
                                    }
                                }
                                else if (FengGameManagerMKII.level.StartsWith("Custom") && FengGameManagerMKII.settingsSkin[93] == "waves")
                                {
                                    if ((int)FengGameManagerMKII.settings[87] <= 0)
                                    {
                                        this.spawnRandomFT("titanRespawn", 3);
                                        break;
                                    }
                                    else
                                    {
                                        this.spawnRandomFT("titanRespawn", (int)FengGameManagerMKII.settings[87]);
                                        break;
                                    }
                                }
                                else if ((int)FengGameManagerMKII.settings[87] <= 0)
                                {
                                    this.spawnRandomFT("titanRespawn", FengGameManagerMKII.levelinfo.enemyNumber);
                                    break;
                                }
                                else
                                {
                                    this.spawnRandomFT("titanRespawn", (int)FengGameManagerMKII.settings[87]);
                                    break;
                                }
                            }
                        case GAMEMODE.BOSS_FIGHT_CT:
                            {
                                if (FengGameManagerMKII.isPlayerAllDead())
                                {
                                    break;
                                }
                                PhotonNetwork.Instantiate("COLOSSAL_TITAN", -Vector3.up * 10000f, Quaternion.Euler(0f, 180f, 0f), 0, null);
                                break;
                            }
                        case GAMEMODE.TROST:
                            {
                                if (FengGameManagerMKII.isPlayerAllDead())
                                {
                                    break;
                                }
                                PhotonNetwork.Instantiate<TITAN_EREN>("TITAN_EREN_trost", new Vector3(-200f, 0f, -194f), Quaternion.Euler(0f, 180f, 0f), 0, null).rockLift = true;
                                int num1 = 90;
                                if (this.difficulty == 1)
                                {
                                    num1 = 70;
                                }
                                GameObject gameObject2 = CacheGameObject.Find("titanRespawnTrost");
                                if (gameObject2 == null)
                                {
                                    break;
                                }
                                GameObject[] gameObjectArray1 = GameObject.FindGameObjectsWithTag("titanRespawn");
                                for (int j = 0; j < (int)gameObjectArray1.Length; j++)
                                {
                                    GameObject gameObject3 = gameObjectArray1[j];
                                    if (gameObject3 != null)
                                    {
                                        Transform _transform1 = gameObject3.transform;
                                        if (_transform1 != null)
                                        {
                                            Transform _parent = _transform1.parent;
                                            _transform1 = _parent;
                                            if (_parent != null && _transform1.gameObject == gameObject2)
                                            {
                                                this.spawnTitan(num1, _transform1.position, _transform1.rotation, false);
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case GAMEMODE.PVP_CAPTURE:
                            {
                                if (FengGameManagerMKII.levelinfo.mapName != "OutSide")
                                {
                                    break;
                                }
                                GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag("titanRespawn");
                                for (int k = 0; k < (int)gameObjectArray2.Length; k++)
                                {
                                    GameObject gameObject4 = gameObjectArray2[k];
                                    if (gameObject4 != null)
                                    {
                                        Transform transform1 = gameObject4.transform;
                                        if (transform1 != null)
                                        {
                                            this.spawnTitanRaw(transform1.position, transform1.rotation).setAbnormalType(AbnormalType.TYPE_CRAWLER, true);
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
                if (!FengGameManagerMKII.levelinfo.supply)
                {
                    UnityEngine.Object.Destroy(CacheGameObject.Find("aot_supply"));
                }
                if (!PhotonNetwork.isMasterClient)
                {
                    FengGameManagerMKII.PView.RPC("RequireStatus", PhotonTargets.MasterClient, new object[0]);
                    if (FengGameManagerMKII.levelinfo.name == "Outside The Walls")
                    {
                        PhotonView pView = FengGameManagerMKII.PView;
                        int num2 = 0;
                        int num3 = num2;
                        this.PVPhumanScore = num2;
                        int num4 = 0;
                        int num5 = num4;
                        this.PVPtitanScore = num4;
                        pView.RPC("refreshPVPStatus", PhotonTargets.Others, num3, num5);
                    }
                }
                if (FengGameManagerMKII.levelinfo.lavaMode)
                {
                    UnityEngine.Object.Instantiate(CacheResources.Load("levelBottom"), new Vector3(0f, -29.5f, 0f), Quaternion.Euler(0f, 0f, 0f));
                    Transform _transform2 = CacheGameObject.Find("aot_supply").transform;
                    Transform transform2 = CacheGameObject.Find("aot_supply_lava_position").transform;
                    _transform2.position = (transform2.position);
                    _transform2.rotation = (transform2.rotation);
                }
            }
            else
            {
                FengGameManagerMKII.settings[3] = true;
                this.single_kills = 0;
                this.single_maxDamage = 0;
                this.single_totalDamage = 0;
                MouseLook mouseLook = IN_GAME_MAIN_CAMERA.mouselook;
                int num6 = 1;
                bool flag = true;
                IN_GAME_MAIN_CAMERA.spectate.disable = true;
                bool flag1 = flag;
                bool flag2 = flag1;
                IN_GAME_MAIN_CAMERA.mainCamera.enabled = (flag1);
                mouseLook.disable = flag2;
                IN_GAME_MAIN_CAMERA.gamemode = FengGameManagerMKII.levelinfo.type;
                this.SpawnPlayer(IN_GAME_MAIN_CAMERA.singleCharacter.ToUpper(), "playerRespawn");
                Screen.showCursor = (false);
                Screen.lockCursor = ((IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS));
                int num7 = (this.difficulty == 1 ? 70 : 90);
                if ((bool)FengGameManagerMKII.settings[16])
                {
                    if ((int)FengGameManagerMKII.settings[87] <= 0)
                    {
                        this.spawnRandomFT("titanRespawn", FengGameManagerMKII.levelinfo.enemyNumber);
                    }
                    else
                    {
                        this.spawnRandomFT("titanRespawn", (int)FengGameManagerMKII.settings[87]);
                    }
                }
                else if ((int)FengGameManagerMKII.settings[87] <= 0)
                {
                    this.spawnTitanCustom("titanRespawn", num7, FengGameManagerMKII.levelinfo.enemyNumber, false);
                }
                else
                {
                    this.spawnTitanCustom("titanRespawn", num7, (int)FengGameManagerMKII.settings[87], false);
                }
            }
        }
        //Yield.Begin(null, () => FengGameManagerMKII.resetSkyTexture(level));
        //Application.set_targetFrameRate((FengGameManagerMKII.FPS > 0 ? FengGameManagerMKII.FPS : -1));
        FengGameManagerMKII.restarting = false;
        if (IN_GAME_MAIN_CAMERA.MULTIPLAYER)
        {
            base.Invoke("DestroyLeftOvers", 1f);
        }
        GameObject.Find("Chatroom").GetComponent<InRoomChat>().photonView.RPC("net3DMGSMOKE", PhotonTargets.All, new object[] { });
        base.photonView.RPC("SpawnPlayerAtRPC", PhotonTargets.All, new object[] { });
        if (FengGameManagerMKII.level == "CandyMod Balls PVP")
            basephotonView.RPC("RPCLoadLevel", PhotonTargets.All, new object[0]);
    }

    public void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        flight = false;
        showconfig = false;
        //UnityEngine.MonoBehaviour.print("OnMasterClientSwitched");
        if (!this.gameTimesUp && PhotonNetwork.isMasterClient)
        {
            this.restartGame(true);
        }
    }

    public void OnPhotonCreateRoomFailed()
    {
        //UnityEngine.MonoBehaviour.print("OnPhotonCreateRoomFailed");
    }

    public void OnPhotonCustomRoomPropertiesChanged()
    {
        //UnityEngine.MonoBehaviour.print("OnPhotonCustomRoomPropertiesChanged");
    }

    public void OnPhotonInstantiate()
    {
        //UnityEngine.MonoBehaviour.print("OnPhotonInstantiate");
    }

    public void OnPhotonJoinRoomFailed()
    {
        //UnityEngine.MonoBehaviour.print("OnPhotonJoinRoomFailed");
    }

    public void OnPhotonMaxCccuReached()
    {
        //UnityEngine.MonoBehaviour.print("OnPhotonMaxCccuReached");
    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer player1)
    {
        FengGameManagerMKII.updatePlayerList();
        if (cmusers.ContainsKey(player1.ID))
        {
            cmusers.Remove(player1.ID);
        }
        //UnityEngine.MonoBehaviour.print("OnPhotonPlayerDisconnected");
        if (!this.gameTimesUp)
        {
            this.oneTitanDown(string.Empty, true);
            this.someOneIsDead(0);
        }
    }

    public void OnPhotonPlayerPropertiesChanged()
    {
        FengGameManagerMKII.updatePlayerList();/*
        bool flag = false;
        ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
        if (PhotonNetwork.player.guildname != LoginFengKAI.player.guildname)
        {
            hashtable.Add("guildName", LoginFengKAI.player.guildname);
            flag = true;
        }
        if ((string)FengGameManagerMKII.settings[84] == "None" && PhotonNetwork.player.uiname != LoginFengKAI.player.name)
        {
            hashtable.Add("name", LoginFengKAI.player.name);
            flag = true;
        }
        if (flag)
        {
            Yield.Begin<PhotonPlayer>((PhotonPlayer p1) => p1.SetCustomProperties(hashtable), PhotonNetwork.player);
        }
        if ((bool)FengGameManagerMKII.settings[17])
        {
            PhotonPlayer[] photonPlayerArray = PhotonNetwork.playerList;
            for (int i = 0; i < (int)photonPlayerArray.Length; i++)
            {
                PhotonPlayer photonPlayer = photonPlayerArray[i];
                if (FengGameManagerMKII.Hash[0].ContainsKey(photonPlayer.ID))
                {
                    string item = FengGameManagerMKII.Hash[0][photonPlayer.ID] as string;
                    if (!item.IsNullOrEmpty() && !item.StartsWith(" ") && item != (string)photonPlayer.customProperties["name"])
                    {
                        ExitGames.Client.Photon.Hashtable hashtable1 = new ExitGames.Client.Photon.Hashtable();
                        hashtable1.Add("name", item);
                        Yield.Begin<ExitGames.Client.Photon.Hashtable>((ExitGames.Client.Photon.Hashtable hash) => photonPlayer.SetCustomProperties(hash), hashtable1);
                    }
                }
            }
        }*/
    }


    public void OnPhotonRandomJoinFailed()
    {
        //UnityEngine.MonoBehaviour.print("OnPhotonRandomJoinFailed");
    }

    public void OnPhotonSerializeView()
    {
        //UnityEngine.MonoBehaviour.print("OnPhotonSerializeView");
    }

    public void OnReceivedRoomListUpdate()
    {
    }

    public void OnUpdatedFriendList()
    {
        //UnityEngine.MonoBehaviour.print("OnUpdatedFriendList");
    }

    public void playerKillInfoSingleUpdate(int dmg)
    {
        this.single_kills++;
        this.single_maxDamage = Mathf.Max(dmg, this.single_maxDamage);
        this.single_totalDamage += dmg;
    }

    public static void playerKillInfoUpdate(PhotonPlayer player, int dmg)
    {
        ExitGames.Client.Photon.Hashtable propertiesToSet = new ExitGames.Client.Photon.Hashtable();
        propertiesToSet.Add(PhotonPlayerProperty.kills, ((int)player.customProperties[PhotonPlayerProperty.kills]) + 1);
        player.SetCustomProperties(propertiesToSet);
        propertiesToSet = new ExitGames.Client.Photon.Hashtable();
        propertiesToSet.Add(PhotonPlayerProperty.max_dmg, Mathf.Max(dmg, (int)player.customProperties[PhotonPlayerProperty.max_dmg]));
        player.SetCustomProperties(propertiesToSet);
        propertiesToSet = new ExitGames.Client.Photon.Hashtable();
        propertiesToSet.Add(PhotonPlayerProperty.total_dmg, ((int)player.customProperties[PhotonPlayerProperty.total_dmg]) + dmg);
        player.SetCustomProperties(propertiesToSet);
    }

    [RPC]
    private void refreshPVPStatus(int score1, int score2)
    {
        this.PVPhumanScore = score1;
        this.PVPtitanScore = score2;
    }

    [RPC]
    private void refreshPVPStatus_AHSS(int[] score1)
    {
        //UnityEngine.MonoBehaviour.print(score1);
        this.teamScores = score1;
    }

    private void refreshRacingResult()
    {
        this.localRacingResult = "Result\n";
        IComparer comparer = new IComparerRacingResult();
        this.racingResult.Sort(comparer);
        int num = Mathf.Min(this.racingResult.Count, 6);
        for (int i = 0; i < num; i++)
        {
            string localRacingResult = this.localRacingResult;
            object[] objArray1 = new object[] { localRacingResult, "Rank ", i + 1, " : " };
            this.localRacingResult = string.Concat(objArray1);
            this.localRacingResult = this.localRacingResult + (this.racingResult[i] as RacingResult).name;
            this.localRacingResult = this.localRacingResult + "   " + ((((int)((this.racingResult[i] as RacingResult).time * 100f)) * 0.01f)).ToString() + "s";
            this.localRacingResult = this.localRacingResult + "\n";
        }
        object[] parameters = new object[] { this.localRacingResult };
        basephotonView.RPC("netRefreshRacingResult", PhotonTargets.All, parameters);
    }

    [RPC]
    private void refreshStatus(int score1, int score2, int wav, int highestWav, float time1, float time2, bool startRacin, bool endRacin)
    {
        this.humanScore = score1;
        this.titanScore = score2;
        this.wave = wav;
        this.highestwave = highestWav;
        roundTime = time1;
        this.timeTotalServer = time2;
        this.startRacing = startRacin;
        this.endRacing = endRacin;
        if (this.startRacing && (GameObject.Find("door") != null))
        {
            GameObject.Find("door").SetActive(false);
        }
    }

    public void removeCT(COLOSSAL_TITAN titan)
    {
        cT.Remove(titan);
    }

    public void removeET(TITAN_EREN hero)
    {
        eT.Remove(hero);
    }

    public void removeFT(FEMALE_TITAN titan)
    {
        fT.Remove(titan);
    }

    public void removeHero(HERO hero)
    {
        heroes.Remove(hero);
    }

    public static void removeHook(Bullet h)
    {
        hooks.Remove(h);
    }

    public void removeTitan(TITAN titan)
    {
        titans.Remove(titan);
    }

    [RPC]
    private void RequireStatus()
    {
        object[] parameters = new object[] { this.humanScore, this.titanScore, this.wave, this.highestwave, roundTime, this.timeTotalServer, this.startRacing, this.endRacing };
        basephotonView.RPC("refreshStatus", PhotonTargets.Others, parameters);
        object[] objArray2 = new object[] { this.PVPhumanScore, this.PVPtitanScore };
        basephotonView.RPC("refreshPVPStatus", PhotonTargets.Others, objArray2);
        object[] objArray3 = new object[] { this.teamScores };
        basephotonView.RPC("refreshPVPStatus_AHSS", PhotonTargets.Others, objArray3);
    }

    public void restartGame(bool masterclientSwitched = false)
    {/*
        CandyModUsersOnly("DestroyFlashy", "All", new object[] { PhotonNetwork.player.ID });
        CandyModUsersOnly("DestroyWings", "Others", new object[] { PhotonNetwork.player.ID });
        for (int z = 0; z < animate.Count; z++)
        {
            animate[z] = false;
        }
        if (IN_GAME_MAIN_CAMERA.iswings)
        {
            GameObject.Destroy(IN_GAME_MAIN_CAMERA.wings);
            IN_GAME_MAIN_CAMERA.wings = null;
            IN_GAME_MAIN_CAMERA.iswings = false;
        }*/
        candypowers = false;
        //UnityEngine.MonoBehaviour.print("reset game :" + this.gameTimesUp);
        if (!this.gameTimesUp)
        {
            this.PVPtitanScore = 0;
            this.PVPhumanScore = 0;
            this.startRacing = false;
            this.endRacing = false;
            this.checkpoint = null;
            this.timeElapse = 0f;
            roundTime = 0f;
            this.isWinning = false;
            this.isLosing = false;
            this.wave = 1;
            this.myRespawnTime = 0f;
            this.kicklist = new ArrayList();
            this.killInfoGO = new ArrayList();
            this.racingResult = new ArrayList();
            ShowHUDInfoCenter(string.Empty);
            PhotonNetwork.DestroyAll();
            basephotonView.RPC("RPCLoadLevel", PhotonTargets.All, new object[0]);
            if (masterclientSwitched)
            {
                flight = false;
                this.sendChatContentInfo("<color=#A8FF24>MasterClient has switched to </color>" + PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]);
            }
        }
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
    private void restartGameByClient()
    {
        //this.restartGame(false);
    }

    public void restartGameSingle()
    {
        this.startRacing = false;
        this.endRacing = false;
        this.checkpoint = null;
        this.single_kills = 0;
        this.single_maxDamage = 0;
        this.single_totalDamage = 0;
        this.timeElapse = 0f;
        roundTime = 0f;
        this.timeTotalServer = 0f;
        this.isWinning = false;
        this.isLosing = false;
        this.wave = 1;
        this.myRespawnTime = 0f;
        ShowHUDInfoCenter(string.Empty);
        Application.LoadLevel(Application.loadedLevel);
    }
    public static bool rainbowasdf;

    [RPC]
    private void RPCLoadLevel()
    {
        PhotonNetwork.LoadLevel(LevelInfo.getInfo(level).mapName);
        if (PhotonNetwork.player == PhotonNetwork.masterClient)
        {
            if (TITAN.spawnrate == true)
            {
                object[] objArray8 = new object[] { "<color=#ffcc00>Spawn Rate Is: " + TITAN.spawn1 + ", " + TITAN.spawn2 + ", " + TITAN.spawn3 + ", " + TITAN.spawn4 + ", " + TITAN.spawn5 + "</color>", string.Empty };
                FengGameManagerMKII.MKII.photonView.RPC("Chat", PhotonTargets.All, objArray8);
            }
            if (size == true)
            {
                object[] objArray8 = new object[] { "<color=#ffcc00>Size Is Set To: " + TITAN.size1 + ", " + TITAN.size2 + " </color>", string.Empty };
                FengGameManagerMKII.MKII.photonView.RPC("Chat", PhotonTargets.All, objArray8);
            }
            if (damage == true)
            {
                object[] objArray8 = new object[] { "<color=#ffcc00>Damage Is Set To " + TITAN.damage + " </color>", string.Empty };
                FengGameManagerMKII.MKII.photonView.RPC("Chat", PhotonTargets.All, objArray8);
            }
        }
        if (PhotonNetwork.isMasterClient && level == "CandyMod Balls PVP")
            base.StartCoroutine(WaitClearMap());
    }

    public IEnumerator WaitClearMap()
    {
        yield return new WaitForSeconds(.2f);
        base.GetComponent<CandyBalls>().ClearMap();
    }

    public void sendChatContentInfo(string content)
    {
        object[] parameters = new object[] { content, string.Empty };
        basephotonView.RPC("Chat", PhotonTargets.All, parameters);
    }

    public void sendKillInfo(bool t1, string killer, bool t2, string victim, int dmg = 0)
    {
        object[] parameters = new object[] { t1, killer, t2, victim, dmg };
        basephotonView.RPC("updateKillInfo", PhotonTargets.All, parameters);
    }

    [RPC]
    private void showChatContent(string content)
    {
        this.chatContent.Add(content);
        if (this.chatContent.Count > 10)
        {
            this.chatContent.RemoveAt(0);
        }
        GameObject.Find("LabelChatContent").GetComponent<UILabel>().text = string.Empty;
        for (int i = 0; i < this.chatContent.Count; i++)
        {
            UILabel component = GameObject.Find("LabelChatContent").GetComponent<UILabel>();
            component.text = component.text + this.chatContent[i];
        }
    }

    public static void ShowHUDInfoCenter(string content)
    {
        GameObject obj2 = GameObject.Find("LabelInfoCenter");
        if (obj2 != null)
        {
            obj2.GetComponent<UILabel>().text = content;
        }
    }

    public static void ShowHUDInfoCenterADD(string content)
    {
        GameObject obj2 = GameObject.Find("LabelInfoCenter");
        if (obj2 != null)
        {
            UILabel component = obj2.GetComponent<UILabel>();
            component.text = component.text + content;
        }
    }

    private static void ShowHUDInfoTopCenter(string content)
    {
        GameObject obj2 = GameObject.Find("LabelInfoTopCenter");
        if (obj2 != null)
        {
            obj2.GetComponent<UILabel>().text = content;
        }
    }

    public static void ShowHUDInfoTopCenterADD(string content)
    {
        GameObject obj2 = GameObject.Find("LabelInfoTopCenter");
        if (obj2 != null)
        {
            UILabel component = obj2.GetComponent<UILabel>();
            component.text = component.text + content;
        }
    }

    private static void ShowHUDInfoTopLeft(string content)
    {
        GameObject obj2 = GameObject.Find("LabelInfoTopLeft");
        if (obj2 != null)
        {
            obj2.GetComponent<UILabel>().text = content;
        }
    }

    private static void ShowHUDInfoTopRight(string content)
    {
        GameObject obj2 = GameObject.Find("LabelInfoTopRight");
        if (obj2 != null)
        {
            obj2.GetComponent<UILabel>().text = content;
        }
    }

    private static void ShowHUDInfoTopRightMAPNAME(string content)
    {
        GameObject obj2 = GameObject.Find("LabelInfoTopRight");
        if (obj2 != null)
        {
            UILabel component = obj2.GetComponent<UILabel>();
            component.text = component.text + content;
        }
    }

    [RPC]
    private void showResult(string text0, string text1, string text2, string text3, string text4, string text6, PhotonMessageInfo t)
    {
        //if (!this.gameTimesUp)
        //{
        if (t.sender.isMasterClient && text0.Contains((string)PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]) && text6.Contains("Humanity") && text6.Contains("Titan"))
        {
            this.gameTimesUp = true;
            GameObject obj2 = GameObject.Find("UI_IN_GAME");
            NGUITools.SetActive(obj2.GetComponent<UIReferArray>().panels[0], false);
            NGUITools.SetActive(obj2.GetComponent<UIReferArray>().panels[1], false);
            NGUITools.SetActive(obj2.GetComponent<UIReferArray>().panels[2], true);
            NGUITools.SetActive(obj2.GetComponent<UIReferArray>().panels[3], false);
            GameObject.Find("LabelName").GetComponent<UILabel>().text = text0;
            GameObject.Find("LabelKill").GetComponent<UILabel>().text = text1;
            GameObject.Find("LabelDead").GetComponent<UILabel>().text = text2;
            GameObject.Find("LabelMaxDmg").GetComponent<UILabel>().text = text3;
            GameObject.Find("LabelTotalDmg").GetComponent<UILabel>().text = text4;
            GameObject.Find("LabelResultTitle").GetComponent<UILabel>().text = text6;
            Screen.lockCursor = false;
            Screen.showCursor = true;
            IN_GAME_MAIN_CAMERA.gametype = GAMETYPE.STOP;
            gameStart = false;
        }
        //}
    }

    private void SingleShowHUDInfoTopCenter(string content)
    {
        GameObject obj2 = GameObject.Find("LabelInfoTopCenter");
        if (obj2 != null)
        {
            obj2.GetComponent<UILabel>().text = content;
        }
    }

    private void SingleShowHUDInfoTopLeft(string content)
    {
        GameObject obj2 = GameObject.Find("LabelInfoTopLeft");
        if (obj2 != null)
        {
            content = content.Replace("[0]", "[*^_^*]");
            obj2.GetComponent<UILabel>().text = content;
        }
    }

    [RPC]
    public void someOneIsDead(int id = -1)
    {
        if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.PVP_CAPTURE)
        {
            if (id != 0)
            {
                this.PVPtitanScore += 2;
            }
            this.checkPVPpts();
            object[] parameters = new object[] { this.PVPhumanScore, this.PVPtitanScore };
            basephotonView.RPC("refreshPVPStatus", PhotonTargets.Others, parameters);
        }
        else if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.ENDLESS_TITAN)
        {
            this.titanScore++;
        }
        else if (((IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.KILL_TITAN) || (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.SURVIVE_MODE)) || ((IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.BOSS_FIGHT_CT) || (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.TROST)))
        {
            if (isPlayerAllDead())
            {
                this.gameLose();
            }
        }
        else if (IN_GAME_MAIN_CAMERA.gamemode == GAMEMODE.PVP_AHSS)
        {
            if (isPlayerAllDead())
            {
                this.gameLose();
                this.teamWinner = 0;
            }
            if (isTeamAllDead(1))
            {
                this.teamWinner = 2;
                this.gameWin();
            }
            if (isTeamAllDead(2))
            {
                this.teamWinner = 1;
                this.gameWin();
            }
        }
    }
    /*
    public void deleteBackground()
    {
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            string tags = "hero";
            if (obj.name.ToLower().Contains(tags) || obj.name.ToLower().Contains("rock") || obj.name.ToLower().Contains("cube") || obj.name.ToLower().Contains("col"))
            {
                UnityEngine.GameObject.Destroy(obj);
            }
        }
    }*/

    public static bool eventChecker(byte code, PhotonPlayer sender, ExitGames.Client.Photon.Hashtable properties, EventData photonEvent, int key)
    {/*
        if ((InRoomChat.joined) && (code != 0xcb && !sender.isMasterClient) && code != 0xc9 && code != 200 && code != 0xca && code != 0xcc && code != 0xce && code != 0xfd && code != 0xfe && code != 0xff)
        {
            return false;
        }
        if (InRoomChat.joined && (code == 0xc9 || code == 200 || code == 0xce || code == 0xcc || code == 0xca || code == 0xcb || code == 0xfe))
        {
            if (sender == null)
            {
                return false;
            }
            if (code != 0xfe && code != 0xcb)
            {
                if (photonEvent.Parameters.Count == 0)
                {
                    return false;
                }
            }
            if (code == 0xca)
            {
                if (!(photonEvent[0xf5] is ExitGames.Client.Photon.Hashtable))
                {
                    return false;
                }
                ExitGames.Client.Photon.Hashtable evData = (ExitGames.Client.Photon.Hashtable)photonEvent[0xf5];
                object key2 = evData[(byte)0];
                object timestamp = evData[(byte)6];
                object instantiationId = evData[(byte)7];
                if ((int)evData[(byte)7] == 2)
                {
                    return false;
                }
                if (evData == null || !evData.ContainsKey((byte)7) || !evData.ContainsKey((byte)0))
                {
                    return false;
                }
                if (!(key2 is string))
                {
                    return false;
                }
                if (!(timestamp is int))
                {
                    return false;
                }
                if (!(instantiationId is int))
                {
                    return false;
                }
            }
            if (code == 0xce)
            {
                ExitGames.Client.Photon.Hashtable hashtable6 = (ExitGames.Client.Photon.Hashtable)photonEvent[0xf5];
                if (!(hashtable6[(byte)0] is int))
                {
                    return false;
                }
                if (!(hashtable6[(byte)1] is short))
                {
                    return false;
                }
            }
        }
        if (code == 0xfd)
        {
            if (photonEvent.Parameters.Count == 0)
            {
                //kick
                return false;
            }
            if (!(photonEvent[0xfd] is int))
            {
                //kick
                return false;
            }
            if (!(photonEvent[0xfb] is ExitGames.Client.Photon.Hashtable))
            {
                //kick
                return false;
            }
            ExitGames.Client.Photon.Hashtable hashtable = (ExitGames.Client.Photon.Hashtable)photonEvent[0xfb];
            if (!hashtable.ContainsKey("statACL") && FengGameManagerMKII.objectToInt(hashtable["statACL"]) > 150)
            {
                //kick
                return false;
            }
            if (!hashtable.ContainsKey("statBLA") && FengGameManagerMKII.objectToInt(hashtable["statBLA"]) > 125)
            {
                //kick
                return false;
            }
            if (!hashtable.ContainsKey("statGAS") && FengGameManagerMKII.objectToInt(hashtable["statGAS"]) > 150)
            {
                //kick
                return false;
            }
            if (!hashtable.ContainsKey("statSPD") && FengGameManagerMKII.objectToInt(hashtable["statSPD"]) > 150)
            {
                //kick
                return false;
            }
            if (FengGameManagerMKII.objectToInt(hashtable["statSPD"]) + FengGameManagerMKII.objectToInt(hashtable["statBLA"]) + FengGameManagerMKII.objectToInt(hashtable["statGAS"]) + FengGameManagerMKII.objectToInt(hashtable["statACL"]) > 455)
            {
                //kick
                return false;
            }
        }*/
        return true;
    }
    public static int objectToInt(object obj)
    {
        if ((obj != null) && (obj is int))
        {
            return (int)obj;
        }
        return 0;
    }

    public void setBackground()
    {
        //UnityEngine.Object.Instantiate(FengGameManagerMKII.RCassets.Load("backgroundCamera"));
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
        //base.gameObject.AddComponent<PlayerList>();
        //base.gameObject.AddComponent<ForumChat>();
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
        HeroCostume.init();
        CharacterMaterials.init();
        base.name = ("MultiplayerManager");
        UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
        FengGameManagerMKII.heroes.Clear();
        FengGameManagerMKII.eT.Clear();
        FengGameManagerMKII.titans.Clear();
        FengGameManagerMKII.fT.Clear();
        FengGameManagerMKII.cT.Clear();
        FengGameManagerMKII.hooks.Clear();
        FengGameManagerMKII.allheroes.Clear();
        FengGameManagerMKII.alltitans.Clear();
        FengGameManagerMKII.localCT.Clear();
        FengGameManagerMKII.localET.Clear();
        FengGameManagerMKII.localFT.Clear();
        FengGameManagerMKII.localHeroes.Clear();
        FengGameManagerMKII.localTitans.Clear();
        //FengGameManagerMKII.killparameters.Clear();
        FengGameManagerMKII.titanSpawns.Clear();
        FengGameManagerMKII.playersRPC.Clear();
        FengGameManagerMKII.titanSpawners.Clear();
        FengGameManagerMKII.titanSpawnersCopy.Clear();
        FengGameManagerMKII.loadconfig();
        FengGameManagerMKII.afkcount = false;
        FengGameManagerMKII.updateTime = 0f;
        FengGameManagerMKII.settingsGame = new int[50];
        for (int i = 0; i < 50; i++)
        {
            FengGameManagerMKII.settingsGame[i] = 0;
        }
        //this.linkgrab = new string[0];
        FengGameManagerMKII.mapScript = string.Empty;
        FengGameManagerMKII.oldScript = string.Empty;
        FengGameManagerMKII.currentLevel = string.Empty;
        if (FengGameManagerMKII.currentScript == null)
        {
            FengGameManagerMKII.currentScript = string.Empty;
        }
        FengGameManagerMKII.playerSpawns.Clear();
        FengGameManagerMKII.playerSpawnsC.Clear();
        FengGameManagerMKII.playerSpawnsM.Clear();
        FengGameManagerMKII.levelCache.Clear();
        FengGameManagerMKII.groundList.Clear();
        FengGameManagerMKII.intVariables.Clear();
        FengGameManagerMKII.heroHash.Clear();
        FengGameManagerMKII.boolVariables.Clear();
        FengGameManagerMKII.stringVariables.Clear();
        FengGameManagerMKII.floatVariables.Clear();
        FengGameManagerMKII.globalVariables.Clear();
        FengGameManagerMKII.RCRegions.Clear();
        FengGameManagerMKII.RCEvents.Clear();
        FengGameManagerMKII.RCVariableNames.Clear();
        FengGameManagerMKII.RCRegionTriggers.Clear();
        FengGameManagerMKII.playerVariables.Clear();
        FengGameManagerMKII.titanVariables.Clear();
        FengGameManagerMKII.logicLoaded = false;
        FengGameManagerMKII.customLevelLoaded = false;
        FengGameManagerMKII.oldScriptLogic = string.Empty;
        FengGameManagerMKII.currentScriptLogic = string.Empty;
        FengGameManagerMKII.GrabHexes();
        float _width = 1024f / (float)Screen.width;
        float _height = 768f / (float)Screen.height;
        //FengGameManagerMKII.GUIMatrix = new Vector3(_width, _height, 1f);
        FengGameManagerMKII.PView = base.photonView;
        FengGameManagerMKII.MKII = this;
    }

    [RPC]
    public void titanGetKill(PhotonPlayer player, int Damage, string name)
    {
        Damage = Mathf.Max(10, Damage);
        object[] parameters = new object[] { Damage };
        basephotonView.RPC("netShowDamage", player, parameters);
        object[] objArray2 = new object[] { name, false };
        basephotonView.RPC("oneTitanDown", PhotonTargets.MasterClient, objArray2);
        this.sendKillInfo(false, (string)player.customProperties[PhotonPlayerProperty.name], true, name, Damage);
        playerKillInfoUpdate(player, Damage);
    }

    public void titanGetKillbyServer(int Damage, string name)
    {
        Damage = Mathf.Max(10, Damage);
        this.sendKillInfo(false, LoginFengKAI.player.name, true, name, Damage);
        this.netShowDamage(Damage);
        this.oneTitanDown(name, false);
        playerKillInfoUpdate(PhotonNetwork.player, Damage);
    }

    private void tryKick(KickState tmp)
    {
        this.sendChatContentInfo(string.Concat(new object[] { "kicking #", tmp.name, ", ", tmp.getKickCount(), "/", (int)(PhotonNetwork.playerList.Length * 0.5f), "vote" }));
        if (tmp.getKickCount() >= ((int)(PhotonNetwork.playerList.Length * 0.5f)))
        {
            this.kickPhotonPlayer(tmp.name.ToString());
        }
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
        //FengGameManagerMKII.GUIAccess();
        if (!FengGameManagerMKII.settingsSkin[64].StartsWith("e") && IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER)
        {
            if (FengGameManagerMKII.LabelNetworkStatus == null)
            {
                FengGameManagerMKII.LabelNetworkStatus = CacheGameObject.Find<UILabel>("LabelNetworkStatus");
            }
            if (FengGameManagerMKII.LabelNetworkStatus != null)
            {
                FengGameManagerMKII.LabelNetworkStatus.text = PhotonNetwork.connectionStateDetailed.ToString();
                if (PhotonNetwork.connected)
                {
                    UILabel labelNetworkStatus = FengGameManagerMKII.LabelNetworkStatus;
                    labelNetworkStatus.text = string.Concat(labelNetworkStatus.text, " ping:", PhotonNetwork.GetPing());
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
                hero.update();
            }
            foreach (Bullet hook in FengGameManagerMKII.hooks)
            {
                if (hook == null)
                {
                    continue;
                }
                hook.update();
            }
            if (IN_GAME_MAIN_CAMERA.mainCamera != null)
            {
                IN_GAME_MAIN_CAMERA.mainCamera.snapShotUpdate();
            }
            foreach (TITAN localTitan in FengGameManagerMKII.localTitans)
            {
                if (localTitan == null)
                {
                    continue;
                }
                localTitan.update();
            }
            foreach (TitanUpgrade tUpgrade in FengGameManagerMKII.TUpgrade)
            {
                if (tUpgrade == null)
                {
                    continue;
                }
                tUpgrade.update();
            }
            foreach (FEMALE_TITAN fEMALETITAN in FengGameManagerMKII.localFT)
            {
                if (fEMALETITAN == null)
                {
                    continue;
                }
                fEMALETITAN.update();
            }
            foreach (COLOSSAL_TITAN cOLOSSALTITAN in FengGameManagerMKII.cT)
            {
                if (cOLOSSALTITAN == null)
                {
                    continue;
                }
                cOLOSSALTITAN.update();
            }
            foreach (TITAN_EREN tITANEREN in FengGameManagerMKII.eT)
            {
                if (tITANEREN == null)
                {
                    continue;
                }
                tITANEREN.update();
            }
            if (IN_GAME_MAIN_CAMERA.isReady)
            {
                IN_GAME_MAIN_CAMERA.mainCamera.update();
            }
        }
    }

    [RPC]
    private void updateKillInfo(bool t1, string killer, bool t2, string victim, int dmg)
    {
        GameObject obj4;
        GameObject obj2 = GameObject.Find("UI_IN_GAME");
        GameObject obj3 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/KillInfo"));
        for (int i = 0; i < this.killInfoGO.Count; i++)
        {
            obj4 = (GameObject)this.killInfoGO[i];
            if (obj4 != null)
            {
                obj4.GetComponent<KillInfoComponent>().moveOn();
            }
        }
        if (this.killInfoGO.Count > 4)
        {
            obj4 = (GameObject)this.killInfoGO[0];
            if (obj4 != null)
            {
                obj4.GetComponent<KillInfoComponent>().destory();
            }
            this.killInfoGO.RemoveAt(0);
        }
        obj3.transform.parent = obj2.GetComponent<UIReferArray>().panels[0].transform;
        obj3.GetComponent<KillInfoComponent>().show(t1, killer, t2, victim, dmg);
        this.killInfoGO.Add(obj3);
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


