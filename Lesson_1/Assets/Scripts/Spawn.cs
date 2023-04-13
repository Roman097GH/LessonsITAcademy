using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObject;

    private void Update()
    {
        int randomIndex = Random.Range(0, _gameObject.Length);

        if(Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(_gameObject[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
