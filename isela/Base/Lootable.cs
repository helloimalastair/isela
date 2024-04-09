using isela.Base.Location;
namespace isela.Base;

public class Lootable(World world, ILocation location, bool damageble = false): WorldObject(world, location, damageble) {}