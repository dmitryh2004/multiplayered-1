using UnityEngine;

public class FinishController : MonoBehaviour
{
    bool active = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active) return;
        active = false;
        PlayerController player;
        if (collision.TryGetComponent<PlayerController>(out player))
        {
            int playerNumber = player.GetPlayerNumber();
            GameManager.Instance.EndGame(winner: playerNumber);
        }
    }
}
