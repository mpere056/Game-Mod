using ExitGames.Client.Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine;
using Xft;

public class Candies : MonoBehaviour
{
    public GameObject main_object = null;
    int mode = 0;
    float deathtime = Time.time;
    GameObject[] titans = GameObject.FindGameObjectsWithTag("titan");
    GameObject[] humans = GameObject.FindGameObjectsWithTag("Player");

    public void GetCandies(GameObject a, int b)
    {
       main_object = a;
       mode = b;
    }

    public void Update()
    {
        main_object.collider.enabled = false;
        if (main_object != null)
        {
            if (mode == 0)
            {
                main_object.transform.position = new Vector3(main_object.transform.position.x, main_object.transform.position.y - 2, main_object.transform.position.z);
            }

            if (mode == 1)
            {
                main_object.transform.position += main_object.transform.forward * 5;
                for (int z = 0; z < titans.Length; z++)
                {
                    if (Vector3.Distance(titans[z].transform.Find("Amarture/Core/Controller_Body").position, main_object.transform.position) < 20)
                    {
                        titans[z].GetComponent<TITAN>().photonView.RPC("laugh", PhotonTargets.All, new object[] { 0f });
                    }
                }
                for (int z = 0; z < humans.Length; z++)
                {
                    if (Vector3.Distance(humans[z].transform.position, main_object.transform.position) < 5 && !humans[z].GetComponent<SmoothSyncMovement>().photonView.isMine)
                    {
                        if (Time.time - FengGameManagerMKII.dancecd > 1f)
                        {
                            float whichdance = UnityEngine.Random.Range(0f, 10f);
                            if (whichdance < 1)
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "special_marco_1" });
                            else if (whichdance < 2)
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "special_marco_0" });
                            else if (whichdance < 3)
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "special_armin" });
                            else if (whichdance < 4)
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "attack1_hook_r1" });
                            else if (whichdance < 5)
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "attack2" });
                            else if (whichdance < 6)
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "AHSS_shoot_both_air" });
                            else if (whichdance < 7)
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "special_petra" });
                            else if (whichdance < 8)
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "horse_getoff" });
                            else if (whichdance < 9)
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "attack3_2" });
                            else
                                humans[z].GetComponent<HERO>().photonView.RPC("netPlayAnimation", PhotonTargets.All, new object[] { "air_rise" });
                            FengGameManagerMKII.dancecd = Time.time;
                        }
                    }
                }
            }

            if (Time.time - deathtime > .3f)
            {
                GameObject.Destroy(main_object);
            }
        }
    }
}
