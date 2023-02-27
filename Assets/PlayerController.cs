using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera; //нужна, чтобы мы могли кликать по видимым зонам
    private NavMeshAgent agent;

    private bool item;
    [SerializeField] Photos photoToAdd;


    void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit)) //out hit - сохраняем всё, что писали до этого, в переменную hit 
            {
                agent.SetDestination(hit.point); //SetDestination - создаёт точку назначения (куда тыкнули, туда перс и идёт)
            } 
        }
        if (Input.GetKeyDown(KeyCode.I)&&item)
        {
            Gallery.instance.AddPhotos(photoToAdd);
            Debug.Log("Элемент добавлен");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            item = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        item = false;
    }
}
