using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this line for TextMeshPro
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public ScoreData    data;
    public TMP_Text     scoreText;
    private bool        displayScore = false;

    public void PlayGame() {
        SceneManager.LoadScene("MapScene");
    }

    public void ToggleScores()
    {
        displayScore = !displayScore;
        if (displayScore)
        {
            scoreText.text = "High Scores:\n";
            foreach (ScoresItem player in data.scores) {
                if (player.name == "")
                    continue;
                scoreText.text += player.name + ": ";
                scoreText.text += player.score.ToString() + "\n";
            }
        }
        else
            scoreText.text = "";
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
