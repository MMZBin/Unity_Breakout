using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    void Start()
    {
        // Image�R���|�[�l���g���擾���A�摜�Ɠ����x��ݒ�
        Image image = GetComponent<Image>();

        // RectTransform���擾���A��ʑS�̂ɍL����
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.anchoredPosition = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(0, 0);
    }
}
