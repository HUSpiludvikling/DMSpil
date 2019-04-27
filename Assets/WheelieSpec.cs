using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelieSpec : MonoBehaviour
{
    public bool turboMode;
    ActorMovementManager amm;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        amm = GetComponent<ActorMovementManager>();
        rb2d = GetComponent<Rigidbody2D>();
        amm.specEvent.AddListener(TurboCharge);
        amm.specUpEvent.AddListener(TurboKick);
    }
    

    void TurboCharge()
    {
        amm.HorizontalMovement = false;
        turboMode = true;
        
    }

    void TurboKick()
    {
        StartCoroutine(Activatein(1f));
    }

    IEnumerator Activatein(float Seconds)
    {
        rb2d.AddForce(transform.right * 10f * transform.localScale.x, ForceMode2D.Impulse);
        yield return new WaitForSeconds(Seconds);
        amm.HorizontalMovement = true;
        turboMode = false;
    }

}
