using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float life = 100;

    public FloatEvent livEvent;

    // Start is called before the first frame update
    void Awake()
    {
        livEvent = new FloatEvent();
    }

    

    public void TakeDamage(float Damage)
    {
        life -= Damage;
        livEvent.Invoke(life);
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
