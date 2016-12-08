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
}