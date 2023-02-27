using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Galleryy : MonoBehaviour
{
    //List<Sprite> allPhotoGallery;
    //public GameObject photo;
    //void Start() 
    //{
    //    //PhotoGallery(); 
    //    if (PersistenceManager.Instance != null) 
    //    {
    //        PersistenceManager.Instance.Load(); 
    //    }
    //}

    //private void PhotoGallery() //выводим рекорд в меню
    //{
    //    //photo = PersistenceManager.Instance.panelGallery;
    //}
    //public List<Sprite> newSprite()
    //{
    //    return allPhotoGallery;
    //}
    [SerializeField] GameObject smallPicture;
    [SerializeField] Transform picturePanel;
    private void Start()
    {
        Sprite[] pictures = Resources.LoadAll<Sprite>("Art/");
        for(int i = 0; i < pictures.Length; i++)
        {
            GameObject clone = Instantiate(smallPicture);
            clone.GetComponentInChildren<Image>().sprite = pictures[i];
            clone.transform.SetParent(picturePanel);
        }
    }
}
