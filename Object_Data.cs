using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Data : MonoBehaviour
{
    #region 変数
    public int Object_No;
    public int Object_Type;
    int Hairetu_x;
    int Hairetu_y;
    [SerializeField] SpriteRenderer zero; //空白
    [SerializeField] SpriteRenderer one;  //壁
    [SerializeField] SpriteRenderer two;  //箱
    [SerializeField] SpriteRenderer three;//ゴール
    [SerializeField] SpriteRenderer four;//プレイヤー
    #endregion
    void Awake()
    {
        Object_No = GetComponentInParent<GameSystem>().number;
        Hairetu_y = Object_No / GetComponentInParent<GameSystem>().g_Width;
        Hairetu_x = Object_No % GetComponentInParent<GameSystem>().g_Width;
        switch (GetComponentInParent<GameSystem>().insert_Number)
        {
            case '0':
                Object_Type = 0;
                break;
            case '1':
                Object_Type = 1;
                break;
            case '2':
                Object_Type = 2;
                break;
            case '3':
                Object_Type = 3;
                break;
            case '4':
                Object_Type = 4;
                break;
        }
    }
    private void FixedUpdate()
    {
        if (Object_Type != GetComponentInParent<GameSystem>().main_Object[Hairetu_y, Hairetu_x])
        {
            Object_Type = GetComponentInParent<GameSystem>().main_Object[Hairetu_y, Hairetu_x];
            switch (Object_Type)
            {
                case 0:
                    GetComponent<SpriteRenderer>().color = zero.color;
                    GetComponent<SpriteRenderer>().sprite = zero.sprite;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().color = two.color;
                    GetComponent<SpriteRenderer>().sprite = two.sprite;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().color = three.color;
                    GetComponent<SpriteRenderer>().sprite = three.sprite;
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().color = four.color;
                    GetComponent<SpriteRenderer>().sprite = four.sprite;
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().color = two.color;
                    GetComponent<SpriteRenderer>().sprite = two.sprite;
                    break;
                case 7:
                    GetComponent<SpriteRenderer>().color = four.color;
                    GetComponent<SpriteRenderer>().sprite = four.sprite;
                    break;
                default:
                    break;
            }
        }
    }
}