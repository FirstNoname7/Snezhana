using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IGallery : MonoBehaviour
{
    [SerializeField] Gallery targetGallery;
    [SerializeField] RectTransform photosPanel;
    [SerializeField] Text textStack;

    readonly List<GameObject> drawnIcons = new List<GameObject>();

    void Start()
    {
        targetGallery.onItemAdded += OnItemAdded;
        Redraw();
    }

    void OnItemAdded(Photos obj) => Redraw(); //��� ���������� ��������� (��������� 4 �������):
    //void OnItemAdded(Photos obj)
    //{
    //    Redraw();
    //}
    void Redraw()
    {
        ClearDrawn();

        for(int i = 0; i < targetGallery.galleryPhotos.Count; i++)
        {
            var item = targetGallery.galleryPhotos[i];
            var icon = new GameObject("������������"); //��� ����� ���������� ����������� �����������
            icon.AddComponent<Image>().sprite = item.icon; //���� ���������� �������, icon = ����������� �� ������� ScriptableObject

            icon.transform.SetParent(photosPanel); //�������� ����� ����������� ������ � ������ photosPanel

            //icon.AddComponent<Text>().text = item.amount.ToString(); //������� �������� ��������� Text. �� ���������, �.�. � ������� ��������� ��������� Image,
            //� Image � Text � ����� ������� �� ����� ���������� ��� ���������

            drawnIcons.Add(icon);
        }
    }

    void ClearDrawn()
    {
        for(int i = 0; i < drawnIcons.Count; i++)
        {
            Destroy(drawnIcons[i]);
        }

        drawnIcons.Clear();
    }
}
