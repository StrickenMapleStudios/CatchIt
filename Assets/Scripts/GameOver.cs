using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Transform _score;

    private TextMeshProUGUI _scoreText;

    public int Score {
        set => _scoreText.text = $"Score: {value}";
    }

    private void Awake() {
        _scoreText = _score.GetComponent<TextMeshProUGUI>();
    }


}
