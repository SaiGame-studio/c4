using UnityEngine;

public class TextPlayerLvlCount : TextAbstact
{
    protected virtual void FixedUpdate()
    {
        this.LoadCount();
    }

    protected virtual void LoadCount()
    {
        this.textPro.text = PlayerCtrl.Instance.Level.CurrentLevel.ToString();
    }
}
