#region

using UnityEngine;

#endregion

[CreateAssetMenu(menuName = "ScriptableObject/AudioSettings")]
public class AudioSettings : ScriptableObject {
    [SerializeField] private bool _muteSound;
    [SerializeField, Range(0, 1f)] private float _generalVolume;
    [SerializeField, Range(0, 1f)] private float _interfaceVolume;
    [SerializeField, Range(0, 1f)] private float _surroundVolume;

    public bool MuteSound {
        get => _muteSound;
        set => _muteSound = value;
    }

    public float GeneralVolume {
        get => _generalVolume;
        set => _generalVolume = value;
    }

    public float InterfaceVolume {
        get => _interfaceVolume;
        set => _interfaceVolume = value;
    }

    public float SurroundVolume {
        get => _surroundVolume;
        set => _surroundVolume = value;
    }

    /// <summary>
    /// Высчитывает громкость элементов
    /// </summary>
    /// <param name="source"></param>
    /// <param name="type"></param>
    /// <param name="trackVolume">Громкость трека, настроенная в редакторе</param>
    public void AudioConfigApply(AudioSource source, AudioType type, float trackVolume) {
        if (source == null) return;
        source.mute = _muteSound;
        switch (type) {
            case AudioType.Interface: {
                source.volume = GeneralVolume * InterfaceVolume * trackVolume;
                break;
            }
            case AudioType.Surround: {
                source.volume = GeneralVolume * SurroundVolume * trackVolume;
                break;
            }
        }
    }
}