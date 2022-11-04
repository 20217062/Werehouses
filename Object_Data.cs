using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Data : MonoBehaviour
{
    public int Object_No;
    public int Object_Type;
    int Hairetu_x;
    int Hairetu_y;
    [SerializeField] SpriteRenderer Zero; //空白
    [SerializeField] SpriteRenderer One;  //壁
    [SerializeField] SpriteRenderer Two;  //箱
    [SerializeField] SpriteRenderer Three;//ゴール
    [SerializeField] SpriteRenderer Four;//プレイヤー
    void Awake()
    {
        Object_No = GetComponentInParent<GameSystem>().Number;
        Hairetu_y = Object_No / GetComponentInParent<GameSystem>().G_Width;
        Hairetu_x = Object_No % GetComponentInParent<GameSystem>().G_Width;
        switch (GetComponentInParent<GameSystem>().Insert_Number)
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
        if (Object_Type != GetComponentInParent<GameSystem>().Main_Object[Hairetu_y, Hairetu_x])
        {
            Object_Type = GetComponentInParent<GameSystem>().Main_Object[Hairetu_y, Hairetu_x];
            switch (Object_Type)
            {
                case 0:
                    GetComponent<SpriteRenderer>().color = Zero.color;
                    GetComponent<SpriteRenderer>().sprite = Zero.sprite;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().color = Two.color;
                    GetComponent<SpriteRenderer>().sprite = Two.sprite;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().color = Three.color;
                    GetComponent<SpriteRenderer>().sprite = Three.sprite;
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().color = Four.color;
                    GetComponent<SpriteRenderer>().sprite = Four.sprite;
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().color = Two.color;
                    GetComponent<SpriteRenderer>().sprite = Two.sprite;
                    break;
                case 7:
                    GetComponent<SpriteRenderer>().color = Four.color;
                    GetComponent<SpriteRenderer>().sprite = Four.sprite;
                    break;
                default:
                    break;
            }
        }
    }
}