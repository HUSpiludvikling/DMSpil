using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecHook : MonoBehaviour
{
    [SerializeField] GameObject hookGO;
    bool hookActive = false;
    GroundCheck groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        groundCheck = transform.parent.GetComponentInChildren<GroundCheck>();
        GetComponentInParent<ActorMovementManager>().specEvent.AddListener(DoHook);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoHook()
    {
        if(groundCheck.grounded && RayCheck())
        {
            GameObject temp;
            temp = Instantiate(hookGO, transform.position, Quaternion.identity, null);
            temp.GetComponent<TeleportToPosition>().location = transform.parent.position + (Vector3.up / 2f);
        }
    }

    private bool RayCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f);

        return hit.transform == null;
        
    }
}
