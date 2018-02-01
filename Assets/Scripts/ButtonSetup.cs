using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetup : MonoBehaviour
{
    public Button itemButton;
    public Text nameLabel;
    public Image iconImage;

    private ListableItem item;
    private ItemScrollList itemScrollList;

    // Use this for initialization
    void Start()
    {
        itemButton.onClick.AddListener (HandleClick);
    }

    public void Setup(ListableItem currentItem, ItemScrollList scrollList)
    {
        item = currentItem;
        nameLabel.text = currentItem.itemName;
        itemScrollList = scrollList;
    }

    public void HandleClick() 
    {
        itemScrollList.SelectItem (item);
    }
}
