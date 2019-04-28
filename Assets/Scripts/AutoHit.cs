using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHit : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator Anim;
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        StartCoroutine(HitOnTiming(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HitOnTiming(float timing)
    {
        while (true)
        {
            RaycastHit2D[] all = Physics2D.RaycastAll(transform.parent.position, transform.position, 2f);

            foreach (var item in all)
            {
                if (item.transform.CompareTag("Wheelie") || item.transform.CompareTag("Leggie") || item.transform.CompareTag("Angstie"))
                {
                    Anim.SetBool("4", true);
                    item.transform.GetComponent<PlayerHealth>().TakeDamage();
                    break;
                }
            }

            yield return new WaitForSeconds(timing);

        }
    }

}
