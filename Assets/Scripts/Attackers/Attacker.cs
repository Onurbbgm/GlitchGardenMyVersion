using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

  //  [Range (-1f,1.5f)]
    private float currentSpeed;
    private GameObject currentTarget;    

	// Use this for initialization
	void Start () {
        //Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        //myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision + "triger enter");
    }*/

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //Called from the animator at the time of the actual blow
    public void StrikeCurrentTarget(float damage)
    {
        Debug.Log(name+" Damage " + damage);
    }

    //Puts attacker in attack mode
    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
