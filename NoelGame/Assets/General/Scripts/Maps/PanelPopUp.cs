using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPopUp : MonoBehaviour {

    public static PanelPopUp intance;
    public GameObject root;
    public Text txtShowInfo;
    public Text txtTitle;
    private void Awake()
    {
        intance = this;
    }
    public void OnInitInforPopUp(string title="Opps!!",string info="")
    {
        root.gameObject.SetActive(true);
        txtTitle.text = title;
        txtShowInfo.text = info;
    }
    public void OnHidePopUp()
    {
        Debug.Log("hide popUp");
        root.SetActive(false);
        txtShowInfo.text = "";

    }
}
