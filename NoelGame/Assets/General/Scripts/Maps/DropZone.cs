using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropZone : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler {
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop" + eventData.pointerDrag.name +"Was drop on "+ gameObject.name);
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if(d!=null)
        {
            d.parremtToReturnTo = this.transform;
        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("on pointer enteer");
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("on pointer exit");
     
    }
}
