using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _foreground;
    [SerializeField] private TextMeshProUGUI _chargeTextMax;

    public void StartCharge()
    {
        _background.color = new Color(1f, 1f, 1f, 0.2f);
        _foreground.enabled = true;
        _chargeTextMax.enabled = false;
    }

    public void StopCharge()
    {
        _background.color = new Color(255f, 141f, 0f, 255f);
        _foreground.enabled = false;
        _chargeTextMax.enabled = true;
    }

    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        _foreground.fillAmount = (currentCharge - 1) / (maxCharge - 1);
    }
}
