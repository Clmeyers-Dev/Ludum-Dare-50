using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform textMovetowards;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,textMovetowards.position,100*Time.deltaTime);
    }
}
