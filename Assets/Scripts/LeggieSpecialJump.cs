using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeggieSpecialJump : MonoBehaviour
{
    ActorStrings aStrings;
    GroundCheck gc;
    WallCheck[] wcs;

    public WallCheck right;
    public WallCheck left;

    Rigidbody2D rb2d;

    bool flipped = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gc = GetComponentInChildren<GroundCheck>();
        wcs = GetComponentsInChildren<WallCheck>();

        left = wcs.OrderBy(x => x.transform.position.x).First();
        right = wcs.OrderBy(x => x.transform.position.x).Last();
        //Debug.Log(right.transform.position.x);


        aStrings = GetComponent<ActorMovementManager>().strings;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ActorMovementManager>().horizontal != 0)
        {
            flipped = GetComponent<ActorMovementManager>().horizontal != 1;
        }

        Debug.Log(left.walled + " " + right.walled);
        if(Input.GetButtonDown(aStrings.jump))
        {
            if (gc.grounded)
            {
                GetComponent<ActorMovementManager>().jumpEvent.Invoke();
                rb2d.AddForce(Vector2.up * GetComponent<ActorMovementManager>().JumpMod, ForceMode2D.Impulse);

            }
            else if (left.walled || (right.walled && flipped))
            {
                //  Debug.Log("LeftWall");
                StartCoroutine(disableHorizontal(1f));
                rb2d.velocity = Vector2.right + Vector2.up;
                rb2d.AddForce(Vector2.right * 2 + Vector2.up * GetComponent<ActorMovementManager>().JumpMod, ForceMode2D.Impulse);

            }
            else if (right.walled || (left.walled && flipped))
            {
                // Debug.Log("RightWall");
                StartCoroutine(disableHorizontal(1f));
                rb2d.velocity = Vector2.left + Vector2.up;
                rb2d.AddForce(Vector2.left * 2 + Vector2.up * GetComponent<ActorMovementManager>().JumpMod, ForceMode2D.Impulse);

            }
        }
        
        
    }



    IEnumerator disableHorizontal(float time)
    {
        GetComponent<ActorMovementManager>().HorizontalMovement = false;
        yield return new WaitForSeconds(time);
        GetComponent<ActorMovementManager>().HorizontalMovement = true;
    }

}
