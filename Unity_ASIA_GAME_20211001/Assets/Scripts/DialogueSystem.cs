using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DialogueSystem : MonoBehaviour
{
    [Header("ｹ・ﾜｶ｡ｹj"), Range(0, 1)]
    public float interval = 0.3f;
    [Header("畫布對話系統")]
    public GameObject goDialogue;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話完成圖示")]
    public GameObject goTip;
    [Header("對話案件")]
    public KeyCode keyDialogue = KeyCode.Mouse0;

    private void Start()
    {
        //StartCoroutine(TypeEffect());
    }
    private IEnumerator TypeEffect(string[] contents)
    {
        //string test1 = "哈摟，你好~";
        //string test2 = "第二段對話顯示";
        //string[] test = { test1, test2 };

        goDialogue.SetActive(true);

        for (int j = 0; j < contents.Length; j++)
        {
            textContent.text = "";
            goTip.SetActive(false);

            for (int i = 0; i < contents[j].Length; i++)
            {
                textContent.text += contents[j][i];
                yield return new WaitForSeconds(interval);
            }
        }

        goTip.SetActive(true);

        while (!Input.GetKeyDown(keyDialogue))
        {
            yield return null;
        }


        //goDialogue.SetActive(true);
        goDialogue.SetActive(false);


    }

}
