using UnityEngine;

public class T_HitBoxCreate : MonoBehaviour
{
	public GameObject HitBox;
	public float size = 1f;
	public PlayerState state;
	public GameObject HitboxCircle;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.E))
		{
			HitBox.transform.localScale = new Vector3(size, size, size);
			Instantiate(HitBox, gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetMouseButtonUp(0))
		{
			Effect effect = new Effect()
			{
				Duration = 1f,
				Times = 4,
				ValueCurrent = 10,
				ValueFinal = 20,
				VariableCurrent = Variable.Health,
				VariableFinal = Variable.Health,
			};
			SpellData spell = new SpellData()
			{
				Damage = 50,
				Effect = effect,
				Lifetime = 2f,
				TravelDistance = 10f,
				HitBox = new HitBox()
				{
					Radius_or_Height = 3,
					Type = HitBoxType.Circle,
					Width = 1,
				},
				Speed = 20,
				TrackMouse = false
			};
			var hitbox = Instantiate(HitboxCircle, gameObject.transform.position, Quaternion.identity);
			hitbox.GetComponent<HitboxActive>().Spell = spell;
		}
	}
}
