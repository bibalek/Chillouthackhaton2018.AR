using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections;

public class VRFurnitureLoad : MonoBehaviour
{
    public FurniturePieceToSave savedFurniture;
    [SerializeField]
    private GameObject testFurniturePrefab;
    void Start()
    {
        string filePath = Application.dataPath + "furnitureTransition";
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            savedFurniture = JsonUtility.FromJson<FurniturePieceToSave>(dataAsJson);
        }

        GameObject pieceToInstantiate = Instantiate(testFurniturePrefab);
        Debug.Log("From file: " + "pos: " + savedFurniture.piecePosition + "rot:" + savedFurniture.pieceRotation);
        pieceToInstantiate.transform.position = savedFurniture.piecePosition;
        pieceToInstantiate.transform.rotation = savedFurniture.pieceRotation;

        Debug.Log("Instantiated: " + "pos: " + pieceToInstantiate.transform.position + "rot:" + pieceToInstantiate.transform.rotation);

    }


}
