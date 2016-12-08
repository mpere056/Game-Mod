using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections;

public class CandyBalls : Photon.MonoBehaviour
{
    public static bool candyballspvpmode = false;
    public static GameObject[] balls = new GameObject[700];
    public static float[] sizesx = new float[700];
    public static float[] velocitiesx = new float[700];
    public static float[] velocitiesy = new float[700];
    public static float[] velocitiesz = new float[700];
    public static float[] posx = new float[700];
    public static float[] posy = new float[700];
    public static float[] posz = new float[700];
    float updatetime = Time.time;
    public static float energybar = 0f;
    Vector2 pos = new Vector2(Screen.width / 3, Screen.height / 1.1f);
    Vector2 size = new Vector2(Screen.width / 3, Screen.height / 20);
    Texture2D progressBarEmpty;
    public static Texture2D progressBarFull;
    float regeneratebar = Time.time;
    float chargetime = Time.time;
    float startshoot = Time.time;
    GameObject thunder = new GameObject();
    int upgrade = 0;
    GameObject charging = new GameObject();

    public void OnGUI()
    {
        if (FengGameManagerMKII.gameStart && FengGameManagerMKII.level == "CandyMod Balls PVP")
        {
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);

            GUI.BeginGroup(new Rect(0, 0, size.x * energybar, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
            GUI.EndGroup();

            GUI.EndGroup();
        }
        else
            energybar = 0;
    }

    public void ClearMap()
    {
        updatetime = Time.time;
        candyballspvpmode = true;
        foreach (GameObject obj1 in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            //destroy all undesired objects
            if (obj1.tag.Contains("titan") || (obj1.name.Contains("Cube") && !obj1.name.Contains("01") && !obj1.name.Contains("02") && !obj1.name.Contains("06") && !obj1.name.Contains("07")))
            {
                GameObject.Destroy(obj1);
            }
            else if (obj1.name.Contains("Cube"))
            {
                obj1.renderer.material.color = UnityEngine.Random.Range(1f, 5f) > 4 ? Color.blue : UnityEngine.Random.Range(1f, 5f) > 4 ? Color.cyan : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.green : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.red : Color.yellow;
            }
        }
        if (PhotonNetwork.isMasterClient)
        SpawnBalls();
    }

    public void SpawnBalls()
    {
        PhysicMaterial material = new PhysicMaterial("bouncy")
        {
            bounciness = .8f,
            bounceCombine = PhysicMaterialCombine.Maximum
        };
        if (PhotonNetwork.isMasterClient)
        {
            for (int z = 0; z < 600; z++)
            {
                float sizeofball = UnityEngine.Random.Range(5f, 100f);
                balls[z] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                balls[z].layer = LayerMask.NameToLayer("Ground");
                balls[z].collider.material = material;
                balls[z].AddComponent<Rigidbody>();
                balls[z].rigidbody.useGravity = false;
                balls[z].transform.localScale = new Vector3(sizeofball, sizeofball, sizeofball);
                balls[z].name = "Candy Ball" + Convert.ToString(z);
                balls[z].transform.position = new Vector3(UnityEngine.Random.Range(-600f, 600f), UnityEngine.Random.Range(0f, 700f), UnityEngine.Random.Range(-600f, 600f));
                balls[z].renderer.material.color = UnityEngine.Random.Range(1f, 5f) > 4 ? Color.blue : UnityEngine.Random.Range(1f, 5f) > 4 ? Color.cyan : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.green : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.magenta : Color.yellow;
            }
            for (int z = 600; z < 700; z++)
            {
                float sizeofball = UnityEngine.Random.Range(5f, 100f);
                balls[z] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                balls[z].layer = LayerMask.NameToLayer("Ground");
                balls[z].collider.material = material;
                balls[z].AddComponent<Rigidbody>();
                balls[z].rigidbody.useGravity = false;
                balls[z].transform.localScale = new Vector3(sizeofball, sizeofball, sizeofball);
                balls[z].name = "Candy Ball" + Convert.ToString(z);
                balls[z].transform.position = new Vector3(UnityEngine.Random.Range(-600f, 600f), UnityEngine.Random.Range(0f, 100f), UnityEngine.Random.Range(-600f, 600f));
                balls[z].renderer.material.color = UnityEngine.Random.Range(1f, 5f) > 3 ? Color.blue : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.cyan : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.green : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.magenta : Color.yellow;
            }
        }
        else
        {
            for (int z = 0; z < 700; z++)
            {
                if (sizesx[z] != 4f)
                {
                    float sizeofball = sizesx[z];
                    balls[z] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    balls[z].layer = LayerMask.NameToLayer("Ground");
                    balls[z].collider.material = material;
                    balls[z].AddComponent<Rigidbody>();
                    balls[z].rigidbody.useGravity = false;
                    balls[z].transform.localScale = new Vector3(sizeofball, sizeofball, sizeofball);
                    balls[z].name = "Candy Ball" + Convert.ToString(z);
                    balls[z].transform.position = new Vector3(posx[z], posy[z], posz[z]);
                    balls[z].renderer.material.color = UnityEngine.Random.Range(1f, 5f) > 4 ? Color.blue : UnityEngine.Random.Range(1f, 5f) > 4 ? Color.cyan : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.green : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.magenta : Color.yellow;
                    balls[z].rigidbody.velocity = new Vector3(velocitiesx[z], velocitiesy[z], velocitiesz[z]);
                }
                else
                    balls[z] = null;
            }
        }
        if (PhotonNetwork.isMasterClient)
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
                sizex[z] = CandyBalls.balls[z].transform.localScale.x;
                velocityx[z] = CandyBalls.balls[z].rigidbody.velocity.x;
                velocityy[z] = CandyBalls.balls[z].rigidbody.velocity.y;
                velocityz[z] = CandyBalls.balls[z].rigidbody.velocity.z;
                posx[z] = CandyBalls.balls[z].transform.position.x;
                posy[z] = CandyBalls.balls[z].transform.position.y;
                posz[z] = CandyBalls.balls[z].transform.position.z;
            }
            base.GetComponent<CandyBalls>().photonView.RPC("SetValues", PhotonTargets.Others, new object[] { sizex, velocityx, velocityy, velocityz, posx, posy, posz });
        }
    }

    public void Update()
    {
        if (candyballspvpmode)
        {
            if (PhotonNetwork.isMasterClient)
            {
                if (Time.time - updatetime > .1f)
                {
                    Vector3[] velocitys = new Vector3[700];
                    Vector3[] pos = new Vector3[700];
                    for (int z = 0; z < CandyBalls.balls.Length; z++)
                    {
                        if (balls[z] != null)
                        {
                            velocitys[z] = CandyBalls.balls[z].rigidbody.velocity;
                            pos[z] = CandyBalls.balls[z].transform.position;
                        }
                    }
                    base.photonView.RPC("UpdateValues", PhotonTargets.All, new object[] { Time.time, velocitys, pos });
                    updatetime = Time.time;
                }
            }
        }
    }

    public void LateUpdate()
    {
        if (Time.time - regeneratebar > .2f)
        {
            if (energybar < 1f)
            {
                energybar += .01f;
            }
            regeneratebar = Time.time;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 150))
        {
            if (FengCustomInputs.inputs.isInputDown[InputCode.attack0])
            {
                if (hit.transform.root.gameObject != null && hit.transform.root.gameObject.name.Contains("Candy Ball"))
                {
                    if (!hit.transform.root.gameObject.GetComponent<RedBall>())
                    {
                        GameObject hitball = hit.transform.root.gameObject;
                        if (!hitball.GetComponent<LineRenderer>())
                        {
                            hitball.AddComponent<LineRenderer>();
                            hitball.GetComponent<LineRenderer>().SetWidth(2f, 2f);
                            hitball.GetComponent<LineRenderer>().SetVertexCount(2);
                            hitball.GetComponent<LineRenderer>().SetPosition(0, hitball.transform.position);
                            hitball.GetComponent<LineRenderer>().SetPosition(1, hit.point);
                            hitball.GetComponent<LineRenderer>().material.mainTexture = FengGameManagerMKII.candytextures[8];
                        }
                        chargetime = Time.time;
                        startshoot = Time.time;
                        base.StartCoroutine(ShootBall(hitball, ray.direction, hitball.renderer.material.color));
                        hitball.renderer.material.color = Color.white;
                    }
                }
            }
        }
    }

    public IEnumerator ShootBall(GameObject a, Vector3 b, Color c)
    {
        while (FengCustomInputs.inputs.isInput[InputCode.attack0])
        {
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit1;
            if (Physics.Raycast(ray1, out hit1))
            {
                a.GetComponent<LineRenderer>().enabled = true;
                a.GetComponent<LineRenderer>().SetWidth(2f, 2f);
                a.GetComponent<LineRenderer>().SetVertexCount(2);
                a.GetComponent<LineRenderer>().material.mainTexture = FengGameManagerMKII.candytextures[8];
                a.GetComponent<LineRenderer>().SetPosition(0, a.transform.position);
                a.GetComponent<LineRenderer>().SetPosition(1, hit1.point);
            }
            if (Time.time - startshoot < 2f || energybar < .3f)
            {
                chargetime = Time.time;
            }
            else
            {
                if (charging == null)
                {
                    charging = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    charging.transform.parent = IN_GAME_MAIN_CAMERA.main_object.transform;
                    charging.transform.position = IN_GAME_MAIN_CAMERA.main_object.transform.position + new Vector3(0f, .7f, 0f);
                    charging.collider.enabled = false;
                    charging.transform.localScale = new Vector3(2f, 2f, 2f);
                    charging.renderer.material.shader = Shader.Find("Hidden/Internal-Halo");
                }
                charging.renderer.material.color = UnityEngine.Random.Range(1f, 5f) > 3 ? Color.blue : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.cyan : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.green : UnityEngine.Random.Range(1f, 5f) > 3 ? Color.magenta : Color.yellow;
            }
            if (Time.time - chargetime > 3f && energybar > .7f)
            {
                upgrade = 1;
                GameObject.Destroy(thunder);
                thunder = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("FX/Thunder"), IN_GAME_MAIN_CAMERA.main_object.transform.position, IN_GAME_MAIN_CAMERA.main_object.transform.rotation);
                thunder.transform.localScale = new Vector3(.01f, .01f, .01f);
                thunder.transform.localScale = new Vector3(thunder.transform.localScale.x / 100, thunder.transform.localScale.y / 100, thunder.transform.localScale.z / 100);
                thunder.transform.position = IN_GAME_MAIN_CAMERA.main_object.transform.position;
            }
            else
                upgrade = 0;
            yield return new WaitForEndOfFrame();
        }
        GameObject.Destroy(charging);
        a.GetComponent<LineRenderer>().enabled = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float strength;
        if (energybar > .2f)
        {
            if (Time.time - startshoot > 1f)
            {
                if (energybar > .2f + (Time.time - chargetime) * .1f)
                {
                    strength = (.3f + (Time.time - chargetime) * .15f) * 2000;
                    energybar = energybar - (.15f + (Time.time - chargetime) * .1f);
                }
                else
                {
                    strength = (energybar + (Time.time - chargetime) * .15f)  * 2000;
                    energybar = 0;
                }
                strength = strength * (1 + (Time.time - chargetime) / 10);
            }
            else
            {
                chargetime = Time.time;
                strength = 600;
                energybar = energybar - .15f;
            }
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 direction = (hit.point - a.transform.position).normalized;
                base.photonView.RPC("MakeDangerous", PhotonTargets.All, new object[] { Convert.ToInt32(a.name.Remove(0, 10)), direction.x, direction.y, direction.z, strength, upgrade });
            }
        }
        else
        {
            a.renderer.material.color = c;
        }
    }

    [RPC]
    public void MakeDangerous(int number, float x, float y, float z, float strength, int upgradenumber)
    {
        balls[number].renderer.material.color = Color.red;
        balls[number].renderer.material.mainTexture = FengGameManagerMKII.candytextures[11];
        if (!balls[number].GetComponent<RedBall>())
        balls[number].AddComponent<RedBall>();
        balls[number].GetComponent<RedBall>().GetNumber(number);
        balls[number].rigidbody.AddForce(new Vector3(x, y, z) * strength * 30);
        balls[number].AddComponent<Light>();
        balls[number].GetComponent<Light>().intensity = 1000f;
        balls[number].GetComponent<Light>().range = base.gameObject.transform.localScale.x * 8f;
        balls[number].GetComponent<Light>().color = Color.white;
        balls[number].renderer.material.shader = Shader.Find("Transparent/VertexLit");
        balls[number].light.intensity = 1000f;
        balls[number].light.range = base.gameObject.transform.localScale.x * 8f;
        balls[number].light.color = Color.white;
        balls[number].GetComponent<RedBall>().GetUpgrade(upgradenumber);
    }

    [RPC]
    public void UpdateValues(float time, Vector3[] velocity, Vector3[] position)
    {
        for (int z = 0; z < balls.Length; z++)
        {
            if (balls[z] != null)
            {
                balls[z].rigidbody.velocity = velocity[z];
                balls[z].transform.position = position[z];
            }
        }
    }

    [RPC]
    public void SetValues(float[] sizex, float[] velocityx, float[] velocityy, float[] velocityz, float[] positionx, float[] positiony, float[] positionz)
    {
        ClearMap();
        sizesx = sizex;
        velocitiesx = velocityx;
        velocitiesy = velocityy;
        velocitiesz = velocityz;
        posx = positionx;
        posy = positiony;
        posz = positionz;
        SpawnBalls();
    }
}