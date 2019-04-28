using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    internal bool walled = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "FearAura")
        {
            walled = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision); //Haha
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        walled = false;
    }
}
