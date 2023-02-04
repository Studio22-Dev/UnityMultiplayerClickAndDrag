using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Netcode;

public class MenuButtonControl : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private void Awake() {
        hostButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        });

        clientButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        });
    }
}
