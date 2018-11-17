using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyAR
{

    [System.Serializable]
    public class ARFurniturePiece : MonoBehaviour
    {
        public int pieceID;
        ARObjectsSave arObjectsManager;
        private void Awake()
        {
            arObjectsManager = FindObjectOfType<ARObjectsSave>();

        }

        private void OnEnable()
        {
            if (!arObjectsManager.piecesOnARScene.Contains(this))
                arObjectsManager.piecesOnARScene.Add(this);
        }

        private void OnDisable()
        {
            if (arObjectsManager.piecesOnARScene.Contains(this))
                arObjectsManager.piecesOnARScene.Remove(this);
        }

    }
}