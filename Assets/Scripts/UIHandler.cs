using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Transform _HUD;
    [SerializeField] private Transform _gameOver;

    private HUD _HUDScript;

    private void Awake() {
        try {
            _HUDScript = _HUD.GetComponent<HUD>();
            _HUD.gameObject.SetActive(true);
            _gameOver.gameObject.SetActive(false);
        } catch {}
    }

    public void LoseHealth() {
        _HUDScript.LoseHealth();
    }

    public void AddHealth() {
        _HUDScript.AddHealth();
    }

    public void UpdateScore(int value) {
        _HUDScript.Score = value;
    }

    public void Play() {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu() {
        Application.Quit();
    }

    public void GameOver() {
        _HUD.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(true);
        _gameOver.GetComponent<GameOver>().Score = _HUDScript.Score;
        _gameOver.GetComponent<Animator>().SetTrigger("FadeIn");
    }
}
