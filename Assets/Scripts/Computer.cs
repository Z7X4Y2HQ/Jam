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
    public bool playingPuzzle = false;

    private void OnTriggerEnter(Collider other)
    {
        computerClose.text = "Computer Close : Yes";
        InteractE.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(OpenWordle());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        computerClose.text = "Computer Close : No";
        InteractE.SetActive(false);
    }

    private IEnumerator OpenWordle()
    {
        levelLoader.gameObject.SetActive(true);
        levelLoader.Play("FadeInBlack");
        WordleCam.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Wordle");

    }
}
