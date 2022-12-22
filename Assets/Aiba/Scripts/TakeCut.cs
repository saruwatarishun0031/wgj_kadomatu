using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class TakeCut : MonoBehaviour
{
    [Header("�|Tag�̖��O")]
    [SerializeField] string _takeTagName = "";

    [Header("�|�̒���ꏊ�̈ʒu�������Ă�I�u�W�F�N�g��Tag�̖��O")]
    [SerializeField] string _takeCatPositionTagName = "";

    [Header("�s�b�^���؂������ɂ���덷�̋��e")]
    [SerializeField] float _parfectCutGosa;

    [Header("�s�b�^���؂������̒|�̃I�u�W�F�N�g")]
    [SerializeField] GameObject _parfectCutTake;

    [Header("�؂�Ȃ��������̒|�̃I�u�W�F�N�g")]
    [SerializeField] GameObject _noCutTake;


    [Header("�؂�����̌덷�B����|�̑f�ނ̑����ɂ��")]
    [SerializeField] List<float> _distance = new List<float>();

    [Header("��̕���؂������̒|�̃I�u�W�F�N�g�B�덷�̏��Ȃ��o�[�W������������")]
    [SerializeField] List<GameObject> _shortTake = new List<GameObject>();

    [Header("���̕���؂������̒|�̃I�u�W�F�N�g�B�덷�̏��Ȃ��o�[�W������������")]
    [SerializeField] List<GameObject> _longTake = new List<GameObject>();

    [Header("�����I�������鎞��")]
    [SerializeField] float _endTime;

    float _countTime = 0;


    [Header("�|��؂�{�^��")]
    [SerializeField] GameObject _cutButtun;

    [SerializeField] SpownTake _spownTake;
    [SerializeField] GameManager _gm;



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

                //�o�����|������
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

        //�؂���ƌ��̏ꏊ�̍������߂�
        var checkPointTake = GameObject.FindGameObjectWithTag(_takeCatPositionTagName);
        //�؂���Ƃ̍�


        float distanceOfCutToCheckPoint = checkPointTake.transform.position.y;

        //�o�����|������
        var take = GameObject.FindGameObjectWithTag(_takeTagName);
        Destroy(take);

        //�p�[�t�F�N�g���ǂ������߂�
        //if (distanceOfCutToCheckPoint < _parfectCutGosa && distanceOfCutToCheckPoint > -_parfectCutGosa)
        //{
        //    _isCut = true;
        //    _gm.TakesSet(_parfectCutTake);
        //    _gm.TurnPurasu();
        //    return;
        //}

        //�؂��������A�|�C���g��艺�̕���������  (�l��+)
        if (distanceOfCutToCheckPoint >= 0)
        {
            for (int i = 0; i < _distance.Count - 1; i++)
            {
                if (_distance[i] < distanceOfCutToCheckPoint && distanceOfCutToCheckPoint < _distance[i + 1])
                {
                    //��Ԍ덷�̏������C���f�b�N�X
                    _gm.TakesSet(_shortTake[i]);
                    _gm.TurnPurasu();
                    _isCut = true;
                    return;
                }
            }
        }
        //�؂��������A�|�C���g��艺�̕��������� (�l��-)
        else if (distanceOfCutToCheckPoint < 0)
        {
            for (int i = 0; i < _distance.Count - 1; i++)
            {
                if (-_distance[i] > distanceOfCutToCheckPoint && distanceOfCutToCheckPoint > -_distance[i + 1])
                {
                    _gm.TakesSet(_longTake[i]);
                    _gm.TurnPurasu();
                    _isCut = true;
                    return;
                }
            }
        }

        _isCut = true;
        _countTime = 0;
        _cutButtun.SetActive(false);

        //�o�����|������
        var takes = GameObject.FindGameObjectWithTag(_takeTagName);
        Destroy(take);
        _gm.TakesSet(_noCutTake);
        _gm.TurnPurasu();
    }




}
