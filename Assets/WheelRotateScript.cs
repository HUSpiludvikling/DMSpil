using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotateScript : MonoBehaviour
{
    public float wheelRotateSpeed;
    private ActorMovementManager AMM;
    // Start is called before the first frame update
    void Start()
    {
        AMM = GetComponentInParent<ActorMovementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -wheelRotateSpeed*AMM.horizontal);
    }
}
