using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TakeCut : MonoBehaviour
{
    [Header("竹Tagの名前")]
    [SerializeField] string _takeTagName = "";

    [Header("竹の着る場所の位置を持ってるオブジェクトのTagの名前")]
    [SerializeField] string _takeCatPositionTagName = "";

    [Header("ピッタリ切った事にする誤差の許容")]
    [SerializeField] float _parfectCutGosa;

    [Header("ピッタリの竹のオブジェクト")]
    [SerializeField] GameObject _parfectCutTake;

    [Header("切った後の誤差。ある竹の素材の多さによる")]
    [SerializeField] List<float> _distance = new List<float>();

    [Header("上の方を切った時の竹のオブジェクト。誤差の少ないバージョンから入れる")]
    [SerializeField] List<GameObject> _PlussTake = new List<GameObject>();

    [Header("下の方を切った時の竹のオブジェクト。誤差の少ないバージョンから入れる")]
    [SerializeField] List<GameObject> _MinussTake = new List<GameObject>();




    [SerializeField] GameManager _gm;

    void Start()
    {

    }


    void Update()
    {

    }

    public void Cut()
    {
        //切り口と元の場所の差を求める
        var checkPointTake = GameObject.FindGameObjectWithTag(_takeCatPositionTagName);
       　//切り口との差
        float distanceOfCutToCheckPoint = checkPointTake.transform.position.y - 0;

        //出した竹を消す
        var take = GameObject.FindGameObjectWithTag(_takeTagName);
        Destroy(take);

        //パーフェクトかどうか求める
        if (distanceOfCutToCheckPoint < _parfectCutGosa && distanceOfCutToCheckPoint > -_parfectCutGosa)
        {

            return;
        }

        //切った所が上の方だったら
        if (distanceOfCutToCheckPoint > _parfectCutGosa)
        {
            List<float> go = new List<float>();

            foreach (var a in _distance)
            {
                go.Add(a - distanceOfCutToCheckPoint);
            }
            //一番誤差の小さいインデックス
            int num = go.IndexOf(go.Min());
        }
        //切ったのが下のほうだったら
        else if (distanceOfCutToCheckPoint < -_parfectCutGosa)
        {
            List<float> go = new List<float>();

            foreach (var a in _distance)
            {
                go.Add( Mathf.Abs(a - distanceOfCutToCheckPoint));
            }
            //一番誤差の小さいインデックス
            int num = go.IndexOf(go.Min());
        }


    }




}
