using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameObject lake;

    public ParticleTrail playerParticleTrail;
    public bool isCarryingKey = false;

    [System.Serializable]
    public class Chapter
    {
        public int chapterIndex = 0;
        public Room room;
        public GameObject key;
        public GameObject keyTrigger;
        public GameObject door;
        public GameObject doorTrigger;
        [ColorUsageAttribute(true, true)]
        public Color color;
        public Light light;

        public GameObject objectHolder;
        [HideInInspector]
        public List<GameObject> objectsInTheRoom;

        public GameObject newPositiveText;
    }

    public PointerRotation pointerRotation;

    public List<Chapter> chapters;

    public bool testRotation = false;
    public bool shouldRotate = true;

    public int globalIndex = 0;

    public Quaternion desiredLocation;

    public GameObject doorTarget;

    private void Start()
    {
        pointerRotation = GameObject.FindObjectOfType<PointerRotation>();

        int i = 0;
        foreach (Chapter chapter in chapters)
        {
            chapter.chapterIndex = i;
            if (chapter.light != null)
            {
                chapter.light.color = Color.white;
            }
            i++;
            if (chapter.objectHolder != null && chapter.objectHolder.activeSelf)
            {
                foreach (Transform child in chapter.objectHolder.transform)
                {
                    chapter.objectsInTheRoom.Add(child.gameObject);
                }
            }
        }
    }

    public void Update()
    {
        if (testRotation & shouldRotate)
        {
            ChangeChapter();
            shouldRotate = false;
        }
    }

    private void OpenDoor(Chapter chapter)
    {
        doorTarget = chapter.door;
        desiredLocation = doorTarget.transform.rotation * Quaternion.Euler(0.0f, 150.0f, 0.0f);
        StartCoroutine("OpenDoorRoutine");
        chapter.doorTrigger.SetActive(true);
    }

    IEnumerator OpenDoorRoutine()
    {
        while (doorTarget.transform.rotation != desiredLocation)
        {
            doorTarget.transform.rotation = Quaternion.Slerp(doorTarget.transform.rotation, Quaternion.Euler(0.0f, 150.0f, 0.0f), 2 * Time.deltaTime);
             yield return null;
        }
        yield return null;
    }

    public void ChangeChapter()
    {
        if (globalIndex == 6)
        {
            lake.SetActive(true);
        }
        if (globalIndex > 0) //excluding the first scene
        {
            OpenDoor(chapters[globalIndex + 1]);
        }

        if (1 <= globalIndex && globalIndex <= 6)
        {
            if (chapters[globalIndex + 1].key != null)
            {
                pointerRotation.target = chapters[globalIndex+1].key.transform;
            }

            if (chapters[globalIndex].keyTrigger != null)
            {
                chapters[globalIndex].keyTrigger.SetActive(false);
            }
            if (chapters[globalIndex + 1].keyTrigger != null)
            {
                chapters[globalIndex + 1].keyTrigger.SetActive(true);
            }

            if (chapters[globalIndex + 1].key != null)
            {
                chapters[globalIndex + 1].key.SetActive(true);
            }

            pointerRotation.light.color = chapters[globalIndex + 1].color; //checking that we are in the correct state to change the color of the light pointer, i.e. that we are  interacting with one of the 4 rooms
            pointerRotation.isActive = true;

            playerParticleTrail.particles.GetComponent<Renderer>().material.color = chapters[globalIndex + 1].color;

            if (chapters[globalIndex].light != null)
            {
                chapters[globalIndex].light.color = chapters[globalIndex].color;
            }
            
            foreach (GameObject roomObject in chapters[globalIndex].objectsInTheRoom)
            {
                if (roomObject.GetComponent<Renderer>() != null)
                    roomObject.GetComponent<Renderer>().material.SetInt("_isFixedInt", 0);
            }
        }

        if(this.globalIndex < 6)
            this.globalIndex++;
    }
}


