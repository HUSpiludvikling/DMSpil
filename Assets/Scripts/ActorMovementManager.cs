using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Player
{
    One,
    Two,
    Three

}

public struct ActorStrings
{
    public string jump;
    public string spec;
    public string hori;
    public string vert;

    public ActorStrings(Player player)
    {
        string add = "";
        switch (player)
        {
            case Player.One:
                add = "1"; break;
            case Player.Two:
                add = "2"; break;
            case Player.Three:
                add = "3"; break;
            default:
                break;
        }


        jump = "JumpJ" + add;
        spec = "SpecJ" + add;
        hori = "HorizontalJ" + add;
        vert = "VerticalJ" + add;
    }

}

public class ActorMovementManager : MonoBehaviour
{
    public Player player;

    public bool HorizontalMovement = true;
    public bool VerticalMovement = false;

    public bool HandleJump = true;

    Rigidbody2D rb2d;

    [SerializeField]
    [Range(0.7f, 5.0f)]
    public float SpeedMod = 1.0f;

    [SerializeField]
    [Range(0.7f, 10f)]
    float JumpMod = 1.0f;


    private ActorStrings strings;

    internal UnityEvent jumpEvent;

    internal UnityEvent specEvent;

    internal float horizontal;
    internal float vertical;

    private GroundCheck gc;

    private void Awake()
    {
        jumpEvent = new UnityEvent();
        specEvent = new UnityEvent();

    }

    // Start is called before the first frame update
    void Start()
    {
        strings = new ActorStrings(player);
        rb2d = GetComponent<Rigidbody2D>();
        gc = GetComponentInChildren<GroundCheck>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(strings.spec))
        {
            specEvent.Invoke();
        }
        if (gc.grounded && Input.GetButtonDown(strings.jump))
        {
            jumpEvent.Invoke();
            if(HandleJump)
            {
                rb2d.AddForce(Vector2.up * JumpMod, ForceMode2D.Impulse);
            }
        }

        if(Input.GetAxis(strings.hori) != 0)
        {
            horizontal = Input.GetAxis(strings.hori);
        }
        else
        {
            horizontal = 0f;
        }

        if (Input.GetAxis(strings.vert) != 0)
        {
            vertical = Input.GetAxis(strings.vert);
        }
        else
        {
            vertical = 0f;
        }

        if(HorizontalMovement && VerticalMovement)
        {
            rb2d.velocity = new Vector2(horizontal, vertical) * SpeedMod;
        }
        else if (HorizontalMovement)
        {
            rb2d.velocity = new Vector2(horizontal * SpeedMod, rb2d.velocity.y);
        }

        
    }
}
