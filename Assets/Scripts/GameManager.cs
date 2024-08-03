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


        
    }

    public void spawnPlatform(GameObject platform_prefab, Vector3 create_position)
    {
        GameObject platform1 = UnityEngine.Object.Instantiate(platform_prefab, create_position, Quaternion.identity);
        platforms.Add(platform1);
    }
}
