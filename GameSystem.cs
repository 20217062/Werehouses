using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    #region �ϐ�
    public int _length = 5; //�z��̍���
    public int _width = 5; //�z��̕�
    public int[,] _mainObject; //�z��
    public char _insertNumber; //�I�u�W�F�N�g�̃^�C�v
    [SerializeField] string _seed = "1111110301102011400111111"; //�V�[�h�l
    string _seed_Copy; //�V�[�h�l�̃R�s�[
    [SerializeField] GameObject _zero; //��
    [SerializeField] GameObject _one;  //��
    [SerializeField] GameObject _two;  //��
    [SerializeField] GameObject _three;//�S�[��
    [SerializeField] GameObject _four;//�v���C���[
    private int _rethuX; //�J�[�\����x���W
    private int _rethuY; //�J�[�\����y���W
    public int _carsor; //�J�[�\���̔z��̈ʒu
    bool _fin = true; //�I���t���O
    public int _number = 0; //�z��̒l
    public static int _walk = default;
    #endregion

    void Start()
    {
        _seed_Copy = _seed;
        _mainObject = new int[_length, _width];
        StartArrangement();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (_mainObject[_rethuY - 1, _rethuX])
            {
                case 0:
                    _mainObject[_rethuY, _rethuX] -= 4;
                    _mainObject[_rethuY - 1, _rethuX] += 4;
                    _rethuY -= 1;
                    _carsor -= _length;
                    _walk++;
                    break;
                case 3:
                    _mainObject[_rethuY, _rethuX] -= 4;
                    _mainObject[_rethuY - 1, _rethuX] += 4;
                    _rethuY -= 1;
                    _carsor -= _length;
                    _walk++;
                    break;
                case 2:
                    if (_mainObject[_rethuY - 2, _rethuX] == 0 || _mainObject[_rethuY - 2, _rethuX] == 3)
                    {
                        _mainObject[_rethuY, _rethuX] -= 4;
                        _mainObject[_rethuY - 1, _rethuX] = 4;
                        _mainObject[_rethuY - 2, _rethuX] += 2;
                        _rethuY -= 1;
                        _carsor -= _length;
                        _walk++;
                    }
                    break;
                case 5:
                    if (_mainObject[_rethuY - 2, _rethuX] == 0 || _mainObject[_rethuY - 2, _rethuX] == 3)
                    {
                        _mainObject[_rethuY, _rethuX] -= 4;
                        _mainObject[_rethuY - 1, _rethuX] = 7;
                        _mainObject[_rethuY - 2, _rethuX] += 2;
                        _rethuY -= 1;
                        _carsor -= _length;
                        _walk++;
                    }
                    break;
                default:
                    break;
            }
            Finish();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (_mainObject[_rethuY, _rethuX - 1])
            {
                case 0:
                    _mainObject[_rethuY, _rethuX] -= 4;
                    _mainObject[_rethuY, _rethuX - 1] += 4;
                    _rethuX -= 1;
                    _carsor -= 1;
                    _walk++;
                    break;
                case 3:
                    _mainObject[_rethuY, _rethuX] -= 4;
                    _mainObject[_rethuY, _rethuX - 1] += 4;
                    _rethuX -= 1;
                    _carsor -= 1;
                    _walk++;
                    break;
                case 2:
                    if (_mainObject[_rethuY, _rethuX - 2] == 0 || _mainObject[_rethuY, _rethuX - 2] == 3)
                    {
                        _mainObject[_rethuY, _rethuX] -= 4;
                        _mainObject[_rethuY, _rethuX - 1] = 4;
                        _mainObject[_rethuY, _rethuX - 2] += 2;
                        _rethuX -= 1;
                        _carsor -= 1;
                        _walk++;
                    }
                    break;
                case 5:
                    if (_mainObject[_rethuY, _rethuX - 2] == 0 || _mainObject[_rethuY, _rethuX - 2] == 3)
                    {
                        _mainObject[_rethuY, _rethuX] -= 4;
                        _mainObject[_rethuY, _rethuX - 1] = 7;
                        _mainObject[_rethuY, _rethuX - 2] += 2;
                        _rethuX -= 1;
                        _carsor -= 1;
                        _walk++;
                    }
                    break;
                default:
                    break;
            }
            Finish();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (_mainObject[_rethuY + 1, _rethuX])
            {
                case 0:
                    _mainObject[_rethuY, _rethuX] -= 4;
                    _mainObject[_rethuY + 1, _rethuX] += 4;
                    _rethuY += 1;
                    _carsor += _length;
                    _walk++;
                    break;
                case 3:
                    _mainObject[_rethuY, _rethuX] -= 4;
                    _mainObject[_rethuY + 1, _rethuX] += 4;
                    _rethuY += 1;
                    _carsor += _length;
                    _walk++;
                    break;
                case 2:
                    if (_mainObject[_rethuY + 2, _rethuX] == 0 || _mainObject[_rethuY + 2, _rethuX] == 3)
                    {
                        _mainObject[_rethuY, _rethuX] -= 4;
                        _mainObject[_rethuY + 1, _rethuX] = 4;
                        _mainObject[_rethuY + 2, _rethuX] += 2;
                        _rethuY += 1;
                        _carsor += _length;
                        _walk++;
                    }
                    break;
                case 5:
                    if (_mainObject[_rethuY + 2, _rethuX] == 0 || _mainObject[_rethuY + 2, _rethuX] == 3)
                    {
                        _mainObject[_rethuY, _rethuX] -= 4;
                        _mainObject[_rethuY + 1, _rethuX] = 7;
                        _mainObject[_rethuY + 2, _rethuX] += 2;
                        _rethuY += 1;
                        _carsor += _length;
                        _walk++;
                    }
                    break;
                default:
                    break;
            }
            Finish();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (_mainObject[_rethuY, _rethuX + 1])
            {
                case 0:
                    _mainObject[_rethuY, _rethuX] -= 4;
                    _mainObject[_rethuY, _rethuX + 1] += 4;
                    _rethuX += 1;
                    _carsor += 1;
                    _walk++;
                    break;
                case 3:
                    _mainObject[_rethuY, _rethuX] -= 4;
                    _mainObject[_rethuY, _rethuX + 1] += 4;
                    _rethuX += 1;
                    _carsor += 1;
                    _walk++;
                    break;
                case 2:
                    if (_mainObject[_rethuY, _rethuX + 2] == 0 || _mainObject[_rethuY, _rethuX + 2] == 3)
                    {
                        _mainObject[_rethuY, _rethuX] -= 4;
                        _mainObject[_rethuY, _rethuX + 1] = 4;
                        _mainObject[_rethuY, _rethuX + 2] += 2;
                        _rethuX += 1;
                        _carsor += 1;
                        _walk++;
                    }
                    break;
                case 5:
                    if (_mainObject[_rethuY, _rethuX + 2] == 0 || _mainObject[_rethuY, _rethuX + 2] == 3)
                    {
                        _mainObject[_rethuY, _rethuX] -= 4;
                        _mainObject[_rethuY, _rethuX + 1] = 7;
                        _mainObject[_rethuY, _rethuX + 2] += 2;
                        _rethuX += 1;
                        _carsor += 1;
                        _walk++;
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
    void StartArrangement() //�X�^�[�g�̏���
    {
        _seed = _seed_Copy;
        _number = 0;
        _walk = 0;
        for (int i = 0; i < _length; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                _insertNumber = _seed[_number];
                print(_insertNumber);
                switch (_seed[_number])
                {
                    case '0':
                        Instantiate(_zero, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = 0;
                        break;
                    case '1':
                        Instantiate(_one, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = 1;
                        break;
                    case '2':
                        Instantiate(_two, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = 2;
                        break;
                    case '3':
                        Instantiate(_three, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = 3;
                        break;
                    case '4':
                        Instantiate(_four, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = 4;
                        break;
                    default:
                        break;
                }
                if (_insertNumber == '4')
                {
                    _carsor = _number;
                }
                _number++;

            }
        }
        _rethuY = _carsor / _width;
        _rethuX = _carsor % _width;
    }
    void Finish()
    {
        while (_fin == true)
        {
            for (int i = 0; i < _length; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (_mainObject[i, j] == 2)
                    {
                        _fin = false;
                    }
                }
            }
            break;
        }
        if (_fin == true)
        {
            SceneManager.LoadSceneAsync("Crear");
        }
        else
        {
            _fin = true;
        }
    }
}