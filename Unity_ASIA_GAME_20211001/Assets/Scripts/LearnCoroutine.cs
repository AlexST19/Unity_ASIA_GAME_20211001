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
        print("�o�O�Ĥ@�q��r�T��");
        yield return new WaitForSeconds(1);
        print("�o�O�ĤG�q��r�T��");
        yield return new WaitForSeconds(3);
        print("�o�O�T����");
    }
    private IEnumerator TestWithLoop()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(.5f);
            print("�Ʀr:" + i);
        }
    }
}
