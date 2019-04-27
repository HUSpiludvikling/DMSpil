using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private ActorMovementManager AMM;
    // Start is called before the first frame update
    void Start()
    {
        AMM = GetComponent<ActorMovementManager>();
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
