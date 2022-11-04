using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public int G_Length = 5; //配列の高さ
    public int G_Width = 5; //配列の幅
    public int[,] Main_Object; //配列
    public char Insert_Number; //オブジェクトのタイプ
    [SerializeField] string Seed = "1111110301102011400111111"; //シード値
    string Seed_copy;
    [SerializeField] GameObject Zero; //空白
    [SerializeField] GameObject One;  //壁
    [SerializeField] GameObject Two;  //箱
    [SerializeField] GameObject Three;//ゴール
    [SerializeField] GameObject Four;//プレイヤー
    int Rethu_x; //カーソルのx座標
    int Rethu_y; //カーソルのy座標
    public int Carsor; //カーソルの配列の位置
    bool Fin = true; //終了フラグ
    public int Number = 0; //配列の値
    int Undo = default;
    public static int Walk = default;
    void Start()
    {
        Seed_copy = Seed;
        Main_Object = new int[G_Length,G_Width];
        StartArrangement();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (Main_Object[Rethu_y - 1, Rethu_x])
            {
                case 0:
                    Main_Object[Rethu_y, Rethu_x] -= 4;
                    Main_Object[Rethu_y - 1, Rethu_x] += 4;
                    Rethu_y -= 1;
                    Carsor -= G_Length;
                    Undo = 1;
                    Walk++;
                    break;
                case 3:
                    Main_Object[Rethu_y, Rethu_x] -= 4;
                    Main_Object[Rethu_y - 1, Rethu_x] += 4;
                    Rethu_y -= 1;
                    Carsor -= G_Length;
                    Undo = 1;
                    Walk++;
                    break;
                case 2:
                    if (Main_Object[Rethu_y - 2,Rethu_x] == 0 || Main_Object[Rethu_y - 2, Rethu_x] == 3)
                    {
                        Main_Object[Rethu_y, Rethu_x] -= 4;
                        Main_Object[Rethu_y - 1, Rethu_x] = 4;
                        Main_Object[Rethu_y - 2, Rethu_x] += 2;
                        Rethu_y -= 1;
                        Carsor -= G_Length;
                        Undo = 1;
                        Walk++;
                    }
                    break;
                case 5:
                    if (Main_Object[Rethu_y - 2, Rethu_x] == 0 || Main_Object[Rethu_y - 2, Rethu_x] == 3)
                    {
                        Main_Object[Rethu_y, Rethu_x] -= 4;
                        Main_Object[Rethu_y - 1, Rethu_x] = 7;
                        Main_Object[Rethu_y - 2, Rethu_x] += 2;
                        Rethu_y -= 1;
                        Carsor -= G_Length;
                        Undo = 1;
                        Walk++;
                    }
                    break;
                default:
                    break;
            }
            Finish();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (Main_Object[Rethu_y,Rethu_x - 1])
            {
                case 0:
                    Main_Object[Rethu_y, Rethu_x] -= 4;
                    Main_Object[Rethu_y, Rethu_x - 1] += 4;
                    Rethu_x -= 1;
                    Carsor -= 1;
                    Undo = 2;
                    Walk++;
                    break;
                case 3:
                    Main_Object[Rethu_y, Rethu_x] -= 4;
                    Main_Object[Rethu_y, Rethu_x - 1] += 4;
                    Rethu_x -= 1;
                    Carsor -= 1;
                    Undo = 2;
                    Walk++;
                    break;
                case 2:
                    if (Main_Object[Rethu_y, Rethu_x - 2] == 0 || Main_Object[Rethu_y, Rethu_x - 2] == 3)
                    {
                        Main_Object[Rethu_y, Rethu_x] -= 4;
                        Main_Object[Rethu_y, Rethu_x - 1] = 4;
                        Main_Object[Rethu_y, Rethu_x - 2] += 2;
                        Rethu_x -= 1;
                        Carsor -= 1;
                        Undo = 2;
                        Walk++;
                    }
                    break;
                case 5:
                    if (Main_Object[Rethu_y, Rethu_x - 2] == 0 || Main_Object[Rethu_y, Rethu_x - 2] == 3)
                    {
                        Main_Object[Rethu_y, Rethu_x] -= 4;
                        Main_Object[Rethu_y, Rethu_x - 1] = 7;
                        Main_Object[Rethu_y, Rethu_x - 2] += 2;
                        Rethu_x -= 1;
                        Carsor -= 1;
                        Undo = 2;
                        Walk++;
                    }
                    break;
                default:
                    break;
            }
            Finish();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (Main_Object[Rethu_y + 1,Rethu_x])
            {
                case 0:
                    Main_Object[Rethu_y, Rethu_x] -= 4;
                    Main_Object[Rethu_y + 1, Rethu_x] += 4;
                    Rethu_y += 1;
                    Carsor += G_Length;
                    Undo = 3;
                    Walk++;
                    break;
                case 3:
                    Main_Object[Rethu_y, Rethu_x] -= 4;
                    Main_Object[Rethu_y + 1, Rethu_x] += 4;
                    Rethu_y += 1;
                    Carsor += G_Length;
                    Undo = 3;
                    Walk++;
                    break;
                case 2:
                    if (Main_Object[Rethu_y + 2, Rethu_x] == 0 || Main_Object[Rethu_y + 2, Rethu_x] == 3)
                    {
                        Main_Object[Rethu_y, Rethu_x] -= 4;
                        Main_Object[Rethu_y + 1, Rethu_x] = 4;
                        Main_Object[Rethu_y + 2, Rethu_x] += 2;
                        Rethu_y += 1;
                        Carsor += G_Length;
                        Undo = 3;
                        Walk++;
                    }
                    break;
                case 5:
                    if (Main_Object[Rethu_y + 2, Rethu_x] == 0 || Main_Object[Rethu_y + 2, Rethu_x] == 3)
                    {
                        Main_Object[Rethu_y, Rethu_x] -= 4;
                        Main_Object[Rethu_y + 1, Rethu_x] = 7;
                        Main_Object[Rethu_y + 2, Rethu_x] += 2;
                        Rethu_y += 1;
                        Carsor += G_Length;
                        Undo = 3;
                        Walk++;
                    }
                    break;
                default:
                    break;
            }
            Finish();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (Main_Object[Rethu_y, Rethu_x + 1])
            {
                case 0:
                    Main_Object[Rethu_y, Rethu_x] -= 4;
                    Main_Object[Rethu_y, Rethu_x + 1] += 4;
                    Rethu_x += 1;
                    Carsor += 1;
                    Undo = 4;
                    Walk++;
                    break;
                case 3:
                    Main_Object[Rethu_y, Rethu_x] -= 4;
                    Main_Object[Rethu_y, Rethu_x + 1] += 4;
                    Rethu_x += 1;
                    Carsor += 1;
                    Undo = 4;
                    Walk++;
                    break;
                case 2:
                    if (Main_Object[Rethu_y, Rethu_x + 2] == 0 || Main_Object[Rethu_y, Rethu_x + 2] == 3)
                    {
                        Main_Object[Rethu_y, Rethu_x] -= 4;
                        Main_Object[Rethu_y, Rethu_x + 1] = 4;
                        Main_Object[Rethu_y, Rethu_x + 2] += 2;
                        Rethu_x += 1;
                        Carsor += 1;
                        Undo = 4;
                        Walk++;
                    }
                    break;
                case 5:
                    if (Main_Object[Rethu_y, Rethu_x + 2] == 0 || Main_Object[Rethu_y, Rethu_x + 2] == 3)
                    {
                        Main_Object[Rethu_y, Rethu_x] -= 4;
                        Main_Object[Rethu_y, Rethu_x + 1] = 7;
                        Main_Object[Rethu_y, Rethu_x + 2] += 2;
                        Rethu_x += 1;
                        Carsor += 1;
                        Undo = 4;
                        Walk++;
                    }
                    break;
                default:
                    break;
            }
            Finish();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            StartArrangement();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Serect");
        }

    }
    void StartArrangement() //スタートの処理
    {
        Seed = Seed_copy;
        Number = 0;
        Walk = 0;
        for (int i = 0; i < G_Length; i++)
        {
            for (int j = 0; j < G_Width; j++)
            {
                Insert_Number = Seed[Number];
                print(Insert_Number);
                switch (Seed[Number])
                {
                    case '0':
                        Instantiate(Zero, new Vector2(j, G_Length - i), Quaternion.identity, transform);
                        Main_Object[i, j] = 0;
                        break;
                    case '1':
                        Instantiate(One, new Vector2(j, G_Length - i), Quaternion.identity, transform);
                        Main_Object[i, j] = 1;
                        break;
                    case '2':
                        Instantiate(Two, new Vector2(j, G_Length - i), Quaternion.identity, transform);
                        Main_Object[i, j] = 2;
                        break;
                    case '3':
                        Instantiate(Three, new Vector2(j, G_Length - i), Quaternion.identity, transform);
                        Main_Object[i, j] = 3;
                        break;
                    case '4':
                        Instantiate(Four, new Vector2(j, G_Length - i), Quaternion.identity, transform);
                        Main_Object[i, j] = 4;
                        break;
                    default:
                        break;
                }
                if (Insert_Number == '4')
                {
                    Carsor = Number;
                }
                Number++;

            }
        }
        Rethu_y = Carsor / G_Width;
        Rethu_x = Carsor % G_Width;
    }
    void Finish()
    {
        while (Fin == true)
        {
            for (int i = 0; i < G_Length; i++)
            {
                for (int j = 0; j < G_Width; j++)
                {
                    if (Main_Object[i, j] == 2)
                    {
                        Fin = false;
                    }
                }
            }
            break;
        }
        if (Fin == true)
        {
            SceneManager.LoadSceneAsync("Crear");
        }
        else
        {
            Fin = true;
        }
    }
}