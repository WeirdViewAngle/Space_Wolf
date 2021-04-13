using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenWrap : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Vector2 wrapCharacter = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        if(wrapCharacter.x > ScreenUtils.ScreenRight)
        {
            wrapCharacter.x = ScreenUtils.ScreenLeft;
        }
        else if(wrapCharacter.x < ScreenUtils.ScreenLeft)
        {
            wrapCharacter.x = ScreenUtils.ScreenRight;
        }

        gameObject.transform.position = wrapCharacter;
    }

}
