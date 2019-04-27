using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDebugger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("JumpJ1"))
        {
            Debug.Log("1F");
        }
        if (Input.GetButtonDown("JumpJ2"))
        {
            Debug.Log("2F");
        }
        if (Input.GetButtonDown("JumpJ3"))
        {
            Debug.Log("3F");
        }

        if(Input.GetAxis("HorizontalJ1") != 0)
        {
            Debug.Log("H1" + Input.GetAxis("HorizontalJ1"));
        }

        if (Input.GetAxis("HorizontalJ2") != 0)
        {
            Debug.Log("H2");
        }

        if (Input.GetAxis("HorizontalJ3") != 0)
        {
            Debug.Log("H3");
        }


    }
}
