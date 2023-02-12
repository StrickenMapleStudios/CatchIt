using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] Transform _healthBar;
    [SerializeField] Transform _scoreObject;

    private HealthBar _healthBarScript;
    private TextMeshProUGUI _scoreText;

    private int _score;

    public int Score {
        get => _score;
        set {
            _score = value;
            _scoreText.text = $"{value}";
        }
    }

    private void Awake() {
        _healthBarScript = _healthBar.GetComponent<HealthBar>();
        _scoreText = _scoreObject.GetComponent<TextMeshProUGUI>();
    }

    public void LoseHealth() {
        _healthBarScript.LoseHealth();
    }

    public void AddHealth() {
        _healthBarScript.AddHealth();
    }
}
