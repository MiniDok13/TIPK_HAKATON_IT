using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        FindPlayer(true);
    }

    void FindPlayer(bool playerFaceLeft)
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            target = playerObject.transform;
            Debug.Log("Found player: " + target.name);
        }
        else
        {
            Debug.LogError("Player object not found!");
        }
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned!");
            return;
        }

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = desiredPosition;
    }
}