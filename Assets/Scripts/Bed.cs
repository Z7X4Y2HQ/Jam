using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public TMP_Text bedClose;
    public GameObject InteractE;
    public GameObject workRoom;
    private bool inBedRange;

    private void OnTriggerEnter(Collider other)
    {
        bedClose.text = "Bed Close : Yes";
        InteractE.SetActive(true);
        inBedRange = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Brunch.work == 3 && inBedRange)
        {
            Brunch.day += 1;
            Brunch.work = 0;
            Brunch.puzzle = 0;
            workRoom.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bedClose.text = "Bed Close : No";
        InteractE.SetActive(false);
        inBedRange = false;
    }
}
