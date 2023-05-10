namespace Models
{
    abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Class Class { get; set; }
        public HeroAttribute HeroAttribute { get; set; }
        public KeyValuePair<Slot, Item>[] Equipment { get; set; }
        public WeaponType[] ValidWeaponTypes;
        public ArmorType[] ValidArmorTypes;
        protected Hero(string name)
        {
            Name = name;
            Level = 1;
            Equipment = new KeyValuePair<Slot, Item>[3];
        }

        public void LevelUp()
        {
            Level++;
            HeroAttribute.Strength += Class.LevelAttributes.Strength;
            HeroAttribute.Dexterity += Class.LevelAttributes.Dexterity;
            HeroAttribute.Intelligence += Class.LevelAttributes.Intelligence;
        }

        public void EquipWeapon(Weapon weapon)
        {
            if ((ValidWeaponTypes.Contains(weapon.WeaponType) && (weapon.RequiredLevel <= Level)))
            {
                Equipment[0] = new KeyValuePair<Slot, Item>(Slot.Weapon, weapon);
            }
            else
            {
                Console.WriteLine("You cant use this. Its either too high level or not the right type of weapon");
            }
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Class: {Class.ClassName}");
            Console.WriteLine($"Strength: {HeroAttribute.Strength}");
            Console.WriteLine($"Dexterity: {HeroAttribute.Dexterity}");
            Console.WriteLine($"Intelligence: {HeroAttribute.Intelligence}");
            foreach(var item in Equipment)
            {
                if(item.Value != null)
                {
                    Console.WriteLine($"{item.Key}: {item.Value.Name}");
                }
            }
        }
    }

    class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            Class = new Class(Class.ClassNameEnum.Warrior, new HeroAttribute(3, 2, 1));
            HeroAttribute = new HeroAttribute(5, 2, 1);
            ValidWeaponTypes = new WeaponType[] { WeaponType.Axe, WeaponType.Sword };
            ValidArmorTypes = new ArmorType[] { ArmorType.Mail, ArmorType.Plate };
        }
    }
    class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
            Class = new Class(Class.ClassNameEnum.Mage, new HeroAttribute(1, 1, 5));
            HeroAttribute = new HeroAttribute(5, 2, 1);
            ValidWeaponTypes = new WeaponType[] { WeaponType.Wand };
            ValidArmorTypes = new ArmorType[] { ArmorType.Cloth };
        }
    }

    static class CharacterFactory
    {
        public static Hero CreateCharacter(string characterType, string name)
        {
            return characterType.ToLower() switch
            {
                "warrior" => new Warrior(name),
                "mage" => new Mage(name),
                _ => throw new ArgumentException("Invalid character type"),
            };
        }
    }
}