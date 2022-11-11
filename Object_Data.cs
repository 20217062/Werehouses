using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Data : MonoBehaviour
{
    #region 変数
    public int _objectNo;
    public int _objectType;
    int _hairethuX;
    int _hairethuY;
    [SerializeField] SpriteRenderer _zero; //空白
    [SerializeField] SpriteRenderer _one;  //壁
    [SerializeField] SpriteRenderer _two;  //箱
    [SerializeField] SpriteRenderer _three;//ゴール
    [SerializeField] SpriteRenderer _four;//プレイヤー
    #endregion
    void Awake()
    {
        _objectNo = GetComponentInParent<GameSystem>()._number;
        _hairethuY = _objectNo / GetComponentInParent<GameSystem>()._width;
        _hairethuX = _objectNo % GetComponentInParent<GameSystem>()._width;
        switch (GetComponentInParent<GameSystem>()._insertNumber)
        {
            case '0':
                _objectType = 0;
                break;
            case '1':
                _objectType = 1;
                break;
            case '2':
                _objectType = 2;
                break;
            case '3':
                _objectType = 3;
                break;
            case '4':
                _objectType = 4;
                break;
        }
    }
    private void FixedUpdate()
    {
        if (_objectType != GetComponentInParent<GameSystem>()._mainObject[_hairethuY, _hairethuX])
        {
            _objectType = GetComponentInParent<GameSystem>()._mainObject[_hairethuY, _hairethuX];
            switch (_objectType)
            {
                case 0:
                    GetComponent<SpriteRenderer>().color = _zero.color;
                    GetComponent<SpriteRenderer>().sprite = _zero.sprite;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().color = _two.color;
                    GetComponent<SpriteRenderer>().sprite = _two.sprite;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().color = _three.color;
                    GetComponent<SpriteRenderer>().sprite = _three.sprite;
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().color = _four.color;
                    GetComponent<SpriteRenderer>().sprite = _four.sprite;
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().color = _two.color;
                    GetComponent<SpriteRenderer>().sprite = _two.sprite;
                    break;
                case 7:
                    GetComponent<SpriteRenderer>().color = _four.color;
                    GetComponent<SpriteRenderer>().sprite = _four.sprite;
                    break;
                default:
                    break;
            }
        }
    }
}