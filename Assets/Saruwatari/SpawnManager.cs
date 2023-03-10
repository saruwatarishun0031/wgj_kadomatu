using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _spawn1;
    [SerializeField] GameObject _spawn2;
    [SerializeField] GameObject _spawn3;


    private void Start()
    {

        Debug.Log(GameManager._take.Count);
        //一本目の竹
        Transform pos1 = _spawn1.transform;//new Vector3(x,y,z);
        var parent1 = pos1;

        Vector3 r = new Vector3(0, 180, 0);
        // プレハブを生成
        var go = Instantiate(GameManager._take[0], pos1.position, Quaternion.identity, parent1);
        go.transform.eulerAngles = r;

        //二本目の竹
        Transform pos2 = _spawn2.transform;//new Vector3(x,y,z);
        var parent2 = pos2;

        // プレハブを生成
        var go2 = Instantiate(GameManager._take[1], pos2.position, Quaternion.identity, parent2);
        go2.transform.eulerAngles = r;
        //三本目の竹
        Transform pos3 = _spawn3.transform;//new Vector3(x,y,z);
        var parent3 = pos3;

        // プレハブを生成
        var go3 = Instantiate(GameManager._take[2], pos3.position, Quaternion.identity, parent3);
        go3.transform.eulerAngles = r;

        GameManager._take.Clear();
    }


}
