using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    // Action���� �̺�Ʈ�� �߰��Ҷ� <>�ȿ� � Ÿ���� �����Ŀ� ���� Invoke���� �����ؾ��ϴ� ���ڰ� �޶�����.
    // �⺻������ �ƹ��͵� �������� ������ �׳� Invoke()�� ȣ��.
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false;
    public void OnUpdate()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return; 
        }

        if(Input.anyKey && KeyAction != null)
        {
            KeyAction.Invoke();
        }

        if(MouseAction != null)
        {
            // Input.GetMouseButton(idx) -> idx 0 : ���ʸ��콺 ��ư / 1 : ������ ���콺 ��ư / 2 : ��� ��
            if(Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if( _pressed )
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                    _pressed = false;
                }
            }
        }
    }
}
