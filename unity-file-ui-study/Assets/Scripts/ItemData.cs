using UnityEngine;

public enum ItemTypes
{
    Weapon,
    Equip,
    Consumable,

}

public class ItemData
{
    public string Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public int Value { get; set; }
    public int Cost { get; set; }
    public string Icon { get; set; }

    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringDesc => DataTableManager.StringTable.Get(Desc);
    public Sprite spriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");
}
