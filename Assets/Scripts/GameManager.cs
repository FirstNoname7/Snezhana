using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator animator;
    int indexScene;
    public static GameManager instance;
    public List<Photos> beginPhotos = new List<Photos>();

    private void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //public void ChangeAnimation(int indexAnimation)
    //{
    //    Animation(indexScene, indexAnimation);
    //}

    //public IEnumerator ryrhyr(int indexAnimation)
    //{
    //    animator.SetInteger("DissolveOut", indexAnimation);
    //    ChangeScene();

    //}

    public void Animation(int index, int indexAnimation) //анимация перехода на другую сцену
    {
        indexScene = index;
        animator.SetInteger("DissolveOut", indexAnimation);
        //ChangeScene();
    }
    public void ChangeScene(int index) //переключение на другую сцену
    {
        //animator.SetInteger("DissolveOut", 1);
        SceneManager.LoadScene(index);
    }

    public void ChangeSceneButton(int index)
    {
        SceneManager.LoadScene(index);
    }
}
