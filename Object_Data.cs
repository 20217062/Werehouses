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
        int blank = 0;
        int wall = 1;
        int box = 2;
        int goal = 3;
        int player = 4;
        _objectNo = GetComponentInParent<GameSystem>()._number; //1次元配列の座標セット
        _hairethuY = _objectNo / GetComponentInParent<GameSystem>()._width;//2次元配列y座標セット
        _hairethuX = _objectNo % GetComponentInParent<GameSystem>()._width;//2次元配列x座標セット
        switch (GetComponentInParent<GameSystem>()._insertNumber) //親スクリプトの現在のオブジェクトタイプを代入
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
        //自身のオブジェクトが変更されたら
        {
            _objectType = GetComponentInParent<GameSystem>()._mainObject[_hairethuY, _hairethuX];
            switch (_objectType) //スプライトのカラーとスキンを変更
            {
                case 0: //空白マスなら
                    GetComponent<SpriteRenderer>().color = _zero.color;
                    GetComponent<SpriteRenderer>().sprite = _zero.sprite;
                    break;
                case 2: //箱マスなら
                    GetComponent<SpriteRenderer>().color = _two.color;
                    GetComponent<SpriteRenderer>().sprite = _two.sprite;
                    break;
                case 3: //ゴールマスなら
                    GetComponent<SpriteRenderer>().color = _three.color;
                    GetComponent<SpriteRenderer>().sprite = _three.sprite;
                    break;
                case 4: //プレイヤーマスなら
                    GetComponent<SpriteRenderer>().color = _four.color;
                    GetComponent<SpriteRenderer>().sprite = _four.sprite;
                    break;
                case 5: //ゴールon箱マスなら
                    GetComponent<SpriteRenderer>().color = _two.color;
                    GetComponent<SpriteRenderer>().sprite = _two.sprite;
                    break;
                case 7: //ゴールonプレイヤーマスなら
                    GetComponent<SpriteRenderer>().color = _four.color;
                    GetComponent<SpriteRenderer>().sprite = _four.sprite;
                    break;
                default:
                    break;
            }
        }
    }
}