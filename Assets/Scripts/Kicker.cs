﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<ActorMovementManager>().specEvent.AddListener(Kick);       
    }

    private void Kick()
    {
        RaycastHit2D[] inFront = Physics2D.RaycastAll(transform.parent.position, transform.position, 2f);
        foreach (var item in inFront)
        {
            Debug.Log(item.transform.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}