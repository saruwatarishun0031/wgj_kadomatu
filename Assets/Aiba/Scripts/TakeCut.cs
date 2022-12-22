using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class TakeCut : MonoBehaviour
{
    [SerializeField] GameObject _startArm;
    [SerializeField] GameObject _endArm;

    [SerializeField] GameObject _bumberrboom;

    [Header("竹Tagの名前")]
    [SerializeField] string _takeTagName = "";

    [Header("竹の着る場所の位置を持ってるオブジェクトのTagの名前")]
    [SerializeField] string _takeCatPositionTagName = "";

    [Header("ピッタリ切った事にする誤差の許容")]
    [SerializeField] float _parfectCutGosa;

    [Header("ピッタリ切った時の竹のオブジェクト")]
    [SerializeField] GameObject _parfectCutTake;

    [Header("切らなかった時の竹のオブジェクト")]
    [SerializeField] GameObject _noCutTake;


    [Header("切った後の誤差。ある竹の素材の多さによる")]
    [SerializeField] List<float> _distance = new List<float>();

    [Header("上の方を切った時の竹のオブジェクト。誤差の少ないバージョンから入れる")]
    [SerializeField] List<GameObject> _shortTake = new List<GameObject>();

    [Header("下の方を切った時の竹のオブジェクト。誤差の少ないバージョンから入れる")]
    [SerializeField] List<GameObject> _longTake = new List<GameObject>();

    [Header("強制終了させる時間")]
    [SerializeField] float _endTime;

    float _countTime = 0;


    [Header("竹を切るボタン")]
    [SerializeField] GameObject _cutButtun;

    [SerializeField] SpownTake _spownTake;
    [SerializeField] GameManager _gm;


    [SerializeField] GameObject _ennsyutu;

    [SerializeField] float ensyutuTime = 1;

    private bool _isCut = false;
    void Start()
    {

    }


    void Update()
    {
        if (_spownTake.IsSpown)
        {
            _countTime += Time.deltaTime;
            if (_countTime >= _endTime && !_isCut)
            {
                _isCut = true;
                _countTime = 0;
                _cutButtun.SetActive(false);

                _startArm.SetActive(false);
                _endArm.SetActive(true);

                //出した竹を消す
                var take = GameObject.FindGameObjectWithTag(_takeTagName);
                Destroy(take);
                _gm.TakesSet(_noCutTake);
                _gm.TurnPurasu();
            }
        }
    }

    public void Cut()
    {
        _cutButtun.SetActive(false);

        //切り口と元の場所の差を求める
        var checkPointTake = GameObject.FindGameObjectWithTag(_takeCatPositionTagName);
        //切り口との差


        float distanceOfCutToCheckPoint = checkPointTake.transform.position.y;

        //出した竹を消す
        var take = GameObject.FindGameObjectWithTag(_takeTagName);
        Destroy(take);

        //パーフェクトかどうか求める
        //if (distanceOfCutToCheckPoint < _parfectCutGosa && distanceOfCutToCheckPoint > -_parfectCutGosa)
        //{
        //    _isCut = true;
        //    _gm.TakesSet(_parfectCutTake);
        //    _gm.TurnPurasu();
        //    return;
        //}

        //切った所が、ポイントより下の方だったら  (値は+)
        if (distanceOfCutToCheckPoint >= 0)
        {
            for (int i = 0; i < _distance.Count - 1; i++)
            {
                if (_distance[i] < distanceOfCutToCheckPoint && distanceOfCutToCheckPoint < _distance[i + 1])
                {
                    _ennsyutu.SetActive(true);
                    StartCoroutine(Next());
                    _startArm.SetActive(false);
                    _endArm.SetActive(true);
                    //一番誤差の小さいインデックス
                    _gm.TakesSet(_shortTake[i]);
                    _isCut = true;


                    return;
                }
            }
        }
        //切った所が、ポイントより下の方だったら (値は-)
        else if (distanceOfCutToCheckPoint < 0)
        {
            for (int i = 0; i < _distance.Count - 1; i++)
            {
                if (-_distance[i] > distanceOfCutToCheckPoint && distanceOfCutToCheckPoint > -_distance[i + 1])
                {
                    _ennsyutu.SetActive(true);
                    StartCoroutine(Next());
                    _gm.TakesSet(_longTake[i]);
                    _isCut = true;
                    _startArm.SetActive(false);
                    _endArm.SetActive(true);
                    return;
                }
            }
        }

        _isCut = true;
        _countTime = 0;
        _cutButtun.SetActive(false);
        _startArm.SetActive(false);
        _endArm.SetActive(true);
        //出した竹を消す
        var takes = GameObject.FindGameObjectWithTag(_takeTagName);
        Destroy(take);
        _gm.TakesSet(_noCutTake);
        _gm.TurnPurasu();
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(ensyutuTime);
        _ennsyutu.SetActive(false);
        _bumberrboom.SetActive(true);
        yield return new WaitForSeconds(2);
        _bumberrboom.SetActive(false);
        _gm.TurnPurasu();

    }



}
