namespace Task5
{
    public class GroundBuilder : IGroundBuilder
    {
        private Ground _ground = new Ground();

        public void BuildGallery()
        {
            _ground.AddPart("Italian-style curved gallery");
        }

        public void BuildSurface()
        {
            _ground.AddPart("Natural grass surface");
        }

        public void BuildAudience()
        {
            _ground.AddPart("Passionate Italian crowd");
        }

        public Ground GetGround()
        {
            return _ground;
        }
    }
}