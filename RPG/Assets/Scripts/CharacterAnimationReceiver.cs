using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAnimationReceiver : MonoBehaviour
{
    public CharacterCombat combat;
    
    public void AttackHitEvent()
    {
        combat.AttackHit_AnimationEvent();
    }
        

}
