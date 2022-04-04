using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUpText : MonoBehaviour
{
    [SerializeField]
    private float detectRange;
    [SerializeField]
    private LayerMask playermask;
    [SerializeField]
    private string textToSay;
    [SerializeField]
    private float YOffset;
    private bool playerInRange;
    [SerializeField]
    private TextMeshPro textMeshPro;
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.alpha = 0;
    }

    void Update()
    {
        Collider2D[] Playerdetect = Physics2D.OverlapCircleAll(new Vector3(transform.position.x,transform.position.y+YOffset,transform.position.z), detectRange, playermask);
            if (Playerdetect.Length > 0)
            {
                playerInRange = true;
               
            }else{
                playerInRange = false;
            }
            if(playerInRange){
                textMeshPro.alpha = 255;
            }else{
                textMeshPro.alpha = 0;
            }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y+YOffset,transform.position.z),detectRange);
    }
}
