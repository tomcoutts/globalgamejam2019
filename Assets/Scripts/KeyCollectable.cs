using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectable : MonoBehaviour
{
    public InteractableObject interactable;
    public PlayerState playerState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerState.playerParticleTrail.isActive = true;
            playerState.isCarryingKey = true;
            playerState.pointerRotation.target = playerState.chapters[playerState.globalIndex].newPositiveText.transform;

            CameraFollow.target = CameraFollow.playerCharacter;
            CameraFollow.smoothSpeed = CameraFollow.smoothSpeed * 3;
            CameraFollow.offset = new Vector3(CameraFollow.offset.x, CameraFollow.offset.y + interactable.zoomAmmount, CameraFollow.offset.z);

            gameObject.SetActive(false);
        }
    }
}
