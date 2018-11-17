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
        [SerializeField]
        private List<MarkerModelConnection> modelsDict;

        void Start()
        {

            int howManyObjectsTransisted = PlayerPrefs.GetInt("HowManyTransitioned");
            for (int i = 0; i < howManyObjectsTransisted; i++)
            {
                string filePath = Application.persistentDataPath + "furnitureTransition" + i.ToString();
                if (File.Exists(filePath))
                {
                    string dataAsJson = File.ReadAllText(filePath);
                    savedFurniture = JsonUtility.FromJson<FurniturePieceToSave>(dataAsJson);
                }
                GameObject modelToSpawn = null;
                foreach (MarkerModelConnection model in modelsDict)
                {
                    if (model.ModelId == savedFurniture.pieceID)
                    {
                        Debug.Log("Piece id: " + savedFurniture.pieceID);
                        modelToSpawn = model.Prefab;
                    }
                }
                GameObject pieceToInstantiate = Instantiate(modelToSpawn, wallsParent.transform);
                Debug.Log("From file: " + "pos: " + savedFurniture.piecePosition + "rot:" + savedFurniture.pieceRotation);
                pieceToInstantiate.transform.localPosition = savedFurniture.piecePosition;//pieceToInstantiate.transform.InverseTransformDirection(savedFurniture.piecePosition);
                pieceToInstantiate.transform.localScale = new Vector3(1, 1, 1);
                pieceToInstantiate.transform.localRotation = new Quaternion(savedFurniture.pieceRotation.x, savedFurniture.pieceRotation.y, 0, savedFurniture.pieceRotation.w);

                Debug.Log("Instantiated: " + "pos: " + pieceToInstantiate.transform.position + "rot:" + pieceToInstantiate.transform.rotation);
            }

        }


    }

}