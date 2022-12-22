using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    [SerializeField]
    SoundManager _soundManager;

    [SerializeField]
    [Header("使いたいBGMの名前")]
    string _bgmName;

    [SerializeField]
    [Header("使いたいSEの名前")]
    string _seName;

    [SerializeField]
    int _count;

    void Start()
    {
        _soundManager.PlayBGM(_bgmName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _soundManager.PlaySE(_seName);
        }
    }
}
