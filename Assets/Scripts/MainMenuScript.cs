using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        // Add listeners in the Start method to avoid adding them multiple times
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(OpenSettings);
    }

    // Update is called once per frame
    void Update()
    {
        // No need to add listeners in the Update method
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Single);
    }
}