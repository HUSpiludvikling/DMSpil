using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string load;

    private void Update()
    {
        if(Input.GetButtonDown("SpecJ1") || Input.GetButtonDown("SpecJ2") || Input.GetButtonDown("SpecJ3"))
        {
            LevelLoad();
        }
    }

    public void LevelLoad()
    {
        SceneManager.LoadScene(load);
    }

}
