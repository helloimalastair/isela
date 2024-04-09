using System.Xml;
namespace isela.Base;
using System.Diagnostics;

// Configuration
public class World {

	public TraceSource Trace { get; } = new("Isela") {
		Switch = new SourceSwitch("Isela", "All")
	};
	public int MaxX { get; }
	public int MaxY { get; }
	// Liskov
	public List<WorldObject> Objects { get; } = new();
	public readonly Random rng;

	public World(string? ConfigPath, List<TraceListener>? listener = null) {
		if(ConfigPath == null) {
			MaxX = 100;
			MaxY = 100;
			rng = new();
		} else {
			XmlDocument doc = new();
			doc.Load(ConfigPath);
			XmlNode? WorldNode = doc.SelectSingleNode("World") ?? throw new("Invalid configuration file.");
			XmlNode? MaxXNode = WorldNode.SelectSingleNode("MaxX");
			if(MaxXNode == null) {
				MaxX = 100;
			} else {
				MaxX = int.Parse(MaxXNode.InnerText);
			}
			XmlNode? MaxYNode =  WorldNode.SelectSingleNode("MaxY");
			if(MaxYNode == null) {
				MaxY = 100;
			} else {
				MaxY = int.Parse(MaxYNode.InnerText);
			}
			XmlNode? SeedNode =  WorldNode.SelectSingleNode("Seed");
			if(SeedNode != null) {
				rng = new(int.Parse(SeedNode.InnerText));
			} else {
				rng = new();
			}
		}
		if(listener != null) {
			foreach(TraceListener l in listener) {
				Trace.Listeners.Add(l);
			}
		}
		Trace.TraceEvent(TraceEventType.Information, 0, "World Initialized. Welcome to Isela!");
	}
}