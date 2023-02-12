using UnityEngine;

public enum Effects {
    AddPoints,
    AddHealth,
    MakeDamage
}

[RequireComponent(typeof(CapsuleCollider2D))]
public class Interactable : MonoBehaviour
{
    [SerializeField] private Transform _particles;
    [SerializeField] protected Effects _effect;
    protected float _speedValue;
    protected int _pointsValue;
    [SerializeField] protected InteractionHandler _interactionHandler;


    private void Update() {
        transform.position += Vector3.down * _speedValue * Time.deltaTime;
    }

    private void OnMouseDown() {
        CreateParticles(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Destroy(gameObject);
    }

    public void CreateParticles() {
        Instantiate(_particles, transform.position, Quaternion.identity);
    }

    private void CreateParticles(Vector2 position) {
        Instantiate(_particles, position, Quaternion.identity);
    }
}
