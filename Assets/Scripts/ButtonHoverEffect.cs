using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour
{
    public Button button;
    public Color hoverColor = Color.green;  // Hoverda değişecek renk
    private Color originalColor;

    private RectTransform rectTransform; // Butonun RectTransform component'i
    private Vector3 originalScale; // Butonun orijinal boyutu
    public Vector3 hoverScale = new Vector3(3f, 3f, 3f);

    void Start()
    {
        // Orijinal renk değerini kaydet
        originalColor = button.GetComponent<Image>().color;
        Debug.Log("Çalışıyor");
        rectTransform = GetComponent<RectTransform>();  // Butonun RectTransform component'ini al
        originalScale = rectTransform.localScale; 
    }

    // Hover üzerine gelince renk değiştir
    public void OnHoverEnter()
    {
        rectTransform.localScale = hoverScale;
    }

    // Fare ayrıldığında eski rengine dön
    public void OnHoverExit()
    {
        rectTransform.localScale = originalScale;
    }
}
