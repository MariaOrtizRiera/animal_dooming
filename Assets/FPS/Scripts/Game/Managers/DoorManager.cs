using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;

public class DoorManager : MonoBehaviour
{
    Vector3 positionToMoveTo;
    void Start()
    {
        positionToMoveTo = 
            new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
    }
    public void OpenDoor(float duration)
    {
        StartCoroutine(LerpPosition(positionToMoveTo, duration));
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
