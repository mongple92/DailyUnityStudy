using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    // Action으로 이벤트를 추가할때 <>안에 어떤 타입이 들어가느냐에 따라 Invoke에서 전달해야하는 인자가 달라진다.
    // 기본적으로 아무것도 포함하지 않으면 그냥 Invoke()를 호출.
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
            // Input.GetMouseButton(idx) -> idx 0 : 왼쪽마우스 버튼 / 1 : 오른쪽 마우스 버튼 / 2 : 가운데 휠
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
