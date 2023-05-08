
using Unity.Netcode;
using UnityEngine;

namespace Moverse 
{
    public class MoverseAlPulsar : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Move();
            }
        }

        public void Move()
        {
            if (NetworkManager.Singleton.IsServer)
            {
               // var randomPosition = GetRandomPositionOnPlane();

                var izquierdaPosition = GetLeftPositionOnPlane();

               /* transform.position = randomPosition;
                Position.Value = randomPosition; */

                transform.position = izquierdaPosition;
                Position.Value = izquierdaPosition;
            }
            else
            {
                SubmitPositionRequestServerRpc();
            }
        }

        [ServerRpc]
        void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        {
           // Position.Value = GetRandomPositionOnPlane();
            Position.Value = GetLeftPositionOnPlane();
        }

      /*  static Vector3 GetRandomPositionOnPlane()
        {
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 0f));
            
        } */

        static Vector3 GetLeftPositionOnPlane(){
            return new Vector3(Random.Range(-3f, 0f), 1f, Random.Range(-3f, 0f));
        }

        void Update()
        {
            transform.position = Position.Value;
        }
    }
}