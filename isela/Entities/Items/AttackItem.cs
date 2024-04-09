using isela.Base;
using isela.Base.Location;

namespace isela.Entities.Items;

public class AttackItem(World world, string name, int attack, ILocation location) : Lootable(world, location, false) {
	public string Name { get; set; } = name;

	public int Attack { get; set; } = attack;
}