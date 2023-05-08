using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Muevete : NetworkBehaviour
{
    public float velocidad = 1f;

    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    public override void OnNetworkSpawn(){
        if (IsOwner)
        {
            Move();
        }
    }

    //Mover a la izquierda al pulsar una tecla
    public void Move(){
        if(NetworkManager.Singleton.IsServer){
            if (Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(Vector3.up * velocidad * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            }if (Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(Vector3.left * velocidad * Time.deltaTime);
            } if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            }
        }

        [ServerRpc]
        void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = GetRandomPositionOnPlane();
        }

        static Vector3 GetRandomPositionOnPlane()
        {
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        }




    // Update is called once per frame
    void Update()
    {
        transform.position = Position.Value;
    }
}
