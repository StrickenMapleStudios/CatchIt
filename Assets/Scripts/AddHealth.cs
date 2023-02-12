using UnityEngine;

public class AddHealth : Interactable
{
    [SerializeField] private float _speed;
    
    private void Awake() {
        try {
            _interactionHandler = transform.parent.GetComponent<InteractionHandler>();
            _speedValue = _speed;
            _effect = Effects.AddHealth;
        } catch {}
    }

    private void OnMouseDown() {
        _interactionHandler.AddHealth();
    }
}
