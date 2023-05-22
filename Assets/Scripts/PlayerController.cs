using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    
    //Movimiento con setPosition, y el raycast para obtener el objeto de adelante
    //Consultar con Lucas como tirar muchos raycast jijiji

    //No me sirve para esto
    //enum RayList { Forward, Right, Back, Left }

    [SerializeField] float rayCastDistance = 1f;
    [SerializeField] float moveTime = 0.15f;
    [SerializeField] LayerMask layerToIgnore;

    float xInput = 0, zInput = 0;
    float radius = 0.5f;
    bool isMoving = false;
    public bool isThereACollider;

    Ray ray;
    Vector3 targetPosition;
    Transform capsule,eyes;


    private void Start()
    {
        capsule = transform.GetChild(0);
        eyes = capsule.GetChild(0);
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        if ((xInput != 0f || zInput != 0) && !isMoving)
        // si quisiera que solo se pueda mover al hacer al tocar una tecla y no mantener apretado
        //podria agregar otro a condicion que sea Input.anyKeyDown
        {
            CalculateTargetPosition();
            CreateRay(); //Aca calculo la colision
            if (!isThereACollider)
            {
                StartCoroutine(Move());
            }
        }
    }

    void CalculateTargetPosition()
    {
        if (xInput == 1)
        {
            targetPosition = capsule.position + Vector3.right;
            rotateCharacter(90);
        }
        if (xInput == -1)
        {
            targetPosition = capsule.position + Vector3.left;
            rotateCharacter(270);
        }
        if (zInput == 1)
        {
            targetPosition = capsule.position + Vector3.forward;
            rotateCharacter(0);
        }
        if (zInput == -1)
        {
            targetPosition = capsule.position + Vector3.back;
            rotateCharacter(180);
        }
    }

    IEnumerator Move()
    {
        isMoving = true;
        float timeElapsed = 0f;
        Vector3 startPosition = capsule.position;
        
        while(timeElapsed < moveTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        capsule.position = targetPosition;
        isMoving = false;
    }

    void rotateCharacter(int angle)
    {
        capsule.localRotation = Quaternion.Euler(0, angle, 0);
    }

    /*bool CanMoveToTargetPosition()
    {
        //Esto funcaria en 2D 
        //return !Physics2D.OverlapCircle(targetPosition, radius);
        

        return false;
    }*/
    

    void CreateRay()
    {
        ray = new Ray(capsule.position, capsule.forward);

        Debug.DrawRay(ray.origin, ray.direction * rayCastDistance, Color.green);

        if (Physics.Raycast(ray, out RaycastHit hit, rayCastDistance))
        {
            if (hit.transform.gameObject.CompareTag("Box"))
            {
                Box_Controller bc = hit.transform.parent.GetComponent<Box_Controller>();
                //bc.Test(targetPosition)
                bc.Test(hit.normal);
            }
            isThereACollider = true;
        }
        else
        {
            isThereACollider = false;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetPosition, radius);
    }

}
