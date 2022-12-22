using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownTake : MonoBehaviour
{
    [Header("竹のオブジェクト")]
    [SerializeField] GameObject _take;

    [Header("竹を出す場所")]
    [SerializeField] GameObject _takePosition;

    [Header("最初のアニメーションが終わる時間")]
    [SerializeField] float _animEndTime;

    [Header("竹を出す最小時間")]
    [SerializeField] float _minTime;

    [Header("竹を出す最高時間")]
    [SerializeField] float _maxTime;


    [Header("竹を切るボタン")]
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
            //時間計測
            _countTime += Time.deltaTime;

            //時間がたったら竹を出す
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
