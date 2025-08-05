using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizMenu : MonoBehaviour
{
    public void OnCategorySelected(int categoryIndex)
    {
        PlayerPrefs.SetInt("SelectedCategory", categoryIndex);

        SceneManager.LoadScene("QuizNutrition");

    }

    //public void NutritionButton(string scenename)
    //{
    //    SceneManager.LoadScene(scenename);

    //}

    //public void FruityButton(string scenename)
    //{
    //    SceneManager.LoadScene(scenename);
    //}


    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
