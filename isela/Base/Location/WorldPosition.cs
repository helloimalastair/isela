namespace isela.Base.Location;

public class WorldPosition(int X, int Y) : ILocation {
	public int X { get; set; } = X;
	public int Y { get; set; } = Y;

	public override string ToString() {
		return $"({X}, {Y})";
	}
}