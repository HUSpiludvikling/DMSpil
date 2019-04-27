using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairWallDestory : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("CollisionEnter");
        if (col.gameObject.CompareTag("Wheelie"))
        {
            if(col.transform.parent.GetComponent<WheelieSpec>().turboMode)
            {
                Debug.Log(col.transform.parent.GetComponent<Rigidbody2D>().velocity.magnitude);
                Debug.Log("CollisionEnter1");

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //anim.SetBool("DestoryWall", true);

            }

        }
    }
}
