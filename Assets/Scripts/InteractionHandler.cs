using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    private Transform _gameObject;
    private Game _game;

    public Transform Game {
        set { _gameObject = value; _game = _gameObject.GetComponent<Game>(); }
    }

    public void AddPoints(int value) {
        _game.AddPoints(value);
    }

    public void AddHealth() {
        _game.AddHealth();
    }

    public void MakeDamage() {
        _game.LoseHealth();
    }
}
