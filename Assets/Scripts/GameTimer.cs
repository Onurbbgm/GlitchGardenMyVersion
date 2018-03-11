using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour {


    public float levelTime = 100;
    private Slider timeSlider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;


	// Use this for initialization
	void Start ()
    {
        timeSlider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("WonTitle");
        FindYouWin();
        winLabel.SetActive(false);
    }

    private void FindYouWin()
    {
        if (!winLabel)
        {
            Debug.LogWarning("Pleas create You Win object");
        }
    }

    // Update is called once per frame
    void Update () {
        timeSlider.value = (Time.timeSinceLevelLoad / levelTime);
        if(Time.timeSinceLevelLoad >= levelTime && !isEndOfLevel)
        {
            HandleWinCondition();
        }

        //print(1 - (timeLeft / levelTime));
    }

    private void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        print("Level over");
        isEndOfLevel = true;
    }

    //Destroys all objects with destroyOnWin tag
    void DestroyAllTaggedObjects()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach(GameObject tagDestroy in objectsToDestroy)
        {
            Destroy(tagDestroy);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

}
