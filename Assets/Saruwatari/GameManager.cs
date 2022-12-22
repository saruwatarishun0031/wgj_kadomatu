using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _one;
    [SerializeField] Text _two;
    [SerializeField] Text _three;
    [SerializeField] string sceneName;

    public List<GameObject> _take = new List<GameObject>();

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
        _one.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        
    }

    public void TakesSet(GameObject take) 
    {
        _take.Add(take);
    }
    

    void Turn()
    {
        if (_oneTime == true)
        {
            _trunCount += 1;
            _oneTime = false;

        }
        if (_twoTime == true)
        {
            _trunCount += 1;
            _twoTime = false;
        }
        if (_threeTime == true)
        {
            _trunCount += 1;
            _threeTime = false;
        }
    }
    private IEnumerator Rizaruto()
    {
            yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }


}
