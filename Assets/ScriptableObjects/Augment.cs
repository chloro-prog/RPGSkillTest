using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// serializable class untuk menandakan efek dengan chance
[System.Serializable]
public class EffectChance
{
    public ChanceBasedStats stat;
    public float chance;
}

[CreateAssetMenu (menuName="Listable Items/Augments")]
public class Augment : ListableItem {

    public int sPowerModifier = 0;
    public int sCostModifier = 0;
    public List<EffectChance> sAddEffects;
}
