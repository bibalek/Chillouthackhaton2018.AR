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
            int index = 0;
            foreach (ARFurniturePiece piece in piecesOnARScene)
            {
                index++;
                FurniturePieceToSave furniturePieceToSave = new FurniturePieceToSave();
                piece.GetComponent<ImageTargetBaseBehaviour>().enabled = false;
                piece.transform.SetParent(wallsMock.transform);
                furniturePieceToSave.pieceID = piece.pieceID;
                furniturePieceToSave.piecePosition = /*piecesOnARScene[0].transform.InverseTransformPoint(wallsMock.transform.position);*/piece.gameObject.transform.localPosition;
                furniturePieceToSave.pieceRotation = piece.gameObject.transform.localRotation;


                string jsonData = JsonUtility.ToJson(furniturePieceToSave);
                Debug.Log("Json saved: " + jsonData);
                string filePath = Application.persistentDataPath + "furnitureTransition" + index.ToString();
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, jsonData);
            }
            PlayerPrefs.SetInt("HowManyTransitioned", index);
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