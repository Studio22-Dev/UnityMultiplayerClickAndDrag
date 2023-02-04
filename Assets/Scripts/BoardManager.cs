using UnityEngine;
using Unity.Netcode;

public class BoardManager : MonoBehaviour
{
    [SerializeField] GameObject playerManager;

    private void Awake() {
        GameObject newPlayerManager = Instantiate(playerManager, Vector3.zero, Quaternion.identity);
        newPlayerManager.GetComponent<NetworkObject>().Spawn(true);
    }
}
