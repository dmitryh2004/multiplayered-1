using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    /*
     -1 - не запущена
     0 - запущена
     1 - закончена
     */
    int gameStatus = -1;

    [SerializeField] List<PlayerController> players = new();
    [SerializeField] Animator startCanvasAnimator;
    [SerializeField] EndGameCanvasController endGameCanvas;
    [SerializeField] AudioSource bgMusic, startCountdown, victorySound;
    [SerializeField] PlayerUIController uiController;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        bool player3Active = PlayerPrefs.GetInt("Player3Active", 0) > 0;
        bool player4Active = PlayerPrefs.GetInt("Player4Active", 0) > 0;

        if (!player3Active)
        {
            players[2].gameObject.SetActive(false);
        }
        if (!player4Active)
        {
            players[3].gameObject.SetActive(false);
        }

        for (int i = 0; i < players.Count; i++)
        {
            PlayerController pc = players[i];
            uiController.ChangeSlotState(i, pc.gameObject.activeInHierarchy);
        }

        endGameCanvas.HideCanvas();
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        startCanvasAnimator.SetTrigger("Play");
        startCountdown.Play();

        yield return new WaitForSeconds(3f);
        
        gameStatus = 0;

        for (int i = 0; i < players.Count; i++)
        {
            PlayerController pc = players[i];
            if (pc.gameObject.activeInHierarchy)
                pc.Activate();
        }

        bgMusic.Play();
    }

    public void EndGame(int winner)
    {
        gameStatus = 1;
        bgMusic.Stop();
        victorySound.Play();
        endGameCanvas.UpdateText(winner);
        endGameCanvas.ShowCanvas();
    }
}
