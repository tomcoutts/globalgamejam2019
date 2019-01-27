using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerRotation : MonoBehaviour
{
    public bool isInTheHouse;

    public Transform target;

    public Light light;

    public bool isActive;

    private void Update()
    {
        transform.LookAt(target);

        if (isInTheHouse)
        {
            light.GetComponent<Animator>().SetBool("transition", false);
        }
        else if (!isInTheHouse && isActive)
        {
            light.GetComponent<Animator>().SetBool("transition", true);
        }
        else if (!isInTheHouse && !isActive)
        {
            light.GetComponent<Animator>().SetBool("transition", false);
        }
    }


    }
