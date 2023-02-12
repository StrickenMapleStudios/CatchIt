using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform _spawner;
    [SerializeField] private Transform _interactableGroup;
    [SerializeField] private Transform _player;

    [Header("Parameters")]
    [SerializeField] private float _spawnFrequency;

    private Spawner _spawnerScript;
    private Player _playerScript;
    
    private UIHandler _UIHandler;
    private AudioHandler _audioHandler;

    private void Awake() {
        _UIHandler = GetComponent<UIHandler>();
        _audioHandler = GetComponent<AudioHandler>();
        _playerScript = _player.GetComponent<Player>();
        _interactableGroup.GetComponent<InteractionHandler>().Game = transform;
        
        _spawnerScript = _spawner.GetComponent<Spawner>();
        _spawnerScript.DefaultParent = _interactableGroup;
        _spawnerScript.SpawnFrequency = _spawnFrequency;
    }

    private void Start() {
        _spawnerScript.enabled = true;
    }

    public void AddPoints(int value) {
        _playerScript.AddPoints(value);
        _UIHandler.UpdateScore(_playerScript.score);
        _audioHandler.PlayNoteAudio();
    }

    public void LoseHealth() {
        _playerScript.LoseHealth();
        _UIHandler.LoseHealth();
        if (_playerScript.health <= 0) {
            GameOver();
        } else {
            _audioHandler.PlayWrongNoteAudio();
        }
    }

    public void AddHealth() {
        _playerScript.AddHealth();
        _UIHandler.AddHealth();
        _audioHandler.PlayHealingNoteAudio();
    }

    private void GameOver() {
        _spawnerScript.enabled = false;
        foreach (Transform child in _interactableGroup) {
            child.GetComponent<Interactable>().CreateParticles();
            Destroy(child.gameObject);
        }
        _audioHandler.PlayGameOverAudio();
        _UIHandler.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(typeof(AddPoints), out _)) {
            LoseHealth();
        }
        Destroy(other.gameObject);
    }
}
