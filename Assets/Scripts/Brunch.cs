using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brunch : MonoBehaviour
{
    public static int puzzle = 0;
    public static int work = 0;
    private string[] eatTime = { "Puzzle : None", "Puzzle : Breakfast", "Puzzle : Lunch", "Puzzle : Dinner" };
    public static int day = 1;
    public static int life = 2;

    public GameObject liquidRoom;
    public TMP_Text puzzleText;
    public TMP_Text workNumText;
    public TMP_Text daysNumText;
    public TMP_Text lifeNumText;
    public TMP_Text puzzleNumText;


    private void Update()
    {
        puzzleNumText.text = "Puzzle : " + puzzle.ToString();
        workNumText.text = "Work : " + work.ToString();
        daysNumText.text = "Day : " + day.ToString();
        lifeNumText.text = "Life : " + life.ToString();

        if (day == 8)
        {
            SceneManager.LoadScene("GameWon");
        }

        if (IdentifyWord.gameState == "win")
        {
            liquidRoom.SetActive(false);
        }
        else
        {
            liquidRoom.SetActive(true);
        }
        puzzleText.text = eatTime[puzzle];

        if (life == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }



}
