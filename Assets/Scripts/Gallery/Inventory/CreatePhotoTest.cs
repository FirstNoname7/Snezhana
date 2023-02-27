using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePhotoTest : MonoBehaviour
{
    [SerializeField] Photos photoToAdd;
    [SerializeField] Photos photoToAdd2;
    [SerializeField] Photos photoToAdd3;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Gallery.instance.AddPhotos(photoToAdd);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Gallery.instance.AddPhotos(photoToAdd2);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Gallery.instance.AddPhotos(photoToAdd3);
        }

    }
}
