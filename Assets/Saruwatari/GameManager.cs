using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image _one;
    [SerializeField] Image _two;
    [SerializeField] Image _three;
    [SerializeField] Button _startButton;

    public bool _oneTime = false;
    public bool _twoTime = false;
    public bool _threeTime = false;

    public int _trunCount;
    //シングルトンパターン（簡易型、呼び出される）
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //シングルトン（ここまで）
    // Start is called before the first frame update
    void Start()
    {
        _trunCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
    }

    void OneTime()
    {
        _oneTime = true;
        
    }

    void TwoTime()
    {
        _twoTime = true;
        
    }
    void ThreeTime()
    {
        _threeTime = true;
    }

    void Turn()
    {
        if (_oneTime == true)
        {
            _trunCount += 1;
        }
        if (_twoTime == true)
        {
            _trunCount += 1;
        }
        if (_threeTime == true)
        {
            _trunCount += 1;
        }
        if (_trunCount == 3)
        {
            Rizaruto();
        }
    }
    private IEnumerator Rizaruto()
    {
            yield return new WaitForSeconds(2f);

    }


}
