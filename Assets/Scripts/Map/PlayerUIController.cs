using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] List<PlayerUISlotController> playerSlots = new();

    public void ChangeSlotState(int slot, bool state, int playerCount)
    {
        playerSlots[slot].ChangeState(state, playerCount);
    }
}
