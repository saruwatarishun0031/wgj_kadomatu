using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager: MonoBehaviour
{
    [SerializeField]
    [Header("BGMの音量")]
    float _bgmVolume;

    [SerializeField]
    [Header("SE(効果音)の音量")]
    float _seVolume;

    [SerializeField]
    [Header("BGM用のオーディオ")]
    private List<AudioSource> _bgmAudios;

    [SerializeField]
    [Header("SE用のオーディオ")]
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
