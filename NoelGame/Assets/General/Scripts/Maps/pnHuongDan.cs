using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnHuongDan : MonoBehaviour {

    public GameObject root;
    public CenterControl pnTrungTam;
    public void Onshow(bool _isShow)
    {
        root.SetActive(_isShow);

    }
    public void OnBtnChonDiaDiemClick()
    {
        Onshow(false);
        pnTrungTam.OnShow(true);
    }
}
