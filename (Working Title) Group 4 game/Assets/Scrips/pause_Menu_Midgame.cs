using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_Menu_Midgame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            void GotoPauseMenu()
            {
                SceneManager.LoadScene("Pause_Menu");

                Debug.Log("Pause.");
            }
        }
    }
}