
using Unity.Netcode;
using UnityEngine;

namespace HelloWorld
{
    public class HelloWorldPlayer : NetworkBehaviour
    {
        private static int instancesCount = 0;

        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Move();
                Debug.Log("Player spawned with NetworkId: " + NetworkObjectId);
                
                HelloWorldPlayer[] players = Object.FindObjectsOfType<HelloWorldPlayer>();
                Debug.Log("Número de instancias de HelloWorldPlayer: " + players.Length);
            }
        }

        public void Move()
        {
            if (NetworkManager.Singleton.IsServer)
            {
                var randomPosition = GetRandomPositionOnPlane();
                transform.position = randomPosition;
                Position.Value = randomPosition;

                instancesCount++;
                Debug.Log($"Se ha creado una instancia de MyClass. Total de instancias: {instancesCount}");
            }
            else
            {
                SubmitPositionRequestServerRpc();
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

        void Start()
    {
        //Debug.Log("Soy " + (IsHost ? "el anfitrión" : "un cliente"));
       // Debug.Log($"Soy el jugador {networkObject.NetworkObjectId} {(IsHost ? "(anfitrión)" : "(cliente)")}");
    }

        void Update()
        {
            transform.position = Position.Value;
        }
    }
}