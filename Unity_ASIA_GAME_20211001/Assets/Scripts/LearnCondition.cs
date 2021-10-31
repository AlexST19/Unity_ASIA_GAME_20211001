using UnityEngine;

/// <summary>
/// 認識判斷式(條件式)
/// </summary>
public class LearnCondition : MonoBehaviour
{
    public bool openDoor = true;
    public int score;
    public string weapon = "刀子";

    //開始事件 : 播放遊戲執行一次
    private void Start()
    {
        #region 判斷式 if
        //語法 : 
        //當 布林值 為 true 會執行 if 的 {}
        //if (布林值) { 程式內容 }
        if (true)
        {
            print("認識判斷式 if");
        }

        //當 布林值 為true 會執行 if 的 {}
        //當 布林值 為fales 會執行 else 的 {}
        // if (布林值) { 程式內容 }
        // else { 程式內容 }
        if (openDoor)
        {
            print("開門!");
        }
        else
        {
            print("關門!");
        }
        #endregion
    }

    //更新事件 : 約一秒六十次 (60 fps)
    private void Update()
    {
        print("持續執行~");

        #region 判斷式 if
        //否則 如果 else if (布林值) { 程式內容 } - if 下方 else 上方 - 無數量限制
        // 如果 分數 >= 60及格
        // 如果 分數 >= 60 但是 >= 40 補考
        // 否則 就 不及格
        if (score >= 60)
        {
            print("及格~");
        }
        else if(score>=40)
        {
            print("補考");
         }
        else
        {
            print("不及格");
        }
        #endregion

        #region 判斷式 switch
        // switch (值)
        // {
        //     case "刀子":
        //        攻擊力 10;
        //        break; 
        //     case "機關槍":
        //        攻擊力 10;
        //        break;
        //     default:
        //        這不是武器:
        //        break;
        //  }

        switch (weapon)
        {
            case "刀子":
                print("攻擊力 10");
                break;
            case "機關槍":
                print("攻擊力 1000");
                break;
            default:
                print("這不是武器!");
                break;

        }
        #endregion
    }
}
