using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScene : MonoBehaviour
{
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetKey(KeyCode.Space))
        {
            if (scene.name == "ControlHelp")
            {
                SceneManager.LoadScene("Ingame");
            }
        }
    }
}
