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

    public float time_elapsed;

    public TextMeshProUGUI timeText;

    public Button nextLevelButton;

    public int currentLevel;

    public TextMeshProUGUI levelText;

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

        time_elapsed = 0.00f;

        if (PlayerPrefs.HasKey("Level"))
        {
            currentLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            currentLevel = 1;
        }

        Debug.Log("Level: " + currentLevel);

        nextLevelButton.gameObject.SetActive(false);
        nextLevelButton.onClick.AddListener(NextLevel);

        levelText.text = "Level: " + currentLevel.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        time_elapsed += Time.deltaTime;
        timeText.text = time_elapsed.ToString("F2");

       

        
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
        
        scoreText.text = "Count: " + (score + 1).ToString();
        score += 1;
    }

    public void gameOver(){
        player1.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameOverText.text = "Game Over!\n Final Count: " + score.ToString();
        Time.timeScale = 0;
    }

    public void LevelCompleted(){

        player1.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        float final_score = (111 - time_elapsed) * score;
        nextLevelButton.gameObject.SetActive(true);
        gameOverText.text = "Level Completed!\n Final Score: " + final_score.ToString();
        PlayerPrefs.SetInt("Level", currentLevel + 1);
        Time.timeScale = 0;
        
    }

    public void RestartGame(){

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void NextLevel(){

        string next_level = "Level" + (currentLevel + 1).ToString();

        SceneManager.LoadScene(next_level, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

}
