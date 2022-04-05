using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{ 
    // 하위 자식을 찾습니다. UnityEngine.Object만 찾아주도록 합니다.
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if( go == null)
        {
            return null;
        }

        if( recursive == false)
        {   // 직속으로 내 하위 자식만 찾습니다.
            for( int i = 0; i < go.transform.childCount; i++ )
            {
                Transform transform = go.transform.GetChild(i);

                if( string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();

                    if( component != null)
                    {
                        return component;
                    }
                }
            }
            
        }
        else
        {   // 재귀로 하위 자식들을 찾습니다.
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                if(string.IsNullOrEmpty(name) || component.name == name)
                {
                    return component;
                }
            }
        }

        return null;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if( transform == null )
        {
            return null;
        }

        return transform.gameObject;
    }

    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();

        if (component == null)
        {   // 없다면 붙여줍니다.
            component = go.AddComponent<T>();
        }

        return component;
    }
}
