using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private NetworkObject networkObject;

   // private bool IsHost => networkObject.IsServer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        networkObject = GetComponent<NetworkObject>();
    }

    void Start()
    {
        Debug.Log($"Soy el jugador {networkObject.NetworkObjectId} {(IsHost ? "(Host)" : "(Cliente)")}");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
    }
}

