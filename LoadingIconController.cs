using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingIconController : MonoBehaviour
{
    public float rotationSpeed = 2.5f;
    RectTransform rect;

    void OnEnable()
    {
        rect = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rect)
        {
            rect.localEulerAngles = new Vector3(rect.localEulerAngles.x, rect.localEulerAngles.y, rect.localEulerAngles.z - rotationSpeed);
        }
    }
}
