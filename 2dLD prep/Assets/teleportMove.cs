using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class teleportMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float detectrange = .01f;
    [SerializeField]
    private LayerMask collisonLayer; 
    [SerializeField]
    public bool inWall; 
   void Update()
   {
       Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(transform.position,detectrange,collisonLayer);
      if(hitEnemies.Length > 0 ){
          inWall = true;
      } else{ 
          inWall = false;
      }
   }
   
}
