using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public TMP_Text bedClose;

    private void OnTriggerEnter(Collider other)
    {
        bedClose.text = "Bed Close : Yes";
    }

    private void OnTriggerExit(Collider other)
    {
        bedClose.text = "Bed Close : No";
    }
}
