using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class networkUi : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    void Start()
    {
        Debug.Log(hostButton == null ? "Host button is NULL!" : "Host button OK");
        Debug.Log(clientButton == null ? "Client button is NULL!" : "Client button OK");
    }


    void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        clientButton.onClick.AddListener(() =>{
            NetworkManager.Singleton.StartClient();
        });
    }
}
