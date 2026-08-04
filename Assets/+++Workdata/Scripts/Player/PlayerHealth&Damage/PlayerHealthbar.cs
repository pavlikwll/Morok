using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

//Passt die Healthbar dem Leben des Players an.
public class PlayerHealthbar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;
    private void Start()
    {
        totalHealthbar.fillAmount = playerHealth.currentHealth / 5;
    }
    private void Update()
    {
        currentHealthbar.fillAmount = playerHealth.currentHealth / 5;
    }
}