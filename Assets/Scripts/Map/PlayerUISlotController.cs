using NUnit.Framework;
using TMPro;
using UnityEngine;

public class PlayerUISlotController : MonoBehaviour
{
    [SerializeField] int playerNumber = 1;
    bool active = true;
    [SerializeField] GameObject hasPlayer, noPlayer;
    [SerializeField] TMP_Text playerName;
    [SerializeField] Camera playerCamera;
    [SerializeField] bool changeIf3Players = false;

    const float rectWidthFor2Players = .48f, rectHeightFor2Players = .98f;
    const float rectWidthFor3Players = .98f, rectHeightFor3Players = .48f;

    public void ChangeState(bool newState, int playerCount)
    {
        active = newState;
        UpdateSlot(playerCount);
    }

    void UpdateSlot(int playerCount)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Rect rect = rectTransform.rect;

        Rect cameraRect = playerCamera.rect;
        if (playerCount == 2)
        {
            cameraRect = new Rect(cameraRect.x, 0.01f, rectWidthFor2Players, rectHeightFor2Players);
            playerCamera.rect = cameraRect;
        }
        else if (playerCount == 3 && changeIf3Players)
        {
            cameraRect = new Rect(.01f, 0.01f, rectWidthFor3Players, rectHeightFor3Players);
            playerCamera.rect = cameraRect;

            int screenWidth = Screen.currentResolution.width;
            int screenHeight = Screen.currentResolution.height;

            rectTransform.position = new Vector2(0.01f * screenWidth, 0.49f * screenHeight);
            rectTransform.sizeDelta = new Vector2(rectWidthFor3Players * screenWidth, rectHeightFor3Players * screenHeight);
        }

        hasPlayer.SetActive(active);
        noPlayer.SetActive(false);
        playerName.text = PlayerPrefs.GetString($"Player{playerNumber}Name", $"NoName {playerNumber}");
    }
}
