using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : ListableItem {

    public int skillPower = 10;
    public int baseCost = 1;
    [HideInInspector]
    public Augment augment;

    // Fungsi untuk mengeksekusi skill
    public abstract void Cast();
}
