using UnityEngine;
using UnityEngine.UI;
public class SFXSlider : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", sfxSlider.value);
    }

    private void Load()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
