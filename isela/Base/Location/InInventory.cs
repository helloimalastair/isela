using isela.Entities;
namespace isela.Base.Location;

public class InInventory(Creature owner) : ILocation {
	public Creature Owner { get; } = owner;
}