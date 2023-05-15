using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal_Controller : MonoBehaviour
{
    MeshRenderer meshRebderer;
    /*float distance = 1f;

    void Update()
    {
        Ray ray = new Ray(transform.position , transform.up);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.blue);

        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            if (hit.transform.CompareTag("Box"))
            {
                GetComponent<MeshRenderer>().material.color = Color.red;
                Singleton_UI_Manager.Instance.UpdateGoalCounterUI(1, 2);
            }

        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.cyan;
            //Singleton_Game_Manager.Instance.UpdateGoal(-1);
        }

    }*/

    private void Start()
    {
        meshRebderer = transform.parent.GetChild(2).GetComponent<MeshRenderer>();

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Box"))
        {
            Singleton_Game_Manager.Instance.UpdateGoal(1);
            meshRebderer.material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Box"))
        {
            Singleton_Game_Manager.Instance.UpdateGoal(-1);
            meshRebderer.material.color = Color.cyan;
        }
    }

}
