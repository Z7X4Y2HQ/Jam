using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayWord : ReturnKeyCode
{
    public TMP_Text[] playerGuess;
    private char lastKeyPressed;
    public static int charIndex = 0;
    public static bool wordComplete = false;
    public TMP_Text triedList;
    private int i = 0;

    private void Update()
    {
        DisplayCharater();
        RemoveCharacter();
        if (charIndex == 5)
        {
            wordComplete = true;
        }
        else
        {
            wordComplete = false;
        }

    }
    public void DisplayCharater()
    {
        if (Input.anyKeyDown && charIndex <= 4)
        {
            ReturnKeyPressed();
            lastKeyPressed = key;
            if (key != ' ')
            {
                playerGuess[charIndex].text = key.ToString().ToUpper();
                charIndex++;
            }
            else if (key == ' ')
            {
                playerGuess[charIndex].text = lastKeyPressed.ToString().ToUpper();
            }
        }
    }

    public void RemoveCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && charIndex != 0 && IdentifyWord.gameState == "")
        {
            playerGuess[charIndex - 1].text = "";
            charIndex--;
        }
    }

    public void ClearWord()
    {
        for (int i = 0; i < 5; i++)
        {
            playerGuess[i].text = "";
            playerGuess[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color = Color.white;
        }
        charIndex = 0;
    }

    public void TriedWord()
    {
        triedList.text += IdentifyWord.tries + 1 + ".";
        for (i = 0; i < 5; i++)
        {
            if (playerGuess[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color == Color.green)
            {
                triedList.text += "<color=green>" + playerGuess[i].text;
            }
            else if (playerGuess[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color == Color.yellow)
            {
                triedList.text += "<color=yellow>" + playerGuess[i].text;
            }
            else if (playerGuess[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color == Color.red)
            {
                triedList.text += "<color=red>" + playerGuess[i].text;
            }
            else
            {
                triedList.text += playerGuess[i].text;
            }
        }
        triedList.text += "<color=white>\n";
    }
}
