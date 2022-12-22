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
    private List<AudioSource> _seAudios;

    /// <summary>
    /// 音楽(BGM)を再生する関数
    /// </summary>
    /// <param name="name">設定した音楽(BGM)の名前</param>
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

    /// <summary>
    /// 効果音(SE)を再生する関数
    /// </summary>
    /// <param name="name">設定した効果音(SE)の名前</param>
    public void PlaySE(string name)
    {
        foreach (var audio in _seAudios)
        {
            audio.Stop();
        }
        foreach (var audio in _seAudios)
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
