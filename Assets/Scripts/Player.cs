using UnityEngine;

public class Player : MonoBehaviour
{
    private const int MAX_HEALTH = 5;
    public int health { get; private set; } = MAX_HEALTH;
    public int score { get; private set; } = 0;

    public void LoseHealth() {
        health--;
    }

    public void AddHealth() {
        health = Mathf.Min(health + 1, MAX_HEALTH);
    }

    public void AddPoints(int value) {
        score += value;
    }
}
