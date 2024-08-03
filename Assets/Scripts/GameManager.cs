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

    public GameObject platform;

    public GameObject background;

    GameObject player1;

    public List<Vector3> platform_locations;
    public List<Vector3> bg_locations;

    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }

        GameObject player1 = UnityEngine.Object.Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (player1.transform.position.x > 5){
            if(new Vector3(10, 0, 0) != platform_locations[platform_locations.Count - 1]){
                spawnPlatform(platform, new Vector3(10, 0, 0));
                spawnBackground(background, new Vector3(10, 0, 0));
            }
        }

        if (player1.transform.position.x < -5){
           if(new Vector3(-10, 0, 0) != platform_locations[platform_locations.Count - 1]){
                spawnPlatform(platform, new Vector3(-10, 0, 0));
                spawnBackground(background, new Vector3(-10, 0, 0));
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
