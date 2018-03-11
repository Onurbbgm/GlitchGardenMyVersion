using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    private Button[] buttonArray;
    public static GameObject selectedDefender;
    private Text costText;

    // Use this for initialization
    void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        costText = GetComponentInChildren<Text>();
        if (costText)
        {
            costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
        }
        else
        {
            Debug.LogWarning(name + " has no cost text");
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
        selectedDefender = defenderPrefab;
        print(selectedDefender);
    }

}
