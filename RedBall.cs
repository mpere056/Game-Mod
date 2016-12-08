using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections;

public class RedBall : Photon.MonoBehaviour
{
    float explodetime = Time.time;
    int number = 0;
    GameObject thunder = new GameObject();
    bool gotthunder = false;
    int upgrade = 0;

    public void GetNumber(int a)
    {
        number = a;
        PhysicMaterial material = new PhysicMaterial("bouncy")
        {
            bounciness = 0f,
            bounceCombine = PhysicMaterialCombine.Maximum
        };
        base.gameObject.collider.material = material;
    }

    public void GetUpgrade(int upgradenumber)
    {
        upgrade = upgradenumber;
    }

    public void Update()
    {
        if (upgrade == 1)
        {
            GameObject.Destroy(thunder);
            thunder = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("FX/Thunder"), base.gameObject.transform.position, base.gameObject.transform.rotation);
            thunder.transform.localScale = base.gameObject.transform.localScale / 65;
            thunder.transform.position = base.gameObject.transform.position;
        }
        GameObject[] pl = GameObject.FindGameObjectsWithTag("Player");
        for (int z = 0; z < pl.Length; z++)
        {
            if (!pl[z].GetComponent<SmoothSyncMovement>().photonView.isMine)
                if (Vector3.Distance(pl[z].transform.position, base.gameObject.transform.position) < base.gameObject.transform.localScale.x * (upgrade == 1 ? 3 : 1.6f))
                {
                    pl[z].GetComponent<HERO>().photonView.RPC("netDie2", PhotonTargets.All, new object[] { -1, "Candy Ball" });
                    GameObject a = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("FX/Thunder"), base.gameObject.transform.position, base.gameObject.transform.rotation);
                    a.transform.localScale = new Vector3(.05f * base.gameObject.transform.localScale.x, .05f * base.gameObject.transform.localScale.y, .05f * base.gameObject.transform.localScale.z);
                    CandyBalls.balls[number] = null;
                    GameObject.Destroy(base.gameObject);
                }
        }
        if (Time.time - explodetime > 2f)
        {
            if (!gotthunder)
            {
                GameObject.Destroy(thunder);
                thunder = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("FX/Thunder"), base.gameObject.transform.position, base.gameObject.transform.rotation);
                thunder.transform.localScale = base.gameObject.transform.localScale / 65;
                //gotthunder = true;
            }
            thunder.transform.position = base.gameObject.transform.position;
            
        }
        if (Time.time - explodetime > 3f)
        {
            if (CandyBalls.balls[number] != null)
            {
                GameObject a = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("FX/Thunder"), base.gameObject.transform.position, base.gameObject.transform.rotation);
                a.transform.localScale = new Vector3(.05f * base.gameObject.transform.localScale.x, .05f * base.gameObject.transform.localScale.y, .05f * base.gameObject.transform.localScale.z);
                CandyBalls.balls[number] = null;
                GameObject.Destroy(base.gameObject);
            }
        }
    }
}