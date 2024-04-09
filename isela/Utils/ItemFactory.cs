using isela.Base;
using isela.Base.Location;
using isela.Entities.Items;

namespace isela.Utils;

// Factory 
public class ItemFactory {
	private static readonly ItemFactory factory = new();
	private ItemFactory() {}
	public static ItemFactory GetFactory() {
		return factory;
	}
	public static readonly string[] name = ["Kherdem", "Jeirdum", "Rorstol", "Gendom", "Mordem", "If", "Zelden", "Strur", "Hajodih", "Zuh-kuf", "Shomvordid", "Rorzos", "Chah", "Thiap", "Groribo", "Idre", "Nahmir", "Nadum", "Bruldig", "Toven", "Mogrem", "Nal", "Vegrur", "Tor", "Githeo-maoth", "Hom-vuk", "Jilmasdos", "Tarvis", "Jia", "Hiem", "Huscalel", "Toruel"];
	private static readonly string[] weaponType = ["Sword", "Axe", "Mace", "Bow", "Staff", "Dagger", "Spear", "Halberd", "Crossbow", "Wand", "Club", "Flail", "Scythe", "Pike", "Rapier", "Trident", "Morningstar", "Warhammer", "Greatsword"];
	private static readonly string[] weaponAdjective = ["Doom", "Wrath", "Fury", "Rage", "Pain", "Suffering", "Torment", "Agony", "Anguish", "Misery", "Distress", "Torture"];
 	public Weapon CreateWeapon(World world) {
		var x = world.rng.Next(world.MaxX);
		var y = world.rng.Next(world.MaxY);
		var item = new Weapon(world, name[world.rng.Next(name.Length)] + "'s " + weaponType[world.rng.Next(weaponType.Length)] + " of " + weaponAdjective[world.rng.Next(weaponAdjective.Length)], world.rng.Next(1, 15), new WorldPosition(x, y));
		world.Objects.Add(item);
		return item;
	}


}