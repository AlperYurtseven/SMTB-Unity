using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button levelsButton;
    public Button exitButton;

    int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        // Add listeners in the Start method to avoid adding them multiple times
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(OpenSettings);
        levelsButton.onClick.AddListener(OpenLevels);
        exitButton.onClick.AddListener(Application.Quit);
        

        if (PlayerPrefs.HasKey("Level"))
        {
            currentLevel = PlayerPrefs.GetInt("Level");

            if (currentLevel > 3){
                currentLevel = 3;
                PlayerPrefs.SetInt("Level", currentLevel);
            }
                
        }
        else
        {
            currentLevel = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // No need to add listeners in the Update method
    }

    void StartGame()
    {
        string levelToLoad = "Level" + currentLevel;
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }

    void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Single);
    }

    void OpenLevels()
    {
        SceneManager.LoadScene("LevelsScene", LoadSceneMode.Single);
    }
}