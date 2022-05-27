using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseClickEffect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Sprite changesImage;
    private Sprite originImage;
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        originImage = GetComponent<Image>().sprite;
        GetComponent<Image>().sprite = changesImage;
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = originImage;
    }
}
