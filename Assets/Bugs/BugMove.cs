using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D thisRigidBody;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float speedVariation = 0.3f;
    [SerializeField]
    private float moveUpdateInterval = 0.5f;
    [SerializeField]
    private float updateIntervalVariation = 0.3f;
    [SerializeField]
    private GameObject attackEffect;
    private float speedMultiplier;
    private GameObject moveTargetObject;
    private Vector2 targetPosition;
    private Vector2 moveDirection;
    private float realMoveInterval;
    //Sets the speed for the bug and tells it what object it needs to follow. 
    void OnEnable()
    {
        speedMultiplier = Random.Range(1 - speedVariation, 1 + speedVariation);
        speed *= speedMultiplier;
        moveTargetObject = GameObject.FindGameObjectWithTag("Player");
        realMoveInterval = moveUpdateInterval;
        targetPosition = moveTargetObject.transform.position;
    }
    //Updates the position the bug is moving towards at a random interval. 
    void Update()
    {  
        if(realMoveInterval <= 0f)
        {
            realMoveInterval = moveUpdateInterval;
            realMoveInterval += Random.Range(updateIntervalVariation *-1, updateIntervalVariation);
            targetPosition = moveTargetObject.transform.position;
            float angle =  Mathf.Rad2Deg * Mathf.Atan2(this.gameObject.transform.position.y - targetPosition.y, this.gameObject.transform.position.x - targetPosition.x);
            var rads = angle * Mathf.Deg2Rad;
            moveDirection = new Vector2(Mathf.Cos(rads), Mathf.Sin(rads)) * -1;
            thisRigidBody.velocity = moveDirection * speed;
        }
        if(realMoveInterval > 0f)
        {
            realMoveInterval -= Time.deltaTime;
        }
        
        
        

    }
    //Damages the player when player enters the attack trigger. 
    void OnTriggerEnter2D(Collider2D other )
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            if(player.TryGetComponent<PlayerHealthController>(out PlayerHealthController health))
            {
                health.DealDamage(damage);
                Vector2 slashEffectPos = other.ClosestPoint(this.transform.position);
                GameObject slashObject = Instantiate(attackEffect, slashEffectPos, this.transform.rotation);
                Destroy(slashObject, 0.2f);
                
            }
        }
    }

}
