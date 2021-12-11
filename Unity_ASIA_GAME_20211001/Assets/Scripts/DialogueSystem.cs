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

    private void Start()
    {
        StartCoroutine(TypeEffect());
    }
    private IEnumerator TypeEffect()
    {
        string test = "哈摟，你好~";

        goDialogue.SetActive(true);

        for (int i = 0; i < test.Length; i++)
        {
            textContent.text += test[i];
            yield return new WaitForSeconds(interval);
        }
    }
}
