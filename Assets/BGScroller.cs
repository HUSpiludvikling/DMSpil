using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGScroller : MonoBehaviour
{
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.material.SetTextureOffset("_MainTex", new Vector2((Time.timeSinceLevelLoad / 4f) % img.mainTexture.width, 0f));
        //img.material.SetTextureOffset("_MainTex", img.material.GetTextureOffset("_MainTex") + Vector2.right);
    }
}
