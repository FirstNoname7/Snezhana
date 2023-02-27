using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPhotoGallery", menuName = "�����/�������")]
public class Photos : ScriptableObject
{
    public string name = "Item";
    public Sprite icon;
    public int amount; //������� ��������� � ���������/������� (����� ����� ���� �������)
}
