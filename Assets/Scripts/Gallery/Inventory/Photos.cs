using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPhotoGallery", menuName = "Снежа/Галерея")]
public class Photos : ScriptableObject
{
    public string name = "Item";
    public Sprite icon;
    public int amount; //сколько элементов в инвентаре/галереи (чтобы можно было стакать)
}
