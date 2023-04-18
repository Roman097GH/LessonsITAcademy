using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 1.0f);
    }
}
