using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dragable : MonoBehaviour,IDragHandler,IDropHandler,IBeginDragHandler,IEndDragHandler {
    public Transform parremtToReturnTo = null;
    public GameObject placeholder = null;
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("beginDrag");
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        //LayoutElement le = placeholder.AddComponent<LayoutElement>();
        //le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        //le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        //le.flexibleHeight = 0;
        //le.flexibleHeight = 0;

        parremtToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
       this.transform.position = eventData.position;
        Debug.Log("OnDrag");
       for(int i=0;i<parremtToReturnTo.childCount;i++)
        {

        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEnđrag");
        this.transform.SetParent(parremtToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);

    }
}
