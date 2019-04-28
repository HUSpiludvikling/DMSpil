using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour
{
    List<ActorMovementManager> AMMs;

    [SerializeField] string load;

    // Start is called before the first frame update
    void Start()
    {
        AMMs = new List<ActorMovementManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        ActorMovementManager amm = collision.GetComponent<ActorMovementManager>();
        if (amm != null) 
        {
            AMMs.Add(amm);
            amm.specEvent.AddListener(LoadLevel);
        }
            

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ActorMovementManager amm = collision.GetComponent<ActorMovementManager>();
        if(amm != null && AMMs.Contains(amm))
        {

            amm.specEvent.RemoveListener(LoadLevel);
            AMMs.Remove(amm);
        }
    }

    void LoadLevel()
    {
        foreach (var item in AMMs)
        {
            item.specEvent.RemoveListener(LoadLevel);
        }

        SceneManager.LoadScene(load);
    }

}
