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

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("CollisionEnter");
        if (col.gameObject.CompareTag("Wheelie"))
        {
            Debug.Log("CollisionEnter1");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //anim.SetBool("DestoryWall", true);
        }
    }
}
