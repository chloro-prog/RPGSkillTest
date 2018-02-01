using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// class dasar untuk instance yang dapat ditampilkan pada list
public abstract class ListableItem : ScriptableObject {

    public string itemName = "New Listable Item";
    public Image imageIcon;
    public string description;
}
