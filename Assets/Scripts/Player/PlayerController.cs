using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int playerNumber = 1;
    [SerializeField] TMP_Text playerName;

    [SerializeField] float playerSpeed = 4f;

    [SerializeField] bool active = false;
    PlayerControls controls;
    Rigidbody2D rb;

    public int GetPlayerNumber() => playerNumber;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();
    }

    private void Start()
    {
        playerName.text = PlayerPrefs.GetString($"Player{playerNumber}Name", $"NoName {playerNumber}");
    }

    public void Activate() 
    { 
        active = true;
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        if (!active) return;

        InputAction usedInputAction = controls.Gameplay.Player1;
        if (playerNumber == 2) usedInputAction = controls.Gameplay.Player2;
        else if (playerNumber == 3) usedInputAction = controls.Gameplay.Player3;
        else if (playerNumber == 4) usedInputAction = controls.Gameplay.Player4;

        rb.linearVelocity = playerSpeed * usedInputAction.ReadValue<Vector2>();
    }
}
