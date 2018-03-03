using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class FoxBehavior : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject obj = collision.gameObject;

        //Abort if not colliding with a defender
        if(!obj.GetComponent<Defender>())
        {
            return;
        }

        if (obj.GetComponent<StoneBehavior>())
        {
            anim.SetTrigger("jumpingTrigger");
        }
        else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
        Debug.Log(collision + "triger enter");

    }

}
