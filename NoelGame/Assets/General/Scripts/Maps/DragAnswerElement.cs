﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAnswerElement : MonoBehaviour {

    // Use this for initialization
    public Transform txtTextAns;

   public int step;
    public void InitAnswer(int _step)
    {
        step = _step;

        // dung forupdate canvas truowcs khi init
        Vector2 newsize = txtTextAns.GetComponent<RectTransform>().sizeDelta;     
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(newsize.x+30,80);
    }
  
}