using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public static GameObject camera; 


    public static Transform target;
    public static Transform playerCharacter;

    public static float smoothSpeed = 10f;
    public float smoothSpeedEditor = 10f;

    public Vector3 offsetEditor;
    public static Vector3 offset;

    public static Vector3 offsetRunMultiplier;

    public Vector4 cameraLimits;
    private Vector3 desiredPosition;

    private void Start()
    {
        smoothSpeed = smoothSpeedEditor;
        offset = offsetEditor;

        camera = this.gameObject;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        playerCharacter = target;

        desiredPosition.x = Mathf.Clamp(target.position.x + offset.x, cameraLimits.x, cameraLimits.y);
        desiredPosition.z = Mathf.Clamp(target.position.z + offset.z, cameraLimits.w, cameraLimits.z);
        desiredPosition.y = target.position.y + offset.y;
        transform.position = desiredPosition;

    }

    void FixedUpdate()
    {
        if (target != null) //checking if player is alive
        {
            if (target.gameObject.tag == "Player")
                offsetRunMultiplier = new Vector3(target.GetComponent<Rigidbody>().velocity.x / 2, 
                    Mathf.Max(Mathf.Abs(target.GetComponent<Rigidbody>().velocity.x), Mathf.Abs(target.GetComponent<Rigidbody>().velocity.z)) / 2, 
                    target.GetComponent<Rigidbody>().velocity.z / 2 - Mathf.Abs(target.GetComponent<Rigidbody>().velocity.z) / 2);

            desiredPosition.x = Mathf.Clamp(target.position.x + offset.x + offsetRunMultiplier.x, cameraLimits.x, cameraLimits.y);
            desiredPosition.z = Mathf.Clamp(target.position.z + offset.z + offsetRunMultiplier.z, cameraLimits.w, cameraLimits.z);
            desiredPosition.y = target.position.y + offset.y + offsetRunMultiplier.y;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;
        }
        else
        {
            smoothSpeed = 1.0f;
        }
    }
}
