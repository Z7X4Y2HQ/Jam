using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    public Transform roomSpawnPoint;
    public Transform roadSpawnPoint;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Other name" + other.gameObject.name);
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Player")
        {
            if (gameObject.name == "RoomElevatorFloor")
            {
                other.gameObject.transform.position = roadSpawnPoint.position;
            }
            else if (gameObject.name == "RoadElevatorFloor")
            {
                other.gameObject.transform.position = roomSpawnPoint.position;
            }
        }
    }
}
