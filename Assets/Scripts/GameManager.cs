using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject player;

    public GameObject[] enemies;

    public GameObject[] platforms;

    public GameObject[] obstacles;

    public GameObject[] backgrounds;

    public GameObject platform;

    public GameObject background;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    public Button restartButton;

    public Camera mainCamera;

    GameObject player1;
    GameObject platform1;
    GameObject background1;

    public List<Vector3> platform_locations;
    public List<Vector3> bg_locations;

    Vector3 last_generated_platform;

    public int score = 0;

    public AudioSource destroySound;

    public float audioVolume;

    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }

        player1 = UnityEngine.Object.Instantiate(player, new Vector3(0, -3, 0), Quaternion.identity);

        gameOverText.gameObject.SetActive(false);

        if(PlayerPrefs.HasKey("Volume")){

            audioVolume = PlayerPrefs.GetFloat("Volume");
        }
        else{
            audioVolume = 1;
        }

        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);

    }

    // Update is called once per frame
    void Update()
    {
       

        
    }

    public void spawnPlatform(GameObject platform_prefab, Vector3 create_position)
    {
        GameObject platform1 = UnityEngine.Object.Instantiate(platform_prefab, create_position, Quaternion.identity);
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        platform_locations.Add(create_position);
    }

    public void spawnBackground(GameObject background_prefab, Vector3 create_position)
    {
        GameObject background1 = UnityEngine.Object.Instantiate(background_prefab, create_position, Quaternion.identity);
        bg_locations.Add(create_position);

    }

    public void destroySoundPlay()
    {
        destroySound.Play();
        Debug.Log("Sound Played");
        
        scoreText.text = "Count: " + (score + 1).ToString();
        score += 1;
    }

    public void gameOver(){

        Debug.Log("Game Over");
        player1.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameOverText.text = "Game Over!\n Final Count: " + score.ToString();
        Time.timeScale = 0;
    }

    public void LevelCompleted(){

        Debug.Log("Level Completed");
        player1.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Level Completed!\n Final Count: " + score.ToString();
        Time.timeScale = 0;
    }

    public void RestartGame(){

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

}
