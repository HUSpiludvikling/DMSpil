using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToPosition : MonoBehaviour
{

    public Vector3 location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator moveTowards(Collider2D collision)
    {
        Rigidbody2D rb2d = collision.GetComponent<Rigidbody2D>();
        ActorMovementManager Amm = collision.GetComponent<ActorMovementManager>();

        rb2d.bodyType = RigidbodyType2D.Kinematic;
        rb2d.gravityScale = 0f;
        rb2d.velocity = Vector2.zero;
        collision.enabled = false;
        Amm.enabled = false;

        Vector2 speed = Vector2.zero;

        while(Vector2.Distance(collision.transform.position, location) > 0.1f)
        {
            yield return new WaitForEndOfFrame();
            collision.transform.position = Vector2.SmoothDamp(collision.transform.position, location, ref speed, 0.5f);
        }

        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.gravityScale = 1f;
        collision.enabled = true;
        Amm.enabled = true;
    }

    public void ExecuteMove(Collider2D col)
    {
        StartCoroutine(moveTowards(col));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Wheelie") || collision.transform.CompareTag("Leggie"))
        {
            GameObject handler = new GameObject();
            handler.AddComponent<TeleportToPosition>().location = location;
            handler.GetComponent<TeleportToPosition>().ExecuteMove(collision.collider);
            Destroy(handler.gameObject, 10f);
            Destroy(this.gameObject);
            // StartCoroutine(moveTowards(collision.collider));
        }
    }

}
