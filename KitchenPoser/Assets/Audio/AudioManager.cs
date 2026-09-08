using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource SFXObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AudioPlaySFX(AudioClip AudioClip, Transform spawnTransform, float Volume, float Pitch)
    {
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = AudioClip;
        audioSource.volume = Volume;
        audioSource.pitch = Pitch;
        audioSource.Play();

        float ClipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, ClipLength);
    }
}
