using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ModelPair
{
    public long id;
    public GameObject prefab;
}



public class ApplicationController : Singleton<ApplicationController>
{
    public ApiClient apiClient;
    [SerializeField]
    private Image image;

    public List<ModelPair> modelPairs = new List<ModelPair>();

    //public MarkerModelDict markerModelDict;
    public List<MarkerModel> markerModels;
    public List<Image> images = new List<Image>();
    public MarkersViewController markersViewController;
    public ModelsViewController modelsViewController;

    public User user { get; set; }
    public bool userLogged { get; set; }

    private void Awake()
    {
        base.Awake();
        if (this != null)
        {
            DontDestroyOnLoad(this.gameObject);
            user = new User(Const.userName, Const.userPassword);
            markerModels = new List<MarkerModel>(); ;
        }
    }


    public async Task<bool> Login()
    {
        user = apiClient.Login(user);
        if(user.FirstName == null && user.LastName == null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public async void GetCurrentMarkers()
    {
        markerModels = apiClient.GetMarkersByUserId(user);

        foreach(MarkerModel markerModel in markerModels)
        {
            markersViewController.AddItem(ConvertByteArrayToImage(markerModel.Picture), markerModel.MarkerID);
        }
        RectTransform parentRect = markersViewController.itemsParent.GetComponent<RectTransform>();
        RectTransform prefabRect = markersViewController.itemPrefab.GetComponent<RectTransform>();
        parentRect.sizeDelta = new Vector2(((markersViewController.items.Count - 1) * markersViewController.gridGroup.spacing.x) + 
            (markersViewController.gridGroup.cellSize.x * markersViewController.items.Count), parentRect.sizeDelta.y);
    }

    public void SetCurrentModels()
    {
        foreach(ModelPair pair in modelPairs)
        {
            modelsViewController.AddItem(pair.prefab, pair.id);
        }
        RectTransform parentRect = modelsViewController.itemsParent.GetComponent<RectTransform>();
        RectTransform prefabRect = modelsViewController.itemPrefab.GetComponent<RectTransform>();
        parentRect.sizeDelta = new Vector2(((modelsViewController.items.Count - 1) * modelsViewController.gridGroup.spacing.x) +
            (modelsViewController.gridGroup.cellSize.x * modelsViewController.items.Count), parentRect.sizeDelta.y);
    }

    public void UpdateMarkerModel()
    {
        apiClient.UpdateMarkerModelReference(
            modelsViewController.selectedItem.GetComponent<Model>().id,
            user,
            markersViewController.selectedItem.GetComponent<Marker>().id
            );

        markerModels.Where(m => m.MarkerID == markersViewController.selectedItem.GetComponent<Marker>().id).First().ModelID = modelsViewController.selectedItem.GetComponent<Model>().id;
    }

    public void ConvertByteArraysToImages(List<byte[]> pictures)
    {
        Sprite sprite;
        foreach(byte[] picture in pictures)
        {
            sprite = ConvertByteArrayToImage(picture);
            Image image;
            //image
        }
    }

    public Sprite ConvertByteArrayToImage(byte[] picture)
    {
        Texture2D texture = new Texture2D(1, 1);
        if (texture.LoadImage(picture))
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), image.rectTransform.pivot);
            //image.sprite = sprite;
        }
        else
            return null;
    }

}
