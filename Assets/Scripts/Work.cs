using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : MonoBehaviour
{
    public GameObject InteractE;
    public GameObject pill;
    private void OnTriggerEnter(Collider other)
    {
        InteractE.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && Brunch.puzzle != Brunch.work && IdentifyWord.gameState != "")
        {
            Brunch.work += 1;
            pill.SetActive(true);
            IdentifyWord.gameState = "";
            Currency.money += 30;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractE.SetActive(true);
    }
}
