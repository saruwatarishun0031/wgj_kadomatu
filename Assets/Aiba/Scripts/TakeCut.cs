using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TakeCut : MonoBehaviour
{
    [Header("�|Tag�̖��O")]
    [SerializeField] string _takeTagName = "";

    [Header("�|�̒���ꏊ�̈ʒu�������Ă�I�u�W�F�N�g��Tag�̖��O")]
    [SerializeField] string _takeCatPositionTagName = "";

    [Header("�s�b�^���؂������ɂ���덷�̋��e")]
    [SerializeField] float _parfectCutGosa;

    [Header("�s�b�^���̒|�̃I�u�W�F�N�g")]
    [SerializeField] GameObject _parfectCutTake;

    [Header("�؂�����̌덷�B����|�̑f�ނ̑����ɂ��")]
    [SerializeField] List<float> _distance = new List<float>();

    [Header("��̕���؂������̒|�̃I�u�W�F�N�g�B�덷�̏��Ȃ��o�[�W������������")]
    [SerializeField] List<GameObject> _PlussTake = new List<GameObject>();

    [Header("���̕���؂������̒|�̃I�u�W�F�N�g�B�덷�̏��Ȃ��o�[�W������������")]
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
        //�؂���ƌ��̏ꏊ�̍������߂�
        var checkPointTake = GameObject.FindGameObjectWithTag(_takeCatPositionTagName);
       �@//�؂���Ƃ̍�
        float distanceOfCutToCheckPoint = checkPointTake.transform.position.y - 0;

        //�o�����|������
        var take = GameObject.FindGameObjectWithTag(_takeTagName);
        Destroy(take);

        //�p�[�t�F�N�g���ǂ������߂�
        if (distanceOfCutToCheckPoint < _parfectCutGosa && distanceOfCutToCheckPoint > -_parfectCutGosa)
        {

            return;
        }

        //�؂���������̕���������
        if (distanceOfCutToCheckPoint > _parfectCutGosa)
        {
            List<float> go = new List<float>();

            foreach (var a in _distance)
            {
                go.Add(a - distanceOfCutToCheckPoint);
            }
            //��Ԍ덷�̏������C���f�b�N�X
            int num = go.IndexOf(go.Min());
        }
        //�؂����̂����̂ق���������
        else if (distanceOfCutToCheckPoint < -_parfectCutGosa)
        {
            List<float> go = new List<float>();

            foreach (var a in _distance)
            {
                go.Add( Mathf.Abs(a - distanceOfCutToCheckPoint));
            }
            //��Ԍ덷�̏������C���f�b�N�X
            int num = go.IndexOf(go.Min());
        }


    }




}