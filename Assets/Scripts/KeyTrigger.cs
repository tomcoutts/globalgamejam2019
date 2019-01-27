using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public PlayerState playerState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerState.isCarryingKey == true)
        {
            playerState.isCarryingKey = false;
            playerState.playerParticleTrail.isActive = false;
            playerState.ChangeChapter();
        }
    }

}
