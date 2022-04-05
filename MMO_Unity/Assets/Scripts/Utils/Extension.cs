using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// ����Ƽ�� �����ڵ带 ������ �� ������ ������ �ڵ带 ���� �� �ִ�. = extension method
public static class Extension
{
    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.AddUIEvent(go, action, type);
    }
}
