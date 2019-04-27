using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runLine : MonoBehaviour
{
    LineRenderer lr;
    Vector3 location;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        location = GetComponentInParent<TeleportToPosition>().location;
    }

    // Update is called once per frame
    void Update()
    {
        
        lr.SetPositions(new[] { transform.position, location });
    }
}
