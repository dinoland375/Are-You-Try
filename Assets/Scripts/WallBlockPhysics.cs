using UnityEngine;

public class WallBlockPhysics : MonoBehaviour
{
    [SerializeField] private Rigidbody blockRigidbody;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Figure"))
        {
            blockRigidbody.useGravity = true;
            blockRigidbody.isKinematic = false;
        }
    }
}