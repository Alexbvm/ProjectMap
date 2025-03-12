namespace ProjectMap.WebApi.Models
{
    public class Object2D
    {
        public Guid Id { get; set; }

        public string PrefabId { get; set; }

        public float PositionX { get; set; }

        public float PositionY { get; set; }

        public float ScaleX { get; set; }

        public float ScaleY { get; set; }

        public float RotationZ { get; set; }

        public int SortingLayer { get; set; }
        public string EnvironmentId { get; set; }
    }

    public class Object2DDTO

    {

        public string PrefabId { get; set; }

        public float PositionX { get; set; }

        public float PositionY { get; set; }

        public float ScaleX { get; set; }

        public float ScaleY { get; set; }

        public float RotationZ { get; set; }

        public int SortingLayer { get; set; }
    }
}
