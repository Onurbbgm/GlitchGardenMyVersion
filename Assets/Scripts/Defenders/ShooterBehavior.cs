using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour {

    public GameObject projectile,  gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        animator = GetComponent<Animator>();
        SetMyLaneSpawner();
       // print(myLaneSpawner);
    }

    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

    //Look through all spawners, and set myLanseSpawner if found
    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach(Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + " can't find spawner in lane");
    }

    bool IsAttackerAheadInLane()
    {
        //Exit if no attackers is in lane
        if (myLaneSpawner.transform.childCount <=0)
        {
            return false;
        }
        //If there are attackers, are they ahead?
        foreach(Transform childAttacker in myLaneSpawner.transform)
        {
            if(childAttacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        //Attackers in lane, but behind us
        return false;
    }

}
