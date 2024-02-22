using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public TMP_Text computerClose;

    private void OnTriggerEnter(Collider other)
    {
        computerClose.text = "Computer Close : Yes";
    }
    private void OnTriggerExit(Collider other)
    {
        computerClose.text = "Computer Close : No";
    }
}
