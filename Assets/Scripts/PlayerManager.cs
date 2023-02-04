using UnityEngine;
using Unity.Netcode;

public class PlayerManager : NetworkBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private void Update() {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.Space)) {
            TestServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void TestServerRpc() {
        Debug.Log("Test Server Rpc" + OwnerClientId);

        if (OwnerClientId == 0) {
            GameObject newPlayer1 = Instantiate(player1);
            newPlayer1.GetComponent<NetworkObject>().SpawnWithOwnership(OwnerClientId);
        } else if (OwnerClientId == 1) {
            GameObject newPlayer2 = Instantiate(player2);
            newPlayer2.GetComponent<NetworkObject>().SpawnWithOwnership(OwnerClientId);
        }
    }
}
