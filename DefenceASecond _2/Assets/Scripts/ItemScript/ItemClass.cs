using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemClass : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    private string itemName;
    public string ItemName
    {
        get { return itemName; }
    }

    [SerializeField]
    private string itemDescription;
    public string ItemDescription
    {
        get { return itemDescription; }
    }
    [SerializeField]
    private GameObject itemInfoPanel;
    private RectTransform itemInfoPanelRectTransform;
    
    [SerializeField]
    private Text itemNameText;

    [SerializeField]
    private Text itemDescriptionText;

    private void Awake()
    {
        itemInfoPanelRectTransform = itemInfoPanel.GetComponent<RectTransform>();
    }
    private void Update()
    {
        itemInfoPanelRectTransform.sizeDelta = new Vector2(itemInfoPanelRectTransform.rect.width, itemDescriptionText.rectTransform.rect.height + 105);
    }
    private void ShowItemInfo()
    {
        itemInfoPanel.gameObject.SetActive(true);
        itemNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        ShowItemInfo();
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        itemInfoPanel.gameObject.SetActive(false);
    }
}
