using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Managers
{
    // 캔버스 sort oder관리
    int _order = 0;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();

    // name : 프리팹이름
    // T : 스크립트 이름
    // 프리팹과 스크립트이름은 동일하게 맞춰줘야한다.
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if( string.IsNullOrEmpty(name))
        {   // 프리팹 이름이 없다면 스크립트 이름과 동일하게 하겠다.
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
