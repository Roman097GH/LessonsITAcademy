using UnityEngine;

public class Detect : MonoBehaviour
{
    [SerializeField] private Scoring _scoring;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            _scoring.AddScore();

            Destroy(other.gameObject, 2.0f);
        }
    }
}
