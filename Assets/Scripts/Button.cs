using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject defenedPrefab;
    private Button[] buttonArray;
    public static GameObject selectedDefender;

    // Use this for initialization
    void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenedPrefab;
        print(selectedDefender);
    }

}
