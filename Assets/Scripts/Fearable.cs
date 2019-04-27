using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEvent : UnityEvent<float> { }

public class Fearable : MonoBehaviour
{
    bool feared = false;
    Rigidbody2D rb2d;
    ActorMovementManager AMM;

    internal FloatEvent staminaTransmit;


    float minimumDistance = 6;

    uint stamina = 100;

    private void Awake()
    {

        staminaTransmit = new FloatEvent();
    }

    private void Start()
    {
        AMM = GetComponent<ActorMovementManager>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "FearAura")
        {
            Debug.Log("GetSpooked");

            if(!feared)
            {
                StartCoroutine(FearMode(collision));
            }
            feared = true;

            

        }
    }

    IEnumerator FearMode(Collider2D coll)
    {
        float speedStore = AMM.SpeedMod;
        AMM.SpeedMod /= 2f;
        while (coll != null && Vector2.Distance(coll.transform.position, transform.position) < minimumDistance)
        {

            if (stamina == 0)
            {
                AMM.SpeedMod = 0f;
            }
            else
            {
                stamina--;
                staminaTransmit.Invoke(stamina);
            }

            yield return new WaitForEndOfFrame();
        }
        





        Debug.Log("It's cool again!");
        AMM.SpeedMod = speedStore;
        stamina = 100;
        staminaTransmit.Invoke(stamina);
        feared = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
    }

}
