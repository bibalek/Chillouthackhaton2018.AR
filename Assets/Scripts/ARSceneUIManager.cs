using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace EasyAR
{

    public class ARSceneUIManager : MonoBehaviour
    {
        bool buttonsVisible;
        [SerializeField]
        private Animator buttonsAnimator;
        [SerializeField]
        private Text hideShowButtonLabel;
        private void Start()
        {
            buttonsVisible = true;
        }
        public void LoadVRScene(bool isVr)
        {
            ARVRScenesTransition.isVr = isVr;
            ARObjectsSave save = FindObjectOfType<ARObjectsSave>();
            save.SaveAllARFurniture();
            SceneManager.LoadScene(2);
        }

        public void HideShowButtons()
        {
            if (buttonsVisible)
            {
                buttonsAnimator.Play("HideButtonsAR");
                hideShowButtonLabel.text = "SHOW";
                buttonsVisible = false;
            }
            else
            {
                buttonsAnimator.Play("ShowButtons");
                hideShowButtonLabel.text = "HIDE";
                buttonsVisible = true;

            }
        }

        public void GoBackButton()
        {
            SceneManager.LoadScene(0);
        }
    }

}