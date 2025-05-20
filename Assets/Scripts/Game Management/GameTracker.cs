using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTracker : MonoBehaviour
{
    public static int cScore = 0;
    public static string cDifficulty = "";
    public static int easyHighScore = 0;
    public static int mediumHighScore = 0;
    public static int hardHighScore = 0;
    public static int impossibleHighScore = 0;

    public GameObject scoreUI;
    public TextMeshProUGUI[] difficultyTexts;
    public GameObject menuUI;
    public GameObject startUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SaveState()
    {
        if(cDifficulty.Equals("Easy") && cScore > easyHighScore)
        {
            easyHighScore = cScore;
        }
        if (cDifficulty.Equals("Medium") && cScore > mediumHighScore)
        {
            mediumHighScore = cScore;
        }
        if (cDifficulty.Equals("Hard") && cScore > hardHighScore)
        {
            hardHighScore = cScore;
        }
        if (cDifficulty.Equals("Impossible") && cScore > impossibleHighScore)
        {
            impossibleHighScore = cScore;
        }
    }

    public void LoadScoreMenu()
    {
        startUI.SetActive(false);
        menuUI.SetActive(true);
        scoreUI.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            difficultyTexts[i].SetText("Easy: " + easyHighScore);
        }

        for (int i = 4; i < 8; i++)
        {
            difficultyTexts[i].SetText("Medium: " + mediumHighScore);
        }

        for (int i = 8; i < 12; i++)
        {
            difficultyTexts[i].SetText("Hard: " + hardHighScore);
        }

        for (int i = 12; i < 16; i++)
        {
            difficultyTexts[i].SetText("Impossible: " + impossibleHighScore);
        }
    }
}
