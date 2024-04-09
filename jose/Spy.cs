using isela.Entities;
using isela.Utils;
namespace jose;

public class Spy(Creature creature): Stalker {
	private Creature Creature { get; } = creature;

	public override void Update() {
		Console.WriteLine($"Spy: {Creature.Name} has moved to {Creature.Location}");
	}
}