using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    void Start()
    {
        // Imageコンポーネントを取得し、画像と透明度を設定
        Image image = GetComponent<Image>();

        // RectTransformを取得し、画面全体に広げる
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.anchoredPosition = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(0, 0);
    }
}
