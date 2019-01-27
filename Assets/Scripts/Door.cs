using UnityEngine;

public class Door : MonoBehaviour
{
    public Room room_1;
    public Room room_2;

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
                    break;
                case false:
                    room_1.TriggerRoomEnter();
                    room_2.TriggerRoomExit();
                    Debug.Log("Door: from " + room_2.gameObject.name + " to " + room_1.gameObject.name);
                    break;
            }
        }
    }
}
