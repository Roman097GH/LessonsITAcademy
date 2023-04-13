using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scale : MonoBehaviour
{
    [SerializeField] private Slider _sliderScale;
    [SerializeField] private TextMeshProUGUI _textCurrentScale;
    [SerializeField] private TextMeshProUGUI _textMinScale;
    [SerializeField] private TextMeshProUGUI _textMaxScale;
    [SerializeField] private Material _material;
    [SerializeField] private float _minScale = 1.0f;
    [SerializeField] private float _maxScale = 5.0f;

    private Color _currentColor;

    private void Start()
    {
        _sliderScale.minValue = _minScale;
        _sliderScale.maxValue = _maxScale;

        _currentColor = Color.green;

        TextUpdate();
    }

    private void Update()
    {
        transform.localScale = new Vector3(_sliderScale.value, _sliderScale.value, _sliderScale.value);

        TextUpdate();

        if (transform.localScale.x == _maxScale)
        {
            _material.color = Color.red;
        }
        else if (transform.localScale.x >= _maxScale / 2)
        {
            _material.color = Color.blue;
        }
        else
        {
            _material.color = _currentColor;
        }    
    }

    private void TextUpdate()
    {
        _textCurrentScale.text = "Текущий масштаб X, Y, Z: " + _sliderScale.value.ToString();
        _textMinScale.text = "Минимальный масштаб: " + _minScale.ToString();
        _textMaxScale.text = "Максимальный масштаб: " + _maxScale.ToString();
    }
}
