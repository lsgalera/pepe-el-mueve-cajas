using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //No me sirve para esto
    //enum RayList { Forward, Right, Back, Left }

    [SerializeField] float distance = 1f;

    Ray rayF, rayR, rayB, rayL;
    Ray[] rayList = new Ray[4];
    RaycastHit hit;

    Vector3 targetPosition;
    float xInput = 0, zInput = 0;
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

        //VOY A HACERLO DE 2 FORMAS, UNA CALCULANDO LA POSICION Y MOSTRANDOLO CON GIZMOS
        //Y LA OTRA ES USANDO RAYOS
        if(xInput != 0f || zInput != 0)
        {
            CalculateTargetPosition();
        }

        //CreateRays();

  
        rayF = new Ray(capsule.position, capsule.forward);
        rayR = new Ray(capsule.position, capsule.right);
        rayB = new Ray(capsule.position, -capsule.forward);
        rayL = new Ray(capsule.position, -capsule.right);

        Debug.DrawRay(rayF.origin, rayF.direction * distance, Color.green);
        Debug.DrawRay(rayR.origin, rayR.direction * distance, Color.blue);
        Debug.DrawRay(rayB.origin, rayB.direction * distance, Color.red);
        Debug.DrawRay(rayL.origin, rayL.direction * distance, Color.cyan);

        if (Physics.Raycast(rayF, out hit, distance)){
            Debug.DrawRay(rayF.origin, rayF.direction * distance, Color.black);
            Debug.Log(hit.transform.name);
        }
        if (Physics.Raycast(rayR, out hit, distance))
        {
            Debug.DrawRay(rayR.origin, rayR.direction * distance, Color.black);
            Debug.Log(hit.transform.name);
        }
        if (Physics.Raycast(rayB, out hit, distance))
        {
            Debug.DrawRay(rayB.origin, rayB.direction * distance, Color.black);
            Debug.Log(hit.transform.name);
        }
        if (Physics.Raycast(rayL, out hit, distance))
        {
            Debug.DrawRay(rayL.origin, rayL.direction * distance, Color.black);
            Debug.Log(hit.transform.name);
        }

        Move();

        //CheckArown(rayList, hit);

        //Singleton_UI_Manager.Instance.SetText(newText);
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.back);
            rotateCharacter(180);

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward);
            rotateCharacter(0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left);
            rotateCharacter(270);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right);
            rotateCharacter(90);
        }
    }





    //PARA REVISAR LO QUE HAY AL REDEDOR
    string CheckArown(Ray[] _rayList, RaycastHit _hit)
    {
        string newText;
        /*
        foreach(Ray ray in rayList)
        {

        }*/

        Ray ray = _rayList[0];
        if (Physics.Raycast(ray, out _hit, distance))
        {
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.blue);
            //Debug.Log("Distancia:" + hit.distance);
            //Debug.Log("Punto de impacto:" + hit.point);
            //Debug.Log(hit.transform.name);

            newText = $"name: {_hit.transform.name}";

        }
        else
        {
            newText = $"No hay nada";
        }

        return newText;
    }

    //SOLO ES PARA VER LOS RAYOS
    void CreateRays()
    {
        //VER COMO CARAJOS HACER ESTO MEJOR
        /*Vector3 origin = capsule.position + new Vector3(0, 0.5f, 0);
        rayF = new Ray(origin, capsule.forward);
        rayR = new Ray(origin, capsule.right);
        rayB = new Ray(origin, -capsule.forward);
        rayL = new Ray(origin, -capsule.right);
        rayList[0] = rayF;
        rayList[1] = rayR;
        rayList[2] = rayB;
        rayList[3] = rayL;*/

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



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetPosition, 0.5f);
    }


    void rotateCharacter(int angle)
    {

        capsule.localRotation = Quaternion.Euler(0, angle, 0);
    }

}
