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

    void OnItemAdded(Photos obj) => Redraw(); //это сокращение выражения (следующие 4 строчки):
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
            var icon = new GameObject("Изображенька"); //как будут называться добавленные изображения
            icon.AddComponent<Image>().sprite = item.icon; //само добавление спрайта, icon = изображение из скрипта ScriptableObject

            icon.transform.SetParent(photosPanel); //предметы будут добавляться именно в объект photosPanel

            //icon.AddComponent<Text>().text = item.amount.ToString(); //попытка добавить компонент Text. Не фортануло, т.к. у объекта добавляем компонент Image,
            //а Image с Text в одном объекте не могут находиться как оказалось

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
