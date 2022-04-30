using UnityEngine;

/// <summary>
/// Ќаблюдатель за событием изменени€ аудио настроек
/// </summary>
public class ChangeAudioSettingListener : MonoBehaviour {
    [SerializeField] private ChangeAudioSettingEvent _event;
    private AudioSettingsApplier _applier;

    public void OnEventRised() {
        _applier.ConfigureAudioSource();
    }

    private void OnEnable() {
        if (TryGetComponent<AudioSettingsApplier>(out _applier)) {
            _event.RegisterListener(this);
        }
    }

    private void OnDisable() {
        _event.UnregisterListener(this);
    }
}
