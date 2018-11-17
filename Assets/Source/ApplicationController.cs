using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationController : MonoBehaviour
{
    [SerializeField]
    private ApiClient apiClient;
    [SerializeField]
    private Image image;
    

    public MarkerModelDict markerModelDict;
    public List<MarkerModel> markerModels;
    public List<Image> images = new List<Image>();
    public MarkersViewController markersViewController;

    public User user { get; set; }

    private void Awake()
    {
        user = new User(Const.userName, Const.userPassword);
        markerModels = new List<MarkerModel>();
    }

    public bool Login()
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

    public void GetCurrentMarkers()
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
