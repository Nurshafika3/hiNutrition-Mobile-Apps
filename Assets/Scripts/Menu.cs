using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   

    public void StartButton()
    {
        SceneManager.LoadScene("QuizMenu");
     
    }

    public void ARButton(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


    public void Quitgame()
    {
        Application.Quit();
    }
}
