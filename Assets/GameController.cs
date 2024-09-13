using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverImage;
    [SerializeField]
    private GameObject gameWonImage;
    [SerializeField]
    private GameObject finalPillar;
    [SerializeField]
    private GameObject finalIndicator;
    [SerializeField]
    private Image fadeInImage;
    [SerializeField]
    private Image fadeOutImage;
    private int litPillars;

   //Disables all Win/GameOver UI.
    void OnEnable()
    {
        gameOverImage.SetActive(false);
        gameWonImage.SetActive(false);
        finalPillar.SetActive(false);
        finalIndicator.SetActive(false);
        Time.timeScale = 1f;
        fadeInImage.gameObject.SetActive(true);
        fadeOutImage.gameObject.SetActive(false);

    }

    //enables the game over screen
    public void EndGame()
    {
        gameOverImage.SetActive(true);
        Time.timeScale = 0f;
    }

    //Tells the game controller what to do when a pillar is lit. 
    public void PillarLit()
    {
        litPillars++;
        if(litPillars >= 4f) //Checks if all other pillars have been lit to enable the final pillar. 
        {
            finalPillar.SetActive(true);
            finalIndicator.SetActive(true);
        }
        
    }

    //Enables the win game screen. 
    public void WinGame()
    {
        Time.timeScale = 0f;
        gameWonImage.SetActive(true);
        
    }
    //Returns the player to the main menu
    public void ReturnToMainMenu()
    {
        fadeOutImage.gameObject.SetActive(true);
        StartCoroutine(ReturnToMainMenuDelay());
    }
    IEnumerator ReturnToMainMenuDelay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Debug.Log("load attempted");
        SceneManager.LoadScene("Main Menu");
    }
    

    
}