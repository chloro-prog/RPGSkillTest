using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoManager : MonoBehaviour {

    public AvailableItemList scrollList;
    public PickedSkillList pickedList;
    public Button skillButton;
    public Button augmentButton;
    public Button skillEquipButton;
    public Text skillButtonText;
    public Button augmentEquipButton;

    private bool isSelectAugment = false;
    private Augment selectedAugment;

	// Use this for initialization
	void Start () {
        skillButton.interactable = false;
        augmentButton.interactable = true;

        skillButton.onClick.AddListener(StateChange);
        augmentButton.onClick.AddListener(StateChange);
        skillEquipButton.onClick.AddListener(TransferItem);
	}

    void Update()
    {
        if (isSelectAugment)
        {
            if (pickedList.isSelectItem)
            {
                if (((Skill)pickedList.selectedItem).augment == null)
                {
                    pickedList.AddAugment(selectedAugment);
                    isSelectAugment = false;
                    selectedAugment = null;
                }
            }
        }

        ManageEquipButton();
    }

    public void TransferItem()
    {
        ItemScrollList activeList = scrollList.isSelectItem ? (ItemScrollList)scrollList : (ItemScrollList)pickedList;
        if (activeList is AvailableItemList)
        {
            if (scrollList.isSkillDisplay)
                activeList.TryTransferSkillToOtherList();
            else
            {
                if (!isSelectAugment)
                {
                    isSelectAugment = true;
                    selectedAugment = (Augment)scrollList.selectedItem;

                    skillButtonText.text = "Cancel";
                }
                else
                {
                    isSelectAugment = false;
                }
            }
        }
        else if (activeList is PickedSkillList)
            pickedList.TryTransferSkillToOtherList();
    }

    public void StateChange()
    {
        scrollList.SwitchDisplay();

        if (scrollList.isSkillDisplay)
        {
            skillButton.interactable = false;
            augmentButton.interactable = true;
        }
        else
        {
            skillButton.interactable = true;
            augmentButton.interactable = false;
        }
    }

    private void ManageEquipButton()
    {
        ItemScrollList activeList = scrollList.isSelectItem ? (ItemScrollList)scrollList : pickedList;

        if (activeList is AvailableItemList)
        {
            if (scrollList.isSkillDisplay)
            {
                if (scrollList.itemList.Count > 0)
                    skillButtonText.text = "Equip Skill";
            }
            else
            {
                if (scrollList.itemList.Count > 0 && !isSelectAugment)
                    skillButtonText.text = "Equip Augment";
            }
        }
        else
        {
            if (scrollList.itemList.Count > 0)
                skillButtonText.text = "Unequip Skill";
        }
    }
}
