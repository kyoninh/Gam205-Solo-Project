using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PillarBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject icon;
    [SerializeField]
    private List<GameObject> bugSpawners;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private bool final = false;
    private bool withinRange = false;
    public bool pillarActivated = false; 

    // Disables all bug spawners attacked to this pillar. 
    void OnEnable()
    {
        icon.SetActive(false);
        foreach(GameObject bugSpawner in bugSpawners)
        {
            bugSpawner.SetActive(false);
        }
        
    }
    // Tracks whether the player is within the activation range. 
   void OnTriggerEnter2D(Collider2D other)
   {
        if (other.tag == "Player")
        {
            icon.SetActive(true);
            withinRange = true;
        }

   }
   void OnTriggerExit2D(Collider2D other)
   {
        
        if(other.tag == "Player")
        {
            icon.SetActive(false);
            withinRange = false;
        }
   }
   //Activates the pillar when the player is within range and presses E
   void Update()
   {
        if(withinRange && Input.GetKeyDown(KeyCode.E) && !pillarActivated)
        {
            //Seperate logic for if this is the final pillar. 
            if(final)
            {
                FinalPillarActivated();
            }
            else
            {
                ActivatePillar();
                Debug.Log("pillar activated");

            }
        }
   }
   //Tells the gamecontroller object that the pillar has been lit, and deactivates. 
   void ActivatePillar()
   {
        pillarActivated = true;
        foreach(GameObject bugSpawner in bugSpawners)
        {
            bugSpawner.SetActive(true);
        }
        gameController.PillarLit();
   }
   void FinalPillarActivated()
   {
        gameController.WinGame();
        Debug.Log("final pillar pressed");
   }
}
