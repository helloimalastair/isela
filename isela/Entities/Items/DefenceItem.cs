using isela.Base;
using isela.Base.Location;

namespace isela.Entities.Items;

public class DefenceItem(World world, string name, int defence, ILocation location) : Lootable(world, location, false) {
	public string Name { get; set; } = name;

	public int Defence { get; set; } = defence;
}