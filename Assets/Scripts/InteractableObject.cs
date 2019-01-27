using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactable;
    private int highlightState;
    public float zoomAmmount = 1.2f;

    public Vector3 offsetRunMultiplierEditor;

    public GameObject floatingText;
    public Animator textAnimator;
    public List<Animator> highlightAnimator;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            CameraFollow.target = interactable.transform;
            CameraFollow.smoothSpeed = CameraFollow.smoothSpeed / 3;
            CameraFollow.offset = new Vector3(CameraFollow.offset.x, CameraFollow.offset.y - zoomAmmount, CameraFollow.offset.z);
            CameraFollow.offsetRunMultiplier = offsetRunMultiplierEditor;
            textAnimator.SetBool("playTransition", true);
            foreach (Animator anim in highlightAnimator)
            {
                anim.SetBool("transition", true);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            CameraFollow.target = CameraFollow.playerCharacter;
            CameraFollow.smoothSpeed = CameraFollow.smoothSpeed * 3;
            CameraFollow.offset = new Vector3(CameraFollow.offset.x, CameraFollow.offset.y + zoomAmmount, CameraFollow.offset.z);

            textAnimator.SetBool("playTransition", false);
            foreach (Animator anim in highlightAnimator)
            {
                anim.SetBool("transition", false);
            }
            CameraFollow.offsetRunMultiplier = Vector3.zero;
        }
    }
}