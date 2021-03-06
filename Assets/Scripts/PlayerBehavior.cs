using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float gravityValue;
    private bool groundedPlayer;
    private Vector3 playerVelocity;

    [Header("Inventory")]
    [SerializeField]
    private int gold;

    [Header("Components")]
    public TMP_Text playerNameText;
    public TMP_Text goldText;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        string name = "PlayerName";
        if (GameManager.Instance != null) {
            name = GameManager.Instance.playerName;
        }
        playerNameText.text = name;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void AddGold(int amount)
    {
        gold += amount;
        goldText.text = gold.ToString();
    }
}
