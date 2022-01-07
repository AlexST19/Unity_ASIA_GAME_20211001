using UnityEngine;
using UnityEngine.Events;

public class PassSystem : MonoBehaviour
{
    public string nameTarget = "¤p®£Às";
    public UnityEvent onPass;

    private void OnTriggerEnter(Collider2D collision)
    {
        if (collision.name == nameTarget) onPass.Invoke();
    }

}
