using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEntrance : Door
{
    public PointerRotation pointerRotation;

    private void Start()
    {
        pointerRotation = GameObject.FindObjectOfType<PointerRotation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (room_1.playerIsIn)
            {
                case true:
                    room_2.TriggerRoomEnter();
                    room_1.TriggerRoomExit();
                    Debug.Log("Door: from " + room_1.gameObject.name + " to " + room_2.gameObject.name);

                    pointerRotation.isInTheHouse = true;
                    break;
                case false:
                    room_1.TriggerRoomEnter();
                    room_2.TriggerRoomExit();
                    Debug.Log("Door: from " + room_2.gameObject.name + " to " + room_1.gameObject.name);

                    pointerRotation.isInTheHouse = false;
                    break;
            }
        }
    }
}
