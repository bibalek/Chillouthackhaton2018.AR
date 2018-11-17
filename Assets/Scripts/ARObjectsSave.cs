using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections;
public class ARObjectsSave : MonoBehaviour
{
    public List<ARFurniturePiece> piecesOnARScene;

    private void Awake()
    {
        piecesOnARScene = new List<ARFurniturePiece>();
    }

    public void SaveAllARFurniture()
    {
        FurniturePieceToSave furniturePieceToSave = new FurniturePieceToSave();
        furniturePieceToSave.pieceID = piecesOnARScene[0].pieceID;
        furniturePieceToSave.piecePosition = piecesOnARScene[0].gameObject.transform.position;
        furniturePieceToSave.pieceRotation = piecesOnARScene[0].gameObject.transform.rotation;


        string jsonData = JsonUtility.ToJson(furniturePieceToSave);
        Debug.Log("Json saved: " + jsonData);
        string filePath = Application.dataPath + "furnitureTransition";
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