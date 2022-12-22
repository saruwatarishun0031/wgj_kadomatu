using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownTake : MonoBehaviour
{
    [Header("�|�̃I�u�W�F�N�g")]
    [SerializeField] GameObject _take;

    [Header("�|���o���ꏊ")]
    [SerializeField] GameObject _takePosition;

    [Header("�ŏ��̃A�j���[�V�������I��鎞��")]
    [SerializeField] float _animEndTime;

    [Header("�|���o���ŏ�����")]
    [SerializeField] float _minTime;

    [Header("�|���o���ō�����")]
    [SerializeField] float _maxTime;


    [Header("�|��؂�{�^��")]
    [SerializeField] GameObject _cutButtun;

    private float _timeLimit;
    private float _countTime = 0;
    private bool _isStart = false;

    private bool _isSpown = false;

    public bool IsSpown => _isSpown;
    void Start()
    {
        _timeLimit = Random.Range(_minTime, _maxTime);
        StartCoroutine(StartSpown());
    }

    void Update()
    {
        if (_isStart)
        {
            //���Ԍv��
            _countTime += Time.deltaTime;

            //���Ԃ���������|���o��
            if (_countTime >= _timeLimit)
            {
                _isStart = false;
                _isSpown = true;
                var go = Instantiate(_take);
                go.transform.position = _takePosition.transform.position;
            }
        }
    }

    IEnumerator StartSpown()
    {
        yield return new WaitForSeconds(_animEndTime);
        _cutButtun.SetActive(true);
        _isStart = true;
    }

}
