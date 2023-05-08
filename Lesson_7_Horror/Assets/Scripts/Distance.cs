using UnityEngine;

public class Distance : MonoBehaviour
{
    [SerializeField] private Transform _character;
    [SerializeField] private GameObject _hand;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _worldCanvasForObject;
    [SerializeField] private GameObject _cardTextTrue;

    private void CardTextTrueSetActiveFalse()
    {
        _cardTextTrue.gameObject.SetActive(false);
    }

    private void Update()
    {
        var distance = (_character.transform.position - transform.position).sqrMagnitude;
        Debug.Log(distance);
        
        if (distance < 3.0f)
        {
            _hand.gameObject.SetActive(true);
            _worldCanvasForObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                //gameObject.GetComponent<Renderer>().material.color = Color.green;
                int newIndex = gameObject.GetComponent<Index>().IndexItem;
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
