// Prompt the user to select a character class
Console.WriteLine("Please select your character class: Warrior or Mage");
string classInput = Console.ReadLine();

// Create a new character object based on the user input
Character character = CharacterFactory.CreateCharacter(classInput);

Console.WriteLine("Please select your character weapon: Axe, Sword, or Wand");
string weaponInput = Console.ReadLine();
Items.Weapon weapon = (Items.Weapon)Enum.Parse(typeof(Items.Weapon), weaponInput, true);

// Display character info
character.Slots.SetWeapon(weapon);
Console.Clear();
character.DisplayInfo();