using UnityEngine;
using System.Collections;

public class LearnCoroutine : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Test());
        StartCoroutine(TestWithLoop());
    }
    private IEnumerator Test()
    {
        print("這是第一段文字訊息");
        yield return new WaitForSeconds(1);
        print("這是第二段文字訊息");
        yield return new WaitForSeconds(3);
        print("這是三紆鉡");
    }
    private IEnumerator TestWithLoop()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(.5f);
            print("數字:" + i);
        }
    }
}
