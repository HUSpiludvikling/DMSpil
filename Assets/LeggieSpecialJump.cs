using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeggieSpecialJump : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<ActorMovementManager>().player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
