using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnKeyCode : MonoBehaviour
{
    char[] keys = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    [HideInInspector] public char key;

    public void ReturnKeyPressed()
    {
        foreach (char i in keys)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                key = i;
                return;
            }
            else
            {
                key = ' ';
            }
        }
    }
}