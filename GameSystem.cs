using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {
    #region �ϐ�
    public int _length = 5; //�z��̍���
    public int _width = 5; //�z��̕�
    public int[,] _mainObject; //�z��
    public char _insertNumber; //�I�u�W�F�N�g�̃^�C�v
    string[] _seedArray;//�V�[�h�l
    private string _seed = default; //�V�[�h�l
    [SerializeField] private TextAsset _seedTxt;
    [SerializeField] private GameObject _zero; //�󔒃}�X�F�������Ɏg�p
    [SerializeField] private GameObject _one;  //�ǃ}�X�F�������Ɏg�p
    [SerializeField] private GameObject _two;  //���}�X�F�������Ɏg�p
    [SerializeField] private GameObject _three;//�S�[���}�X�F�������Ɏg�p
    [SerializeField] private GameObject _four; //�v���C���[�}�X�F�������Ɏg�p
    private int _rethuX; //�J�[�\����x���W
    private int _rethuY; //�J�[�\����y���W
    private int _playerCursor; //�J�[�\���̔z��̈ʒu
    private bool _isFin = true; //�I���t���O
    public int _number = default; //���������ƃ��X�^�[�g���Ɏg�p�A�X�e�[�W�ԍ���}�����Ă���
    public static int _walk = 0; //�����FWalk�œǂݍ��ނ��߂�static��
    private bool _inputSwitch = false;//���͂���Ă���Ԃ̏����Ɏg�p
    enum Number : int {
        _blank = 0,
        _wall,
        _box,
        _goal,
        _player,
        _goalOnBox
    }
    #endregion

    void Start() {
        _seedArray = _seedTxt.text.Split(char.Parse("\n"));
        for (int i = 0;i < _number;i++) {
            _seed = _seedArray[i];
        }
        _number = 0;
        _mainObject = new int[_length, _width];
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //�S�z��T��
                _insertNumber = _seed[_number]; //�V�[�h�l�̐擪��؂�o��
                switch (_seed[_number]) { //�؂�o�������l�ɏ]���ăI�u�W�F�N�g�z�u
                    case '0':
                        Instantiate(_zero, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = (int)Number._blank;
                        break;
                    case '1':
                        Instantiate(_one, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = (int)Number._wall;
                        break;
                    case '2':
                        Instantiate(_two, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = (int)Number._box;
                        break;
                    case '3':
                        Instantiate(_three, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = (int)Number._goal;
                        break;
                    case '4':
                        Instantiate(_four, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = (int)Number._player;
                        break;
                    default:
                        break;
                }
                if (_insertNumber == '4') {
                    _playerCursor = _number; //�v���C���[�̈ʒu���J�[�\���ƂȂ�
                }
                _number++;
            }
        }
        _rethuY = _playerCursor / _width; //�v���C���[��Y���W���L��
        _rethuX = _playerCursor % _width; //�v���C���[��X���W���L��
    }
    private void Update() {
        if (!_inputSwitch) {
            InputArray();//WASD���͏��� 
        }
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0) {
            _inputSwitch = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartArrangement(); //Spase���͂ŏ�����Ԃ��Č�
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Serect"); //Esc���͂ŃZ���N�g��ʂɖ߂�
        }
    }
    private void InputArray() {
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) { //���͂��ꂽ�Ƃ�
            _inputSwitch = true;
            //�ړ��悪�󔒂܂��̓S�[���������ꍇ
            if (_mainObject[_rethuY  - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] == (int)Number._blank
            || _mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] == (int)Number._goal) {

                /* ���̃v���C���[�̏ꏊ�̒l-4
                ���ʂȂ�0(��)�ƂȂ邪�A�S�[��on�v���C���[�������ꍇ��3(�S�[��)�ƂȂ� */
                _mainObject[_rethuY, _rethuX] -= (int)Number._player;

                /* �ړ���̈ʒu+4�@�ړ��悪�󔒂Ȃ�4(�v���C���[)�A�S�[���Ȃ�7(�S�[��on�v���C���[)�ƂȂ� */
                _mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] += (int)Number._player;

                _rethuX += 1 * (int)Input.GetAxisRaw("Horizontal");
                _rethuY -= 1 * (int)Input.GetAxisRaw("Vertical"); //�v���C���[���W�ړ�
                if (Input.GetAxisRaw("Vertical") != 0) {
                    _playerCursor -= _length * (int)Input.GetAxisRaw("Vertical");
                } else if (Input.GetAxisRaw("Horizontal") != 0) {
                    _playerCursor -= 1 * (int)Input.GetAxisRaw("Horizontal");
                }//�J�[�\���ړ�
                _walk++; //��������
                //�ړ��悪���܂��̓S�[��on���������ꍇ
            } else if (_mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] == (int)Number._box
            || _mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] == (int)Number._goalOnBox) {
                //���̐悪�󔒂܂��̓S�[���Ȃ�
                if (_mainObject[_rethuY - (2 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (2 * (int)Input.GetAxisRaw("Horizontal"))] == (int)Number._blank
            || _mainObject[_rethuY - (2 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (2 * (int)Input.GetAxisRaw("Horizontal"))] == (int)Number._goal)
                {
                    _mainObject[_rethuY, _rethuX] -= (int)Number._player; //���v���C���[�̈ʒu-4

                    /* �����̈ʒu+2 
                    ������2(��)�Ȃ�4(�v���C���[)�A5(�S�[��on��)�Ȃ�7(�S�[��on�v���C���[)�ƂȂ� */
                    _mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] += (int)Number._box;

                    //���̈ړ���+2�A���Ƃقړ��l
                    _mainObject[_rethuY - (2 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (2 * (int)Input.GetAxisRaw("Horizontal"))] += (int)Number._box;
                    _rethuX += 1 * (int)Input.GetAxisRaw("Horizontal");
                    _rethuY -= 1 * (int)Input.GetAxisRaw("Vertical"); //�v���C���[���W�ړ�
                    if (Input.GetAxisRaw("Vertical") != 0) {
                        _playerCursor -= _length * (int)Input.GetAxisRaw("Vertical");
                    } else if (Input.GetAxisRaw("Horizontal") != 0) {
                        _playerCursor -= 1 * (int)Input.GetAxisRaw("Horizontal");
                    }//�J�[�\���ړ�
                    _walk++;
                }
            }
            Finish();
        }
    }
    private void StartArrangement() //���X�^�[�g�̏���
    {
        _number = 0; //�i���o�[��0�ŏ�����
        _walk = 0; //������0�ŏ�����
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //�S�z��T��
                _insertNumber = _seed[_number]; //�V�[�h�l�̐擪��؂�o��
                switch (_seed[_number]) { //�؂�o�������l�ɏ]���đS�I�u�W�F�N�g�̃^�C�v��ύX
                    case '0':
                        _mainObject[i, j] = (int)Number._blank;
                        break;
                    case '1':
                        _mainObject[i, j] = (int)Number._wall;
                        break;
                    case '2':
                        _mainObject[i, j] = (int)Number._box;
                        break;
                    case '3':
                        _mainObject[i, j] = (int)Number._goal;
                        break;
                    case '4':
                        _mainObject[i, j] = (int)Number._player;
                        break;
                    default:
                        break;
                }
                if (_insertNumber == '4') {
                    _playerCursor = _number; //�J�[�\���ʒu���v���C���[�̈ʒu��
                }
                _number++;

            }
        }
        _rethuY = _playerCursor / _width; //�v���C���[y���W�X�V
        _rethuX = _playerCursor % _width; //�v���C���[x���W�X�V
    }
    private void Finish() {
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //�S�z��T��
                if (_mainObject[i, j] == (int)Number._box) {
                    _isFin = false; //��(2)���������_isFin���U��
                }
            }
        }
        if (_isFin == true) {
            SceneManager.LoadSceneAsync("Crear"); //_isFin���X�V����Ȃ���΃X�e�[�W�N���A
        } else {
            _isFin = true; //_isFin��^��
        }
    }
}