using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpHeight =1f;
    [SerializeField]
    private Rigidbody2D playerRigidBody;
    private float moveDirection;
    private bool grounded = false;
    
    void Update()
    {
        //Move Right
        if(Input.GetKeyDown(KeyCode.D))
        {
            moveDirection = 1f;
        }
        else if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            moveDirection = -1f;
        }
        //Move Left
        if(Input.GetKeyDown(KeyCode.A))
        {
            moveDirection = -1f;
        }
        else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            moveDirection = 1f;
        }
        //Stop Moving
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            moveDirection = 0f;
        }
        //Jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

       
        

        //Moves Player
        
    }
    void Jump()
    {
        Debug.Log("Jump Attempted");
        if(grounded)
        {
            playerRigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            Debug.Log("Joomp");
        }
    }
    //checks if the player trigger overlaps with ground
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("GroundTrigger Entered");
        if (collider.gameObject.layer == 6)
        {
            grounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            grounded = false;
        }
    }
   

}
