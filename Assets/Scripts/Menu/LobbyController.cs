using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    bool player3Active, player4Active;
    string player1Name, player2Name, player3Name, player4Name;

    [SerializeField] Toggle player3Toggle, player4Toggle;
    [SerializeField] TMP_InputField player1InputField, player2InputField, player3InputField, player4InputField;

    void UpdateLayout()
    {
        player3InputField.gameObject.SetActive(player3Active);
        player4InputField.gameObject.SetActive(player4Active);

        player1InputField.text = player1Name;
        player2InputField.text = player2Name;
        player3InputField.text = player3Name;
        player4InputField.text = player4Name;
    }
    private void Start()
    {
        player3Active = PlayerPrefs.GetInt("Player3Active", 0) > 0;
        player4Active = PlayerPrefs.GetInt("Player4Active", 0) > 0;

        player3Toggle.isOn = player3Active;
        player4Toggle.isOn = player4Active;

        player1Name = PlayerPrefs.GetString("Player1Name", "Noname 1");
        player2Name = PlayerPrefs.GetString("Player2Name", "Noname 2");
        player3Name = PlayerPrefs.GetString("Player3Name", "Noname 3");
        player4Name = PlayerPrefs.GetString("Player4Name", "Noname 4");

        UpdateLayout();
    }
    public void OnPlayer3Toggled(bool newState)
    {
        player3Active = newState;

        UpdateLayout();
    }
    public void OnPlayer4Toggled(bool newState)
    {
        player4Active = newState;

        UpdateLayout();
    }
    public void OnPlayer1NameChanged(string newName)
    {
        player1Name = newName;

        UpdateLayout();
    }
    public void OnPlayer2NameChanged(string newName)
    {
        player2Name = newName;

        UpdateLayout();
    }
    public void OnPlayer3NameChanged(string newName)
    {
        player3Name = newName;

        UpdateLayout();
    }
    public void OnPlayer4NameChanged(string newName)
    {
        player4Name = newName;

        UpdateLayout();
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("Player3Active", player3Active ? 1 : 0);
        PlayerPrefs.SetInt("Player4Active", player4Active ? 1 : 0);

        PlayerPrefs.SetString("Player1Name", player1Name);
        PlayerPrefs.SetString("Player2Name", player2Name);
        PlayerPrefs.SetString("Player3Name", player3Name);
        PlayerPrefs.SetString("Player4Name", player4Name);

        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Exit.ExitGame();
    }
}
