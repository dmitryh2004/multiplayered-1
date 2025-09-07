using TMPro;
using UnityEngine;

public class PlayerUISlotController : MonoBehaviour
{
    [SerializeField] int playerNumber = 1;
    bool active = true;
    [SerializeField] GameObject hasPlayer, noPlayer;
    [SerializeField] TMP_Text playerName;
    public void ChangeState(bool newState)
    {
        active = newState;
        UpdateSlot();
    }

    void UpdateSlot()
    {
        hasPlayer.SetActive(active);
        noPlayer.SetActive(!active);
        playerName.text = PlayerPrefs.GetString($"Player{playerNumber}Name", $"NoName {playerNumber}");
    }
}
