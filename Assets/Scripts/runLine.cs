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
        lr.sortingLayerName = "Foreground";
        location = GetComponentInParent<TeleportToPosition>().location;
    }

    // Update is called once per frame
    void Update()
    {
        
        lr.SetPositions(new[] { transform.position, location + (Vector3.down * 1f) });
    }
}
