﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject defenderParent;
    private StarDisplay starDisplay;
    private void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();        
    }
    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;
        int starCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(starCost) == StarDisplay.Status.SUCCESS )
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient stars");
        }
       
        //print(Input.mousePosition);
        //print(SnapToGrid(CalculateWorldPointOfMouseClick()));
    }

    void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        GameObject newDef = Instantiate(defender, roundedPos, Quaternion.identity) as GameObject;
        newDef.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    } 

}