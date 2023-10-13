using pindwin.umvr.Repository;
using UnityEngine;
using Zenject;

namespace pindwin.Scripts.Field
{
	public partial class FieldRepository
	{
		[Inject]
		public FieldRepository(FieldReactorFactory fieldReactorFactory, ZenjectToken _) : this(fieldReactorFactory)
		{
			AddIndex(nameof(IField.Coordinates), new SecondaryIndex<Vector3Int,IField>(nameof(IField.Coordinates), this));
		}
	}
}