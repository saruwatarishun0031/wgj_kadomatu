using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    [SerializeField]
    SoundManager _soundManager;

    [SerializeField]
    [Header("BGMName")]
    string _bgmName;

    [SerializeField]
    [Header("SEName")]
    string _seName;
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
