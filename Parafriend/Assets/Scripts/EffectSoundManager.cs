using UnityEngine;

public class EffectSoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public static EffectSoundManager Instance { private set; get; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of EffectSoundManager" + Instance.transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void PlaySoundEffect(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
