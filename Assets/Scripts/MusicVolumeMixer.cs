using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeMixer : MonoBehaviour
{
    private const string Volume = nameof(Volume);

    [SerializeField] private Toggle _toggleMusic;
    [SerializeField] private Slider _sliderVolumeMusic;
    [SerializeField] private AudioSource _audioSource;

    private float _currentVolume;
    
    void Start()
    {
        Load();
        SetVolume();
    }

    public void SliderVolume()
    {
        _currentVolume = _sliderVolumeMusic.value;
        Save();
        SetVolume();
    }

    public void ToggleVolume()
    {
        if (_toggleMusic.isOn == true)
            _currentVolume = 1;
        else 
            _currentVolume = 0;

        Save();
        SetVolume();
    }

    private void SetVolume()
    {
        _audioSource.volume = _currentVolume;
        _sliderVolumeMusic.value = _currentVolume;
        if (_currentVolume == 0) 
            _toggleMusic.isOn = false;
        else 
            _toggleMusic.isOn = true;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(Volume, _currentVolume);
    }
    private void Load()
    {
        _currentVolume = PlayerPrefs.GetFloat(Volume, _currentVolume);
    }
}
