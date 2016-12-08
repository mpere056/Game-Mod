using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace RedSkies
{
    internal class F3GUI : MonoBehaviour, MenuGUI
    {
        private string deletionLink;

        private string imageLink;

        private Vector2 scroll = Vector3.zero;

        public F3GUI()
        {
        }

        private void Awake()
        {
            UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
        }

        private void OnDisable()
        {
            if (FengGameManagerMKII.settings != null && (int)FengGameManagerMKII.settings.Length > 0)
            {
                FengGameManagerMKII.settings[82] = false;
                if (!IN_GAME_MAIN_CAMERA.isPausing && IN_GAME_MAIN_CAMERA.isTyping)
                {
                    this.scroll = Vector2.zero;
                    IN_GAME_MAIN_CAMERA.isTyping = false;
                    FengGameManagerMKII.settings[79] = false;
                    return;
                }
                this.scroll = Vector2.zero;
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
                FengGameManagerMKII.settings[79] = IN_GAME_MAIN_CAMERA.isTyping = IN_GAME_MAIN_CAMERA.isPausing = false;
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
            GUI.depth = (-100);
            if (Event.current.type == (EventType)4 && Event.current.keyCode == (KeyCode)284)
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
            GUI.backgroundColor = (Color.black);
            if (GUI.Button(new Rect((float)Screen.width - 150f, (float)Screen.height / 2f - 15f, 145f, 30f), "NEXT"))
            {
                FengGameManagerMKII.ResizeImg(SnapShotSaves.GetNextIMG());
            }
            else if (GUI.Button(new Rect(5f, (float)Screen.height / 2f - 15f, 145f, 30f), "PREV"))
            {
                FengGameManagerMKII.ResizeImg(SnapShotSaves.GetPrevIMG());
            }
            if (SnapShotSaves.getLength() <= 0 || !(FengGameManagerMKII.resizedlinkTex != null) || !(FengGameManagerMKII.linkTex != null))
            {
                GUI.Box(new Rect((float)Screen.width / 2f - 155f, (float)Screen.height / 2f - 30f, 310f, 35f), string.Empty);
                GUI.Box(new Rect((float)Screen.width / 2f - 155f, (float)Screen.height / 2f - 30f, 310f, 35f), string.Empty);
                GUI.Box(new Rect((float)Screen.width / 2f - 150f, (float)Screen.height / 2f - 25f, 300f, 25f), string.Empty);
                GUI.Box(new Rect((float)Screen.width / 2f - 150f, (float)Screen.height / 2f - 25f, 300f, 25f), "No Snapshots Available");
            }
            else
            {
                Rect rect = new Rect((float)Screen.width * 0.5f - (float)FengGameManagerMKII.resizedlinkTex.width * 0.5f, (float)Screen.height * 0.5f - (float)FengGameManagerMKII.resizedlinkTex.height * 0.5f, (float)FengGameManagerMKII.resizedlinkTex.width, (float)FengGameManagerMKII.resizedlinkTex.height);
                GUI.Box(new Rect(rect.xMin - 10f, rect.yMin - 5f, rect.width + 10f, rect.height + 10f), string.Empty);
                GUI.Box(new Rect(rect.xMin - 10f, rect.yMin - 5f, rect.width + 10f, rect.height + 10f), string.Empty);
                GUI.Box(new Rect(rect.xMin - 10f, rect.yMin - 5f, rect.width + 10f, rect.height + 10f), string.Empty);
                GUI.Box(rect, FengGameManagerMKII.resizedlinkTex, "Label");
                float _width = (float)Screen.width * 0.5f - 75f;
                Rect rect1 = new Rect(_width, rect.yMin + rect.height + 10f, 150f, 30f);
                GUI.Box(new Rect(rect1.xMin - 5f, rect1.yMin - 5f, rect1.width + 10f, rect1.height + 10f), string.Empty);
                GUI.Box(new Rect(rect1.xMin - 5f, rect1.yMin - 5f, rect1.width + 10f, rect1.height + 10f), string.Empty);
                if ((bool)FengGameManagerMKII.settings[80])
                {
                    GUI.Button(rect1, "uploading");
                }
                else if (GUI.Button(rect1, "UPLOAD"))
                {
                    FengGameManagerMKII.settings[80] = true;
                    FengGameManagerMKII.settings[69] = string.Empty;
                    base.StartCoroutine(FengGameManagerMKII.UploadImage(FengGameManagerMKII.linkTex));
                }
                if ((string)FengGameManagerMKII.settings[69] != string.Empty)
                {
                    GUI.backgroundColor = (Color.black);
                    float single = (float)Screen.width / 2f - 200f;
                    float _height = (float)Screen.height / 2f - 75f;
                    GUI.Box(new Rect(single - 5f, _height - 5f, 410f, 85f), string.Empty);
                    GUI.Box(new Rect(single - 5f, _height - 5f, 410f, 85f), string.Empty);
                    GUI.Box(new Rect(single, _height, 400f, 75f), string.Empty);
                    GUI.backgroundColor = (Color.blue);
                    GUI.Label(new Rect(single + 5f, _height + 5f, 195f, 30f), "Image Link : \r\n");
                    if (this.imageLink.IsNullOrEmpty())
                    {
                        this.imageLink = (string)FengGameManagerMKII.settings[69];
                        if (this.imageLink.Contains("<rsp stat=\"ok\">"))
                        {
                            this.imageLink = this.imageLink.Remove(this.imageLink.IndexOf("</original_image>")).Substring(this.imageLink.IndexOf("<original_image>") + 16);
                        }
                        else if (this.imageLink.Contains("<error>"))
                        {
                            this.imageLink = Regex.Replace(this.imageLink.Remove(this.imageLink.IndexOf("</error>")).Substring(this.imageLink.IndexOf("<error>") + 7), "<\\/?[a-z0-9]+(_?)[a-z0-9]+>", " ");
                        }
                    }
                    GUI.TextField(new Rect(single + 100f, _height + 5f, 295f, 30f), this.imageLink);
                    GUI.Label(new Rect(single + 5f, _height + 40f, 200f, 30f), "Deletion Link : \r\n");
                    if (string.IsNullOrEmpty(this.deletionLink))
                    {
                        this.deletionLink = (string)FengGameManagerMKII.settings[69];
                        if (this.deletionLink.Contains("<rsp stat=\"ok\">"))
                        {
                            this.deletionLink = this.deletionLink.Remove(this.deletionLink.IndexOf("</delete_page>")).Substring(this.deletionLink.IndexOf("<delete_page>") + 13);
                        }
                        else if (this.deletionLink.Contains("<error>"))
                        {
                            this.deletionLink = Regex.Replace(this.deletionLink.Remove(this.deletionLink.IndexOf("</error>")).Substring(this.deletionLink.IndexOf("<error>") + 7), "<\\/?[a-z0-9]+(_?)[a-z0-9]+>", " ");
                        }
                    }
                    GUI.TextField(new Rect(single + 100f, _height + 40f, 295f, 30f), this.deletionLink);
                    GUI.Box(new Rect(single - 5f, (float)Screen.height / 2f - 105f, 410f, 25f), string.Empty);
                    GUI.Box(new Rect(single - 5f, (float)Screen.height / 2f - 105f, 410f, 25f), string.Empty);
                    if (GUI.Button(new Rect(single, (float)Screen.height / 2f - 102.5f, 400f, 20f), "CLOSE"))
                    {
                        FengGameManagerMKII.settings[69] = string.Empty;
                    }
                }
            }
            GUI.backgroundColor = (Color.black);
        }
    }
}