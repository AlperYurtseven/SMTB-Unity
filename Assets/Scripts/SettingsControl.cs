using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{

    public Button backButton;
    public Slider volumeSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(BackToMainMenu);
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            volumeSlider.value = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        Debug.Log("Volume: " + volume);
        //AudioListener.volume = volume;
    }
}
