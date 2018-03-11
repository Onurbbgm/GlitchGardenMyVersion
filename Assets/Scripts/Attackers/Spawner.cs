using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackersPrefabs;
    
	// Update is called once per frame
	void Update () {
	    foreach(GameObject thisAttacker in attackersPrefabs)
        {
            if (IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }	
	}

    bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;
        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }
        //Divided by 5 because there are 5 lanes(5 spawners)
        float threshold = spawnsPerSecond * Time.deltaTime /5 ;
        return (Random.value < threshold);        
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }
}
