namespace modules.bicycle
{
    public class Collision
    {
        public CollisionsController.Tag source;
        public CollisionsController.Tag target;

        public Collision(CollisionsController.Tag source, CollisionsController.Tag target)
        {
            this.source = source;
            this.target = target;
        }
    
        public override bool Equals(object obj)
        {
            if (!(obj is Collision collision)) return false;
            return source == collision.source && target == collision.target;
        }
    }
}