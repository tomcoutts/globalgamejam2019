using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<AudioSource> roomSounds;
    public List<Door> doors;

    public float fadeTime = 0.5f;

    public bool playerIsIn = false;

    public void TriggerRoomEnter ()
    {
        playerIsIn = true;

        foreach (AudioSource audio in roomSounds)
        {
            if(!audio.isPlaying)
                audio.Play();
            else
            {
                audio.Stop();
                audio.Play();
            }
        }
    }

    public void TriggerRoomExit()
    {
        playerIsIn = false;
        foreach (AudioSource audio in roomSounds)
        {
            if (audio.isPlaying)
                audio.Stop();
        }
    }
}
