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

        //��{�ڂ̒|
        Transform pos1 = _spawn1.transform;//new Vector3(x,y,z);
        var parent1 = pos1;

        // �v���n�u�𐶐�
        Instantiate(GameManager.Instance._take[0], pos1.position, Quaternion.identity, parent1);

        //��{�ڂ̒|
        Transform pos2 = _spawn2.transform;//new Vector3(x,y,z);
        var parent2 = pos2;

        // �v���n�u�𐶐�
        Instantiate(GameManager.Instance._take[1], pos2.position, Quaternion.identity, parent2);

        //�O�{�ڂ̒|
        Transform pos3 = _spawn3.transform;//new Vector3(x,y,z);
        var parent3 = pos3;

        // �v���n�u�𐶐�
        Instantiate(GameManager.Instance._take[2], pos3.position, Quaternion.identity, parent3);
    }


}
