using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject WordleCanvas;
    public GameObject WordleMenu;
    public Animator levelLoader;

    private void Awake()
    {
        levelLoader.Play("FadeOutBlack");
    }
    public void TestYourself()
    {
        WordleMenu.SetActive(false);
        WordleCanvas.SetActive(true);
    }
}
