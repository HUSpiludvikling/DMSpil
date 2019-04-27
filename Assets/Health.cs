using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float life = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float Damage)
    {
        life -= Damage;
        Debug.Log(life);
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
