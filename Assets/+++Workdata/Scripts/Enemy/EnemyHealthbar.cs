using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

//Passt die Healthbar dem Leben des Enemy an.
public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] private EnemyInformation _enemyInformation;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;
    private void Start()
    {
        totalHealthbar.fillAmount = _enemyInformation._currentLifePoints / _enemyInformation.enemyMaxLifePoints;
    }
    private void Update()
    {
        currentHealthbar.fillAmount = _enemyInformation._currentLifePoints / _enemyInformation.enemyMaxLifePoints;
    }
}