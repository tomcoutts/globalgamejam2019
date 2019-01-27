using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LivingRoomGameStart : Door
{
    public PlayerState playerState;
    public GameObject entranceDoor;

    public Light[] lights = new Light[5];

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            room_2.TriggerRoomEnter();
            room_1.TriggerRoomExit();
        }
        playerState.doorTarget = entranceDoor;
        playerState.desiredLocation = playerState.doorTarget.transform.rotation * Quaternion.Euler(0.0f, 150.0f, 0.0f);
        playerState.StartCoroutine("OpenDoorRoutine");

        foreach (Light light in lights)
        {
            light.gameObject.SetActive(true);
        }
        StartCoroutine("Timer");

        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Worked!");
        playerState.ChangeChapter();

        gameObject.SetActive(false);
        yield return null;
    }
}
