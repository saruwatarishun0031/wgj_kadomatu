using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // ��������v���n�u�i�[�p
    public GameObject PrefabCube;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._oneTime == true)
        {
            Vector3 pos = new Vector3(1, 1, 1);

            // �v���n�u�𐶐�
            Instantiate(PrefabCube, pos, Quaternion.identity);
        }

        if (GameManager.Instance._twoTime == true)
        {
            Vector3 pos = new Vector3(1, 1, 1);

            // �v���n�u�𐶐�
            Instantiate(PrefabCube, pos, Quaternion.identity);
        }

        if (GameManager.Instance._threeTime == true)
        {
            Vector3 pos = new Vector3(1, 1, 1);

            // �v���n�u�𐶐�
            Instantiate(PrefabCube, pos, Quaternion.identity);
        }

    }
}
