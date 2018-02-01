using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickedSkillList : ItemScrollList {

    public override void RefreshDisplay()
    {
        base.RefreshDisplay();

        AddButtons(itemList);

        selectedItem = null;
        if (itemList.Count > 0)
        {
            SelectItem(itemList[0]);
        }
    }

    public void AddAugment(Augment augment)
    {
        Skill selectedSkill = (Skill)selectedItem;
        selectedSkill.augment = augment;

        RemoveItem(augment, targetList);

        RefreshDisplay();
        targetList.RefreshDisplay();
    }

    protected override void UpdateItemInfo()
    {
        base.UpdateItemInfo();

        if (selectedItem != null)
        {
            if (selectedItem is Skill)
            {
                if (((Skill)selectedItem).augment != null)
                {
                    itemStatText.text = "Power : " + ((Skill)selectedItem).skillPower.ToString() + " " +
                        ((Skill)selectedItem).augment.sPowerModifier.ToString() + "\n" +
                    "Cost : " + ((Skill)selectedItem).baseCost.ToString() + " " +
                        ((Skill)selectedItem).augment.sCostModifier.ToString();
                }
            }
        }
    }

    public override void TryTransferSkillToOtherList()
    {
        if(((Skill)selectedItem).augment != null)
        {
            Augment attachedAugment = ((Skill)selectedItem).augment;
            ((Skill)selectedItem).augment = null;
            AddItem(attachedAugment, targetList);
        }
        base.TryTransferSkillToOtherList();
    }
}
