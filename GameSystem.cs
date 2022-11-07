using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    #region �ϐ�
    public int g_Length = 5; //�z��̍���
    public int g_Width = 5; //�z��̕�
    public int[,] main_Object; //�z��
    public char insert_Number; //�I�u�W�F�N�g�̃^�C�v
    [SerializeField] string seed = "1111110301102011400111111"; //�V�[�h�l
    string seed_Copy; //�V�[�h�l�̃R�s�[
    [SerializeField] GameObject zero; //��
    [SerializeField] GameObject one;  //��
    [SerializeField] GameObject two;  //��
    [SerializeField] GameObject three;//�S�[��
    [SerializeField] GameObject four;//�v���C���[
    private int rethu_X; //�J�[�\����x���W
    private int rethu_Y; //�J�[�\����y���W
    public int carsor; //�J�[�\���̔z��̈ʒu
    bool fin = true; //�I���t���O
    public int number = 0; //�z��̒l
    int Undo = default;
    public static int walk = default;
    #endregion

    void Start()
    {
        seed_Copy = seed;
        main_Object = new int[g_Length,g_Width];
        StartArrangement();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (main_Object[rethu_Y - 1, rethu_X])
            {
                case 0:
                    main_Object[rethu_Y, rethu_X] -= 4;
                    main_Object[rethu_Y - 1, rethu_X] += 4;
                    rethu_Y -= 1;
                    carsor -= g_Length;
                    Undo = 1;
                    walk++;
                    break;
                case 3:
                    main_Object[rethu_Y, rethu_X] -= 4;
                    main_Object[rethu_Y - 1, rethu_X] += 4;
                    rethu_Y -= 1;
                    carsor -= g_Length;
                    Undo = 1;
                    walk++;
                    break;
                case 2:
                    if (main_Object[rethu_Y - 2,rethu_X] == 0 || main_Object[rethu_Y - 2, rethu_X] == 3)
                    {
                        main_Object[rethu_Y, rethu_X] -= 4;
                        main_Object[rethu_Y - 1, rethu_X] = 4;
                        main_Object[rethu_Y - 2, rethu_X] += 2;
                        rethu_Y -= 1;
                        carsor -= g_Length;
                        Undo = 1;
                        walk++;
                    }
                    break;
                case 5:
                    if (main_Object[rethu_Y - 2, rethu_X] == 0 || main_Object[rethu_Y - 2, rethu_X] == 3)
                    {
                        main_Object[rethu_Y, rethu_X] -= 4;
                        main_Object[rethu_Y - 1, rethu_X] = 7;
                        main_Object[rethu_Y - 2, rethu_X] += 2;
                        rethu_Y -= 1;
                        carsor -= g_Length;
                        Undo = 1;
                        walk++;
                    }
                    break;
                default:
                    break;
            }
            finish();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (main_Object[rethu_Y,rethu_X - 1])
            {
                case 0:
                    main_Object[rethu_Y, rethu_X] -= 4;
                    main_Object[rethu_Y, rethu_X - 1] += 4;
                    rethu_X -= 1;
                    carsor -= 1;
                    Undo = 2;
                    walk++;
                    break;
                case 3:
                    main_Object[rethu_Y, rethu_X] -= 4;
                    main_Object[rethu_Y, rethu_X - 1] += 4;
                    rethu_X -= 1;
                    carsor -= 1;
                    Undo = 2;
                    walk++;
                    break;
                case 2:
                    if (main_Object[rethu_Y, rethu_X - 2] == 0 || main_Object[rethu_Y, rethu_X - 2] == 3)
                    {
                        main_Object[rethu_Y, rethu_X] -= 4;
                        main_Object[rethu_Y, rethu_X - 1] = 4;
                        main_Object[rethu_Y, rethu_X - 2] += 2;
                        rethu_X -= 1;
                        carsor -= 1;
                        Undo = 2;
                        walk++;
                    }
                    break;
                case 5:
                    if (main_Object[rethu_Y, rethu_X - 2] == 0 || main_Object[rethu_Y, rethu_X - 2] == 3)
                    {
                        main_Object[rethu_Y, rethu_X] -= 4;
                        main_Object[rethu_Y, rethu_X - 1] = 7;
                        main_Object[rethu_Y, rethu_X - 2] += 2;
                        rethu_X -= 1;
                        carsor -= 1;
                        Undo = 2;
                        walk++;
                    }
                    break;
                default:
                    break;
            }
            finish();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (main_Object[rethu_Y + 1,rethu_X])
            {
                case 0:
                    main_Object[rethu_Y, rethu_X] -= 4;
                    main_Object[rethu_Y + 1, rethu_X] += 4;
                    rethu_Y += 1;
                    carsor += g_Length;
                    Undo = 3;
                    walk++;
                    break;
                case 3:
                    main_Object[rethu_Y, rethu_X] -= 4;
                    main_Object[rethu_Y + 1, rethu_X] += 4;
                    rethu_Y += 1;
                    carsor += g_Length;
                    Undo = 3;
                    walk++;
                    break;
                case 2:
                    if (main_Object[rethu_Y + 2, rethu_X] == 0 || main_Object[rethu_Y + 2, rethu_X] == 3)
                    {
                        main_Object[rethu_Y, rethu_X] -= 4;
                        main_Object[rethu_Y + 1, rethu_X] = 4;
                        main_Object[rethu_Y + 2, rethu_X] += 2;
                        rethu_Y += 1;
                        carsor += g_Length;
                        Undo = 3;
                        walk++;
                    }
                    break;
                case 5:
                    if (main_Object[rethu_Y + 2, rethu_X] == 0 || main_Object[rethu_Y + 2, rethu_X] == 3)
                    {
                        main_Object[rethu_Y, rethu_X] -= 4;
                        main_Object[rethu_Y + 1, rethu_X] = 7;
                        main_Object[rethu_Y + 2, rethu_X] += 2;
                        rethu_Y += 1;
                        carsor += g_Length;
                        Undo = 3;
                        walk++;
                    }
                    break;
                default:
                    break;
            }
            finish();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (main_Object[rethu_Y, rethu_X + 1])
            {
                case 0:
                    main_Object[rethu_Y, rethu_X] -= 4;
                    main_Object[rethu_Y, rethu_X + 1] += 4;
                    rethu_X += 1;
                    carsor += 1;
                    Undo = 4;
                    walk++;
                    break;
                case 3:
                    main_Object[rethu_Y, rethu_X] -= 4;
                    main_Object[rethu_Y, rethu_X + 1] += 4;
                    rethu_X += 1;
                    carsor += 1;
                    Undo = 4;
                    walk++;
                    break;
                case 2:
                    if (main_Object[rethu_Y, rethu_X + 2] == 0 || main_Object[rethu_Y, rethu_X + 2] == 3)
                    {
                        main_Object[rethu_Y, rethu_X] -= 4;
                        main_Object[rethu_Y, rethu_X + 1] = 4;
                        main_Object[rethu_Y, rethu_X + 2] += 2;
                        rethu_X += 1;
                        carsor += 1;
                        Undo = 4;
                        walk++;
                    }
                    break;
                case 5:
                    if (main_Object[rethu_Y, rethu_X + 2] == 0 || main_Object[rethu_Y, rethu_X + 2] == 3)
                    {
                        main_Object[rethu_Y, rethu_X] -= 4;
                        main_Object[rethu_Y, rethu_X + 1] = 7;
                        main_Object[rethu_Y, rethu_X + 2] += 2;
                        rethu_X += 1;
                        carsor += 1;
                        Undo = 4;
                        walk++;
                    }
                    break;
                default:
                    break;
            }
            finish();
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
    void StartArrangement() //�X�^�[�g�̏���
    {
        seed = seed_Copy;
        number = 0;
        walk = 0;
        for (int i = 0; i < g_Length; i++)
        {
            for (int j = 0; j < g_Width; j++)
            {
                insert_Number = seed[number];
                print(insert_Number);
                switch (seed[number])
                {
                    case '0':
                        Instantiate(zero, new Vector2(j, g_Length - i), Quaternion.identity, transform);
                        main_Object[i, j] = 0;
                        break;
                    case '1':
                        Instantiate(one, new Vector2(j, g_Length - i), Quaternion.identity, transform);
                        main_Object[i, j] = 1;
                        break;
                    case '2':
                        Instantiate(two, new Vector2(j, g_Length - i), Quaternion.identity, transform);
                        main_Object[i, j] = 2;
                        break;
                    case '3':
                        Instantiate(three, new Vector2(j, g_Length - i), Quaternion.identity, transform);
                        main_Object[i, j] = 3;
                        break;
                    case '4':
                        Instantiate(four, new Vector2(j, g_Length - i), Quaternion.identity, transform);
                        main_Object[i, j] = 4;
                        break;
                    default:
                        break;
                }
                if (insert_Number == '4')
                {
                    carsor = number;
                }
                number++;

            }
        }
        rethu_Y = carsor / g_Width;
        rethu_X = carsor % g_Width;
    }
    void finish()
    {
        while (fin == true)
        {
            for (int i = 0; i < g_Length; i++)
            {
                for (int j = 0; j < g_Width; j++)
                {
                    if (main_Object[i, j] == 2)
                    {
                        fin = false;
                    }
                }
            }
            break;
        }
        if (fin == true)
        {
            SceneManager.LoadSceneAsync("Crear");
        }
        else
        {
            fin = true;
        }
    }
}