using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections;

namespace EasyAR
{

    public class VRFurnitureLoad : MonoBehaviour
    {
        public FurniturePieceToSave savedFurniture;
        [SerializeField]
        private GameObject testFurniturePrefab;
        [SerializeField]
        private GameObject wallsParent;
        void Start()
        {
            string filePath = Application.persistentDataPath + "furnitureTransition";
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                savedFurniture = JsonUtility.FromJson<FurniturePieceToSave>(dataAsJson);
            }

            GameObject pieceToInstantiate = Instantiate(testFurniturePrefab, wallsParent.transform);
            Debug.Log("From file: " + "pos: " + savedFurniture.piecePosition + "rot:" + savedFurniture.pieceRotation);
            pieceToInstantiate.transform.localPosition = savedFurniture.piecePosition;//pieceToInstantiate.transform.InverseTransformDirection(savedFurniture.piecePosition);
            pieceToInstantiate.transform.localScale = new Vector3(1, 1, 1);
            pieceToInstantiate.transform.localRotation = new Quaternion(savedFurniture.pieceRotation.x, savedFurniture.pieceRotation.y, 0, savedFurniture.pieceRotation.w);

            Debug.Log("Instantiated: " + "pos: " + pieceToInstantiate.transform.position + "rot:" + pieceToInstantiate.transform.rotation);

        }


    }

}