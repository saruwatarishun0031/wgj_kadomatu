using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager: MonoBehaviour
{
    [SerializeField]
    [Header("BGM�̉���")]
    float _bgmVolume;

    [SerializeField]
    [Header("SE(���ʉ�)�̉���")]
    float _seVolume;

    [SerializeField]
    [Header("BGM�p�̃I�[�f�B�I")]
    private List<AudioSource> _bgmAudios;

    [SerializeField]
    [Header("SE�p�̃I�[�f�B�I")]
    private List<AudioSource> _seAudio;

    public void PlayBGM(string name)
    {
        foreach (var audio in _bgmAudios)
        {
            audio.Stop();
        }
        foreach (var audio in _bgmAudios)
        {
            if (audio.name == name)
            {
                audio.volume = _bgmVolume;
                audio.Play();
                return;
            }
        }
    }
    public void PlaySE(string name)
    {
        foreach (var audio in _seAudio)
        {
            audio.Stop();
        }
        foreach (var audio in _seAudio)
        {
            if (audio.name == name)
            {
                audio.volume = _seVolume;
                audio.Play();
                return;
            }
        }
    }
}
