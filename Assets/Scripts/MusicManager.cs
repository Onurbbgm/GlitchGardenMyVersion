using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load");
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = levelMusicChangeArray[0];
        audioSource.loop = true;
        audioSource.Play();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private void OnEnable()  //this method is required to replace OnLevelWasLoaded().
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // subscribe
    }
    private void OnDisable()  //this method is required to replace OnLevelWasLoaded().
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; //unsubscribe
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("MusicPlayer: Loaded level " + scene.buildIndex);
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        if (scene.buildIndex == 0)  
        {
            audioSource.clip = levelMusicChangeArray[0];
        }
        if (scene.buildIndex == 1)
        {
            audioSource.clip = levelMusicChangeArray[1];
        }
        if (scene.buildIndex == 2)
        {
            audioSource.clip = levelMusicChangeArray[2];
        }
        if (scene.buildIndex == 3)
        {
            audioSource.clip = levelMusicChangeArray[3];
        }
        audioSource.Play();
    }
}
