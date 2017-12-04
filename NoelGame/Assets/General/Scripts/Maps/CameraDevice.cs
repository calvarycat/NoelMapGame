using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraDevice : MonoBehaviour
{

    public RawImage camImage;
    WebCamTexture webCam;
    public GameObject PnQuestion;
    void Start()
    {
        webCam = new WebCamTexture();
        camImage.texture = webCam;
        camImage.material.mainTexture = webCam;       
        webCam.Play();
    }
    public void OpenTheBox()
    {
        //animation Open The box
        PnQuestion.gameObject.SetActive(true);
    }


}
