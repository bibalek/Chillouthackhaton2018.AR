//=============================================================================================================================
//
// Copyright (c) 2015-2018 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================

using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using EasyAR;


namespace Sample
{
    public class FilesManager : MonoBehaviour
    {
        private string MarksDirectory;
        private bool isWriting;
        private TargetOnTheFly ui;
        [SerializeField]
        private MarkerModelDict modelsDictionary;
        [SerializeField]
        private ImageTarget imageTargetToSave;

        public
        void Awake()
        {
            ui = FindObjectOfType<TargetOnTheFly>();
            MarksDirectory = Application.persistentDataPath;
            Debug.Log("MarkPath:" + Application.persistentDataPath);
        }

        public void StartTakePhoto()
        {
            if (!Directory.Exists(MarksDirectory))
                Directory.CreateDirectory(MarksDirectory);
            if (!isWriting)
                StartCoroutine(ImageCreate());
        }

        IEnumerator ImageCreate()
        {
            isWriting = true;
            yield return new WaitForEndOfFrame();
            Texture2D photo = new Texture2D(Screen.width / 2, Screen.height / 2, TextureFormat.RGB24, false);
            photo.ReadPixels(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), 0, 0, false);
            byte[] data = photo.EncodeToJPG(80);
            ApiClient client = FindObjectOfType<ApiClient>();
            ApplicationController appController = FindObjectOfType<ApplicationController>();
            ApplicationController.Instance.user = client.Login(ApplicationController.Instance.user);
            long myMarkerID = appController.apiClient.SaveMarkerModel(data, 0, ApplicationController.Instance.user);
            Debug.Log("My marker id: " + myMarkerID.ToString());
            MarkerModel addedModel = new MarkerModel();
            addedModel.MarkerID = myMarkerID;
            addedModel.ModelID = 0;
            addedModel.Picture = data;
            addedModel.UserID = ApplicationController.Instance.user.UserID;
            ApplicationController.Instance.markerModels.Add(addedModel);

            DestroyImmediate(photo);
            photo = null;

            string photoPath = Path.Combine(Application.streamingAssetsPath + "/" + myMarkerID.ToString() + ".jpg");


            FileStream file = File.Open(photoPath, FileMode.Create);
            file.BeginWrite(data, 0, data.Length, new AsyncCallback(endWriter), file);
            Debug.Log("File saved to: " + photoPath);
        }

        void endWriter(IAsyncResult end)
        {
            using (FileStream file = (FileStream)end.AsyncState)
            {
                file.EndWrite(end);
                isWriting = false;
                ui.StartShowMessage = true;
            }
        }

        public Dictionary<string, string> GetDirectoryName_FileDic()
        {
            if (!Directory.Exists(MarksDirectory))
                return new Dictionary<string, string>();
            return GetAllImagesFiles(MarksDirectory);
        }

        private Dictionary<string, string> GetAllImagesFiles(string path)
        {
            Dictionary<string, string> imgefilesDic = new Dictionary<string, string>();
            foreach (var file in Directory.GetFiles(path))
            {
                if (Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".bmp" || Path.GetExtension(file) == ".png")
                    imgefilesDic.Add(Path.GetFileNameWithoutExtension(file), file);
            }
            return imgefilesDic;
        }

        public void ClearTexture()
        {
            Dictionary<string, string> imageFileDic = GetAllImagesFiles(MarksDirectory);
            foreach (var path in imageFileDic)
                File.Delete(path.Value);
        }
    }
}
