using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsViewController : MonoBehaviour
{
    public Text debugText;
    public GameObject itemsParent;
    public GridLayoutGroup gridGroup;

    public GameObject itemPrefab;

    public List<GameObject> items = new List<GameObject>();

    public Transform selectedItem;

    public void AddItem(GameObject prefab, long id)
    {
        GameObject newItem = Instantiate(itemPrefab, itemsParent.transform);
        GameObject newModel = Instantiate(prefab, newItem.transform);
        Image newItemImage = newItem.GetComponent<Image>();
        //SetImageOnItem(sprite, newItemImage);
        Button button = newItem.GetComponent<Button>();
        button.onClick.AddListener(() => SelectItem(newItem));
        newItem.GetComponent<Model>().id = id;
        newModel.transform.localScale = new Vector3(100, 100, 100);
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
        //for (int i = 0; i < Input.touchCount; ++i)
        //{
        //    if (Input.GetTouch(i).phase == TouchPhase.Began)
        //    {
        //        // Construct a ray from the current touch coordinates
        //        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
        //        // Create a particle if hit
        //        RaycastHit hit;
        //        if (Physics.Raycast(ray, out hit))
        //        {
        //            if (hit.transform.CompareTag("ScrollViewItem"))
        //            {
        //                selectedItem = hit.transform;
        //            }
        //        }
        //    }
        //}
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.CompareTag("ScrollViewItem"))
        //        {
        //            selectedItem = hit.transform;
        //        }
        //    }
        //}
        if (selectedItem != null)
        {
            debugText.text = selectedItem.gameObject.name + "  " + selectedItem.GetComponent<Model>().id;
        }
    }
}
