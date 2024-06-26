﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// T is any class that can be added to Generic Singleton
public class GenericSingleton<T> : MonoBehaviour where T : Component {
	
	private static T instance;

	public static T Instance 
	{
		get 
		{
			if (instance == null) 
			{
				instance = FindObjectOfType<T>();
				
				if (instance == null) 
				{
					GameObject obj = new GameObject();
					obj.name = typeof(T).Name;
					instance = obj.AddComponent<T>();
				}
			}

			return instance;
		}
	}

	public virtual void OnDestroy ()
	{
		if (instance == this)
		{ 
			instance = null;
		}
	}
}

// T is any class that can be added to Generic Singleton
public class GenericSingletonPersistent<T> : MonoBehaviour where T : Component
{

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    // For persistent, remeber to use base.Awake and override
    public virtual void Awake()
    {
        if (instance == null)
        { 
            instance = this as T;

            if (transform.parent != null)
            {
                DontDestroyOnLoad(transform.parent.gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}