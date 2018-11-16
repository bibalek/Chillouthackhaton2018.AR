//=============================================================================================================================
//
// Copyright (c) 2015-2018 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================

using UnityEngine;
using System.Collections;
using EasyAR;

namespace Sample
{
    public class TargetOnTheFly : MonoBehaviour
    {
        private const string title = "Please enter KEY first!";
        private const string boxtitle = "===PLEASE ENTER YOUR KEY HERE===";
        private const string keyMessage = ""
            + "Steps to create the key for this sample:\n"
            + "  1. login www.easyar.com\n"
            + "  2. create app with\n"
            + "      Name: TargetOnTheFly (Unity)\n"
            + "      Bundle ID: cn.easyar.samples.unity.targetonthefly\n"
            + "  3. find the created item in the list and show key\n"
            + "  4. replace all text in TextArea with your key";

        [HideInInspector]
        public bool StartShowMessage = false;
        private bool isShowing = false;
        private ImageTargetManager imageManager;
        private FilesManager imageCreater;

        public GUISkin skin;
        private void Awake()
        {
            if (FindObjectOfType<EasyARBehaviour>().Key.Contains(boxtitle))
            {
#if UNITY_EDITOR
                UnityEditor.EditorUtility.DisplayDialog(title, keyMessage, "OK");
#endif
                Debug.LogError(title + " " + keyMessage);
            }
            imageManager = FindObjectOfType<ImageTargetManager>();
            imageCreater = FindObjectOfType<FilesManager>();
        }



        public void TakePhoto()
        {
            imageCreater.StartTakePhoto();
        }

        IEnumerator showMessage()
        {
            isShowing = true;
            yield return new WaitForSeconds(2f);
            isShowing = false;
        }
    }
}
