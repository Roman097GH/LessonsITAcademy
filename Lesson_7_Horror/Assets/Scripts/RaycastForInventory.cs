using UnityEngine;

public class RaycastForInventory : MonoBehaviour
{
    [SerializeField] private GameObject _hand;
    [SerializeField] private GameManager _gameManager;
    private GameObject _worldCanvasForObject;
    [SerializeField] private GameObject _cardTextTrue;

    private void CardTextTrueSetActiveFalse()
    {
        _cardTextTrue.gameObject.SetActive(false);
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Card"))
            {
                var distance = (hit.transform.position - transform.position).sqrMagnitude;

                Debug.Log(distance);

                if (distance < 4.5f)
                {
                    _hand.gameObject.SetActive(true);
                    _worldCanvasForObject = hit.collider.gameObject.transform.GetChild(0).gameObject;
                    _worldCanvasForObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
                        int newIndex = hit.collider.gameObject.GetComponent<Index>().IndexItem;
                        _gameManager.AddClick(newIndex);
                        _cardTextTrue.gameObject.SetActive(true);
                        Invoke(nameof(CardTextTrueSetActiveFalse), 2.0f);
                    }
                }
                else
                {
                    _hand.gameObject.SetActive(false);

                    if (_worldCanvasForObject != null)
                    {
                        _worldCanvasForObject.SetActive(false);
                    }
                }
            }
        }
    }
}
