using System;
using TMPro;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public static MoneySystem Instance { get; private set; }
    public static event Action<int> BalanceChanged;
    private const string MoneyStateId = "money_pence";

    [Header("Money")]
    [SerializeField, Min(0)] private int startingMoneyPence;

    [Header("Optional UI")]
    [SerializeField] private TextMeshProUGUI moneyText;

    public int MoneyPence { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        MoneyPence = Mathf.Max(0, startingMoneyPence);
        UpdateUI();
    }

    private void OnEnable()
    {
        DialogueController.OnAddState += HandleInkState;
    }

    private void OnDisable()
    {
        DialogueController.OnAddState -= HandleInkState;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    
    private void HandleInkState(string id, int amount)
    {
        if (id != MoneyStateId)
        {
            return;
        }

        if (amount > 0)
        {
            AddMoney(amount);
        }
        else if (amount < 0)
        {
            TrySpendMoney(Mathf.Abs(amount));
        }
    }

    public void AddMoney(int amountPence)
    {
        if (amountPence <= 0)
        {
            Debug.LogWarning(
                $"Money amount must be positive: {amountPence}",
                this);
            return;
        }

        MoneyPence += amountPence;
        NotifyChanged();
    }

    public bool HasEnoughMoney(int amountPence)
    {
        return amountPence >= 0 && MoneyPence >= amountPence;
    }

    public bool TrySpendMoney(int amountPence)
    {
        if (amountPence <= 0)
        {
            Debug.LogWarning(
                $"Purchase price must be positive: {amountPence}",
                this);
            return false;
        }

        if (!HasEnoughMoney(amountPence))
        {
            return false;
        }

        MoneyPence -= amountPence;
        NotifyChanged();

        return true;
    }

    public void SetMoney(int amountPence)
    {
        MoneyPence = Mathf.Max(0, amountPence);
        NotifyChanged();
    }

    public string GetFormattedMoney()
    {
        int pounds = MoneyPence / 100;
        int pence = MoneyPence % 100;

        return $"£{pounds}.{pence:00}";
    }

    private void NotifyChanged()
    {
        UpdateUI();
        BalanceChanged?.Invoke(MoneyPence);
    }

    private void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.SetText(GetFormattedMoney());
        }
    }
}