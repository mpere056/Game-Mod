using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

namespace RedSkies
{
    internal class F2GUI : MonoBehaviour//, MenuGUI
    {/*
        private readonly static string[] commandsReg;

        private readonly static string[] commandsMode;

        private Vector2 scroll = Vector3.zero;

        private static Vector3 GUIMatrix;

        private static float adder
        {
            get
            {
                if (Screen.width < 1024)
                {
                    return 10f;
                }
                return -25f;
            }
        }

        private static float divider
        {
            get
            {
                if (Screen.width < 1024)
                {
                    return 3f;
                }
                return 1f;
            }
        }

        private static Matrix4x4 matrix
        {
            get
            {
                return Matrix4x4.TRS(Vector3.zero, Quaternion.get_identity(), new Vector3(1f, 1f, 1f));
            }
        }

        private static Matrix4x4 resize
        {
            get
            {
                return Matrix4x4.TRS(Vector3.zero, Quaternion.get_identity(), new Vector3((float)Screen.width / (2400f / F2GUI.divider), (float)Screen.height / (1800f / F2GUI.divider), 1f));
            }
        }

        static F2GUI()
        {
            F2GUI.GUIMatrix = Vector3.zero;
            string[] strArrays = new string[] { "/restart", "/setmc", "/time", "/kick", "/ban", "/unban", "/add", "/erase", "/die", "/live", "/deathlist", "/antisteal", "/antiname", "/afk", "/banlist", "/cmdlist", "/roomlist", "/objlist", "/namelist", "/crashlist", "/mutelist", "/kill", "/rek", "/clear", "/mode", "/light", "/revive", "/resetkd", "/destroy", "/maxplayers", "//s", "//w", "//c", "/me", "/pm", "/color", "/quit", "/pvp", "/crash", "/mute", "/unmute", "/users", "/noguests", "GroupChats", "/dc", "/info", "/current", "/modinfo", "/horse", "/spawn" };
            F2GUI.commandsReg = strArrays;
            Array.Sort<string>(F2GUI.commandsReg, (string x, string y) => string.Compare(x, y));
            string[] strArrays1 = new string[] { "/duelspd", "/nocrawler", "/heat", "/ice", "/zerog", "/endless", "/size", "/shifter", "/crawler", "/punks", "/teleport", "/nopunks", "/untouch", "/waves", "/damage", "/bomb", "/annie", "/dueldmg", "/dueltotal", "/lock", "/hvh", "/respawn", "/health", "/noabs", "/nojumpers", "/nonormals" };
            F2GUI.commandsMode = strArrays1;
            Array.Sort<string>(F2GUI.commandsMode, (string x, string y) => string.Compare(x, y));
        }

        public F2GUI()
        {
        }

        private void Awake()
        {
            Object.DontDestroyOnLoad(base.gameObject);
            float _width = 1024f / (float)Screen.width;
            float _height = 768f / (float)Screen.height;
            F2GUI.GUIMatrix = new Vector3(_width, _height, 1f);
        }

        private static GUIStyle formatStyle(GUIStyle other)
        {
            GUIStyle gUIStyle = new GUIStyle(other);
            gUIStyle.set_wordWrap(true);
            gUIStyle.set_alignment(0);
            gUIStyle.set_fontSize((F2GUI.divider != 1f ? 14 : 15));
            return gUIStyle;
        }

        private void OnDisable()
        {
            if (FengGameManagerMKII.settings != null && (int)FengGameManagerMKII.settings.Length > 0)
            {
                FengGameManagerMKII.settings[82] = false;
                if (IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.SINGLE)
                {
                    Time.timeScale = (1f);
                }
                if (!(FengGameManagerMKII.MKII != null) || !FengGameManagerMKII.gameStart)
                {
                    Screen.showCursor = (true);
                    Screen.lockCursor = (false);
                }
                else
                {
                    Screen.showCursor = (false);
                    Screen.lockCursor = ((IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS ? true : IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.oldTPS));
                }
                int num = 0;
                IN_GAME_MAIN_CAMERA.isPausing = (bool)num;
                IN_GAME_MAIN_CAMERA.isTyping = (bool)num;
                FengGameManagerMKII.settings[35] = (bool)num;
            }
        }

        private void OnEnable()
        {
            if (FengGameManagerMKII.settings != null && (int)FengGameManagerMKII.settings.Length > 0)
            {
                if (!Screen.showCursor)
                {
                    Screen.showCursor = (true);
                }
                if (Screen.lockCursor)
                {
                    Screen.lockCursor = (false);
                }
                if (!(bool)FengGameManagerMKII.settings[82])
                {
                    FengGameManagerMKII.settings[82] = true;
                }
                if (!IN_GAME_MAIN_CAMERA.isPausing)
                {
                    IN_GAME_MAIN_CAMERA.isPausing = true;
                    IN_GAME_MAIN_CAMERA.isTyping = true;
                }
            }
        }

        public void OnGUI()
        {
            int num;
            int num1;
            GUI.depth = (-100);
            if (Event.current.type == 4 && Event.current.keyCode == 283)
            {
                this.OnDisable();
                return;
            }
            if (!Screen.showCursor)
            {
                Screen.showCursor = (true);
            }
            if (Screen.lockCursor)
            {
                Screen.lockCursor = (false);
            }
            if (!(bool)FengGameManagerMKII.settings[82])
            {
                FengGameManagerMKII.settings[82] = true;
            }
            if (!IN_GAME_MAIN_CAMERA.isPausing)
            {
                IN_GAME_MAIN_CAMERA.isPausing = true;
                IN_GAME_MAIN_CAMERA.isTyping = true;
            }
            float _width = (float)Screen.width / 4f;
            float _height = (float)Screen.height / 4f;
            float single = (float)Screen.width / 2f;
            float _height1 = (float)Screen.height / 2f;
            Rect rect = new Rect(_width, _height, single, _height1);
            GUI.backgroundColor = (Color.black);
            GUI.Box(new Rect(_width - 9f, _height - 39f, single + 18f, _height1 + 48f), string.Empty);
            GUI.Box(new Rect(_width - 5f, _height - 35f, single + 10f, _height1 + 40f), string.Empty);
            GUI.Box(new Rect(_width - 5f, _height - 35f, single + 10f, _height1 + 40f), string.Empty);
            GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
            GUI.Box(rect, string.Empty);
            GUI.Box(rect, string.Empty);
            GUI.Box(rect, string.Empty);
            if ((int)FengGameManagerMKII.settings[36] == 2)
            {
                GUI.backgroundColor = (Color.get_grey());
                string str = "<b>STARTER</b>  <size=12><i>These are the few things in this mod that makes it unique.</i></size>";
                Rect rect1 = GUILayoutUtility.GetRect(new GUIContent(str), "Button");
                Rect rect2 = new Rect(_width + 5f, _height + 5f, single - 20f, 25f);
                if (rect2.width >= rect1.width)
                {
                    GUI.Label(rect2, str, "Button");
                }
                else
                {
                    GUI.Label(rect2, string.Empty, "Button");
                    GUI.Label(new Rect(_width + 10f, _height + 7f, single - 20f, 25f), "<b>STARTER</b>", "Label");
                }
                string str1 = string.Join("\r\n", FengGameManagerMKII.StarterExplaination());
                GUILayout.BeginArea(new Rect(_width + 5f, _height + 35f, single - 5f, _height1 - 35f));
                this.scroll = GUILayout.BeginScrollView(this.scroll, new GUILayoutOption[0]);
                GUILayout.Label(str1, F2GUI.formatStyle("Label"), new GUILayoutOption[0]);
                GUILayout.EndScrollView();
                GUILayout.EndArea();
            }
            else if ((int)FengGameManagerMKII.settings[36] == 1)
            {
                GUI.backgroundColor = (Color.get_grey());
                string str2 = "<size=11><i><b>COMMAND LIST</b></i></size>\r\n<size=11><i>Choose a command.</i></size>";
                GUIStyle gUIStyle = new GUIStyle("Button");
                Rect rect3 = GUILayoutUtility.GetRect(new GUIContent(str2), gUIStyle);
                GUI.Label(new Rect(_width + single - rect3.width, _height + 4f, rect3.width, 50f), str2);
                GUI.Label(new Rect(_width + 5f, _height + 5f, single - 10f, 30f), string.Empty, gUIStyle);
                GUI.backgroundColor = (Color.Lerp(Color.get_grey(), Color.get_white(), 0.95f));
                if ((int)FengGameManagerMKII.settings[37] == 1)
                {
                    GUI.backgroundColor = (Color.black);
                }
                Rect rect4 = GUILayoutUtility.GetRect(new GUIContent("REGULAR"), gUIStyle);
                Rect rect5 = GUILayoutUtility.GetRect(new GUIContent("GAMEMODE"), gUIStyle);
                if (GUI.Button(new Rect(_width + 10f, _height + 10f, rect4.width, 20f), "REGULAR", gUIStyle))
                {
                    FengGameManagerMKII.settings[37] = ((int)FengGameManagerMKII.settings[37] != 1 ? 1 : 0);
                }
                GUI.backgroundColor = (Color.Lerp(Color.get_grey(), Color.get_white(), 0.95f));
                if ((int)FengGameManagerMKII.settings[37] == 2)
                {
                    GUI.backgroundColor = (Color.black);
                }
                if (GUI.Button(new Rect(_width + 15f + rect4.width, _height + 10f, rect5.width, 20f), "GAMEMODE", gUIStyle))
                {
                    FengGameManagerMKII.settings[37] = ((int)FengGameManagerMKII.settings[37] != 2 ? 2 : 0);
                }
                if ((int)FengGameManagerMKII.settings[37] == 1 || (int)FengGameManagerMKII.settings[37] == 2)
                {
                    GUI.backgroundColor = (Color.get_red());
                    if ((int)FengGameManagerMKII.settings[37] == 1)
                    {
                        GUI.backgroundColor = (Color.get_red());
                        this.SelectionGrid(4, F2GUI.resize, F2GUI.matrix, F2GUI.divider, F2GUI.adder);
                    }
                    else if ((int)FengGameManagerMKII.settings[37] == 2)
                    {
                        GUI.backgroundColor = (Color.get_red());
                        this.SelectionGrid(5, F2GUI.resize, F2GUI.matrix, F2GUI.divider, F2GUI.adder);
                    }
                }
                else
                {
                    GUI.set_matrix(F2GUI.resize);
                    GUI.backgroundColor = (Color.get_white());
                    Rect rect6 = new Rect(610f / F2GUI.divider, 555f / F2GUI.divider + F2GUI.adder, 1180f / F2GUI.divider, 60f / F2GUI.divider);
                    string str3 = (string)FengGameManagerMKII.settings[38];
                    GUIStyle gUIStyle1 = new GUIStyle("Button");
                    gUIStyle1.set_wordWrap(true);
                    gUIStyle1.set_alignment(3);
                    gUIStyle1.set_fontSize((F2GUI.divider != 1f ? 15 : 35));
                    gUIStyle1.set_fontStyle(3);
                    GUI.Label(rect6, str3, gUIStyle1);
                    string[] empty = new string[] { string.Empty, FengGameManagerMKII.CmdDescription() };
                    string[] strArrays = empty;
                    if (!strArrays[1].IsNullOrEmpty() && strArrays[1].Contains("\n"))
                    {
                        int num2 = strArrays[1].IndexOf("\n");
                        string[] strArrays1 = new string[] { strArrays[1].Remove(num2), strArrays[1].Substring(num2) };
                        strArrays = strArrays1;
                        strArrays[0] = Regex.Replace(strArrays[0], "\\s(or)\\s", " </i></color>$1<color=yellow><i> ");
                        strArrays[0] = Regex.Replace(strArrays[0], "(\\[)(.+?)(\\])", "<color=yellow><b>$1</b></color><color=white>$2</color><color=yellow><b>$3</b></color>");
                        strArrays[0] = string.Concat("<color=yellow><i>", strArrays[0], "</i></color>");
                        strArrays[1] = string.Concat("\r\n", strArrays[1].TrimStart(new char[0]));
                    }
                    bool flag = F2GUI.divider != 1f;
                    GUI.backgroundColor = (Color.get_grey());
                    GUILayout.BeginArea(new Rect(610f / F2GUI.divider, 665f / F2GUI.divider + F2GUI.adder, 1190f / F2GUI.divider, 825f / F2GUI.divider));
                    if (!flag)
                    {
                        Vector2 vector2 = this.scroll;
                        GUILayoutOption[] gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.MaxHeight(700f) };
                        this.scroll = GUILayout.BeginScrollView(vector2, gUILayoutOptionArray);
                    }
                    else
                    {
                        Vector2 vector21 = this.scroll;
                        GUILayoutOption[] gUILayoutOptionArray1 = new GUILayoutOption[] { GUILayout.MaxHeight(620f / F2GUI.divider + F2GUI.adder) };
                        this.scroll = GUILayout.BeginScrollView(vector21, gUILayoutOptionArray1);
                    }
                    string str4 = strArrays[0];
                    GUIStyle gUIStyle2 = new GUIStyle("Box");
                    gUIStyle2.set_wordWrap(true);
                    gUIStyle2.set_alignment(3);
                    GUIStyle gUIStyle3 = gUIStyle2;
                    if (flag)
                    {
                        num = 14;
                    }
                    else
                    {
                        num = (Screen.height > 1000 ? 28 : 33);
                    }
                    gUIStyle3.set_fontSize(num);
                    GUILayout.Label(str4, gUIStyle2, new GUILayoutOption[0]);
                    string str5 = strArrays[1];
                    GUIStyle gUIStyle4 = new GUIStyle("Label");
                    gUIStyle4.set_wordWrap(true);
                    gUIStyle4.set_alignment(0);
                    GUIStyle gUIStyle5 = gUIStyle4;
                    if (flag)
                    {
                        num1 = 14;
                    }
                    else
                    {
                        num1 = (Screen.height > 1000 ? 24 : 29);
                    }
                    gUIStyle5.set_fontSize(num1);
                    GUILayout.Label(str5, gUIStyle4, new GUILayoutOption[0]);
                    GUILayout.EndScrollView();
                    GUILayout.EndArea();
                    GUI.set_matrix(F2GUI.matrix);
                }
            }
            else if ((int)FengGameManagerMKII.settings[36] == 0)
            {
                GUI.backgroundColor = (Color.get_grey());
                string str6 = "<b>CHANGELOG</b>  <size=12><i>For viewing the recent changes of this mod or the next newest update.</i></size>";
                Rect rect7 = GUILayoutUtility.GetRect(new GUIContent(str6), "Button");
                Rect rect8 = new Rect(_width + 5f, _height + 5f, single - 20f, 25f);
                if (rect8.width >= rect7.width)
                {
                    GUI.Label(rect8, str6, "Button");
                }
                else
                {
                    GUI.Label(rect8, string.Empty, "Button");
                    GUI.Label(new Rect(_width + 10f, _height + 7f, single - 20f, 25f), "<b>CHANGELOG</b>", "Label");
                }
                string str7 = FengGameManagerMKII.ChangeLog();
                GUILayout.BeginArea(new Rect(_width + 5f, _height + 35f, single, _height1 - 35f));
                this.scroll = GUILayout.BeginScrollView(this.scroll, new GUILayoutOption[0]);
                GUILayout.Label(str7, F2GUI.formatStyle("Label"), new GUILayoutOption[0]);
                GUILayout.EndScrollView();
                GUILayout.EndArea();
            }
            GUI.backgroundColor = (Color.get_red());
            if (GUI.Button(new Rect(_width + single / 3f + 2.5f, _height - 35f, single / 3f - 5f, 30f), "Command List"))
            {
                FengGameManagerMKII.settings[36] = 1;
                return;
            }
            if (GUI.Button(new Rect(_width + single / 3f * 2f + 2.5f, _height - 35f, single / 3f - 2.5f, 30f), "ChangeLog"))
            {
                FengGameManagerMKII.settings[36] = 0;
                return;
            }
            if (GUI.Button(new Rect(_width, _height - 35f, single / 3f - 2.5f, 30f), "Starter"))
            {
                FengGameManagerMKII.settings[36] = 2;
            }
        }

        internal void SelectionGrid(int id, Matrix4x4 resize, Matrix4x4 matrix, float divider, float adder)
        {
            int num = 0;
            if (id == 4)
            {
                num = 0;
                while (num < (int)F2GUI.commandsReg.Length)
                {
                    if (!((string)FengGameManagerMKII.settings[38]).IsNullOrEmpty())
                    {
                        if ((string)FengGameManagerMKII.settings[38] == F2GUI.commandsReg[num])
                        {
                            break;
                        }
                        num++;
                    }
                    else
                    {
                        num = -1;
                        break;
                    }
                }
                GUI.set_contentColor(Color.get_white());
                GUI.set_matrix(resize);
                GUILayout.BeginArea(new Rect(613f / divider, 555f / divider + adder, 1060f / divider, 1800f / divider));
                int num1 = num;
                string[] strArrays = F2GUI.commandsReg;
                GUIStyle gUIStyle = new GUIStyle("Button");
                gUIStyle.set_wordWrap(true);
                gUIStyle.set_alignment(4);
                gUIStyle.set_fontSize((divider != 1f ? 13 : 35));
                GUILayoutOption[] gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(1060f / divider) };
                int num2 = GUILayout.SelectionGrid(num1, strArrays, 4, gUIStyle, gUILayoutOptionArray);
                GUILayout.EndArea();
                GUI.set_matrix(matrix);
                GUI.set_contentColor(Color.get_white());
                GUI.backgroundColor = (Color.get_clear());
                if (num != num2)
                {
                    FengGameManagerMKII.settings[38] = F2GUI.commandsReg[num2];
                    FengGameManagerMKII.settings[37] = 0;
                    return;
                }
            }
            else if (id == 5)
            {
                GUI.set_contentColor(Color.get_white());
                num = 0;
                while (num < (int)F2GUI.commandsMode.Length)
                {
                    if (!((string)FengGameManagerMKII.settings[38]).IsNullOrEmpty())
                    {
                        if ((string)FengGameManagerMKII.settings[38] == F2GUI.commandsMode[num])
                        {
                            break;
                        }
                        num++;
                    }
                    else
                    {
                        num = -1;
                        break;
                    }
                }
                GUI.set_matrix(resize);
                GUILayout.BeginArea(new Rect(613f / divider, 555f / divider + adder, 1060f / divider, 1800f / divider));
                int num3 = num;
                string[] strArrays1 = F2GUI.commandsMode;
                GUIStyle gUIStyle1 = new GUIStyle("Button");
                gUIStyle1.set_wordWrap(true);
                gUIStyle1.set_alignment(4);
                gUIStyle1.set_fontSize((divider != 1f ? 13 : 35));
                GUILayoutOption[] gUILayoutOptionArray1 = new GUILayoutOption[] { GUILayout.Width(1060f / divider) };
                int num4 = GUILayout.SelectionGrid(num3, strArrays1, 4, gUIStyle1, gUILayoutOptionArray1);
                GUILayout.EndArea();
                GUI.set_matrix(matrix);
                GUI.set_contentColor(Color.get_white());
                GUI.backgroundColor = (Color.get_clear());
                if (num != num4)
                {
                    FengGameManagerMKII.settings[38] = F2GUI.commandsMode[num4];
                    FengGameManagerMKII.settings[37] = 0;
                }
            }
        }*/
    }
}