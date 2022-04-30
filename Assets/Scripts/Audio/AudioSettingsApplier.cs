 #region

using UnityEngine;

#endregion


/// <summary>
/// Применяет настройки аудио к звуковой дорожке привязанной к объекту
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioSettingsApplier : MonoBehaviour {
    [SerializeField] private AudioSettings _config;

    private AudioSource _audio;
    [SerializeField] private AudioType _type;

    private float _trackStartVolume;

    public void ConfigureAudioSource() {
        if (_config != null) _config.AudioConfigApply(_audio, _type, _trackStartVolume);
    }

    private void OnValidate() {
        ConfigureAudioSource();
    }

    private void Start() {
        if (TryGetComponent<AudioSource>(out _audio)) {
            _trackStartVolume = _audio.volume;
            ConfigureAudioSource();
        }
    }
}