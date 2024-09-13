using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnPress : MonoBehaviour
{
    [SerializeField]
    private Button thisButton;
    [SerializeField]
    private string sceneName;
    void OnEnable()
    {
        //Loads the given scene when the button is clicked. 
        thisButton.onClick.AddListener(LoadScene);
    }
    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }   


}
