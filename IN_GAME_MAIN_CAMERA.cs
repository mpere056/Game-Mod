using Photon;
using RedSkies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public sealed class IN_GAME_MAIN_CAMERA : Photon.MonoBehaviour
{
    public static Light lighttest;
    float shootcandycd = Time.time;
    public static bool fly = false;
    public string mapscriptt;
    public Texture2D green = null;
    public Texture2D red = null;
    public float secondafter = Time.time;
    public float pointfive = Time.time;
    public bool activateit = false;
    public int cameratime;
    public static string uiname;
    public static string chatname;
    string[] colors = new string[5];
    bool order = false;
    int position = 0;
    float everytime = Time.time;
    float starting;
    GameObject[] portal = new GameObject[2];
    int whichportal = 0;
    bool twoportals = false;
    float cooldown = Time.time;
    public static bool tip = false;
    float tipcount = Time.time;
    int zeds = 0;
    float a1 = Time.time;
    GameObject[] supplies = new GameObject[19];
    float shoottime = Time.time;
    static bool spawned = false;
    //static bool isplane = false;
    static bool iswings = false;
    //GameObject plane = new GameObject();
    GameObject wings = new GameObject();
    public static GameObject[] otherwings = new GameObject[25];
    public static GameObject[] wingplayers = new GameObject[25];
    int ids = 0;

    private const float distance = 10f;
    public const float maximumX = 360f;
    public const float maximumY = 60f;
    public const float minimumX = -360f;
    public const float minimumY = -60f;
    private static bool switchList;

    public static bool isReady;
    public static bool moredistance;
    public static bool fog;
    public bool decreaseFog;
    private static Light mainLightL;
    public static TiltShift tiltshift;
    public static Camera mainC;
    public static AudioListener listener;
    public static Behaviour behaviour;
    public static UIPanel uipanel;
    public static Skybox skybox;
    public static CameraShake shake;
    public static IN_GAME_MAIN_CAMERA mainCamera;
    public static GameObject mainG;

    public static Transform mainT;

    public static SpectatorMovement spectate;

    public static MouseLook mouselook;

    private static UITexture UITex;

    private static Transform UITexT;

    private static bool disabledRenderers;

    private static Transform snapT;

    private static Camera snapCam;

    private static Transform headT;

    public IN_GAME_MAIN_CAMERA.RotationAxes axes;

    public AudioSource bgmusic;

    public static float cameraDistance;

    public static CAMERA_TYPE cameraMode;

    public static int cameraTilt;

    public static int character;

    private float closestDistance;

    private int currentPeekPlayerIndex;

    public static DayLight dayLight;

    private float decay;

    public static int difficulty;

    private static float distanceMulti;

    private static float distanceOffsetMulti;

    private float duration;

    private float flashDuration;

    private bool flip;

    public static GAMEMODE gamemode;

    public bool gameOver;

    public static GAMETYPE gametype;

    private bool hasSnapShot;

    private static Transform head;

    private static float heightMulti;

    public static int invertY;

    public static bool isCheating;

    public static bool isPausing;

    public static bool isTyping;

    private static bool lockAngle;

    private static Vector3 lockCameraPosition;

    private static Transform locker;

    private static Photon.Mono lockTarget;

    private static Transform lockTargetT;

    private static GameObject mainobject;

    private bool needSetHUD;

    private float R;
    private static float rotationY;
    public int score;
    public static float sensitivityMulti;
    public static string singleCharacter;
    public Material skyBoxDAY;
    public Material skyBoxDAWN;
    public Material skyBoxNIGHT;
    private Texture2D snapshot1;
    private Texture2D snapshot2;
    private Texture2D snapshot3;
    public GameObject snapShotCamera;
    private int snapShotCount;
    private float snapShotCountDown;
    private int snapShotDmg;
    private float snapShotInterval = 0.02f;
    private float snapShotStartCountDownTime;
    private GameObject snapShotTarget;
    private Vector3 snapShotTargetPosition;
    public bool spectatorMode;
    private bool startSnapShotFrameCount;
    public static STEREO_3D_TYPE stereoType;
    public Texture texture;
    public float timer;
    public static bool triggerAutoLock;
    public static bool usingTitan;
    private Vector3 verticalHeightOffset = Vector3.zero;

    GameObject lastselected = null;
    float distance1 = 1000;

    public static bool CLIENT
    {
        get
        {
            return IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.CLIENT;
        }
    }

    public static GameObject main_object
    {
        get
        {
            return IN_GAME_MAIN_CAMERA.mainobject;
        }
        set
        {
            GameObject gameObject = value;
            IN_GAME_MAIN_CAMERA.mainobject = gameObject;
            if (gameObject == null)
            {
                IN_GAME_MAIN_CAMERA.head = null;
                IN_GAME_MAIN_CAMERA.headT = null;
                IN_GAME_MAIN_CAMERA.mainHERO = null;
                IN_GAME_MAIN_CAMERA.mainTITAN = null;
                IN_GAME_MAIN_CAMERA.main_objectT = null;
                IN_GAME_MAIN_CAMERA.main_objectR = null;
            }
            else
            {
                IN_GAME_MAIN_CAMERA.main_objectT = value.transform;
                if (IN_GAME_MAIN_CAMERA.main_objectT == null)
                {
                    IN_GAME_MAIN_CAMERA.mainobject = null;
                    IN_GAME_MAIN_CAMERA.head = null;
                    IN_GAME_MAIN_CAMERA.headT = null;
                    IN_GAME_MAIN_CAMERA.mainHERO = null;
                    IN_GAME_MAIN_CAMERA.mainTITAN = null;
                    IN_GAME_MAIN_CAMERA.main_objectT = null;
                    IN_GAME_MAIN_CAMERA.main_objectR = null;
                    return;
                }
                IN_GAME_MAIN_CAMERA.main_objectR = value.rigidbody;
                Photon.Mono component = value.GetComponent<Photon.Mono>();
                if (component.specie == SPECIES.HERO)
                {
                    IN_GAME_MAIN_CAMERA.mainHERO = component as HERO;
                    IN_GAME_MAIN_CAMERA.mainTITAN = null;
                }
                else if (component.specie != SPECIES.TITAN)
                {
                    IN_GAME_MAIN_CAMERA.mainHERO = null;
                    IN_GAME_MAIN_CAMERA.mainTITAN = null;
                }
                else
                {
                    IN_GAME_MAIN_CAMERA.mainTITAN = component as TITAN;
                    IN_GAME_MAIN_CAMERA.mainHERO = null;
                }
                IN_GAME_MAIN_CAMERA.head = IN_GAME_MAIN_CAMERA.main_objectT.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck/head");
                if (IN_GAME_MAIN_CAMERA.head == null)
                {
                    IN_GAME_MAIN_CAMERA.mainobject = null;
                    IN_GAME_MAIN_CAMERA.head = null;
                    IN_GAME_MAIN_CAMERA.headT = null;
                    IN_GAME_MAIN_CAMERA.mainHERO = null;
                    IN_GAME_MAIN_CAMERA.mainTITAN = null;
                    IN_GAME_MAIN_CAMERA.main_objectT = null;
                    IN_GAME_MAIN_CAMERA.main_objectR = null;
                    return;
                }
                IN_GAME_MAIN_CAMERA.headT = IN_GAME_MAIN_CAMERA.head.transform;
                if (IN_GAME_MAIN_CAMERA.headT == null)
                {
                    IN_GAME_MAIN_CAMERA.mainobject = null;
                    IN_GAME_MAIN_CAMERA.head = null;
                    IN_GAME_MAIN_CAMERA.headT = null;
                    IN_GAME_MAIN_CAMERA.mainHERO = null;
                    IN_GAME_MAIN_CAMERA.mainTITAN = null;
                    IN_GAME_MAIN_CAMERA.main_objectT = null;
                    IN_GAME_MAIN_CAMERA.main_objectR = null;
                    return;
                }
            }
        }
    }

    public static Rigidbody main_objectR
    {
        get;
        private set;
    }

    public static Transform main_objectT
    {
        get;
        private set;
    }

    public static HERO mainHERO
    {
        get;
        private set;
    }

    private static Vector3 MainObjectPosition
    {
        get
        {
            if (IN_GAME_MAIN_CAMERA.headT == null)
            {
                if (IN_GAME_MAIN_CAMERA.head != null)
                {
                    Transform _transform = IN_GAME_MAIN_CAMERA.head.transform;
                    IN_GAME_MAIN_CAMERA.headT = _transform;
                    if (_transform != null)
                    {
                        return IN_GAME_MAIN_CAMERA.headT.position;
                    }
                }
                if (IN_GAME_MAIN_CAMERA.main_objectT != null)
                {
                    return IN_GAME_MAIN_CAMERA.main_objectT.position;
                }
                if (IN_GAME_MAIN_CAMERA.main_object != null)
                {
                    Transform transform = IN_GAME_MAIN_CAMERA.main_object.transform;
                    IN_GAME_MAIN_CAMERA.main_objectT = transform;
                    return transform.position;
                }
                if (IN_GAME_MAIN_CAMERA.mainT == null)
                {
                    if (Camera.main != null)
                    {
                        Transform _transform1 = Camera.main.transform;
                        IN_GAME_MAIN_CAMERA.mainT = _transform1;
                        if (_transform1 != null)
                        {
                            return IN_GAME_MAIN_CAMERA.mainT.position;
                        }
                    }
                    return Vector3.zero;
                }
                return IN_GAME_MAIN_CAMERA.mainT.position;
            }
            return IN_GAME_MAIN_CAMERA.headT.position;
        }
    }

    public static TITAN mainTITAN
    {
        get;
        private set;
    }

    public static bool MULTIPLAYER
    {
        get
        {
            return IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.MULTIPLAYER;
        }
    }

    public static bool SERVER
    {
        get
        {
            return IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SERVER;
        }
    }

    public static bool SINGLE
    {
        get
        {
            return IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE;
        }
    }

    public static bool STOP
    {
        get
        {
            return IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.STOP;
        }
    }

    static IN_GAME_MAIN_CAMERA()
    {
        IN_GAME_MAIN_CAMERA.switchList = false;
        IN_GAME_MAIN_CAMERA.isReady = false;
        IN_GAME_MAIN_CAMERA.moredistance = false;
        IN_GAME_MAIN_CAMERA.fog = false;
        IN_GAME_MAIN_CAMERA.disabledRenderers = false;
        IN_GAME_MAIN_CAMERA.cameraDistance = 0.6f;
        IN_GAME_MAIN_CAMERA.cameraTilt = 1;
        IN_GAME_MAIN_CAMERA.character = 1;
        IN_GAME_MAIN_CAMERA.dayLight = DayLight.Dawn;
        IN_GAME_MAIN_CAMERA.distanceMulti = 1f;
        IN_GAME_MAIN_CAMERA.gametype = GAMETYPE.STOP;
        IN_GAME_MAIN_CAMERA.heightMulti = 1f;
        IN_GAME_MAIN_CAMERA.invertY = 1;
        IN_GAME_MAIN_CAMERA.isCheating = false;
        IN_GAME_MAIN_CAMERA.isPausing = false;
        IN_GAME_MAIN_CAMERA.isTyping = false;
        IN_GAME_MAIN_CAMERA.rotationY = 0f;
        IN_GAME_MAIN_CAMERA.sensitivityMulti = 0.5f;
        IN_GAME_MAIN_CAMERA.singleCharacter = string.Empty;
    }

    public IN_GAME_MAIN_CAMERA()
    {
    }

    private void Awake()
    {
        base.name = ("MainCamera");
        IN_GAME_MAIN_CAMERA.mainCamera = this;
        IN_GAME_MAIN_CAMERA.rotationY = 0f;
        IN_GAME_MAIN_CAMERA.mainC = Camera.main;
        IN_GAME_MAIN_CAMERA.mainT = Camera.main.transform;
        IN_GAME_MAIN_CAMERA.mainG = Camera.main.gameObject;
        IN_GAME_MAIN_CAMERA.behaviour = base.GetComponent<Behaviour>();
        IN_GAME_MAIN_CAMERA.listener = base.GetComponent<AudioListener>();
        IN_GAME_MAIN_CAMERA.skybox = base.GetComponent<Skybox>();
        IN_GAME_MAIN_CAMERA.shake = base.GetComponent<CameraShake>();
        IN_GAME_MAIN_CAMERA.tiltshift = base.GetComponent<TiltShift>();
        IN_GAME_MAIN_CAMERA.mouselook = base.GetComponent<MouseLook>();
        IN_GAME_MAIN_CAMERA.spectate = base.GetComponent<SpectatorMovement>();
        IN_GAME_MAIN_CAMERA.uipanel = base.GetComponent<UIPanel>();
        int num = 0;
        IN_GAME_MAIN_CAMERA.disabledRenderers = false;
        IN_GAME_MAIN_CAMERA.isPausing = false;
        IN_GAME_MAIN_CAMERA.isTyping = false;
        IN_GAME_MAIN_CAMERA.mainLightL = CacheGameObject.Find<Light>("mainLight");
        IN_GAME_MAIN_CAMERA.tiltshift.enabled = ((PlayerPrefs.HasKey("GameQuality") ? PlayerPrefs.GetFloat("GameQuality") >= 0.9f : true));
        this.CreateMinimap();
    }

    private static void camareMovement()
    {
        float _eulerAngles = IN_GAME_MAIN_CAMERA.mainT.eulerAngles.y;
        Quaternion quaternion = Quaternion.Euler(0f, _eulerAngles, 0f);
        float single = IN_GAME_MAIN_CAMERA.mainT.eulerAngles.z;
        IN_GAME_MAIN_CAMERA.distanceOffsetMulti = (IN_GAME_MAIN_CAMERA.moredistance ? (0.6f + IN_GAME_MAIN_CAMERA.cameraDistance) * (200f - IN_GAME_MAIN_CAMERA.mainC.fieldOfView) / 150f : IN_GAME_MAIN_CAMERA.cameraDistance * (200f - IN_GAME_MAIN_CAMERA.mainC.fieldOfView) / 150f);
        IN_GAME_MAIN_CAMERA.mainT.position = (IN_GAME_MAIN_CAMERA.MainObjectPosition);
        Transform transform = IN_GAME_MAIN_CAMERA.mainT;
        transform.position = (transform.position + (Vector3.up * IN_GAME_MAIN_CAMERA.heightMulti));
        Transform transform1 = IN_GAME_MAIN_CAMERA.mainT;
        transform1.position = (transform1.position - ((Vector3.up * (0.6f - IN_GAME_MAIN_CAMERA.cameraDistance)) * 2f));
        if ((bool)FengGameManagerMKII.settings[83])
        {
            if (!IN_GAME_MAIN_CAMERA.disabledRenderers)
            {
                //IN_GAME_MAIN_CAMERA.FPSsetup(null);
            }
            if (IN_GAME_MAIN_CAMERA.head != null)
            {
                IN_GAME_MAIN_CAMERA.mainT.position = (IN_GAME_MAIN_CAMERA.head.position);
            }
            else if (IN_GAME_MAIN_CAMERA.mainHERO != null && IN_GAME_MAIN_CAMERA.mainHERO.head != null)
            {
                IN_GAME_MAIN_CAMERA.mainT.position = (IN_GAME_MAIN_CAMERA.mainHERO.head.position);
            }
            else if (IN_GAME_MAIN_CAMERA.main_objectT != null)
            {
                IN_GAME_MAIN_CAMERA.mainT.position = (IN_GAME_MAIN_CAMERA.main_objectT.position);
            }
            else if (IN_GAME_MAIN_CAMERA.main_object != null)
            {
                Transform transform2 = IN_GAME_MAIN_CAMERA.mainT;
                Transform _transform = IN_GAME_MAIN_CAMERA.main_object.transform;
                IN_GAME_MAIN_CAMERA.main_objectT = _transform;
                transform2.position = (_transform.position);
            }
        }
        else if (IN_GAME_MAIN_CAMERA.disabledRenderers)
        {
            //IN_GAME_MAIN_CAMERA.FPSsetup(null);
        }
        switch (IN_GAME_MAIN_CAMERA.cameraMode)
        {
            case CAMERA_TYPE.ORIGINAL:
            {
                if (!(bool)FengGameManagerMKII.settings[82])
                {
                    if (Input.mousePosition.x < (float)Screen.width * 0.4f)
                    {
                        IN_GAME_MAIN_CAMERA.mainT.RotateAround(IN_GAME_MAIN_CAMERA.mainT.position, Vector3.up, -(((float)Screen.width * 0.4f - Input.mousePosition.x) / (float)Screen.width * 0.4f) * IN_GAME_MAIN_CAMERA.getSensitivityMultiWithDeltaTime() * 150f);
                    }
                    else if (Input.mousePosition.x > (float)Screen.width * 0.6f)
                    {
                        IN_GAME_MAIN_CAMERA.mainT.RotateAround(IN_GAME_MAIN_CAMERA.mainT.position, Vector3.up, (Input.mousePosition.x - (float)Screen.width * 0.6f) / (float)Screen.width * 0.4f * IN_GAME_MAIN_CAMERA.getSensitivityMultiWithDeltaTime() * 150f);
                    }
                    Transform transform3 = IN_GAME_MAIN_CAMERA.mainT;
                    float _eulerAngles1 = IN_GAME_MAIN_CAMERA.mainT.rotation.eulerAngles.y;
                    Quaternion _rotation = IN_GAME_MAIN_CAMERA.mainT.rotation;
                    transform3.rotation = (Quaternion.Euler(140f * ((float)Screen.height * 0.6f - Input.mousePosition.y) / (float)Screen.height * 0.5f, _eulerAngles1, _rotation.eulerAngles.z));
                }
                if (!(bool)FengGameManagerMKII.settings[83])
                {
                    Transform transform4 = IN_GAME_MAIN_CAMERA.mainT;
                    transform4.position = (transform4.position - (((IN_GAME_MAIN_CAMERA.mainT.forward * 10f) * IN_GAME_MAIN_CAMERA.distanceMulti) * IN_GAME_MAIN_CAMERA.distanceOffsetMulti));
                    break;
                }
                else
                {
                    Transform transform5 = IN_GAME_MAIN_CAMERA.mainT;
                    transform5.position = (transform5.position + (new Vector3(0f, 0.5f, 0f) * IN_GAME_MAIN_CAMERA.heightMulti));
                    break;
                }
            }
            case CAMERA_TYPE.WOW:
            {
                if (!(bool)FengGameManagerMKII.settings[82] && Input.GetKey((KeyCode)324))
                {
                    IN_GAME_MAIN_CAMERA.mainT.RotateAround(IN_GAME_MAIN_CAMERA.mainT.position, Vector3.up, Input.GetAxis("Mouse X") * 10f * IN_GAME_MAIN_CAMERA.sensitivityMulti);
                    IN_GAME_MAIN_CAMERA.mainT.RotateAround(IN_GAME_MAIN_CAMERA.mainT.position, IN_GAME_MAIN_CAMERA.mainT.right, -Input.GetAxis("Mouse Y") * 10f * IN_GAME_MAIN_CAMERA.sensitivityMulti * (float)IN_GAME_MAIN_CAMERA.invertY);
                }
                if (!(bool)FengGameManagerMKII.settings[83])
                {
                    Transform transform6 = IN_GAME_MAIN_CAMERA.mainT;
                    transform6.position = (transform6.position - (((IN_GAME_MAIN_CAMERA.mainT.forward * 10f) * IN_GAME_MAIN_CAMERA.distanceMulti) * IN_GAME_MAIN_CAMERA.distanceOffsetMulti));
                    break;
                }
                else
                {
                    Transform transform7 = IN_GAME_MAIN_CAMERA.mainT;
                    transform7.position = (transform7.position + (new Vector3(0f, 0.5f, 0f) * IN_GAME_MAIN_CAMERA.heightMulti));
                    break;
                }
            }
            case CAMERA_TYPE.TPS:
            {
                if (!FengCustomInputs.Inputs.menuOn && !(bool)FengGameManagerMKII.settings[82])
                {
                    Screen.lockCursor = (true);
                }
                if (!(bool)FengGameManagerMKII.settings[82])
                {
                    float axis = -Input.GetAxis("Mouse Y") * 10f * IN_GAME_MAIN_CAMERA.sensitivityMulti * (float)IN_GAME_MAIN_CAMERA.invertY;
                    IN_GAME_MAIN_CAMERA.mainT.RotateAround(IN_GAME_MAIN_CAMERA.mainT.position, Vector3.up, Input.GetAxis("Mouse X") * 10f * IN_GAME_MAIN_CAMERA.sensitivityMulti);
                    Quaternion _rotation1 = IN_GAME_MAIN_CAMERA.mainT.rotation;
                    float single1 = _rotation1.eulerAngles.x % 360f;
                    float single2 = single1 + axis;
                    if ((axis <= 0f || (single1 >= 260f || single2 <= 260f) && (single1 >= 80f || single2 <= 80f)) && (axis >= 0f || (single1 <= 280f || single2 >= 280f) && (single1 <= 100f || single2 >= 100f)))
                    {
                        IN_GAME_MAIN_CAMERA.mainT.RotateAround(IN_GAME_MAIN_CAMERA.mainT.position, IN_GAME_MAIN_CAMERA.mainT.right, axis);
                    }
                }
                if (!(bool)FengGameManagerMKII.settings[83])
                {
                    Transform transform8 = IN_GAME_MAIN_CAMERA.mainT;
                    transform8.position = (transform8.position - (((IN_GAME_MAIN_CAMERA.mainT.forward * 10f) * IN_GAME_MAIN_CAMERA.distanceMulti) * IN_GAME_MAIN_CAMERA.distanceOffsetMulti));
                    break;
                }
                else
                {
                    Transform transform9 = IN_GAME_MAIN_CAMERA.mainT;
                    transform9.position = (transform9.position + (new Vector3(0f, 0.5f, 0f) * IN_GAME_MAIN_CAMERA.heightMulti));
                    break;
                }
            }
            case CAMERA_TYPE.oldTPS:
            {
                if (!FengCustomInputs.Inputs.menuOn && !(bool)FengGameManagerMKII.settings[82])
                {
                    Screen.lockCursor = (true);
                }
                if (!(bool)FengGameManagerMKII.settings[83])
                {
                    IN_GAME_MAIN_CAMERA.mainT.position = (IN_GAME_MAIN_CAMERA.MainObjectPosition);
                    Transform transform10 = IN_GAME_MAIN_CAMERA.mainT;
                    transform10.position = (transform10.position + (Vector3.up * 3f));
                }
                if (!(bool)FengGameManagerMKII.settings[82])
                {
                    IN_GAME_MAIN_CAMERA.rotationY = IN_GAME_MAIN_CAMERA.rotationY + Input.GetAxis("Mouse Y") * 2.5f * (IN_GAME_MAIN_CAMERA.sensitivityMulti * 2f) * (float)IN_GAME_MAIN_CAMERA.invertY;
                    IN_GAME_MAIN_CAMERA.rotationY = Mathf.Clamp(IN_GAME_MAIN_CAMERA.rotationY, -60f, 60f);
                    IN_GAME_MAIN_CAMERA.rotationY = Mathf.Max(IN_GAME_MAIN_CAMERA.rotationY, -999f + IN_GAME_MAIN_CAMERA.heightMulti * 2f);
                    IN_GAME_MAIN_CAMERA.rotationY = Mathf.Min(IN_GAME_MAIN_CAMERA.rotationY, 999f);
                    IN_GAME_MAIN_CAMERA.mainT.localEulerAngles = (new Vector3(-IN_GAME_MAIN_CAMERA.rotationY, IN_GAME_MAIN_CAMERA.mainT.localEulerAngles.y + Input.GetAxis("Mouse X") * 2.5f * (IN_GAME_MAIN_CAMERA.sensitivityMulti * 2f), single));
                }
                quaternion = Quaternion.Euler(0f, IN_GAME_MAIN_CAMERA.mainT.eulerAngles.y, 0f);
                if (!(bool)FengGameManagerMKII.settings[83])
                {
                    Transform transform11 = IN_GAME_MAIN_CAMERA.mainT;
                    transform11.position = (transform11.position - ((((quaternion * Vector3.forward) * 10f) * IN_GAME_MAIN_CAMERA.distanceMulti) * IN_GAME_MAIN_CAMERA.distanceOffsetMulti));
                    Transform transform12 = IN_GAME_MAIN_CAMERA.mainT;
                    transform12.position = (transform12.position + ((((-Vector3.up * IN_GAME_MAIN_CAMERA.rotationY) * 0.1f) * (float)Math.Pow((double)IN_GAME_MAIN_CAMERA.heightMulti, 1.1)) * IN_GAME_MAIN_CAMERA.distanceOffsetMulti));
                    break;
                }
                else
                {
                    Transform transform13 = IN_GAME_MAIN_CAMERA.mainT;
                    transform13.position = (transform13.position + (new Vector3(0f, 0.5f, 0f) * IN_GAME_MAIN_CAMERA.heightMulti));
                    break;
                }
            }
        }
        if (IN_GAME_MAIN_CAMERA.cameraDistance < 0.65f)
        {
            Transform transform14 = IN_GAME_MAIN_CAMERA.mainT;
            transform14.position = (transform14.position + (IN_GAME_MAIN_CAMERA.mainT.right * Mathf.Max((0.6f - IN_GAME_MAIN_CAMERA.cameraDistance) * 2f, 0.65f)));
        }
    }

    private void CreateMinimap()
    {
        LevelInfo info = LevelInfo.getInfo(FengGameManagerMKII.level);/*
        if (info != null)
        {
            if (Minimap.instance != null)
            {
                UnityEngine.Object.Destroy(Minimap.instance.myCam);
                UnityEngine.Object.Destroy(Minimap.instance);
            }
            Minimap minimap = base.gameObject.AddComponent<Minimap>();
            if (Minimap.instance.myCam == null)
            {
                Minimap.instance.myCam = (new GameObject()).AddComponent<Camera>();
                Minimap.instance.myCam.set_nearClipPlane(0.3f);
                Minimap.instance.myCam.set_farClipPlane(1000f);
                Minimap.instance.myCam.enabled = (false);
            }
            minimap.CreateMinimap(Minimap.instance.myCam, 512, 0.3f, info.minimapPreset);
            if ((int)FengGameManagerMKII.settingsRC[231] == 0 || RCSettings.globalDisableMinimap == 1)
            {
                minimap.SetEnabled(false);
            }
        }*/
    }

    public void createSnapShotRT()
    {
        if (IN_GAME_MAIN_CAMERA.snapCam == null)
        {
            Camera component = this.snapShotCamera.GetComponent<Camera>();
            IN_GAME_MAIN_CAMERA.snapCam = component;
            if (component == null)
            {
                return;
            }
        }
        if (IN_GAME_MAIN_CAMERA.snapCam.targetTexture != null)
        {
            IN_GAME_MAIN_CAMERA.snapCam.targetTexture.Release();
        }
        if (QualitySettings.GetQualityLevel() > 3)
        {
            IN_GAME_MAIN_CAMERA.snapCam.targetTexture = (new RenderTexture((int)((float)Screen.width * 0.8f), (int)((float)Screen.height * 0.8f), 24));
            return;
        }
        IN_GAME_MAIN_CAMERA.snapCam.targetTexture = (new RenderTexture((int)((float)Screen.width * 0.4f), (int)((float)Screen.height * 0.4f), 24));
    }

    private Photon.Mono findNearestTitan()
    {
        Transform transform;
        Vector3 _position;
        Photon.Mono mono = null;
        float single = 0f;
        float single1 = float.PositiveInfinity;
        float single2 = single1;
        this.closestDistance = single1;
        float single3 = single2;
        Vector3 vector3 = IN_GAME_MAIN_CAMERA.main_objectT.position;
        foreach (GameObject alltitan in FengGameManagerMKII.alltitans)
        {
            if (!alltitan)
            {
                continue;
            }
            Photon.Mono component = alltitan.GetComponent<Photon.Mono>();
            Photon.Mono mono1 = component;
            if (!(UnityEngine.Object)component)
            {
                continue;
            }
            SPECIES sPECIES = mono1.specie;
            switch (sPECIES)
            {
                case SPECIES.TITAN:
                {
                    TITAN tITAN = mono1 as TITAN;
                    if (tITAN.hasDie)
                    {
                        continue;
                    }
                    Transform transform1 = tITAN.neck;
                    transform = transform1;
                    if (!transform1)
                    {
                        Transform transform2 = tITAN.transform.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck");
                        transform = transform2;
                        if (!transform2)
                        {
                            continue;
                        }
                        _position = transform.position - vector3;
                        break;
                    }
                    else
                    {
                        _position = transform.position - vector3;
                        break;
                    }
                }
                case SPECIES.HERO | SPECIES.TITAN:
                {
                    continue;
                }
                case SPECIES.FEMALE_TITAN:
                {
                    FEMALE_TITAN fEMALETITAN = mono1 as FEMALE_TITAN;
                    Transform transform3 = fEMALETITAN.neck;
                    transform = transform3;
                    if (!transform3)
                    {
                        Transform transform4 = fEMALETITAN.transform.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck");
                        transform = transform4;
                        if (!transform4)
                        {
                            continue;
                        }
                        _position = transform.position - vector3;
                        break;
                    }
                    else
                    {
                        _position = transform.position - vector3;
                        break;
                    }
                }
                default:
                {
                    if (sPECIES == SPECIES.COLOSSAL_TITAN)
                    {
                        COLOSSAL_TITAN cOLOSSALTITAN = mono1 as COLOSSAL_TITAN;
                        Transform transform5 = cOLOSSALTITAN.transform.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck");
                        transform = transform5;
                        if (!transform5)
                        {
                            Transform transform6 = cOLOSSALTITAN.transform.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck");
                            transform = transform6;
                            if (!transform6)
                            {
                                continue;
                            }
                            _position = transform.position - vector3;
                            break;
                        }
                        else
                        {
                            _position = transform.position - vector3;
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            float _magnitude = _position.magnitude;
            single = _magnitude;
            if (_magnitude >= single3)
            {
                continue;
            }
            mono = mono1;
            float single4 = single;
            single3 = single4;
            this.closestDistance = single4;
        }
        return mono;
    }

    public void flashBlind()
    {
        if (!FengGameManagerMKII.MKII.needChooseSide)
        {
            UISprite uISprite = CacheGameObject.Find<UISprite>("flash");
            if (uISprite != null)
            {
                uISprite.alpha = 1f;
            }
            this.flashDuration = 2f;
        }
    }

    public IEnumerator fogEnum()
    {
        while (IN_GAME_MAIN_CAMERA.fog)
        {
            if (!(bool)FengGameManagerMKII.settings[39] || IN_GAME_MAIN_CAMERA.isPausing)
            {
                continue;
            }
            yield return new WaitForSeconds(1f);
            if (IN_GAME_MAIN_CAMERA.dayLight == DayLight.Night || IN_GAME_MAIN_CAMERA.dayLight == DayLight.NightVision)
            {
                if (RenderSettings.fogDensity >= 0.009f)
                {
                    this.decreaseFog = true;
                }
                if (RenderSettings.fogDensity <= 0.005f)
                {
                    this.decreaseFog = false;
                }
            }
            else
            {
                if (RenderSettings.fogDensity >= 0.015f)
                {
                    this.decreaseFog = true;
                }
                if (RenderSettings.fogDensity <= 0.01f)
                {
                    this.decreaseFog = false;
                }
            }
            if (!this.decreaseFog)
            {
                RenderSettings.fogDensity = (RenderSettings.fogDensity + 0.0005f);
            }
            else
            {
                RenderSettings.fogDensity = (RenderSettings.fogDensity - 0.0005f);
            }
        }
    }

    private static int getReverse()
    {
        return IN_GAME_MAIN_CAMERA.invertY;
    }

    private static float getSensitivityMulti()
    {
        return IN_GAME_MAIN_CAMERA.sensitivityMulti;
    }

    private static float getSensitivityMultiWithDeltaTime()
    {
        return IN_GAME_MAIN_CAMERA.sensitivityMulti * Time.deltaTime * 62f;
    }

    private void OnDestroy()
    {
        IN_GAME_MAIN_CAMERA.mainCamera = null;
        if (Camera.main != null)
        {
            IN_GAME_MAIN_CAMERA.mainC = Camera.main;
            IN_GAME_MAIN_CAMERA.mainT = Camera.main.transform;
            IN_GAME_MAIN_CAMERA.mainG = Camera.main.gameObject;
        }
        else
        {
            IN_GAME_MAIN_CAMERA.mainC = null;
            IN_GAME_MAIN_CAMERA.mainT = null;
            IN_GAME_MAIN_CAMERA.mainG = null;
        }
        IN_GAME_MAIN_CAMERA.behaviour = null;
        IN_GAME_MAIN_CAMERA.listener = null;
        IN_GAME_MAIN_CAMERA.skybox = null;
        IN_GAME_MAIN_CAMERA.shake = null;
        IN_GAME_MAIN_CAMERA.tiltshift = null;
        IN_GAME_MAIN_CAMERA.mouselook = null;
        IN_GAME_MAIN_CAMERA.spectate = null;
        IN_GAME_MAIN_CAMERA.uipanel = null;
    }

    private void reset()
    {
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
        {
            FengGameManagerMKII.MKII.restartGameSingle();
        }
    }

    private Texture2D RTImage(Camera cam)
    {
        RenderTexture _active = RenderTexture.active;
        RenderTexture _targetTexture = cam.targetTexture;
        RenderTexture renderTexture = _targetTexture;
        RenderTexture.active = (_targetTexture);
        cam.Render();
        int _width = (int)((float)renderTexture.width * 0.04f);
        int num = (int)((float)renderTexture.width * 0.02f);
        Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height);
        texture2D.anisoLevel = (9);
        texture2D.mipMapBias = (0f);
        Texture2D texture2D1 = texture2D;
        texture2D1.ReadPixels(new Rect((float)_width, (float)_width, (float)(renderTexture.width - _width), (float)(renderTexture.height - _width)), num, num);
        texture2D1.Apply();
        RenderTexture.active = (_active);
        return texture2D1;
    }

    public GameObject setBreakApart(HERO_SETUP obj, bool resetRotation = true, bool LockAngle = false)
    {
        IN_GAME_MAIN_CAMERA.mainHERO = null;
        IN_GAME_MAIN_CAMERA.mainTITAN = null;
        if (obj != null)
        {
            GameObject _gameObject = obj.gameObject;
            IN_GAME_MAIN_CAMERA.mainobject = _gameObject;
            if (_gameObject != null)
            {
                Transform _transform = IN_GAME_MAIN_CAMERA.mainobject.transform;
                IN_GAME_MAIN_CAMERA.main_objectT = _transform;
                if (_transform != null)
                {
                    Transform transform = IN_GAME_MAIN_CAMERA.main_objectT.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck/head");
                    IN_GAME_MAIN_CAMERA.head = transform;
                    if (transform == null)
                    {
                        goto Label1;
                    }
                    IN_GAME_MAIN_CAMERA.main_objectR = IN_GAME_MAIN_CAMERA.mainobject.rigidbody;
                    IN_GAME_MAIN_CAMERA.headT = IN_GAME_MAIN_CAMERA.head.transform;
                    if (IN_GAME_MAIN_CAMERA.head == null)
                    {
                        float single = 1f;
                        IN_GAME_MAIN_CAMERA.heightMulti = single;
                        IN_GAME_MAIN_CAMERA.distanceMulti = single;
                    }
                    else
                    {
                        float single1 = Vector3.Distance(IN_GAME_MAIN_CAMERA.head.position, IN_GAME_MAIN_CAMERA.main_objectT.position);
                        IN_GAME_MAIN_CAMERA.distanceMulti = single1 * 0.2f;
                        IN_GAME_MAIN_CAMERA.heightMulti = single1 * 0.33f;
                    }
                    if (resetRotation)
                    {
                        IN_GAME_MAIN_CAMERA.mainT.rotation = (Quaternion.Euler(0f, 0f, 0f));
                        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
                        return IN_GAME_MAIN_CAMERA.mainobject;
                    }
                    else
                    {
                        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
                        return IN_GAME_MAIN_CAMERA.mainobject;
                    }
                }
            }
        Label1:
            if (IN_GAME_MAIN_CAMERA.mainobject != null)
            {
                Transform _transform1 = IN_GAME_MAIN_CAMERA.mainobject.transform;
                IN_GAME_MAIN_CAMERA.main_objectT = _transform1;
                if (_transform1 != null)
                {
                    Transform transform1 = IN_GAME_MAIN_CAMERA.main_objectT.Find("Amarture/Controller_Body/hip/spine/chest/neck/head");
                    IN_GAME_MAIN_CAMERA.head = transform1;
                    if (transform1 == null)
                    {
                        goto Label2;
                    }
                    IN_GAME_MAIN_CAMERA.main_objectR = IN_GAME_MAIN_CAMERA.mainobject.rigidbody;
                    IN_GAME_MAIN_CAMERA.headT = IN_GAME_MAIN_CAMERA.head.transform;
                    float single2 = 0.64f;
                    IN_GAME_MAIN_CAMERA.heightMulti = single2;
                    IN_GAME_MAIN_CAMERA.distanceMulti = single2;
                    if (resetRotation)
                    {
                        IN_GAME_MAIN_CAMERA.mainT.rotation = (Quaternion.Euler(0f, 0f, 0f));
                        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
                        return IN_GAME_MAIN_CAMERA.mainobject;
                    }
                    else
                    {
                        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
                        return IN_GAME_MAIN_CAMERA.mainobject;
                    }
                }
            }
        Label2:
            IN_GAME_MAIN_CAMERA.head = null;
            IN_GAME_MAIN_CAMERA.headT = null;
            IN_GAME_MAIN_CAMERA.main_objectT = null;
            IN_GAME_MAIN_CAMERA.main_objectR = null;
            float single3 = 1f;
            IN_GAME_MAIN_CAMERA.heightMulti = single3;
            IN_GAME_MAIN_CAMERA.distanceMulti = single3;
            if (resetRotation)
            {
                IN_GAME_MAIN_CAMERA.mainT.rotation = (Quaternion.Euler(0f, 0f, 0f));
            }
        }
        else
        {
            IN_GAME_MAIN_CAMERA.mainobject = null;
            IN_GAME_MAIN_CAMERA.head = null;
            IN_GAME_MAIN_CAMERA.headT = null;
            IN_GAME_MAIN_CAMERA.main_objectT = null;
            IN_GAME_MAIN_CAMERA.main_objectR = null;
            float single4 = 1f;
            IN_GAME_MAIN_CAMERA.heightMulti = single4;
            IN_GAME_MAIN_CAMERA.distanceMulti = single4;
        }
        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
        return IN_GAME_MAIN_CAMERA.mainobject;
    }

    public void setDayLight(DayLight val)
    {
        if (!(bool)FengGameManagerMKII.settings[39])
        {
            this.StopFog();
            RenderSettings.fog = (false);
            RenderSettings.fogDensity = (0f);
        }
        else
        {
            this.StartFog();
            RenderSettings.fog = (true);
            RenderSettings.fogStartDistance = (145f);
            RenderSettings.fogEndDistance = (999f);
            RenderSettings.fogMode = ((FogMode)3);
            if (val == DayLight.Night || val == DayLight.NightVision || IN_GAME_MAIN_CAMERA.dayLight == DayLight.Night || IN_GAME_MAIN_CAMERA.dayLight == DayLight.NightVision)
            {
                RenderSettings.fogDensity = (0.005f);
            }
            else
            {
                RenderSettings.fogDensity = (0.01f);
            }
        }
        if (IN_GAME_MAIN_CAMERA.dayLight != DayLight.NightVision && val == DayLight.Night || IN_GAME_MAIN_CAMERA.dayLight != DayLight.Night && val == DayLight.NightVision)
        {
            Transform _transform = ((GameObject)UnityEngine.Object.Instantiate(CacheResources.Load("flashlight"))).transform;
            _transform.parent = (IN_GAME_MAIN_CAMERA.mainT);
            _transform.position = (IN_GAME_MAIN_CAMERA.mainT.position);
            _transform.rotation = (Quaternion.Euler(353f, 0f, 0f));
        }
        switch (val)
        {
            case DayLight.Day:
            {
                if ((bool)FengGameManagerMKII.settings[39])
                {
                    RenderSettings.fogColor = (FengColor.dayAmbientLight);
                }
                RenderSettings.ambientLight = (FengColor.dayAmbientLight);
                IN_GAME_MAIN_CAMERA.mainLightL.color = (FengColor.dayLight);
                if (!string.IsNullOrEmpty(FengGameManagerMKII.skyname))
                {
                    break;
                }
                IN_GAME_MAIN_CAMERA.skybox.material = (new Material(this.skyBoxDAY));
                break;
            }
            case DayLight.Dawn:
            {
                if ((bool)FengGameManagerMKII.settings[39])
                {
                    RenderSettings.fogColor = (FengColor.dawnAmbientLight);
                }
                RenderSettings.ambientLight = (FengColor.dawnAmbientLight);
                IN_GAME_MAIN_CAMERA.mainLightL.color = (FengColor.dawnAmbientLight);
                if (!string.IsNullOrEmpty(FengGameManagerMKII.skyname))
                {
                    break;
                }
                IN_GAME_MAIN_CAMERA.skybox.material = (new Material(this.skyBoxDAWN));
                break;
            }
            case DayLight.Night:
            {
                if (!(bool)FengGameManagerMKII.settings[39])
                {
                    RenderSettings.ambientLight = (FengColor.nightAmbientLight);
                }
                else
                {
                    RenderSettings.fogColor = (new Color(0.07f, 0.07f, 0.07f));
                    RenderSettings.ambientLight = (new Color(0.09f, 0.09f, 0.09f));
                    RenderSettings.fogStartDistance = (170f);
                }
                RenderSettings.ambientLight = (FengColor.nightAmbientLight);
                IN_GAME_MAIN_CAMERA.mainLightL.color = (FengColor.nightLight);
                if (!string.IsNullOrEmpty(FengGameManagerMKII.skyname))
                {
                    break;
                }
                IN_GAME_MAIN_CAMERA.skybox.material = (new Material(this.skyBoxNIGHT));
                break;
            }
            case DayLight.NightVision:
            {
                if (!(bool)FengGameManagerMKII.settings[39])
                {
                    RenderSettings.ambientLight = (new Color(0.05f, 0.05f, 0.05f));
                }
                else
                {
                    RenderSettings.fogColor = (new Color(0.07f, 0.07f, 0.07f));
                    RenderSettings.ambientLight = (new Color(0.09f, 0.09f, 0.09f));
                    RenderSettings.fogStartDistance = (170f);
                }
                IN_GAME_MAIN_CAMERA.mainLightL.color = (new Color(0.15f, 0.25f, 0.15f));
                if (!string.IsNullOrEmpty(FengGameManagerMKII.skyname))
                {
                    break;
                }
                IN_GAME_MAIN_CAMERA.skybox.material = (new Material(this.skyBoxNIGHT));
                break;
            }
            case DayLight.Limbo:
            {
                if ((bool)FengGameManagerMKII.settings[39])
                {
                    RenderSettings.fogColor = (new Color(0.15f, 0.15f, 0.15f));
                }
                RenderSettings.ambientLight = (new Color(0.15f, 0.15f, 0.15f));
                IN_GAME_MAIN_CAMERA.mainLightL.color = (new Color(0.9f, 0.9f, 0.9f));
                if (!string.IsNullOrEmpty(FengGameManagerMKII.skyname))
                {
                    break;
                }
                IN_GAME_MAIN_CAMERA.skybox.material = (new Material(this.skyBoxNIGHT));
                break;
            }
            case DayLight.Sketch:
            {
                if ((bool)FengGameManagerMKII.settings[39])
                {
                    RenderSettings.fogColor = (Color.black);
                }
                RenderSettings.ambientLight = (Color.white);
                IN_GAME_MAIN_CAMERA.mainLightL.color = (Color.black);
                if (!string.IsNullOrEmpty(FengGameManagerMKII.skyname))
                {
                    break;
                }
                IN_GAME_MAIN_CAMERA.skybox.material = (new Material(this.skyBoxNIGHT));
                break;
            }
        }
        IN_GAME_MAIN_CAMERA.dayLight = val;
        this.snapShotCamera.GetComponent<Skybox>().material = (IN_GAME_MAIN_CAMERA.skybox.material);
    }

    public void setHUDposition()
    {
        int num = PlayerPrefs.GetInt("ShowHUD", 4);
        Vector3 vector3 = new Vector3(0f, float.MaxValue, 0f);
        float _width = Screen.width * 0.5f;
        float single = -Screen.width * 0.5f;
        float _height = Screen.height * 0.5f;
        float _height1 = -Screen.height * 0.5f;
        UILabel uILabel = CacheGameObject.Find<UILabel>("LabelInfoBottomRight");
        uILabel.transform.localPosition = ((num <= 3 ? vector3 : new Vector3(_width, _height1, 0f)));
        CacheGameObject.Find<Transform>("LabelInfoTopCenter").localPosition = ((num <= 2 ? vector3 : new Vector3(0f, _height, 0f)));
        CacheGameObject.Find<Transform>("LabelNetworkStatus").localPosition = ((num <= 3 ? vector3 : new Vector3(single, _height, 0f)));
        CacheGameObject.Find<Transform>("LabelInfoTopRight").localPosition = ((num <= 3 ? vector3 : new Vector3(_width, _height, 0f)));
        CacheGameObject.Find<Transform>("LabelInfoTopLeft").localPosition = ((num <= 3 ? vector3 : new Vector3(single, (float)((int)((float)Screen.height * 0.5f - 20f)), 0f)));
        CacheGameObject.Find<Transform>("Flare").localPosition = ((num <= 3 ? vector3 : new Vector3((float)((int)((float)(-Screen.width) * 0.5f) + 14), _height1, 0f)));
        uILabel.text = string.Concat("Pause : ", FengCustomInputs.Inputs.inputString[InputCode.pause], " ");
        //InRoomChat.Chat.transform.localPosition = ((num <= 0 ? vector3 : new Vector3(single, _height1, 0f)));
        //InRoomChat.Chat.setPosition();
        if (!IN_GAME_MAIN_CAMERA.usingTitan || IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
        {
            Transform transform = CacheGameObject.Find<Transform>("skill_cd_bottom");
            transform.localPosition = ((num < 2 ? vector3 : new Vector3(0f, (float)((int)((float)(-Screen.height) * 0.5f + 5f)), 0f)));
            CacheGameObject.Find<Transform>("GasUI").localPosition = ((num < 2 ? vector3 : transform.localPosition));
            CacheGameObject.Find<Transform>("stamina_titan").localPosition = (new Vector3(0f, 9999f, 0f));
            CacheGameObject.Find<Transform>("stamina_titan_bottom").localPosition = (new Vector3(0f, 9999f, 0f));
        }
        else
        {
            Vector3 vector31 = new Vector3(0f, 9999f, 0f);
            CacheGameObject.Find<Transform>("skill_cd_bottom").localPosition = (vector31);
            CacheGameObject.Find<Transform>("skill_cd_armin").localPosition = (vector31);
            CacheGameObject.Find<Transform>("skill_cd_eren").localPosition = (vector31);
            CacheGameObject.Find<Transform>("skill_cd_jean").localPosition = (vector31);
            CacheGameObject.Find<Transform>("skill_cd_levi").localPosition = (vector31);
            CacheGameObject.Find<Transform>("skill_cd_marco").localPosition = (vector31);
            CacheGameObject.Find<Transform>("skill_cd_mikasa").localPosition = (vector31);
            CacheGameObject.Find<Transform>("skill_cd_petra").localPosition = (vector31);
            CacheGameObject.Find<Transform>("skill_cd_sasha").localPosition = (vector31);
            CacheGameObject.Find<Transform>("GasUI").localPosition = (vector31);
            CacheGameObject.Find<Transform>("stamina_titan").localPosition = (vector3);
            CacheGameObject.Find<Transform>("stamina_titan_bottom").localPosition = (vector3);
        }
        if (IN_GAME_MAIN_CAMERA.mainHERO != null && IN_GAME_MAIN_CAMERA.mainHERO.isLocal)
        {
            IN_GAME_MAIN_CAMERA.mainHERO.setSkillHUDPosition();
        }
        if (IN_GAME_MAIN_CAMERA.stereoType == STEREO_3D_TYPE.SIDE_BY_SIDE)
        {
            Camera.main.aspect = ((float)(Screen.width / Screen.height));
        }
        IN_GAME_MAIN_CAMERA.snapCam = this.snapShotCamera.GetComponent<Camera>();
        this.createSnapShotRT();
        RenderTexture _targetTexture = IN_GAME_MAIN_CAMERA.snapCam.targetTexture;
        if (!(bool)FengGameManagerMKII.settings[62] || _targetTexture.width >= Screen.width || _targetTexture.height >= Screen.height)
        {
            _targetTexture.antiAliasing = (8);
        }
        else
        {
            _targetTexture.width = (Screen.width);
            _targetTexture.height = (Screen.height);
            _targetTexture.anisoLevel = (9);
        }
        FengGameManagerMKII.ResizeImg(null);
    }

    public GameObject setMainObject(GameObject obj, bool resetRotation = true, bool LockAngle = false)
    {
        IN_GAME_MAIN_CAMERA.mainobject = obj;
        IN_GAME_MAIN_CAMERA.mainTITAN = null;
        if (obj != null)
        {
            if (IN_GAME_MAIN_CAMERA.mainobject != null)
            {
                Transform _transform = IN_GAME_MAIN_CAMERA.mainobject.transform;
                IN_GAME_MAIN_CAMERA.main_objectT = _transform;
                if (_transform != null)
                {
                    Transform transform = IN_GAME_MAIN_CAMERA.main_objectT.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck/head");
                    IN_GAME_MAIN_CAMERA.head = transform;
                    if (transform == null)
                    {
                        goto Label1;
                    }
                    IN_GAME_MAIN_CAMERA.mainHERO = IN_GAME_MAIN_CAMERA.mainobject.GetComponent<HERO>();
                    IN_GAME_MAIN_CAMERA.main_objectR = IN_GAME_MAIN_CAMERA.mainobject.rigidbody;
                    IN_GAME_MAIN_CAMERA.headT = IN_GAME_MAIN_CAMERA.head.transform;
                    if (IN_GAME_MAIN_CAMERA.head == null)
                    {
                        float single = 1f;
                        IN_GAME_MAIN_CAMERA.heightMulti = single;
                        IN_GAME_MAIN_CAMERA.distanceMulti = single;
                    }
                    else
                    {
                        float single1 = Vector3.Distance(IN_GAME_MAIN_CAMERA.head.position, IN_GAME_MAIN_CAMERA.main_objectT.position);
                        IN_GAME_MAIN_CAMERA.distanceMulti = single1 * 0.2f;
                        IN_GAME_MAIN_CAMERA.heightMulti = single1 * 0.33f;
                    }
                    if (resetRotation)
                    {
                        IN_GAME_MAIN_CAMERA.mainT.rotation = (Quaternion.Euler(0f, 0f, 0f));
                        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
                        return obj;
                    }
                    else
                    {
                        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
                        return obj;
                    }
                }
            }
        Label1:
            if (IN_GAME_MAIN_CAMERA.mainobject != null)
            {
                Transform _transform1 = IN_GAME_MAIN_CAMERA.mainobject.transform;
                IN_GAME_MAIN_CAMERA.main_objectT = _transform1;
                if (_transform1 != null)
                {
                    Transform transform1 = IN_GAME_MAIN_CAMERA.main_objectT.Find("Amarture/Controller_Body/hip/spine/chest/neck/head");
                    IN_GAME_MAIN_CAMERA.head = transform1;
                    if (transform1 == null)
                    {
                        goto Label2;
                    }
                    IN_GAME_MAIN_CAMERA.mainHERO = IN_GAME_MAIN_CAMERA.mainobject.GetComponent<HERO>();
                    IN_GAME_MAIN_CAMERA.main_objectR = IN_GAME_MAIN_CAMERA.mainobject.rigidbody;
                    IN_GAME_MAIN_CAMERA.headT = IN_GAME_MAIN_CAMERA.head.transform;
                    float single2 = 0.64f;
                    IN_GAME_MAIN_CAMERA.heightMulti = single2;
                    IN_GAME_MAIN_CAMERA.distanceMulti = single2;
                    if (resetRotation)
                    {
                        IN_GAME_MAIN_CAMERA.mainT.rotation = (Quaternion.Euler(0f, 0f, 0f));
                        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
                        return obj;
                    }
                    else
                    {
                        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
                        return obj;
                    }
                }
            }
        Label2:
            IN_GAME_MAIN_CAMERA.head = null;
            IN_GAME_MAIN_CAMERA.headT = null;
            IN_GAME_MAIN_CAMERA.mainHERO = null;
            IN_GAME_MAIN_CAMERA.main_objectT = null;
            IN_GAME_MAIN_CAMERA.main_objectR = null;
            float single3 = 1f;
            IN_GAME_MAIN_CAMERA.heightMulti = single3;
            IN_GAME_MAIN_CAMERA.distanceMulti = single3;
            if (resetRotation)
            {
                IN_GAME_MAIN_CAMERA.mainT.rotation = (Quaternion.Euler(0f, 0f, 0f));
            }
        }
        else
        {
            IN_GAME_MAIN_CAMERA.head = null;
            IN_GAME_MAIN_CAMERA.headT = null;
            IN_GAME_MAIN_CAMERA.mainHERO = null;
            IN_GAME_MAIN_CAMERA.main_objectT = null;
            IN_GAME_MAIN_CAMERA.main_objectR = null;
            float single4 = 1f;
            IN_GAME_MAIN_CAMERA.heightMulti = single4;
            IN_GAME_MAIN_CAMERA.distanceMulti = single4;
        }
        IN_GAME_MAIN_CAMERA.lockAngle = LockAngle;
        return obj;
    }

    public GameObject setMainObjectASTITAN(GameObject obj)
    {
        IN_GAME_MAIN_CAMERA.mainobject = obj;
        Transform _transform = IN_GAME_MAIN_CAMERA.mainobject.transform;
        IN_GAME_MAIN_CAMERA.main_objectT = _transform;
        if (_transform != null)
        {
            Transform transform = IN_GAME_MAIN_CAMERA.main_objectT.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck/head");
            IN_GAME_MAIN_CAMERA.head = transform;
            if (transform != null)
            {
                IN_GAME_MAIN_CAMERA.mainTITAN = IN_GAME_MAIN_CAMERA.mainobject.GetComponent<TITAN>();
                IN_GAME_MAIN_CAMERA.main_objectR = IN_GAME_MAIN_CAMERA.mainobject.rigidbody;
                IN_GAME_MAIN_CAMERA.headT = IN_GAME_MAIN_CAMERA.head.transform;
                if (IN_GAME_MAIN_CAMERA.head == null)
                {
                    float single = 1f;
                    IN_GAME_MAIN_CAMERA.heightMulti = single;
                    IN_GAME_MAIN_CAMERA.distanceMulti = single;
                }
                else
                {
                    float single1 = Vector3.Distance(IN_GAME_MAIN_CAMERA.head.position, IN_GAME_MAIN_CAMERA.main_objectT.position);
                    IN_GAME_MAIN_CAMERA.distanceMulti = single1 * 0.4f;
                    IN_GAME_MAIN_CAMERA.heightMulti = single1 * 0.45f;
                }
                IN_GAME_MAIN_CAMERA.mainT.rotation = (Quaternion.Euler(0f, 0f, 0f));
            }
        }
        return obj;
    }

    public bool setSpectorMode(bool val)
    {
        this.spectatorMode = val;
        IN_GAME_MAIN_CAMERA.spectate.disable = !val;
        IN_GAME_MAIN_CAMERA.mouselook.disable = !val;
        return val;
    }

    private void shakeUpdate()
    {
        if (this.duration > 0f)
        {
            IN_GAME_MAIN_CAMERA _deltaTime = this;
            _deltaTime.duration = _deltaTime.duration - Time.deltaTime;
            if (!this.flip)
            {
                Transform transform = IN_GAME_MAIN_CAMERA.mainT;
                transform.position = (transform.position - (Vector3.up * this.R));
            }
            else
            {
                Transform transform1 = IN_GAME_MAIN_CAMERA.mainT;
                transform1.position = (transform1.position + (Vector3.up * this.R));
            }
            this.flip = !this.flip;
            IN_GAME_MAIN_CAMERA r = this;
            r.R = r.R * this.decay;
        }
    }

    public void snapShot2(int index)
    {
        RaycastHit raycastHit = new RaycastHit();
        Vector3 _zero = Vector3.zero;
        IN_GAME_MAIN_CAMERA.snapT.position = (IN_GAME_MAIN_CAMERA.MainObjectPosition);
        Transform transform = IN_GAME_MAIN_CAMERA.snapT;
        transform.position = (transform.position + (Vector3.up * IN_GAME_MAIN_CAMERA.heightMulti));
        Transform transform1 = IN_GAME_MAIN_CAMERA.snapT;
        transform1.position = (transform1.position - (Vector3.up * 1.1f));
        Vector3 _position = IN_GAME_MAIN_CAMERA.snapT.position;
        _zero = _position;
        Vector3 mainObjectPosition = _position;
        Vector3 vector3 = Vector3.Slerp(mainObjectPosition, this.snapShotTargetPosition, UnityEngine.Random.Range(0.15f, 0.55f));
        IN_GAME_MAIN_CAMERA.snapT.position = (vector3);
        mainObjectPosition = vector3;
        IN_GAME_MAIN_CAMERA.snapT.LookAt(this.snapShotTargetPosition);
        if (index != 3)
        {
            IN_GAME_MAIN_CAMERA.snapT.RotateAround(IN_GAME_MAIN_CAMERA.mainT.position, Vector3.up, UnityEngine.Random.Range(-20f, 20f));
        }
        else
        {
            IN_GAME_MAIN_CAMERA.snapT.RotateAround(IN_GAME_MAIN_CAMERA.mainT.position, Vector3.up, UnityEngine.Random.Range(-180f, 180f));
        }
        IN_GAME_MAIN_CAMERA.snapT.LookAt(mainObjectPosition);
        IN_GAME_MAIN_CAMERA.snapT.RotateAround(mainObjectPosition, IN_GAME_MAIN_CAMERA.mainT.right, UnityEngine.Random.Range(-20f, 20f));
        float single = Vector3.Distance(this.snapShotTargetPosition, _zero);
        if (this.snapShotTarget != null && this.snapShotTarget.GetComponent<TITAN>() != null)
        {
            single = single + (float)(index - 1) * this.snapShotTarget.transform.localScale.x * 10f;
        }
        Transform transform2 = IN_GAME_MAIN_CAMERA.snapT;
        transform2.position = (transform2.position - (IN_GAME_MAIN_CAMERA.snapT.forward * UnityEngine.Random.Range(single + 3f, single + 10f)));
        IN_GAME_MAIN_CAMERA.snapT.LookAt(mainObjectPosition);
        IN_GAME_MAIN_CAMERA.snapT.RotateAround(mainObjectPosition, IN_GAME_MAIN_CAMERA.mainT.forward, UnityEngine.Random.Range(-30f, 30f));
        mainObjectPosition = IN_GAME_MAIN_CAMERA.MainObjectPosition;
        _zero = IN_GAME_MAIN_CAMERA.MainObjectPosition - IN_GAME_MAIN_CAMERA.snapT.position;
        mainObjectPosition = mainObjectPosition - _zero;/*
        if (IN_GAME_MAIN_CAMERA.head == null)
        {
            if (Physics.Linecast(IN_GAME_MAIN_CAMERA.main_objectT.position + Vector3.up, mainObjectPosition, ref raycastHit, Layer.GroundEnemy))
            {
                IN_GAME_MAIN_CAMERA.snapT.position = (raycastHit.point);
            }
        }
        else if (Physics.Linecast(IN_GAME_MAIN_CAMERA.headT.position, mainObjectPosition, ref raycastHit, Layer.GroundEnemy))
        {
            IN_GAME_MAIN_CAMERA.snapT.position = (raycastHit.point);
        }
        else if (Physics.Linecast(IN_GAME_MAIN_CAMERA.headT.position - ((_zero * IN_GAME_MAIN_CAMERA.distanceMulti) * 3f), mainObjectPosition, ref raycastHit, Layer.GroundEnemy))
        {
            IN_GAME_MAIN_CAMERA.snapT.position = (raycastHit.point);
        }*/
        if (index == 1)
        {
            this.snapshot1 = this.RTImage(IN_GAME_MAIN_CAMERA.snapCam);
            SnapShotSaves.addIMG(this.snapshot1, this.snapShotDmg);
        }
        else if (index == 2)
        {
            this.snapshot2 = this.RTImage(IN_GAME_MAIN_CAMERA.snapCam);
            SnapShotSaves.addIMG(this.snapshot2, this.snapShotDmg);
        }
        else if (index == 3)
        {
            this.snapshot3 = this.RTImage(IN_GAME_MAIN_CAMERA.snapCam);
            SnapShotSaves.addIMG(this.snapshot3, this.snapShotDmg);
        }
        this.snapShotCount = index;
        this.hasSnapShot = true;
        this.snapShotCountDown = 2f;
        if (index == 1)
        {
            IN_GAME_MAIN_CAMERA.UITex.mainTexture = this.snapshot1;
            IN_GAME_MAIN_CAMERA.UITexT.localScale = (new Vector3((float)Screen.width * 0.4f, (float)Screen.height * 0.4f, 1f));
            IN_GAME_MAIN_CAMERA.UITexT.localPosition = (new Vector3((float)(-Screen.width) * 0.225f, (float)Screen.height * 0.225f, 0f));
            IN_GAME_MAIN_CAMERA.UITexT.rotation = (Quaternion.Euler(0f, 0f, 10f));
            ((Behaviour)IN_GAME_MAIN_CAMERA.UITex).enabled = ((!PlayerPrefs.HasKey("showSSInGame") ? false : PlayerPrefs.GetInt("showSSInGame") == 1));
        }
    }

    public void snapShotUpdate()
    {
        if (this.startSnapShotFrameCount)
        {
            IN_GAME_MAIN_CAMERA _deltaTime = this;
            _deltaTime.snapShotStartCountDownTime = _deltaTime.snapShotStartCountDownTime - Time.deltaTime;
            if (this.snapShotStartCountDownTime <= 0f)
            {
                this.snapShot2(1);
                this.startSnapShotFrameCount = false;
            }
        }
        if (this.hasSnapShot)
        {
            IN_GAME_MAIN_CAMERA nGAMEMAINCAMERA = this;
            nGAMEMAINCAMERA.snapShotCountDown = nGAMEMAINCAMERA.snapShotCountDown - Time.deltaTime;
            if (this.snapShotCountDown <= 0f)
            {
                IN_GAME_MAIN_CAMERA.UITex.enabled = (false);
                this.hasSnapShot = false;
                this.snapShotCountDown = 0f;
            }
            else if (this.snapShotCountDown < 1f)
            {
                IN_GAME_MAIN_CAMERA.UITex.mainTexture = this.snapshot3;
            }
            else if (this.snapShotCountDown < 1.5f)
            {
                IN_GAME_MAIN_CAMERA.UITex.mainTexture = this.snapshot2;
            }
            if (this.snapShotCount < 3)
            {
                IN_GAME_MAIN_CAMERA _deltaTime1 = this;
                _deltaTime1.snapShotInterval = _deltaTime1.snapShotInterval - Time.deltaTime;
                if (this.snapShotInterval <= 0f)
                {
                    this.snapShotInterval = 0.05f;
                    IN_GAME_MAIN_CAMERA nGAMEMAINCAMERA1 = this;
                    nGAMEMAINCAMERA1.snapShotCount = nGAMEMAINCAMERA1.snapShotCount + 1;
                    this.snapShot2(this.snapShotCount);
                }
            }
        }
    }

    private void Start()
    {
        base.gameObject.AddComponent<SAOGui>();
        base.gameObject.AddComponent<PauseGUI>();
        if (PlayerPrefs.GetString("Name") != String.Empty)
        {
            uiname = PlayerPrefs.GetString("Name");
        }
        if (PlayerPrefs.GetString("ChatName") != String.Empty)
        {
            chatname = RCextensions.hexColor(PlayerPrefs.GetString("Name"));
        }
        ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable()
					            {
						            { PhotonPlayerProperty.name, PlayerPrefs.GetString("Name") }
					            };
        ExitGames.Client.Photon.Hashtable hashtable1 = hashtable;
        PhotonNetwork.player.SetCustomProperties(hashtable1);
        isPausing = false;
        sensitivityMulti = PlayerPrefs.GetFloat("MouseSensitivity");
        invertY = PlayerPrefs.GetInt("invertMouseY");
        this.setDayLight(dayLight);
        IN_GAME_MAIN_CAMERA.mainCamera = this;
        IN_GAME_MAIN_CAMERA.isReady = true;
        IN_GAME_MAIN_CAMERA.isPausing = false;
        IN_GAME_MAIN_CAMERA.sensitivityMulti = PlayerPrefs.GetFloat("MouseSensitivity");
        IN_GAME_MAIN_CAMERA.invertY = PlayerPrefs.GetInt("invertMouseY");
        this.setDayLight(IN_GAME_MAIN_CAMERA.dayLight);
        IN_GAME_MAIN_CAMERA.locker = CacheGameObject.Find<Transform>("locker");
        IN_GAME_MAIN_CAMERA.cameraTilt = (PlayerPrefs.HasKey("cameraTilt") ? PlayerPrefs.GetInt("cameraTilt") : 1);
        if (PlayerPrefs.HasKey("cameraDistance"))
        {
            IN_GAME_MAIN_CAMERA.cameraDistance = PlayerPrefs.GetFloat("cameraDistance") + 0.3f;
        }
        IN_GAME_MAIN_CAMERA.snapCam = this.snapShotCamera.GetComponent<Camera>();
        this.createSnapShotRT();
        IN_GAME_MAIN_CAMERA.UITex = CacheGameObject.Find<UIReferArray>("UI_IN_GAME").panels[0].transform.Find("snapshot1").GetComponent<UITexture>();
        IN_GAME_MAIN_CAMERA.UITexT = IN_GAME_MAIN_CAMERA.UITex.transform;
        IN_GAME_MAIN_CAMERA.snapT = this.snapShotCamera.transform;
        RenderTexture _targetTexture = IN_GAME_MAIN_CAMERA.snapCam.targetTexture;/*
        if (!(bool)FengGameManagerMKII.settings[62] || _targetTexture.width >= Screen.width || _targetTexture.height >= Screen.height)
        {
            _targetTexture.antiAliasing = (8);
            return;
        }
        _targetTexture.width = (Screen.width);
        _targetTexture.height = (Screen.height);
        _targetTexture.anisoLevel = (9);*/
    }

    public void StartFog()
    {
        if ((bool)FengGameManagerMKII.settings[39] && !IN_GAME_MAIN_CAMERA.fog)
        {
            base.StartCoroutine(this.fogEnum());
            IN_GAME_MAIN_CAMERA.fog = !IN_GAME_MAIN_CAMERA.fog;
        }
    }

    public void startShake(float R, float duration, float decay = 0.95f)
    {
        if (this.duration < duration)
        {
            this.R = R;
            this.duration = duration;
            this.decay = decay;
        }
    }

    public void startSnapShot(Vector3 p, int dmg, GameObject target = null, float startTime = 0.02f)
    {
        if (dmg == 0)
        {
            if (!(bool)FengGameManagerMKII.settings[33])
            {
                this.startSnapShotFrameCount = false;
                return;
            }
            this.snapShotCount = 1;
            this.startSnapShotFrameCount = true;
            this.snapShotTargetPosition = p;
            this.snapShotTarget = target;
            this.snapShotStartCountDownTime = startTime;
            this.snapShotInterval = 0.05f + UnityEngine.Random.Range(0f, 0.03f);
            this.snapShotDmg = dmg;
            return;
        }
        if (dmg < (int)FengGameManagerMKII.settings[32])
        {
            this.startSnapShotFrameCount = false;
            return;
        }
        this.snapShotCount = 1;
        this.startSnapShotFrameCount = true;
        this.snapShotTargetPosition = p;
        this.snapShotTarget = target;
        this.snapShotStartCountDownTime = startTime;
        this.snapShotInterval = 0.05f + UnityEngine.Random.Range(0f, 0.03f);
        this.snapShotDmg = dmg;
    }

    public void StopFog()
    {
        if (IN_GAME_MAIN_CAMERA.fog)
        {
            base.StopCoroutine(this.fogEnum());
            IN_GAME_MAIN_CAMERA.fog = !IN_GAME_MAIN_CAMERA.fog;
        }
    }

    internal void update()
    {
        RaycastHit raycastHit = new RaycastHit();
        Transform transform;
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.STOP)
        {
            Screen.showCursor = (true);
            Screen.lockCursor = (false);
            return;
        }
        if (this.flashDuration > 0f)
        {
            IN_GAME_MAIN_CAMERA _deltaTime = this;
            _deltaTime.flashDuration = _deltaTime.flashDuration - Time.deltaTime;
            if (this.flashDuration <= 0f)
            {
                this.flashDuration = 0f;
            }
            UISprite uISprite = CacheGameObject.Find<UISprite>("flash");
            if (uISprite != null)
            {
                uISprite.alpha = this.flashDuration * 0.5f;
            }
        }
        if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.SINGLE && this.gameOver)
        {
            if (FengCustomInputs.Inputs.isInputDown[InputCode.attack1])
            {
                if (!this.spectatorMode)
                {
                    this.setSpectorMode(true);
                }
                else
                {
                    this.setSpectorMode(false);
                }
            }
            if (FengCustomInputs.Inputs.isInputDown[InputCode.flare1])
            {
                List<GameObject> gameObjects = new List<GameObject>((!PhotonNetwork.player.isTitan || !IN_GAME_MAIN_CAMERA.switchList ?
                    from h in FengGameManagerMKII.allheroes
                    where h != null
                    select h : FengGameManagerMKII.alltitans.Where<GameObject>((GameObject h) =>
                    {
                        if (h == null)
                        {
                            return false;
                        }
                        if (h.name == "Female Titan" || h.name == "Colossal Titan")
                        {
                            return true;
                        }
                        if (!(h.GetComponent<PhotonView>() != null) || h.GetComponent<PhotonView>().owner.isMasterClient)
                        {
                            return false;
                        }
                        return h.GetComponent<PhotonView>().owner.isTitan;
                    })));
                if (gameObjects.Count > 0)
                {
                    IN_GAME_MAIN_CAMERA nGAMEMAINCAMERA = this;
                    nGAMEMAINCAMERA.currentPeekPlayerIndex = nGAMEMAINCAMERA.currentPeekPlayerIndex + 1;
                    if (this.currentPeekPlayerIndex >= gameObjects.Count)
                    {
                        this.currentPeekPlayerIndex = 0;
                        IN_GAME_MAIN_CAMERA.switchList = !IN_GAME_MAIN_CAMERA.switchList;
                    }
                    if (!IN_GAME_MAIN_CAMERA.switchList)
                    {
                        this.setMainObject(gameObjects[this.currentPeekPlayerIndex], true, false);
                    }
                    else
                    {
                        this.setMainObjectASTITAN(gameObjects[this.currentPeekPlayerIndex]);
                    }
                    this.setSpectorMode(false);
                    IN_GAME_MAIN_CAMERA.lockAngle = false;
                }
            }
            if (FengCustomInputs.Inputs.isInputDown[InputCode.flare2])
            {
                List<GameObject> gameObjects1 = new List<GameObject>((!PhotonNetwork.player.isTitan || !IN_GAME_MAIN_CAMERA.switchList ?
                    from h in FengGameManagerMKII.allheroes
                    where h != null
                    select h : FengGameManagerMKII.alltitans.Where<GameObject>((GameObject h) =>
                    {
                        if (h == null)
                        {
                            return false;
                        }
                        if (h.name == "Female Titan" || h.name == "Colossal Titan")
                        {
                            return true;
                        }
                        if (!(h.GetComponent<PhotonView>() != null) || h.GetComponent<PhotonView>().owner.isMasterClient)
                        {
                            return false;
                        }
                        return h.GetComponent<PhotonView>().owner.isTitan;
                    })));
                IN_GAME_MAIN_CAMERA nGAMEMAINCAMERA1 = this;
                nGAMEMAINCAMERA1.currentPeekPlayerIndex = nGAMEMAINCAMERA1.currentPeekPlayerIndex - 1;
                if (this.currentPeekPlayerIndex < 0)
                {
                    this.currentPeekPlayerIndex = gameObjects1.Count - 1;
                    IN_GAME_MAIN_CAMERA.switchList = !IN_GAME_MAIN_CAMERA.switchList;
                }
                if (gameObjects1.Count > 0)
                {
                    if (!IN_GAME_MAIN_CAMERA.switchList)
                    {
                        this.setMainObject(gameObjects1[this.currentPeekPlayerIndex], true, false);
                    }
                    else
                    {
                        this.setMainObjectASTITAN(gameObjects1[this.currentPeekPlayerIndex]);
                    }
                    this.setSpectorMode(false);
                    IN_GAME_MAIN_CAMERA.lockAngle = false;
                }
            }
            if (this.spectatorMode)
            {
                return;
            }
        }
        if (FengCustomInputs.Inputs.isInputDown[InputCode.pause])
        {
            IN_GAME_MAIN_CAMERA.isPausing = !IN_GAME_MAIN_CAMERA.isPausing;
            /*
            if (!IN_GAME_MAIN_CAMERA.isPausing)
            {
                UIReferArray uIReferArray = CacheGameObject.Find<UIReferArray>("UI_IN_GAME");
                if (uIReferArray != null)
                {
                    IN_GAME_MAIN_CAMERA.isPausing = !IN_GAME_MAIN_CAMERA.isPausing;
                    if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
                    {
                        Time.timeScale = (0f);
                    }
                    NGUITools.SetActive(uIReferArray.panels[0], false);
                    NGUITools.SetActive(uIReferArray.panels[1], true);
                    NGUITools.SetActive(uIReferArray.panels[2], false);
                    NGUITools.SetActive(uIReferArray.panels[3], false);
                    FengCustomInputs.Inputs.showKeyMap();
                    FengCustomInputs.Inputs.justUPDATEME();
                    FengCustomInputs inputs = FengCustomInputs.Inputs;
                    int num = 1;
                    Screen.showCursor = true;
                    inputs.menuOn = true;
                    Screen.lockCursor = (false);
                }
            }
            else if (IN_GAME_MAIN_CAMERA.mainT != null && IN_GAME_MAIN_CAMERA.main_object != null)
            {
                Vector3 _position = IN_GAME_MAIN_CAMERA.mainT.position;
                _position = IN_GAME_MAIN_CAMERA.MainObjectPosition;
                _position = _position + (Vector3.up * IN_GAME_MAIN_CAMERA.heightMulti);
                IN_GAME_MAIN_CAMERA.mainT.position = (Vector3.Lerp(IN_GAME_MAIN_CAMERA.mainT.position, _position - (IN_GAME_MAIN_CAMERA.mainT.forward * 5f), 0.2f));
            }*/
        }
        if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE && FengCustomInputs.Inputs.isInputDown[InputCode.restart])
        {
            this.reset();
        }
        if (this.needSetHUD)
        {
            this.needSetHUD = false;
            this.setHUDposition();
        }
        if (FengCustomInputs.Inputs.isInputDown[InputCode.fullscreen])
        {
            Screen.fullScreen = (!Screen.fullScreen);
            if (!Screen.fullScreen)
            {
                int _width = Screen.currentResolution.width;
                Resolution _currentResolution = Screen.currentResolution;
                Screen.SetResolution(_width, _currentResolution.height, true);
            }
            else
            {
                Screen.SetResolution(960, 600, false);
            }
            this.needSetHUD = true;/*
            Minimap.OnScreenResolutionChanged();
            if (StylishComponent.stylebar != null)
            {
                StylishComponent.stylebar.setPosition();
            }*/
        }
        if (IN_GAME_MAIN_CAMERA.main_object != null)
        {
            if (IN_GAME_MAIN_CAMERA.main_objectT == null)
            {
                IN_GAME_MAIN_CAMERA.main_objectT = IN_GAME_MAIN_CAMERA.main_object.transform;
            }
            if (FengCustomInputs.Inputs.isInputDown[InputCode.camera])
            {
                switch (IN_GAME_MAIN_CAMERA.cameraMode)
                {
                    case CAMERA_TYPE.ORIGINAL:
                        {
                            IN_GAME_MAIN_CAMERA.cameraMode = CAMERA_TYPE.WOW;
                            Screen.lockCursor = (false);
                            break;
                        }
                    case CAMERA_TYPE.WOW:
                        {
                            IN_GAME_MAIN_CAMERA.cameraMode = CAMERA_TYPE.TPS;
                            Screen.lockCursor = (true);
                            break;
                        }
                    case CAMERA_TYPE.TPS:
                        {
                            IN_GAME_MAIN_CAMERA.cameraMode = CAMERA_TYPE.oldTPS;
                            Screen.lockCursor = (true);
                            break;
                        }
                    case CAMERA_TYPE.oldTPS:
                        {
                            IN_GAME_MAIN_CAMERA.cameraMode = CAMERA_TYPE.ORIGINAL;
                            Screen.lockCursor = (false);
                            break;
                        }
                }
            }
            if (FengCustomInputs.Inputs.isInputDown[InputCode.hideCursor])
            {
                Screen.showCursor = !Screen.showCursor;
            }
            /*
            if (FengCustomInputs.Inputs.isInputDown[InputCode.hideCursor] && ((bool)FengGameManagerMKII.settings[40] || !(bool)FengGameManagerMKII.settings[82]))
            {
                if ((bool)FengGameManagerMKII.settings[40])
                {
                    if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
                    {
                        Time.timeScale = (1f);
                    }
                    if (FengGameManagerMKII.gameStart)
                    {
                        Screen.showCursor = (false);
                        Screen.lockCursor = ((IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS));
                    }
                    else
                    {
                        Screen.lockCursor = (false);
                        Screen.showCursor = (true);
                    }
                    FengGameManagerMKII.settings[82] = false;
                    FengGameManagerMKII.settings[40] = false;
                    IN_GAME_MAIN_CAMERA.isTyping = false;
                    IN_GAME_MAIN_CAMERA.isPausing = false;
                }
                else
                {
                    if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
                    {
                        Time.timeScale = (0f);
                    }
                    Screen.showCursor = (true);
                    Screen.lockCursor = (false);
                    FengGameManagerMKII.settings[82] = true;
                    FengGameManagerMKII.settings[40] = true;
                    IN_GAME_MAIN_CAMERA.isTyping = true;
                    IN_GAME_MAIN_CAMERA.isPausing = true;
                }
            }*/
            if (FengCustomInputs.Inputs.isInputDown[InputCode.focus])
            {
                IN_GAME_MAIN_CAMERA.triggerAutoLock = !IN_GAME_MAIN_CAMERA.triggerAutoLock;
                if (IN_GAME_MAIN_CAMERA.triggerAutoLock)
                {
                    IN_GAME_MAIN_CAMERA.lockTarget = this.findNearestTitan();
                    if (this.closestDistance < 150f)
                    {
                        IN_GAME_MAIN_CAMERA.lockTargetT = IN_GAME_MAIN_CAMERA.lockTarget.transform;
                    }
                    else
                    {
                        IN_GAME_MAIN_CAMERA.lockTarget = null;
                        IN_GAME_MAIN_CAMERA.lockTargetT = null;
                        IN_GAME_MAIN_CAMERA.triggerAutoLock = false;
                    }
                }
            }
            if (!this.gameOver || !IN_GAME_MAIN_CAMERA.lockAngle || !(IN_GAME_MAIN_CAMERA.main_objectT != null))
            {
                IN_GAME_MAIN_CAMERA.camareMovement();
            }
            else if (IN_GAME_MAIN_CAMERA.mainT != null)
            {
                IN_GAME_MAIN_CAMERA.mainT.rotation = (Quaternion.Lerp(IN_GAME_MAIN_CAMERA.mainT.rotation, IN_GAME_MAIN_CAMERA.main_objectT.rotation, 0.2f));
                IN_GAME_MAIN_CAMERA.mainT.position = (Vector3.Lerp(IN_GAME_MAIN_CAMERA.mainT.position, IN_GAME_MAIN_CAMERA.main_objectT.position - (IN_GAME_MAIN_CAMERA.main_objectT.forward * 5f), 0.2f));
            }
            if (IN_GAME_MAIN_CAMERA.locker != null)
            {
                if (!IN_GAME_MAIN_CAMERA.triggerAutoLock || !(IN_GAME_MAIN_CAMERA.lockTargetT != null))
                {
                    IN_GAME_MAIN_CAMERA.locker.localPosition = (new Vector3(0f, (float)(-Screen.height) * 0.5f - 50f, 0f));
                }
                else
                {
                    float _eulerAngles = IN_GAME_MAIN_CAMERA.mainT.eulerAngles.z;
                    SPECIES sPECIES = IN_GAME_MAIN_CAMERA.lockTarget.specie;
                    switch (sPECIES)
                    {
                        case SPECIES.TITAN:
                            {
                                Transform transform1 = ((TITAN)IN_GAME_MAIN_CAMERA.lockTarget).neck;
                                transform = transform1;
                                if (transform1)
                                {
                                    break;
                                }
                                transform = IN_GAME_MAIN_CAMERA.lockTargetT.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck");
                                break;
                            }
                        case SPECIES.HERO | SPECIES.TITAN:
                            {
                                transform = IN_GAME_MAIN_CAMERA.lockTargetT.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck");
                                break;
                            }
                        case SPECIES.FEMALE_TITAN:
                            {
                                Transform transform2 = ((FEMALE_TITAN)IN_GAME_MAIN_CAMERA.lockTarget).neck;
                                transform = transform2;
                                if (transform2)
                                {
                                    break;
                                }
                                transform = IN_GAME_MAIN_CAMERA.lockTargetT.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck");
                                break;
                            }
                        default:
                            {
                                if (sPECIES == SPECIES.COLOSSAL_TITAN)
                                {
                                    Transform transform3 = ((COLOSSAL_TITAN)IN_GAME_MAIN_CAMERA.lockTarget).transform.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck");
                                    transform = transform3;
                                    if (transform3)
                                    {
                                        break;
                                    }
                                    transform = IN_GAME_MAIN_CAMERA.lockTargetT.Find("Amarture/Core/Controller_Body/hip/spine/chest/neck");
                                    break;
                                }
                                else
                                {
                                    goto case SPECIES.HERO | SPECIES.TITAN;
                                }
                            }
                    }
                    Vector3 vector3 = transform.position - IN_GAME_MAIN_CAMERA.MainObjectPosition;
                    vector3.Normalize();
                    Transform transform4 = IN_GAME_MAIN_CAMERA.mainT;
                    Vector3 _position1 = IN_GAME_MAIN_CAMERA.mainT.position;
                    Vector3 mainObjectPosition = (IN_GAME_MAIN_CAMERA.MainObjectPosition - (((vector3 * 10f) * IN_GAME_MAIN_CAMERA.distanceMulti) * IN_GAME_MAIN_CAMERA.distanceOffsetMulti)) + (((Vector3.up * 3f) * IN_GAME_MAIN_CAMERA.heightMulti) * IN_GAME_MAIN_CAMERA.distanceOffsetMulti);
                    IN_GAME_MAIN_CAMERA.lockCameraPosition = mainObjectPosition;
                    transform4.position = (Vector3.Lerp(_position1, mainObjectPosition, Time.deltaTime * 4f));
                    if (IN_GAME_MAIN_CAMERA.head == null)
                    {
                        IN_GAME_MAIN_CAMERA.mainT.LookAt((IN_GAME_MAIN_CAMERA.main_objectT.position * 0.8f) + (transform.position * 0.2f));
                    }
                    else
                    {
                        IN_GAME_MAIN_CAMERA.mainT.LookAt((IN_GAME_MAIN_CAMERA.headT.position * 0.8f) + (transform.position * 0.2f));
                    }
                    IN_GAME_MAIN_CAMERA.mainT.localEulerAngles = (new Vector3(IN_GAME_MAIN_CAMERA.mainT.eulerAngles.x, IN_GAME_MAIN_CAMERA.mainT.eulerAngles.y, _eulerAngles));
                    Vector2 screenPoint = IN_GAME_MAIN_CAMERA.mainC.WorldToScreenPoint(transform.position - (transform.forward * IN_GAME_MAIN_CAMERA.lockTargetT.localScale.x));
                    IN_GAME_MAIN_CAMERA.locker.localPosition = (new Vector3(screenPoint.x - (float)Screen.width * 0.5f, screenPoint.y - (float)Screen.height * 0.5f, 0f));
                    if (IN_GAME_MAIN_CAMERA.lockTarget.specie == SPECIES.TITAN && ((TITAN)IN_GAME_MAIN_CAMERA.lockTarget).hasDie)
                    {
                        IN_GAME_MAIN_CAMERA.lockTarget = null;
                        IN_GAME_MAIN_CAMERA.lockTargetT = null;
                    }
                }
            }
            if (!(bool)FengGameManagerMKII.settings[83])
            {
                Vector3 mainObjectPosition1 = IN_GAME_MAIN_CAMERA.MainObjectPosition;
                Vector3 vector31 = IN_GAME_MAIN_CAMERA.MainObjectPosition - IN_GAME_MAIN_CAMERA.mainT.position;
                Vector3 _normalized = vector31.normalized;
                mainObjectPosition1 = mainObjectPosition1 - ((10f * _normalized) * IN_GAME_MAIN_CAMERA.distanceMulti);
                if (IN_GAME_MAIN_CAMERA.head != null)
                {
                    if (IN_GAME_MAIN_CAMERA.headT == null)
                    {
                        IN_GAME_MAIN_CAMERA.headT = IN_GAME_MAIN_CAMERA.head.transform;
                    }/*
                    if (Physics.Linecast(IN_GAME_MAIN_CAMERA.headT.position, mainObjectPosition1, ref raycastHit, (int)Layer.Ground))
                    {
                        IN_GAME_MAIN_CAMERA.mainT.position = (raycastHit.point);
                    }
                    else if (Physics.Linecast(IN_GAME_MAIN_CAMERA.headT.position - ((_normalized * IN_GAME_MAIN_CAMERA.distanceMulti) * 3f), mainObjectPosition1, ref raycastHit, Layer.Enemy))
                    {
                        IN_GAME_MAIN_CAMERA.mainT.position = (raycastHit.point);
                    }*/
                    //Debug.DrawLine(IN_GAME_MAIN_CAMERA.headT.position - ((_normalized * IN_GAME_MAIN_CAMERA.distanceMulti) * 3f), mainObjectPosition1, Color.get_red());
                }/*
                else if (Physics.Linecast(IN_GAME_MAIN_CAMERA.main_objectT.position + Vector3.up, mainObjectPosition1, ref raycastHit, Layer.GroundEnemy))
                {
                    IN_GAME_MAIN_CAMERA.mainT.position = (raycastHit.point);
                }*/
            }
            this.shakeUpdate();
        }
    }

    public void OnGUI()
    {
        if (IN_GAME_MAIN_CAMERA.isPausing)
        {

            if (FengGameManagerMKII.level == "Custom" && PhotonNetwork.isMasterClient)
            {
                mapscriptt = GUI.TextArea(new Rect(0, Screen.height / 2, Screen.width / 4, Screen.height / 4), mapscriptt);
                if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 5, Screen.width / 20, Screen.height / 20), "Create"))
                {
                    FengGameManagerMKII.times = 0;
                    string[] maptosend = new string[100];
                    string[] map = new string[5000];
                    for (int z = 0; z < 5000; z++)
                    {
                        if (mapscriptt.Contains(";"))
                        {
                            map[z] = mapscriptt.Substring(0, mapscriptt.IndexOf(";"));
                            mapscriptt = mapscriptt.Remove(0, mapscriptt.IndexOf("\n") + 1);
                            FengGameManagerMKII.times++;
                        }
                    }
                    FengGameManagerMKII.mymap = map;
                    int ze = 0;
                    while (ze < FengGameManagerMKII.times)
                    {
                        for (int zed = 0; zed < 100; zed++)
                        {
                            if (ze < FengGameManagerMKII.times)
                            {
                                maptosend[zed] = map[ze];
                                ze++;
                            }
                            else
                                break;
                        }
                        FengGameManagerMKII.inputs.photonView.RPC("customlevelRPC", PhotonTargets.All, new object[] { maptosend });
                    }
                    //FengGameManagerMKII.inputs.photonView.RPC("customlevelRPC", PhotonTargets.All, new object[] { map });
                    string[] abfd = new string[1];
                    abfd[0] = String.Empty;
                    FengGameManagerMKII.inputs.photonView.RPC("clearlevel", PhotonTargets.All, new object[] { abfd, 1 });
                    FengGameManagerMKII.imhosting = true;
                }
            }
        }
    }

    public void loadobject(int number, int id, float x, float y, float z)
    {
        Vector3 theposition = new Vector3(x, y, z);
        // Create Object
        GameObject myMesh = new GameObject("Blablabla");
        // Meshfilter to create meshes ingame
        MeshFilter filter = myMesh.AddComponent<MeshFilter>();
        // Call importer class
        ObjImporter importalo = new ObjImporter();
        if (number == 0)
            myMesh.GetComponent<MeshFilter>().mesh = importalo.ImportFile("bike.obj");
        else
            myMesh.GetComponent<MeshFilter>().mesh = importalo.ImportFile("Wings.obj");
        // Position
        myMesh.transform.position = theposition;
        // Rotation
        myMesh.transform.rotation = main_object.transform.rotation;
        // Create renderer
        myMesh.AddComponent<MeshRenderer>();
        // Apply texture
        if (number == 0)
            myMesh.renderer.material.mainTexture = FengGameManagerMKII.candytextures[9];
        else
            myMesh.renderer.material.mainTexture = FengGameManagerMKII.wingstex;
        // Create collider
        myMesh.AddComponent<MeshCollider>();
        // Useless thing LOL
        myMesh.collider.material.dynamicFriction = 0.8f;
        // Make mesh grappable
        myMesh.layer = LayerMask.NameToLayer("Ground");
        if (number == 1)
        {
            if (id == PhotonNetwork.player.ID)
            {
                wings = myMesh;
                wings.collider.enabled = false;
            }
            else
            {
                int thezed = 0;
                for (int zed = 0; zed < otherwings.Length; zed++)
                {
                    if (otherwings[zed] == null)
                    {
                        otherwings[zed] = myMesh;
                        thezed = zed;
                        break;
                    }
                }
                otherwings[thezed].collider.enabled = false;
                otherwings[thezed].transform.localScale = new Vector3(.4f, .4f, .4f);
                GameObject[] candywingplayers = GameObject.FindGameObjectsWithTag("Player");
                for (int zed = 0; zed < candywingplayers.Length; zed++)
                {
                    if (candywingplayers[zed].GetComponent<SmoothSyncMovement>().photonView.owner.ID == id)
                    {
                        wingplayers[thezed] = candywingplayers[zed];
                        otherwings[thezed].transform.parent = wingplayers[thezed].transform;
                        otherwings[thezed].transform.rotation = wingplayers[thezed].transform.rotation * Quaternion.Euler(0f, -90f, 0f);
                        otherwings[thezed].transform.position = wingplayers[thezed].transform.position - wingplayers[thezed].transform.forward * .2f + new Vector3(0f, .3f, 0f);
                        break;
                    }
                }
            }
        }
        else
        {
            if (id == PhotonNetwork.player.ID)
            {
                myMesh.transform.localScale = new Vector3(.05f, .05f, .05f);/*
                this.bike = myMesh;
                this.bike.transform.position = main_object.transform.position + new Vector3(5f, 5f, 0f);
                this.bike.rigidbody.useGravity = true;*/
            }
            else
            {
                int thezed = 0;/*
                for (int zed = 0; zed < otherbikes.Length; zed++)
                {
                    if (otherbikes[zed] == null)
                    {
                        otherbikes[zed] = myMesh;
                        thezed = zed;
                        break;
                    }
                }
                otherbikes[thezed].transform.localScale = new Vector3(.01f, .01f, .01f);
                GameObject[] candybikeplayers = GameObject.FindGameObjectsWithTag("Player");
                for (int zed = 0; zed < candybikeplayers.Length; zed++)
                {
                    if (candybikeplayers[zed].GetComponent<SmoothSyncMovement>().photonView.owner.ID == id)
                    {
                        bikeplayers[thezed] = candybikeplayers[zed];
                        otherbikes[thezed].transform.parent = bikeplayers[thezed].transform;
                        otherbikes[thezed].transform.rotation = bikeplayers[thezed].transform.rotation * Quaternion.Euler(0f, -90f, 0f);
                        otherbikes[thezed].transform.position = bikeplayers[thezed].transform.position - bikeplayers[thezed].transform.forward * .2f + new Vector3(0f, .3f, 0f);
                        break;
                    }
                }*/
            }
        }
    }

    public void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
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
        GameObject closest = null;
        if (Physics.Raycast(ray, out hit, 300))
        {
            for (int z = 0; z < testlist.Count; z++)
            {
                if (closest == null)
                {
                    if (testlist[z] != main_object)
                        closest = testlist[z];
                }
                else
                {
                    if (testlist[z] != main_object && Vector3.Distance(hit.point, testlist[z].transform.position) < Vector3.Distance(hit.point, closest.transform.position))
                    {
                        closest = testlist[z];
                    }
                }
            }
            distance1 = Vector3.Distance(hit.point, closest.transform.position);
            if (hit.transform.root.name.StartsWith("AOTTG"))
            {
                if (hit.transform.root.gameObject)
                {
                    lastselected = hit.transform.root.gameObject;
                    //localtext = lastselected.name;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl))
        {
            FengGameManagerMKII.selected = lastselected;
            if (distance1 < 50)
            {
                FengGameManagerMKII.selected = closest;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            FengGameManagerMKII.selected = null;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
            camera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            camera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            camera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            int x = UnityEngine.Random.Range(-2147480999, 2147480999) * UnityEngine.Random.Range(1, 10);
            System.IO.File.WriteAllBytes((string)"ScreenShot" + x + ".png", bytes);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
            Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            int x = UnityEngine.Random.Range(-2147480999, 2147480999) * UnityEngine.Random.Range(1, 10);
            System.IO.File.WriteAllBytes((string)"ScreenShot" + x + ".png", bytes);
        }/*
        if (FengGameManagerMKII.actualseeker)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
                if (hit.transform.root.gameObject.GetComponent<HERO>())
                {
                    if (FengGameManagerMKII.modUsers.Contains(hit.transform.root.gameObject.GetComponent<SmoothSyncMovement>().photonView.owner.ID) && !hit.transform.root.gameObject.GetComponent<SmoothSyncMovement>().photonView.isMine && !FengGameManagerMKII.caught[hit.transform.root.gameObject.GetComponent<SmoothSyncMovement>().photonView.owner.ID])
                    {
                        FengGameManagerMKII.inputs.CandyModUsersOnly("Found", "All", new object[] { hit.transform.root.gameObject.GetComponent<SmoothSyncMovement>().photonView.owner.ID, PhotonNetwork.player.ID});
                    }
                }
        }
        else if (followseeker)
        {
            GameObject[] pls = GameObject.FindGameObjectsWithTag("Player");
            for (int z = 0; z < pls.Length; z++)
            {
                if (pls[z].GetComponent<SmoothSyncMovement>().photonView.owner.ID == seekerid)
                {
                    main_object.transform.position = pls[z].transform.position;
                    break;
                }
            }
        }*/
        if (Input.GetKey(KeyCode.Alpha5) && FengGameManagerMKII.candypowers)
        {
            if (Time.time - shootcandycd > .01f)
            {
                GameObject candybreath = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                candybreath.renderer.material.mainTexture = FengGameManagerMKII.candytextures[9];
                candybreath.collider.enabled = false;
                candybreath.transform.localScale = new Vector3(.3f, .2f, .2f);
                candybreath.transform.rotation = main_object.transform.rotation;
                candybreath.transform.Rotate(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
                candybreath.transform.position = main_object.transform.position + main_object.transform.forward;
                candybreath.transform.position += main_object.transform.right * UnityEngine.Random.Range(-1f, 1f);
                candybreath.transform.position += new Vector3(0f, UnityEngine.Random.Range(0.5f, 2f), 0f);
                candybreath.AddComponent<Candies>();
                candybreath.GetComponent<Candies>().GetCandies(candybreath, 1);
            }
        }/*
        if (FengGameManagerMKII.candypowers && this.inputManager.isInputDown[InputCode.attack0])
        {
            if (Time.time - doubletap < .15f)
            {
                //GameObject teren = PhotonNetwork.Instantiate("redCross", main_object.transform.position + new Vector3(0f, -5f, 0f), main_object.transform.rotation, 0);
                GameObject[] titn = GameObject.FindGameObjectsWithTag("titan");
                foreach (GameObject w in titn)
                {
                    if (Vector3.Distance(w.transform.position, main_object.transform.position) < 50f)
                    {
                        w.GetComponent<TITAN>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "hit_eren_R" });
                        w.GetComponent<TITAN>().photonView.RPC("hitRRPC", PhotonTargets.All, new object[] { main_object.transform.position, .01f });
                        PhotonNetwork.Instantiate("redCross1", w.transform.Find("Amarture/Core/Controller_Body").transform.position, w.transform.rotation, 0);
                        for (int z = 0; z < 10; z++)
                            PhotonNetwork.Instantiate(UnityEngine.Random.Range(0f, 2f) != 1 ? "redCross1" : "redCross", w.transform.Find("Amarture/Core/Controller_Body").transform.position + new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f)), w.transform.rotation, 0);
                    }
                }
            }
            else
                doubletap = Time.time;
        }*/

        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().CandyModUsersOnly("SpawnWhere", "All", new object[] { main_object.transform.position.x + 2, main_object.transform.position.y + .5f, main_object.transform.position.z + 2 });
            //FengGameManagerMKII.inputs.photonView.RPC("SpawnWhere", PhotonTargets.All, new object[] { main_object.transform.position.x + 2, main_object.transform.position.y + .5f, main_object.transform.position.z + 2 });
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (FengGameManagerMKII.candypowers)
            {
                if (!iswings)
                {
                    iswings = true;
                    GameObject.Find("MultiplayerManager").GetComponent<FengGameManagerMKII>().CandyModUsersOnly("SendObject", "All", new object[] { 1, PhotonNetwork.player.ID, main_object.transform.position.x, main_object.transform.position.y, main_object.transform.position.z });
                    //FengGameManagerMKII.inputs.photonView.RPC("SendObject", PhotonTargets.All, new object[] { 1, PhotonNetwork.player.ID, main_object.transform.position.x, main_object.transform.position.y, main_object.transform.position.z });
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (FengGameManagerMKII.candypowers)
            {
                //this.isplane = true;
                //FengGameManagerMKII.inputs.CandyModUsersOnly("SendObject", "All", new object[] { 1, PhotonNetwork.player.ID, main_object.transform.position.x, main_object.transform.position.y, main_object.transform.position.z });
                //FengGameManagerMKII.inputs.photonView.RPC("SendObject", PhotonTargets.All, new object[] { 0, PhotonNetwork.player.ID, main_object.transform.position.x, main_object.transform.position.y, main_object.transform.position.z });
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            main_object.GetComponent<HERO>().gravity = 20f;/*
            if (isplane)
            {
                GameObject.Destroy(this.plane);
                this.plane = null;
                isplane = false;
            }*/
            if (iswings)
            {
                FengGameManagerMKII.inputs.CandyModUsersOnly("DestroyWings", "Others", new object[] { PhotonNetwork.player.ID });
                GameObject.Destroy(wings);
                wings = null;
                iswings = false;
            }
        }
        if (iswings)
        {
            cameraDistance = 2.5f;
            wings.transform.localScale = new Vector3(.4f, .4f, .4f);
            wings.transform.rotation = main_object.transform.rotation * Quaternion.Euler(0f, -90f, 0f);
            wings.transform.position = main_object.transform.position - main_object.transform.forward * .2f + new Vector3(0f, .3f, 0f);
            if (FengCustomInputs.inputs.isInput[InputCode.attack0] && fly && FengGameManagerMKII.flight)
            {
                if ((main_object.transform.eulerAngles.x <= 340))
                {
                    main_object.transform.Rotate(new Vector3(-6f, 0f, 0f));
                }
                else if (main_object.transform.eulerAngles.x > 350)
                {
                    main_object.transform.Rotate(new Vector3(1f, 0f, 0f));
                }
                main_object.transform.Translate(transform.up / 2);
                wings.transform.position = main_object.transform.position - main_object.transform.forward * .2f + new Vector3(0f, 1f, 0f);
            }
            if (Input.GetKey(KeyCode.LeftShift) && fly && FengGameManagerMKII.flight)
            {
                if (!(main_object.transform.eulerAngles.x >= 45))
                {
                    main_object.transform.Rotate(new Vector3(4f, 0f, 0f));
                }
                main_object.transform.position += main_object.transform.up * -.05f;
                main_object.transform.position += main_object.transform.forward * .3f;
                wings.transform.position = main_object.transform.position - main_object.transform.forward * .05f + new Vector3(0f, 1f, 0f);
                main_object.GetComponent<HERO>().gravity = 0f;
            }
            else
                main_object.GetComponent<HERO>().gravity = 20f;
        }/*
        HERO hero_component = main_object.GetComponent<HERO>();
        if (hero_component)
        {
            if (hero_component.bulletLeft)
            {
                Bullet hero_left_bullet = hero_component.bulletLeft.GetComponent<Bullet>();
                if (hero_component.bulletLeft && !hero_left_bullet.isHooked() && !hero_component.inputManager.isInput[InputCode.leftRope] && !hero_component.inputManager.isInput[InputCode.bothRope])
                {
                    hero_left_bullet.removeMe();
                }
            }
            if (hero_component.bulletRight)
            {
                Bullet hero_right_bullet = hero_component.bulletRight.GetComponent<Bullet>();
                if (hero_component.bulletRight && !hero_right_bullet.isHooked() && !hero_component.inputManager.isInput[InputCode.rightRope] && !hero_component.inputManager.isInput[InputCode.bothRope])
                {
                    hero_right_bullet.removeMe();
                }
            }
        }*/
    }

    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }
}