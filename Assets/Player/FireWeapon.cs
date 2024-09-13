using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform bulletOrigin;
    [SerializeField]
    private float bulletRange;
    [SerializeField]
    private int bulletDamage;
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private GameObject gunPivot;
    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    GameObject bullet;
    private Vector2 bulletDirection;
    private float autoTimer = 0.1f;
    private float autoTimerReal;
    private  Vector3[] bulletPoints = new Vector3[2];
    private Vector2 cursorPos;
    private float angle;

    //Instantiates the Timer float. 
    void OnEnable()
    {
        autoTimerReal = autoTimer;
    }
    
    void Update()
    {
        //Finds the cursor position in world space and then sets the cursor object to that position.
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.transform.position = cursorPos; 

        //Calculates the angle and vector for where the gun should point, then rotates the gun gameObject.
        angle =  Mathf.Rad2Deg * Mathf.Atan2(gunPivot.transform.position.y-cursorPos.y, gunPivot.transform.position.x - cursorPos.x);
        var rads = angle * Mathf.Deg2Rad;
        bulletDirection = new Vector2(Mathf.Cos(rads), Mathf.Sin(rads)) * -1;
        gunPivot.transform.rotation = Quaternion.Euler(new Vector3 (0,0, angle));

        //Fires when mouse1 is pressed, and auto fires when mouse1 is held. 
        if(Input.GetMouseButtonDown(0))
        {
            
            Fire();
        }
        if(Input.GetMouseButton(0))
        {
            autoTimerReal -= Time.deltaTime;
            if(autoTimerReal <= 0)
            {
                Fire();
                autoTimerReal = autoTimer;
            }
            
        }
        
    }
    //Casts a ray in the direction of the gun, and evaluates the returned colliders. 
    void Fire()
    {
        
         
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(bulletOrigin.position, bulletDirection, bulletRange, LayerMask.GetMask("Bug"));
            
        foreach(RaycastHit2D raycastHit in raycastHits) 
        {
            if(raycastHit.collider != null)
                {
                    //If the collider's game object meets the criteria, damage is dealt. 
                    if(raycastHit.collider.gameObject.TryGetComponent<BugHealth>(out BugHealth bugHealth))
                    {
                        bugHealth.DealDamage(bulletDamage);
                    }

                }

        }  
        //Spawns the visual component for the raycast, the sets the direction of the visual element
        GameObject firedBullet = Instantiate(bullet, bulletOrigin.position, this.transform.rotation);
        if(firedBullet.TryGetComponent<BulletControl>(out BulletControl bulletControl))
        {
            bulletControl.Fire(bulletDirection);
        }

            
    }
   
}
