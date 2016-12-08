using System;
using System.Collections.Generic;
using UnityEngine;

namespace RedSkies
{
    internal class ExtraGUI : MonoBehaviour//, MenuGUI
    {/*
        private Vector3? nullable;

        private Vector3 screenPoint;

        private Vector2 label;

        public ExtraGUI()
        {
        }

        private static bool isTitanNotDead(Animation baseA)
        {
            if (!(baseA != null) || baseA.IsPlaying("sit_die") || baseA.IsPlaying("crawler_die") || baseA.IsPlaying("die_front") || baseA.IsPlaying("die_ground"))
            {
                return false;
            }
            return !baseA.IsPlaying("die_back");
        }

        public void OnGUI()
        {
            Rect rect;
            if (HERO.radarTimer > 0f)
            {
                rect = new Rect(-5f, -5f, 210f, 40f);
                Rect rect1 = new Rect(0f, 0f, 200f, 30f);
                foreach (GameObject alltitan in FengGameManagerMKII.alltitans)
                {
                    if (!(IN_GAME_MAIN_CAMERA.main_objectT != null) || !ExtraGUI.isTitanNotDead(alltitan.animation))
                    {
                        continue;
                    }
                    Transform _transform = alltitan.transform;
                    Transform transform = _transform;
                    if (_transform == null)
                    {
                        continue;
                    }
                    this.nullable = new Vector3?(Camera.get_main().WorldToScreenPoint(transform.position));
                    if (!this.nullable.HasValue)
                    {
                        continue;
                    }
                    this.screenPoint = this.nullable.Value;
                    if (this.screenPoint.z <= 0f)
                    {
                        continue;
                    }
                    this.label = GUIUtility.ScreenToGUIPoint(this.screenPoint);
                    this.label.y = (float)Screen.height - (this.label.y + 1f);
                    rect.set_xMin(this.label.x - 5f);
                    rect.set_yMin(this.label.y - 5f);
                    GUI.Box(rect, string.Empty);
                    rect1.set_xMin(this.label.x);
                    rect1.set_yMin(this.label.y);
                    string rGBA = alltitan.name.NullFix().ToRGBA();
                    float single = Mathf.Round(Vector3.Distance(transform.position, IN_GAME_MAIN_CAMERA.main_objectT.position));
                    GUI.Box(rect1, string.Concat(rGBA, " : ", single.ToString(), " ft"));
                }
            }
            if (IN_GAME_MAIN_CAMERA.gametype != GAMETYPE.STOP && (bool)FengGameManagerMKII.settings[115] && IN_GAME_MAIN_CAMERA.mainHERO != null && IN_GAME_MAIN_CAMERA.main_objectR != null)
            {
                rect = new Rect((float)Screen.width - 200f, (float)Screen.height - 75f, 195f, 70f);
                GUI.DrawTexture(rect, GUITexture.DarkGray);
                GUILayout.BeginArea(rect);
                GUI.DrawTexture(new Rect(5f, 5f, 185f, 27.5f), GUITexture.Black);
                GUI.DrawTexture(new Rect(5f, 37.5f, 185f, 27.5f), GUITexture.Black);
                Vector3 _velocity = IN_GAME_MAIN_CAMERA.main_objectR.velocity;
                float single1 = _velocity.magnitude.RoundTo(2);
                GUILayout.BeginArea(new Rect(10f, 7f, 181f, 33.5f));
                GUILayout.Label(string.Concat("<color=yellow>Speed:\t", single1, "</color>"), new GUILayoutOption[0]);
                GUILayout.EndArea();
                GUILayout.BeginArea(new Rect(10f, 39.5f, 181f, 33.5f));
                GUILayout.Label(string.Concat("<color=yellow>Damage:\t", (IN_GAME_MAIN_CAMERA.mainHERO.useGun ? Mathf.Max(10, (int)(single1 * 10f * 0.4f)) : Mathf.Max(10, (int)(single1 * 10f))), "</color>"), new GUILayoutOption[0]);
                GUILayout.EndArea();
                GUILayout.EndArea();
            }
        }*/
    }
}