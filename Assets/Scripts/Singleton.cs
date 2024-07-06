using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected virtual bool DestroyTargetGameObject => false;

    public static T I { get; private set; } = null;

    // Singleton���L����
    public static bool IsValid() => I != null;

    private void Awake()
    {
        if (I == null)
        {
            I = this as T;
            I.Init();
        }
        else
        {
            if (DestroyTargetGameObject)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
    }

    private void OnDestroy()
    {
        if (I == this)
        {
            I = null;
            OnRelease();
        }
    }

    // �h���N���X�p�̏��������\�b�h
    protected virtual void Init()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // �h���N���X�p��OnDestroy
    protected virtual void OnRelease()
    {
    }

    // Singleton�̍Đ������\�b�h
    public static void RecreateInstance()
    {
        if (I != null)
        {
            Destroy(I.gameObject);
        }

        // �V�����C���X�^���X�𐶐�����
        GameObject newGameObject = new GameObject(typeof(T).Name);
        I = newGameObject.AddComponent<T>();
        I.Init();
    }
}
