using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Image fill;

    private void OnEnable()
    {
        enemy.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        enemy.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float normalizedHealth)
    {
        fill.fillAmount = normalizedHealth;
    }
}
