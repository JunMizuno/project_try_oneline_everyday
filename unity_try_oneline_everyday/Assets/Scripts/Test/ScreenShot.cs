using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Test
{
    public class ScreenShot : MonoBehaviour
    {
        [Header("保存先フォルダ名を指定")]
        [SerializeField]
        public string FolderName = "screen_shot";

        private bool isCreating = false;
        private string path = default;

        private void Start()
        {
            path = Application.dataPath + "/" + FolderName + "/";
        }

        public void PrintScreen()
        {
            StartCoroutine(CreateScreenShot());
        }

        IEnumerator CreateScreenShot()
        {
            if (isCreating)
            {
                yield break;
            }

            Debug.Log("<color=cyan>" + "Start CreateScreenShot" + "</color>");

            isCreating = true;

            yield return null;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string date = DateTime.Now.ToString("yy-MM-dd_HH-mm-ss");
            string fileName = path + date + ".png";

            ScreenCapture.CaptureScreenshot(fileName);

            yield return new WaitUntil(() => File.Exists(fileName));

            isCreating = false;

            Debug.Log("<color=cyan>" + "Finished CreateScreenShot" + "</color>");
        }
    }
}
