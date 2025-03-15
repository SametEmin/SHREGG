using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button button;
    public GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(() => panel.SetActive(!panel.activeSelf));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
