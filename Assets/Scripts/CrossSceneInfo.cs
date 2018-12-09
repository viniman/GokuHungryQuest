using UnityEngine;

/// Funciona apenas como meio de manter as informações do load após a mudança de cena
public class CrossSceneInfo
{
	public static int level { get; set; }
	public static Vector3 pointToSpawn { get; set; }
	public static int coinsCollected { get; set; }
	public static int gokuState { get; set; }
}
