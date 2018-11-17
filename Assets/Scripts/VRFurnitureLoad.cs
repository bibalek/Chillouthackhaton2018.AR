using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections;

public class VRFurnitureLoad : MonoBehaviour
{
    public ARFurniturePiece savedFurniture;
    [SerializeField]
    private GameObject testFurniturePrefab;
    void Start()
    {
        string filePath = Application.dataPath + "furnitureTransition";
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            savedFurniture = JsonUtility.FromJson<ARFurniturePiece>(dataAsJson);
        }
        //foreach (ARFurniturePiece piece in savedFurniture.piecesSaved)
        // {
        GameObject pieceToInstantiate = Instantiate(testFurniturePrefab);
      //  pieceToInstantiate.transform.SetPositionAndRotation(savedFurniture.myTransform.position, savedFurniture.myTransform.rotation);
        //  furnitureLoaded.
        //  }

    }


}
