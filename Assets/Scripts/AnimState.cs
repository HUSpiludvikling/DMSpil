using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimState : MonoBehaviour
{
    private ActorMovementManager AMM;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        AMM = GetComponentInParent<ActorMovementManager>();
        AMM.jumpEvent.AddListener(RunJump);
        AMM.specEvent.AddListener(SpecStart);
        AMM.specUpEvent.AddListener(SpecStop);
    }

    // Update is called once per frame
    void Update()
    {
        if(AMM.horizontal != 0)
        {
            Anim.SetBool("Run", true);
        }
        else
        {
            Anim.SetBool("Run", false);
        }
       
    }
    void RunJump()
    {
        StartCoroutine(SetJumpOnOFF());
    }
    void SpecStart()
    {
        Anim.SetBool("4", true);
    }
    void SpecStop()
    {
        Anim.SetBool("4", false);
    }

    IEnumerator SetJumpOnOFF()
    {
        Anim.SetBool("Jump", true);
        yield return new WaitForSeconds(0.1f);
        Anim.SetBool("Jump", false);
    }
}
