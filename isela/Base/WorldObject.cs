using isela.Base.Location;
namespace isela.Base;

// Template
// Single Responsibility
// Open/Closed: Takes any ILocation
public abstract class WorldObject {
	public World World { get; }
	public virtual ILocation Location { get; set; }
	public bool Damageble { get; }

	public WorldObject(World world, ILocation location, bool damageble = false) {
		World = world;
		Location = location;
		Damageble = damageble;

		World.Objects.Add(this);
	}
}