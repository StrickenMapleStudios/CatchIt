using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private Transform _audioSourcePrefab;

    [Header("Audio")]
    [SerializeField] private AudioClip[] _noteAudio;
    [SerializeField] private AudioClip[] _wrongNoteAudio;
    [SerializeField] private AudioClip _healingNoteAudio;
    [SerializeField] private AudioClip _gameOverAudio;

    public void PlayNoteAudio() {
        CreateAudioSource(_noteAudio[Random.Range(0, _noteAudio.Length)]);
    }

    public void PlayHealingNoteAudio() {
        CreateAudioSource(_healingNoteAudio);
    }

    public void PlayWrongNoteAudio() {
        CreateAudioSource(_wrongNoteAudio[Random.Range(0, _wrongNoteAudio.Length)]);
    }

    public void PlayGameOverAudio() {
        CreateAudioSource(_gameOverAudio);
    }

    public void CreateAudioSource(AudioClip clip) {
        var audio = Instantiate(_audioSourcePrefab, Vector3.zero, Quaternion.identity);
        var audioSource = audio.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        
        Destroy(audioSource.gameObject, clip.length);
    }
}
