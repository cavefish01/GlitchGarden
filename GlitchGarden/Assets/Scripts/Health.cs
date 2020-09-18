﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damageDelt)
    {
        health -= damageDelt;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }
        else
        {
            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 0.2f);
        }
    }
}
