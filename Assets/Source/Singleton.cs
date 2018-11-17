using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                }
            }
            return instance;
        }
    }

    void CheckInstance(T thisInstance)
    {
        if (instance == null)
        {
            instance = thisInstance;
        }
        else if (instance != thisInstance)
        {
            DestroyImmediate(thisInstance);
        }
    }

    protected void Awake()
    {
        CheckInstance(this as T);
        Initiate();
    }

    protected virtual void Initiate() { }

}