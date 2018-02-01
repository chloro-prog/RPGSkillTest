using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableItemList : ItemScrollList {

    // penanda list sedang menampilkan skill atau modifier
    [HideInInspector]
    public bool isSkillDisplay = true;

    protected override void Initialize()
    {
        isSkillDisplay = true;

        itemList = new List<ListableItem>();
        ListableItem[] itemsToLoad = Resources.LoadAll<ListableItem>("ListableItems");

        foreach (ListableItem item in itemsToLoad)
            itemList.Add(item);
    }
    
    public void SwitchDisplay()
    {
        isSkillDisplay ^= true;
        RefreshDisplay();
    }

    public override void RefreshDisplay()
    {
        base.RefreshDisplay();

        List<ListableItem> filteredList;
        if (isSkillDisplay)
            filteredList = itemList.FindAll(i => i is Skill);
        else
            filteredList = itemList.FindAll(i => i is Augment);

        AddButtons(filteredList);

        selectedItem = null;
        if (filteredList.Count > 0)
        {
            SelectItem(filteredList[0]);
        }
    }

    public override void TryTransferSkillToOtherList()
    {
        if (targetList.itemList.Count < 4)
            base.TryTransferSkillToOtherList();
    }
}
