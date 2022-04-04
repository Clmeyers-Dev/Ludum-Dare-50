using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourSpider : MonoBehaviour
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

    public LayerMask layerMask;
        public float detectrange;
        public Transform groundcheckPoint;
        public bool groundedCheck;
        public PlayerHealthManager playerHealthManager;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
    }
    public float detectionRange;
    public LayerMask playermask;
    public bool playerInRange;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float distanceFromPlayer;
    
    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position,playerHealthManager.transform.position);
          Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(groundcheckPoint.position, detectrange, layerMask);
            if (hitEnemies.Length > 0)
            {
                groundedCheck = true;
            }
            else
            {
                groundedCheck = false;
            }
            Collider2D[] Playerdetect = Physics2D.OverlapCircleAll(transform.position, detectionRange, playermask);
            if (Playerdetect.Length > 0)
            {
                playerInRange = true;
               
            }
            else
            {
                playerInRange = false;
            }
           
           if(Time.time >= nextAttackTime&& distanceFromPlayer <minDistance){
        Debug.Log("attack");
            Attack(); 
            nextAttackTime = Time.time +1f/attackRate;
        
        }
        if(distanceFromPlayer>minDistance&&playerInRange&&groundedCheck){
            move();
            animator.SetBool("walking",true);
        }else{
            animator.SetBool("walking",false);
        }
        
    }
    void move(){
        transform.position = Vector3.MoveTowards(transform.position,playerHealthManager.transform.position,speed*Time.deltaTime);
        if(transform.position.x > playerHealthManager.transform.position.x){
             transform.localScale = new Vector3( -1, 1, 1);
        }else{
            transform.localScale = new Vector3( 1, 1, 1);
        }
    }
       void Attack()
    {   
        animator.SetTrigger("Attack");
      Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
    foreach(Collider2D enemy in hitEnemies)
    {
        Debug.Log("hit for "+ meleedamage);
        enemy.GetComponent<PlayerHealthManager>().takeDamage(meleedamage);
    }
    }
    
    void  OnDrawGizmosSelected()
    {
          Gizmos.DrawWireSphere(transform.position,minDistance);
        Gizmos.DrawWireSphere(transform.position,detectionRange);
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    void endAttack(){
        animator.ResetTrigger("Attack");
    }
}
