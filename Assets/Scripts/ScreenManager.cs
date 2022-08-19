using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private void Update()
    {
        ChangeGameSize();
    }

    private void ChangeGameSize()
    {
        float width = Screen.width;
        float height = Screen.height;
        float widthRatio = transform.localScale.x / width;
        float heightRatio = transform.localScale.y / height;
        float ratio = Mathf.Min(widthRatio, heightRatio);

        transform.localScale = new Vector3(width * ratio, height * ratio, 1);
    }
}
