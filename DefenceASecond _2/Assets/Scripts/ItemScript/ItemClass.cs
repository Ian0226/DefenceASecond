using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemClass : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject background;
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

    public int itemAmountValue;
    public Text itemAmount;

    private void Awake()
    {
        itemInfoPanelRectTransform = itemInfoPanel.GetComponent<RectTransform>();
        background = transform.parent.gameObject;
        if (background.GetComponent<RectTransform>().rect.width != 216 && background.GetComponent<RectTransform>().rect.height != 259)
        {
            //Debug.Log("!");
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().rect.width * 0.64f, this.GetComponent<RectTransform>().rect.height * 0.64f);
            this.GetComponent<RectTransform>().localPosition = new Vector2(69, -66);
        }
    }
    private void Update()
    {
        itemInfoPanelRectTransform.sizeDelta = new Vector2(itemInfoPanelRectTransform.rect.width, itemDescriptionText.rectTransform.rect.height + 105);
        itemAmount.text = itemAmountValue.ToString();
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
