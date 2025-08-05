using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARButton : MonoBehaviour
{

    public void ButtonHome(string scenename)
    {
        SceneManager.LoadScene(scenename);

    }

}