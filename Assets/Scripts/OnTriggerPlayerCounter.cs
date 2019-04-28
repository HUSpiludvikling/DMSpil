using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerPlayerCounter : MonoBehaviour
{

    PlayerChaser pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponentInParent<PlayerChaser>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wheelie") || collision.CompareTag("Leggie") || collision.CompareTag("Angstie"))
        {
            pc.players.Add(collision.gameObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(pc.players.Contains(collision.gameObject))
        {
            pc.players.Remove(collision.gameObject);
        }
    }

}
