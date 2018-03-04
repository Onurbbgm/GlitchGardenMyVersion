using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    //Good for deleting when objects get off camerea, but the object itself has to have a sprite render, not useful in this case,
    //because Body is the one with sprite render, not the parent game object
    /*private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }*/

}
