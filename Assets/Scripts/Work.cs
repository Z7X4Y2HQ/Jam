using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : MonoBehaviour
{
    public GameObject InteractE;
    public GameObject pill;
    public bool inRange;
    private void OnTriggerEnter(Collider other)
    {
        InteractE.SetActive(true);
        inRange = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Brunch.puzzle != Brunch.work && IdentifyWord.gameState != "" && inRange)
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
        inRange = false;
    }
}
