using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//建立專案?的選單(menuName = "選單名稱") 資料夾/子資料
[CreateAssetMenu(menuName = "Alex/對話資料")]
public class DataDialogue : ScriptableObject
{
    [Header("對話內容"), TextArea(3, 5)]
    public string[] dialogues;
}
