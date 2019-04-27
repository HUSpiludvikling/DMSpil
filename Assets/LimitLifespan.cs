using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitLifespan : MonoBehaviour
{

    [SerializeField] [Range(5f, 30f)] float lifetime = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

}
