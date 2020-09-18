using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if(IsAttackerInLane())
        {
            //Debug.Log("shoot pew pew");
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            //Debug.Log("sit and wait");
            animator.SetBool("IsAttacking", false);
        }
    }



    private void SetLaneSpawner()
    {
        AttackSpawner[] spawners = FindObjectsOfType<AttackSpawner>();

        foreach (AttackSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }


    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile,gun.transform.position,gun.transform.rotation) as GameObject;
        newProjectile.transform.parent = transform;
    }

}
