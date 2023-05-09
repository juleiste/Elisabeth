// Prompt the user to select a character class
using Models;

Console.Write("Please select your character class: ");
var classTypes = Enum.GetNames(typeof(Character.Type));
string classTypesString = string.Join(", ", classTypes);
Console.WriteLine(classTypesString);

string classInput = Console.ReadLine();

// Create a new character object based on the user input
Character character = CharacterFactory.CreateCharacter(classInput);

Console.Write("Please select your character weapon: ");
var weaponTypes = Enum.GetNames(typeof(Items.Weapon));
string weaponTypesString = string.Join(", ", weaponTypes);
Console.WriteLine(weaponTypesString);

string weaponInput = Console.ReadLine();
Items.Weapon weapon = (Items.Weapon)Enum.Parse(typeof(Items.Weapon), weaponInput, true);

// Display character info
character.SetWeapon(weapon);
Console.Clear();
character.DisplayInfo();