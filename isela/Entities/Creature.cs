using isela.Base;
using isela.Base.Location; 
using isela.Entities.Items;
using isela.Utils;

namespace isela.Entities;

// Documenteret
/// <summary>
/// A creature that can move around the world and hit other creatures. Does not inherently contain a race.
/// </summary>
/// <param name="world"></param>
/// <param name="name"></param>
/// <param name="health"></param>
/// <param name="attack"></param>
/// <param name="location"></param>
public class Creature(World world, string name, int health, int attack, WorldPosition location) : WorldObject(world, location, true) {
	public new WorldPosition Location { get; set; } = location;
	public string Name { get; set; } = name;
	public int BaseHealth { get; set; } = health;
	public int Health { get; set; } = health;
	public int BaseAttack { get; set; } = attack;
	public int Attack { get; set; } = attack;
	public Weapon? EquippedWeapon { get; set; }

	private List<Stalker> Stalkers { get; } = [];

	public List<Lootable> Inventory { get; } = [];

	// Dependency Injection
	/// <summary>
	/// Hit another creature. Dependent on buffs from equipped weapon, multiplied by random number.
	/// </summary>
	/// <param name="creature">Creature to hit</param>
	/// <returns>Number of Hit Points Generated</returns>
	public virtual int Hit(Creature creature) {
		int points = World.rng.Next(1, Attack);
		creature.TakeHit(points);
		World.Trace.TraceEvent(System.Diagnostics.TraceEventType.Information, 1, $"{Name} hit {creature.Name} for {points} HP");
		return points;
	}

	/// <summary>
	/// Take a hit from another creature. Dependent on defence of equipped items.
	/// If health is 0, drop some items.
	/// </summary>
	public virtual void TakeHit(int damage) {
		Health -= damage;
		if(Health <= 0) {
			Health = 0;
			DropItems();
		}
	}

	/// <summary>
	/// Move to a new location. Notify all stalkers.
	/// </summary>
	public void MoveTo(WorldPosition position) {
		Location = position;
		foreach(Stalker stalker in Stalkers) {
			stalker.Update();
		}
	}

	/// <summary>
	/// Drops only some items to the current location, then deletes the rest.
	/// </summary>
	private void DropItems() {
		IEnumerable<Lootable> items = Inventory.Where(item => World.rng.Next(0, 2) == 1);
		// TODO: Luck component?
		foreach(Lootable item in items) {
			item.Location = Location;
		}
		Inventory.Clear();
	}

	public void Equip(int WeaponPosition) {
		if(WeaponPosition < Inventory.Count && Inventory[WeaponPosition] is Weapon weapon) {
			if(EquippedWeapon != null) {
				Attack -= EquippedWeapon.Attack;
				Loot(EquippedWeapon);
			}
			EquippedWeapon = weapon;
			Attack += weapon.Attack;
			Inventory.RemoveAt(WeaponPosition);
			World.Trace.TraceEvent(System.Diagnostics.TraceEventType.Information, 1, $"{Name} equipped {weapon.Name}");
		}
	}

	public void Loot(Lootable obj) {
		obj.Location = new InInventory(this);
		if(obj is AttackItem attackItem && attackItem != null && attackItem is not Weapon) {
			Attack += attackItem.Attack;
		}
		if(obj is DefenceItem defenceItem && defenceItem != null) {
			Health += defenceItem.Defence;
		}
		Inventory.Add(obj);
	}

	// LINQ
	/// <summary>
	/// Get the weapon with the highest attack in the inventory.
	/// </summary>
	/// <returns></returns>
	public Weapon? GetTopWeapon() {
		#pragma warning disable CS8602 // Dereference of a possibly null reference.
		var weaponsInOrder = from w in Inventory where w is Weapon orderby (w as Weapon).Attack descending select w;
		#pragma warning restore CS8602 // Dereference of a possibly null reference.
		return weaponsInOrder.First() as Weapon;
	}

	public void Attach(Stalker stalker) {
		Stalkers.Add(stalker);
	}

	public void Detach(Stalker stalker) {
		Stalkers.Remove(stalker);
	}
}