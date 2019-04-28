using System;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour 
{
    internal FloatEvent livEvent;

    private void Awake()
    {
        livEvent = new FloatEvent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage();
        }
    }

    float health = 100f;
    internal void TakeDamage(float damage = 10)
    {
        health -= damage;
        livEvent.Invoke(health);
        if(health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}