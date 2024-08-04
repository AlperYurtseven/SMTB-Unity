using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{   

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        while (gameManager == null){
            gameManager = GameObject.Find("GameManagerObj").GetComponent<GameManager>();
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObject()
    {

        Destroy(gameObject);

    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            gameManager.destroySoundPlay();
            DestroyObject();
        }

    }
}
