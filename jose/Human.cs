using isela.Base;
using isela.Base.Location;
using isela.Entities;
using isela.Utils;

namespace jose;

public class Human : Creature {

	public Human(World world): base(world, ItemFactory.name[world.rng.Next(ItemFactory.name.Length)], world.rng.Next(1, 30), world.rng.Next(1, 2), new WorldPosition(world.rng.Next(world.MaxX), world.rng.Next(world.MaxY))) {
		world.Objects.Add(this);
	}

	public override string ToString() {
		if(Health > 0) {
			return $"Hyumon {Name} at {Location} with {Health} HP.";
		}
		return $"Hyumon {Name} at {Location} is dead.";
	}
}