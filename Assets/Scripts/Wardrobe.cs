using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public TMP_Text wardrobeClose;
    public TMP_Text readyText;
    public bool readyForOut = false;
    public GameObject InteractE;

    private void OnTriggerEnter(Collider other)
    {
        wardrobeClose.text = "Wardrobe Close : Yes";
        InteractE.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            readyForOut = true;
            readyText.text = "Ready for Out : Yes";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        wardrobeClose.text = "Wardrobe Close : No";
        InteractE.SetActive(false);
    }
}
