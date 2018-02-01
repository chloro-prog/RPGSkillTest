using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Set Skills")]
public class EquippedSkills : ScriptableObject {

    [HideInInspector]
    public Skill[] skills = new Skill[4];
}
