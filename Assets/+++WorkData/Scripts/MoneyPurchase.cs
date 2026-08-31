using UnityEngine;
using UnityEngine.Events;

public class MoneyPurchase : MonoBehaviour
{
    [Header("Purchase")]
    [SerializeField, Min(1)] private int pricePence = 100;
    [SerializeField] private bool purchaseOnlyOnce = true;

    [Header("Events")]
    [SerializeField] private UnityEvent onPurchaseSuccessful;
    [SerializeField] private UnityEvent onNotEnoughMoney;
    [SerializeField] private UnityEvent onAlreadyPurchased;

    private bool purchased;

    public void TryPurchase()
    {
        if (purchaseOnlyOnce && purchased)
        {
            onAlreadyPurchased?.Invoke();
            return;
        }

        if (MoneySystem.Instance == null)
        {
            Debug.LogError(
                "MoneySystem was not found. Add it to IngameAlwaysActive.",
                this);
            return;
        }

        if (!MoneySystem.Instance.TrySpendMoney(pricePence))
        {
            onNotEnoughMoney?.Invoke();
            return;
        }

        purchased = true;
        onPurchaseSuccessful?.Invoke();
    }
}