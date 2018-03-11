using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;
    private int levelLife = 100;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D()
    {
        levelLife -= 10;
        print(levelLife);
        if (levelLife <= 0)
        {            
            levelManager.LoadLevel("Lose");
        }
        
     
    }
}
