using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    public enum Status { SUCCESS, FAILURE };

    //Text star display
    private Text text;
    private int totalStars = 100;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();        
        text.text = totalStars.ToString();
	}
	
    public void AddStars(int star)
    {
        totalStars += star;
        UpdateDisplay();
        //print(star + " stars added to display");
    }

    public Status UseStars(int star)
    {
        if (totalStars >= star)
        {
            totalStars -= star;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    void UpdateDisplay()
    {
        text.text = totalStars.ToString();
    }
}
