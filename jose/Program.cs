using isela.Base;
using isela.Base.Location;
using isela.Utils;
using jose;
using System.Diagnostics;

ConsoleTraceListener listener = new()
{
	Filter = new EventTypeFilter(SourceLevels.Information)
};

World world = new("isela.xml", [listener]);

ItemFactory Factory = ItemFactory.GetFactory();

Wall wall = new(world, new WorldPosition(0, 0));
Imp imp = new(world);
imp.Loot(Factory.CreateWeapon(world));
imp.Equip(0);
Human human = new(world);
human.Loot(Factory.CreateWeapon(world));
human.Equip(0);
human.Hit(imp);
Spy RedSpy = new(human);
human.Attach(RedSpy);
human.MoveTo(new WorldPosition(1, 1));
human.Loot(Factory.CreateWeapon(world));
human.Loot(Factory.CreateWeapon(world));
// Print world
Console.WriteLine(human.Name + "'s best weapon is " + human.GetTopWeapon());
Console.WriteLine(imp);
Console.WriteLine(human);