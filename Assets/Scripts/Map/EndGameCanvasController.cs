using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCanvasController : MonoBehaviour
{
    [SerializeField] TMP_Text whoWon;
    [SerializeField] Animator animator;

    public void UpdateText(int winner)
    {
        string key = $"Player{winner}Name";
        Debug.Log(key);
        whoWon.SetText($"Победитель: {PlayerPrefs.GetString(key, "NoName")} (игрок {winner})");
    }

    public void ShowCanvas()
    {
        animator.SetBool("visible", true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCanvas()
    {
        animator.SetBool("visible", false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Exit.ExitGame();
    }
}
