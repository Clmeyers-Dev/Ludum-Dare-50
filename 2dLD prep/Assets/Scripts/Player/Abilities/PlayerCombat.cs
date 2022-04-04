using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   [SerializeField]
   private Animator animator;
   [SerializeField]
   private Transform attackPoint;
   [SerializeField]
   public float attackRange = 0.05f;
   public LayerMask enemyLayers; 
    [SerializeField]
    public float meleedamage = 1;
    [SerializeField]
    private float attackRate = 2f;
    private float nextAttackTime = 0;
    void Start()
    {
        ph = GetComponent<PlayerHealthManager>();
    }
    void Update()
    {
        if(Time.time >= nextAttackTime){
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack(); 
            nextAttackTime = Time.time +1f/attackRate;
        }
        }
    }
    
    private PlayerHealthManager ph;
    void Attack()
    {   
        animator.SetTrigger("Attack");
        ph.playerController.audioManager.play("attack");
      Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
    foreach(Collider2D enemy in hitEnemies)
    {
        Debug.Log("hit for "+ meleedamage);
        enemy.GetComponent<EnemyHealthManager>().TakeDamage(meleedamage);
    }
    }

    void  OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    void endAttack(){
        animator.ResetTrigger("Attack");
    }
}
