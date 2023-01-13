using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat: MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    const float combatCooldown = 5;
    public float attackDelay = .6f;

    float lastAttackTime;
    
    public bool InCombat { get; private set; }
   
    public event System.Action OnAttack;
    
    CharacterStats myStats;
    CharacterStats opponentStats;
     void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }
     void Update()
    {
        attackCooldown -= Time.deltaTime;
        if(Time.time - lastAttackTime > combatCooldown ) 
        {
           InCombat = false;
        }
    }
    public void Attack (CharacterStats targetStats)
    {
        if (attackCooldown <= 0f) 
        {
            //  StartCoroutine(DoDamage(targetStats, attackDelay));
            opponentStats = targetStats;

            if (OnAttack != null)
                OnAttack();
            attackCooldown = 1f / attackSpeed;
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }

   /* IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
       
    }*/

    public void AttackHit_AnimationEvent()
    {
        opponentStats.TakeDamage(myStats.damage.GetValue());
        if (opponentStats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }
}
