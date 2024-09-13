using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BugHealth : MonoBehaviour
{  
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int killDelay = 0;
    [SerializeField]
    private GameObject deathParticles;

    private int health;
    void OnEnable()
    {
        health = maxHealth;
    }
    public void DealDamage(int dmg)
    {
        health -= dmg;
        Debug.Log($"bug took {dmg} damage");
        if(health <= 0)
        {
            Kill();
        }
        
    }
    private void Kill()
    {
        deathParticles.transform.SetParent(null);
        if(deathParticles.TryGetComponent<ParticleSystem>(out var particles))
        {
            particles.Play();
        }
        Destroy(this.gameObject, killDelay);
        
    }

}
