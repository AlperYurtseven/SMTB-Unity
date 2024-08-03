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

    }

    // Update is called once per frame
    void Update()
    {


        
    }
}
