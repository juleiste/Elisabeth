// Prompt the user to select a character class
using Models;

Console.Write("Please select your character class: ");
var classTypes = Enum.GetNames(typeof(Class.ClassNameEnum));
string classTypesString = string.Join(", ", classTypes);
Console.WriteLine(classTypesString);
string characterClass = Console.ReadLine();

Console.Write("Please select your character name: ");
string characterName = Console.ReadLine();

// Create a new character object based on the user input
Hero character = CharacterFactory.CreateCharacter(characterClass, characterName);

// Prompt the user to select a character weapon
// Console.Write("Please select your character weapon: ");
// var weaponTypes = Enum.GetNames(typeof(WeaponType));
// string weaponTypesString = string.Join(", ", weaponTypes);
// Console.WriteLine(weaponTypesString);


//START STORY
Console.Clear();
Console.Write("You find the epic Sword of the Gods. Do you want to equip it? (y/n)");
var result = Console.ReadKey();
Console.Clear();
if(result.KeyChar == 'y')
{
    character.EquipWeapon(new Weapon("Sword of the Gods", 1, WeaponType.Sword, 100));
    Console.WriteLine("You equip the sword and feel like a million bucks!");
}
else
{
    Console.WriteLine("You leave the sword behind..");
}

Console.WriteLine("You encounter a troll that needs some serious beating. Do you attack? (y/n)");
result = Console.ReadKey();
Console.Clear();
if(result.KeyChar == 'y')
{
    if(character.Equipment[0].Value == null)
    {
        Console.WriteLine("You dont have a weapon equipped. You die!");
        return;
    }
    Console.WriteLine($"You attack the troll and deal {(character.Equipment[0].Value as Weapon)?.WeaponDamage ?? 0} damage! It dies because you are very good at killing things");

    character.LevelUp();
}
else
{
    Console.WriteLine("You run away like a coward!");
}
//Console.Clear();
//Console.WriteLine(character.Level);
Console.WriteLine("The troll leaves behind a shiny axe. Do you pick it up? (y/n)");
result = Console.ReadKey();
Console.Clear();
if(result.KeyChar == 'y')
{
    character.EquipWeapon(new Weapon("Axe of the Troll", 2, WeaponType.Axe, 1));
    Console.WriteLine($"You equip the axe and it looks very nice. It does only {(character.Equipment[0].Value as Weapon)?.WeaponDamage ?? 0} damage though, but who cares when its pink?");
}
else
{
    Console.WriteLine("You leave the axe behind..");
}


//Level up character
//WeaponType weapon = (WeaponType)Enum.Parse(typeof(WeaponType), Console.ReadLine(), true);

//character.EquipWeapon(new Weapon("Sword of the Gods", 1, weapon, 100));

// Display character info
//Console.Clear();
//character.DisplayInfo();

// Wait for user input before exiting
Console.WriteLine("Press any key to exit...");
Console.ReadKey();