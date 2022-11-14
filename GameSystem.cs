using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour {
    #region �ϐ�
    public int _length = 5; //�z��̍���
    public int _width = 5; //�z��̕�
    public int[,] _mainObject; //�z��
    public char _insertNumber; //�I�u�W�F�N�g�̃^�C�v
    [SerializeField] string _seed = "1111110301102011400111111"; //�V�[�h�l
    [SerializeField] GameObject _zero; //��
    [SerializeField] GameObject _one;  //��
    [SerializeField] GameObject _two;  //��
    [SerializeField] GameObject _three;//�S�[��
    [SerializeField] GameObject _four; //�v���C���[
    private int _rethuX; //�J�[�\����x���W
    private int _rethuY; //�J�[�\����y���W
    int _carsor; //�J�[�\���̔z��̈ʒu
    bool _fin = true; //�I���t���O
    public int _number = 0; //���������ƃ��X�^�[�g���Ɏg�p
    public static int _walk = default; //����
    #endregion

    void Start() {
        int blank = 0; //��
        int wall = 1; //��
        int box = 2; //��
        int goal = 3; //�S�[��
        int player = 4; //�v���C���[
        _number = 0; //�i���o�[��0�ŏ�����
        _walk = 0; //������0�ŏ�����
        _mainObject = new int[_length, _width];
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //�S�z��T��
                _insertNumber = _seed[_number]; //�V�[�h�l�̐擪��؂�o��
                switch (_seed[_number]) { //�؂�o�������l�ɏ]���ăI�u�W�F�N�g�z�u
                    case '0':
                        Instantiate(_zero, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = blank;
                        break;
                    case '1':
                        Instantiate(_one, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = wall;
                        break;
                    case '2':
                        Instantiate(_two, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = box;
                        break;
                    case '3':
                        Instantiate(_three, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = goal;
                        break;
                    case '4':
                        Instantiate(_four, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = player;
                        break;
                    default:
                        break;
                }
                if (_insertNumber == '4') {
                    _carsor = _number; //�v���C���[�̈ʒu���J�[�\���ƂȂ�
                }
                _number++;

            }
        }
        _rethuY = _carsor / _width; //�v���C���[��Y���W���L��
        _rethuX = _carsor % _width; //�v���C���[��X���W���L��
    }
    private void Update() {
        int blank = 0;
        int box = 2;
        int goal = 3;
        int player = 4;
        int goalOnBox = 5;
        //[1]��[5]�͖��g�p�̂��ߏȗ�
        #region ��Ɉړ������Ƃ�
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            //[W][��]�����͂��ꂽ�Ƃ�
            if (_mainObject[_rethuY - 1, _rethuX] == blank || _mainObject[_rethuY - 1, _rethuX] == goal) {
                //�ړ��悪�󔒂܂��̓S�[���������ꍇ

                _mainObject[_rethuY, _rethuX] -= player;
                /* ���̃v���C���[�̏ꏊ�̒l-4
                ���ʂȂ�0(��)�ƂȂ邪�A�S�[��on�v���C���[�������ꍇ��3(�S�[��)�ƂȂ� */

                _mainObject[_rethuY - 1, _rethuX] += player;
                /* �ړ���̈ʒu+4
                �ړ��悪�󔒂Ȃ�4(�v���C���[)�A�S�[���Ȃ�7(�S�[��on�v���C���[)�ƂȂ� */

                _rethuY -= 1; //�v���C���[���W�ړ�
                _carsor -= _length; //�J�[�\���ړ�
                _walk++; //��������
            } else if (_mainObject[_rethuY - 1, _rethuX] == box || _mainObject[_rethuY - 1, _rethuX] == goalOnBox) {
                //�ړ��悪���܂��̓S�[��on���������ꍇ
                if (_mainObject[_rethuY - 2, _rethuX] == blank || _mainObject[_rethuY - 2, _rethuX] == goal)
                //���̐悪�󔒂܂��̓S�[���Ȃ�
                {
                    _mainObject[_rethuY, _rethuX] -= player; //���v���C���[�̈ʒu-4
                    _mainObject[_rethuY - 1, _rethuX] += box;
                    /* �����̈ʒu+2 
                    ������2(��)�Ȃ�4(�v���C���[)�A5(�S�[��on��)�Ȃ�7(�S�[��on�v���C���[)�ƂȂ� */

                    _mainObject[_rethuY - 2, _rethuX] += box; //���̈ړ���+2�A���Ƃقړ��l
                    _rethuY -= 1; //�v���C���[���W�ړ�
                    _carsor -= _length; //�J�[�\���ړ�
                    _walk++;
                }
            }
            Finish();
        }
        #endregion
        /* �Ȍ�A�������Ⴄ�����œ��������̂��߃R�����g�͏ȗ� */
        #region ���Ɉړ������Ƃ�
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            //[A][��]�����͂��ꂽ�Ƃ�
            if (_mainObject[_rethuY, _rethuX - 1] == blank || _mainObject[_rethuY, _rethuX - 1] == goal) {
                _mainObject[_rethuY, _rethuX] -= player;
                _mainObject[_rethuY, _rethuX - 1] += player;
                _rethuX -= 1;
                _carsor -= 1;
                _walk++;
            } else if (_mainObject[_rethuY, _rethuX - 1] == box || _mainObject[_rethuY, _rethuX - 1] == goalOnBox) {
                if (_mainObject[_rethuY, _rethuX - 2] == blank || _mainObject[_rethuY, _rethuX - 2] == goal) {
                    _mainObject[_rethuY, _rethuX] -= player;
                    _mainObject[_rethuY, _rethuX - 1] += box;
                    _mainObject[_rethuY, _rethuX - 2] += box;
                    _rethuX -= 1;
                    _carsor -= 1;
                    _walk++;
                }
            }
            Finish();
        }
        #endregion
        #region ���Ɉړ������Ƃ�
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            //[S][��]�����͂��ꂽ�Ƃ�
            if (_mainObject[_rethuY + 1, _rethuX] == blank || _mainObject[_rethuY + 1, _rethuX] == goal) {
                _mainObject[_rethuY, _rethuX] -= player;
                _mainObject[_rethuY + 1, _rethuX] += player;
                _rethuY += 1;
                _carsor += _length;
                _walk++;
            } else if (_mainObject[_rethuY + 1, _rethuX] == box || _mainObject[_rethuY + 1, _rethuX] == goalOnBox) {
                if (_mainObject[_rethuY + 2, _rethuX] == blank || _mainObject[_rethuY + 2, _rethuX] == goal) {
                    _mainObject[_rethuY, _rethuX] -= player;
                    _mainObject[_rethuY + 1, _rethuX] += box;
                    _mainObject[_rethuY + 2, _rethuX] += box;
                    _rethuY += 1;
                    _carsor += _length;
                    _walk++;
                }
            }
            Finish();
        }
        #endregion
        #region �E�Ɉړ������Ƃ�
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            //[D][��]�����͂��ꂽ�Ƃ�
            if (_mainObject[_rethuY, _rethuX + 1] == blank || _mainObject[_rethuY, _rethuX + 1] == goal) {
                _mainObject[_rethuY, _rethuX] -= player;
                _mainObject[_rethuY, _rethuX + 1] += player;
                _rethuX += 1;
                _carsor += 1;
                _walk++;
            } else if (_mainObject[_rethuY, _rethuX + 1] == box || _mainObject[_rethuY, _rethuX + 1] == goalOnBox) {
                if (_mainObject[_rethuY, _rethuX + 2] == blank || _mainObject[_rethuY, _rethuX + 2] == goal) {
                    _mainObject[_rethuY, _rethuX] -= player;
                    _mainObject[_rethuY, _rethuX + 1] += box;
                    _mainObject[_rethuY, _rethuX + 2] += box;
                    _rethuX += 1;
                    _carsor += 1;
                    _walk++;
                }
            }
            Finish();
        }
        #endregion
        else if (Input.GetKeyDown(KeyCode.Space)) {
            StartArrangement(); //Spase���͂ŏ�����Ԃ��Č�
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Serect"); //Esc���͂ŃZ���N�g��ʂɖ߂�
        }
    }
    void StartArrangement() //���X�^�[�g�̏���
    {
        int blank = 0; //��
        int wall = 1; //��
        int box = 2; //��
        int goal = 3; //�S�[��
        int player = 4; //�v���C���[
        _number = 0; //�i���o�[��0�ŏ�����
        _walk = 0; //������0�ŏ�����
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //�S�z��T��
                _insertNumber = _seed[_number]; //�V�[�h�l�̐擪��؂�o��
                switch (_seed[_number]) { //�؂�o�������l�ɏ]���đS�I�u�W�F�N�g�̃^�C�v��ύX
                    case '0':
                        _mainObject[i, j] = blank;
                        break;
                    case '1':
                        _mainObject[i, j] = wall;
                        break;
                    case '2':
                        _mainObject[i, j] = box;
                        break;
                    case '3':
                        _mainObject[i, j] = goal;
                        break;
                    case '4':
                        _mainObject[i, j] = player;
                        break;
                    default:
                        break;
                }
                if (_insertNumber == '4') {
                    _carsor = _number; //�J�[�\���ʒu���v���C���[�̈ʒu��
                }
                _number++;

            }
        }
        _rethuY = _carsor / _width; //�v���C���[y���W�X�V
        _rethuX = _carsor % _width; //�v���C���[x���W�X�V
    }
    void Finish() {
        int box = 2;
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //�S�z��T��
                if (_mainObject[i, j] == box) {
                    _fin = false; //��(2)���������_fin���U��
                }
            }
        }
        if (_fin == true) {
            SceneManager.LoadSceneAsync("Crear"); //_fin���X�V����Ȃ���΃X�e�[�W�N���A
        } else {
            _fin = true; //_fin��^��
        }
    }
}