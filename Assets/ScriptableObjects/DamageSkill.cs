using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Listable Items/Skills/Damage Skill")]
public class DamageSkill : Skill {

    public SkillTarget skillTarget = SkillTarget.Self;

    public override void Cast()
    {
        throw new System.NotImplementedException();
    } 
}
