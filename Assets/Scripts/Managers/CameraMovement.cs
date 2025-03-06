using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float followSpeed;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

}
