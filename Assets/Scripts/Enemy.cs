using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 enemyMoveOffset; 
    private Vector3 startPos;
    private Vector3 targetPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos=transform.position;
        targetPos=startPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,targetPos,speed*Time.deltaTime);

        if(transform.position==targetPos )
        {
            // has the enemy reached the target?
            if(targetPos==startPos )
            {
                targetPos= startPos+enemyMoveOffset;
            }
            else
            {
                targetPos= startPos;
            }
        }
        
    }
}
