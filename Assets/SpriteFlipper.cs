using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private ActorMovementManager AMM;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        AMM = GetComponent<ActorMovementManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AMM.horizontal != 0)
        {
            transform.localScale = new Vector3(AMM.horizontal, 1, 1);
        }
    }
}
