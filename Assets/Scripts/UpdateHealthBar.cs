using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHealthBar : MonoBehaviour
{
    Renderer renderer;

    Renderer parentRend;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        parentRend = transform.parent.GetComponent<Renderer>();
        parentRend.enabled = false;
        renderer.enabled = false;
        transform.parent.GetComponentInParent<PlayerHealth>().livEvent.AddListener(ResizeBar);
    }

    

    private void ResizeBar(float data)
    {
        
        if (data == 100)
        {
            parentRend.enabled = false;
            renderer.enabled = false;
        }
        else
        {
            parentRend.enabled = true;
            renderer.enabled = true;
        }

        renderer.transform.localScale = new Vector3(Mathf.Min(data / 100f, 0.9f), 0.7f, 0.9f);
    }

}
