using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Managers
{
    // ĵ���� sort oder����
    int _order = 0;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();

    // name : �������̸�
    // T : ��ũ��Ʈ �̸�
    // �����հ� ��ũ��Ʈ�̸��� �����ϰ� ��������Ѵ�.
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if( string.IsNullOrEmpty(name))
        {   // ������ �̸��� ���ٸ� ��ũ��Ʈ �̸��� �����ϰ� �ϰڴ�.
            name = typeof(T).Name;
        }

        GameObject go = Managers.Resource.instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        return null;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
        {
            return;
        }

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }
}
