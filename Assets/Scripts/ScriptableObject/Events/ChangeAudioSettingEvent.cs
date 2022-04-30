using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Событие изменения аудио настроек
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/ChangeSettingsEvent")]
public class ChangeAudioSettingEvent : ScriptableObject {
    private List<ChangeAudioSettingListener> _listeners = new List<ChangeAudioSettingListener>();

    public void Rise() {
        foreach (var listener in _listeners) {
            listener.OnEventRised();
        }
    }

    public void RegisterListener(ChangeAudioSettingListener listener) {
        _listeners.Add(listener);
    }

    public void UnregisterListener(ChangeAudioSettingListener listener) {
        _listeners.Remove(listener);
    }

}
