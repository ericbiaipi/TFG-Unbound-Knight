using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Animator settingsAnim;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainMenu")
        {
            AudioManager.instance.backgroundMusic.Stop();
            AudioManager.instance.PlayAudio(AudioManager.instance.mainMenu);
        }

        Time.timeScale = 1;
    }


    void Update()
    {
        
    }

    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    { 
        Application.Quit();
    }

    public void GoToMainMenu()
    { 
        SceneManager.LoadScene(0);
    }

    public void ShowSettings()
    {
        settingsAnim.SetBool("ShowSettings", true);
    }

    public void HideSettings() 
    {
        settingsAnim.SetBool("ShowSettings", false);
    }


}