using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public TMP_Text moneyText;
    [HideInInspector] public static float money = 60f;

    private void Update()
    {
        moneyText.text = "Money : $" + money.ToString();
        if (money < 0f)
        {
            money = 0;
        }
    }

}
