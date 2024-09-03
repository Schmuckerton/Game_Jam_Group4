using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //adds scene control

public class GoToLevel : MonoBehaviour
{
    //method takes build index integer and loads that scene
   public void loadTheLevel(int buildNum)
   {
       Time.timeScale = 1;
       SceneManager.LoadScene(buildNum);
   }
    public void Resetlevel()
    {
       Time.timeScale = 1;
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
