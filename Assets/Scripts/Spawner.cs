using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Interactable> _defaultPrefabs;
    [SerializeField] private Interactable _healingNotePrefab;
    [SerializeField] private Interactable _wrongNotePrefab;

    private Transform _defaultParent;
    public Transform DefaultParent { set => _defaultParent = value; }

    private float _spawnFrequency;
    public float SpawnFrequency { set => _spawnFrequency = value; }

    
    private Transform _game;

    private void Awake() {
        enabled = false;
    }

    private IEnumerator<WaitForSeconds> SpawnObjects() {
        Vector2 position = transform.position;
        while (true) {
            position.x = Random.Range(0, transform.lossyScale.x);
            position.x -= transform.lossyScale.x / 2;
            Interactable obj = Instantiate(ChoosePrefab(), position, Quaternion.identity, _defaultParent);

            yield return new WaitForSeconds(_spawnFrequency);
        }
    }

    private Interactable ChoosePrefab() {
        float value = Random.Range(0f, 1f);
        if (value < 0.65)
            return _defaultPrefabs[Random.Range(0, _defaultPrefabs.Count)];
        else if (value < 0.95)
            return _wrongNotePrefab;
        else
            return _healingNotePrefab;
    }

    private void OnEnable() {
        StartCoroutine(SpawnObjects());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }
}
