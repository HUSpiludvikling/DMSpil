using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerChaser : MonoBehaviour
{
    public List<GameObject> players;
    Rigidbody2D rb2d;
    GameObject target;
    private void Awake()
    {
        players = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(players.Count > 0)
        {
            if(players.Count == 1)
            {
                target = players[0];
            }
            else
            {
                target = players.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).First();
            }
            
            rb2d.velocity = new Vector2(target.transform.position.x > transform.position.x ? 1 : -1, 0f);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

}
