using System.Collections;
using System.Collections.Generic;
using JetBrains.Rider.Unity.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 8f;
    [SerializeField]
    private Rigidbody2D thisRigidBody;
    private Vector2 moveDirection;
    //moves the player 
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveDirection.Normalize();
        thisRigidBody.velocity = moveDirection * maxSpeed;

    }
}
