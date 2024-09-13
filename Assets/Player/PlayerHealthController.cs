using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth;
    public int health;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private Image healthBar;    
    void OnEnable()
    {
        health = maxHealth;
        
    }
    //Subtracts health by the incoming damage value. 
    public void DealDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = (float)health/(float)maxHealth;
        Debug.Log(health/maxHealth);
        Debug.Log(health);
        
        //Tracks if health goes below zero, then ends the game. 
        if(health <= 0)
        {
            gameController.EndGame();
        }
    }
}
