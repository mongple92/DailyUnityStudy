using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Button : UI_Popup
{
    // UI목록들
    enum Buttons
    {
        PointButton = 0,
    }

    enum Texts
    {
        PointText   = 0,
        ScoreText
    }

    enum GameObjects
    {
        TestObject  = 0,
    }

    enum Images
    {
        ItemIcon    = 0,
    }

    int _score = 0;

    public void OnButtonClicked( PointerEventData data )
    {
        _score++;
        Get<Text>((int)Texts.ScoreText).text = $"점수 : {_score}";
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        Get<Button>((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position; }, Define.UIEvent.Drag);
    }
}
