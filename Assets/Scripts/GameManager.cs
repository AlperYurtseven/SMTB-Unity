using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    GameObject player1;
    GameObject platform1;
    GameObject background1;

    public List<Vector3> platform_locations;
    public List<Vector3> bg_locations;

    Vector3 last_generated_platform;

    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }

        player1 = UnityEngine.Object.Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);

        platform1 = UnityEngine.Object.Instantiate(platform, new Vector3(0, -5, 0), Quaternion.identity);

        background1 = UnityEngine.Object.Instantiate(background, new Vector3(0, 0, 0), Quaternion.identity);

        Debug.Log(player1.transform.position);

        last_generated_platform = new Vector3(0, -5, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //GameObject player1 = GameObject.FindGameObjectsWithTag("Player")[0];

        if (player1 != null)
        {
            if (player1.transform.position.x > last_generated_platform.x + 9)
            {
                last_generated_platform.x = player1.transform.position.x + 9;
                spawnPlatform(platform, last_generated_platform);
                spawnBackground(background, new Vector3(last_generated_platform.x, last_generated_platform.y+5, last_generated_platform.z));

                platforms = GameObject.FindGameObjectsWithTag("Platform");
                if (platforms.Length > 5)
                {
                    Destroy(platforms[0]);
                }
                backgrounds = GameObject.FindGameObjectsWithTag("BG_Image");
                if (backgrounds.Length > 5)
                {
                    Destroy(backgrounds[0]);
                }

            }
           

        }

       

        
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
}
