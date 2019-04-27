using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    internal bool grounded = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision); //Haha
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;   
    }
}
