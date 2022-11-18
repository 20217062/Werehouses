using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour {
    #region 変数
    public int _length = 5; //配列の高さ
    public int _width = 5; //配列の幅
    public int[,] _mainObject; //配列
    public char _insertNumber; //オブジェクトのタイプ
    [SerializeField] string _seed = "1111110301102011400111111"; //シード値
    [SerializeField] private GameObject _zero; //空白：生成時に使用
    [SerializeField] private GameObject _one;  //壁：生成時に使用
    [SerializeField] private GameObject _two;  //箱：生成時に使用
    [SerializeField] private GameObject _three;//ゴール：生成時に使用
    [SerializeField] private GameObject _four; //プレイヤー：生成時に使用
    private int _rethuX; //カーソルのx座標
    private int _rethuY; //カーソルのy座標
    private int _playerCursor; //カーソルの配列の位置
    private bool _isFin = true; //終了フラグ
    public int _number = 0; //初期化時とリスタート時に使用
    public static int _walk = 0; //歩数
    private int _blank = 0; //空白
    private int _wall = 1; //壁
    private int _box = 2; //箱
    private int _goal = 3; //ゴール
    private int _player = 4; //プレイヤー
    private int _goalOnBox = 5;//ゴールに箱が乗ってる
    private bool _inputSwitch = false;//入力されている間の処理に使用
    #endregion

    void Start() {
        _mainObject = new int[_length, _width];
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //全配列探索
                _insertNumber = _seed[_number]; //シード値の先頭を切り出す
                switch (_seed[_number]) { //切り出した数値に従ってオブジェクト配置
                    case '0':
                        Instantiate(_zero, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = _blank;
                        break;
                    case '1':
                        Instantiate(_one, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = _wall;
                        break;
                    case '2':
                        Instantiate(_two, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = _box;
                        break;
                    case '3':
                        Instantiate(_three, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = _goal;
                        break;
                    case '4':
                        Instantiate(_four, new Vector2(j, _length - i), Quaternion.identity, transform);
                        _mainObject[i, j] = _player;
                        break;
                    default:
                        break;
                }
                if (_insertNumber == '4') {
                    _playerCursor = _number; //プレイヤーの位置がカーソルとなる
                }
                _number++;

            }
        }
        _rethuY = _playerCursor / _width; //プレイヤーのY座標を記憶
        _rethuX = _playerCursor % _width; //プレイヤーのX座標を記憶
    }
    private void Update() {
        if (!_inputSwitch) {
            InputArray();//WASD入力処理 
        }
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0) {
            _inputSwitch = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartArrangement(); //Spase入力で初期状態を再現
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Serect"); //Esc入力でセレクト画面に戻る
        }
    }
    private void InputArray() {
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) { //入力されたとき
            _inputSwitch = true;
            if (_mainObject[_rethuY  - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] == _blank
            || _mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] == _goal) {
                //移動先が空白またはゴールだった場合

                _mainObject[_rethuY, _rethuX] -= _player;
                /* 元のプレイヤーの場所の値-4
                普通なら0(空白)となるが、ゴールonプレイヤーだった場合は3(ゴール)となる */

                _mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] += _player;
                /* 移動先の位置+4　移動先が空白なら4(プレイヤー)、ゴールなら7(ゴールonプレイヤー)となる */

                _rethuX += 1 * (int)Input.GetAxisRaw("Horizontal");
                _rethuY -= 1 * (int)Input.GetAxisRaw("Vertical"); //プレイヤー座標移動
                if (Input.GetAxisRaw("Vertical") != 0) {
                    _playerCursor -= _length * (int)Input.GetAxisRaw("Vertical");
                } else if (Input.GetAxisRaw("Horizontal") != 0) {
                    _playerCursor -= 1 * (int)Input.GetAxisRaw("Horizontal");
                }//カーソル移動
                _walk++; //歩数増加
            } else if (_mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] == _box
            || _mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] == _goalOnBox) {
                //移動先が箱またはゴールon箱だった場合
                if (_mainObject[_rethuY - (2 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (2 * (int)Input.GetAxisRaw("Horizontal"))] == _blank
            || _mainObject[_rethuY - (2 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (2 * (int)Input.GetAxisRaw("Horizontal"))] == _goal)
                //箱の先が空白またはゴールなら
                {
                    _mainObject[_rethuY, _rethuX] -= _player; //元プレイヤーの位置-4
                    _mainObject[_rethuY - (1 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (1 * (int)Input.GetAxisRaw("Horizontal"))] += _box;
                    /* 元箱の位置+2 
                    元箱が2(箱)なら4(プレイヤー)、5(ゴールon箱)なら7(ゴールonプレイヤー)となる */

                    _mainObject[_rethuY - (2 * (int)Input.GetAxisRaw("Vertical")), _rethuX + (2 * (int)Input.GetAxisRaw("Horizontal"))] += _box;
                    //箱の移動先+2、↑とほぼ同様
                    _rethuX += 1 * (int)Input.GetAxisRaw("Horizontal");
                    _rethuY -= 1 * (int)Input.GetAxisRaw("Vertical"); //プレイヤー座標移動
                    if (Input.GetAxisRaw("Vertical") != 0) {
                        _playerCursor -= _length * (int)Input.GetAxisRaw("Vertical");
                    } else if (Input.GetAxisRaw("Horizontal") != 0) {
                        _playerCursor -= 1 * (int)Input.GetAxisRaw("Horizontal");
                    }//カーソル移動
                    _walk++;
                }
            }
            Finish();
        }
    }
    private void StartArrangement() //リスタートの処理
    {
        _number = 0; //ナンバーを0で初期化
        _walk = 0; //歩数を0で初期化
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //全配列探索
                _insertNumber = _seed[_number]; //シード値の先頭を切り出す
                switch (_seed[_number]) { //切り出した数値に従って全オブジェクトのタイプを変更
                    case '0':
                        _mainObject[i, j] = _blank;
                        break;
                    case '1':
                        _mainObject[i, j] = _wall;
                        break;
                    case '2':
                        _mainObject[i, j] = _box;
                        break;
                    case '3':
                        _mainObject[i, j] = _goal;
                        break;
                    case '4':
                        _mainObject[i, j] = _player;
                        break;
                    default:
                        break;
                }
                if (_insertNumber == '4') {
                    _playerCursor = _number; //カーソル位置をプレイヤーの位置に
                }
                _number++;

            }
        }
        _rethuY = _playerCursor / _width; //プレイヤーy座標更新
        _rethuX = _playerCursor % _width; //プレイヤーx座標更新
    }
    private void Finish() {
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //全配列探索
                if (_mainObject[i, j] == _box) {
                    _isFin = false; //箱(2)が見つかれば_isFinを偽に
                }
            }
        }
        if (_isFin == true) {
            SceneManager.LoadSceneAsync("Crear"); //_isFinが更新されなければステージクリア
        } else {
            _isFin = true; //_isFinを真に
        }
    }
}