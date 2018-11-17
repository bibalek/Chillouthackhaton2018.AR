using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections;
namespace EasyAR
{

    public class ARObjectsSave : MonoBehaviour
    {
        public List<ARFurniturePiece> piecesOnARScene;
        [SerializeField]
        private GameObject wallsMock;

        private void Awake()
        {
            piecesOnARScene = new List<ARFurniturePiece>();
        }

        public void SaveAllARFurniture()
        {
            FurniturePieceToSave furniturePieceToSave = new FurniturePieceToSave();
            piecesOnARScene[0].GetComponent<ImageTargetBaseBehaviour>().enabled = false;
            piecesOnARScene[0].transform.SetParent(wallsMock.transform);
            furniturePieceToSave.pieceID = piecesOnARScene[0].pieceID;
            furniturePieceToSave.piecePosition = /*piecesOnARScene[0].transform.InverseTransformPoint(wallsMock.transform.position);*/piecesOnARScene[0].gameObject.transform.localPosition;
            furniturePieceToSave.pieceRotation = piecesOnARScene[0].gameObject.transform.localRotation;


            string jsonData = JsonUtility.ToJson(furniturePieceToSave);
            Debug.Log("Json saved: " + jsonData);
            string filePath = Application.persistentDataPath + "furnitureTransition";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.WriteAllText(filePath, jsonData);
        }

    }

    [System.Serializable]
    public class FurniturePieceToSave
    {
        public Vector3 piecePosition;
        public Quaternion pieceRotation;

        public int pieceID;
    }
}