using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraDevice : MonoBehaviour
{

    public RawImage camImage;
    WebCamTexture webCam;
    public GameObject PnQuestion;
    public GameObject gift;
    public ControlQuestion controlQuestion;

    void Start()
    {
        webCam = new WebCamTexture();
        camImage.texture = webCam;
        camImage.material.mainTexture = webCam;       
        webCam.Play();
    }
    public void OnHide()
    {
        gameObject.SetActive(false);
    }
    public void OnEnable()
    {
        int randomOpen = Random.Range(1, 2);
        Invoke("ShowTheGift", randomOpen);
    }
    
    void ShowTheGift()
    {
        gift.gameObject.SetActive(true);
    }
    public void OpenTheBox()
    {

        controlQuestion.InitMultipleChoise();
        PnQuestion.gameObject.SetActive(true);

        OnHide();
    }


}
