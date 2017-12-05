using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnInCenter : MonoBehaviour {

    public GameObject root;
    public string[] listTestTutorial;
    public Text txtIndex;
    public Text txtTut;
    public GameObject camDevice;
    public PnInCenter pnTrungTam;

    int indexText = 0;
	public void OnShow(bool _isShow)
    {
        root.gameObject.SetActive(_isShow);
    }
    public void OnButtonQuayLaiSauClick()
    {
        OnShow(false);// tắt đi mở lại cái chọn địa điểm
        pnTrungTam.OnShow(true);
        Debug.Log("On button Quay lại sau Click");
    }
    public void OnButtonImRightHereClick()
    {
        Debug.Log("On button im right here Click");
    }
    public void OnButtonPreClick()
    {
        indexText++;
        if(indexText> listTestTutorial.Length)
        {
            indexText = 0;
        }
        Debug.Log("On button pre clickj" +indexText);
        UpdateTutorial(indexText);
    }
    public void OnButtonNextClick()
    {
        indexText--;
        if(indexText<0)
        {
            indexText = listTestTutorial.Length;
        }
        Debug.Log("On button nextClickClick" +indexText);
        UpdateTutorial(indexText);
    }
    public void UpdateTutorial(int _idx)
    {
        txtIndex.text = indexText.ToString();
        txtTut.text = listTestTutorial[_idx];
    }
    public void OnBatDauClick()
    {
        Debug.Log("On button bắt đầu click");
        OnShow(false);
        camDevice.SetActive(true);
    }
}
