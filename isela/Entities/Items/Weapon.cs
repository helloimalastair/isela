using isela.Base;
using isela.Base.Location;

namespace isela.Entities.Items;

public class Weapon(World world, string name, int attack, ILocation location) : AttackItem(world, name, attack, location) {
	public override string ToString()
	{
		return Name + " with " + Attack + " attack";
	}
}