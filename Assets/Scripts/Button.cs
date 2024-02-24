using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Button : MonoBehaviour
{
    public GameObject puzzleGame;
    public GameObject puzzleMenu;
    public GameObject difficulties;
    public Animator levelLoader;
    public Currency currency;
    public Timer timer;
    public UnityEngine.UI.Button moveForwardButton;

    private void Awake()
    {
        levelLoader.Play("FadeOutBlack");
    }
    public void TestYourself()
    {
        moveForwardButton.enabled = true;
        difficulties.SetActive(true);
        puzzleMenu.SetActive(false);
    }

    public void GiveUp()
    {
        StartCoroutine(GoBack());
    }

    public void MoveForward()
    {
        StartCoroutine(MoveForwardCoroutine());
    }

    public void Win()
    {
        IdentifyWord.gameState = "win";
        MoveForward();
    }
    public void lose()
    {
        IdentifyWord.gameState = "lose";
        MoveForward();
    }



    public void Easy()
    {
        puzzleGame.SetActive(true);
        difficulties.SetActive(false);
        timer.time = 360f;
        Currency.money -= 40;
        currency.moneyText.text = "Money : $" + Currency.money.ToString();
    }
    public void Medium()
    {
        puzzleGame.SetActive(true);
        difficulties.SetActive(false);
        timer.time = 240f;
        Currency.money -= 30;
        currency.moneyText.text = "Money : $" + Currency.money.ToString();
    }
    public void Hard()
    {
        puzzleGame.SetActive(true);
        difficulties.SetActive(false);
        timer.time = 120f;
        Currency.money -= 20;
        currency.moneyText.text = "Money : $" + Currency.money.ToString();
    }

    public IEnumerator GoBack()
    {
        levelLoader.Play("FadeInBlack");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("SampleScene");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator MoveForwardCoroutine()
    {
        moveForwardButton.enabled = false;
        if (IdentifyWord.gameState == "lose")
        {
            Brunch.life -= 1;
        }
        else if (IdentifyWord.gameState == "win" && Brunch.life != 2)
        {
            Brunch.life += 1;
        }
        Brunch.puzzle += 1;
        levelLoader.Play("FadeInBlack");
        yield return new WaitForSeconds(1.5f);
        DisplayWord.charIndex = 0;
        SceneManager.LoadScene("SampleScene");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = Computer.playerPosition;
        player.transform.eulerAngles = Computer.playerDirection;
        player.GetComponent<CharacterController>().enabled = true;
        GameObject WorkRoom = GameObject.Find("Work Room");
        if (IdentifyWord.gameState == "lose")
        {
            WorkRoom.SetActive(false);
        }
        else
        {
            WorkRoom.SetActive(true);
        }
    }
}
