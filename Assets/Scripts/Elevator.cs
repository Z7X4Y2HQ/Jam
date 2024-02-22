using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public TMP_Text elevatorClose;
    public TMP_Text elevatorOpenText;
    private bool elevatorOpen;
    public Wardrobe wardrobe;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (wardrobe.readyForOut)
        {
            animator.SetBool("ElevatorOpen", true);
        }
        elevatorClose.text = "Elevator Close : Yes";
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && wardrobe.readyForOut)
        {
            elevatorOpen = true;
            elevatorOpenText.text = "Elevator Open : Yes";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("ElevatorOpen", false);
        elevatorClose.text = "Elevator Close : No";
    }
}
