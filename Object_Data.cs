using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Data : MonoBehaviour
{
    #region �ϐ�
    public int _objectNo;
    public int _objectType;
    int _hairethuX;
    int _hairethuY;
    [SerializeField] SpriteRenderer _zero; //��
    [SerializeField] SpriteRenderer _one;  //��
    [SerializeField] SpriteRenderer _two;  //��
    [SerializeField] SpriteRenderer _three;//�S�[��
    [SerializeField] SpriteRenderer _four;//�v���C���[
    #endregion
    void Awake()
    {
        int blank = 0;
        int wall = 1;
        int box = 2;
        int goal = 3;
        int player = 4;
        _objectNo = GetComponentInParent<GameSystem>()._number; //1�����z��̍��W�Z�b�g
        _hairethuY = _objectNo / GetComponentInParent<GameSystem>()._width;//2�����z��y���W�Z�b�g
        _hairethuX = _objectNo % GetComponentInParent<GameSystem>()._width;//2�����z��x���W�Z�b�g
        switch (GetComponentInParent<GameSystem>()._insertNumber) //�e�X�N���v�g�̌��݂̃I�u�W�F�N�g�^�C�v����
        {
            case '0':
                _objectType = blank;
                break;
            case '1':
                _objectType = wall;
                break;
            case '2':
                _objectType = box;
                break;
            case '3':
                _objectType = goal;
                break;
            case '4':
                _objectType = player;
                break;
        }
    }
    private void FixedUpdate()
    {
        if (_objectType != GetComponentInParent<GameSystem>()._mainObject[_hairethuY, _hairethuX])
        //���g�̃I�u�W�F�N�g���ύX���ꂽ��
        {
            _objectType = GetComponentInParent<GameSystem>()._mainObject[_hairethuY, _hairethuX];
            switch (_objectType) //�X�v���C�g�̃J���[�ƃX�L����ύX
            {
                case 0: //�󔒃}�X�Ȃ�
                    GetComponent<SpriteRenderer>().color = _zero.color;
                    GetComponent<SpriteRenderer>().sprite = _zero.sprite;
                    break;
                case 2: //���}�X�Ȃ�
                    GetComponent<SpriteRenderer>().color = _two.color;
                    GetComponent<SpriteRenderer>().sprite = _two.sprite;
                    break;
                case 3: //�S�[���}�X�Ȃ�
                    GetComponent<SpriteRenderer>().color = _three.color;
                    GetComponent<SpriteRenderer>().sprite = _three.sprite;
                    break;
                case 4: //�v���C���[�}�X�Ȃ�
                    GetComponent<SpriteRenderer>().color = _four.color;
                    GetComponent<SpriteRenderer>().sprite = _four.sprite;
                    break;
                case 5: //�S�[��on���}�X�Ȃ�
                    GetComponent<SpriteRenderer>().color = _two.color;
                    GetComponent<SpriteRenderer>().sprite = _two.sprite;
                    break;
                case 7: //�S�[��on�v���C���[�}�X�Ȃ�
                    GetComponent<SpriteRenderer>().color = _four.color;
                    GetComponent<SpriteRenderer>().sprite = _four.sprite;
                    break;
                default:
                    break;
            }
        }
    }
}