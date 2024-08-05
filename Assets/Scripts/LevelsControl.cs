using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsControl : MonoBehaviour
{

    public Button Level1Button;
    public Button Level2Button;
    public Button Level3Button;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        Level1Button.onClick.AddListener(StartLevel1);
        Level2Button.onClick.AddListener(StartLevel2);
        Level3Button.onClick.AddListener(StartLevel3);
        backButton.onClick.AddListener(BackToMainMenu);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartLevel1()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    void StartLevel2()
    {   
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    void StartLevel3()
    {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
