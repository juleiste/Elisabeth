namespace Models
{
    public enum Slot
    {
        Weapon,
        Head,
        Body,
        Legs
    }

    public enum WeaponType
    {
        Axe,
        Bow,
        Dagger,
        Hammer,
        Staff,
        Sword,
        Wand
    }

     public enum ArmorType
    {
        Cloth,
        Leather,
        Mail,
        Plate
    }

    public abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Slot Slot { get; set; }

        protected Item(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }
    }

    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public int WeaponDamage { get; set; }

        public Weapon(string name, int requiredLevel, WeaponType weaponType, int weaponDamage)
            : base(name, requiredLevel, Slot.Weapon)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }
    }

    public class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public int ArmorRating { get; set; }

        public Armor(string name, int requiredLevel, ArmorType armorType, int armorRating, Slot slot)
            : base(name, requiredLevel, slot)
        {
            ArmorType = armorType;
            ArmorRating = armorRating;
        }
    }

}