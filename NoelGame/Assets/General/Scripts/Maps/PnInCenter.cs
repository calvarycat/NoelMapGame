using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnInCenter : MonoBehaviour
{

    public GameObject root;
    public string[] listTestTutorial;
    public Text txtIndex;
    public Text txtTut;
    public GameObject camDevice;
    public CenterControl pnTrungTam;
    int centerID;
    int indexText = 0;
    PositionWELCenter datacenter;
    public Text txtDiaChi;
    public Text txtName;
    public void InitCenter(int _centerid)
    {
        centerID = _centerid;
        OnShow(true);
        // show infor center
        LoadCenter(_centerid);
    }
    public void LoadCenter(int centerID)
    {
        datacenter = Datacenter.instance.listCenter[centerID];
        // load dia chir
        txtDiaChi.text = datacenter.Address;
        txtName.text = datacenter.name;
    }
    public void OnShow(bool _isShow)
    {
        root.gameObject.SetActive(_isShow);
    }

    public void OnButtonPreClick()
    {
        indexText--;
        if (indexText<0)
        {
            indexText = listTestTutorial.Length-1;
        }
        Debug.Log("On button pre clickj" + indexText);
        UpdateTutorial(indexText);
    }
    public void OnButtonNextClick()
    {
        indexText++;
        if (indexText >= listTestTutorial.Length)
        {
            indexText = 0;
        }
        Debug.Log("On button nextClickClick" + indexText);
        UpdateTutorial(indexText);
    }
    public void UpdateTutorial(int _idx)
    {
        txtIndex.text = (indexText+1).ToString() + "/" + listTestTutorial.Length;
        txtTut.text = listTestTutorial[_idx];
    }
    public void OnBatDauClick()
    {
        Debug.Log("On button bắt đầu click");
        OnShow(false);
        camDevice.SetActive(true);
    }
    public void OnButtonQuayLaiSauClick()
    {
        OnShow(false);// tắt đi mở lại cái chọn địa điểm
        pnTrungTam.OnShow(true);
        Debug.Log("On button Quay lại sau Click");
    }
    #region  im right here
    public GameObject pnImRightHere;
    public GameObject[] HideImRightHere;
    public void OnButtonImRightHereClick()
    {
        Debug.Log("On button im right here Click");
        Debug.Log(CheckGotoCenter(centerID));
        if(CheckGotoCenter(centerID))
        {
            Debug.Log("Ban đã đến center");
            pnImRightHere.gameObject.SetActive(true);
            HideImRightHere[0].gameObject.SetActive(false);
            HideImRightHere[1].gameObject.SetActive(false);
            HideImRightHere[2].gameObject.SetActive(false);
        }
        else
        {
            PanelPopUp.intance.OnInitInforPopUp("Opps!!", "Bạn chưa đến đúng vị trí. Vui lòng thử lại!! ");
            Debug.Log("Ban đã chưa đến đúng nới rồi");
        }
    }
    public bool  CheckGotoCenter(int CenterID)
    {
        return true; // check trường hợp đã đến
       // return false;// check trường hợp chưa tới
    }
    #endregion
}
