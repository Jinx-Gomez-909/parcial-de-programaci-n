using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;
    [SerializeField] private Transform target;
    private Vector3 vel = Vector3.zero;
    private void FixedUpdate() //uso el fixedupdate en lugar del update porque se ve mal con el update
    {
        Vector3 targetPosition= target.position + offset;
        targetPosition.z = transform.position.z;  
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
    }

}
