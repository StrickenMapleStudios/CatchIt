using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Heart[] _hearts;
    private int _currentHealth;

    private void Awake() {
        _hearts = GetComponentsInChildren<Heart>();
        _currentHealth = _hearts.Length;
    }

    public void LoseHealth() {
        _hearts[_currentHealth-- - 1].LoseHeart();
    }

    public void AddHealth() {
        try {
            _hearts[_currentHealth].AddHeart();
            _currentHealth++;
        } catch {}
    }
}
