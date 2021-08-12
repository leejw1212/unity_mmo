using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    class Test
    {
        public int Id = 0;

    }

    class CoroutineTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 100000000; i++)
            {
                if (i % 100000 == 0)
                    yield return null;
            }
        }
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Inven>();

        CoroutineTest test = new CoroutineTest();
    }

    public override void Clear()
    {
        
    }
    
}
