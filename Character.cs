abstract class Character
{
    public Slots Slots { get; set; }
    public enum Type { Warrior, Mage }
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Character Info:");
        Console.WriteLine($"Selected Weapon: {Slots.Weapon}");
    }
}

class Slots
{
    public enum Chest { Plate, Robe, None };
    public enum Legs { Pants, Skirt, None };
    public enum Feet { Boots, Sandals, None };
    public enum Hands { Gauntlets, Gloves, None };
    public Items.Weapon Weapon;
    public Items.Weapon[] validWeapons;
    public void SetWeapon(Items.Weapon weapon)
    {
        if (validWeapons.Contains(weapon))
        {
            Weapon = weapon;
        }
        else
        {
            throw new Exception("Invalid weapon choice for character type");
        }
    }
}
class Warrior : Character
{
    public Warrior()
    {
        Console.WriteLine("Warrior created");
        Slots = new Slots
        {
            validWeapons = new Items.Weapon[] { Items.Weapon.Axe, Items.Weapon.Sword }
        };

    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Class: Warrior");
    }
}

class Mage : Character
{
    public Mage()
    {
        Console.WriteLine("Mage created");
        Slots = new Slots
        {
            validWeapons = new Items.Weapon[] { Items.Weapon.Wand }
        };
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Class: Mage");
    }
}

static class CharacterFactory
{
    public static Character CreateCharacter(string characterType)
    {
        switch (characterType.ToLower())
        {
            case "warrior":
                return new Warrior();
            case "mage":
                return new Mage();
            default:
                throw new ArgumentException("Invalid character type");
        }
    }
}

class Items
{
    public enum Weapon { Axe, Sword, Wand };
    public enum Chest { Plate, Robe };
    public enum Legs { Pants, Skirt };
    public enum Feet { Boots, Sandals };
    public enum Hands { Gauntlets, Gloves };
}