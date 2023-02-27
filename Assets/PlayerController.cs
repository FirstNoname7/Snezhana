using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera; //�����, ����� �� ����� ������� �� ������� �����
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
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit)) //out hit - ��������� ��, ��� ������ �� �����, � ���������� hit 
            {
                agent.SetDestination(hit.point); //SetDestination - ������ ����� ���������� (���� �������, ���� ���� � ���)
            } 
        }
        if (Input.GetKeyDown(KeyCode.I)&&item)
        {
            Gallery.instance.AddPhotos(photoToAdd);
            Debug.Log("������� ��������");
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
