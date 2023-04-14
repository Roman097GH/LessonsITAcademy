using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _informationText;
    [SerializeField] private Button _informationButton;

    [SerializeField] private GameObject[] _gameObjects;

    [SerializeField] private Slider _sliderScale;
    [SerializeField] private Slider _sliderRotate;

    [SerializeField] private float _minScale = 1.0f;
    [SerializeField] private float _maxScale = 5.0f;

    private float _angle = 360.0f;

    private int _currentIndex;

    private Vector3 _currentRotation;

    private void Awake()
    {
        _sliderScale.minValue = _minScale;
        _sliderScale.maxValue = _maxScale;

        _sliderRotate.onValueChanged.AddListener(OnSliderChanged);
        _informationButton.onClick.AddListener(OnButtonPressed);
    }

    public void SetObject(int index)
    {
        for (int i = 0; i < _gameObjects.Length; i++)
        {
            if (i == index)
            {
                _currentIndex = index;
                _gameObjects[i].SetActive(true);                
            }
            else
            {
                _gameObjects[i].SetActive(false);
            }
        }
    }

    private void OnButtonPressed()
    {
        _informationText.text = "Position X, Y, Z: " + _gameObjects[_currentIndex].transform.position;
    }

    private void OnSliderChanged(float value)
    {
        var rotation = value * _angle;
        _gameObjects[_currentIndex].transform.rotation =  Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));        
    }

    private void Update()
    {
        _gameObjects[_currentIndex].transform.localScale = new Vector3(_sliderScale.value, _sliderScale.value, _sliderScale.value);
    }
}
