using UnityEngine;

public class AddPoints : Interactable
{
    [SerializeField] private int _points;
    [SerializeField] private float _speed;

    private void Awake() {
        try {
            _interactionHandler = transform.parent.GetComponent<InteractionHandler>();
            _effect = Effects.AddPoints;
            _pointsValue = _points;
            _speedValue = _speed;
        } catch {}
    }

    private void OnMouseDown() {
        _interactionHandler.AddPoints(_points);
    }
}
