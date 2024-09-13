using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D thisRigidBody;
    [SerializeField]
    float timeAlive;
    [SerializeField]
    float speed;
    //Fires the bullet in a direction, and destroys itself after a set time.
    public void Fire(Vector2 direction)
    {
        thisRigidBody.velocity = direction * speed;
        Destroy(this.gameObject, timeAlive);
    }
    
}
