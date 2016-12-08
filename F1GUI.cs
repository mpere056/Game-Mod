using Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

namespace RedSkies
{
    internal class F1GUI : Photon.MonoBehaviour//, MenuGUI
    {/*
        private static Pair<WWW, bool> skinWWW;

        private static Texture2D SkinTex;

        private static Texture2D resizedSkinTex;

        private static bool keyup;

        private static bool flip;

        private static F1GUI.Tab tabs;

        private static int currentPage;

        private static bool MORE;

        private static bool Grid;

        private static int qualitylevel;

        private static float heightPos;

        private static float timeTillReplaced;

        private static Vector2 scroll;

        private static Vector2 scroll2;

        private static Vector3 GUIMatrix;

        private readonly static Regex regexHex;

        private readonly static string[] characters;

        private readonly static string[] specials;

        private readonly static string[] gameTypes;

        private static Dictionary<int, string> stealSkin;

        static F1GUI()
        {
            F1GUI.skinWWW = new Pair<WWW, bool>(null, false);
            F1GUI.keyup = false;
            F1GUI.flip = false;
            F1GUI.currentPage = 0;
            F1GUI.MORE = false;
            F1GUI.Grid = false;
            F1GUI.heightPos = 0f;
            F1GUI.timeTillReplaced = 0f;
            F1GUI.scroll = Vector3.zero;
            F1GUI.scroll2 = Vector3.zero;
            F1GUI.GUIMatrix = Vector3.zero;
            F1GUI.regexHex = new Regex("\\[([a-fA-F0-9]{6})\\]");
            F1GUI.stealSkin = new Dictionary<int, string>();
            F1GUI.tabs = new F1GUI.Tab();
            string[] strArrays = new string[] { "MIKASA", "LEVI", "ARMIN", "MARCO", "JEAN", "EREN", "PETRA", "SASHA", "TITAN_EREN", "SET 1", "SET 2", "SET 3", "AHSS-MIKASA", "AHSS-LEVI", "AHSS-ARMIN", "AHSS-MARCO", "AHSS-JEAN", "AHSS-EREN", "AHSS-PETRA", "AHSS-SASHA" };
            F1GUI.characters = strArrays;
            string[] strArrays1 = new string[] { "none", "mikasa", "levi", "armin", "marco", "jean", "eren", "petra", "sasha", "refill", "afterimg", "radar", "hypercannon", "trap", "slash" };
            F1GUI.specials = strArrays1;
            string[] strArrays2 = new string[] { "1 Round", "Waves", "PVP", "Racing", "Custom" };
            F1GUI.gameTypes = strArrays2;
        }

        public F1GUI()
        {
        }

        private static string abnormalType(int lol)
        {
            switch (lol)
            {
                case 0:
                {
                    return "Normals";
                }
                case 1:
                {
                    return "Aberrants";
                }
                case 2:
                {
                    return "Jumpers";
                }
                case 3:
                {
                    return "Crawlers";
                }
                case 4:
                {
                    return "Punks";
                }
                default:
                {
                    return "---";
                }
            }
        }

        private void Awake()
        {
            float _width = 1024f / (float)Screen.width;
            float _height = 768f / (float)Screen.height;
            F1GUI.GUIMatrix = new Vector3(_width, _height, 1f);
            F1GUI.Tab.myGUI = this;
        }

        private static string hairtype(string lol)
        {
            int num;
            if (!int.TryParse(lol, out num))
            {
                return string.Empty;
            }
            if (num < 0)
            {
                return "Random";
            }
            return string.Concat("Male ", num);
        }

        private IEnumerator HasSelected(bool NGUISwitch, Action action)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                action();
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private IEnumerator HasSelected(bool NGUISwitch, Action action, Action action2)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                action();
                action2();
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private IEnumerator HasSelected(bool NGUISwitch, Action action, Action action2, Action action3)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                action();
                action2();
                action3();
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private IEnumerator HasSelected(bool NGUISwitch, params Action[] actions)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                Action[] actionArray = actions;
                for (int i = 0; i < (int)actionArray.Length; i++)
                {
                    actionArray[i]();
                }
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private IEnumerator HasSelected<T>(bool NGUISwitch, T parameter, Action<T> action)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                action(parameter);
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private IEnumerator HasSelected<T>(bool NGUISwitch, T parameter, Action<T> action, Action<T> action2)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                action(parameter);
                action2(parameter);
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private IEnumerator HasSelected<T>(bool NGUISwitch, T parameter, Action<T> action, Action<T> action2, Action<T> action3)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                action(parameter);
                action2(parameter);
                action3(parameter);
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private IEnumerator HasSelected<T>(bool NGUISwitch, T parameter, Action<T> action, T parameter2, Action<T> action2)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                action(parameter);
                action2(parameter2);
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private IEnumerator HasSelected<T>(bool NGUISwitch, T parameter, Action<T> action, T parameter2, Action<T> action2, T parameter3, Action<T> action3)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                action(parameter);
                action2(parameter2);
                action3(parameter3);
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private IEnumerator HasSelected<T>(bool NGUISwitch, T parameter, params Action<T>[] actions)
        {
            yield return new WaitForSeconds(0.5f);
            if (F1GUI.keyup)
            {
                if (base.IsInvoking("KeyUP"))
                {
                    base.CancelInvoke("KeyUP");
                }
                F1GUI.keyup = false;
                Action<T>[] actionArray = actions;
                for (int i = 0; i < (int)actionArray.Length; i++)
                {
                    actionArray[i](parameter);
                }
                F1GUI.Grid = false;
                if (NGUISwitch)
                {
                    base.Invoke("TurnOnNGUI", 0.32f);
                }
            }
        }

        private static string HiddenHUDS(int lol)
        {
            switch (lol)
            {
                case -3:
                {
                    return "Max : None";
                }
                case -2:
                {
                    return "UltraHi : Crosshair";
                }
                case -1:
                {
                    return "High : Hit Damage";
                }
                case 0:
                {
                    return "Med : Damage&Style";
                }
                case 1:
                {
                    return "Basic : Chat";
                }
                case 2:
                {
                    return "Low : Gas&Blades";
                }
                case 3:
                {
                    return "XtraLow : TopCenter";
                }
            }
            return "Off : All";
        }

        private static void InputKeyCode(Rect labelpos, Rect buttonpos, string label, int index)
        {
            GUI.Label(labelpos, label);
            if (GUI.Button(buttonpos, (string)FengGameManagerMKII.settingsRC[index]))
            {
                FengGameManagerMKII.settingsRC[index] = "waiting...";
                FengGameManagerMKII.settingsRC[100] = index.ToString();
            }
        }

        private void KeyUP()
        {
            F1GUI.keyup = true;
        }

        protected static IEnumerator LoadImageE(string url = "")
        {
            F1GUI.skinWWW.Second = 0;
            if (F1GUI.skinWWW.First != null)
            {
                F1GUI.skinWWW.First.Dispose();
                F1GUI.skinWWW.First = null;
            }
            if (F1GUI.SkinTex != null)
            {
                Object.Destroy(F1GUI.SkinTex);
            }
            if (F1GUI.resizedSkinTex != null)
            {
                Object.Destroy(F1GUI.resizedSkinTex);
            }
            if (!url.IsNullOrWhiteSpace())
            {
                Pair<WWW, bool> pair = F1GUI.skinWWW;
                WWW wWW = new WWW(url);
                WWW wWW1 = wWW;
                pair.First = wWW;
                yield return wWW1;
                if (F1GUI.skinWWW.First.get_error().IsNullOrEmpty())
                {
                    bool _size = F1GUI.skinWWW.First.size >= 50000000;
                    float _width = (float)F1GUI.skinWWW.First.get_texture().width / (float)F1GUI.skinWWW.First.get_texture().height;
                    int _height = (int)((float)Screen.height * 0.75f * _width);
                    int num = (int)((float)Screen.height * 0.75f);
                    while (_height >= Screen.width)
                    {
                        _height = _height - (int)((float)_height * 0.05f);
                        num = num - (int)((float)num * 0.05f);
                    }
                    F1GUI.SkinTex = new Texture2D(F1GUI.skinWWW.First.get_texture().width, F1GUI.skinWWW.First.get_texture().height, 1, false);
                    F1GUI.resizedSkinTex = new Texture2D(_height, num, 1, _size);
                    F1GUI.skinWWW.First.LoadImageIntoTexture(F1GUI.SkinTex);
                    F1GUI.skinWWW.First.LoadImageIntoTexture(F1GUI.resizedSkinTex);
                    TextureScale.Bilinear(F1GUI.resizedSkinTex, _height, num);
                    if (F1GUI.skinWWW.First.size >= 1000000)
                    {
                        F1GUI.resizedSkinTex.Compress(true);
                    }
                    F1GUI.resizedSkinTex.Apply();
                }
                F1GUI.skinWWW.Second = 1;
            }
        }

        private static string mastertexturetype(int lol)
        {
            if (lol == 0)
            {
                return "High";
            }
            if (lol == 1)
            {
                return "Med";
            }
            return "Low";
        }

        private void OnDisable()
        {
            if (FengGameManagerMKII.settings != null && (int)FengGameManagerMKII.settings.Length > 0)
            {
                if (F1GUI.Grid)
                {
                    F1GUI.Grid = false;
                }
                int num = 0;
                F1GUI.flip = (bool)num;
                FengGameManagerMKII.settings[82] = (bool)num;
                FengGameManagerMKII.settingsSkin[64] = "0";
                if (!IN_GAME_MAIN_CAMERA.isPausing && IN_GAME_MAIN_CAMERA.isTyping)
                {
                    F1GUI.scroll = Vector2.zero;
                    IN_GAME_MAIN_CAMERA.isTyping = false;
                    FengGameManagerMKII.settingsSkin[64] = (FengGameManagerMKII.settingsSkin[64] == "6" ? "0" : "6");
                    return;
                }
                F1GUI.scroll = Vector2.zero;
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
                int num1 = 0;
                IN_GAME_MAIN_CAMERA.isPausing = (bool)num1;
                IN_GAME_MAIN_CAMERA.isTyping = (bool)num1;
                FengGameManagerMKII.settings[22] = (bool)num1;
            }
        }

        private void OnEnable()
        {
            if (FengGameManagerMKII.settings != null && (int)FengGameManagerMKII.settings.Length > 0)
            {
                F1GUI.Grid = false;
                if (!Screen.showCursor)
                {
                    Screen.showCursor = (true);
                }
                if (Screen.lockCursor)
                {
                    Screen.lockCursor = (false);
                }
                if (!IN_GAME_MAIN_CAMERA.isPausing)
                {
                    IN_GAME_MAIN_CAMERA.isPausing = true;
                    IN_GAME_MAIN_CAMERA.isTyping = true;
                }
                if (!(bool)FengGameManagerMKII.settings[82] || !F1GUI.flip)
                {
                    int num = 1;
                    F1GUI.flip = (bool)num;
                    FengGameManagerMKII.settings[82] = (bool)num;
                }
            }
            F1GUI.qualitylevel = PlayerPrefs.GetInt("texQuality", 100);
            F1GUI.qualitylevel = (F1GUI.qualitylevel == 100 ? QualitySettings.get_masterTextureLimit() : F1GUI.qualitylevel);
        }

        public void OnGUI()
        {
            GUI.depth = (-100);
            if (Event.current.type == 4 && Event.current.keyCode == 282 || !IN_GAME_MAIN_CAMERA.isPausing && !FengGameManagerMKII.settingsSkin[64].StartsWith("e"))
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
            if (!FengGameManagerMKII.settingsSkin[64].StartsWith("e") && FengGameManagerMKII.settingsSkin[64] != "6")
            {
                this.SkinView();
                GUI.backgroundColor = (Color.black);
                Rect rect = new Rect(0f, 0f, 247f, 609f);
                GUI.Box(rect, string.Empty);
                GUI.Box(rect, string.Empty);
                GUI.Box(rect, string.Empty);
                GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                GUI.Box(new Rect(5f, 5f, 237f, 555f), string.Empty);
                GUI.Box(new Rect(0f, 0f, 277f, 75f), string.Empty);
                if (GUI.Button(new Rect(247f, 5f, 25f, 65f), "M\nO\nR\nE", "Box"))
                {
                    F1GUI.scroll = Vector2.zero;
                    F1GUI.MORE = !F1GUI.MORE;
                }
                GUILayout.BeginArea(new Rect(10f, 10f, 227f, 65f));
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                GUILayoutOption[] gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Height(30f) };
                if (!GUILayout.Button("General", gUILayoutOptionArray))
                {
                    GUILayoutOption[] gUILayoutOptionArray1 = new GUILayoutOption[] { GUILayout.Height(30f) };
                    if (!GUILayout.Button("Human", gUILayoutOptionArray1))
                    {
                        GUILayoutOption[] gUILayoutOptionArray2 = new GUILayoutOption[] { GUILayout.Height(30f) };
                        if (!GUILayout.Button("Map", gUILayoutOptionArray2))
                        {
                            GUILayoutOption[] gUILayoutOptionArray3 = new GUILayoutOption[] { GUILayout.Height(30f) };
                            if (GUILayout.Button("Titan", gUILayoutOptionArray3))
                            {
                                F1GUI.currentPage = 0;
                                int num = 0;
                                F1GUI.MORE = (bool)num;
                                F1GUI.Grid = (bool)num;
                                F1GUI.scroll = Vector2.zero;
                                FengGameManagerMKII.settingsSkin[64] = "1";
                            }
                        }
                        else
                        {
                            F1GUI.currentPage = 0;
                            int num1 = 0;
                            F1GUI.MORE = (bool)num1;
                            F1GUI.Grid = (bool)num1;
                            F1GUI.scroll = Vector2.zero;
                            FengGameManagerMKII.settingsSkin[64] = "10";
                        }
                    }
                    else
                    {
                        F1GUI.currentPage = 0;
                        int num2 = 0;
                        F1GUI.MORE = (bool)num2;
                        F1GUI.Grid = (bool)num2;
                        F1GUI.scroll = Vector2.zero;
                        FengGameManagerMKII.settingsSkin[64] = "7";
                    }
                }
                else
                {
                    F1GUI.currentPage = 0;
                    int num3 = 0;
                    F1GUI.MORE = (bool)num3;
                    F1GUI.Grid = (bool)num3;
                    F1GUI.scroll = Vector2.zero;
                    FengGameManagerMKII.settingsSkin[64] = "0";
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                GUILayoutOption[] gUILayoutOptionArray4 = new GUILayoutOption[] { GUILayout.Height(30f) };
                if (!GUILayout.Button("Levels", gUILayoutOptionArray4))
                {
                    GUILayoutOption[] gUILayoutOptionArray5 = new GUILayoutOption[] { GUILayout.Height(30f) };
                    if (!GUILayout.Button("Sky", gUILayoutOptionArray5))
                    {
                        GUILayoutOption[] gUILayoutOptionArray6 = new GUILayoutOption[] { GUILayout.Height(30f) };
                        if (!GUILayout.Button("Rebinds", gUILayoutOptionArray6))
                        {
                            GUILayoutOption[] gUILayoutOptionArray7 = new GUILayoutOption[] { GUILayout.Height(30f) };
                            if (GUILayout.Button("UIName", gUILayoutOptionArray7))
                            {
                                F1GUI.currentPage = 0;
                                int num4 = 0;
                                F1GUI.MORE = (bool)num4;
                                F1GUI.Grid = (bool)num4;
                                F1GUI.scroll = Vector2.zero;
                                FengGameManagerMKII.settingsSkin[64] = "-3";
                            }
                        }
                        else
                        {
                            F1GUI.currentPage = 0;
                            int num5 = 0;
                            F1GUI.MORE = (bool)num5;
                            F1GUI.Grid = (bool)num5;
                            F1GUI.scroll = Vector2.zero;
                            FengGameManagerMKII.settingsSkin[64] = "-2";
                        }
                    }
                    else
                    {
                        F1GUI.currentPage = 0;
                        int num6 = 0;
                        F1GUI.MORE = (bool)num6;
                        F1GUI.Grid = (bool)num6;
                        F1GUI.scroll = Vector2.zero;
                        FengGameManagerMKII.settingsSkin[64] = "-1";
                    }
                }
                else
                {
                    F1GUI.currentPage = 0;
                    int num7 = 0;
                    F1GUI.MORE = (bool)num7;
                    F1GUI.Grid = (bool)num7;
                    F1GUI.scroll = Vector2.zero;
                    FengGameManagerMKII.settingsSkin[64] = "2";
                }
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
                if (GUI.Button(new Rect(5f, 585f, 237f, 18f), "Close"))
                {
                    F1GUI.currentPage = 0;
                    int num8 = 0;
                    F1GUI.MORE = (bool)num8;
                    F1GUI.Grid = (bool)num8;
                    this.OnDisable();
                }
                else if (GUI.Button(new Rect(126f, 565f, 116f, 15f), "Load"))
                {
                    FengGameManagerMKII.loadconfig();
                    F1GUI.scroll = Vector2.zero;
                    FengGameManagerMKII.settingsSkin[64] = "5";
                }
                else if (GUI.Button(new Rect(5f, 565f, 116f, 15f), "Save"))
                {
                    F1GUI.Save();
                }
                if (F1GUI.MORE)
                {
                    GUILayout.BeginArea(new Rect(5f, 80f, 237f, 555f));
                    F1GUI.scroll = GUILayout.BeginScrollView(F1GUI.scroll, false, false, new GUILayoutOption[0]);
                    if (GUILayout.Button("Abilities", new GUILayoutOption[0]))
                    {
                        F1GUI.currentPage = 0;
                        FengGameManagerMKII.settingsRC[64] = ((int)FengGameManagerMKII.settingsRC[64] == 11 ? 0 : 11);
                    }
                    GUILayout.EndScrollView();
                    GUILayout.EndArea();
                    GUILayout.BeginArea(new Rect(200f, 0f, (float)Screen.width - 100f, (float)Screen.height));
                    if ((int)FengGameManagerMKII.settingsRC[64] == 11)
                    {
                        F1GUI.tabs.Abilities();
                    }
                    GUILayout.EndArea();
                    return;
                }
                string str = FengGameManagerMKII.settingsSkin[64];
                string str1 = str;
                if (str != null)
                {
                    switch (str1)
                    {
                        case "-3":
                        {
                            F1GUI.tabs.UIName();
                            return;
                        }
                        case "-2":
                        {
                            F1GUI.tabs.Rebinds();
                            return;
                        }
                        case "-1":
                        {
                            F1GUI.tabs.Sky();
                            return;
                        }
                        case "0":
                        {
                            F1GUI.tabs.General();
                            return;
                        }
                        case "1":
                        {
                            F1GUI.tabs.Titan();
                            return;
                        }
                        case "2":
                        {
                            F1GUI.tabs.LevelsForest();
                            return;
                        }
                        case "3":
                        {
                            F1GUI.tabs.LevelsCity();
                            return;
                        }
                        case "4":
                        {
                            F1GUI.tabs.SavedSettings();
                            return;
                        }
                        case "5":
                        {
                            F1GUI.tabs.RevivedSettings();
                            return;
                        }
                        case "7":
                        {
                            F1GUI.tabs.Human();
                            return;
                        }
                        case "9":
                        {
                            F1GUI.tabs.SingleGamemodes();
                            return;
                        }
                        case "10":
                        {
                            F1GUI.tabs.Map();
                            return;
                        }
                        case "11":
                        {
                            F1GUI.tabs.Abilities();
                            return;
                        }
                    }
                }
                return;
            }
        }

        private static void OnGUIKeyCodeRC(int index, int index2, Rect labelpos, Rect togglepos, Rect buttonpos, int time, string label)
        {
            bool flag = (string)FengGameManagerMKII.settingsRC[index] == "1";
            GUI.Label(labelpos, label, "Label");
            bool flag1 = GUI.Toggle(togglepos, flag, "On");
            if (flag != flag1)
            {
                FengGameManagerMKII.settingsRC[index] = (flag1 ? "1" : "0");
            }
            if (GUI.Button(buttonpos, (string)FengGameManagerMKII.settingsRC[index2]))
            {
                FengGameManagerMKII.settingsRC[index2] = "waiting...";
                FengGameManagerMKII.settingsRC[100] = time.ToString();
            }
        }

        private static void OnGUISINGLE(int index, Rect labelpos, Rect togglepos, string label, bool RC)
        {
            bool flag = (RC ? (string)FengGameManagerMKII.settingsRC[index] == "1" : (bool)FengGameManagerMKII.settings[index]);
            GUI.Label(labelpos, label, "Label");
            bool flag1 = GUI.Toggle(togglepos, flag, "On");
            if (flag != flag1)
            {
                if (!RC)
                {
                    FengGameManagerMKII.settings[index] = flag1;
                }
                else
                {
                    FengGameManagerMKII.settingsRC[index] = (flag1 ? "1" : "0");
                }
            }
            F1GUI.heightPos = F1GUI.heightPos + 25f;
        }

        private static void Save()
        {
            if (FengGameManagerMKII.settingsSkin[87] == "1")
            {
                FengGameManagerMKII.settingsSkin[0] = "1";
                FengGameManagerMKII.settingsSkin[88] = "0";
            }
            if (FengGameManagerMKII.settingsSkin[88] == "1")
            {
                FengGameManagerMKII.settingsSkin[0] = "1";
                FengGameManagerMKII.settingsSkin[87] = "0";
            }
            if (FengGameManagerMKII.settingsSkin[87] == "0" && FengGameManagerMKII.settingsSkin[88] == "0")
            {
                FengGameManagerMKII.settingsSkin[0] = "0";
                FengGameManagerMKII.settingsSkin[87] = "0";
                FengGameManagerMKII.settingsSkin[88] = "0";
            }
            F1GUI.scroll = Vector2.zero;
            PlayerPrefs.SetString((string)FengGameManagerMKII.settings[92], (string)FengGameManagerMKII.settings[93]);
            PlayerPrefs.SetInt("gameTypeRS", Convert.ToInt32(FengGameManagerMKII.settingsSkin[93]));
            PlayerPrefs.SetString("tthrowrock", FengGameManagerMKII.settingsSkin[94]);
            PlayerPrefs.SetString("tmeteor", FengGameManagerMKII.settingsSkin[95]);
            PlayerPrefs.SetString("tlaugh", FengGameManagerMKII.settingsSkin[96]);
            bool flag = (bool)FengGameManagerMKII.settings[83];
            PlayerPrefs.SetString("FPScamera", flag.ToString());
            bool flag1 = (bool)FengGameManagerMKII.settings[62];
            PlayerPrefs.SetString("HDSnapShots", flag1.ToString());
            bool flag2 = (bool)FengGameManagerMKII.settings[115];
            PlayerPrefs.SetString("RSSpeedMeter", flag2.ToString());
            PlayerPrefs.SetInt("texQuality", (Application.get_loadedLevel() == 0 ? F1GUI.qualitylevel : QualitySettings.get_masterTextureLimit()));
            PlayerPrefs.SetString("cnumber", (string)FengGameManagerMKII.settingsRC[82]);
            PlayerPrefs.SetString("cmax", (string)FengGameManagerMKII.settingsRC[85]);
            PlayerPrefs.SetString("customGround", (string)FengGameManagerMKII.settingsRC[162]);
            PlayerPrefs.SetString("human", (string)FengGameManagerMKII.settingsRC[0]);
            PlayerPrefs.SetString("titan", (string)FengGameManagerMKII.settingsRC[1]);
            PlayerPrefs.SetString("level", (string)FengGameManagerMKII.settingsRC[2]);
            PlayerPrefs.SetString("humanset1", FengGameManagerMKII.settingsSkin[87]);
            PlayerPrefs.SetString("humanset2", FengGameManagerMKII.settingsSkin[88]);
            PlayerPrefs.SetString("airspecial", FengGameManagerMKII.settingsSkin[89]);
            PlayerPrefs.SetString("groundspecial", FengGameManagerMKII.settingsSkin[90]);
            bool flag3 = (bool)FengGameManagerMKII.settings[25];
            PlayerPrefs.SetString("redCross", flag3.ToString());
            PlayerPrefs.SetFloat("dmgscreenshot", (float)((int)FengGameManagerMKII.settings[32]));
            bool flag4 = (bool)FengGameManagerMKII.settings[33];
            PlayerPrefs.SetString("deathscreenshot", flag4.ToString());
            bool flag5 = (bool)FengGameManagerMKII.settings[39];
            PlayerPrefs.SetString("fog", flag5.ToString());
            PlayerPrefs.SetString("vol", AudioListener.get_volume().ToString());
            PlayerPrefs.SetString("horse", (string)FengGameManagerMKII.settingsRC[3]);
            PlayerPrefs.SetString("hair", (string)FengGameManagerMKII.settingsRC[4]);
            PlayerPrefs.SetString("eye", (string)FengGameManagerMKII.settingsRC[5]);
            PlayerPrefs.SetString("glass", (string)FengGameManagerMKII.settingsRC[6]);
            PlayerPrefs.SetString("face", (string)FengGameManagerMKII.settingsRC[7]);
            PlayerPrefs.SetString("skin", (string)FengGameManagerMKII.settingsRC[8]);
            PlayerPrefs.SetString("costume", (string)FengGameManagerMKII.settingsRC[9]);
            PlayerPrefs.SetString("logo", (string)FengGameManagerMKII.settingsRC[10]);
            PlayerPrefs.SetString("bladel", (string)FengGameManagerMKII.settingsRC[11]);
            PlayerPrefs.SetString("blader", (string)FengGameManagerMKII.settingsRC[12]);
            PlayerPrefs.SetString("gas", (string)FengGameManagerMKII.settingsRC[13]);
            PlayerPrefs.SetString("hoodie", (string)FengGameManagerMKII.settingsRC[14]);
            PlayerPrefs.SetString("gasenable", (string)FengGameManagerMKII.settingsRC[15]);
            PlayerPrefs.SetString("titantype1", (string)FengGameManagerMKII.settingsRC[16]);
            PlayerPrefs.SetString("titantype2", (string)FengGameManagerMKII.settingsRC[17]);
            PlayerPrefs.SetString("titantype3", (string)FengGameManagerMKII.settingsRC[18]);
            PlayerPrefs.SetString("titantype4", (string)FengGameManagerMKII.settingsRC[19]);
            PlayerPrefs.SetString("titantype5", (string)FengGameManagerMKII.settingsRC[20]);
            PlayerPrefs.SetString("titanhair1", (string)FengGameManagerMKII.settingsRC[21]);
            PlayerPrefs.SetString("titanhair2", (string)FengGameManagerMKII.settingsRC[22]);
            PlayerPrefs.SetString("titanhair3", (string)FengGameManagerMKII.settingsRC[23]);
            PlayerPrefs.SetString("titanhair4", (string)FengGameManagerMKII.settingsRC[24]);
            PlayerPrefs.SetString("titanhair5", (string)FengGameManagerMKII.settingsRC[25]);
            PlayerPrefs.SetString("titaneye1", (string)FengGameManagerMKII.settingsRC[26]);
            PlayerPrefs.SetString("titaneye2", (string)FengGameManagerMKII.settingsRC[27]);
            PlayerPrefs.SetString("titaneye3", (string)FengGameManagerMKII.settingsRC[28]);
            PlayerPrefs.SetString("titaneye4", (string)FengGameManagerMKII.settingsRC[29]);
            PlayerPrefs.SetString("titaneye5", (string)FengGameManagerMKII.settingsRC[30]);
            PlayerPrefs.SetString("titanR", (string)FengGameManagerMKII.settingsRC[32]);
            PlayerPrefs.SetString("tree1", (string)FengGameManagerMKII.settingsRC[33]);
            PlayerPrefs.SetString("tree2", (string)FengGameManagerMKII.settingsRC[34]);
            PlayerPrefs.SetString("tree3", (string)FengGameManagerMKII.settingsRC[35]);
            PlayerPrefs.SetString("tree4", (string)FengGameManagerMKII.settingsRC[36]);
            PlayerPrefs.SetString("tree5", (string)FengGameManagerMKII.settingsRC[37]);
            PlayerPrefs.SetString("tree6", (string)FengGameManagerMKII.settingsRC[38]);
            PlayerPrefs.SetString("tree7", (string)FengGameManagerMKII.settingsRC[39]);
            PlayerPrefs.SetString("tree8", (string)FengGameManagerMKII.settingsRC[40]);
            PlayerPrefs.SetString("leaf1", (string)FengGameManagerMKII.settingsRC[41]);
            PlayerPrefs.SetString("leaf2", (string)FengGameManagerMKII.settingsRC[42]);
            PlayerPrefs.SetString("leaf3", (string)FengGameManagerMKII.settingsRC[43]);
            PlayerPrefs.SetString("leaf4", (string)FengGameManagerMKII.settingsRC[44]);
            PlayerPrefs.SetString("leaf5", (string)FengGameManagerMKII.settingsRC[45]);
            PlayerPrefs.SetString("leaf6", (string)FengGameManagerMKII.settingsRC[46]);
            PlayerPrefs.SetString("leaf7", (string)FengGameManagerMKII.settingsRC[47]);
            PlayerPrefs.SetString("leaf8", (string)FengGameManagerMKII.settingsRC[48]);
            PlayerPrefs.SetString("forestG", (string)FengGameManagerMKII.settingsRC[49]);
            PlayerPrefs.SetString("forestR", (string)FengGameManagerMKII.settingsRC[50]);
            PlayerPrefs.SetString("house1", (string)FengGameManagerMKII.settingsRC[51]);
            PlayerPrefs.SetString("house2", (string)FengGameManagerMKII.settingsRC[52]);
            PlayerPrefs.SetString("house3", (string)FengGameManagerMKII.settingsRC[53]);
            PlayerPrefs.SetString("house4", (string)FengGameManagerMKII.settingsRC[54]);
            PlayerPrefs.SetString("house5", (string)FengGameManagerMKII.settingsRC[55]);
            PlayerPrefs.SetString("house6", (string)FengGameManagerMKII.settingsRC[56]);
            PlayerPrefs.SetString("house7", (string)FengGameManagerMKII.settingsRC[57]);
            PlayerPrefs.SetString("house8", (string)FengGameManagerMKII.settingsRC[58]);
            PlayerPrefs.SetString("cityG", (string)FengGameManagerMKII.settingsRC[59]);
            PlayerPrefs.SetString("cityW", (string)FengGameManagerMKII.settingsRC[60]);
            PlayerPrefs.SetString("cityH", (string)FengGameManagerMKII.settingsRC[61]);
            PlayerPrefs.SetString("skinQ", (string)FengGameManagerMKII.settingsRC[62]);
            PlayerPrefs.SetString("skinQL", (string)FengGameManagerMKII.settingsRC[63]);
            PlayerPrefs.SetString("eren", (string)FengGameManagerMKII.settingsRC[65]);
            PlayerPrefs.SetString("annie", (string)FengGameManagerMKII.settingsRC[66]);
            PlayerPrefs.SetString("colossal", (string)FengGameManagerMKII.settingsRC[67]);
            PlayerPrefs.SetString("titanbody1", (string)FengGameManagerMKII.settingsRC[86]);
            PlayerPrefs.SetString("titanbody2", (string)FengGameManagerMKII.settingsRC[87]);
            PlayerPrefs.SetString("titanbody3", (string)FengGameManagerMKII.settingsRC[88]);
            PlayerPrefs.SetString("titanbody4", (string)FengGameManagerMKII.settingsRC[89]);
            PlayerPrefs.SetString("titanbody5", (string)FengGameManagerMKII.settingsRC[90]);
            PlayerPrefs.SetString("customlevel", (string)FengGameManagerMKII.settingsRC[91]);
            PlayerPrefs.SetString("traildisable", (string)FengGameManagerMKII.settingsRC[92]);
            PlayerPrefs.SetString("wind", (string)FengGameManagerMKII.settingsRC[93]);
            PlayerPrefs.SetString("trailskin", (string)FengGameManagerMKII.settingsRC[94]);
            PlayerPrefs.SetString("snapshot", (string)FengGameManagerMKII.settingsRC[95]);
            PlayerPrefs.SetString("trailskin2", (string)FengGameManagerMKII.settingsRC[96]);
            PlayerPrefs.SetString("reel", (string)FengGameManagerMKII.settingsRC[97]);
            PlayerPrefs.SetString("reelin", (string)FengGameManagerMKII.settingsRC[98]);
            PlayerPrefs.SetString("reelout", (string)FengGameManagerMKII.settingsRC[99]);
            PlayerPrefs.SetString("vol", AudioListener.get_volume().ToString());
            PlayerPrefs.SetString("tforward", (string)FengGameManagerMKII.settingsRC[101]);
            PlayerPrefs.SetString("tback", (string)FengGameManagerMKII.settingsRC[102]);
            PlayerPrefs.SetString("tleft", (string)FengGameManagerMKII.settingsRC[103]);
            PlayerPrefs.SetString("tright", (string)FengGameManagerMKII.settingsRC[104]);
            PlayerPrefs.SetString("twalk", (string)FengGameManagerMKII.settingsRC[105]);
            PlayerPrefs.SetString("tjump", (string)FengGameManagerMKII.settingsRC[106]);
            PlayerPrefs.SetString("tpunch", (string)FengGameManagerMKII.settingsRC[107]);
            PlayerPrefs.SetString("tslam", (string)FengGameManagerMKII.settingsRC[108]);
            PlayerPrefs.SetString("tgrabfront", (string)FengGameManagerMKII.settingsRC[109]);
            PlayerPrefs.SetString("tgrabback", (string)FengGameManagerMKII.settingsRC[110]);
            PlayerPrefs.SetString("tgrabnape", (string)FengGameManagerMKII.settingsRC[111]);
            PlayerPrefs.SetString("tantiae", (string)FengGameManagerMKII.settingsRC[112]);
            PlayerPrefs.SetString("tbite", (string)FengGameManagerMKII.settingsRC[113]);
            PlayerPrefs.SetString("tcover", (string)FengGameManagerMKII.settingsRC[114]);
            PlayerPrefs.SetString("tsit", (string)FengGameManagerMKII.settingsRC[115]);
            PlayerPrefs.SetString("humangui", (string)FengGameManagerMKII.settingsRC[133]);
            PlayerPrefs.SetString("reel2", (string)FengGameManagerMKII.settingsRC[116]);
            PlayerPrefs.SetString("horse2", (string)FengGameManagerMKII.settingsRC[134]);
            PlayerPrefs.SetString("hair2", (string)FengGameManagerMKII.settingsRC[135]);
            PlayerPrefs.SetString("eye2", (string)FengGameManagerMKII.settingsRC[136]);
            PlayerPrefs.SetString("glass2", (string)FengGameManagerMKII.settingsRC[137]);
            PlayerPrefs.SetString("face2", (string)FengGameManagerMKII.settingsRC[138]);
            PlayerPrefs.SetString("skin2", (string)FengGameManagerMKII.settingsRC[139]);
            PlayerPrefs.SetString("costume2", (string)FengGameManagerMKII.settingsRC[140]);
            PlayerPrefs.SetString("logo2", (string)FengGameManagerMKII.settingsRC[141]);
            PlayerPrefs.SetString("bladel2", (string)FengGameManagerMKII.settingsRC[142]);
            PlayerPrefs.SetString("blader2", (string)FengGameManagerMKII.settingsRC[143]);
            PlayerPrefs.SetString("gas2", (string)FengGameManagerMKII.settingsRC[144]);
            PlayerPrefs.SetString("hoodie2", (string)FengGameManagerMKII.settingsRC[145]);
            PlayerPrefs.SetString("trail2", (string)FengGameManagerMKII.settingsRC[146]);
            PlayerPrefs.SetString("horse3", (string)FengGameManagerMKII.settingsRC[147]);
            PlayerPrefs.SetString("hair3", (string)FengGameManagerMKII.settingsRC[148]);
            PlayerPrefs.SetString("eye3", (string)FengGameManagerMKII.settingsRC[149]);
            PlayerPrefs.SetString("glass3", (string)FengGameManagerMKII.settingsRC[150]);
            PlayerPrefs.SetString("face3", (string)FengGameManagerMKII.settingsRC[151]);
            PlayerPrefs.SetString("skin3", (string)FengGameManagerMKII.settingsRC[152]);
            PlayerPrefs.SetString("costume3", (string)FengGameManagerMKII.settingsRC[153]);
            PlayerPrefs.SetString("logo3", (string)FengGameManagerMKII.settingsRC[154]);
            PlayerPrefs.SetString("bladel3", (string)FengGameManagerMKII.settingsRC[155]);
            PlayerPrefs.SetString("blader3", (string)FengGameManagerMKII.settingsRC[156]);
            PlayerPrefs.SetString("gas3", (string)FengGameManagerMKII.settingsRC[157]);
            PlayerPrefs.SetString("hoodie3", (string)FengGameManagerMKII.settingsRC[158]);
            PlayerPrefs.SetString("trail3", (string)FengGameManagerMKII.settingsRC[159]);
            PlayerPrefs.SetString("script", FengGameManagerMKII.currentScript);
            PlayerPrefs.SetString("reel", (string)FengGameManagerMKII.settingsRC[97]);
            PlayerPrefs.SetString("reel2", (string)FengGameManagerMKII.settingsRC[116]);
            PlayerPrefs.SetString("reelin", (string)FengGameManagerMKII.settingsRC[98]);
            PlayerPrefs.SetString("reelout", (string)FengGameManagerMKII.settingsRC[99]);
            bool flag6 = (bool)FengGameManagerMKII.settings[43];
            PlayerPrefs.SetString("bodylean", flag6.ToString());
            bool flag7 = (bool)FengGameManagerMKII.settings[44];
            PlayerPrefs.SetString("autoaimGuns", flag7.ToString());
            bool flag8 = (bool)FengGameManagerMKII.settings[45];
            PlayerPrefs.SetString("weaponTrail", flag8.ToString());
            PlayerPrefs.SetString("forestskyfront", (string)FengGameManagerMKII.settingsRC[163]);
            PlayerPrefs.SetString("forestskyback", (string)FengGameManagerMKII.settingsRC[164]);
            PlayerPrefs.SetString("forestskyleft", (string)FengGameManagerMKII.settingsRC[165]);
            PlayerPrefs.SetString("forestskyright", (string)FengGameManagerMKII.settingsRC[166]);
            PlayerPrefs.SetString("forestskyup", (string)FengGameManagerMKII.settingsRC[167]);
            PlayerPrefs.SetString("forestskydown", (string)FengGameManagerMKII.settingsRC[168]);
            PlayerPrefs.SetString("cityskyfront", (string)FengGameManagerMKII.settingsRC[169]);
            PlayerPrefs.SetString("cityskyback", (string)FengGameManagerMKII.settingsRC[170]);
            PlayerPrefs.SetString("cityskyleft", (string)FengGameManagerMKII.settingsRC[171]);
            PlayerPrefs.SetString("cityskyright", (string)FengGameManagerMKII.settingsRC[172]);
            PlayerPrefs.SetString("cityskyup", (string)FengGameManagerMKII.settingsRC[173]);
            PlayerPrefs.SetString("cityskydown", (string)FengGameManagerMKII.settingsRC[174]);
            PlayerPrefs.SetString("customskyfront", (string)FengGameManagerMKII.settingsRC[175]);
            PlayerPrefs.SetString("customskyback", (string)FengGameManagerMKII.settingsRC[176]);
            PlayerPrefs.SetString("customskyleft", (string)FengGameManagerMKII.settingsRC[177]);
            PlayerPrefs.SetString("customskyright", (string)FengGameManagerMKII.settingsRC[178]);
            PlayerPrefs.SetString("customskyup", (string)FengGameManagerMKII.settingsRC[179]);
            PlayerPrefs.SetString("customskydown", (string)FengGameManagerMKII.settingsRC[180]);
            PlayerPrefs.SetString("dashenable", (string)FengGameManagerMKII.settingsRC[181]);
            PlayerPrefs.SetString("dashkey", (string)FengGameManagerMKII.settingsRC[182]);
            PlayerPrefs.SetInt("speedometer", (int)FengGameManagerMKII.settingsRC[189]);
            PlayerPrefs.SetInt("bombMode", (int)FengGameManagerMKII.settingsRC[192]);
            PlayerPrefs.SetInt("teamMode", (int)FengGameManagerMKII.settingsRC[193]);
            PlayerPrefs.SetInt("rockThrow", (int)FengGameManagerMKII.settingsRC[194]);
            PlayerPrefs.SetInt("explodeModeOn", (int)FengGameManagerMKII.settingsRC[195]);
            PlayerPrefs.SetString("explodeModeNum", (string)FengGameManagerMKII.settingsRC[196]);
            PlayerPrefs.SetInt("healthMode", (int)FengGameManagerMKII.settingsRC[197]);
            PlayerPrefs.SetString("healthLower", (string)FengGameManagerMKII.settingsRC[198]);
            PlayerPrefs.SetString("healthUpper", (string)FengGameManagerMKII.settingsRC[199]);
            PlayerPrefs.SetInt("infectionModeOn", (int)FengGameManagerMKII.settingsRC[200]);
            PlayerPrefs.SetString("infectionModeNum", (string)FengGameManagerMKII.settingsRC[201]);
            PlayerPrefs.SetInt("banEren", (int)FengGameManagerMKII.settingsRC[202]);
            PlayerPrefs.SetInt("moreTitanOn", (int)FengGameManagerMKII.settingsRC[203]);
            PlayerPrefs.SetString("moreTitanNum", (string)FengGameManagerMKII.settingsRC[204]);
            PlayerPrefs.SetInt("damageModeOn", (int)FengGameManagerMKII.settingsRC[205]);
            PlayerPrefs.SetString("damageModeNum", (string)FengGameManagerMKII.settingsRC[206]);
            PlayerPrefs.SetInt("sizeMode", (int)FengGameManagerMKII.settingsRC[207]);
            PlayerPrefs.SetString("sizeLower", (string)FengGameManagerMKII.settingsRC[208]);
            PlayerPrefs.SetString("sizeUpper", (string)FengGameManagerMKII.settingsRC[209]);
            PlayerPrefs.SetInt("spawnModeOn", (int)FengGameManagerMKII.settingsRC[210]);
            PlayerPrefs.SetString("nRate", (string)FengGameManagerMKII.settingsRC[211]);
            PlayerPrefs.SetString("aRate", (string)FengGameManagerMKII.settingsRC[212]);
            PlayerPrefs.SetString("jRate", (string)FengGameManagerMKII.settingsRC[213]);
            PlayerPrefs.SetString("cRate", (string)FengGameManagerMKII.settingsRC[214]);
            PlayerPrefs.SetString("pRate", (string)FengGameManagerMKII.settingsRC[215]);
            PlayerPrefs.SetInt("horseMode", (int)FengGameManagerMKII.settingsRC[216]);
            PlayerPrefs.SetInt("waveModeOn", (int)FengGameManagerMKII.settingsRC[217]);
            PlayerPrefs.SetString("waveModeNum", (string)FengGameManagerMKII.settingsRC[218]);
            PlayerPrefs.SetInt("friendlyMode", (int)FengGameManagerMKII.settingsRC[219]);
            PlayerPrefs.SetInt("pvpMode", (int)FengGameManagerMKII.settingsRC[220]);
            PlayerPrefs.SetInt("maxWaveOn", (int)FengGameManagerMKII.settingsRC[221]);
            PlayerPrefs.SetString("maxWaveNum", (string)FengGameManagerMKII.settingsRC[222]);
            PlayerPrefs.SetInt("endlessModeOn", (int)FengGameManagerMKII.settingsRC[223]);
            PlayerPrefs.SetString("endlessModeNum", (string)FengGameManagerMKII.settingsRC[224]);
            PlayerPrefs.SetString("motd", (string)FengGameManagerMKII.settingsRC[225]);
            PlayerPrefs.SetInt("pointModeOn", (int)FengGameManagerMKII.settingsRC[226]);
            PlayerPrefs.SetString("pointModeNum", (string)FengGameManagerMKII.settingsRC[227]);
            PlayerPrefs.SetInt("ahssReload", (int)FengGameManagerMKII.settingsRC[228]);
            PlayerPrefs.SetInt("punkWaves", (int)FengGameManagerMKII.settingsRC[229]);
            PlayerPrefs.SetInt("mapOn", (int)FengGameManagerMKII.settingsRC[231]);
            PlayerPrefs.SetString("mapMaximize", (string)FengGameManagerMKII.settingsRC[232]);
            PlayerPrefs.SetString("mapToggle", (string)FengGameManagerMKII.settingsRC[233]);
            PlayerPrefs.SetString("mapReset", (string)FengGameManagerMKII.settingsRC[234]);
            PlayerPrefs.SetInt("globalDisableMinimap", (int)FengGameManagerMKII.settingsRC[235]);
            PlayerPrefs.SetString("chatRebind", (string)FengGameManagerMKII.settingsRC[236]);
            PlayerPrefs.SetString("hforward", (string)FengGameManagerMKII.settingsRC[237]);
            PlayerPrefs.SetString("hback", (string)FengGameManagerMKII.settingsRC[238]);
            PlayerPrefs.SetString("hleft", (string)FengGameManagerMKII.settingsRC[239]);
            PlayerPrefs.SetString("hright", (string)FengGameManagerMKII.settingsRC[240]);
            PlayerPrefs.SetString("hwalk", (string)FengGameManagerMKII.settingsRC[241]);
            PlayerPrefs.SetString("hjump", (string)FengGameManagerMKII.settingsRC[242]);
            PlayerPrefs.SetString("hmount", (string)FengGameManagerMKII.settingsRC[243]);
            PlayerPrefs.SetInt("chatfeed", (int)FengGameManagerMKII.settingsRC[244]);
            PlayerPrefs.SetFloat("bombR", (float)FengGameManagerMKII.settingsRC[246]);
            PlayerPrefs.SetFloat("bombG", (float)FengGameManagerMKII.settingsRC[247]);
            PlayerPrefs.SetFloat("bombB", (float)FengGameManagerMKII.settingsRC[248]);
            PlayerPrefs.SetFloat("bombA", (float)FengGameManagerMKII.settingsRC[249]);
            PlayerPrefs.SetInt("bombRadius", (int)FengGameManagerMKII.settingsRC[250]);
            PlayerPrefs.SetInt("bombRange", (int)FengGameManagerMKII.settingsRC[251]);
            PlayerPrefs.SetInt("bombSpeed", (int)FengGameManagerMKII.settingsRC[252]);
            PlayerPrefs.SetInt("bombCD", (int)FengGameManagerMKII.settingsRC[253]);
            PlayerPrefs.SetString("cannonUp", (string)FengGameManagerMKII.settingsRC[254]);
            PlayerPrefs.SetString("cannonDown", (string)FengGameManagerMKII.settingsRC[255]);
            PlayerPrefs.SetString("cannonLeft", (string)FengGameManagerMKII.settingsRC[256]);
            PlayerPrefs.SetString("cannonRight", (string)FengGameManagerMKII.settingsRC[257]);
            PlayerPrefs.SetString("cannonFire", (string)FengGameManagerMKII.settingsRC[258]);
            PlayerPrefs.SetString("cannonMount", (string)FengGameManagerMKII.settingsRC[259]);
            PlayerPrefs.SetString("cannonSlow", (string)FengGameManagerMKII.settingsRC[260]);
            PlayerPrefs.SetInt("deadlyCannon", (int)FengGameManagerMKII.settingsRC[261]);
            bool flag9 = (bool)FengGameManagerMKII.settings[48];
            PlayerPrefs.SetString("oldtrail", flag9.ToString());
            FengGameManagerMKII.settingsSkin[64] = "4";
            FengGameManagerMKII.settings[95] = PlayerPrefs.GetString("Faded", "None");
            FengGameManagerMKII.settings[96] = PlayerPrefs.GetString("Linear", "None");
            FengGameManagerMKII.settings[97] = PlayerPrefs.GetString("Rebound", "None");
            FengGameManagerMKII.EncodeAnimation((string)FengGameManagerMKII.settings[95]);
            FengGameManagerMKII.EncodeAnimation((string)FengGameManagerMKII.settings[96]);
            FengGameManagerMKII.EncodeAnimation((string)FengGameManagerMKII.settings[97]);
            FengGameManagerMKII.settings[84] = PlayerPrefs.GetString("AnimatedName", "None");
            if (PhotonNetwork.connectionStateDetailed == PeerStates.Joined)
            {
                FengGameManagerMKII.MKII.StartNameAnim((string)FengGameManagerMKII.settings[84] != "None");
            }
        }

        private static void SelectionGrid(int id)
        {
            int num = 0;
            if (FengGameManagerMKII.settingsSkin[91] == "2")
            {
                num = 0;
                while (num < (int)F1GUI.characters.Length)
                {
                    if (!IN_GAME_MAIN_CAMERA.singleCharacter.IsNullOrEmpty())
                    {
                        if (IN_GAME_MAIN_CAMERA.singleCharacter == F1GUI.characters[num])
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
                Rect rect = new Rect(10f, 160f, 228f, 245f);
                string[] strArrays = F1GUI.characters;
                GUIStyle gUIStyle = new GUIStyle("Button");
                gUIStyle.set_wordWrap(true);
                int num1 = GUI.SelectionGrid(rect, num, strArrays, 2, gUIStyle);
                GUI.backgroundColor = (new Color(0f, 0f, 0f, 0f));
                if (num != num1)
                {
                    IN_GAME_MAIN_CAMERA.singleCharacter = F1GUI.characters[num1];
                    FengGameManagerMKII.settingsSkin[91] = "0";
                    return;
                }
            }
            else if (FengGameManagerMKII.settingsSkin[91] == "1")
            {
                num = 0;
                while (num < (int)F1GUI.specials.Length)
                {
                    if (!FengGameManagerMKII.settingsSkin[89].IsNullOrEmpty())
                    {
                        if (FengGameManagerMKII.settingsSkin[89] == F1GUI.specials[num])
                        {
                            break;
                        }
                        num++;
                    }
                    else
                    {
                        num = 0;
                        break;
                    }
                }
                Rect rect1 = new Rect(10f, F1GUI.heightPos + 25f, 230f, 165f);
                string[] strArrays1 = F1GUI.specials;
                GUIStyle gUIStyle1 = new GUIStyle("Button");
                gUIStyle1.set_wordWrap(true);
                gUIStyle1.set_alignment(4);
                int num2 = GUI.SelectionGrid(rect1, num, strArrays1, 2, gUIStyle1);
                GUI.backgroundColor = (Color.get_clear());
                if (num != num2)
                {
                    FengGameManagerMKII.settingsSkin[89] = F1GUI.specials[num2];
                    FengGameManagerMKII.settingsSkin[91] = "0";
                    return;
                }
            }
            else if (FengGameManagerMKII.settingsSkin[92] == "1")
            {
                num = 0;
                while (num < (int)F1GUI.specials.Length)
                {
                    if (!FengGameManagerMKII.settingsSkin[90].IsNullOrEmpty())
                    {
                        if (FengGameManagerMKII.settingsSkin[90] == F1GUI.specials[num])
                        {
                            break;
                        }
                        num++;
                    }
                    else
                    {
                        num = 0;
                        break;
                    }
                }
                Rect rect2 = new Rect(10f, F1GUI.heightPos, 230f, 165f);
                string[] strArrays2 = F1GUI.specials;
                GUIStyle gUIStyle2 = new GUIStyle("Button");
                gUIStyle2.set_wordWrap(true);
                gUIStyle2.set_alignment(4);
                int num3 = GUI.SelectionGrid(rect2, num, strArrays2, 2, gUIStyle2);
                GUI.backgroundColor = (Color.get_clear());
                if (num != num3)
                {
                    FengGameManagerMKII.settingsSkin[90] = F1GUI.specials[num3];
                    FengGameManagerMKII.settingsSkin[92] = "0";
                }
            }
        }

        private static string singledaylight(int lol)
        {
            switch (lol)
            {
                case 1:
                {
                    return "Dawn";
                }
                case 2:
                {
                    return "Night";
                }
                case 3:
                {
                    return "NightVision";
                }
                case 4:
                {
                    return "Limbo";
                }
                case 5:
                {
                    return "Sketchy";
                }
                case 6:
                {
                    return "Oppose";
                }
            }
            return "Day";
        }

        private static string singledifficulty(int lol)
        {
            switch (lol)
            {
                case -1:
                {
                    return "Training";
                }
                case 0:
                {
                    return "Normal";
                }
                case 1:
                {
                    return "Hard";
                }
            }
            return "Abnormal";
        }

        private void SkinView()
        {

Current member / type: System.Void RedSkies.F1GUI::SkinView()
File path: C:\Users\Mark\Downloads\Assembly-CSharp.dll

Product version: 2014.1.225.0
Exception in: System.Void SkinView()

Object reference not set to an instance of an object.
at ..( , Int32 , & , Int32& ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatterns\ObjectInitialisationPattern.cs:line 78
at ..( , Int32& , & , Int32& ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatterns\BaseInitialisationPattern.cs:line 33
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 60
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 363
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 67
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..Visit[,]( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 288
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 319
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 339
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 36
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 363
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 67
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..Visit[,]( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 288
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 319
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 339
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 36
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 363
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 67
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..Visit[,]( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 288
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 319
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 339
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 36
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 363
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 67
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..Visit[,]( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 288
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 319
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 339
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 36
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 363
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 67
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..Visit[,]( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 288
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 319
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 339
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 36
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ,  ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 30
at ..(MethodBody , ILanguage ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 83
at ..( , ILanguage , MethodBody , & ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\Extensions.cs:line 99
at ..(MethodBody , ILanguage , & ,  ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\Extensions.cs:line 62
at ..(ILanguage , MethodDefinition ,  ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 116

========================================================================
Please update to the latest version of JustDecompile and then try again.
Get latest version.

        }

        private static void Toggle(Rect labelpos, Rect togglepos, string label, Func<bool> on, Action<bool> toggle)
        {
            bool flag = on();
            GUI.Label(labelpos, label);
            bool flag1 = GUI.Toggle(togglepos, flag, "On");
            if (flag != flag1)
            {
                toggle(flag1);
            }
            F1GUI.heightPos = F1GUI.heightPos + 25f;
        }

        private static void ToggleLayout(string label, Func<bool> on, Action<bool> toggle, Vector2? labelWxH = null, Vector2? toggleWxH = null)
        {
            float value;
            float single;
            bool flag;
            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
            bool flag1 = on();
            if (!labelWxH.HasValue)
            {
                GUILayout.Label(label, new GUILayoutOption[0]);
            }
            else
            {
                value = labelWxH.Value.x;
                single = labelWxH.Value.y;
                if (value > 0f && single > 0f)
                {
                    GUILayoutOption[] gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(value), GUILayout.Height(single) };
                    GUILayout.Label(label, gUILayoutOptionArray);
                }
                else if (value > 0f)
                {
                    GUILayoutOption[] gUILayoutOptionArray1 = new GUILayoutOption[] { GUILayout.Width(value) };
                    GUILayout.Label(label, gUILayoutOptionArray1);
                }
                else if (single <= 0f)
                {
                    GUILayout.Label(label, new GUILayoutOption[0]);
                }
                else
                {
                    GUILayoutOption[] gUILayoutOptionArray2 = new GUILayoutOption[] { GUILayout.Height(single) };
                    GUILayout.Label(label, gUILayoutOptionArray2);
                }
            }
            if (!toggleWxH.HasValue)
            {
                flag = GUILayout.Toggle(flag1, "On", new GUILayoutOption[0]);
            }
            else
            {
                value = labelWxH.Value.x;
                single = labelWxH.Value.y;
                if (value > 0f && single > 0f)
                {
                    GUILayoutOption[] gUILayoutOptionArray3 = new GUILayoutOption[] { GUILayout.Width(value), GUILayout.Height(single) };
                    flag = GUILayout.Toggle(flag1, "On", gUILayoutOptionArray3);
                }
                else if (value > 0f)
                {
                    GUILayoutOption[] gUILayoutOptionArray4 = new GUILayoutOption[] { GUILayout.Width(value) };
                    flag = GUILayout.Toggle(flag1, "On", gUILayoutOptionArray4);
                }
                else if (single <= 0f)
                {
                    flag = GUILayout.Toggle(flag1, "On", new GUILayoutOption[0]);
                }
                else
                {
                    GUILayoutOption[] gUILayoutOptionArray5 = new GUILayoutOption[] { GUILayout.Height(single) };
                    flag = GUILayout.Toggle(flag1, "On", gUILayoutOptionArray5);
                }
            }
            if (flag1 != flag)
            {
                toggle(flag);
            }
            GUILayout.EndHorizontal();
        }

        private static void ToggleLayout(string label, Func<bool> on, Action<bool> toggle, GUIStyle labelStyle, GUIStyle toggleStyle, Vector2? labelWxH = null, Vector2? toggleWxH = null)
        {
            float value;
            float single;
            bool flag;
            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
            bool flag1 = on();
            if (!labelWxH.HasValue)
            {
                GUILayout.Label(label, labelStyle, new GUILayoutOption[0]);
            }
            else
            {
                value = labelWxH.Value.x;
                single = labelWxH.Value.y;
                if (value > 0f && single > 0f)
                {
                    GUILayoutOption[] gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(value), GUILayout.Height(single) };
                    GUILayout.Label(label, gUILayoutOptionArray);
                }
                else if (value > 0f)
                {
                    GUILayoutOption[] gUILayoutOptionArray1 = new GUILayoutOption[] { GUILayout.Width(value) };
                    GUILayout.Label(label, gUILayoutOptionArray1);
                }
                else if (single <= 0f)
                {
                    GUILayout.Label(label, new GUILayoutOption[0]);
                }
                else
                {
                    GUILayoutOption[] gUILayoutOptionArray2 = new GUILayoutOption[] { GUILayout.Height(single) };
                    GUILayout.Label(label, gUILayoutOptionArray2);
                }
            }
            if (!toggleWxH.HasValue)
            {
                flag = GUILayout.Toggle(flag1, "On", toggleStyle, new GUILayoutOption[0]);
            }
            else
            {
                value = labelWxH.Value.x;
                single = labelWxH.Value.y;
                if (value > 0f && single > 0f)
                {
                    GUILayoutOption[] gUILayoutOptionArray3 = new GUILayoutOption[] { GUILayout.Width(value), GUILayout.Height(single) };
                    flag = GUILayout.Toggle(flag1, "On", gUILayoutOptionArray3);
                }
                else if (value > 0f)
                {
                    GUILayoutOption[] gUILayoutOptionArray4 = new GUILayoutOption[] { GUILayout.Width(value) };
                    flag = GUILayout.Toggle(flag1, "On", gUILayoutOptionArray4);
                }
                else if (single <= 0f)
                {
                    flag = GUILayout.Toggle(flag1, "On", new GUILayoutOption[0]);
                }
                else
                {
                    GUILayoutOption[] gUILayoutOptionArray5 = new GUILayoutOption[] { GUILayout.Height(single) };
                    flag = GUILayout.Toggle(flag1, "On", gUILayoutOptionArray5);
                }
            }
            if (flag1 != flag)
            {
                toggle(flag);
            }
            GUILayout.EndHorizontal();
        }

        private void TurnOffNGUI()
        {
            int num = 1;
            F1GUI.flip = (bool)num;
            FengGameManagerMKII.settings[82] = (bool)num;
        }

        private void TurnOnNGUI()
        {
            int num = 0;
            F1GUI.flip = (bool)num;
            FengGameManagerMKII.settings[82] = (bool)num;
            base.StopAllCoroutines();
        }

        private class Tab
        {
            protected internal static F1GUI myGUI;

            public Tab()
            {
            }

            protected internal void Abilities()
            {
                GUI.backgroundColor = (new Color(0.08f, 0.3f, 0.4f, 1f));
                float _width = (float)Screen.width / 2f - 350f;
                float _height = (float)Screen.height / 2f - 250f;
                GUI.DrawTexture(new Rect(_width + 2f, _height + 2f, 696f, 496f), GUITexture.Blue);
                GUI.Box(new Rect(_width, _height, 700f, 500f), string.Empty);
                GUILayout.BeginArea(new Rect(_width, _height, 700f, 500f));
                GUI.Label(new Rect(150f, 80f, 185f, 22f), "Bomb Mode", "Label");
                GUI.Label(new Rect(80f, 110f, 80f, 22f), "Color:", "Label");
                Texture2D texture2D = new Texture2D(1, 1, 5, false);
                texture2D.SetPixel(0, 0, new Color((float)FengGameManagerMKII.settingsRC[246], (float)FengGameManagerMKII.settingsRC[247], (float)FengGameManagerMKII.settingsRC[248], (float)FengGameManagerMKII.settingsRC[249]));
                texture2D.Apply();
                GUI.DrawTexture(new Rect(120f, 113f, 40f, 15f), texture2D, 0);
                Object.Destroy(texture2D);
                GUI.Label(new Rect(72f, 135f, 20f, 22f), "R:", "Label");
                GUI.Label(new Rect(72f, 160f, 20f, 22f), "G:", "Label");
                GUI.Label(new Rect(72f, 185f, 20f, 22f), "B:", "Label");
                GUI.Label(new Rect(72f, 210f, 20f, 22f), "A:", "Label");
                FengGameManagerMKII.settingsRC[246] = GUI.HorizontalSlider(new Rect(92f, 135f, 100f, 20f), (float)FengGameManagerMKII.settingsRC[246], 0f, 1f);
                FengGameManagerMKII.settingsRC[247] = GUI.HorizontalSlider(new Rect(92f, 160f, 100f, 20f), (float)FengGameManagerMKII.settingsRC[247], 0f, 1f);
                FengGameManagerMKII.settingsRC[248] = GUI.HorizontalSlider(new Rect(92f, 185f, 100f, 20f), (float)FengGameManagerMKII.settingsRC[248], 0f, 1f);
                FengGameManagerMKII.settingsRC[249] = GUI.HorizontalSlider(new Rect(92f, 210f, 100f, 20f), (float)FengGameManagerMKII.settingsRC[249], 0.5f, 1f);
                GUI.Label(new Rect(72f, 235f, 95f, 22f), "Bomb Radius:", "Label");
                GUI.Label(new Rect(72f, 260f, 95f, 22f), "Bomb Range:", "Label");
                GUI.Label(new Rect(72f, 285f, 95f, 22f), "Bomb Speed:", "Label");
                GUI.Label(new Rect(72f, 310f, 95f, 22f), "Bomb CD:", "Label");
                GUI.Label(new Rect(72f, 335f, 95f, 22f), "Unused Points:", "Label");
                int num = (int)FengGameManagerMKII.settingsRC[250];
                GUI.Label(new Rect(168f, 235f, 20f, 22f), num.ToString(), "Label");
                num = (int)FengGameManagerMKII.settingsRC[251];
                GUI.Label(new Rect(168f, 260f, 20f, 22f), num.ToString(), "Label");
                num = (int)FengGameManagerMKII.settingsRC[252];
                GUI.Label(new Rect(168f, 285f, 20f, 22f), num.ToString(), "Label");
                Rect rect = new Rect(168f, 310f, 20f, 22f);
                int num1 = (int)FengGameManagerMKII.settingsRC[253];
                GUI.Label(rect, num1.ToString(), "Label");
                int num2 = 20 - (int)FengGameManagerMKII.settingsRC[250] - (int)FengGameManagerMKII.settingsRC[251] - (int)FengGameManagerMKII.settingsRC[252] - (int)FengGameManagerMKII.settingsRC[253];
                GUI.Label(new Rect(168f, 335f, 20f, 22f), num2.ToString(), "Label");
                if (GUI.Button(new Rect(190f, 235f, 20f, 20f), "-"))
                {
                    if ((int)FengGameManagerMKII.settingsRC[250] > 0)
                    {
                        FengGameManagerMKII.settingsRC[250] = (int)FengGameManagerMKII.settingsRC[250] - 1;
                    }
                }
                else if (GUI.Button(new Rect(215f, 235f, 20f, 20f), "+") && (int)FengGameManagerMKII.settingsRC[250] < 10 && num2 > 0)
                {
                    FengGameManagerMKII.settingsRC[250] = (int)FengGameManagerMKII.settingsRC[250] + 1;
                }
                if (GUI.Button(new Rect(190f, 260f, 20f, 20f), "-"))
                {
                    if ((int)FengGameManagerMKII.settingsRC[251] > 0)
                    {
                        FengGameManagerMKII.settingsRC[251] = (int)FengGameManagerMKII.settingsRC[251] - 1;
                    }
                }
                else if (GUI.Button(new Rect(215f, 260f, 20f, 20f), "+") && (int)FengGameManagerMKII.settingsRC[251] < 10 && num2 > 0)
                {
                    FengGameManagerMKII.settingsRC[251] = (int)FengGameManagerMKII.settingsRC[251] + 1;
                }
                if (GUI.Button(new Rect(190f, 285f, 20f, 20f), "-"))
                {
                    if ((int)FengGameManagerMKII.settingsRC[252] > 0)
                    {
                        FengGameManagerMKII.settingsRC[252] = (int)FengGameManagerMKII.settingsRC[252] - 1;
                    }
                }
                else if (GUI.Button(new Rect(215f, 285f, 20f, 20f), "+") && (int)FengGameManagerMKII.settingsRC[252] < 10 && num2 > 0)
                {
                    FengGameManagerMKII.settingsRC[252] = (int)FengGameManagerMKII.settingsRC[252] + 1;
                }
                if (GUI.Button(new Rect(190f, 310f, 20f, 20f), "-"))
                {
                    if ((int)FengGameManagerMKII.settingsRC[253] > 0)
                    {
                        FengGameManagerMKII.settingsRC[253] = (int)FengGameManagerMKII.settingsRC[253] - 1;
                    }
                }
                else if (GUI.Button(new Rect(215f, 310f, 20f, 20f), "+") && (int)FengGameManagerMKII.settingsRC[253] < 10 && num2 > 0)
                {
                    FengGameManagerMKII.settingsRC[253] = (int)FengGameManagerMKII.settingsRC[253] + 1;
                }
                GUILayout.EndArea();
            }

            protected internal void General()
            {
                string str;
                string str1;
                string str2;
                string str3;
                F1GUI.scroll = GUI.BeginScrollView(new Rect(5f, 80f, 257f, 480f), F1GUI.scroll, new Rect(5f, 80f, 200f, 665f), false, true);
                F1GUI.heightPos = 80f;
                F1GUI.OnGUISINGLE(39, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Fog Mode", false);
                F1GUI.OnGUISINGLE(43, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Body Leaning", false);
                F1GUI.OnGUISINGLE(45, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Allow WeaponTrail?", false);
                F1GUI.OnGUISINGLE(48, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Old WeaponTrail?", false);
                F1GUI.OnGUISINGLE(44, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Auto-Aim Guns", false);
                F1GUI.OnGUISINGLE(62, new Rect(10f, F1GUI.heightPos, 185f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "HD SnapShots:", false);
                F1GUI.OnGUISINGLE(83, new Rect(10f, F1GUI.heightPos, 185f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "FPS Camera:", false);
                F1GUI.OnGUISINGLE(115, new Rect(10f, F1GUI.heightPos, 185f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Speed Meter:", false);
                string str4 = PlayerPrefs.GetString("AnimatedName", "None");
                bool flag = str4 == "Linear";
                bool flag1 = str4 == "Faded";
                bool flag2 = str4 == "Rebound";
                GUI.Label(new Rect(10f, F1GUI.heightPos, 185f, 20f), "UI Name:", "Label");
                bool flag3 = GUI.Toggle(new Rect(65f, F1GUI.heightPos, 65f, 20f), flag2, "Rebound");
                bool flag4 = GUI.Toggle(new Rect(135f, F1GUI.heightPos, 50f, 20f), flag, "Linear");
                bool flag5 = GUI.Toggle(new Rect(190f, F1GUI.heightPos, 50f, 20f), flag1, "Faded");
                if (flag3 != flag2)
                {
                    if (flag3)
                    {
                        str3 = "Rebound";
                    }
                    else if (flag4)
                    {
                        str3 = "Linear";
                    }
                    else
                    {
                        str3 = (flag5 ? "Faded" : "None");
                    }
                    PlayerPrefs.SetString("AnimatedName", str3);
                }
                if (flag4 != flag)
                {
                    if (flag4)
                    {
                        str2 = "Linear";
                    }
                    else if (flag3)
                    {
                        str2 = "Rebound";
                    }
                    else
                    {
                        str2 = (flag5 ? "Faded" : "None");
                    }
                    PlayerPrefs.SetString("AnimatedName", str2);
                }
                if (flag5 != flag1)
                {
                    if (flag5)
                    {
                        str1 = "Faded";
                    }
                    else if (flag3)
                    {
                        str1 = "Rebound";
                    }
                    else
                    {
                        str1 = (flag4 ? "Linear" : "None");
                    }
                    PlayerPrefs.SetString("AnimatedName", str1);
                }
                F1GUI.heightPos = F1GUI.heightPos + 25f;
                if (PhotonNetwork.connectionStateDetailed != PeerStates.Joined && GUI.Button(new Rect(10f, F1GUI.heightPos, 227f, 20f), "SINGLE GAMEMODES"))
                {
                    FengGameManagerMKII.settingsSkin[64] = "9";
                }
                F1GUI.heightPos = F1GUI.heightPos + 25f;
                GUI.Label(new Rect(10f, F1GUI.heightPos, 185f, 20f), "Volume:", "Label");
                GUI.backgroundColor = (new Color(0f, 0f, 1f, 1f));
                F1GUI.heightPos = F1GUI.heightPos + 25f;
                AudioListener.set_volume(GUI.HorizontalSlider(new Rect(10f, F1GUI.heightPos, 227f, 30f), AudioListener.get_volume(), 0f, 1f));
                F1GUI.heightPos = F1GUI.heightPos + 30f;
                GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                if (FengGameManagerMKII.settingsSkin[91] == "1")
                {
                    GUI.backgroundColor = (new Color(0f, 0f, 0f, 1f));
                }
                if (GUI.Button(new Rect(10f, F1GUI.heightPos, 150f, 20f), "AirSpecial"))
                {
                    if (FengGameManagerMKII.settingsSkin[91] == "1")
                    {
                        FengGameManagerMKII.settingsSkin[91] = "0";
                    }
                    else
                    {
                        FengGameManagerMKII.settingsSkin[91] = "1";
                        FengGameManagerMKII.settingsSkin[92] = "0";
                    }
                }
                if (FengGameManagerMKII.settingsSkin[91] == "1")
                {
                    GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                }
                GUI.Label(new Rect(165f, F1GUI.heightPos, 175f, 25f), FengGameManagerMKII.settingsSkin[89], "Label");
                F1GUI.heightPos = F1GUI.heightPos + 25f;
                if (FengGameManagerMKII.settingsSkin[91] == "1")
                {
                    GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                    F1GUI.SelectionGrid(1);
                }
                if (FengGameManagerMKII.settingsSkin[92] == "1")
                {
                    GUI.backgroundColor = (new Color(0f, 0f, 0f, 1f));
                }
                if (GUI.Button(new Rect(10f, F1GUI.heightPos, 150f, 20f), "GroundSpecial"))
                {
                    if (FengGameManagerMKII.settingsSkin[92] == "1")
                    {
                        FengGameManagerMKII.settingsSkin[92] = "0";
                    }
                    else
                    {
                        FengGameManagerMKII.settingsSkin[92] = "1";
                        FengGameManagerMKII.settingsSkin[91] = "0";
                    }
                }
                if (FengGameManagerMKII.settingsSkin[92] == "1")
                {
                    GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                }
                GUI.Label(new Rect(165f, F1GUI.heightPos, 175f, 25f), FengGameManagerMKII.settingsSkin[90], "Label");
                F1GUI.heightPos = F1GUI.heightPos + 25f;
                if (FengGameManagerMKII.settingsSkin[92] == "1")
                {
                    GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                    F1GUI.SelectionGrid(2);
                }
                if (FengGameManagerMKII.settingsSkin[92] != "1" && FengGameManagerMKII.settingsSkin[91] != "1")
                {
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 270f, 40f), "Min Damage for Screenshots\n(Anything less won't be taken):", "Label");
                    F1GUI.heightPos = F1GUI.heightPos + 45f;
                    object[] num = FengGameManagerMKII.settings;
                    Rect rect = new Rect(10f, F1GUI.heightPos, 227f, 20f);
                    int num1 = (int)FengGameManagerMKII.settings[32];
                    num[32] = Convert.ToInt32(GUI.TextField(rect, num1.ToString()));
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    F1GUI.Toggle(new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Minimap:", () => (int)FengGameManagerMKII.settingsRC[231] > 0, (bool ifOn) => FengGameManagerMKII.settingsRC[231] = (ifOn ? 1 : 0));
                    F1GUI.OnGUISINGLE(33, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Allow Death Screenshotting?", false);
                    F1GUI.OnGUISINGLE(15, new Rect(10f, F1GUI.heightPos, 185f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Disable custom gas textures:", true);
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 185f, 20f), "Scale human/titan textures with quality:", "Label");
                    bool flag6 = (string)FengGameManagerMKII.settingsRC[62] == "1";
                    bool flag7 = GUI.Toggle(new Rect(200f, F1GUI.heightPos, 40f, 20f), flag6, "On");
                    if (flag6 != flag7)
                    {
                        object[] objArray = FengGameManagerMKII.settingsRC;
                        string[] strArrays = FengGameManagerMKII.settingsSkin;
                        str = (flag7 ? "1" : "0");
                        string str5 = str;
                        strArrays[62] = str;
                        objArray[62] = str5;
                        FengGameManagerMKII.skinCache[0].Clear();
                        FengGameManagerMKII.skinCache[1].Clear();
                    }
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 200f, 20f), "Scale level textures with quality:", "Label");
                    bool flag8 = (string)FengGameManagerMKII.settingsRC[63] == "1";
                    bool flag9 = GUI.Toggle(new Rect(200f, F1GUI.heightPos, 40f, 20f), flag8, "On");
                    if (flag9 != flag8)
                    {
                        FengGameManagerMKII.settingsRC[63] = (flag9 ? "1" : "0");
                        FengGameManagerMKII.skinCache[2].Clear();
                        FengGameManagerMKII.skinCache[3].Clear();
                    }
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    F1GUI.OnGUISINGLE(25, new Rect(10f, F1GUI.heightPos, 185f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Enable RedCross Smoke:", false);
                    F1GUI.OnGUISINGLE(93, new Rect(10f, F1GUI.heightPos, 185f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "Disable WindFX:", true);
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 160f, 22f), "Texture Quality:", "Label");
                    if (Application.get_loadedLevel() == 0)
                    {
                        if (GUI.Button(new Rect(120f, F1GUI.heightPos, 60f, 20f), F1GUI.mastertexturetype(F1GUI.qualitylevel)))
                        {
                            if (F1GUI.qualitylevel > 0)
                            {
                                F1GUI.qualitylevel = F1GUI.qualitylevel - 1;
                            }
                            else
                            {
                                F1GUI.qualitylevel = 2;
                            }
                            FengGameManagerMKII.skinCache[0].Clear();
                            FengGameManagerMKII.skinCache[1].Clear();
                            FengGameManagerMKII.skinCache[2].Clear();
                            FengGameManagerMKII.skinCache[3].Clear();
                        }
                    }
                    else if (GUI.Button(new Rect(120f, F1GUI.heightPos, 60f, 20f), F1GUI.mastertexturetype(QualitySettings.get_masterTextureLimit())))
                    {
                        if (QualitySettings.get_masterTextureLimit() > 0)
                        {
                            QualitySettings.set_masterTextureLimit(QualitySettings.get_masterTextureLimit() - 1);
                        }
                        else
                        {
                            QualitySettings.set_masterTextureLimit(2);
                        }
                        FengGameManagerMKII.skinCache[0].Clear();
                        FengGameManagerMKII.skinCache[1].Clear();
                        FengGameManagerMKII.skinCache[2].Clear();
                        FengGameManagerMKII.skinCache[3].Clear();
                    }
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 185f, 20f), "Hide HUD:", "Label");
                    int num2 = PlayerPrefs.GetInt("ShowHUD", 4);
                    if (GUI.Button(new Rect(80f, F1GUI.heightPos, 150f, 20f), F1GUI.HiddenHUDS(num2)))
                    {
                        if (num2 > -3)
                        {
                            PlayerPrefs.SetInt("ShowHUD", num2 - 1);
                        }
                        else
                        {
                            PlayerPrefs.SetInt("ShowHUD", 4);
                        }
                    }
                }
                GUI.EndScrollView();
            }

            protected internal void Human()
            {
                int num;
                int num1;
                int num2;
                int num3;
                int num4;
                int num5;
                int num6;
                int num7;
                int num8;
                int num9;
                int num10;
                int num11;
                int num12;
                GUILayout.BeginArea(new Rect(5f, 80f, 257f, 480f));
                F1GUI.scroll = GUI.BeginScrollView(new Rect(0f, 0f, 257f, 480f), F1GUI.scroll, new Rect(0f, 0f, 200f, 1015f), false, true);
                GUILayout.BeginArea(new Rect(2f, 0f, 232f, 1015f));
                F1GUI.ToggleLayout("Human Skin Mode:", () => (string)FengGameManagerMKII.settingsRC[1] == "1", (bool on) => FengGameManagerMKII.settingsRC[1] = (on ? "1" : "0"), new Vector2?(new Vector2(185f, 0f)), new Vector2?(new Vector2(40f, 20f)));
                string empty = string.Empty;
                string str = (string)FengGameManagerMKII.settingsRC[133];
                string str1 = str;
                if (str != null && !(str1 == "0"))
                {
                    if (str1 == "1")
                    {
                        empty = "Human Set 2";
                        num = 134;
                        num1 = 135;
                        num2 = 136;
                        num3 = 137;
                        num4 = 138;
                        num5 = 139;
                        num6 = 140;
                        num7 = 141;
                        num8 = 142;
                        num9 = 143;
                        num10 = 144;
                        num11 = 145;
                        num12 = 146;
                        goto Label0;
                    }
                    else
                    {
                        if (str1 != "2")
                        {
                            goto Label1;
                        }
                        empty = "Human Set 3";
                        num = 147;
                        num1 = 148;
                        num2 = 149;
                        num3 = 150;
                        num4 = 151;
                        num5 = 152;
                        num6 = 153;
                        num7 = 154;
                        num8 = 155;
                        num9 = 156;
                        num10 = 157;
                        num11 = 158;
                        num12 = 159;
                        goto Label0;
                    }
                }
            Label1:
                empty = "Human Set 1";
                num = 3;
                num1 = 4;
                num2 = 5;
                num3 = 6;
                num4 = 7;
                num5 = 8;
                num6 = 14;
                num7 = 9;
                num8 = 10;
                num9 = 11;
                num10 = 12;
                num11 = 13;
                num12 = 94;
            Label0:
                GUILayoutOption[] gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Height(30f) };
                GUILayout.BeginHorizontal(gUILayoutOptionArray);
                GUILayout.FlexibleSpace();
                GUILayoutOption[] gUILayoutOptionArray1 = new GUILayoutOption[] { GUILayout.Width(120f), GUILayout.Height(30f) };
                if (GUILayout.Button(empty, gUILayoutOptionArray1))
                {
                    string str2 = (string)FengGameManagerMKII.settingsRC[133];
                    string str3 = str2;
                    if (str2 != null)
                    {
                        if (str3 == "0")
                        {
                            FengGameManagerMKII.settingsRC[133] = "1";
                        }
                        else if (str3 == "1")
                        {
                            FengGameManagerMKII.settingsRC[133] = "2";
                        }
                        else if (str3 == "2")
                        {
                            FengGameManagerMKII.settingsRC[133] = "0";
                        }
                    }
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    GUILayout.EndArea();
                    GUI.EndScrollView();
                    GUILayout.EndArea();
                    return;
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray2 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Horse:", gUILayoutOptionArray2);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray = FengGameManagerMKII.settingsRC;
                string str4 = (string)FengGameManagerMKII.settingsRC[num];
                GUILayoutOption[] gUILayoutOptionArray3 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str5 = GUILayout.TextField(str4, gUILayoutOptionArray3).Trim();
                object obj = str5;
                objArray[num] = str5;
                GUILayoutOption[] gUILayoutOptionArray4 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj, gUILayoutOptionArray4);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray5 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Hair (model dependent):", gUILayoutOptionArray5);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray1 = FengGameManagerMKII.settingsRC;
                string str6 = (string)FengGameManagerMKII.settingsRC[num1];
                GUILayoutOption[] gUILayoutOptionArray6 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str7 = GUILayout.TextField(str6, gUILayoutOptionArray6).Trim();
                object obj1 = str7;
                objArray1[num1] = str7;
                GUILayoutOption[] gUILayoutOptionArray7 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj1, gUILayoutOptionArray7);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray8 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Eyes:", gUILayoutOptionArray8);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray2 = FengGameManagerMKII.settingsRC;
                string str8 = (string)FengGameManagerMKII.settingsRC[num2];
                GUILayoutOption[] gUILayoutOptionArray9 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str9 = GUILayout.TextField(str8, gUILayoutOptionArray9).Trim();
                object obj2 = str9;
                objArray2[num2] = str9;
                GUILayoutOption[] gUILayoutOptionArray10 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj2, gUILayoutOptionArray10);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray11 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Glass (must have a glass enabled):", gUILayoutOptionArray11);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray3 = FengGameManagerMKII.settingsRC;
                string str10 = (string)FengGameManagerMKII.settingsRC[num3];
                GUILayoutOption[] gUILayoutOptionArray12 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str11 = GUILayout.TextField(str10, gUILayoutOptionArray12).Trim();
                object obj3 = str11;
                objArray3[num3] = str11;
                GUILayoutOption[] gUILayoutOptionArray13 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj3, gUILayoutOptionArray13);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray14 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Face:", gUILayoutOptionArray14);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray4 = FengGameManagerMKII.settingsRC;
                string str12 = (string)FengGameManagerMKII.settingsRC[num4];
                GUILayoutOption[] gUILayoutOptionArray15 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str13 = GUILayout.TextField(str12, gUILayoutOptionArray15).Trim();
                object obj4 = str13;
                objArray4[num4] = str13;
                GUILayoutOption[] gUILayoutOptionArray16 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj4, gUILayoutOptionArray16);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray17 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Skin:", gUILayoutOptionArray17);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray5 = FengGameManagerMKII.settingsRC;
                string str14 = (string)FengGameManagerMKII.settingsRC[num5];
                GUILayoutOption[] gUILayoutOptionArray18 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str15 = GUILayout.TextField(str14, gUILayoutOptionArray18).Trim();
                object obj5 = str15;
                objArray5[num5] = str15;
                GUILayoutOption[] gUILayoutOptionArray19 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj5, gUILayoutOptionArray19);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray20 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Hoodie (costume dependent):", gUILayoutOptionArray20);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray6 = FengGameManagerMKII.settingsRC;
                string str16 = (string)FengGameManagerMKII.settingsRC[num6];
                GUILayoutOption[] gUILayoutOptionArray21 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str17 = GUILayout.TextField(str16, gUILayoutOptionArray21).Trim();
                object obj6 = str17;
                objArray6[num6] = str17;
                GUILayoutOption[] gUILayoutOptionArray22 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj6, gUILayoutOptionArray22);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray23 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Costume (model dependent):", gUILayoutOptionArray23);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray7 = FengGameManagerMKII.settingsRC;
                string str18 = (string)FengGameManagerMKII.settingsRC[num7];
                GUILayoutOption[] gUILayoutOptionArray24 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str19 = GUILayout.TextField(str18, gUILayoutOptionArray24).Trim();
                object obj7 = str19;
                objArray7[num7] = str19;
                GUILayoutOption[] gUILayoutOptionArray25 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj7, gUILayoutOptionArray25);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray26 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Logo & Cape:", gUILayoutOptionArray26);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray8 = FengGameManagerMKII.settingsRC;
                string str20 = (string)FengGameManagerMKII.settingsRC[num8];
                GUILayoutOption[] gUILayoutOptionArray27 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str21 = GUILayout.TextField(str20, gUILayoutOptionArray27).Trim();
                object obj8 = str21;
                objArray8[num8] = str21;
                GUILayoutOption[] gUILayoutOptionArray28 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj8, gUILayoutOptionArray28);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray29 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("3DMG Center & 3DMG/Blade/Gun(left):", gUILayoutOptionArray29);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray9 = FengGameManagerMKII.settingsRC;
                string str22 = (string)FengGameManagerMKII.settingsRC[num9];
                GUILayoutOption[] gUILayoutOptionArray30 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str23 = GUILayout.TextField(str22, gUILayoutOptionArray30).Trim();
                object obj9 = str23;
                objArray9[num9] = str23;
                GUILayoutOption[] gUILayoutOptionArray31 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj9, gUILayoutOptionArray31);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray32 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("3DMG/Blade/Gun(right):", gUILayoutOptionArray32);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray10 = FengGameManagerMKII.settingsRC;
                string str24 = (string)FengGameManagerMKII.settingsRC[num10];
                GUILayoutOption[] gUILayoutOptionArray33 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str25 = GUILayout.TextField(str24, gUILayoutOptionArray33).Trim();
                object obj10 = str25;
                objArray10[num10] = str25;
                gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj10, gUILayoutOptionArray);
                GUILayout.EndHorizontal();
                gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Gas:", gUILayoutOptionArray);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray11 = FengGameManagerMKII.settingsRC;
                string str26 = (string)FengGameManagerMKII.settingsRC[num11];
                gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str27 = GUILayout.TextField(str26, gUILayoutOptionArray).Trim();
                obj = str27;
                objArray11[num11] = str27;
                gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj, gUILayoutOptionArray);
                GUILayout.EndHorizontal();
                gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Weapon Trail:", gUILayoutOptionArray);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray12 = FengGameManagerMKII.settingsRC;
                string str28 = (string)FengGameManagerMKII.settingsRC[num12];
                gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str29 = GUILayout.TextField(str28, gUILayoutOptionArray).Trim();
                obj = str29;
                objArray12[num12] = str29;
                gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj, gUILayoutOptionArray);
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
                GUI.EndScrollView();
                GUILayout.EndArea();
            }

            protected internal void LevelsCity()
            {
                F1GUI.scroll = GUI.BeginScrollView(new Rect(5f, 80f, 257f, 480f), F1GUI.scroll, new Rect(5f, 80f, 200f, 480f), false, true);
                if (GUI.Button(new Rect(165f, 80f, 70f, 20f), "FOREST"))
                {
                    FengGameManagerMKII.settingsSkin[64] = "2";
                }
                GUILayout.BeginArea(new Rect(10f, 80f, 227f, 480f));
                F1GUI.ToggleLayout("Level Skin Mode:", () => (string)FengGameManagerMKII.settingsRC[2] == "1", (bool on) => FengGameManagerMKII.settingsRC[2] = (on ? "1" : "0"), new Vector2?(new Vector2(110f, 30f)), new Vector2?(new Vector2(40f, 20f)));
                GUILayoutOption[] gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(150f), GUILayout.Height(20f) };
                GUILayout.Label("Ground:", gUILayoutOptionArray);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray = FengGameManagerMKII.settingsRC;
                string str = (string)FengGameManagerMKII.settingsRC[59];
                GUILayoutOption[] gUILayoutOptionArray1 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str1 = GUILayout.TextField(str, gUILayoutOptionArray1).Trim();
                object obj = str1;
                objArray[59] = str1;
                GUILayoutOption[] gUILayoutOptionArray2 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj, gUILayoutOptionArray2);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray3 = new GUILayoutOption[] { GUILayout.Width(150f), GUILayout.Height(20f) };
                GUILayout.Label("Wall:", gUILayoutOptionArray3);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray1 = FengGameManagerMKII.settingsRC;
                string str2 = (string)FengGameManagerMKII.settingsRC[60];
                GUILayoutOption[] gUILayoutOptionArray4 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str3 = GUILayout.TextField(str2, gUILayoutOptionArray4).Trim();
                object obj1 = str3;
                objArray1[60] = str3;
                GUILayoutOption[] gUILayoutOptionArray5 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj1, gUILayoutOptionArray5);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray6 = new GUILayoutOption[] { GUILayout.Width(150f), GUILayout.Height(20f) };
                GUILayout.Label("Gate:", gUILayoutOptionArray6);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray2 = FengGameManagerMKII.settingsRC;
                string str4 = (string)FengGameManagerMKII.settingsRC[61];
                GUILayoutOption[] gUILayoutOptionArray7 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str5 = GUILayout.TextField(str4, gUILayoutOptionArray7).Trim();
                object obj2 = str5;
                objArray2[61] = str5;
                GUILayoutOption[] gUILayoutOptionArray8 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj2, gUILayoutOptionArray8);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray9 = new GUILayoutOption[] { GUILayout.Width(150f), GUILayout.Height(20f) };
                GUILayout.Label("Houses:", gUILayoutOptionArray9);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray3 = FengGameManagerMKII.settingsRC;
                string str6 = (string)FengGameManagerMKII.settingsRC[51];
                GUILayoutOption[] gUILayoutOptionArray10 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str7 = GUILayout.TextField(str6, gUILayoutOptionArray10).Trim();
                object obj3 = str7;
                objArray3[51] = str7;
                GUILayoutOption[] gUILayoutOptionArray11 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj3, gUILayoutOptionArray11);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray4 = FengGameManagerMKII.settingsRC;
                string str8 = (string)FengGameManagerMKII.settingsRC[52];
                GUILayoutOption[] gUILayoutOptionArray12 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str9 = GUILayout.TextField(str8, gUILayoutOptionArray12).Trim();
                object obj4 = str9;
                objArray4[52] = str9;
                GUILayoutOption[] gUILayoutOptionArray13 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj4, gUILayoutOptionArray13);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray5 = FengGameManagerMKII.settingsRC;
                string str10 = (string)FengGameManagerMKII.settingsRC[53];
                GUILayoutOption[] gUILayoutOptionArray14 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str11 = GUILayout.TextField(str10, gUILayoutOptionArray14).Trim();
                object obj5 = str11;
                objArray5[53] = str11;
                GUILayoutOption[] gUILayoutOptionArray15 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj5, gUILayoutOptionArray15);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray6 = FengGameManagerMKII.settingsRC;
                string str12 = (string)FengGameManagerMKII.settingsRC[54];
                GUILayoutOption[] gUILayoutOptionArray16 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str13 = GUILayout.TextField(str12, gUILayoutOptionArray16).Trim();
                object obj6 = str13;
                objArray6[54] = str13;
                GUILayoutOption[] gUILayoutOptionArray17 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj6, gUILayoutOptionArray17);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray7 = FengGameManagerMKII.settingsRC;
                string str14 = (string)FengGameManagerMKII.settingsRC[55];
                GUILayoutOption[] gUILayoutOptionArray18 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str15 = GUILayout.TextField(str14, gUILayoutOptionArray18).Trim();
                object obj7 = str15;
                objArray7[55] = str15;
                GUILayoutOption[] gUILayoutOptionArray19 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj7, gUILayoutOptionArray19);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray8 = FengGameManagerMKII.settingsRC;
                string str16 = (string)FengGameManagerMKII.settingsRC[56];
                GUILayoutOption[] gUILayoutOptionArray20 = new GUILayoutOption[] { GUILayout.Width(227f), GUILayout.Height(20f) };
                string str17 = GUILayout.TextField(str16, gUILayoutOptionArray20).Trim();
                object obj8 = str17;
                objArray8[56] = str17;
                GUILayoutOption[] gUILayoutOptionArray21 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj8, gUILayoutOptionArray21);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray9 = FengGameManagerMKII.settingsRC;
                string str18 = (string)FengGameManagerMKII.settingsRC[57];
                GUILayoutOption[] gUILayoutOptionArray22 = new GUILayoutOption[] { GUILayout.Width(227f), GUILayout.Height(20f) };
                string str19 = GUILayout.TextField(str18, gUILayoutOptionArray22).Trim();
                object obj9 = str19;
                objArray9[57] = str19;
                GUILayoutOption[] gUILayoutOptionArray23 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj9, gUILayoutOptionArray23);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray10 = FengGameManagerMKII.settingsRC;
                string str20 = (string)FengGameManagerMKII.settingsRC[58];
                GUILayoutOption[] gUILayoutOptionArray24 = new GUILayoutOption[] { GUILayout.Width(227f), GUILayout.Height(20f) };
                string str21 = GUILayout.TextField(str20, gUILayoutOptionArray24).Trim();
                object obj10 = str21;
                objArray10[58] = str21;
                GUILayoutOption[] gUILayoutOptionArray25 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj10, gUILayoutOptionArray25);
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
                GUI.EndScrollView();
            }

            protected internal void LevelsForest()
            {
                F1GUI.scroll = GUI.BeginScrollView(new Rect(5f, 80f, 257f, 480f), F1GUI.scroll, new Rect(5f, 80f, 200f, 570f), false, true);
                if (GUI.Button(new Rect(165f, 80f, 70f, 20f), "CITY"))
                {
                    FengGameManagerMKII.settingsSkin[64] = "3";
                }
                GUILayout.BeginArea(new Rect(10f, 80f, 227f, 570f));
                F1GUI.ToggleLayout("Level Skin Mode:", () => (string)FengGameManagerMKII.settingsRC[2] == "1", (bool on) => FengGameManagerMKII.settingsRC[2] = (on ? "1" : "0"), new Vector2?(new Vector2(110f, 30f)), new Vector2?(new Vector2(40f, 20f)));
                F1GUI.ToggleLayout("Randomized Pairs:", () => (string)FengGameManagerMKII.settingsRC[50] == "1", (bool on) => FengGameManagerMKII.settingsRC[50] = (on ? "1" : "0"), new Vector2?(new Vector2(110f, 30f)), new Vector2?(new Vector2(40f, 20f)));
                GUILayoutOption[] gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(150f), GUILayout.Height(20f) };
                GUILayout.Label("Ground:", gUILayoutOptionArray);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray = FengGameManagerMKII.settingsRC;
                string str = (string)FengGameManagerMKII.settingsRC[49];
                GUILayoutOption[] gUILayoutOptionArray1 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str1 = GUILayout.TextField(str, gUILayoutOptionArray1).Trim();
                object obj = str1;
                objArray[49] = str1;
                GUILayoutOption[] gUILayoutOptionArray2 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj, gUILayoutOptionArray2);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray3 = new GUILayoutOption[] { GUILayout.Width(150f), GUILayout.Height(20f) };
                GUILayout.Label("Forest Trunks:", gUILayoutOptionArray3);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray1 = FengGameManagerMKII.settingsRC;
                string str2 = (string)FengGameManagerMKII.settingsRC[33];
                GUILayoutOption[] gUILayoutOptionArray4 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str3 = GUILayout.TextField(str2, gUILayoutOptionArray4).Trim();
                object obj1 = str3;
                objArray1[33] = str3;
                GUILayoutOption[] gUILayoutOptionArray5 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj1, gUILayoutOptionArray5);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray2 = FengGameManagerMKII.settingsRC;
                string str4 = (string)FengGameManagerMKII.settingsRC[34];
                GUILayoutOption[] gUILayoutOptionArray6 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str5 = GUILayout.TextField(str4, gUILayoutOptionArray6).Trim();
                object obj2 = str5;
                objArray2[34] = str5;
                GUILayoutOption[] gUILayoutOptionArray7 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj2, gUILayoutOptionArray7);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray3 = FengGameManagerMKII.settingsRC;
                string str6 = (string)FengGameManagerMKII.settingsRC[35];
                GUILayoutOption[] gUILayoutOptionArray8 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str7 = GUILayout.TextField(str6, gUILayoutOptionArray8).Trim();
                object obj3 = str7;
                objArray3[35] = str7;
                GUILayoutOption[] gUILayoutOptionArray9 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj3, gUILayoutOptionArray9);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray4 = FengGameManagerMKII.settingsRC;
                string str8 = (string)FengGameManagerMKII.settingsRC[36];
                GUILayoutOption[] gUILayoutOptionArray10 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str9 = GUILayout.TextField(str8, gUILayoutOptionArray10).Trim();
                object obj4 = str9;
                objArray4[36] = str9;
                GUILayoutOption[] gUILayoutOptionArray11 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj4, gUILayoutOptionArray11);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray5 = FengGameManagerMKII.settingsRC;
                string str10 = (string)FengGameManagerMKII.settingsRC[37];
                GUILayoutOption[] gUILayoutOptionArray12 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str11 = GUILayout.TextField(str10, gUILayoutOptionArray12).Trim();
                object obj5 = str11;
                objArray5[37] = str11;
                GUILayoutOption[] gUILayoutOptionArray13 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj5, gUILayoutOptionArray13);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray6 = FengGameManagerMKII.settingsRC;
                string str12 = (string)FengGameManagerMKII.settingsRC[38];
                GUILayoutOption[] gUILayoutOptionArray14 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str13 = GUILayout.TextField(str12, gUILayoutOptionArray14).Trim();
                object obj6 = str13;
                objArray6[38] = str13;
                GUILayoutOption[] gUILayoutOptionArray15 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj6, gUILayoutOptionArray15);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray7 = FengGameManagerMKII.settingsRC;
                string str14 = (string)FengGameManagerMKII.settingsRC[39];
                GUILayoutOption[] gUILayoutOptionArray16 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str15 = GUILayout.TextField(str14, gUILayoutOptionArray16).Trim();
                object obj7 = str15;
                objArray7[39] = str15;
                GUILayoutOption[] gUILayoutOptionArray17 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj7, gUILayoutOptionArray17);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray8 = FengGameManagerMKII.settingsRC;
                string str16 = (string)FengGameManagerMKII.settingsRC[40];
                GUILayoutOption[] gUILayoutOptionArray18 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str17 = GUILayout.TextField(str16, gUILayoutOptionArray18).Trim();
                object obj8 = str17;
                objArray8[40] = str17;
                GUILayoutOption[] gUILayoutOptionArray19 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj8, gUILayoutOptionArray19);
                GUILayout.EndHorizontal();
                GUILayoutOption[] gUILayoutOptionArray20 = new GUILayoutOption[] { GUILayout.Width(150f), GUILayout.Height(20f) };
                GUILayout.Label("Forest Leaves:", gUILayoutOptionArray20);
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray9 = FengGameManagerMKII.settingsRC;
                string str18 = (string)FengGameManagerMKII.settingsRC[41];
                GUILayoutOption[] gUILayoutOptionArray21 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str19 = GUILayout.TextField(str18, gUILayoutOptionArray21).Trim();
                object obj9 = str19;
                objArray9[41] = str19;
                GUILayoutOption[] gUILayoutOptionArray22 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj9, gUILayoutOptionArray22);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray10 = FengGameManagerMKII.settingsRC;
                string str20 = (string)FengGameManagerMKII.settingsRC[42];
                GUILayoutOption[] gUILayoutOptionArray23 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str21 = GUILayout.TextField(str20, gUILayoutOptionArray23).Trim();
                object obj10 = str21;
                objArray10[42] = str21;
                GUILayoutOption[] gUILayoutOptionArray24 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj10, gUILayoutOptionArray24);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray11 = FengGameManagerMKII.settingsRC;
                string str22 = (string)FengGameManagerMKII.settingsRC[43];
                GUILayoutOption[] gUILayoutOptionArray25 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str23 = GUILayout.TextField(str22, gUILayoutOptionArray25).Trim();
                object obj11 = str23;
                objArray11[43] = str23;
                GUILayoutOption[] gUILayoutOptionArray26 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj11, gUILayoutOptionArray26);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray12 = FengGameManagerMKII.settingsRC;
                string str24 = (string)FengGameManagerMKII.settingsRC[44];
                GUILayoutOption[] gUILayoutOptionArray27 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str25 = GUILayout.TextField(str24, gUILayoutOptionArray27).Trim();
                object obj12 = str25;
                objArray12[44] = str25;
                GUILayoutOption[] gUILayoutOptionArray28 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj12, gUILayoutOptionArray28);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray13 = FengGameManagerMKII.settingsRC;
                string str26 = (string)FengGameManagerMKII.settingsRC[45];
                GUILayoutOption[] gUILayoutOptionArray29 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str27 = GUILayout.TextField(str26, gUILayoutOptionArray29).Trim();
                object obj13 = str27;
                objArray13[45] = str27;
                GUILayoutOption[] gUILayoutOptionArray30 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj13, gUILayoutOptionArray30);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray14 = FengGameManagerMKII.settingsRC;
                string str28 = (string)FengGameManagerMKII.settingsRC[46];
                GUILayoutOption[] gUILayoutOptionArray31 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str29 = GUILayout.TextField(str28, gUILayoutOptionArray31).Trim();
                object obj14 = str29;
                objArray14[46] = str29;
                GUILayoutOption[] gUILayoutOptionArray32 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj14, gUILayoutOptionArray32);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray15 = FengGameManagerMKII.settingsRC;
                string str30 = (string)FengGameManagerMKII.settingsRC[47];
                GUILayoutOption[] gUILayoutOptionArray33 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str31 = GUILayout.TextField(str30, gUILayoutOptionArray33).Trim();
                object obj15 = str31;
                objArray15[47] = str31;
                GUILayoutOption[] gUILayoutOptionArray34 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj15, gUILayoutOptionArray34);
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                object[] objArray16 = FengGameManagerMKII.settingsRC;
                string str32 = (string)FengGameManagerMKII.settingsRC[48];
                GUILayoutOption[] gUILayoutOptionArray35 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                string str33 = GUILayout.TextField(str32, gUILayoutOptionArray35).Trim();
                object obj16 = str33;
                objArray16[48] = str33;
                GUILayoutOption[] gUILayoutOptionArray36 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                F1GUI.Tab.ViewImageButtonLayout(obj16, gUILayoutOptionArray36);
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
                GUI.EndScrollView();
            }

            protected internal void Map()
            {

Current member / type: System.Void RedSkies.F1GUI/Tab::Map()
File path: C:\Users\Mark\Downloads\Assembly-CSharp.dll

Product version: 2014.1.225.0
Exception in: System.Void Map()

Object reference not set to an instance of an object.
at ..( , Int32 , & , Int32& ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatterns\ObjectInitialisationPattern.cs:line 78
at ..( , Int32& , & , Int32& ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatterns\BaseInitialisationPattern.cs:line 33
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 60
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 363
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 67
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..Visit[,]( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 288
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 319
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 339
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 36
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ,  ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 30
at ..(MethodBody , ILanguage ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 83
at ..( , ILanguage , MethodBody , & ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\Extensions.cs:line 99
at ..(MethodBody , ILanguage , & ,  ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\Extensions.cs:line 62
at ..(ILanguage , MethodDefinition ,  ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 116

========================================================================
Please update to the latest version of JustDecompile and then try again.
Get latest version.

            }

            protected internal void Rebinds()
            {
                int num;
                int i = 0;
                bool flag = false;
                F1GUI.scroll = GUI.BeginScrollView(new Rect(5f, 80f, 257f, 480f), F1GUI.scroll, new Rect(5f, 80f, 200f, 775f), false, false);
                F1GUI.heightPos = 80f;
                if (GUI.Button(new Rect(10f, F1GUI.heightPos, 227f, 20f), string.Empty))
                {
                    if (F1GUI.currentPage != 2)
                    {
                        F1GUI.currentPage = F1GUI.currentPage + 1;
                    }
                    else
                    {
                        F1GUI.currentPage = 0;
                    }
                }
                switch (F1GUI.currentPage)
                {
                    case 0:
                    {
                        Rect rect = new Rect(10f, F1GUI.heightPos, 227f, 20f);
                        GUIStyle gUIStyle = new GUIStyle("Label");
                        gUIStyle.set_alignment(4);
                        GUI.Label(rect, "Rebinds: Human", gUIStyle);
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        F1GUI.OnGUIKeyCodeRC(97, 98, new Rect(10f, F1GUI.heightPos, 145f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), new Rect(110f, F1GUI.heightPos, 80f, 20f), 98, "Reel In:");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        F1GUI.OnGUIKeyCodeRC(116, 99, new Rect(10f, F1GUI.heightPos, 145f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), new Rect(110f, F1GUI.heightPos, 80f, 20f), 99, "Reel Out:");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        F1GUI.OnGUIKeyCodeRC(181, 182, new Rect(10f, F1GUI.heightPos, 145f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), new Rect(110f, F1GUI.heightPos, 80f, 20f), 182, "Gas Burst:");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        F1GUI.InputKeyCode(new Rect(10f, F1GUI.heightPos, 145f, 20f), new Rect(110f, F1GUI.heightPos, 80f, 20f), "Minimap Max:", 232);
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        F1GUI.InputKeyCode(new Rect(10f, F1GUI.heightPos, 145f, 20f), new Rect(110f, F1GUI.heightPos, 80f, 20f), "Minimap Toggle:", 233);
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        F1GUI.InputKeyCode(new Rect(10f, F1GUI.heightPos, 145f, 20f), new Rect(110f, F1GUI.heightPos, 80f, 20f), "Minimap Reset:", 234);
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        break;
                    }
                    case 1:
                    {
                        Rect rect1 = new Rect(10f, F1GUI.heightPos, 227f, 20f);
                        GUIStyle gUIStyle1 = new GUIStyle("Label");
                        gUIStyle1.set_alignment(4);
                        GUI.Label(rect1, "Rebinds: Player Titan", gUIStyle1);
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Forward:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Back:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Left:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Right:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Walk:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Jump:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Punch:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Slam:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Grab (front):", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Grab (back):", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Grab (nape):", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Slap:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Bite:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Cover Nape:", "Label");
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Rock Throw:", "Label");
                        if (GUI.Button(new Rect(110f, F1GUI.heightPos, 80f, 20f), FengGameManagerMKII.settingsSkin[94]))
                        {
                            FengGameManagerMKII.settingsSkin[94] = "waiting...";
                            FengGameManagerMKII.settingsRC[100] = "rock";
                        }
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 20f), "Meteor Crash:", "Label");
                        if (GUI.Button(new Rect(110f, F1GUI.heightPos, 80f, 20f), FengGameManagerMKII.settingsSkin[95]))
                        {
                            FengGameManagerMKII.settingsSkin[95] = "waiting...";
                            FengGameManagerMKII.settingsRC[100] = "meteor";
                        }
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        GUI.Label(new Rect(10f, F1GUI.heightPos, 145f, 22f), "Laugh:", "Label");
                        if (GUI.Button(new Rect(110f, F1GUI.heightPos, 80f, 20f), FengGameManagerMKII.settingsSkin[96]))
                        {
                            FengGameManagerMKII.settingsSkin[96] = "waiting...";
                            FengGameManagerMKII.settingsRC[100] = "laugh";
                        }
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        for (i = 0; i < 14; i++)
                        {
                            float single = 105f + 25f * (float)i;
                            num = 101 + i;
                            if (GUI.Button(new Rect(110f, single, 80f, 20f), (string)FengGameManagerMKII.settingsRC[num]))
                            {
                                FengGameManagerMKII.settingsRC[num] = "waiting...";
                                FengGameManagerMKII.settingsRC[100] = num.ToString();
                            }
                        }
                        break;
                    }
                    case 2:
                    {
                        Rect rect2 = new Rect(10f, F1GUI.heightPos, 227f, 20f);
                        GUIStyle gUIStyle2 = new GUIStyle("Label");
                        gUIStyle2.set_alignment(4);
                        GUI.Label(rect2, "Rebinds: Cannon", gUIStyle2);
                        F1GUI.heightPos = F1GUI.heightPos + 25f;
                        List<string> strs = new List<string>()
                        {
                            "Rotate Up:",
                            "Rotate Down:",
                            "Rotate Left:",
                            "Rotate Right:",
                            "Fire:",
                            "Mount:",
                            "Slow Rotate:"
                        };
                        List<string> strs1 = strs;
                        for (i = 0; i < strs1.Count; i++)
                        {
                            GUI.Label(new Rect(10f, F1GUI.heightPos + (float)i * 25f, 145f, 22f), strs1[i], "Label");
                        }
                        for (i = 0; i < 7; i++)
                        {
                            int num1 = 254 + i;
                            if (GUI.Button(new Rect(110f, F1GUI.heightPos + (float)i * 25f, 80f, 20f), (string)FengGameManagerMKII.settingsRC[num1]))
                            {
                                FengGameManagerMKII.settingsRC[num1] = "waiting...";
                                FengGameManagerMKII.settingsRC[100] = num1.ToString();
                            }
                        }
                        F1GUI.heightPos = F1GUI.heightPos + 175f;
                        break;
                    }
                }
                if ((string)FengGameManagerMKII.settingsRC[100] != "0")
                {
                    Event _current = Event.current;
                    flag = false;
                    string str = "waiting...";
                    if (_current.type == 4 && _current.keyCode != null)
                    {
                        flag = true;
                        str = _current.keyCode.ToString();
                    }
                    else if (Input.GetKey(304))
                    {
                        flag = true;
                        str = (KeyCode)304.ToString();
                    }
                    else if (Input.GetKey(303))
                    {
                        flag = true;
                        str = (KeyCode)303.ToString();
                    }
                    else if (Input.GetAxis("Mouse ScrollWheel") == 0f)
                    {
                        for (i = 0; i < 7; i++)
                        {
                            if (Input.GetKeyDown(323 + i))
                            {
                                flag = true;
                                str = string.Concat("Mouse", Convert.ToString(i));
                            }
                        }
                    }
                    else if (Input.GetAxis("Mouse ScrollWheel") <= 0f)
                    {
                        flag = true;
                        str = "Scroll Down";
                    }
                    else
                    {
                        flag = true;
                        str = "Scroll Up";
                    }
                    if (flag)
                    {
                        string str1 = (string)FengGameManagerMKII.settingsRC[100];
                        string str2 = str1;
                        if (str1 != null)
                        {
                            switch (str2)
                            {
                                case "rock":
                                {
                                    FengGameManagerMKII.settingsSkin[94] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.titanRockThrow, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                                case "meteor":
                                {
                                    FengGameManagerMKII.settingsSkin[95] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.titanMeteor, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                                case "laugh":
                                {
                                    FengGameManagerMKII.settingsSkin[96] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.titanLaugh, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                                case "98":
                                {
                                    FengGameManagerMKII.settingsRC[98] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.reelin, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                                case "99":
                                {
                                    FengGameManagerMKII.settingsRC[99] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.reelout, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                                case "182":
                                {
                                    FengGameManagerMKII.settingsRC[182] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.dash, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                                case "232":
                                {
                                    FengGameManagerMKII.settingsRC[232] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.mapMaximize, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                                case "233":
                                {
                                    FengGameManagerMKII.settingsRC[233] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.mapToggle, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                                case "234":
                                {
                                    FengGameManagerMKII.settingsRC[234] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.mapReset, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                                case "236":
                                {
                                    FengGameManagerMKII.settingsRC[236] = str;
                                    FengGameManagerMKII.settingsRC[100] = "0";
                                    InputCodeRC.setInputHuman(InputCodeRC.chat, str);
                                    GUI.EndScrollView();
                                    return;
                                }
                            }
                        }
                        if (int.TryParse((string)FengGameManagerMKII.settingsRC[100], out num))
                        {
                            FengGameManagerMKII.settingsRC[num] = str;
                            FengGameManagerMKII.settingsRC[100] = "0";
                            if (num.InBetween(254, 260))
                            {
                                InputCodeRC.setInputCannon(num - 254, str);
                            }
                            else if (!num.InBetween(232, 234))
                            {
                                InputCodeRC.setInputTitan(num - 101, str);
                            }
                            else
                            {
                                InputCodeRC.setInputHuman(num - 254, str);
                            }
                        }
                    }
                }
                GUI.EndScrollView();
            }

            protected internal void RevivedSettings()
            {
                string str = "0";
                string str1 = str;
                FengGameManagerMKII.settingsSkin[92] = str;
                FengGameManagerMKII.settingsSkin[91] = str1;
                GUI.TextArea(new Rect(10f, 80f, 270f, 30f), "Settings revived!", 100, "Label");
                if (GUI.Button(new Rect(10f, 127f, 227f, 20f), "CLOSE"))
                {
                    FengGameManagerMKII.settings[82] = false;
                    FengGameManagerMKII.settingsSkin[64] = "0";
                    F1GUI.scroll = Vector2.zero;
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
                    int num = 0;
                    IN_GAME_MAIN_CAMERA.isPausing = (bool)num;
                    IN_GAME_MAIN_CAMERA.isTyping = (bool)num;
                    FengGameManagerMKII.settings[22] = (bool)num;
                }
            }

            protected internal void SavedSettings()
            {
                string str = "0";
                string str1 = str;
                FengGameManagerMKII.settingsSkin[92] = str;
                FengGameManagerMKII.settingsSkin[91] = str1;
                GUI.TextArea(new Rect(10f, 80f, 270f, 30f), "Settings saved!", 100, "Label");
                if (GUI.Button(new Rect(10f, 127f, 227f, 20f), "CLOSE"))
                {
                    FengGameManagerMKII.settings[82] = false;
                    FengGameManagerMKII.settingsSkin[64] = "0";
                    F1GUI.scroll = Vector2.zero;
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
                    int num = 0;
                    IN_GAME_MAIN_CAMERA.isPausing = (bool)num;
                    IN_GAME_MAIN_CAMERA.isTyping = (bool)num;
                    FengGameManagerMKII.settings[22] = (bool)num;
                }
            }

            protected internal void SingleGamemodes()
            {
                int num;
                float single = 260f - F1GUI.scroll.y;
                GUI.backgroundColor = (Color.Lerp(Color.get_white(), Color.get_gray(), 0.3f));
                if (FengGameManagerMKII.settingsSkin[91] != "2" && single >= 80f && single < 527f)
                {
                    GUI.Label(new Rect(5f, single, 237f, 20f), "GAMEMODES", "Button");
                }
                GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                F1GUI.scroll = GUI.BeginScrollView(new Rect(5f, 80f, 257f, 480f), F1GUI.scroll, new Rect(5f, 80f, 200f, 740f), false, true);
                GUI.Label(new Rect(10f, 90f, 185f, 40f), "SINGLE GAMEMODES", "Label");
                if (FengGameManagerMKII.settingsSkin[91] == "2")
                {
                    GUI.backgroundColor = (new Color(0f, 0f, 0f, 1f));
                }
                if (GUI.Button(new Rect(10f, 135f, 150f, 20f), "CHARACTER"))
                {
                    if (FengGameManagerMKII.settingsSkin[91] == "2")
                    {
                        FengGameManagerMKII.settingsSkin[91] = "0";
                    }
                    else
                    {
                        FengGameManagerMKII.settingsSkin[91] = "2";
                        FengGameManagerMKII.settingsSkin[92] = "0";
                    }
                }
                if (FengGameManagerMKII.settingsSkin[91] == "2")
                {
                    GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                }
                GUI.Label(new Rect(165f, 135f, 175f, 20f), string.Concat("<size=10.5>", IN_GAME_MAIN_CAMERA.singleCharacter, "</size>"), "Label");
                if (FengGameManagerMKII.settingsSkin[91] != "2")
                {
                    GUI.Label(new Rect(10f, 160f, 210f, 20f), "Daylight:", "Label");
                    if (GUI.Button(new Rect(10f, 185f, 100f, 20f), IN_GAME_MAIN_CAMERA.dayLight.ToString()))
                    {
                        if (IN_GAME_MAIN_CAMERA.dayLight < DayLight.Sketch)
                        {
                            IN_GAME_MAIN_CAMERA.dayLight = (DayLight)((int)IN_GAME_MAIN_CAMERA.dayLight + (int)DayLight.Dawn);
                        }
                        else
                        {
                            IN_GAME_MAIN_CAMERA.dayLight = DayLight.Day;
                        }
                        IN_GAME_MAIN_CAMERA.mainCamera.setDayLight(IN_GAME_MAIN_CAMERA.dayLight);
                    }
                    GUI.Label(new Rect(10f, 210f, 210f, 20f), "Difficulty:", "Label");
                    if (GUI.Button(new Rect(10f, 235f, 100f, 20f), F1GUI.singledifficulty(IN_GAME_MAIN_CAMERA.difficulty)))
                    {
                        if (IN_GAME_MAIN_CAMERA.difficulty < 2)
                        {
                            IN_GAME_MAIN_CAMERA.difficulty = IN_GAME_MAIN_CAMERA.difficulty + 1;
                        }
                        else
                        {
                            IN_GAME_MAIN_CAMERA.difficulty = -1;
                        }
                    }
                    F1GUI.heightPos = 285f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 210f, 20f), "SPEEDRUN <size=11>(in seconds::0 is off)</size>:", "Label");
                    InRoomChat.duelKills = Convert.ToInt32(GUI.TextField(new Rect(200f, F1GUI.heightPos, 40f, 20f), InRoomChat.duelKills.ToString()));
                    FengGameManagerMKII.settings[0] = InRoomChat.duelKills > 0;
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 210f, 20f), "Only Spawn:", "Label");
                    int num1 = (int)FengGameManagerMKII.settings[113];
                    if (GUI.Button(new Rect(140f, F1GUI.heightPos, 100f, 20f), F1GUI.abnormalType(num1)))
                    {
                        if (num1 < 4)
                        {
                            FengGameManagerMKII.settings[113] = num1 + 1;
                        }
                        else
                        {
                            FengGameManagerMKII.settings[113] = -1;
                        }
                    }
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    F1GUI.OnGUISINGLE(11, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "ENDLESS", false);
                    F1GUI.OnGUISINGLE(6, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "HEATBLAZE", false);
                    F1GUI.OnGUISINGLE(7, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "ICEFIELDS", false);
                    F1GUI.OnGUISINGLE(108, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "NO ABERRANT", false);
                    F1GUI.OnGUISINGLE(1, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "NO CRAWLER", false);
                    F1GUI.OnGUISINGLE(107, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "NO JUMPER", false);
                    F1GUI.OnGUISINGLE(31, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "NO PUNKS", false);
                    F1GUI.OnGUISINGLE(109, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "NO NORMAL", false);
                    F1GUI.OnGUISINGLE(10, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "SHIFTER TITANS", false);
                    F1GUI.OnGUISINGLE(23, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "TELEPORTING TITANS", false);
                    F1GUI.OnGUISINGLE(28, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "UNTOUCHABLE", false);
                    F1GUI.OnGUISINGLE(9, new Rect(10f, F1GUI.heightPos, 175f, 20f), new Rect(200f, F1GUI.heightPos, 40f, 20f), "ZERO-G CRAWLERS", false);
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 190f, 20f), "RESPAWN (0 is off):");
                    if (!int.TryParse(GUI.TextField(new Rect(200f, F1GUI.heightPos, 40f, 20f), FengGameManagerMKII.settingsGame[24].ToString()), out num) || num <= 0)
                    {
                        FengGameManagerMKII.settingsGame[24] = 0;
                    }
                    else
                    {
                        FengGameManagerMKII.settingsGame[24] = Mathf.Max(1, num);
                    }
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 190f, 20f), "50 WAVES (0 & 20 is off):");
                    object[] objArray = FengGameManagerMKII.settings;
                    Rect rect = new Rect(200f, F1GUI.heightPos, 40f, 20f);
                    int num2 = (int)FengGameManagerMKII.settings[15];
                    objArray[15] = Convert.ToInt32(GUI.TextField(rect, num2.ToString()));
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 190f, 20f), "NAPE DAMAGE:");
                    FengGameManagerMKII.settingsGame[9] = Convert.ToInt32(GUI.TextField(new Rect(200f, F1GUI.heightPos, 40f, 20f), FengGameManagerMKII.settingsGame[9].ToString()));
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 190f, 20f), "Titan Size (0 is off):");
                    GUI.Label(new Rect(185f, F1GUI.heightPos, 15f, 20f), "to", "Label");
                    Rect rect1 = new Rect(200f, F1GUI.heightPos, 40f, 20f);
                    Rect rect2 = new Rect(141f, F1GUI.heightPos, 40f, 20f);
                    float single1 = InRoomChat.titanSizes;
                    float single2 = Convert.ToSingle(GUI.TextField(rect2, single1.ToString()));
                    InRoomChat.titanSizes = single2;
                    float single3 = Mathf.Max(single2, InRoomChat.titanSizes2);
                    InRoomChat.titanSizes2 = Convert.ToSingle(GUI.TextField(rect1, single3.ToString()));
                    if (InRoomChat.titanSizes <= 0f)
                    {
                        RCSettings.sizeMode = 0;
                    }
                    else
                    {
                        RCSettings.sizeMode = 1;
                    }
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 190f, 20f), "ANNIE APOCALYPSE:");
                    GUI.Label(new Rect(150f, F1GUI.heightPos, 190f, 20f), "<size=11>Nape HP</size>:");
                    object[] objArray1 = FengGameManagerMKII.settings;
                    Rect rect3 = new Rect(200f, F1GUI.heightPos, 40f, 20f);
                    int num3 = (int)FengGameManagerMKII.settings[58];
                    objArray1[58] = Convert.ToInt32(GUI.TextField(rect3, num3.ToString()));
                    FengGameManagerMKII.settings[16] = (int)FengGameManagerMKII.settings[58] > 0;
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 190f, 20f), "NUMBERLOCK (0 is off):");
                    object[] objArray2 = FengGameManagerMKII.settings;
                    Rect rect4 = new Rect(200f, F1GUI.heightPos, 40f, 20f);
                    int num4 = (int)FengGameManagerMKII.settings[87];
                    objArray2[87] = Convert.ToInt32(GUI.TextField(rect4, num4.ToString()));
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                    GUI.Label(new Rect(10f, F1GUI.heightPos, 190f, 20f), "HEALTH:");
                    GUI.Label(new Rect(185f, F1GUI.heightPos, 15f, 20f), "to");
                    if (GUI.Button(new Rect(75f, F1GUI.heightPos, 60f, 20f), (RCSettings.healthMode == 2 ? "scaled" : "fixed")))
                    {
                        if (RCSettings.healthMode == 2)
                        {
                            RCSettings.healthMode = 1;
                        }
                        else
                        {
                            RCSettings.healthMode = 2;
                        }
                    }
                    Rect rect5 = new Rect(200f, F1GUI.heightPos, 40f, 20f);
                    Rect rect6 = new Rect(141f, F1GUI.heightPos, 40f, 20f);
                    int num5 = RCSettings.healthLower;
                    int num6 = Convert.ToInt32(GUI.TextField(rect6, num5.ToString()));
                    RCSettings.healthLower = num6;
                    int num7 = Mathf.Max(num6, RCSettings.healthUpper);
                    RCSettings.healthUpper = Convert.ToInt32(GUI.TextField(rect5, num7.ToString()));
                    F1GUI.heightPos = F1GUI.heightPos + 25f;
                }
                else
                {
                    GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                    F1GUI.SelectionGrid(3);
                }
                GUI.EndScrollView();
            }

            protected internal void Sky()
            {
                GUI.backgroundColor = (Color.Lerp(Color.get_white(), Color.get_gray(), 0.3f));
                float single = 80f - F1GUI.scroll.y;
                float single1 = 415f - F1GUI.scroll.y;
                float single2 = 745f - F1GUI.scroll.y;
                if (single >= 80f && single < 527f)
                {
                    GUI.Label(new Rect(5f, single, 237f, 20f), "Custom Map Skies", "Button");
                }
                if (single1 >= 80f && single1 < 527f)
                {
                    GUI.Label(new Rect(5f, single1, 237f, 20f), "Forest Map Skies", "Button");
                }
                if (single2 >= 80f && single2 < 527f)
                {
                    GUI.Label(new Rect(5f, single2, 237f, 20f), "City Map Skies", "Button");
                }
                GUI.backgroundColor = (new Color(0f, 1f, 1f, 1f));
                F1GUI.scroll = GUI.BeginScrollView(new Rect(5f, 80f, 257f, 480f), F1GUI.scroll, new Rect(5f, 80f, 310f, 1000f), true, true);
                GUI.Label(new Rect(10f, 105f, 150f, 20f), "Skybox Front:", "Label");
                Rect rect = new Rect(155f, 130f, 80f, 20f);
                object[] objArray = FengGameManagerMKII.settingsRC;
                string str = GUI.TextField(new Rect(10f, 130f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[175]).Trim();
                object obj = str;
                objArray[175] = str;
                F1GUI.Tab.ViewImageButton(rect, obj);
                GUI.Label(new Rect(10f, 155f, 150f, 20f), "Skybox Back:", "Label");
                Rect rect1 = new Rect(155f, 180f, 80f, 20f);
                object[] objArray1 = FengGameManagerMKII.settingsRC;
                string str1 = GUI.TextField(new Rect(10f, 180f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[176]).Trim();
                object obj1 = str1;
                objArray1[176] = str1;
                F1GUI.Tab.ViewImageButton(rect1, obj1);
                GUI.Label(new Rect(10f, 205f, 150f, 20f), "Skybox Left:", "Label");
                Rect rect2 = new Rect(155f, 230f, 80f, 20f);
                object[] objArray2 = FengGameManagerMKII.settingsRC;
                string str2 = GUI.TextField(new Rect(10f, 230f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[177]).Trim();
                object obj2 = str2;
                objArray2[177] = str2;
                F1GUI.Tab.ViewImageButton(rect2, obj2);
                GUI.Label(new Rect(10f, 255f, 150f, 20f), "Skybox Right:", "Label");
                Rect rect3 = new Rect(155f, 280f, 80f, 20f);
                object[] objArray3 = FengGameManagerMKII.settingsRC;
                string str3 = GUI.TextField(new Rect(10f, 280f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[178]).Trim();
                object obj3 = str3;
                objArray3[178] = str3;
                F1GUI.Tab.ViewImageButton(rect3, obj3);
                GUI.Label(new Rect(10f, 305f, 150f, 20f), "Skybox Up:", "Label");
                Rect rect4 = new Rect(155f, 330f, 80f, 20f);
                object[] objArray4 = FengGameManagerMKII.settingsRC;
                string str4 = GUI.TextField(new Rect(10f, 330f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[179]).Trim();
                object obj4 = str4;
                objArray4[179] = str4;
                F1GUI.Tab.ViewImageButton(rect4, obj4);
                GUI.Label(new Rect(10f, 355f, 150f, 20f), "Skybox Down:", "Label");
                Rect rect5 = new Rect(155f, 380f, 80f, 20f);
                object[] objArray5 = FengGameManagerMKII.settingsRC;
                string str5 = GUI.TextField(new Rect(10f, 380f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[180]).Trim();
                object obj5 = str5;
                objArray5[180] = str5;
                F1GUI.Tab.ViewImageButton(rect5, obj5);
                GUI.Label(new Rect(10f, 440f, 150f, 20f), "Skybox Front:", "Label");
                Rect rect6 = new Rect(155f, 465f, 80f, 20f);
                object[] objArray6 = FengGameManagerMKII.settingsRC;
                string str6 = GUI.TextField(new Rect(10f, 465f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[163]).Trim();
                object obj6 = str6;
                objArray6[163] = str6;
                F1GUI.Tab.ViewImageButton(rect6, obj6);
                GUI.Label(new Rect(10f, 490f, 150f, 20f), "Skybox Back:", "Label");
                Rect rect7 = new Rect(155f, 515f, 80f, 20f);
                object[] objArray7 = FengGameManagerMKII.settingsRC;
                string str7 = GUI.TextField(new Rect(10f, 515f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[164]).Trim();
                object obj7 = str7;
                objArray7[164] = str7;
                F1GUI.Tab.ViewImageButton(rect7, obj7);
                GUI.Label(new Rect(10f, 540f, 150f, 20f), "Skybox Left:", "Label");
                Rect rect8 = new Rect(155f, 565f, 80f, 20f);
                object[] objArray8 = FengGameManagerMKII.settingsRC;
                string str8 = GUI.TextField(new Rect(10f, 565f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[165]).Trim();
                object obj8 = str8;
                objArray8[165] = str8;
                F1GUI.Tab.ViewImageButton(rect8, obj8);
                GUI.Label(new Rect(10f, 590f, 150f, 20f), "Skybox Right:", "Label");
                Rect rect9 = new Rect(155f, 615f, 80f, 20f);
                object[] objArray9 = FengGameManagerMKII.settingsRC;
                string str9 = GUI.TextField(new Rect(10f, 615f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[166]).Trim();
                object obj9 = str9;
                objArray9[166] = str9;
                F1GUI.Tab.ViewImageButton(rect9, obj9);
                GUI.Label(new Rect(10f, 640f, 150f, 20f), "Skybox Up:", "Label");
                Rect rect10 = new Rect(155f, 665f, 80f, 20f);
                object[] objArray10 = FengGameManagerMKII.settingsRC;
                string str10 = GUI.TextField(new Rect(10f, 665f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[167]).Trim();
                object obj10 = str10;
                objArray10[167] = str10;
                F1GUI.Tab.ViewImageButton(rect10, obj10);
                GUI.Label(new Rect(10f, 690f, 150f, 20f), "Skybox Down:", "Label");
                Rect rect11 = new Rect(155f, 710f, 80f, 20f);
                object[] objArray11 = FengGameManagerMKII.settingsRC;
                string str11 = GUI.TextField(new Rect(10f, 710f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[168]).Trim();
                object obj11 = str11;
                objArray11[168] = str11;
                F1GUI.Tab.ViewImageButton(rect11, obj11);
                GUI.Label(new Rect(10f, 770f, 150f, 20f), "Skybox Front:", "Label");
                Rect rect12 = new Rect(155f, 795f, 80f, 20f);
                object[] objArray12 = FengGameManagerMKII.settingsRC;
                string str12 = GUI.TextField(new Rect(10f, 795f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[169]).Trim();
                object obj12 = str12;
                objArray12[169] = str12;
                F1GUI.Tab.ViewImageButton(rect12, obj12);
                GUI.Label(new Rect(10f, 820f, 150f, 20f), "Skybox Back:", "Label");
                Rect rect13 = new Rect(155f, 845f, 80f, 20f);
                object[] objArray13 = FengGameManagerMKII.settingsRC;
                string str13 = GUI.TextField(new Rect(10f, 845f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[170]).Trim();
                object obj13 = str13;
                objArray13[170] = str13;
                F1GUI.Tab.ViewImageButton(rect13, obj13);
                GUI.Label(new Rect(10f, 870f, 150f, 20f), "Skybox Left:", "Label");
                Rect rect14 = new Rect(155f, 895f, 80f, 20f);
                object[] objArray14 = FengGameManagerMKII.settingsRC;
                string str14 = GUI.TextField(new Rect(10f, 895f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[171]).Trim();
                object obj14 = str14;
                objArray14[171] = str14;
                F1GUI.Tab.ViewImageButton(rect14, obj14);
                GUI.Label(new Rect(10f, 920f, 150f, 20f), "Skybox Right:", "Label");
                Rect rect15 = new Rect(155f, 945f, 80f, 20f);
                object[] objArray15 = FengGameManagerMKII.settingsRC;
                string str15 = GUI.TextField(new Rect(10f, 945f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[172]).Trim();
                object obj15 = str15;
                objArray15[172] = str15;
                F1GUI.Tab.ViewImageButton(rect15, obj15);
                GUI.Label(new Rect(10f, 970f, 150f, 20f), "Skybox Up:", "Label");
                Rect rect16 = new Rect(155f, 995f, 80f, 20f);
                object[] objArray16 = FengGameManagerMKII.settingsRC;
                string str16 = GUI.TextField(new Rect(10f, 995f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[173]).Trim();
                object obj16 = str16;
                objArray16[173] = str16;
                F1GUI.Tab.ViewImageButton(rect16, obj16);
                GUI.Label(new Rect(10f, 1020f, 150f, 20f), "Skybox Down:", "Label");
                Rect rect17 = new Rect(155f, 1045f, 80f, 20f);
                object[] objArray17 = FengGameManagerMKII.settingsRC;
                string str17 = GUI.TextField(new Rect(10f, 1045f, 145f, 20f), (string)FengGameManagerMKII.settingsRC[174]).Trim();
                object obj17 = str17;
                objArray17[174] = str17;
                F1GUI.Tab.ViewImageButton(rect17, obj17);
                GUI.EndScrollView();
            }

            protected internal void Titan()
            {
                int i;
                int num;
                int str;
                int num1;
                GUILayout.BeginArea(new Rect(5f, 80f, 257f, 480f));
                float single = (F1GUI.currentPage == 0 ? 725f : 1330f);
                F1GUI.scroll = GUI.BeginScrollView(new Rect(0f, 0f, 257f, 480f), F1GUI.scroll, new Rect(0f, 0f, 200f, single), false, true);
                GUILayout.BeginArea(new Rect(2f, 0f, 232f, single));
                F1GUI.ToggleLayout("Titan Skin Mode:", () => (string)FengGameManagerMKII.settingsRC[1] == "1", (bool on) => FengGameManagerMKII.settingsRC[1] = (on ? "1" : "0"), new Vector2?(new Vector2(185f, 0f)), new Vector2?(new Vector2(40f, 20f)));
                F1GUI.ToggleLayout("Randomized Pairs:", () => (string)FengGameManagerMKII.settingsRC[32] == "1", (bool on) => FengGameManagerMKII.settingsRC[32] = (on ? "1" : "0"), new Vector2?(new Vector2(185f, 0f)), new Vector2?(new Vector2(40f, 20f)));
                GUILayout.Label("Titan Hair:", new GUILayoutOption[0]);
                for (i = 21; i < 26; i++)
                {
                    str = i - 5;
                    GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                    object[] objArray = FengGameManagerMKII.settingsRC;
                    string str1 = (string)FengGameManagerMKII.settingsRC[i];
                    GUILayoutOption[] gUILayoutOptionArray = new GUILayoutOption[] { GUILayout.Width(162f), GUILayout.Height(20f) };
                    objArray[i] = GUILayout.TextField(str1, gUILayoutOptionArray).Trim();
                    string str2 = F1GUI.hairtype((string)FengGameManagerMKII.settingsRC[str]);
                    GUILayoutOption[] gUILayoutOptionArray1 = new GUILayoutOption[] { GUILayout.Width(60f), GUILayout.Height(20f) };
                    if (GUILayout.Button(str2, gUILayoutOptionArray1))
                    {
                        if (!int.TryParse((string)FengGameManagerMKII.settingsRC[str], out num1))
                        {
                            FengGameManagerMKII.settingsRC[str] = "-1";
                        }
                        else
                        {
                            num1 = (num1 < 9 ? num1 + 1 : -1);
                            FengGameManagerMKII.settingsRC[str] = num1.ToString();
                        }
                    }
                    GUILayout.EndHorizontal();
                    GUIStyle gUIStyle = new GUIStyle("Button");
                    gUIStyle.set_alignment(4);
                    if (GUILayout.Button("View Image", gUIStyle, new GUILayoutOption[0]))
                    {
                        F1GUI.Tab.myGUI.StartCoroutine(F1GUI.LoadImageE((string)FengGameManagerMKII.settingsRC[i]));
                    }
                }
                GUILayout.Label("Titan Eye:", new GUILayoutOption[0]);
                for (i = 26; i < 31; i++)
                {
                    GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                    object[] objArray1 = FengGameManagerMKII.settingsRC;
                    string str3 = (string)FengGameManagerMKII.settingsRC[i];
                    GUILayoutOption[] gUILayoutOptionArray2 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                    string str4 = GUILayout.TextField(str3, gUILayoutOptionArray2).Trim();
                    object obj = str4;
                    objArray1[i] = str4;
                    GUILayoutOption[] gUILayoutOptionArray3 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                    F1GUI.Tab.ViewImageButtonLayout(obj, gUILayoutOptionArray3);
                    GUILayout.EndHorizontal();
                }
                GUILayout.Label("Titan Body:", new GUILayoutOption[0]);
                for (i = 86; i < 91; i++)
                {
                    GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                    object[] objArray2 = FengGameManagerMKII.settingsRC;
                    string str5 = (string)FengGameManagerMKII.settingsRC[i];
                    GUILayoutOption[] gUILayoutOptionArray4 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                    string str6 = GUILayout.TextField(str5, gUILayoutOptionArray4).Trim();
                    object obj1 = str6;
                    objArray2[i] = str6;
                    GUILayoutOption[] gUILayoutOptionArray5 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                    F1GUI.Tab.ViewImageButtonLayout(obj1, gUILayoutOptionArray5);
                    GUILayout.EndHorizontal();
                }
                GUIStyle gUIStyle1 = new GUIStyle("Label");
                gUIStyle1.set_alignment(4);
                gUIStyle1.set_wordWrap(true);
                GUILayoutOption[] gUILayoutOptionArray6 = new GUILayoutOption[] { GUILayout.Height(20f) };
                GUILayout.Label("Player ID (player to steal from) : ", gUIStyle1, gUILayoutOptionArray6);
                object[] objArray3 = FengGameManagerMKII.settings;
                string str7 = (string)FengGameManagerMKII.settings[89];
                GUILayoutOption[] gUILayoutOptionArray7 = new GUILayoutOption[] { GUILayout.Width(227f), GUILayout.Height(20f) };
                objArray3[89] = GUILayout.TextField(str7, gUILayoutOptionArray7).Trim();
                bool flag = int.TryParse((string)FengGameManagerMKII.settings[89], out num);
                if (!flag)
                {
                    FengGameManagerMKII.settings[89] = string.Empty;
                }
                string empty = string.Empty;
                GUILayoutOption[] gUILayoutOptionArray8 = new GUILayoutOption[] { GUILayout.Height(5f) };
                GUILayout.Label(empty, gUILayoutOptionArray8);
                GUILayoutOption[] gUILayoutOptionArray9 = new GUILayoutOption[] { GUILayout.Height(30f) };
                GUILayout.BeginHorizontal(gUILayoutOptionArray9);
                GUILayout.FlexibleSpace();
                GUIStyle gUIStyle2 = new GUIStyle("Button");
                gUIStyle2.set_alignment(4);
                gUIStyle2.set_wordWrap(true);
                GUILayoutOption[] gUILayoutOptionArray10 = new GUILayoutOption[] { GUILayout.Width(150f), GUILayout.Height(30f) };
                if (GUILayout.Button("Steal Skin", gUIStyle2, gUILayoutOptionArray10) && flag && (string)FengGameManagerMKII.settings[89] != string.Empty)
                {
                    List<string> strs = new List<string>();
                    F1GUI.stealSkin[0] = num.ToString();
                    for (i = 16; i < 31; i++)
                    {
                        F1GUI.stealSkin[i] = string.Empty;
                    }
                    for (i = 86; i < 91; i++)
                    {
                        F1GUI.stealSkin[i] = string.Empty;
                    }
                Label0:
                    foreach (TITAN titan in FengGameManagerMKII.titans)
                    {
                        if (titan.photonView.ownerId != num)
                        {
                            continue;
                        }
                        string[] strArrays = new string[] { titan.skinhairtype, titan.skinhair, titan.skineye, titan.skinbody };
                        string str8 = string.Join(",", strArrays);
                        if (strs.Count > 0 && strs.Contains(str8))
                        {
                            continue;
                        }
                        strs.Add(str8);
                        if (!titan.skinhairtype.IsNullOrWhiteSpace())
                        {
                            i = 16;
                            while (i < 21)
                            {
                                if (!(F1GUI.stealSkin[i] == string.Empty) || !(F1GUI.stealSkin[i] != titan.skinhairtype))
                                {
                                    i++;
                                }
                                else
                                {
                                    F1GUI.stealSkin[i] = titan.skinhairtype;
                                    break;
                                }
                            }
                        }
                        if (!titan.skinhair.IsNullOrWhiteSpace())
                        {
                            i = 21;
                            while (i < 26)
                            {
                                if (!(F1GUI.stealSkin[i] == string.Empty) || !(F1GUI.stealSkin[i] != titan.skinhair))
                                {
                                    i++;
                                }
                                else
                                {
                                    F1GUI.stealSkin[i] = titan.skinhair;
                                    break;
                                }
                            }
                        }
                        if (!titan.skineye.IsNullOrWhiteSpace())
                        {
                            i = 26;
                            while (i < 31)
                            {
                                if (!(F1GUI.stealSkin[i] == string.Empty) || !(F1GUI.stealSkin[i] != titan.skineye))
                                {
                                    i++;
                                }
                                else
                                {
                                    F1GUI.stealSkin[i] = titan.skineye;
                                    break;
                                }
                            }
                        }
                        if (titan.skinbody.IsNullOrWhiteSpace())
                        {
                            continue;
                        }
                        i = 86;
                        while (i < 91)
                        {
                            if (!(F1GUI.stealSkin[i] == string.Empty) || !(F1GUI.stealSkin[i] != titan.skinbody))
                            {
                                i++;
                            }
                            else
                            {
                                F1GUI.stealSkin[i] = titan.skinbody;
                                goto Label0;
                            }
                        }
                    }
                    for (i = 17; i < 21; i++)
                    {
                        if (F1GUI.stealSkin[i] == string.Empty && F1GUI.stealSkin[i] != F1GUI.stealSkin[i - 1])
                        {
                            F1GUI.stealSkin[i] = F1GUI.stealSkin[i - 1];
                        }
                    }
                    for (i = 22; i < 26; i++)
                    {
                        if (F1GUI.stealSkin[i] == string.Empty && F1GUI.stealSkin[i] != F1GUI.stealSkin[i - 1])
                        {
                            F1GUI.stealSkin[i] = F1GUI.stealSkin[i - 1];
                        }
                    }
                    for (i = 27; i < 31; i++)
                    {
                        if (F1GUI.stealSkin[i] == string.Empty && F1GUI.stealSkin[i] != F1GUI.stealSkin[i - 1])
                        {
                            F1GUI.stealSkin[i] = F1GUI.stealSkin[i - 1];
                        }
                    }
                    for (i = 87; i < 91; i++)
                    {
                        if (F1GUI.stealSkin[i] == string.Empty && F1GUI.stealSkin[i] != F1GUI.stealSkin[i - 1])
                        {
                            F1GUI.stealSkin[i] = F1GUI.stealSkin[i - 1];
                        }
                    }
                    F1GUI.currentPage = 1;
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                if (F1GUI.currentPage == 1)
                {
                    GUILayout.BeginVertical(new GUILayoutOption[0]);
                    string str9 = string.Concat("Stolen Skin: ID ", F1GUI.stealSkin[0]);
                    GUIStyle gUIStyle3 = new GUIStyle("Label");
                    gUIStyle3.set_alignment(4);
                    GUILayout.Label(str9, gUIStyle3, new GUILayoutOption[0]);
                    if (!GUILayout.Button("Apply", new GUILayoutOption[0]))
                    {
                        GUILayout.Label("Titan Hair:", new GUILayoutOption[0]);
                        for (i = 21; i < 26; i++)
                        {
                            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                            Dictionary<int, string> nums = F1GUI.stealSkin;
                            string item = F1GUI.stealSkin[i];
                            GUILayoutOption[] gUILayoutOptionArray11 = new GUILayoutOption[] { GUILayout.Width(162f), GUILayout.Height(20f) };
                            nums[i] = GUILayout.TextField(item, gUILayoutOptionArray11).Trim();
                            string str10 = F1GUI.hairtype(F1GUI.stealSkin[i - 5]);
                            GUILayoutOption[] gUILayoutOptionArray12 = new GUILayoutOption[] { GUILayout.Width(60f), GUILayout.Height(20f) };
                            if (GUILayout.Button(str10, gUILayoutOptionArray12))
                            {
                                str = 16;
                                if (!int.TryParse(F1GUI.stealSkin[str], out num1))
                                {
                                    F1GUI.stealSkin[str] = "-1";
                                }
                                else
                                {
                                    num1 = (num1 < 9 ? num1 + 1 : -1);
                                    F1GUI.stealSkin[str] = num1.ToString();
                                }
                            }
                            GUILayout.EndHorizontal();
                            GUIStyle gUIStyle4 = new GUIStyle("Button");
                            gUIStyle4.set_alignment(4);
                            if (GUILayout.Button("View Image", gUIStyle4, new GUILayoutOption[0]))
                            {
                                F1GUI.Tab.myGUI.StartCoroutine(F1GUI.LoadImageE(F1GUI.stealSkin[i]));
                            }
                        }
                        GUILayout.Label("Titan Eye:", new GUILayoutOption[0]);
                        for (i = 26; i < 31; i++)
                        {
                            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                            Dictionary<int, string> nums1 = F1GUI.stealSkin;
                            string item1 = F1GUI.stealSkin[i];
                            GUILayoutOption[] gUILayoutOptionArray13 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                            string str11 = GUILayout.TextField(item1, gUILayoutOptionArray13).Trim();
                            string str12 = str11;
                            nums1[i] = str11;
                            GUILayoutOption[] gUILayoutOptionArray14 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                            F1GUI.Tab.ViewImageButtonLayout(str12, gUILayoutOptionArray14);
                            GUILayout.EndHorizontal();
                        }
                        GUILayout.Label("Titan Body:", new GUILayoutOption[0]);
                        for (i = 86; i < 91; i++)
                        {
                            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
                            Dictionary<int, string> nums2 = F1GUI.stealSkin;
                            string item2 = F1GUI.stealSkin[i];
                            GUILayoutOption[] gUILayoutOptionArray15 = new GUILayoutOption[] { GUILayout.Width(145f), GUILayout.Height(20f) };
                            string str13 = GUILayout.TextField(item2, gUILayoutOptionArray15).Trim();
                            string str14 = str13;
                            nums2[i] = str13;
                            GUILayoutOption[] gUILayoutOptionArray16 = new GUILayoutOption[] { GUILayout.Width(80f), GUILayout.Height(20f) };
                            F1GUI.Tab.ViewImageButtonLayout(str14, gUILayoutOptionArray16);
                            GUILayout.EndHorizontal();
                        }
                    }
                    else
                    {
                        for (i = 16; i < 31; i++)
                        {
                            FengGameManagerMKII.settingsRC[i] = F1GUI.stealSkin[i].Trim();
                        }
                        for (i = 86; i < 91; i++)
                        {
                            FengGameManagerMKII.settingsRC[i] = F1GUI.stealSkin[i].Trim();
                        }
                        F1GUI.currentPage = 0;
                    }
                    GUILayout.EndVertical();
                }
                GUILayout.EndArea();
                GUI.EndScrollView();
                GUILayout.EndArea();
            }

            protected internal void UIName()
            {

Current member / type: System.Void RedSkies.F1GUI/Tab::UIName()
File path: C:\Users\Mark\Downloads\Assembly-CSharp.dll

Product version: 2014.1.225.0
Exception in: System.Void UIName()

Object reference not set to an instance of an object.
at ..( , Int32 , & , Int32& ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatterns\ObjectInitialisationPattern.cs:line 78
at ..( , Int32& , & , Int32& ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatterns\BaseInitialisationPattern.cs:line 33
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 60
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 363
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 67
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..Visit[,]( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 288
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 319
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 339
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 36
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 363
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 67
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..Visit[,]( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 288
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 319
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 339
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 36
at ..( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 61
at ..Visit( ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Ast\BaseCodeTransformer.cs:line 278
at ..( ,  ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Steps\CodePatternsStep.cs:line 30
at ..(MethodBody , ILanguage ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 83
at ..( , ILanguage , MethodBody , & ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\Extensions.cs:line 99
at ..(MethodBody , ILanguage , & ,  ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\Extensions.cs:line 62
at ..(ILanguage , MethodDefinition ,  ) in c:\Builds\245\Behemoth\ReleaseBranch Production Build\Sources\Decompiler\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 116

========================================================================
Please update to the latest version of JustDecompile and then try again.
Get latest version.

            }

            private static void ViewImageButton(Rect rect, int index)
            {
                GUIStyle gUIStyle = new GUIStyle("Button");
                gUIStyle.set_alignment(4);
                if (GUI.Button(rect, "View Image", gUIStyle))
                {
                    F1GUI.Tab.myGUI.StartCoroutine(F1GUI.LoadImageE((string)FengGameManagerMKII.settingsRC[index]));
                }
            }

            private static void ViewImageButton(Rect rect, string link)
            {
                GUIStyle gUIStyle = new GUIStyle("Button");
                gUIStyle.set_alignment(4);
                if (GUI.Button(rect, "View Image", gUIStyle))
                {
                    F1GUI.Tab.myGUI.StartCoroutine(F1GUI.LoadImageE(link));
                }
            }

            private static void ViewImageButton(Rect rect, object link)
            {
                GUIStyle gUIStyle = new GUIStyle("Button");
                gUIStyle.set_alignment(4);
                if (GUI.Button(rect, "View Image", gUIStyle))
                {
                    F1GUI.Tab.myGUI.StartCoroutine(F1GUI.LoadImageE((string)link));
                }
            }

            private static void ViewImageButtonLayout(int index, params GUILayoutOption[] layouts)
            {
                GUIStyle gUIStyle = new GUIStyle("Button");
                gUIStyle.set_alignment(4);
                if (GUILayout.Button("View Image", gUIStyle, layouts))
                {
                    F1GUI.Tab.myGUI.StartCoroutine(F1GUI.LoadImageE((string)FengGameManagerMKII.settingsRC[index]));
                }
            }

            private static void ViewImageButtonLayout(string link, params GUILayoutOption[] layouts)
            {
                GUIStyle gUIStyle = new GUIStyle("Button");
                gUIStyle.set_alignment(4);
                if (GUILayout.Button("View Image", gUIStyle, layouts))
                {
                    F1GUI.Tab.myGUI.StartCoroutine(F1GUI.LoadImageE(link));
                }
            }

            private static void ViewImageButtonLayout(object link, params GUILayoutOption[] layouts)
            {
                GUIContent gUIContent = new GUIContent("View Image");
                GUIStyle gUIStyle = new GUIStyle("Button");
                gUIStyle.set_alignment(4);
                if (GUILayout.Button(gUIContent, gUIStyle, layouts))
                {
                    F1GUI.Tab.myGUI.StartCoroutine(F1GUI.LoadImageE((string)link));
                }
            }
        }*/
    }
}