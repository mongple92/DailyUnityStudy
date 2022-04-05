using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // 최상위 관리자
    static Managers s_instance; // 유일성이 보장된다.
    static Managers Instance { get { Init(); return s_instance;  }  }

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();

    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }

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
        {   // 매니저 인스턴스가 없습니다.

            // 매니저를 하나 생성합니다.
            GameObject go = GameObject.Find("@Managers");
            if( go == null )
            {   // 가져올 매니저 오브젝트가 없습니다.
                // 빈 오브젝트를 생성합니다.
                // 오브젝트의 이름을 셋팅합니다.
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            // 삭제되지 못하게 하라
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}
