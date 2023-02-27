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
    void Awake() //нужно выводить в Awake, так как естьь элементы, которые выводятся до старта, и может из-за этого быть ошибка
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
        //проблема: показывается только 1 элемент в галерее
        //if (IsStackable)
        //{
        //}
        //foreach (Photos photo in galleryPhotos) //если текущая картинка уже есть в галерее, тогда:
        //{
        //    photos.amount += 1; //стакаем уже существующую картинку
        //    return; //возвращаемся обратно, чтоб случайно не создать эту же картинку в другом слоте
        //}

        //в обратном случае:

        galleryPhotos.Add(photos);
        onItemAdded?.Invoke(photos);
        test = photos;
    }
}
