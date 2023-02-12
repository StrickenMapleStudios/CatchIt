using UnityEngine;

public class MakeDamage : Interactable
{
    [SerializeField] private float _speed;
    
    
    private void Awake() {
        try {
            _interactionHandler = transform.parent.GetComponent<InteractionHandler>();
            _speedValue = _speed;
            _effect = Effects.MakeDamage;
        } catch {}
    }

    private void OnMouseDown() {
        _interactionHandler.MakeDamage();
    }
}
