using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour
{
    public int points;

    public Text pointsText;

    public Text gameOverText;

    public Text gameOverText2;

    public Button startButton;

    public Image instructionScroll;

    private void Update()
    {
        pointsText.text = ("Scores: " + points);
    }

    public void setNextScreen(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void showInstruction()
    {
        instructionScroll.gameObject.SetActive(true);
    }

    public void hideInstruction()
    {
        instructionScroll.gameObject.SetActive(false);
    }
}
