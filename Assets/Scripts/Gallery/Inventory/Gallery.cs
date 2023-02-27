using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallery : MonoBehaviour
{
    private Photos photos;
    public Action<Photos> onItemAdded;
    [SerializeField] List<Photos> beginPhotos = new List<Photos>();
    public List<Photos> galleryPhotos { get; private set; }
    public bool IsStackable = true;
    public static Gallery instance;

    public Photos test;
    void Awake() //����� �������� � Awake, ��� ��� ����� ��������, ������� ��������� �� ������, � ����� ��-�� ����� ���� ������
    {
        galleryPhotos = new List<Photos>();
        for (int i = 0; i < beginPhotos.Count; i++)
        {
            AddPhotos(beginPhotos[i]);
        }

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void AddPhotos(Photos photos)
    {
        //��������: ������������ ������ 1 ������� � �������
        //if (IsStackable)
        //{
        //}
        //foreach (Photos photo in galleryPhotos) //���� ������� �������� ��� ���� � �������, �����:
        //{
        //    photos.amount += 1; //������� ��� ������������ ��������
        //    return; //������������ �������, ���� �������� �� ������� ��� �� �������� � ������ �����
        //}

        //� �������� ������:

        galleryPhotos.Add(photos);
        onItemAdded?.Invoke(photos);
        test = photos;
    }
}
