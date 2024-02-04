using TMPro;
using UnityEngine;

public class BagView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountView;
    [SerializeField] private Bag _bag;
    
    private void OnEnable()
    {
        _bag.AmountChanged += DisplayAmount;
    }

    private void OnDisable()
    {
        _bag.AmountChanged -= DisplayAmount;
    }

    private void DisplayAmount()
    {
        int amount = _bag.Coins;
        _amountView.text = amount.ToString();
    }
}
