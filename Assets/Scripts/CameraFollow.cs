using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    List<GameObject> ActivePlayers;

    Vector3 speed = Vector3.zero;

    Vector3 middlePoint;

    Vector3 offset = new Vector3(0, 0, -10f);

    float intentedCameraSize = 5f;
    float camspeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        intentedCameraSize = Camera.main.orthographicSize;

        ActivePlayers = new List<GameObject>();
        ActivePlayers.Add(GameObject.FindGameObjectWithTag("Wheelie"));
        ActivePlayers.Add(GameObject.FindGameObjectWithTag("Angstie"));
        ActivePlayers.Add(GameObject.FindGameObjectWithTag("Leggie"));

        ActivePlayers.RemoveAll(x => x == null);

        Debug.Log("Fandt " + ActivePlayers.Count + " aktive spillere!");

    }

    Vector3 averageVector()
    {
        return new Vector3(ActivePlayers.Average(x => x.transform.position.x) , ActivePlayers.Average(x => x.transform.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        middlePoint = averageVector() + offset;

        transform.position = Vector3.SmoothDamp(transform.position, middlePoint, ref speed, 0.5f);
        float[] ViewportPoints = new float[2]; 
        foreach (GameObject item in ActivePlayers)
        {
            ViewportPoints[0] = ActivePlayers.Max(x => Mathf.Abs(Camera.main.WorldToViewportPoint(x.transform.position).x));
            ViewportPoints[1] = ActivePlayers.Max(x => Mathf.Abs(Camera.main.WorldToViewportPoint(x.transform.position).y));
            if (Mathf.Max(ViewportPoints) >= 0.85f)
            {
                intentedCameraSize += 0.05f;
            }
            else if (Mathf.Max(ViewportPoints) <= 0.8f)
            {
                intentedCameraSize = (intentedCameraSize <= 5 ? intentedCameraSize = 5 : intentedCameraSize - 0.1f);
                
            }
            Debug.Log(ViewportPoints[0] + " " + ViewportPoints[1]);
            Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, intentedCameraSize, ref camspeed, 0.9f);

        }

    }
}
