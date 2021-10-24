using UnityEngine;         // [引用 Unity 引擎命名空間 : 可以使用此空間的 API

// 單行註解
// Alex 2021
// class 類別 : 一個物件的藍圖
// 語法 : 類別名稱 { 類別內容 ( 類別成員 ) }
// 此類別要在 Unity 內使用必須繼承 MonoBehavior
// 括號皆是成對出現 : ()、[]、{}、<>、''、""
public class Car : MonoBehaviour
{
    #region 欄位語法及四大常用類型
    // 欄位 Field : 保存各種類型的資料
    // 語法 : 修飾詞 資料類型 欄位名稱 指定 預設值 結束符號
    // ※四大常用類型 :
    // 整數 : 儲存沒有小數點的正負整數 - int
    // 浮點數 : 儲存帶有小數點的正負整數 - float
    // 字串 : 儲存文字 - string
    // 布林值 : 是與否 ture、false - bool
    // ※ 修飾詞
    // 私人 : 其他類別不能純取、不顯示 private (預設值)
    // 公開 : 其他類別可以存取、顯示 public
    // 欄位屬性 Attritube
    // 語法 : [屬性名稱(值)]
    // 1. 標題 Header(字串)
    // 2. 提示 Tooltip(字串)
    // 3. 範圍 Range( 最大值 , 最小時 )
    [Header("????"), Range(150, 2000)]
    public int cc = 1000;
    [Header("hdjsafafhj"), Range(1.0f, 5.0f)]
    public float weight = 3.5f;
    [Tooltip("this is ")]
    public string brdnd = "Benz";
    [Header("Have a windors ?")]
    public bool hasSkyWindoe = true;
    #endregion

    #region Unituy 內資料類型
    // 顏色、向量(座標)、按鍵、遊戲物件、元件
    // 顏色 Color
    public Color color;
    public Color colorRed = Color.red;
    public Color coloryellow = Color.yellow;
    public Color colorcustim1 = new Color(0, 0, 1);
    public Color colorcustim2 = new Color(0, 0, 0, 0.5f);
    // 向量 1 ~ 4 Vector
    public Vector2 v2;
    public Vector2 v20ne = Vector2.one;
    public Vector2 v2right = Vector2.right;
    public Vector2 v2up = Vector2.up;
    public Vector2 v2Custom = new Vector2(1, 2);
    public Vector3 v3custom = new Vector3(1, 2, 3);
    public Vector4 v4custom = new Vector4(1, 2, 3, 4);
    // 按鍵 KeyCord
    public KeyCode keycode;
    public KeyCode keycodeMouseLeft = KeyCode.Mouse0;
    public KeyCode keycodeJump = KeyCode.Space;
    // 遊戲物件 GameObject
    public GameObject goCamera;
    public GameObject goCar;
    // 元件 Component
    public Transform traCamera;
    public Camera cam;
    public SpriteRenderer spr;
    #endregion

    #region 事件 : 程式的入口
    //開始事件 : 遊戲撥放時執行一次
    private void Start()
    {
        //呼叫方法 :方法名稱();
        Test();
        Drive80();
        Drive(120);   //呼叫時填入的稱謂 : 引數
        Drive(999);
        float w99 = ConvertWeight(9.9f);
        print("9.9 轉換 : " + w99);

        print("重量轉換:" + ConvertWeight(weight));
    }
    #endregion
    #region 方法語法
    // 方法 : 保存程式內容的區塊,演算法、陳述式
    // 語法 : 修飾詞 回傳類型 方法名稱 (參數1，參數2，....，參數N) { 程式內容 }
    //void 無傳回 :使用方法時不會有傳回資料
    // 自訂方法 : 不會執行，必須呼叫才會執行
    private void Test()
    {
        //ﾅ・ﾅｹﾕﾉ) - ﾙｹﾕﾉﾅﾝ Unity ・ﾏﾐﾎｲ Console
        print("hellow.world");
    }
    private void Drive80()
    {
        print("drive:" + 80);
    }
    //參數語法 : 不會執行，必須呼叫才會執行
    private void Drive(int speed)
    {
        print("drive:" + speed);
        print("音效 : 咻咻咻");
    }

    private float ConvertWeight(float setWeight)
    {
        return setWeight * 50;
    }

    #endregion
}