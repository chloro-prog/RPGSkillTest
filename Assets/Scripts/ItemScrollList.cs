using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScrollList : MonoBehaviour {

    public List<ListableItem> itemList;
    public Transform contentPanel;
    public ObjectPoolHandler buttonObjectHandler; // object pooling untuk button
    public Text itemTypeText;
    public Text itemStatText;
    public Text additionalText;
    public ItemScrollList targetList;
    [HideInInspector]
    public bool isSelectItem = false;

    [HideInInspector]
    public ListableItem selectedItem;

	void Start () {
        Initialize();
        RefreshDisplay();
	}

    protected virtual void Initialize()
    { }

    public virtual void RefreshDisplay()
    {
        RemoveButtons();
    }

    public void AddButtons(List<ListableItem> itemToShow)
    {
        for (int i = 0; i < itemToShow.Count; i++)
        {
            ListableItem item = itemToShow[i];
            GameObject newButton = buttonObjectHandler.GetObject();

            newButton.transform.SetParent(contentPanel);

            ButtonSetup itemButton = newButton.GetComponent<ButtonSetup>();
            itemButton.Setup(item, this);
        }
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectHandler.ReturnObject(toRemove);
        }
    }

    protected void AddItem(ListableItem itemToAdd, ItemScrollList scrollList)
    {
        scrollList.itemList.Add(itemToAdd);
    }

    protected void RemoveItem(ListableItem itemToRemove, ItemScrollList scrollList)
    {

        Debug.Log(itemToRemove.itemName);

        for (int i = itemList.Count - 1; i >= 0; i--)
        {
            if (scrollList.itemList[i] == itemToRemove)
            {
                scrollList.itemList.RemoveAt(i);
                return;
            }
        }
    }

    public virtual void SelectItem(ListableItem itemToSelect)
    {
        targetList.DeselectItem();

        selectedItem = itemToSelect;
        isSelectItem = true;
        UpdateItemInfo();
    }

    public void DeselectItem()
    {
        selectedItem = null;
        isSelectItem = false;
    }

    protected virtual void UpdateItemInfo()
    {
        if (selectedItem != null)
        {
            if (selectedItem is Skill)
            {
                itemTypeText.text = "[" + selectedItem.itemName + "]";
                itemTypeText.color = Color.red;
                itemStatText.text = "Power : " + ((Skill)selectedItem).skillPower.ToString() + "\n" +
                    "Cost : " + ((Skill)selectedItem).baseCost.ToString();
                additionalText.text = selectedItem.description;
            }
            else if (selectedItem is Augment)
            {
                itemTypeText.text = "[" + selectedItem.itemName + "]";
                itemTypeText.color = Color.green;
                itemStatText.text = "Power : " + ((Augment)selectedItem).sPowerModifier.ToString() + "\n" +
                    "Cost : " + ((Augment)selectedItem).sCostModifier.ToString();
                additionalText.text = selectedItem.description;
            }
        }
    }
    
    // mencoba untuk memindahkan skill dari list ke list yang lain
    public virtual void TryTransferSkillToOtherList()
    {
        AddItem(selectedItem, targetList);
        RemoveItem(selectedItem, this);

        RefreshDisplay();
        targetList.RefreshDisplay();
    }
}
