namespace modules.bicycle
{
    public class Trick
    { 
        public string Id { get; }

        public Trick(string id)
        {
            Id = id;
        }

        public float initTime;
        public float pauseTime;

        public void Reset()
        {
            initTime = 0f;
            pauseTime = 0f;
        }
    }
}