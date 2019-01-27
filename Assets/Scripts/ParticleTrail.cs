using UnityEngine;

public class ParticleTrail : MonoBehaviour
{
    public bool isActive = false;
    public GameObject particles;

    private void Update()
    {
        if (isActive)
        {
            particles.SetActive(true);
        }
        else
            particles.SetActive(false);
    }
}
