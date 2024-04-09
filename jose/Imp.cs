using isela.Base;
using isela.Base.Location;
using isela.Entities;

namespace jose;

public class Imp : Creature {
	public Imp(World world): base(world, "Gorlock", world.rng.Next(1, 10), 1, new WorldPosition(world.rng.Next(world.MaxX), world.rng.Next(world.MaxY))) {
		world.Objects.Add(this);
	}

	public override string ToString() {
		if(Health > 0) {
			return $"Imp {Name} at {Location} with {Health} HP.";
		}
		return $"Imp {Name} at {Location} is dead.";
	}
}