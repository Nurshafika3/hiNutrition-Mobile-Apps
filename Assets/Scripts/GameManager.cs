using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // Array to hold all categories (each category is a different QuestionData Scriptable Object)
    public QuestionData[] categories;

    //Reference to the selected category's QuestionData Scriptable Object
    private QuestionData selectedCategory;

    // Index to track the current question within the selected category
    private int currentQuestionIndex = 0;

    //UI elements to display the question text, image and reply buttons
    public TMP_Text questionText; //TextMeshPro
    public UnityEngine.UI.Image questionImage;
    public Button[] replyButtons;

    [Header("Score")]
    public ScoreManager score;
    public int correctReply = 10;
    public int wrongReply = 5;
    public TextMeshProUGUI scoreText;

    [Header("correctReplyIndex")]
    public int correctReplyIndex;
    int correctReplies;

    [Header("Game Finished Panel")]
    public GameObject GameFinished;


    void Start()
    {
        int selectedCategoryIndex = PlayerPrefs.GetInt("SelectedCategory" , 0);
        GameFinished.SetActive(false);
        SelectCategory(selectedCategoryIndex);
        //LoadProgress(selectedCategoryIndex);
    }

    //Method to select a category based on the player's choice
    // categoryIndex: the index of the category selected by the player
    public void SelectCategory(int categoryIndex)
    {
        // Set the selectedCategory to the chosen category's QuestionData Scriptable Object
        selectedCategory = categories[categoryIndex];
        // Reset the current question index 
        currentQuestionIndex = 0;
        //Display the first question in the selected category
        DisplayQuestion();
    }

    // Method to display the current question
    public void DisplayQuestion()
    {
        //Check if a category has been selected
        if (selectedCategory == null) return;

        ResetButtons();

        //Get the current question from the selected category
        var question = selectedCategory.questions[currentQuestionIndex];

        // Set the question text in the UI 
        questionText.text = question.questionText;

        //Set the question image in the UI
        questionImage.sprite = question.questionImage;

        //Loop through all reply buttons and set their text to the corresponding replies
        for (int i = 0; i < replyButtons.Length; i++)
        {
            //Use TextMeshPro component for reply buttons
            TMP_Text buttonText = replyButtons[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = question.replies[i];
        }
    }

    // Method to handle when a player selects reply
    public void OnReplySelected(int replyIndex)
    {
        //Check if the selected reply is correct
        if (replyIndex == selectedCategory.questions[currentQuestionIndex].correctReplyIndex)
        {
            score.AddScore(correctReply);
            correctReplies++;
            Debug.Log("Correct Reply!");
        }
        else
        {
            score.SubtractScore(wrongReply);
            Debug.Log("Wrong Reply!");
        }

        //SaveProgress();
        //Proceed to the next question/ end the quiz (all q are answered)
        currentQuestionIndex++;
        //SaveProgress();
        if (currentQuestionIndex < selectedCategory.questions.Length)
        {
            DisplayQuestion(); // Display next question
        }
        else
        {
            ShowGameFinishedPanel();
            Debug.Log("Quiz Finished!");
            //Implement what happens when the quiz is finished
        }

    }

    //Call this method when want to show correct reply
    public void ShowCorrectReply()
    {
        correctReplyIndex = selectedCategory.questions[currentQuestionIndex].correctReplyIndex;

        //Loop through all button
        for (int i = 0; i < replyButtons.Length; i++)
        {
            if (i == correctReplyIndex)
        
        {
            replyButtons[i].interactable = true; //Show correct value
        }
        else
        {
            replyButtons[i].interactable = false; //Hide the incorrect buttons

        }
    }
}
    public void ResetButtons()
    {
        foreach (var button in replyButtons)
        {
          button.interactable = true;
        }
    }

    public void ShowGameFinishedPanel()
    {
        GameFinished.SetActive(true);
        scoreText.text = "" + correctReplies + " / " + selectedCategory.questions.Length;
    }

    //private void SaveProgress()
    //{
    //    PlayerPrefs.SetInt("LastQuestionIndex_" + selectedCategory.name, currentQuestionIndex);
    //    PlayerPrefs.Save();
    //}

    //private void LoadProgress(int categoryIndex)
    //{
    //    string categoryName = categories[categoryIndex].name;
    //    currentQuestionIndex = PlayerPrefs.GetInt("LastQuestionIndex_" + categoryName, 0);

    //    //Start quiz from loaded progress
    //    DisplayQuestion();
    //}

    public void GoBack()
    {
        SceneManager.LoadScene("QuizMenu");
    }
}

