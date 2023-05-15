using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box_Controller : MonoBehaviour
{
    bool isMoving = false;
    [SerializeField] float moveTime = 0.10f;
    public void Test(Vector3 direction)
    {
        //Debug.Log("ME MOVI, KAPPA");
        
        
        if(!isMoving) StartCoroutine(Move(direction));
        
    }

    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        float timeElapsed = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position - direction;

        while (timeElapsed < moveTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }
}
