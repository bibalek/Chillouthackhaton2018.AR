using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkersViewController : MonoBehaviour
{
    //public DynamicHScrollView scrollView;
    public Text debugText;
    public GameObject itemsParent;
    public GridLayoutGroup gridGroup;

    public GameObject itemPrefab;

    public List<GameObject> items = new List<GameObject>();

    public Transform selectedItem;

    public void AddItem(Sprite sprite, long? id)
    {
        GameObject newItem = Instantiate(itemPrefab, itemsParent.transform);
        Image newItemImage = newItem.GetComponent<Image>();
        SetImageOnItem(sprite, newItemImage);
        Button button = newItem.GetComponent<Button>();
        button.onClick.AddListener(() => SelectItem(newItem));
        newItem.GetComponent<Marker>().id = id;
        items.Add(newItem);

    }

    public void SelectItem(GameObject item)
    {
        selectedItem = item.transform;
    }

    public void SetImageOnItem(Sprite sprite, Image image)
    {
        image.sprite = sprite;
    }

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                // Create a particle if hit
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("ScrollViewItem"))
                    {
                        selectedItem = hit.transform;
                    }
                }
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("ScrollViewItem"))
                {
                    selectedItem = hit.transform;
                }
            }
        }
        if (selectedItem != null)
        {
            debugText.text = selectedItem.gameObject.name + "  " + selectedItem.GetComponent<Marker>().id;

        }
    }
}
