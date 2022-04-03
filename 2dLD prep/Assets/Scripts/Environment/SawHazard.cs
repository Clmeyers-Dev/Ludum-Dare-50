using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawHazard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float damage;

    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private float speed = 5f;
    public int count = 0;
    void Start()
    {
        Debug.Log(points.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(count<= points.Length-1)
        transform.position = Vector3.MoveTowards(transform.position , points[count].transform.position, speed*Time.deltaTime);
        if(count<= points.Length-1){
        if(transform.position == points[count].transform .position&&count < points.Length-1){
            
            count++;
        }
         if(transform.position == points[count].transform .position|| count >= points.Length){
            count = 0;
        }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealthManager ph = other.GetComponent<PlayerHealthManager>();
        if(other.GetComponent<PlayerHealthManager>()!=null)
        {
            ph.moveToSaveLocation(damage);
        }
    }
}
