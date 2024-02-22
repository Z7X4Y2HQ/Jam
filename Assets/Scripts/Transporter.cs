using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    public Transform roomSpawnPoint;
    public Transform roadSpawnPoint;
    public GameObject InteractE;

    private void OnTriggerEnter(Collider other)
    {
        InteractE.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        InteractE.SetActive(false);
    }



    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Other name" + other.gameObject.name);
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Player")
        {
            if (gameObject.name == "RoomElevatorFloor")
            {
                TransortCharacter(other, roadSpawnPoint.position);
            }
            else if (gameObject.name == "RoadElevatorFloor")
            {
                TransortCharacter(other, roomSpawnPoint.position);
            }
        }
    }

    private void TransortCharacter(Collider other, Vector3 position)
    {
        other.GetComponent<CharacterController>().enabled = false;
        other.gameObject.transform.position = position;
        other.GetComponent<CharacterController>().enabled = true;
    }
}
