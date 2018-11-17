using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRCameraGaze : MonoBehaviour
{
    [SerializeField]
    private Image circleToFill;
    [SerializeField]
    private Image fadePanel;
    public Camera viewCamera;
    bool isGazing;
    bool isTransition = false;
    [SerializeField]
    private GameObject gazePoint;

    private GameObject currentTeleportPoint;

    private void Start()
    {
        viewCamera = Camera.main;
        isGazing = false;
    }

    void Update()
    {
        if (!isTransition)
        {
            // Create a gaze ray pointing forward from the camera
            Ray ray = new Ray(gazePoint.transform.position, gazePoint.transform.rotation * Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "teleport")
                {
                    isGazing = true;
                    currentTeleportPoint = hit.transform.gameObject;
                }
                else
                {
                    isGazing = false;
                    circleToFill.fillAmount = 0;
                }
            }
            else
            {
                isGazing = false;
                circleToFill.fillAmount = 0;
            }

            if (isGazing)
            {
                circleToFill.fillAmount += 0.01f;
                if (circleToFill.fillAmount >= 1)
                {
                    isGazing = false;
                    circleToFill.fillAmount = 0;
                    circleToFill.gameObject.SetActive(false);
                    StartCoroutine(MoveToTeleportPoint());
                }
            }
        }
    }

    IEnumerator MoveToTeleportPoint()
    {
        byte alpha = 0;
        isTransition = true;
        while (fadePanel.color.a < 1)
        {
            alpha++;
            fadePanel.color = new Color32(0, 0, 0, alpha);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        currentTeleportPoint.GetComponent<TeleportSphereWithCamera>().camera.SetActive(true);
        gameObject.SetActive(false);
        // gameObject.transform.position = new Vector3(currentTeleportPoint.transform.position.x, transform.position.y, currentTeleportPoint.transform.position.z); ;
        while (fadePanel.color.a > 0)
        {
            alpha--;
            fadePanel.color = new Color32(0, 0, 0, alpha);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        circleToFill.gameObject.SetActive(true);
        isTransition = false;
    }
}
