using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    
    void Start()
    {
        target = FindAnyObjectByType<PlayerHealth>();
    }
   
    public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
   
}
