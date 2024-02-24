using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computer : MonoBehaviour
{
    public TMP_Text computerClose;
    public GameObject WordleCam;
    public GameObject InteractE;
    public Animator levelLoader;
    public static Vector3 playerPosition;
    public static Vector3 playerDirection;
    public bool playingPuzzle = false;
    private Transform playerTransform;
    private string[] puzzleToLoad = { "Wordle", "Braille", "Vigenere" };
    private bool inCompRange;

    private void OnTriggerEnter(Collider other)
    {
        computerClose.text = "Computer Close : Yes";
        InteractE.SetActive(true);
        inCompRange = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Brunch.puzzle == Brunch.work && Brunch.work != 3 && inCompRange)
        {
            playerPosition = playerTransform.position;
            playerDirection = playerTransform.eulerAngles;
            StartCoroutine(OpenPuzzle());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        playerTransform = other.gameObject.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        computerClose.text = "Computer Close : No";
        InteractE.SetActive(false);
        inCompRange = false;
    }

    private IEnumerator OpenPuzzle()
    {
        levelLoader.gameObject.SetActive(true);
        levelLoader.Play("FadeInBlack");
        WordleCam.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(puzzleToLoad[Brunch.puzzle]);

    }
}
