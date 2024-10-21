using UnityEngine;

public class BtnCloseSetting : ButttonAbstract
{
    public virtual void CloseInventoryUI()
    {
        UISetting.Instance.Hide();
    }

    protected override void OnClick()
    {
        this.CloseInventoryUI();
    }
}
