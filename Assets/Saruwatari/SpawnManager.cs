using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // 生成するプレハブ格納用
    public GameObject PrefabCube;

    public int x;
    public int y;
    public int z;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._oneTime == true)
        {
            Vector3 pos = new Vector3(x,y,z);

            // プレハブを生成
            Instantiate(PrefabCube, pos, Quaternion.identity);
            GameManager.Instance._oneTime = false;
            Debug.Log("1");
        }

        if (GameManager.Instance._twoTime == true)
        {
            Vector3 pos = new Vector3(x, y, z);

            // プレハブを生成
            Instantiate(PrefabCube, pos, Quaternion.identity);
            GameManager.Instance._twoTime = false;
            Debug.Log("2");
        }

        if (GameManager.Instance._threeTime == true)
        {
            Vector3 pos = new Vector3(x, y, z);

            // プレハブを生成
            Instantiate(PrefabCube, pos, Quaternion.identity);
            GameManager.Instance._threeTime = false;
            Debug.Log("3");
        }

    }
}
