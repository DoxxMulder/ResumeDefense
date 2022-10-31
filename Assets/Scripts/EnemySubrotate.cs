using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySubrotate : MonoBehaviour
{
    public Transform partToRotate;
    public float lerpDuration;
    private bool rotating = false;


    // Rotate 90 degrees indefinitely
    void Update()
    {
        if (rotating)
        {
            return;
        }
        StartCoroutine(Rotate90());
    }

    IEnumerator Rotate90()
    {
        rotating = true;
        float timeElapsed = 0f;
        Quaternion startRotation = partToRotate.rotation;
        Quaternion targetRotation = partToRotate.rotation * Quaternion.Euler(0, 0, 90);
        while (timeElapsed < lerpDuration)
        {
            partToRotate.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        partToRotate.rotation = targetRotation;
        rotating = false;
    }
}
