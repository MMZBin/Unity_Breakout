using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Main
{
    //è∞Ç…çáÇÌÇπÇƒï«ÇîzíuÇ∑ÇÈ
    public class Wall : MonoBehaviour
    {
        private void Awake()
        {
            GameObject bottom = _box.transform.Find("Bottom").gameObject;
            GameObject top = _box.transform.Find("Top").gameObject;
            GameObject left = _box.transform.Find("Left").gameObject;
            GameObject right = _box.transform.Find("Right").gameObject;
            GameObject floor = _box.transform.Find("Floor").gameObject;

            if (!bottom || !top || !left || !right || !floor)
            {
                Debug.LogError("One of the 'GameObject' objects named 'Bottom', 'Top', 'Left', 'Right', or 'Floor' does not exist in the specified object.");
                return;
            }

            Vector3 floorScale = floor.transform.localScale;

            Vector3 verticalScale = new(floorScale.x, 1, 0.2f);
            Vector3 horizontalScale = new(0.2f, 1, floorScale.z);

            bottom.transform.position = new(0, 0.5f, floorScale.z / 2);
            top.transform.position = new(0, 0.5f, floorScale.z / 2 * -1);
            left.transform.position = new(floorScale.x / 2, 0.5f, 0);
            right.transform.position = new(floorScale.x / 2 * -1, 0.5f, 0);

            bottom.transform.localScale = verticalScale;
            top.transform.localScale = verticalScale;
            left.transform.localScale = horizontalScale;
            right.transform.localScale = horizontalScale;
        }

        [SerializeField] GameObject _box;
    }
}
