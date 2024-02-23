using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [HideInInspector] public float time = 10f;
    public TMP_Text timer;

    private void Start()
    {
        timer.text = time.ToString();
    }

    private void Update()
    {
        if (IdentifyWord.gameState == "")
        {
            time -= Time.deltaTime;
        }
        timer.text = Mathf.Round(time).ToString();
        if (time < 0)
        {
            time = 0;
        }
    }
}
