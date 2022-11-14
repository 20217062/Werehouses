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
    [SerializeField] GameObject _zero; //空白
    [SerializeField] GameObject _one;  //壁
    [SerializeField] GameObject _two;  //箱
    [SerializeField] GameObject _three;//ゴール
    [SerializeField] GameObject _four; //プレイヤー
    private int _rethuX; //カーソルのx座標
    private int _rethuY; //カーソルのy座標
    int _carsor; //カーソルの配列の位置
    bool _fin = true; //終了フラグ
    public int _number = 0; //初期化時とリスタート時に使用
    public static int _walk = default; //歩数
    #endregion

    void Start() {
        int blank = 0; //空白
        int wall = 1; //壁
        int box = 2; //箱
        int goal = 3; //ゴール
        int player = 4; //プレイヤー
        _number = 0; //ナンバーを0で初期化
        _walk = 0; //歩数を0で初期化
        _mainObject = new int[_length, _width];
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //全配列探索
                _insertNumber = _seed[_number]; //シード値の先頭を切り出す
                switch (_seed[_number]) { //切り出した数値に従ってオブジェクト配置
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
                    _carsor = _number; //プレイヤーの位置がカーソルとなる
                }
                _number++;

            }
        }
        _rethuY = _carsor / _width; //プレイヤーのY座標を記憶
        _rethuX = _carsor % _width; //プレイヤーのX座標を記憶
    }
    private void Update() {
        int blank = 0;
        int box = 2;
        int goal = 3;
        int player = 4;
        int goalOnBox = 5;
        //[1]と[5]は未使用のため省略
        #region 上に移動したとき
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            //[W][↑]が入力されたとき
            if (_mainObject[_rethuY - 1, _rethuX] == blank || _mainObject[_rethuY - 1, _rethuX] == goal) {
                //移動先が空白またはゴールだった場合

                _mainObject[_rethuY, _rethuX] -= player;
                /* 元のプレイヤーの場所の値-4
                普通なら0(空白)となるが、ゴールonプレイヤーだった場合は3(ゴール)となる */

                _mainObject[_rethuY - 1, _rethuX] += player;
                /* 移動先の位置+4
                移動先が空白なら4(プレイヤー)、ゴールなら7(ゴールonプレイヤー)となる */

                _rethuY -= 1; //プレイヤー座標移動
                _carsor -= _length; //カーソル移動
                _walk++; //歩数増加
            } else if (_mainObject[_rethuY - 1, _rethuX] == box || _mainObject[_rethuY - 1, _rethuX] == goalOnBox) {
                //移動先が箱またはゴールon箱だった場合
                if (_mainObject[_rethuY - 2, _rethuX] == blank || _mainObject[_rethuY - 2, _rethuX] == goal)
                //箱の先が空白またはゴールなら
                {
                    _mainObject[_rethuY, _rethuX] -= player; //元プレイヤーの位置-4
                    _mainObject[_rethuY - 1, _rethuX] += box;
                    /* 元箱の位置+2 
                    元箱が2(箱)なら4(プレイヤー)、5(ゴールon箱)なら7(ゴールonプレイヤー)となる */

                    _mainObject[_rethuY - 2, _rethuX] += box; //箱の移動先+2、↑とほぼ同様
                    _rethuY -= 1; //プレイヤー座標移動
                    _carsor -= _length; //カーソル移動
                    _walk++;
                }
            }
            Finish();
        }
        #endregion
        /* 以後、方向が違うだけで同じ処理のためコメントは省略 */
        #region 左に移動したとき
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            //[A][←]が入力されたとき
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
        #region 下に移動したとき
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            //[S][↓]が入力されたとき
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
        #region 右に移動したとき
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            //[D][→]が入力されたとき
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
            StartArrangement(); //Spase入力で初期状態を再現
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Serect"); //Esc入力でセレクト画面に戻る
        }
    }
    void StartArrangement() //リスタートの処理
    {
        int blank = 0; //空白
        int wall = 1; //壁
        int box = 2; //箱
        int goal = 3; //ゴール
        int player = 4; //プレイヤー
        _number = 0; //ナンバーを0で初期化
        _walk = 0; //歩数を0で初期化
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //全配列探索
                _insertNumber = _seed[_number]; //シード値の先頭を切り出す
                switch (_seed[_number]) { //切り出した数値に従って全オブジェクトのタイプを変更
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
                    _carsor = _number; //カーソル位置をプレイヤーの位置に
                }
                _number++;

            }
        }
        _rethuY = _carsor / _width; //プレイヤーy座標更新
        _rethuX = _carsor % _width; //プレイヤーx座標更新
    }
    void Finish() {
        int box = 2;
        for (int i = 0; i < _length; i++) {
            for (int j = 0; j < _width; j++) { //全配列探索
                if (_mainObject[i, j] == box) {
                    _fin = false; //箱(2)が見つかれば_finを偽に
                }
            }
        }
        if (_fin == true) {
            SceneManager.LoadSceneAsync("Crear"); //_finが更新されなければステージクリア
        } else {
            _fin = true; //_finを真に
        }
    }
}