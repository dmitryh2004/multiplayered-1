using UnityEngine;

public class OpenWebPage : MonoBehaviour
{
    [SerializeField] string url = "https://example.com";
    public void OpenPage()
    {
        Application.OpenURL(url);
    }
}