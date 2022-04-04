using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // �ֻ��� ������
    static Managers s_instance; // ���ϼ��� ����ȴ�.
    static Managers Instance
    { 
        get 
        { 
            Init();
            return s_instance; 
        } 
    }  // ������ �Ŵ����� ����´�.

    // �Է� �Ŵ���
    InputManager _input = new InputManager();
    public static InputManager Input
    { 
        get
        {
            return Instance._input;
        }
    }

    // ���ҽ� �Ŵ���
    ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource
    {
        get
        {
            return Instance._resource;
        }
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();   
    }

    static void Init()
    {
        if(s_instance == null )
        {   // �Ŵ��� �ν��Ͻ��� �����ϴ�.

            // �Ŵ����� �ϳ� �����մϴ�.
            GameObject go = GameObject.Find("@Managers");
            if( go == null )
            {   // ������ �Ŵ��� ������Ʈ�� �����ϴ�.
                // �� ������Ʈ�� �����մϴ�.
                // ������Ʈ�� �̸��� �����մϴ�.
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            // �������� ���ϰ� �϶�
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}
